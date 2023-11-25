using KataTest.Faker.Utilities;
using KataTest.Faker;
using NUnit.Framework;
using System.Collections.Generic;
using Faker.KendoGrid.Generator;

namespace KataTest.TU.Tests.KendoGrid
{
    [TestFixture]
    public class KendoGridGeneratorTests
    {
        [Test]
        public void GenerateSomeRandomColumnsTest()
        {
            IGenerateObject<Columns> randomRunner = new GenerateFakerObject<Columns>();

            List<Columns> listKendoColumns = randomRunner.Generate<Columns>(25);

            Assert.That(listKendoColumns.Count == 25);
        }
    }
}
