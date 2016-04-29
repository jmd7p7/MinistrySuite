using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinistrySuite.Util;
using MinistrySuite.Entities;
using MinistrySuite.Enums;

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


        //Testing falls within current week
        [TestMethod]
        public void FallsWithinCurrentWeek_True()
        {
            //Arrange
            DateTimeOffset startDate = DateTimeOffset.Now.AddDays(-2);
            DateTimeOffset endDate = DateTimeOffset.Now.AddDays(2);
            PrayerRequest pr = PrayerRequest.Create(1, "Bob's knee surgery", "Prayer for successful surgery.", startDate, endDate, null);
            var expected = true;

            //Act
            var actual = pr.FallsWithinCurrentWeek();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FallsWithinCurrentWeek_False_DateAlreadyExpired()
        {
            //Arrange
            DateTimeOffset startDate = DateTimeOffset.Now.AddDays(-30);
            DateTimeOffset endDate = DateTimeOffset.Now.AddDays(-28);
            PrayerRequest pr = PrayerRequest.Create(1, "Bob's knee surgery", "Prayer for successful surgery.", startDate, endDate, null);
            var expected = false;

            //Act
            var actual = pr.FallsWithinCurrentWeek();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void FallsWithinCurrentWeek_False_DateTooFarIntoFuture()
        {
            //Arrange
            DateTimeOffset startDate = DateTimeOffset.Now.AddDays(20);
            DateTimeOffset endDate = DateTimeOffset.Now.AddDays(28);
            PrayerRequest pr = PrayerRequest.Create(1, "Bob's knee surgery", "Prayer for successful surgery.", startDate, endDate, null);
            var expected = false;

            //Act
            var actual = pr.FallsWithinCurrentWeek();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        //The start and end dates must be configured based on the current day or test may fail
        //or give false postives
        [TestMethod]
        public void FallsWithinCurrentWeek_False_DateExpiredByOneDay()
        {
            //Arrange
            DateTimeOffset startDate = new DateTimeOffset(new DateTime(2016, 4, 23));
            DateTimeOffset endDate = new DateTimeOffset(new DateTime(2016, 4, 23));
            PrayerRequest pr = PrayerRequest.Create(1, "Bob's knee surgery", "Prayer for successful surgery.", startDate, endDate, null);
            var expected = false;

            //Act
            var actual = pr.FallsWithinCurrentWeek();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        //The start and end dates must be configured based on the current day or test may fail
        //or give false positives
        [TestMethod]
        public void FallsWithinCurrentWeek_False_TooFarInFutureByOneDay()
        {
            //Arrange
            DateTimeOffset startDate = new DateTimeOffset(new DateTime(2016, 5, 30));
            DateTimeOffset endDate = new DateTimeOffset(new DateTime(2016, 5, 1));
            PrayerRequest pr = PrayerRequest.Create(1, "Bob's knee surgery", "Prayer for successful surgery.", startDate, endDate, null);
            var expected = false;

            //Act
            var actual = pr.FallsWithinCurrentWeek();

            //Assert
            Assert.AreEqual(actual, expected);
        }

        //GetNearestDayOfWeek tests

        [TestMethod]
        public void GetNearestDayOfWeek_Sunday()
        {
            //Arrange
            var expected = new DateTimeOffset(new DateTime(2016, 4, 24));

            //Act
            var actual = DateHelper.GetNearestDayOfWeek(DaysOfWeek.Sunday);

            //Assert
            Assert.AreEqual(expected.Date.Date, actual.Date.Date);
        }

        [TestMethod]
        public void GetNearestDayOfWeek_Monday()
        {
            //Arrange
            var expected = new DateTimeOffset(new DateTime(2016, 4, 25));

            //Act
            var actual = DateHelper.GetNearestDayOfWeek(DaysOfWeek.Monday);

            //Assert
            Assert.AreEqual(expected.Date.Date, actual.Date.Date);
        }

        [TestMethod]
        public void GetNearestDayOfWeek_Tuesday()
        {
            //Arrange
            var expected = new DateTimeOffset(new DateTime(2016, 4, 26));

            //Act
            var actual = DateHelper.GetNearestDayOfWeek(DaysOfWeek.Tuesday);

            //Assert
            Assert.AreEqual(expected.Date.Date, actual.Date.Date);
        }

        [TestMethod]
        public void GetNearestDayOfWeek_Wednesday()
        {
            //Arrange
            var expected = new DateTimeOffset(new DateTime(2016, 4, 27));

            //Act
            var actual = DateHelper.GetNearestDayOfWeek(DaysOfWeek.Wednesday);

            //Assert
            Assert.AreEqual(expected.Date.Date, actual.Date.Date);
        }

        [TestMethod]
        public void GetNearestDayOfWeek_Thursday()
        {
            //Arrange
            var expected = new DateTimeOffset(new DateTime(2016, 4, 28));

            //Act
            var actual = DateHelper.GetNearestDayOfWeek(DaysOfWeek.Thursday);

            //Assert
            Assert.AreEqual(expected.Date.Date, actual.Date.Date);
        }

        [TestMethod]
        public void GetNearestDayOfWeek_Friday()
        {
            //Arrange
            var expected = new DateTimeOffset(new DateTime(2016, 4, 29));

            //Act
            var actual = DateHelper.GetNearestDayOfWeek(DaysOfWeek.Friday);

            //Assert
            Assert.AreEqual(expected.Date.Date, actual.Date.Date);
        }

        [TestMethod]
        public void GetNearestDayOfWeek_Saturday()
        {
            //Arrange
            var expected = new DateTimeOffset(new DateTime(2016, 4, 30));

            //Act
            var actual = DateHelper.GetNearestDayOfWeek(DaysOfWeek.Saturday);

            //Assert
            Assert.AreEqual(expected.Date.Date, actual.Date.Date);
        }
    }
}
