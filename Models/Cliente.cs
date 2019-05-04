using AspNetCoreMVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AspNetCoreMVCCRUD.Models
{
    public class Cliente
    {

        [Key]
        public int ClienteId { get; set; }
        [RegularExpression(@"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)", ErrorMessage = "Formato de CPF inválido.")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "CPF inválido")]
        [Required(ErrorMessage = "O campo CPF não pode ficar em branco")]
        public string CPF { get; set; }

        [StringLength(150, ErrorMessage = "O Nome excedeu o limite")]
        [Required(ErrorMessage = "O campo Nome não pode ficar em branco")]
        public string Nome { get; set; }

        [ValidarEstado(ErrorMessage = "O campo Estado não pode ficar em branco")]
        public string SiglaEstado { get; set; }
        }
    }
