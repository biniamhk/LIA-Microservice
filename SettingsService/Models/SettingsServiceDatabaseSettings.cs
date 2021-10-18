using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsService.Models
{
    public class SettingsServiceDatabaseSettings : ISettingsServiceDatabaseSettings
    {
        public string SettingsCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
