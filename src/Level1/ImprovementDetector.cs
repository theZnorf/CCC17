using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{
    public class ImprovementDetector
    {
        private List<Journey> Journeys;
        private Segment HyperloopSegment;

        public ImprovementDetector(List<Journey> journeys, Segment hyperloopSegment)
        {
            Journeys = journeys;
            HyperloopSegment = hyperloopSegment;
        }


        public int calcNumberOfImprovements()
        {
            return calcNumberOfImprovements(false);
        }

        public int calcNumberOfImprovements(bool print)
        {
            int count = 0;
            foreach (var jour in Journeys)
            {
                var planner = new RoutePlanner(HyperloopSegment, jour.From, jour.To);

                var travelTime = planner.calcJourneyTime();

                if (travelTime < jour.CarDuration)
                {
                    if (print)
                    {
                        Console.WriteLine($"Possible improvement detected for : {jour.From} - {jour.To}");
                        Console.WriteLine($" {jour.CarDuration} vs {travelTime}");
                    }
                    count++;
                }
            }
            if (print)
            {
                Console.WriteLine($"Result: {count} improvements detected");
            }
            return count;
        }

    }
}
