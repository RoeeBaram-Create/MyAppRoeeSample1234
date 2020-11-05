using FunProject.Domain.Entities;
using FunProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunProject.Application.Creations
{
    public class ActiviryLogCreation: IActiviryLogCreation
    {
      
        public ActivityLog CreateActivityLog(Customer customer, ActionType actionType)
        {
            ActivityLog activityLog = new ActivityLog();
            activityLog.CustomerId = customer.Id;
            activityLog.ActionType = actionType;
            activityLog.ActivityDate = DateTime.Now;
            activityLog.FullName = $"{customer.FirstName} {customer.LastName}";

            return activityLog;
        }
         
    }
}
