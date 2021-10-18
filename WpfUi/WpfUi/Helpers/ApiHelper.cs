using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfUi.Models;

namespace WpfUi.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient apiClient;

        public ApiHelper()
        {
            InitializeClient();
        }
        private void InitializeClient()
        {


            apiClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:3666/")
            };
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        public async Task<List<MapSearchModel>> MapSearch(string location)
        {

            HttpResponseMessage response = await apiClient.GetAsync($"search/{location}");

            string jsonResponse = await response.Content.ReadAsStringAsync();
            try
            {
                var result = JsonConvert.DeserializeObject<List<MapSearchModel>>(jsonResponse);
                return result;
            }
            catch
            {
                List<MapSearchModel> nothingFound = new();
                nothingFound.Add(new MapSearchModel { Place = "Nothing Found" });
                return nothingFound;
            }




        }

        public async Task<SettingsModel> GetSettingsForUser(string userId)
        {

            HttpResponseMessage response = await apiClient.GetAsync($"settings/{userId}");

            string jsonResponse = await response.Content.ReadAsStringAsync();


            SettingsModel settings = JsonConvert.DeserializeObject<SettingsModel>(jsonResponse);

            return settings;

        }

        public async Task<SettingsModel> RestoreDefaultSettings(string userId)
        {

            HttpResponseMessage response = await apiClient.GetAsync($"settings/restore/{userId}");

            string jsonResponse = await response.Content.ReadAsStringAsync();


            SettingsModel settings = JsonConvert.DeserializeObject<SettingsModel>(jsonResponse);

            return settings;

        }

        public async Task<SettingsModel> UpdateSettingsForUser(string UserId, SettingsModel settingsModel)
        {

            var jsonString = JsonConvert.SerializeObject(settingsModel);

            var buffer = Encoding.UTF8.GetBytes(jsonString);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await apiClient.PutAsync($"settings/{UserId}", byteContent);
            return settingsModel;


        }






        public async Task<TimePlanModel> CreateTimePlan(TimePlanModel timePlanModel)
        {

            var jsonString = JsonConvert.SerializeObject(timePlanModel);
            var buffer = Encoding.UTF8.GetBytes(jsonString);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            try
            {
                var httpResponse = await apiClient.PostAsync("/planservice", byteContent);

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return timePlanModel;
        }

        public async Task<TimePlanModel> UpdateTimePlan(TimePlanModel timePlanModel)
        {
            var jsonString = JsonConvert.SerializeObject(timePlanModel);
            var buffer = Encoding.UTF8.GetBytes(jsonString);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            try
            {
                var httpResponse = await apiClient.PutAsync("/planservice", byteContent);

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return timePlanModel;
        }

        public async Task DeleteTimeplan(string planid)
        {
            var httpResponse = await apiClient.DeleteAsync($"planservice/{planid}");
        }




        public async Task<List<TimePlanModel>> GetAllPlansByUserId(string userId)
        {
            HttpResponseMessage response = await apiClient.GetAsync($"/planservice/getAllPlans/{userId}");

            string jsonResponse = await response.Content.ReadAsStringAsync();
            try
            {
                var result = JsonConvert.DeserializeObject<List<TimePlanModel>>(jsonResponse);

                return result;
            }
            catch
            {
                List<TimePlanModel> nothingFound = new();
                return nothingFound;
            }
        }







        public async Task<List<TimePlanModel>> GetAllPlansByMemberShip(string userId)
        {
            HttpResponseMessage response = await apiClient.GetAsync($"/planservice/membership/{userId}");

            string jsonResponse = await response.Content.ReadAsStringAsync();
            try
            {
                var result = JsonConvert.DeserializeObject<List<TimePlanModel>>(jsonResponse);
                return result;
            }
            catch
            {
                List<TimePlanModel> nothingFound = new();
                return nothingFound;
            }
        }
    }
}
