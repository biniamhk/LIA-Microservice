using PlanService.Models;
using System;
using System.Collections.Generic;

namespace PlanService.DTOS
{
    public class PlanPutDto
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
}
