using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheLiskovSubstitutionPrinciple.ModulesWrongApproach;

namespace UnitTestProject1
{
    [TestClass]
    public class TheLiskovSubstitutionPrinciple
    {

        private RectangleW _rectangle;

        [TestInitialize]
        public void Setup()
        {
            _rectangle = new RectangleW();
        }

        [TestMethod]
        public void AreaRectangle3x2equal6()
        {
            _rectangle.Width = 3;
            _rectangle.Height = 2;
            Assert.AreEqual(_rectangle.Area(), 6);
        }

    }
}
