using System;

Logger.WriteLog("First log is hear!");


class Logger
{
    static readonly string s_logsPath;
    // it is unable to create struct type of const
    readonly DateTime time;
    static Logger() {
        string projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
        s_logsPath = Path.Combine(projectDir, "LogsFolder", "logs.txt");
    }

    public Logger()
    {
        time = DateTime.Now;
    }

    static public void WriteLog(string log)
    {
        try
        {
            using var writer = new StreamWriter(s_logsPath, append: true);
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {log}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Logger Error] {ex.Message}");
        }
    }
}
