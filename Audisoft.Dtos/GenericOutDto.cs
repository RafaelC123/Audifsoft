using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Dtos
{
    /// <summary>
    /// Dto de salida generico con propiedades requeridas
    /// </summary>
    public class GenericOutDto
    {
        public decimal Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
