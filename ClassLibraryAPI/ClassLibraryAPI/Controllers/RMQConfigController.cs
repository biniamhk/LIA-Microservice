using ClassLibraryAPI.DataService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClassLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RMQConfigController : ControllerBase
    {
        // GET: api/<RMQConfigController>
        [HttpGet]
        public RMQConfigOptions Get()
        {
            return new RMQConfigOptions { RabbitMQHost = "localhost", RabbitMQPort="5672(as int)", ExchangeName="PublishedObjectService", JsonOptionsName="RMQ"};
                                          
        }
      
    }
}
