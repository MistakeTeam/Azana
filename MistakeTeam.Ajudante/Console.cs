using System;
using System.Diagnostics;
using System.Text;
using System.Reflection;
using System.IO;

namespace MistakeTeam.Azana.Ajudante {
    public class ConsoleLine {
        static string projectFolder = Path.GetFullPath(Assembly.GetExecutingAssembly().Location);

        // Source code: https://github.com/Unity-Technologies/UnityCsReference/blob/master/Runtime/Export/Scripting/StackTrace.cs
        [System.Security.SecuritySafeCritical] // System.Diagnostics.StackTrace cannot be accessed from transparent code (PSM, 2.12)
        static internal string ExtractFormattedStackTrace(StackTrace stackTrace) {
            StringBuilder sb = new StringBuilder(255);
            int iIndex;

            // need to skip over "n" frames which represent the
            // System.Diagnostics package frames
            for (iIndex = 0; iIndex < stackTrace.FrameCount; iIndex++) {
                StackFrame frame = stackTrace.GetFrame(iIndex);
                if (frame == null)
                    continue;

                MethodBase mb = frame.GetMethod();
                if (mb == null)
                    continue;

                Type classType = mb.DeclaringType;
                if (classType == null)
                    continue;

                // Add namespace.classname:MethodName
                String ns = classType.Namespace;
                if (!string.IsNullOrEmpty(ns)) {
                    sb.Append(ns);
                    sb.Append(".");
                }

                sb.Append(classType.Name);
                sb.Append(":");
                sb.Append(mb.Name);
                sb.Append("(");

                // Add parameters
                int j = 0;
                ParameterInfo[] pi = mb.GetParameters();
                bool fFirstParam = true;
                while (j < pi.Length) {
                    if (fFirstParam == false)
                        sb.Append(", ");
                    else
                        fFirstParam = false;

                    sb.Append(pi[j].ParameterType.Name);
                    j++;
                }
                sb.Append(")");

                // Add path name and line number - unless it is a Debug.Log call, then we are only interested
                // in the calling frame.
                string path = frame.GetFileName();
                if (path != null) {
                    sb.Append(" (at ");

                    if (!string.IsNullOrEmpty(projectFolder)) {
                        if (path.Replace("\\", "/").StartsWith(projectFolder)) {
                            path = path.Substring(projectFolder.Length, path.Length - projectFolder.Length);
                        }
                    }

                    sb.Append(path);
                    sb.Append(":");
                    sb.Append(frame.GetFileLineNumber().ToString());
                    sb.Append(")");
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        public static void Enviar(string texto, params object[] args) {
            if (args == null) {
                Console.WriteLine(String.Format(texto));
            } else {
                Console.WriteLine(String.Format(texto, args));
            }
        }

        private static void Log(string texto, string Level, params object[] args) {

            StackTrace trace = new StackTrace(0, true);
            string traceString = ExtractFormattedStackTrace(trace);

            Enviar(FormatarLinha(Level));
            Enviar(texto, args);
            Enviar(traceString);
            Enviar(FormatarLinha());
        }

        public static void Debug (string texto, params object[] args) {
            Log("DEBUG: " + texto, "Debug", args);
        }

        public static void Aviso (string texto, params object[] args) {
            Log("AVISO: " + texto, "Aviso", args);
        }

        public static void Erro (string texto, params object[] args) {
            Log("ERROR: " + texto, "Erro", args);
        }

        private static string FormatarLinha(string texto = null) {
            string dp = "--------------------------------------------------";
            if (texto != null) {
                dp = dp.Substring(0, (dp.Length/2) - (texto.Length/2));
                return String.Format(dp + texto.ToUpper() + dp);
            } else {
                return dp;
            }
        }
    }
}