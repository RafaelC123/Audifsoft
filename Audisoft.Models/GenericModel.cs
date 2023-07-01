using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Models
{
    /// <summary>
    /// Clase generica para modelos realizados desde CodeFirst
    /// </summary>
    public class GenericModel
    {
        /// <summary>
        /// Id de la entidad que corresponde a Numeric(20,0)
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Fecha de actualización
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}
