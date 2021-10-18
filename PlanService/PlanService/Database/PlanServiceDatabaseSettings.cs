using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanService.Models
{
    public class PlanServiceDatabaseSettings : IPlanServiceDataBaseSettings
    {
        public string PlanCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string DockerDbString { get; set; }
    }
    public interface IPlanServiceDataBaseSettings 
    {
        string PlanCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string DockerDbString { get; set; }

    }
}
