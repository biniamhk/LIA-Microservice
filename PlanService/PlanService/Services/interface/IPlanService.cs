using System.Collections.Generic;
using System.Threading.Tasks;
using PlanService.Models;

namespace PlanService.Services
{
    public interface IPlanService
    {
        Task<Plan> GetPlanByIdAsync(string planId);
        Task<Plan> CreatePlanAsync(Plan plan);
        Task<Plan> UpdatePlanAsync(Plan planId);
        Task<Plan> DeletePlanAsync(string planId);
        Task<List<Plan>> GetAllPlansByUserIdAsync(string userId);
        Task<List<Plan>> GetPlansWhereUserHasMemberShipAsync(string userId);
    }
}