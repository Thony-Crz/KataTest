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
        public MyUrls StravaLink { get; set; }
    }

    public class MyUrls
    {
        public int ID { get; set; }
        public Scheme Scheme { get; set; }
        public string Host { get; set; }
        public int? Port { get; set; }
        public string Path { get; set; }
        public string Query { get; set; } = string.Empty;
        public string Fragment { get; set; } = string.Empty;

        public override string ToString()
        {
            string portString = (Port == 0) ? string.Empty : $":{Port}";
            string queryString = string.IsNullOrEmpty(Query) ? string.Empty : $"?{Query}";
            string fragmentString = string.IsNullOrEmpty(Fragment) ? string.Empty : $"#{Fragment}";

            return $"{Scheme}://{Host}{portString}/{Path}{queryString}{fragmentString}";
        }
    }

    public enum Gender
    {
        Male,
        Female
    }   
    
    public enum Scheme
    {
        http,
        https,
        ftp
    }
}