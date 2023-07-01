using Audisoft.Application.CustomAttributes.Models;
using Audisoft.Data.Context;
using Audisoft.Domain.Repositories.Interfaces;
using Audisoft.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Audisoft.Domain.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : GenericModel
    {
        protected readonly ApplicationDbContext context;
        protected DbSet<T> dbSet;
        private bool UsingTransaction { get; set; } = false;
        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public bool IsUsingTransaction() => UsingTransaction;
        public async Task InitializeTransaction()
        {
            UsingTransaction = true;
            await context.Database.BeginTransactionAsync();
        }
        public async Task RollbackTransaction()
        {
            UsingTransaction = false;
            await context.Database.RollbackTransactionAsync();
        }
        public async Task CloseTransaction()
        {
            UsingTransaction = false;
            await context.Database.CommitTransactionAsync();
        }
        public virtual async Task<T> CreateAsync(T Entity)
        {
            await dbSet.AddAsync(Entity);
            return Entity;
        }

        public virtual async Task<List<T>> CreateFromCollection(IEnumerable<T> Entities)
        {
            this.dbSet.AsNoTracking();
            await this.dbSet.AddRangeAsync(Entities);
            return Entities.ToList();
        }
        public virtual async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> Entities)
        {
            Entities.ToList().ForEach(Entity =>
            {
                var existingEntity = dbSet.Local.FirstOrDefault(e => e.Id == Entity.Id);
                if (existingEntity is not null)
                    context.Entry(existingEntity).State = EntityState.Detached;
            });

            await Task.Run(() => this.dbSet.UpdateRange(Entities));
            return Entities;
        }

        public virtual async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> Entities)
        {
            dbSet.AsNoTracking();
            await Task.Run(() => this.dbSet.RemoveRange(Entities));
            return Entities;
        }

        public virtual async Task<T> DeleteAsync(T Entity)
        {
            dbSet.AsNoTracking();
            await Task.Run(() => this.dbSet.Remove(Entity));
            return Entity;
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> WhereCondition = null, Expression<Action<T>> Select = null)
        {
            dbSet.AsNoTracking();
            IQueryable<T> resultQuery = dbSet;
            if (WhereCondition != null)
                resultQuery = resultQuery.Where(WhereCondition);

            return await resultQuery.ToListAsync();
        }

        public virtual async Task<T> GetFirstAsync(decimal Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            await context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<T> UpdateAsync(T Entity)
        {
            var existingEntity = context.Set<T>().Local.FirstOrDefault(e => e.Id == Entity.Id);
            if (existingEntity is not null)
                context.Entry(existingEntity).State = EntityState.Detached;

            await Task.Run(() => dbSet.Update(Entity).Property(x => x.CreatedAt).IsModified = false);
            return Entity;
        }


        public virtual async Task<string> ExecuteValidateStore(string NameStore, string Action, T Entity, decimal? Id = null)
        {
            var scheme = typeof(T).GetCustomAttribute<Scheme>().scheme;
            var MessageOut = new SqlParameter("@Message", SqlDbType.NVarChar, 3500);
            MessageOut.Direction = ParameterDirection.Output;

            List<object> Params = new List<object>
                    { new SqlParameter("@Action",Action),new SqlParameter("@IdEntity", Id ?? 0), MessageOut, };

            typeof(T).GetProperties().Where(x => x.GetCustomAttribute<IsParamValidate>() != null).ToList().ForEach(p =>
            {
                Params.Add(new SqlParameter($"@{p.Name}", p.GetValue(Entity)));
            });
            try
            {
                using (SqlConnection connection = new SqlConnection(this.context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = scheme + "." + NameStore;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(Params.ToArray());
                        int result = await command.ExecuteNonQueryAsync();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }



            return MessageOut.SqlValue.ToString();
        }
    }
}
