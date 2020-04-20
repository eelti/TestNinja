using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.MockingTest
{
    [TestFixture]
    public class BookingHelperTest
    {
        private Booking _existingBookings;
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _existingBookings = new Booking()
            {
                Id = 2,
                ArrivalDate = ArrivalDate(2019, 12, 25),
                DepartureDate = DepartureDate(2019, 12, 31),
                Reference = "Abc"
            };
            _repository = new Mock<IBookingRepository>();
            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>()
            {
               _existingBookings
            }.AsQueryable());
            
        }
        [Test]
        public void OverlappingBookingsExist_BookingStartsAndFinishBeforeAExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_existingBookings.ArrivalDate, 5),
                DepartureDate = Before(_existingBookings.ArrivalDate),
                Reference = "Abc"
            }, _repository.Object);
            
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void  OverlappingBookingsExist_BookingStartAfterExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_existingBookings.DepartureDate),
                DepartureDate = After(_existingBookings.DepartureDate,5),
                Reference = "Abc"
            }, _repository.Object);

            Assert.That(result,Is.Empty);
        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(- days);
        }
        
        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }
        

        private DateTime ArrivalDate(int year, int month, int day)
        {
            return new DateTime(year,month, day, 14,0,0);
        }

        private DateTime DepartureDate(int year, int month, int day)
        {
            return new DateTime(year,month, day, 10,0,0);
        }
    }
}