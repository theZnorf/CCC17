using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Level1
{
    class Program
    {
        public static void TaskRunner(string path, string outFile)
        {
            var task = new TaskParser(path);
            // var time = (int)Math.Round(task.TravelLocations.Sum(x => x.Duration));
            // File.AppendAllText(outFile, $"{time}{Environment.NewLine}");
            // Console.WriteLine($"{time}");
        }

        static void Main(string[] args)
        {
            string levelpath = @"E:\work\CCC17\level3\";
            string outFile = $"{levelpath}level3_results.txt";

            RunExample($"{levelpath}level3-eg.txt", outFile);

            // File.WriteAllText(outFile, "");
            // int NumTasks = 4;
            // for (int i = 1; i <= NumTasks; i++)
            // {
            //     Console.WriteLine("========================  " + i + " ======================== ");
            //     TaskRunner($"{levelpath}level2-{i}.txt", outFile);
            // }
        }

        static void RunExample(string infile, string outFile)
        {
            File.WriteAllText(outFile, "");
            TaskRunner(infile, outFile);
        }
    }
}
