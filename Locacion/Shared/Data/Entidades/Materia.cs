using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacion.Comunes.Data.Entidades
{
    [Index(nameof(CodMateria), Name = "UQ_Materia_Codmateria", IsUnique =true)]
    public class materia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El código de la Materia es obligatorio.")]
        [MaxLength(2, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string CodMateria { get; set; }

        [Required(ErrorMessage = "El Nombre de la Materia es obligatorio.")]
        [MaxLength(120, ErrorMessage = "El campo tiene como máximo {1} caracteres.")]
        public string NombreMateria { get; set; }

    }
}
