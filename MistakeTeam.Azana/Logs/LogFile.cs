using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace MistakeTeam.Azana.Logs
{
    public static class LogFile
    {
        private static bool _iniciado = false;
        private static string _filepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\logs";
        private static string _filename = string.Format("\\{0}_log_{1}-{2}-{3}T{4}-{5}-{6}.txt",
                Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location),
                DateTime.Now.Day,
                DateTime.Now.Month,
                DateTime.Now.Year,
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second
            );

        public static void Iniciar()
        {
            if (!_iniciado)
            {
                if (!Directory.Exists(_filepath))
                {
                    Directory.CreateDirectory(_filepath);
                }

                using StreamWriter _w = File.AppendText(_filepath + _filename);
                _w.Close();
            }

            _iniciado = true;
        }

        public static void WriteLine(string mensagem)
        {
            try
            {
                using StreamWriter _filelog = File.AppendText(_filepath + _filename);

                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);

                // Volte uma casa
                if (sf.GetMethod().Name == "WriteLine")
                {
                    sf = st.GetFrame(2);
                }

                _filelog.Write("\r\n[{0} {1}] ", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
                _filelog.Write("[{0}.{1}:{2}] {3}",
                    sf.GetMethod().DeclaringType.Namespace, sf.GetMethod().DeclaringType.Name, sf.GetMethod().Name, mensagem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void WriteLine(string mensagem, params object?[] args)
        {
            WriteLine(string.Format(mensagem, args));
        }
    }
}