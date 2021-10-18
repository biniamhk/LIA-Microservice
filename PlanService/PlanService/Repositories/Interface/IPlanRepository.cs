using PlanService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanService.Repositories.Interface
{
    public interface IPlanRepository
    {
        Task<Plan> GetPlanById(string planId);
        Task<Plan> CreatePlanAsync(Plan plan);
        Task<Plan> UpdatePlanAsync(Plan plan);
        Task<Plan> DeletePlanAsync(string planId);
        Task<List<Plan>> GetAllPlansByUserIdAsync(string userId);
        Task<List<Plan>> GetPlansWhereUserHasMemberShipAsync(string userId);
    }
}
