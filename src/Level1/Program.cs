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

            var time = (int)Math.Round(new RoutePlanner(task.Segments, task.Journey.From, task.Journey.To).calcJourneyTime());

            Console.WriteLine($"Total travel time: {time}");
            File.AppendAllText(outFile, $"{time}" + Environment.NewLine);

            //foreach (var start in task.Locations)
            //{
            //    foreach (var end in task.Locations.Where(x => x != start))
            //    {
            //        var hyper = new HyperloopSegment(start, end);
            //        var count = new ImprovementDetector(task.Journeys, hyper).calcNumberOfImprovements();
            //        if (count >= task.MinImprovements)
            //        {
            //            Console.WriteLine($"good hyperloop: {hyper.From} - {hyper.To}");
            //            File.AppendAllText(outFile, $"{hyper.From.Name} {hyper.To.Name}" + Environment.NewLine);
            //            return;
            //        }
            //    }
            //}
        }

        static void Main(string[] args)
        {
            string levelpath = @"C:\work\CCC17\level5\";
            string outFile = $"{levelpath}level5_results.txt";

            RunExample($"{levelpath}level5-eg.txt", outFile);

            return;

            File.WriteAllText(outFile, "");
            int NumTasks = 4;
            for (int i = 1; i <= NumTasks; i++)
            {
                Console.WriteLine("========================  " + i + " ======================== ");
                TaskRunner($"{levelpath}level5-{i}.txt", outFile);
            }
        }

        static void RunExample(string infile, string outFile)
        {
            File.WriteAllText(outFile, "");
            TaskRunner(infile, outFile);
        }
    }
}
