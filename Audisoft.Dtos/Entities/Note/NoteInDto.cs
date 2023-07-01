﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audisoft.Dtos.Entities.Note
{
    public class NoteInDto
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
    }
}
