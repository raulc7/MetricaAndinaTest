using ClassExamen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for MoneyPartsTest and is intended
    ///to contain all MoneyPartsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MoneyPartsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for build
        ///</summary>
        [TestMethod()]
        public void buildTest()
        {
            string value = "0.1";
            string actual = MoneyParts.build(value);
            string expected = "[0.05, 0.05, 0.1]";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void buildTest2()
        {
            string value = "0.5";
            string actual = MoneyParts.build(value);
            string expected = "[0.05, 0.05, 0.05, 0.05, 0.05, 0.05, 0.05, 0.05, 0.05, 0.05, 0.1, 0.1, 0.1, 0.1, 0.1, 0.2, 0.2, 0.1, 0.5]";

            Assert.AreEqual(expected, actual);
        }
    }
}
