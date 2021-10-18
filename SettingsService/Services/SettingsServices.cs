using MongoDB.Driver;
using SettingsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsService.Services
{
    public class SettingsServices
    {
        private readonly IMongoCollection<SettingsModel> _settings;

        public SettingsServices(ISettingsServiceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _settings = database.GetCollection<SettingsModel>(settings.SettingsCollection);
        }

        public List<SettingsModel> Get() =>
            _settings.Find(setting => true).ToList();

        public SettingsModel Get(string id) =>
            _settings.Find<SettingsModel>(setting => setting.Id == id).FirstOrDefault();


        public SettingsModel GetbyUserID(string userid) =>
            _settings.Find<SettingsModel>(setting => setting.UserId == userid).FirstOrDefault();


        public SettingsModel Create(SettingsModel setting)
        {
            _settings.InsertOne(setting);
            return setting;
        }

        public void Update(string id, SettingsModel settingIn) =>
            _settings.ReplaceOne(setting => setting.Id == id, settingIn);

        public void Remove(SettingsModel settingIn) =>
            _settings.DeleteOne(setting => setting.Id == settingIn.Id);

        public void Remove(string id) =>
            _settings.DeleteOne(setting => setting.Id == id);
    }
}
