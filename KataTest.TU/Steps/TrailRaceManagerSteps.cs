using System;
using KataTest.ProjectToTest;
using KataTest.SpecflowBase.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace KataTest.TU.Steps
{
    [Binding]
    public class TrailRaceManagerSteps
    {
        private TrailRunner _trailRunners;
        private TrailRaceManager _trailRaceManager;

        //Valeur par défaut de order : 10000, doit être inférieur pour que ce soit toujours avant que celui par défaut
        [BeforeFeature(Order = 0)]
        public static void BeforeFeatureWithTransaction()
        {
            SpecflowEventTransaction.BeforeFeatureTransaction();
        }

        //Valeur par défaut de order : 10000, doit être supérieur pour que ce soit toujours après que celui par défaut
        [AfterFeature(Order = 10200)]
        public static void AfterFeatureWithTransaction()
        {
            SpecflowEventTransaction.AfterFeatureTransaction();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Console.WriteLine("[BeforeFeature]");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("[AfterFeature]");
        }

        [Given(@"a trail race manager")]
        public void GivenATrailRaceManager()
        {
            _trailRaceManager = new TrailRaceManager();
        }

        [When(@"I add a trail runner named ""(.*)"" with age (.*), location ""(.*)"", and best time (.*) minutes")]
        public void WhenIAddATrailRunnerNamedWithAgeLocationAndBestTimeMinutes(string p0, DateTime p1, string p2, double p3)
        {
            _trailRunners = new TrailRunner(p0, p1, p2, p3);
            _trailRaceManager.AddRunner(_trailRunners);
        }

        [Then(@"the trail runner ""(.*)"" should be in the list")]
        public void ThenTheTrailRunnerShouldBeInTheList(string p0)
        {
            Assert.AreEqual(_trailRaceManager.FindRunnerByName(p0).Name, p0);
        }
    }
}