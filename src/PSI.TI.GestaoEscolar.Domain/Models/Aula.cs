namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Aula : Entity
    {
        public string Assunto { get; private set; }
        public Chamada Chamada { get; private set; }

        // For EF
        protected Aula()
        {
            
        }

        protected Aula(string assunto, Chamada chamada)
        {
            Assunto = assunto;
            Chamada = chamada;
        }

        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }
    }
}