using System;
using System.Collections.Generic;
using PlanService.Models;


namespace PlanService.DTOS
{
    public class PlanCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy {  get; set; }  
        public DateTime FromDate { get; set; }        
        public DateTime ToDate { get; set; }   
        public List<Member> Members { get; set; }

    }
}