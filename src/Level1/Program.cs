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

            int count = 0;
            foreach (var jour in task.Journeys)
            {
                var planner = new RoutePlanner(task.HyperloopSegment, jour.From, jour.To);

                var travelTime = planner.calcJourneyTime();

                if (travelTime < jour.CarDuration)
                {
                    Console.WriteLine($"Possible improvement detected for : {jour.From} - {jour.To}");
                    Console.WriteLine($" {jour.CarDuration} vs {travelTime}");

                    count++;
                }
            }

            Console.WriteLine($"Result: {count} improvements detected");

            File.AppendAllText(outFile, count.ToString() + Environment.NewLine);
        }

        static void Main(string[] args)
        {
            string levelpath = @"C:\work\CCC17\level3\";
            string outFile = $"{levelpath}level3_results.txt";

            //RunExample($"{levelpath}level3-eg.txt", outFile);

            File.WriteAllText(outFile, "");
            int NumTasks = 4;
            for (int i = 1; i <= NumTasks; i++)
            {
                Console.WriteLine("========================  " + i + " ======================== ");
                TaskRunner($"{levelpath}level3-{i}.txt", outFile);
            }
        }

        static void RunExample(string infile, string outFile)
        {
            File.WriteAllText(outFile, "");
            TaskRunner(infile, outFile);
        }
    }
}
