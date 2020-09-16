using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities; 

namespace Utilities_ut
{


    [TestClass]
    public class Test_isValid
    {
        [TestMethod]
        public void BasicOption()
        {
            bool val = Utilities.Utl.Empty(".AAPL201009112.5");
            Assert.AreEqual(false, val, "fuck you");
        }

        [TestMethod]
        public void FOP()
        {
            bool val = Utilities.Utl.Empty("./ES201016XXXX");
            Assert.AreEqual(false, val, "fuck you");
        }
        [TestMethod]
        public void Empty()
        {
            bool val = Utilities.Utl.Empty("   ");
            Assert.AreEqual(true, val, "fuck you");
        }

    }


    [TestClass]
    public class UnitTest_Utl
    {

        [TestMethod]
        public void TestStartsWith()
        {
            Assert.AreEqual(true, Utilities.Utl.startsWith("abcd", "a"));
            Assert.AreEqual(true, Utilities.Utl.startsWith(".abcd", ".a"));
            Assert.AreEqual(true, Utilities.Utl.startsWith("_abcd", "_ab"));
            Assert.AreEqual(true, Utilities.Utl.startsWith("%abcd", "%abcd"));
            Assert.AreEqual(true, Utilities.Utl.startsWith("zkjhsf", "zkj"));
            Assert.AreEqual(false, Utilities.Utl.startsWith("asbcd", "z"));
        }

        [TestMethod]
        public void TestFirstChar()
        {
            Assert.AreEqual(true, Utilities.Utl.firstCharIs("abcd", 'a'));
            Assert.AreEqual(true, Utilities.Utl.firstCharIs(".fagr", '.'));
            Assert.AreEqual(true, Utilities.Utl.firstCharIs("_abcd", '_'));
            Assert.AreEqual(true, Utilities.Utl.firstCharIs("%abcd", '%'));
            Assert.AreEqual(true, Utilities.Utl.firstCharIs("zkjhsf", 'z'));
            Assert.AreEqual(false, Utilities.Utl.firstCharIs("asbcd", 'z'));
        }

        /// <summary>
        ///  WTF 
        /// </summary>
        [TestMethod]
        public void TestSymbol_Options()
        {
            Assert.AreEqual("AAPL", Utl.symbol(".AAPL201016C12345"));
            Assert.AreEqual("AAPL", Utl.symbol(".AAPL201016P12345"));
            Assert.AreEqual("AAPL", Utl.symbol(".AAPL201016P12345"));
        }

        [TestMethod]
        public void TestSymbol_FOPs()
        {
            Assert.Inconclusive("TODO");
        }

        [TestMethod]
        public void TestSymbol_Stock()
        {
            Assert.AreEqual("AAPL", Utl.symbol("AAPL"));
            Assert.AreEqual("MSFT", Utl.symbol("MSFT"));
        }

        /// <summary>
        ///  WTF 
        /// </summary>
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


        [TestMethod]
        public void Multiplier()
        {
            Assert.AreEqual(50, opt.multiplier("./MSFT200925p12345676.9876543"));
            Assert.AreEqual(100, opt.multiplier(".MSFT200925p12345676.9876543"));
            Assert.AreEqual(1, opt.multiplier("MSFT200925p12345676.9876543"));
        }

    }


    [TestClass]
    public class Test_pos_first_alpha
    {
        [TestMethod]
        public void TestInvalid()
        {
            Assert.AreEqual(-1, Utl.pos_first_alpha(""));
            Assert.AreEqual(-1, Utl.pos_first_alpha(" "));
            Assert.AreEqual(-1, Utl.pos_first_alpha(" 98765 "));
            Assert.AreEqual(-1, Utl.pos_first_alpha("1234"));
            Assert.AreEqual(-1, Utl.pos_first_alpha("%*)&^ "));
        }

        [TestMethod]
        public void TestFirst()
        { 
            Assert.AreEqual(0, Utl.pos_first_alpha("asdfghjk23456789"));
        }

        [TestMethod]
        public void TestMid()
        {
            Assert.AreEqual(4, Utl.pos_first_alpha("7654asdfg357356"));
        }

        [TestMethod]
        public void TestLast()
        {
            Assert.AreEqual(5, Utl.pos_first_alpha("12345X"));
        }
    }

    [TestClass]
    public class Test_pos_last_alpha
    {
        [TestMethod]
        public void TestInvalid()
        {
            Assert.AreEqual(-1, Utl.pos_first_alpha(""));
            Assert.AreEqual(-1, Utl.pos_first_alpha(" "));
            Assert.AreEqual(-1, Utl.pos_first_alpha("1234"));
            Assert.AreEqual(-1, Utl.pos_first_alpha("%*)&^ "));
        }

        [TestMethod]
        public void TestFirst()
        {
            Assert.AreEqual(0, Utl.pos_last_alpha("x234567890"));
        }

        [TestMethod]
        public void TestMid()
        {
            Assert.AreEqual(5, Utl.pos_last_alpha("12345X"));
        }

        [TestMethod]
        public void TestLast()
        {
            Assert.AreEqual(4, Utl.pos_last_alpha("1234s5"));
        }
    }

    [TestClass]
    public class Test_pos_first_num
    {
        [TestMethod]
        public void TestInvalid()
        {
            Assert.AreEqual(-1, Utl.pos_first_alpha(""));
            Assert.AreEqual(-1, Utl.pos_first_alpha(" "));
            Assert.AreEqual(-1, Utl.pos_first_alpha(" 98765 "));
            Assert.AreEqual(-1, Utl.pos_first_alpha("1234"));
            Assert.AreEqual(-1, Utl.pos_first_alpha("%*)&^ "));
        }

        [TestMethod]
        public void TestFirst()
        {
            Assert.AreEqual(0, Utl.pos_first_num("1234s5"));
        }

        [TestMethod]
        public void TestMid()
        {
            Assert.AreEqual(6, Utl.pos_first_num("insafg3sfhgs"));
        }

        [TestMethod]
        public void TestLast()
        {
            Assert.AreEqual(7, Utl.pos_first_num("dfgaeff4"));
        }
    }

    [TestClass]
    public class Test_pos_last_num
    {
        [TestMethod]
        public void TestInvalid()
        {
            Assert.AreEqual(-1, Utl.pos_first_alpha(""));
            Assert.AreEqual(-1, Utl.pos_first_alpha(" "));
            Assert.AreEqual(-1, Utl.pos_first_alpha(" 98765 "));
            Assert.AreEqual(-1, Utl.pos_first_alpha("1234"));
            Assert.AreEqual(-1, Utl.pos_first_alpha("%*)&^ "));
        }

        [TestMethod]
        public void TestFirst()
        {
            Assert.AreEqual(0, Utl.pos_last_num("1dfghjk"));
        }

        [TestMethod]
        public void TestMid()
        {
            Assert.AreEqual(15, Utl.pos_last_num("dsagssfd3fjnfhj7xvns"));
        }

        [TestMethod]
        public void TestLast()
        {
            Assert.AreEqual(11, Utl.pos_last_num("dfa3af7bhfs9"));
        }
    }


    [TestClass]
    public class Test_code
    {
        [TestMethod]
        public void futureCode_1()
        {
            Assert.Inconclusive("TODO");
            //Assert.AreEqual("", opt.exDateStr(""));
        }

        [TestMethod]
        public void optioneCode_1()
        {
            Assert.Inconclusive("TODO");
            //Assert.AreEqual("", opt.exDateStr(""));
        }
    }



    [TestClass]
    public class Test_strike
    {
        [TestMethod]
        public void strike_112_50()
        {
            Assert.AreEqual(112.50, opt.strike(".AAPL200925C112.50"));
        }

        [TestMethod]
        public void strike_12345676_9876543()
        {
            Assert.AreEqual(12345676.9876543, opt.strike(".MSFT200925p12345676.9876543"));
        }
    }

    




    [TestClass]
    public class Test_opt
    {
        [TestMethod]
        public void exData_ZeroLength()
        {
            Assert.AreEqual("", opt.exDateStr(""));
        }

        [TestMethod]
        public void exData_1()
        {
            Assert.AreEqual("200925", opt.exDateStr(".AAPL200925C112.50"));
        }

        [TestMethod]
        public void exData_FOP()
        {
            Assert.Inconclusive("FOPs support not implemented.");
        }
    }

}
