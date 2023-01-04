using MistakeTeam.Azana.Texto;
using Remy.Logs;

namespace MistakeTeam.Azana.Mundo
{
    public class Mapa
    {
        private readonly static List<Cidade> _cidades = new List<Cidade>();

        public static void Iniciar()
        {
            List<string> iou = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                string iuy = Localizar.TextoAleatorio(TextoPath.NOMES_CIDADES);

                if (iou.Exists(s => s == iuy))
                {
                    iuy = Localizar.TextoAleatorio(TextoPath.NOMES_CIDADES);
                }

                _cidades.Add(new Cidade(iuy));
                iou.Add(iuy);

                // Lixo
                if (i == 7)
                {
                    iou.Clear();
                    GC.Collect();
                }
            }
        }

        public static List<string> PegarLista()
        {
            List<string> p = new List<string>();

            _cidades.ForEach(s =>
            {
                p.Add(s.Nome());
            });
            return p;
        }
    }

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