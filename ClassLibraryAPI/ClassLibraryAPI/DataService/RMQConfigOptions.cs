using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibraryAPI.DataService
{
    public class RMQConfigOptions
    {
        public string JsonOptionsName { get; set; }
        public string RabbitMQHost { get; set; }

        public string RabbitMQPort { get; set; }

        public string ExchangeName { get; set; }
    }
}
