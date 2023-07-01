using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Models.Entities
{
    /// <summary>
    /// Entidad para las notas 
    /// </summary>
    public class Note : GenericModel
    {
        /// <summary>
        /// Valor de la nota
        /// </summary>
        [Range(0, 5.0)]
        public double Value { get; set; }

        /// <summary>
        /// Id del estudiante
        /// </summary>
        public decimal StudentId { get; set; }
        /// <summary>
        /// Id del profesor que indica la nota
        /// </summary>
        public decimal TeacherId { get; set; }

        /*
         * 
         * Propiedades de navegación para 
         * Entity Framework
         * 
         */
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
