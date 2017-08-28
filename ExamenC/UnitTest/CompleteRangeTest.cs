using ClassExamen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    
    
    /// <summary>
    ///This is a test class for CompleteRangeTest and is intended
    ///to contain all CompleteRangeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CompleteRangeTest
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
            List<int> value = new List<int>() { 2, 1, 4, 5 };
            List<int> actual = CompleteRange.build(value);
            List<int> expected = new List<int>() { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void buildTest2()
        {
            List<int> value = new List<int>() { 4, 2, 9 };
            List<int> actual = CompleteRange.build(value);
            List<int> expected = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
