using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using PlanService.Models;
using PlanService.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using PlanService.Database;

namespace PlanService.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly PlanServiceDatabase _database;

        public PlanRepository(PlanServiceDatabase database)
        {
            _database = database;
        }


        public async Task<Plan> GetPlanById(string planId)
        {

            var plan = await _database.PlanCollection()
                .Find<Plan>(pl => pl.Id == planId)
                .FirstOrDefaultAsync();
            if (plan != null)
            {
                return plan;
            }
            else
                return null;

        }

        public async Task<Plan> CreatePlanAsync(Plan plan)
        {
            if (plan != null)
            {
                plan.LastUpdated = DateTime.Now;
                await _database
                    .PlanCollection()
                    .InsertOneAsync(plan);
                return plan;
            }
            else
                return null;

        }

        public async Task<Plan> UpdatePlanAsync(Plan plan)
        {
            
            if (plan != null)
            {
                plan.LastUpdated = DateTime.Now;
                var filter = Builders<Plan>.Filter.Eq(p => p.Id, plan.Id);


                await _database.PlanCollection()
                    .ReplaceOneAsync(filter, plan);
                return plan;
            }
            else
                return null;


        }

        public async Task<Plan> DeletePlanAsync(string planId)
        {
            var deletedPlan = await _database.PlanCollection()
                .FindOneAndDeleteAsync(p => p.Id == planId);
            if (deletedPlan != null)
            {
                return deletedPlan;
            }
            else
                return null;

        }

        public async Task<List<Plan>> GetAllPlansByUserIdAsync(string userId)
        {

            var plans = await _database.PlanCollection()
                .FindAsync(p => p.CreatedBy == userId);

            if (plans != null)
            {
                return plans.ToList();
            }
            else
                return null;
        }

        public async Task<List<Plan>> GetPlansWhereUserHasMemberShipAsync(string userId)
        {
            var filter = Builders<Plan>.Filter.ElemMatch(x => x.Members, x => x.UserId == userId);
            var plans = await _database.PlanCollection().FindAsync(filter);

            if (plans != null)
            {
                return plans.ToList();
            }
            else
                return null;


        }
    }
}




