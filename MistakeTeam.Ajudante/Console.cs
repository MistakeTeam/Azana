using System;
using System.Diagnostics;


namespace MistakeTeam.Azana.Ajudante {
    public class ConsoleLine {
        public static void Enviar(string texto, params object[] args) {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(1);
            
            Console.WriteLine(FormatarLinha("debug"));
            Console.WriteLine("[{0}, linha {1}, coluna {2} em {3}]: ", sf.GetFileName(), sf.GetFileLineNumber(), sf.GetFileColumnNumber(), sf.GetMethod().Name);
            Console.WriteLine(String.Format(texto, args));
            Console.WriteLine("--------------------------------------------------");
        }
        
        static string FormatarLinha(string texto) {
            string dp = "--------------------------------------------------";
            
            dp = dp.Substring(0, (dp.Length/2) - (texto.Length/2));
            
            return String.Format(dp + texto.ToUpper() + dp);
        }
    }
}






