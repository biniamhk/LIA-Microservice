using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchService.ViewModels
{
    public class GISAuthTokenModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public DateTime ExpireTime => DateTime.UtcNow.AddSeconds(expires_in);
    }
}
