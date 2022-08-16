using System;
using System.Reflection;
using MistakeTeam.Azana.Ajudante;

namespace MistakeTeam.Azana.Comandos {
    public class ComandoMestre {
        private Dictionary<string, MethodInfo> CMetodos = new Dictionary<string, MethodInfo>();
        private Dictionary<string, Type> CClasses = new Dictionary<string, Type>();
        public List<string> CLista = new List<string>();
        
        public ComandoMestre () { }
        
        public void Init () {
            foreach (Type control in Assembly.GetExecutingAssembly().GetTypes()
                    .Where(mytype =>  String.Equals(mytype.Namespace, "MistakeTeam.Azana.Comandos", StringComparison.Ordinal) 
                    && mytype.GetInterfaces().Contains(typeof(IComando)))) {
                
                
                CLista.Add(control.Name);
                CClasses.Add(control.Name, control);
                CMetodos.Add(control.Name, control.GetMethod("Run"));
            }
        }
        
        public void ExecutarComando(string Nome) {
            if (!CLista.Contains(Nome)) {
                ConsoleLine.Erro("Comando não existe.");
                return;
            }
            
            Type t = CClasses[Nome];
            MethodInfo m = CMetodos[Nome];
            
            m.Invoke(Activator.CreateInstance(t), null);
        }
    }
}