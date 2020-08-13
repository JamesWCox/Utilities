using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities; 

namespace Utilities_ut
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            double last = 100.00;
            double high = 200.00;
            double low = 0.00;

            double res = Basic.getRange(last, high, low);
           
            Assert.AreEqual(50.00, res, 0.001, "fuck you");
        }
    }

    [TestClass]
    public class Test_isValid
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            double last = 100.00;
            double high = 200.00;
            double low = 0.00;

            double res = Basic.getRange(last, high, low);

            Assert.AreEqual(50.00, res, 0.001, "fuck you");
        }
    }
}
