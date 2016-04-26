using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinistrySuite.Util;

namespace MinistrySuite.Test
{
    [TestClass]
    public class DateHelperTest
    {
        [TestMethod]
        public void GetNumberOfDaysFromSunday_UsingSunday()
        {
            //Arrange
            var today = new DateTimeOffset(new DateTime(2016, 4, 24));
            var expected = 0;

            //Act
            var actual = today.GetNumOfDaysFromSunday();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetNumberOfDaysFromSunday_UsingMonday()
        {
            //Arrange
            var today = new DateTimeOffset(new DateTime(2016, 4, 25));
            var expected = 1;

            //Act
            var actual = today.GetNumOfDaysFromSunday();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetNumberOfDaysFromSunday_UsingSaturday()
        {
            //Arrange
            var today = new DateTimeOffset(new DateTime(2016, 4, 30));
            var expected = 6;

            //Act
            var actual = today.GetNumOfDaysFromSunday();

            //Assert
            Assert.AreEqual(actual, expected);
        }


        //Testing method GetNumOfDaysUntilSaturday
        [TestMethod]
        public void GetNumOfDaysUntilSaturday_UsingSunday()
        {
            //Arrange
            var today = new DateTimeOffset(new DateTime(2016, 4, 24));
            var expected = 6;

            //Act
            var actual = today.GetNumOfDaysUntilSaturday();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetNumOfDaysUntilSaturday_UsingMonday()
        {
            //Arrange
            var today = new DateTimeOffset(new DateTime(2016, 4, 25));
            var expected = 5;

            //Act
            var actual = today.GetNumOfDaysUntilSaturday();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetNumOfDaysUntilSaturday_UsingSaturday()
        {
            //Arrange
            var today = new DateTimeOffset(new DateTime(2016, 4, 30));
            var expected = 0;

            //Act
            var actual = today.GetNumOfDaysUntilSaturday();

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
