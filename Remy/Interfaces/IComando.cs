namespace Remy.Interfaces
{
    public interface IComando
    {
        public string Nome { get; }
        public string Aliase { get; }
        public string Descricao { get; }

        public void Run();
    }
}
