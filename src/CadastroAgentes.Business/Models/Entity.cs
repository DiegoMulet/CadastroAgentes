using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroAgentes.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public enum StatusEnum
        {
            CadastroPrevio = 1,
            Pendente = 2,
            Encaminhado = 3,
            Aprovado = 4
        }
    }
}
