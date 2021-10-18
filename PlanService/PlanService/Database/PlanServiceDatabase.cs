using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using PlanService.Models;

namespace PlanService.Database
{
    public class PlanServiceDatabase
    {
        private readonly IPlanServiceDataBaseSettings _settings;
        private IMongoCollection<Plan> _plans;
        
        public PlanServiceDatabase(IPlanServiceDataBaseSettings settings)
        {
            _settings = settings;
        }


        public IMongoCollection<Plan> PlanCollection()
        {
            var client = new MongoClient(_settings.DockerDbString);
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
            var dataBase = client.GetDatabase(_settings.DatabaseName);
            
            
            _plans = dataBase.GetCollection<Plan>(_settings.PlanCollectionName);
            var planCount = _plans.CountDocuments(new BsonDocument());
            if(planCount == 0)
            {
                SeedInitialData(_plans);
                return _plans;
            }
            else           
                return _plans;

           

        
        }

        public void SeedInitialData(IMongoCollection<Plan> _plans)
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

            _plans.InsertManyAsync(plans).Wait();
            
        }
    }
}