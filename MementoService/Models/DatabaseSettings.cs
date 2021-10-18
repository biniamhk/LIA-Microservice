using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MementoService.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string MementosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string MementosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
