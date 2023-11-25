using KataTest.Faker;
using KataTest.Faker.data;
using KataTest.Faker.Utilities;
using KataTest.ProjectToTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace KataTest.TU
{
    [TestFixture]
    public class GetTrailRunnerTests
    {
        [Test]
        public void GenerateSomeRandomRunnerTest()
        {
            IGenerateObject<TrailRunnerToTestFaker> randomRunner = new GenerateFakerObject<TrailRunnerToTestFaker>();

            List<TrailRunnerToTestFaker> listRunner = randomRunner.Generate<TrailRunnerToTestFaker>(25);

            Assert.That(listRunner.Count == 25);
        }  
        
        [Test]
        public void InsertInJsonFileAfterGenerateTest()
        {
            IGenerateObject<TrailRunnerToTestFaker> randomRunner = new GenerateFakerObject<TrailRunnerToTestFaker>();

            try
            {
                randomRunner.InsertInJsonFileAfterGenerate<TrailRunnerToTestFaker>(5);
                Assert.IsTrue(true,"Le fichier à bien été généré");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void GenerateRandomNameTrailTest()
        {
            IGenerateObject<Trail> randomTrail = new GenerateFakerObject<Trail>();

            List<Trail> trails = randomTrail.Generate<Trail>(1);

            Assert.That(trails.Any());
        }
    }
}