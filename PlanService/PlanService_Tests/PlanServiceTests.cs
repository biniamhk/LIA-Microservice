using System;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;
using PlanService.Models;
using PlanService.Repositories;
using PlanService.Services;
using PlanService.Repositories.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.OpenApi.Any;

namespace PlanService_Tests
{
    public class PlanServiceTests
    {

        private readonly PlanService.Services.PlanService _sut;
        private readonly Mock<IPlanRepository> _planRepositoryMock = new Mock<IPlanRepository>();
        private readonly Plan _plan;
        private string _planId = "6149c7a321e103804c876e28";


        public PlanServiceTests()
        {
            _sut = new PlanService.Services.PlanService(_planRepositoryMock.Object);
            _plan = new Plan
            {
                Id = "6149c7a321e103804c876e28",
                Name = "Operation CG",
                Description = "CG st�r f�r Carl Gustaf",
                FromDate = System.DateTime.Parse("2021-09-21 11:59:00"),
                ToDate = System.DateTime.Parse("2021-10-21 14:59:00"),
                CreatedBy = "Calle G",
                LastUpdated = System.DateTime.Parse("2021-09-21 11:59:00")


            };
            List<Member> memberList = new List<Member>();
            memberList.Add(new Member() { UserId = "thisIsUserId", UserName = "Tr�d-Harald" });
            _plan.Members = memberList;
        }

        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnPlanWithCorrectId()
        {
            //arrange
            _planRepositoryMock.Setup(m => m.GetPlanById(_planId)).ReturnsAsync(_plan);
            //act
            var actual = await _sut.GetPlanByIdAsync(_planId);
            //assert
            Assert.That(actual.Id, Is.EqualTo(_plan.Id));
        }


        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnPlanWithCorrectName()
        {
            //arrange
            _planRepositoryMock.Setup(m => m.GetPlanById(_planId)).ReturnsAsync(_plan);
            //act
            var actual = await _sut.GetPlanByIdAsync(_planId);
            //assert
            Assert.That(actual.Name, Is.EqualTo(_plan.Name));

        }


        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnPlanWithCorrectDescription()
        {
            //arrange
            _planRepositoryMock.Setup(m => m.GetPlanById(_planId)).ReturnsAsync(_plan);
            //act
            var actual = await _sut.GetPlanByIdAsync(_planId);
            //assert
            Assert.That(actual.Description, Is.EqualTo(_plan.Description));
        }


        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnPlanWithCorrectFromDate()
        {
            //arrange

            _planRepositoryMock.Setup(m => m.GetPlanById(_planId)).ReturnsAsync(_plan);
            //act
            var actual = await _sut.GetPlanByIdAsync(_planId);

            //assert

            Assert.That(actual.FromDate, Is.EqualTo(_plan.FromDate));

        }


        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnPlanWithCorrectToDate()
        {
            //arrange
            _planRepositoryMock.Setup(m => m.GetPlanById(_planId)).ReturnsAsync(_plan);
            //act
            var actual = await _sut.GetPlanByIdAsync(_planId);
            //assert
            Assert.That(actual.ToDate, Is.EqualTo(_plan.ToDate));
        }


        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnPlanWithCorrectCreatedBy()
        {
            //arrange
            _planRepositoryMock.Setup(m => m.GetPlanById(_planId)).ReturnsAsync(_plan);
            //act
            var actual = await _sut.GetPlanByIdAsync(_planId);
            //assert
            Assert.That(actual.CreatedBy, Is.EqualTo(_plan.CreatedBy));
            //Assert.That(actual.Members, Is.EqualTo(_plan.Members));
        }


        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnPlanWithCorrectMembers()
        {
            //arrange
            _planRepositoryMock.Setup(m => m.GetPlanById(_planId)).ReturnsAsync(_plan);
            //act
            var actual = await _sut.GetPlanByIdAsync(_planId);
            //assert
            Assert.That(actual.Id, Is.EqualTo(_plan.Id));
            //Assert.That(actual.Members, Is.EqualTo(_plan.Members));
        }


        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnPlanWithCorrectLastUpdated()
        {
            //arrange
            _planRepositoryMock.Setup(m =>
                m.GetPlanById(_planId))
                .ReturnsAsync(_plan);
            //act
            var actual = await _sut.GetPlanByIdAsync(_planId);
            //assert
            Assert.That(actual.LastUpdated, Is.EqualTo(_plan.LastUpdated));
        }


        [Test]
        [Category("Read")]
        public async Task GetPlanByIdAsync_ShouldReturnNullIfNotFound()
        {
            //arrange
            var emptyString = string.Empty;
            //act
            _planRepositoryMock.Setup(m =>
                m.GetPlanById(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            var plan = await _sut.GetPlanByIdAsync(Guid.NewGuid().ToString());
            //assert
            Assert.That(plan, Is.Null);

        }


        [Test]
        [Category("Create")]
        public async Task CreatePlanAsync_ShouldCreatePlan()
        {
            //arrange
            var plan = CreatePlanHelper();
            _planRepositoryMock.Setup(m =>
                    m.CreatePlanAsync(plan))
                    .ReturnsAsync(plan);


            //act

            var actualPlan = await _sut.CreatePlanAsync(plan);

            //assert
            Assert.That(actualPlan, Is.EqualTo(plan));
        }

        [Test]
        [Category("Update")]
        public async Task UpdatePlanAsync_ShouldReturnUpdatedPlan()
        {
            var plan = CreatePlanHelper();

            _planRepositoryMock.Setup(m =>
                   m.UpdatePlanAsync(plan))
                   .ReturnsAsync(plan);

            var actual = await _sut.UpdatePlanAsync(plan);

            Assert.That(actual, Is.EqualTo(plan));


        }


        [Test]
        [Category("Update")]
        public async Task UpdatePlanAsync_LastUpdatedShouldEqualDateTimeNow()
        {
            var plan = CreatePlanHelper();

            _planRepositoryMock.Setup(m =>
                   m.UpdatePlanAsync(plan))
                   .ReturnsAsync(plan);

            var actual = await _sut.UpdatePlanAsync(plan);

            Assert.That(actual.LastUpdated, Is.EqualTo(plan.LastUpdated));


        }


        [Test]
        [Category("Delete")]
        public async Task DeletePlanAsync_ShouldReturnDeletedPlan()
        {
            var plan = CreatePlanHelper();

            _planRepositoryMock.Setup(m =>
                   m.DeletePlanAsync(plan.Id))
                   .ReturnsAsync(plan);

            var actual = await _sut.DeletePlanAsync(plan.Id);

            Assert.That(actual, Is.EqualTo(plan));
        }


        [Test]
        [Category("Read")]
        public async Task GetAllPlansByUserIdAsync_ShouldReturnListOfPlans()
        {
            var plans = MockedPlanList();
            var userId = "1";
            _planRepositoryMock.Setup(m =>
                  m.GetAllPlansByUserIdAsync(userId))
                  .ReturnsAsync(() => plans);

            var actual = await _sut.GetAllPlansByUserIdAsync(userId);

            Assert.That(actual, Is.EqualTo(plans));

        }


        [Test]
        [Category("Read")]
        public async Task GetPlansWhereUserHasMemberShipAsync_ShouldReturnListOfPlans()
        {
            var plans = MockedPlanList();
            var userId = "1";
            _planRepositoryMock.Setup(m =>
            m.GetPlansWhereUserHasMemberShipAsync(userId))
                .ReturnsAsync(() => plans);

            var actual = await _sut.GetPlansWhereUserHasMemberShipAsync(userId);

            Assert.That(actual, Is.EqualTo(plans));
        }


        static List<Plan> MockedPlanList()
        {
            var plans = new List<Plan>
            {
                new Plan
                {
                    Name = "Operation FL",
                    Description = "FL står för Fredrik Larsson",
                    FromDate = new DateTime(2021, 10, 10, 19, 00, 00),
                    ToDate = new DateTime(2021, 10, 11, 19, 00, 00),
                    CreatedBy = "1",
                    LastUpdated = System.DateTime.Now,
                    Members = new List<Member>()
                    {
                        new Member(){UserId = "12", UserName = "JanneBoi"},
                        new Member(){UserId = "13", UserName = "Tomten"},
                        new Member(){UserId = "3", UserName = "Jan-Allan"}
                    }
                },


                new Plan()
                {
                    Name = "Operation Jan-Erik",
                    Description = "Lassagne är också gott",
                    FromDate = new DateTime(2021, 10, 10, 19, 00, 00),
                    ToDate = new DateTime(2021, 10, 11, 19, 00, 00),
                    CreatedBy = "1",
                    LastUpdated = System.DateTime.Now,
                    Members = new List<Member>()
                    {
                        new Member() { UserId = "13", UserName = "Tomten"},
                        new Member() { UserId = "3", UserName = "Jan-Allan"},
                        new Member() { UserId = "4", UserName = "Snurrig man"}
                    }
                },

                new Plan()
                {
                Name = "Operation Kebab",
                Description = "Stark och Mild",
                FromDate = new DateTime(2021, 10, 10, 19, 00, 00),
                ToDate = new DateTime(2021, 12, 11, 19, 00, 00),
                CreatedBy = "2",
                LastUpdated = System.DateTime.Now,
                Members = new List<Member>()
                {
                    new Member(){UserId = "12", UserName = "JanneBoi"},
                    new Member(){UserId = "13", UserName = "Tomten"},
                }
            },

                new Plan()
                {
                    Name = "Operation Pizzasallad",
                    Description = "Pizzasallad är gratis",
                    FromDate = new DateTime(2022, 01, 10, 19, 00, 00),
                    ToDate = new DateTime(2022, 03, 11, 19, 00, 00),
                    CreatedBy = "2",
                    LastUpdated = System.DateTime.Now,
                    Members = new List<Member>()
                    {
                        new Member(){UserId = "12", UserName = "JanneBoi"},
                        new Member(){UserId = "13", UserName = "Tomten"},
                        new Member(){UserId = "3", UserName = "Jan-Allan"},
                        new Member(){UserId = "16", UserName = "Papegojan"},
                        new Member(){UserId = "18", UserName = "Katten"},
                        new Member(){UserId = "19", UserName = "Hunden"}
                    }
                },

                new Plan()
                {
                    Name = "Operation Potatismos",
                    Description = "Potatismos kan man ha till det mesta",
                    FromDate = new DateTime(2021, 10, 10, 19, 00, 00),
                    ToDate = new DateTime(2021, 12, 01, 14, 40, 00),
                    CreatedBy = "3",
                    LastUpdated = System.DateTime.Now,
                    Members = new List<Member>()
                    {
                        new Member(){UserId = "12", UserName = "JanneBoi"},
                        new Member(){UserId = "13", UserName = "Tomten"},
                        new Member(){UserId = "3", UserName = "Jan-Allan"}
                    }
                }
            };





            return plans;
        }

        private Plan CreatePlanHelper()
        {
            var plan = new Plan()

            {
                Name = "Operation FL",
                Description = "FL står för Fredrik Larsson",
                FromDate = new DateTime(2021, 10, 10, 19, 00, 00),
                ToDate = System.DateTime.Parse("2021-10-21 14:59:00"),
                CreatedBy = "Fredrik Larsson",
                LastUpdated = System.DateTime.Now


            };

            List<Member> memberList = new List<Member>();
            memberList.Add(new Member() { UserId = "thisIsUserId", UserName = "Träd-Harald" });
            plan.Members = memberList;

            return plan;

        }





    }
}