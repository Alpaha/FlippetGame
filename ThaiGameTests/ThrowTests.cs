using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThaiGame;

namespace ThaiGameTests
{
    [TestClass]
    public class ThrowTests
    {
        private readonly Throw _throw = new Throw();

        [TestMethod]
        public void ThrowSimple()
        {
            var throwResults = _throw.DoThrow((b1, b2) =>
            {
                b1.Number = 1;
                b2.Number = 2;
            });

            CollectionAssert.AreEquivalent(throwResults, new List<int> {1, 2, 3});
        }

        [TestMethod]
        public void ThrowWithEqualNumbers()
        {
            var throwResults = _throw.DoThrow((b1, b2) =>
            {
                b1.Number = 1;
                b2.Number = 1;
            });

            CollectionAssert.AreEquivalent(throwResults, new List<int>{1,2});
        }

        [TestMethod]
        public void ThrowWhenBonesSummaryMoreNine()
        {
            var throwResults = _throw.DoThrow((b1, b2) =>
            {
                b1.Number = 5;
                b2.Number = 6;
            });

            CollectionAssert.AreEquivalent(throwResults, new List<int> {5,6});
        }
    }
}