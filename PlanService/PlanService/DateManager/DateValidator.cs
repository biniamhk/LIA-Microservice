using System;
using PlanService.Models;

namespace PlanService.DateManager
{
    public class DateValidator
    {
        public bool ValidateDates(DateTime toDate,DateTime fromDate)
        {
           if (toDate <= fromDate )
           {
               return false;
           }
           else
           {
               return true;
           }
 
        }

    }
}