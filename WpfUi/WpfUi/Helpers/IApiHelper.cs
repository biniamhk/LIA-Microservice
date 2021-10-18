using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUi.Models;

namespace WpfUi.Helpers
{
    public interface IApiHelper
    {
        //Settings

        Task<SettingsModel> GetSettingsForUser(string userId);
        Task<SettingsModel> UpdateSettingsForUser(string UserId, SettingsModel settingsModel);
        Task<SettingsModel> RestoreDefaultSettings(string UserId);
        //Settings



        // MapServices
        Task<List<MapSearchModel>> MapSearch(string location);

        // MapServices



        // PlanService

        Task<TimePlanModel> CreateTimePlan(TimePlanModel timePlanModel);
        Task<TimePlanModel> UpdateTimePlan(TimePlanModel timePlanModel);
        Task DeleteTimeplan(string planId);


        Task<List<TimePlanModel>> GetAllPlansByUserId(string userId);
        Task<List<TimePlanModel>> GetAllPlansByMemberShip(string userId);

        // PlanService

    }
}
