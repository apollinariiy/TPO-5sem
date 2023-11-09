using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using lr7;


namespace CalculatorAAA
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void IsCorrectSum()
        {
            double num1 = 5;
            double num2 = 3;
            double expected = num1 + num2;
            double actual = Calculator.Sum(num1, num2);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsCorrectDifference()
        {
            double num1 = 7;
            double num2 = 4;
            double expected = num1 - num2;
            double actual = Calculator.Sub(num1, num2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsCorrectMultiplication()
        {
            double num1 = 2;
            double num2 = 6;
            double expected = num1 * num2;
            double actual = Calculator.Mul(num1, num2);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsCorrectDivision()
        {
            double num1 = 8;
            double num2 = 2;
            double expected = num1/num2;
            double actual = Calculator.Div(num1, num2);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IsCorrectDivisionByZero()
        {
            double actual = Calculator.Div(1, 0);
            Assert.AreEqual(double.PositiveInfinity, actual);
        }
    }
}