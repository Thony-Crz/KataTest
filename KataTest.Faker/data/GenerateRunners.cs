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
                .RuleFor(x => x.Nom, faker => faker.Person.LastName)
                .RuleFor(x => x.Prenom, faker => faker.Person.FirstName)
                .RuleFor(x => x.DateDeNaissance, faker => faker.Person.DateOfBirth)
                .RuleFor(x => x.City, faker => faker.Address.City())
                .RuleFor(x => x.Adresss, faker => faker.Address.StreetAddress(true))
                .RuleFor(x => x.Sexe, faker => (Gender)faker.Person.Gender)
                .RuleFor(x => x.ITRA, faker => faker.Random.Number(400,900))
                .RuleFor(x => x.StravaLink, faker => faker.Internet.Url());

            List<TrailRunnerToTestFaker> fakeRunners = new List<TrailRunnerToTestFaker>();
            fakeRunners = dataFaker.Generate(number);

            return fakeRunners;
        }
    }
}
