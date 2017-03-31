﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{

    public class Journey
    {
        public Journey(Location from, Location to, int carDuration)
        {
            From = from;
            To = to;
            CarDuration = carDuration;
        }

        public Location From { get; set; }
        public Location To { get; set; }
        public int CarDuration { get; set; }
    }

    public class TaskParser
    {
        public List<Location> Locations { get; set; }

        public List<Journey> Journeys { get; set; }

        public TaskParser(string path)
        {
            int line = 0;
            var lines = File.ReadAllLines(path);
            Locations = new List<Location>();
            Journeys = new List<Journey>();
            int numLocs = int.Parse(lines[line++]);
            for (; line <= numLocs; line++)
            {
                Locations.Add(new Location(lines[line]));
            }

            Console.WriteLine("Parsing journeys:");
            int numJourneys = int.Parse(lines[line++]);
            for (int i = 0; i < numJourneys; i++)
            {
                var journeyString = lines[line++];
                var parts = journeyString.Split(' ');
                var s = parts[0]; var e = parts[1]; var cd = parts[2];
                Journeys.Add(new Journey(Locations.First(x => x.Name.Equals(s)), Locations.First(x => x.Name.Equals(e)), int.Parse(cd)));
            }

            var hyperloopSegment = lines[line];

            Console.WriteLine($"{numLocs} Locations parsed:");
            foreach (var loc in Locations)
            {
                Console.WriteLine(loc.ToString());
            }
        }
    }
}
