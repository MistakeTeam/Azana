using System;
using MistakeTeam.Azana.Ajudante;
using MistakeTeam.Azana.Comandos;
using MistakeTeam.Azana.Texto;




namespace MistakeTeam.Azana
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ComandoMestre cm = new ComandoMestre();
                cm.Init();

                // Loop de comandos
                bool ativo = true;
                while (ativo)
                {
                    Console.WriteLine("Escolha um número");
                    char iut = Console.ReadKey().KeyChar;

                    Console.WriteLine("");
                    if (char.IsNumber(iut))
                    {
                        if ((int)Char.GetNumericValue(iut) > 3)
                        {
                            Console.WriteLine("Número errado");
                            continue;
                        }
                        Console.WriteLine("Seu número é: {0}", iut);
                        ativo = false;
                    }
                    else
                    {
                        Console.WriteLine("Isso não é número");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}