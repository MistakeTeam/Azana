namespace MistakeTeam.Azana.Mundo
{
    public class Cidade
    {
        private string _nome;

        public Cidade(string nome)
        {
            _nome = nome;
        }

        public string Nome()
        {
            return _nome;
        }
    }
}