using System;

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

    public class Trail
    {
        public string Name { get; set; }    
    }

    public class TrailRunnerToTestFaker
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public Gender Sexe { get; set; }
        public string City { get; set; }
        public string Adresss { get; set; }
        public int ITRA { get; set; }

        public string StravaLink { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}