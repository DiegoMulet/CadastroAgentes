using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroAgentes.WebApi.ViewModels
{
    public class StatusViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public int? Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
