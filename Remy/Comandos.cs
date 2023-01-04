using System.Reflection;
using Remy.Interfaces;
using Remy.Logs;

namespace Remy
{
    public class Comandos
    {
        // Dicionarios para listar os comandos:
        private readonly static Dictionary<List<string>, Type> CClasses = new(); // Lista a classe de cada comando
        private readonly static List<string> CLista = new(); // Lista o nome de cada comando

        public static void Iniciar()
        {
            LogFile.WriteLine("Iniciando comandos...");

            // É feita uma busca em todo o codigo pelo namespace: "MistakeTeam.Azana.Comandos"_cls
            foreach (
                Type comando in Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(
                        mytype => mytype.GetInterfaces().Contains(typeof(IComando))
                    )
            )
            {
                // Se existir alguma classe no namespace, cada uma delas será listado aqui
                if (comando != null)
                {
                    IComando cc = (IComando)Activator.CreateInstance(comando);
                    List<string> _cls = new()
                    {
                        cc.Nome
                    };

                    CLista.Add(cc.Nome);
                    if (cc.Aliase != "")
                    {
                        _cls.Add(cc.Aliase);
                        CLista.Add(cc.Aliase);
                    }

                    CClasses.Add(_cls, comando);
                }
            }

            LogFile.WriteLine("{0} comandos foram registrados", CClasses.Count);
        }

        public static Type? ProcurarComando(string Nome)
        {
            // Existe?
            if (!CLista.Contains(Nome))
            {
                LogFile.WriteLine("Comando não existe.");
                return null;
            }

            return CClasses.First(n => n.Key.Contains(Nome)).Value;
        }

        // Vamos executar o comando?
        public static void ExecutarComando(string Nome)
        {
            Type t = ProcurarComando(Nome);

            // Existe?
            if (t == null)
            {
                return;
            }


            //Cria-se uma instancia da classe
            IComando op = (IComando)Activator.CreateInstance(t);

            op.Run(); // A magia acontece aqui
        }
    }
}
