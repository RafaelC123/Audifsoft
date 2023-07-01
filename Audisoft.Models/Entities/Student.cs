using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Models.Entities
{
    /// <summary>
    /// Clase que modela a la entidad para estudiantes
    /// </summary>
    public class Student : GenericModel
    {
        /// <summary>
        /// Nombre del estudiante
        /// </summary>
        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /*
         * Propiedades de navegación para 
         * EntityFramework
         */

        public virtual ICollection<Note> Notes { get; set; }
    }
}
