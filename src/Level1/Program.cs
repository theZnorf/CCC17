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

            foreach (var start in task.Locations)
            {
                foreach (var end in task.Locations.Where(x => x != start))
                {
                    var hyper = new HyperloopSegment(start, end);
                    var count = new ImprovementDetector(task.Journeys, hyper).calcNumberOfImprovements();
                    if (count >= task.MinImprovements)
                    {
                        Console.WriteLine($"good hyperloop: {hyper.From} - {hyper.To}");
                        File.AppendAllText(outFile, $"{hyper.From.Name} {hyper.To.Name}" + Environment.NewLine);
                        return;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string levelpath = @"C:\work\CCC17\level4\";
            string outFile = $"{levelpath}level4_results.txt";

            RunExample($"{levelpath}level4-eg.txt", outFile);

            File.WriteAllText(outFile, "");
            int NumTasks = 4;
            for (int i = 1; i <= NumTasks; i++)
            {
                Console.WriteLine("========================  " + i + " ======================== ");
                TaskRunner($"{levelpath}level4-{i}.txt", outFile);
            }
        }

        static void RunExample(string infile, string outFile)
        {
            File.WriteAllText(outFile, "");
            TaskRunner(infile, outFile);
        }
    }
}
