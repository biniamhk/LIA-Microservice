using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PlanService.Repositories.Interface;
using PlanService.DateManager;
using PlanService.Models;

namespace PlanService_Tests
{
    public class DateManagerTests
    {

        private DateValidator _sut;
        

      
        [SetUp]
        public  void SetUp()
        {
            _sut = new DateValidator();
            var _lateDate = new DateTime(2021,09,10,19,00,00);
            var _earliyDate = new DateTime(2021,10,10,19,00,00);
        }


        [Test]
        [Category("DateManager")]
        public void DateValidator_ShouldReturnFalseIfToDateIsLessThanOrDatesAreEqual()
        {
            var earlyDate = new DateTime(2021,09,10,19,00,00);
            var lateDate = new DateTime(2021,10,10,19,00,00);
            
            var falseDate = _sut.ValidateDates(earlyDate, lateDate);
            var equalDate = _sut.ValidateDates(lateDate, lateDate);
            Assert.That(falseDate, Is.False);
            Assert.That(equalDate, Is.False);
        }

        [Test]
        [Category("DateManager")]
        public void DateValidator_ShouldReturnTrueIfFromDateIsLessThanToDate()
        {
            var earlyDate = new DateTime(2021,09,10,19,00,00);
            var lateDate = new DateTime(2021,10,10,19,00,00);

            var validate = _sut.ValidateDates(lateDate, earlyDate);
            
            Assert.That(validate, Is.True);
        }
        

        
        
    }
}