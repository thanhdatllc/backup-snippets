using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackupSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                         ################################################################");
            Console.WriteLine("                         #                    BACKUP DATA SNIPPETS v1.0                 #");
            Console.WriteLine("                         #                    Author: Thanh Dat                         #");
            Console.WriteLine("                         #                    Company: Thanh Dat LLC                    #");
            Console.WriteLine("                         ################################################################");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine();
            var month = DateTime.Today.Month.ToString();
            var year = DateTime.Today.Year.ToString();
            var day = DateTime.Today.Day.ToString();
            var time = DateTime.Now.ToLongTimeString();
            time = time.Replace(":", "-");
            time = time.Replace(" ", "-");
            var dirStatup = AppDomain.CurrentDomain.BaseDirectory;
            var dirBackup = string.Format("{0}Snippets\\{1}-{2}", dirStatup, year, month);
            var db = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Snippets\\snippets.sqlite");
            var dbDest = string.Format("{0}\\snippets.sqlite-{1}-{2}-{3}-{4}", dirBackup, year, month, day, time);
            if (File.Exists(db))
            {
                if (!Directory.Exists(dirBackup)) Directory.CreateDirectory(dirBackup);
                File.Copy(db, dbDest);
            }
            Console.WriteLine("                         # Running backup data..........................................");
            Thread.Sleep(3000);
            Console.WriteLine("                         # Backup data completed! ......................................");
            Thread.Sleep(1000);
            Console.WriteLine("                         # Program will exit after 10s..................................");
            Thread.Sleep(10000);
        }
    }
}
