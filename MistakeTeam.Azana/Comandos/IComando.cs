namespace MistakeTeam.Azana.Comandos {
    public interface IComando {
        string Nome { get; }
        string Descricao { get; }
        
        void Run();
    }
}