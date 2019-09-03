using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAgentes.Business.Models
{
    public class Status : Entity
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
