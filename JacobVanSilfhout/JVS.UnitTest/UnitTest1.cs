/*
 * Developer: Jacob Van Silfhout
 * Purpose: Unit tests for converter application
 */
using System;
using JacobVanSilfhout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JVS.UnitTest
{
    /*Check if the conversion is possible*/
    [TestClass]
    public class PositiveValidityTests
    {
        [TestMethod]
        public void CheckValidCoversion_ml_ml_true()
        {
            Converter c1 = new Converter(10, "ml", "ml");
            bool result = c1.ValidConversion();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckValidCoversion_l_l_true()
        {
            Converter c1 = new Converter(10, "l", "l");
            bool result = c1.ValidConversion();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckValidCoversion_gal_gal_true()
        {
            Converter c1 = new Converter(10, "us gal", "us gal");
            bool result = c1.ValidConversion();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckValidCoversion_c_c_true()
        {
            Converter c1 = new Converter(10, "c", "c");
            bool result = c1.ValidConversion();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckValidCoversion_f_f_true()
        {
            Converter c1 = new Converter(10, "f", "f");
            bool result = c1.ValidConversion();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckValidCoversion_k_k_true()
        {
            Converter c1 = new Converter(10, "k", "k");
            bool result = c1.ValidConversion();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CheckValidCoversion_l_ml_true()
        {
            Converter c1 = new Converter(10,"l","ml");
            bool result = c1.ValidConversion();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckValidCoversion_l_gal_true()
        {
            Converter c1 = new Converter(10, "l", "us gal");
            bool result1 = c1.ValidConversion();
            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_ml_gal_true()
        {
            Converter c1 = new Converter(10, "ml", "us gal");
            bool result1 = c1.ValidConversion();
            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_ml_l_true()
        {
            Converter c1 = new Converter(10, "ml", "l");
            bool result1 = c1.ValidConversion();
            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_gal_l_true()
        {
            Converter c1 = new Converter(10, "us gal", "l");
            bool result1 = c1.ValidConversion();
            Assert.IsTrue(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_gal_ml_true()
        {
            Converter c1 = new Converter(10, "us gal", "ml");
            bool result1 = c1.ValidConversion();
            Assert.IsTrue(result1);
        }
    }

    /*Check for invalid conversion types*/
    [TestClass]
    public class NegativeValidityTests
    {
        [TestMethod]
        public void CheckValidCoversion_f_ml_false()
        {
            Converter c1 = new Converter(10, "f", "ml");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_f_l_false()
        {
            Converter c1 = new Converter(10, "f", "l");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_f_gal_false()
        {
            Converter c1 = new Converter(10, "f", "us gal");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_c_ml_false()
        {
            Converter c1 = new Converter(10, "c", "ml");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_c_l_false()
        {
            Converter c1 = new Converter(10, "c", "l");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_c_gal_false()
        {
            Converter c1 = new Converter(10, "c", "us gal");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_k_ml_false()
        {
            Converter c1 = new Converter(10, "k", "ml");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_k_l_false()
        {
            Converter c1 = new Converter(10, "k", "l");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }

        [TestMethod]
        public void CheckValidCoversion_k_gal_false()
        {
            Converter c1 = new Converter(10, "k", "us gal");
            bool result1 = c1.ValidConversion();
            Assert.IsFalse(result1);
        }
    }

    /*Check for a successful result against the formula*/
    [TestClass]
    public class AppropriateResultsTests
    {
        /*Adjust the size of the test data used*/
        static int start = -10000;
        static int size = 10000;
        [TestMethod]
        public void SuccesfulCoversion_k_c()
        {
            for(int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "k", "c");
                Assert.AreEqual(Math.Round(double.Parse((i - 273.15).ToString()),2), c1.Conversion());
            }
        }

        [TestMethod]
        public void SuccesfulCoversion_k_f()
        {
            for (double i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "k", "f");
                Assert.AreEqual(Math.Round(double.Parse(((i - 273.15)*9/5+32).ToString()), 2), c1.Conversion());
            }
        }

        [TestMethod]
        public void SuccesfulCoversion_c_f()
        {
            for (double i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "c", "f");
                Assert.AreEqual(Math.Round(double.Parse((i*9/5+32).ToString()), 2), c1.Conversion());
            }
        }

        [TestMethod]
        public void SuccesfulCoversion_c_k()
        {
            for (double i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "c", "k");
                Assert.AreEqual(Math.Round(double.Parse((i + 273.15).ToString()), 2), c1.Conversion());
            }
        }

        [TestMethod]
        public void SuccesfulCoversion_f_k()
        {
            for (double i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "f", "k");
                Assert.AreEqual(Math.Round(double.Parse(((i - 32)*5/9+273.15).ToString()), 2), c1.Conversion());
            }
        }

        [TestMethod]
        public void SuccesfulCoversion_f_c()
        {
            for (double i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "f", "c");
                Assert.AreEqual(Math.Round(double.Parse(((i-32)*5/9).ToString()), 2), c1.Conversion());
            }
        }
    }

    /*Check for a unsuccessful result against the formula*/
    [TestClass]
    public class ErrorResultsTests
    {
        /*Adjust the size of the test data used*/
        static int start = -10000;
        static int size = 10000;
        [TestMethod]
        public void UnsuccesfulCoversion_k_l()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "k", "l");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_k_ml()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "k", "ml");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_k_gal()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "k", "us gal");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }

        [TestMethod]
        public void UnsuccesfulCoversion_c_l()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "c", "l");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_c_ml()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "c", "ml");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_c_gal()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "c", "us gal");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }

        [TestMethod]
        public void UnsuccesfulCoversion_f_l()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "f", "l");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_f_ml()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "f", "ml");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_f_gal()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "f", "us gal");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }

        [TestMethod]
        public void UnsuccesfulCoversion_l_c()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "l", "c");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_l_f()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "l", "f");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_l_k()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "l", "k");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }

        [TestMethod]
        public void UnsuccesfulCoversion_ml_c()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "ml", "c");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_ml_f()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "ml", "f");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_ml_k()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "ml", "k");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }

        [TestMethod]
        public void UnsuccesfulCoversion_gal_c()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "us gal", "c");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_gal_f()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "us gal", "f");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
        [TestMethod]
        public void UnsuccesfulCoversion_gal_k()
        {
            for (int i = start; i < size; i++)
            {
                Converter c1 = new Converter(i, "us gal", "k");
                Assert.AreEqual(double.Parse((-1).ToString()), c1.Conversion());
            }
        }
    }
}
