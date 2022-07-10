using System;
using System.Linq;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Collections.Generic;

using MistakeTeam.Azana.Ajudante;
using MistakeTeam.Azana.Texto;



namespace MistakeTeam.Azana
{
    public class Program
    {
        private static Assembly AssemblyResolve(object sender, ResolveEventArgs args) {
            var referenceFiles = Directory.GetFiles("./lib", "*.dll", SearchOption.AllDirectories);

            var name = new AssemblyName(args.Name).Name + ".dll";
            var assyFile = referenceFiles.Where(x => x.EndsWith(name)).FirstOrDefault();

            Console.WriteLine(assyFile);
            if (assyFile != null) {
                Console.WriteLine("---------------------------------------");
                return Assembly.LoadFile(assyFile);
            } else {
                throw new Exception($"'{name}' não foi encontrado");
            }
        }

        static public void Main (string[] args) {
            try {

                //AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;

                float porcentagem = Calc.pegarporcentagem(34, 345);
                ConsoleLine.Enviar("Minha porcentagem é: {0}", porcentagem);

                ConsoleLine.Enviar("aqui: {0}", Localizar.PegarTexto("sucesso1"));
                
                Assembly[] ar = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly a in ar) {
                    //ConsoleLine.Enviar("{0}", a);
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}