using Audisoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Domain.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : GenericModel
    {
        /// <summary>
        /// Obtener primer elemento por Id
        /// </summary>
        public Task<T> GetFirstAsync(decimal Id);
        /// <summary>
        /// Obtener todos los elementos seleccionados
        /// </summary>
        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> WhereCondition = null, Expression<Action<T>> Select = null);
        /// <summary>
        /// Crear elementos
        /// </summary>
        public Task<T> CreateAsync(T Entity);
        /// <summary>
        /// Crear por colleccion 
        /// </summary>
        public Task<List<T>> CreateFromCollection(IEnumerable<T> Entities);
        /// <summary>
        /// Actualizar elementos
        /// </summary>
        public Task<T> UpdateAsync(T Entity);
        /// <summary>
        /// Eliminar elementos
        /// </summary>
        public Task<T> DeleteAsync(T Entity);
        /// <summary>
        /// Ejecutar validaciones por procedimiento almacenado
        /// </summary>
        public Task<string> ExecuteValidateStore(string NameStore, string Action, T Entity, decimal? Id = null);


        /// <summary>
        /// Guardar cambios realizados
        /// </summary>
        /// <returns></returns>
        public Task<bool> SaveChangesAsync();

        /// <summary>
        /// Valida si se esta usando una transaccion
        /// </summary>
        public bool IsUsingTransaction();
        /// <summary>
        /// Iniciar transacción
        /// </summary>
        public Task InitializeTransaction();
        /// <summary>
        /// Devuelve o reversa operaciones realizadas en la transaccion
        /// </summary>
        public Task RollbackTransaction();
        /// <summary>
        /// Cierra una transaccion
        /// </summary>
        /// <returns></returns>
        public Task CloseTransaction();


        /// <summary>
        /// Eliminar varios elementos
        /// </summary>
        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> Entities);
        /// <summary>
        /// Actualiza varios elementos
        /// </summary>
        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> Entities);
    }
}
