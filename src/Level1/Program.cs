using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Level1
{
    class Program
    {
        public static void TaskRunner(string path, string outFile)
        {
            var task = new TaskParser(path);
            var time = new TimeCalculator().calcTime(task.From, task.To);
            File.AppendAllText(outFile, $"{time}{Environment.NewLine}");
            Console.WriteLine($"{time}");
        }

        static void Main(string[] args)
        {
            string outFile = "E:\\work\\CCC17\\src\\Level1\\files\\level1\\level1_results.txt";
            File.WriteAllText(outFile, "");
            int NumTasks = 4;
            for (int i = 1; i <= NumTasks; i++)
            {
                TaskRunner($"E:\\work\\CCC17\\src\\Level1\\files\\level1\\level1-{i}.txt", outFile);
            }
        }
    }
}
