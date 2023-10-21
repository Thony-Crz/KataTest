using Bogus;
using KataTest.ProjectToTest;
using System.Collections.Generic;

namespace KataTest.Faker.data
{
    public static class GenerateRunners
    {
        /// <summary>
        /// à utiliser pour tous les objet sans constructeur pour faire du test Random
        /// </summary>
        /// <param name="number">Nomrbre d'éléments à générer</param>
        /// <returns></returns>
        public static List<TrailRunnerToTestFaker> GenerateSomeRunners(int number)
        {
             var dataFaker = new Faker<TrailRunnerToTestFaker>()
                .RuleFor(x => x.Name, faker => faker.Person.FullName)
                .RuleFor(x => x.DateDeNaissance, faker => faker.Person.DateOfBirth)
                .RuleFor(x => x.Location, faker => faker.Address.Locale)
                .RuleFor(x => x.BestTime, faker => faker.Random.Double());

            List<TrailRunnerToTestFaker> fakeRunners = new List<TrailRunnerToTestFaker>();
            fakeRunners = dataFaker.Generate(number);

            return fakeRunners;
        }
    }
}
