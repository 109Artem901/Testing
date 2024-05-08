using Lab2_testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Lab2
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            float a = 2;
            float b = 3;
            float expected = 2.4494898f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            float a = 1;
            float b = 1;
            float expected = 1f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            float a = 4;
            float b = 2;
            float expected = 2.828427f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            float a = 4.23f;
            float b = 8;
            float expected = 5.8172158f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            float a = 5.2674f;
            float b = 3.78324f;
            float expected = 4.4640607f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            float a = 57;
            float b = 567.456f;
            float expected = 179.847136f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod7()
        {
            float a = 43.342f;
            float b = 9.3219876f;
            float expected = 20.1005867f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod8()
        {
            float a = 0;
            float b = 6;
            float expected = 0;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod9()
        {
            float a = 123456;
            float b = 0.23124f;
            float expected = 168.96144f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod10()
        {
            float a = 0.123123f;
            float b = 0.0001f;
            float expected = 0.0035088887f;

            Class1 c = new Class1();
            float actual = c.SredGeom(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}