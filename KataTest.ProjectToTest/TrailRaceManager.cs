using System;
using System.Collections.Generic;
using System.Linq;

namespace KataTest.ProjectToTest
{
    public class TrailRaceManager
    {
        private List<TrailRunner> _runners;

        public TrailRaceManager(List<TrailRunner> trailRunners = null)
        {

            if (trailRunners == null)
            {
                trailRunners = new List<TrailRunner>
                {
                    new TrailRunner("Alice Johnson", DateTime.Now, "New York", 45.5),
                    new TrailRunner("Bob Smith", DateTime.Now, "San Francisco", 40.2),
                    new TrailRunner("Charlie Brown", DateTime.Now, "Denver", 50.8),
                    new TrailRunner("David Williams", DateTime.Now, "Seattle", 38.7),
                    new TrailRunner("Eva Davis", DateTime.Now, "Los Angeles", 42.3),
                };
            }
            
            _runners = trailRunners;
        }

        public void AddRunner(TrailRunner runner)
        {
            _runners.Add(runner);
        }

        public TrailRunner FindRunnerByName(string name)
        {
            return _runners.FirstOrDefault(runner => runner.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<TrailRunner> GetRunnersInLocation(string location)
        {
            return _runners.Where(runner => runner.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<TrailRunner> GetTopRunners(int count)
        {
            return _runners.OrderByDescending(runner => runner.BestTime).Take(count).ToList();
        }
    }
}