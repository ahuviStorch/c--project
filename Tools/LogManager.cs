using System.IO;
namespace Tools;

public static class LogManager
{
    private const string PATH = "Log";
    public static string GetPathDir()
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string projectRoot = Directory.GetParent(baseDir)?.Parent?.Parent?.FullName ?? baseDir;
        string path = Path.Combine(projectRoot, PATH, $"{DateTime.Now.Month}.{DateTime.Now.Year}");

        if (Directory.Exists(path))
            return path;

        Directory.CreateDirectory(path);
        return path;
    }
    public static string GetPathFile()
    {
        return Path.Combine(GetPathDir(), $"{DateTime.Now.Day}.log");
    }
    public static void write(string project, string funcName, string massage)
    {
        string dir = GetPathDir();
        string file = GetPathFile();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string log = $"{DateTime.Now}\t{project}.{funcName}:\t{massage}";

        using (StreamWriter writer = new StreamWriter(file, true))
        {
            writer.WriteLine(log);
        }
    }

    //פונקציית הניקוי
    public static void clear()
    {
        if (!Directory.Exists(PATH)) return;
        string[] directories = Directory.GetDirectories(PATH);
        foreach (string dir in directories)
        {
            string dirName = Path.GetFileName(dir);
            string[] date = dirName.Split('.');
            if (date.Length == 2
              && int.TryParse(date[0], out int month)
                && int.TryParse(date[1], out int year))
            {
                DateTime dirDate2 = new DateTime(year, month, 1).AddMonths(1);

                if ((month == DateTime.Now.Month && year == DateTime.Now.Year)
                || (dirDate2.Month == DateTime.Now.Month && dirDate2.Year == DateTime.Now.Year))
                {
                    continue;
                }
                else
                {
                    Directory.Delete(dir, true);

                }
            }


        }
    }
}




