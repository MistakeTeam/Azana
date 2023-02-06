using Remy.Logs;

namespace Remy.ScriptParse
{
    /// <summary>
    /// Exemplo de sintaxe no arquivo de texto: ./Recursos/Script/Text.txt
    /// </summary>
    public class ScriptsParse
    {
        private int ChaveIndex;
        private string[] txt;
        private string[] c;
        private int dws;
        private object tyg = "";
        private bool _start = false;

        public ScriptsParse(string path)
        {
            txt = File.ReadAllLines(path);
        }

        public int FindIndex(string[] array, int startIndex, Predicate<string> match)
        {
            for (int i = startIndex; i < array.Length; i++)
            {
                string x = array[i];

                if (match(x))
                {
                    return i;
                }
            }

            return -1;
        }

        public object GetChave(string chave = "")
        {
            // Esse pedaço só pode ser executado uma vez no inicio da busca
            if (!_start)
            {
                LogFile.WriteLine("============================");
                c = chave.Split(".");
                ChaveIndex = 0;
                dws = FindIndex(txt, 0, x => x.Contains(c[ChaveIndex]));
                _start = true;
            }

            // Mensagem.Enviar($">>>> {FindIndex(txt, 0, x => x.Contains(c[ChaveIndex]))}");

            int Lindex = ProcurarColchetes(dws);
            string linha = txt[dws];

            if (linha.Contains(c[ChaveIndex]))
            {
                string wfe = linha.Split("=")[0].Trim(), rgt = linha.Split("=")[1].Trim();
                (string g, object h) = GetT(rgt);

                LogFile.WriteLine($"Etapa {ChaveIndex + 1}");
                LogFile.WriteLine($"Chave: {wfe} ({ChaveIndex})");
                LogFile.WriteLine($"Type: {g}");
                LogFile.WriteLine($"Valor: {h}");
                LogFile.WriteLine($"Range: {dws}:{Lindex}");
                if (c[ChaveIndex] == c[^1]) LogFile.WriteLine("============================");

                switch (g)
                {
                    case "object":
                        if (linha.Contains(c[ChaveIndex])) ProximoIndex();
                        LogFile.WriteLine($"Proxima chave: {c[ChaveIndex]}");

                        dws++;
                        GetChave();
                        break;
                    default:
                        tyg = h;
                        break;
                }
            }
            else
            {
                dws++;
                GetChave();
            }

            return tyg;
        }

        private void ProximoIndex()
        {
            int MaxIndex = c.Length - 1;
            ChaveIndex = ChaveIndex >= MaxIndex ? MaxIndex : ChaveIndex + 1;
        }

        private int ProcurarColchetes(int Start)
        {
            int leng = 0;
            int index = 0;
            for (int i = Start; i < txt.Length; i++)
            {
                if (txt[i].Contains("{{"))
                    leng++;
                if (txt[i].Contains("}}"))
                    leng--;

                if (leng == 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private (string type, object value) GetT(string str)
        {
            object ygfe = "";

            if (str.Contains("{{"))
            {
                return (type: "object", value: ygfe);
            }
            else
            {
                _start = false;
                LogFile.WriteLine("Analisando o resultado");
                if (int.TryParse(str, out int n))
                {
                    ygfe = n;
                    return (type: "number", value: ygfe);
                }
                else if (float.TryParse(str, out float f))
                {
                    ygfe = f;
                    return (type: "float", value: ygfe);
                }
                else if (bool.TryParse(str, out bool b))
                {
                    ygfe = b;
                    return (type: "boolean", value: ygfe);
                }
                else
                {
                    ygfe = str;
                    return (type: "string", value: ygfe);
                }
            }
        }
    }
}