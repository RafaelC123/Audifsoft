using Audisoft.Application.Enums;
using Audisoft.Domain.Repositories.Interfaces;
using Audisoft.Domain.Services.Interfaces;
using Audisoft.Dtos;
using Audisoft.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Domain.Services.Implementation
{
    public class GenericService<InDto, OutDto, T> : IGenericService<InDto, OutDto, T> where InDto : class, new() where OutDto : GenericOutDto, new() where T : GenericModel, new()
    {
        protected IMapper mapper;
        protected IGenericRepository<T> repository;

        public GenericService(IMapper mapper, IGenericRepository<T> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Where = null)
        {
            var data = await this.repository.GetAsync(Where);
            return data;
        }

        public virtual Task<T> GetFirstAsync(decimal Id)
        {
            return this.repository.GetFirstAsync(Id);
        }

        /*
         * Db
         * Actions
         */

        public virtual async Task<Status<T>> CreateAsync(T Entity, string ValidateStoreName = null)
        {
            try
            {
                Entity.CreatedAt = DateTime.Now;
                Entity.UpdatedAt = DateTime.Now;
                if (ValidateStoreName is not null)
                {
                    var ValidateResult = await ExecuteValidations(ValidateStoreName, "CREATE", Entity);
                    if (ValidateResult != "IsValid")
                        return new Status<T>(ValidateResult, TypeMessage.Error, Entity);
                }
                await this.repository.CreateAsync(Entity);
                await this.repository.SaveChangesAsync();
                return new Status<T>("Se creó el registro correctamente", TypeMessage.Success, Entity);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public virtual async Task<Status<T>> UpdateAsync(T Entity, decimal Id, string ValidateStoreName = null)
        {
            Entity.Id = Id;
            Entity.UpdatedAt = DateTime.Now;

            if (ValidateStoreName is not null)
            {
                var ValidateResult = await ExecuteValidations(ValidateStoreName, "UPDATE", Entity, Id);
                if (ValidateResult != "IsValid")
                    return new Status<T>(ValidateResult, TypeMessage.Error, Entity);
            }
            await this.repository.UpdateAsync(Entity);
            await this.repository.SaveChangesAsync();
            return new Status<T>("Se actualizó el registro correctamente", TypeMessage.Success, Entity);
        }

        public virtual async Task<Status<T>> DeleteAsync(T Entity, string ValidateStoreName = null)
        {
            if (ValidateStoreName is not null)
            {
                var ValidateResult = await ExecuteValidations(ValidateStoreName, "DELETE", Entity, Entity.Id);
                if (ValidateResult != "IsValid")
                    return new Status<T>(ValidateResult, TypeMessage.Error, Entity);
            }
            await this.repository.DeleteAsync(Entity);
            await this.repository.SaveChangesAsync();
            return new Status<T>("Se eliminó el registro correctamente", TypeMessage.Success, Entity);
        }

        protected async Task<string> ExecuteValidations(string StoreName, string Action, T Entity, decimal? Id = null)
        {
            return await this.repository.ExecuteValidateStore(StoreName, Action, Entity, Id);
        }

        public void SetRepository(IGenericRepository<T> NewRepository)
        {
            this.repository = NewRepository;
        }
    }
}
