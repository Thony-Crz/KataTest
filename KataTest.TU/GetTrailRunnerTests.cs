using KataTest.Faker.data;
using KataTest.ProjectToTest;
using NUnit.Framework;
using System.Collections.Generic;

namespace KataTest.TU
{
    [TestFixture]
    public class GetTrailRunnerTests
    {
        [Test]
        public void GenerateSomeRandomRunnerTest()
        {
            List<TrailRunnerToTestFaker> listRunner = GenerateRunners.GenerateSomeRunners(2000);

            Assert.That(listRunner.Count == 2000);
        }
    }
}