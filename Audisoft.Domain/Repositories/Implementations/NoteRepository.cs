using Audisoft.Data.Context;
using Audisoft.Domain.Repositories.Interfaces;
using Audisoft.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Domain.Repositories.Implementations
{
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Note>> GetAsync(Expression<Func<Note, bool>> WhereCondition = null, Expression<Action<Note>> Select = null)
        {
            dbSet.AsNoTracking();
            IQueryable<Note> resultQuery = dbSet;
            if (WhereCondition != null)
                resultQuery = resultQuery.Where(WhereCondition);


            return await resultQuery.Include(x => x.Teacher).Include(x => x.Student).ToListAsync();
        }
    }
}
