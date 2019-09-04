namespace CadastroAgentes.Business.Models
{
    public class Status : Entity
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public enum CodigoStatus
        {
            CadastroPrevio = 1,
            Pendente = 2,
            Encaminhado = 3,
            Aprovado = 4
        }
    }
}
