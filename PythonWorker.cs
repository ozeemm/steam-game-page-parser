using Microsoft.AspNetCore.Http.Connections;
using System.Diagnostics;

namespace Steam_Game_Page_Parser
{
    public class PythonWorker
    {
        public static string GetGamePageFileName(string url)
        {
            string name = RunPython($"Python/GetGamePage.py {url}");
            name = name.Replace($"{(char)13}", "");
            name = name.Replace($"{(char)10}", "");
            return name;
        }
        public static string GetGameUrlByName(string name)
        {
            return RunPython($"Python/GetGameUrlByName.py {name}");
        }
        private static string RunPython(string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
