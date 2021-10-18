using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUi.Models
{
    public class TimePlanModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<Member> Members { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
    }


    public class Member
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
    }

}
