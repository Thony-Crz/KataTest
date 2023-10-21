using System;
using System.Collections.Generic;
using System.Linq;

namespace KataTest.ProjectToTest
{
    public class TrailRunner
    {
        public string Name { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Location { get; set; }
        public double BestTime { get; set; }

        public TrailRunner(string name, DateTime date, string location, double bestTime)
        {
            Name = name;
            DateDeNaissance = date;
            Location = location;
            BestTime = bestTime;
        }
    }

    public class TrailRunnerToTestFaker
    {
        public string Name { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Location { get; set; }
        public double BestTime { get; set; }
    }
}