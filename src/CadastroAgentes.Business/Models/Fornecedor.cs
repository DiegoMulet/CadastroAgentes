using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAgentes.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataAbertura { get; set; }
        public int QtdFuncionarios { get; set; }
        public Status Status { get; set; }
        //public User UsuarioAnalise { get; set; }
        public DateTime? DataTerminoAnalise { get; set; }       
    }
}
