namespace PSI.TI.GestaoEscolar.Business.Models
{
    public class Disciplina : Entity
    {
        public string Descricao { get; private set; }
        public int CargaHoraria { get; private set; }

        // For EF
        protected Disciplina()
        {
            
        }

        protected Disciplina(string descricao, int cargaHoraria)
        {
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
        }
    }
}