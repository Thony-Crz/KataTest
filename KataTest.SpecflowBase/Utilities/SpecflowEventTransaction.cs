using System;
using System.Transactions;

namespace KataTest.SpecflowBase.Utilities
{
    public static class SpecflowEventTransaction
    {
        private static TransactionScope _transactionScopeFeature;
        private static TransactionScope _transactionScopeScenario;

        private static bool _isBeforeFeatureCalled = false;
        private static bool _isBeforeScenarioCalled = false;

        /// <summary>
        /// Ouvre une transaction dans le cas où l'on souhaite annuler plus tard les actions en base
        /// On doit retrouver AfterFeatureTransaction dans le [AfterFeature] si cette méthode est utilisé
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void BeforeFeatureTransaction()
        {
            if (_isBeforeFeatureCalled)
            {
                throw new InvalidOperationException("OnBeforeFeatureTransaction has already been called. Ensure it's paired with OnAfterFeatureTransaction.");
            }

            _isBeforeFeatureCalled = true;

            _transactionScopeFeature = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        /// <summary>
        /// Doit être appelé dans le [AfterFeature] si on a BeforeFeatureTransaction() qui est appelé dans le [BeforeFeature]
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AfterFeatureTransaction()
        {
            if (!_isBeforeFeatureCalled)
            {
                throw new InvalidOperationException("OnAfterFeatureTransaction called without prior OnBeforeFeatureTransaction.");
            }

            _isBeforeFeatureCalled = false;

            _transactionScopeFeature?.Dispose();
        }

        /// <summary>
        /// Ouvre une transaction dans le cas où l'on souhaite annuler plus tard les actions en base
        /// On doit retrouver AfterScenarioTransaction dans le [AfterScenario] si cette méthode est utilisé
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void BeforeScenarioTransaction()
        {
            if (_isBeforeScenarioCalled)
            {
                throw new InvalidOperationException("OnBeforeFeatureTransaction has already been called. Ensure it's paired with OnAfterFeatureTransaction.");
            }

            _isBeforeScenarioCalled = true;

            _transactionScopeScenario = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        /// <summary>
        /// Doit être appelé dans le [AfterScenario] si on a BeforeScenarioTransaction() qui est appelé dans le [BeforeScenario]
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AfterScenarioTransaction()
        {
            if (!_isBeforeScenarioCalled)
            {
                throw new InvalidOperationException("OnAfterFeatureTransaction called without prior OnBeforeFeatureTransaction.");
            }

            _isBeforeScenarioCalled = false;

            _transactionScopeScenario?.Dispose();
        }
    }
}