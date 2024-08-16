using System.Diagnostics;

namespace Steam_Game_Page_Parser
{
    public class PythonWorker
    {
        public static string GetGamePageFileName(string url)
        {
            return RunPython($"Python/GetGamePage.py {url}");
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
