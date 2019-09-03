using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAgentes.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }

        public Status Status { get; set; }
        //public User UsuarioAnalise { get; set; }
        public DateTime? DataTerminoAnalise { get; set; }
    }
}
