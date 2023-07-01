using Audisoft.Domain.Repositories.Interfaces;
using Audisoft.Dtos;
using Audisoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Domain.Services.Interfaces
{
    public interface IGenericService<InDto, OutDto, T> where InDto : class, new() where OutDto : GenericOutDto, new() where T : GenericModel, new()
    {
        /// <summary>
        /// Obtiene el primer elemento seleccionado por el Id
        /// </summary>
        public Task<T> GetFirstAsync(decimal Id);
        /// <summary>
        /// Obtiene todos los elementos
        /// </summary>
        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Where = null);
        /// <summary>
        /// Crea una entidad
        /// </summary>
        public Task<Status<T>> CreateAsync(T Entity, string ValidateStoreName = null);
        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        public Task<Status<T>> UpdateAsync(T Entity, decimal Id, string ValidateStoreName = null);
        /// <summary>
        /// Elimina una entidad
        /// </summary>
        public Task<Status<T>> DeleteAsync(T Entity, string ValidateStoreName = null);


        public void SetRepository(IGenericRepository<T> NewRepository);
    }
}
