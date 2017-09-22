using FivePrincipleOOP.Models;
using FivePrincipleOOPOpenClosePrinciple.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests.UnitTests
{
    [TestFixture]
    public class CartTests
    {
        private FivePrincipleOOPOpenClosePrinciple.Models.Cart _cart;

        [SetUp]
        public void Setup()
        {
            _cart = new FivePrincipleOOPOpenClosePrinciple.Models.Cart();
        }

        [Test]
        public void ZeroWhenEmpty()
        {
            Assert.AreEqual(0, _cart.TotalAmount());
        }
    }
}
