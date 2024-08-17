using Microsoft.AspNetCore.Http.Connections;
using System;
using System.Diagnostics;

namespace Steam_Game_Page_Parser
{
    public class PythonWorker
    {
        public static string GetGamePageFileName(string url)
        {
            string name = RunPython($"Python/GetGamePage.py {url}");
            name = DeleteEndings(name);

            return name;
        }
        public static string GetGameUrlByName(string name)
        {
            string url = RunPython($"Python/GetGameUrlByName.py {name}");
            url = DeleteEndings(url);

            return url;
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
        private static string DeleteEndings(string text)
        {
            text = text.Replace($"{(char)13}", "");
            text = text.Replace($"{(char)10}", "");

            return text;
        }
    }
}
