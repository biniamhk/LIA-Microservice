using System.Collections.Generic;
using System.Threading.Tasks;
using PlanService.Models;
using PlanService.Repositories.Interface;


namespace PlanService.Services
{
    public class PlanService : IPlanService
    {
        private readonly  IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
            
        }

        public async Task<Plan> GetPlanByIdAsync(string planId)
        {
            return await _planRepository.GetPlanById(planId);      
        }

        public async Task<Plan> CreatePlanAsync(Plan plan)
        {
            return await _planRepository.CreatePlanAsync(plan);
        }

        public async Task<Plan> UpdatePlanAsync(Plan plan)
        {
            
            return await _planRepository.UpdatePlanAsync(plan);
        }

        public async Task<Plan> DeletePlanAsync(string planId)
        {
            return await _planRepository.DeletePlanAsync(planId);
        }

        public async Task<List<Plan>> GetAllPlansByUserIdAsync(string userId)
        {
            return await _planRepository.GetAllPlansByUserIdAsync(userId);
        }

        public async Task<List<Plan>> GetPlansWhereUserHasMemberShipAsync(string userId)
        {
            return await _planRepository.GetPlansWhereUserHasMemberShipAsync(userId);
        }
    }
}