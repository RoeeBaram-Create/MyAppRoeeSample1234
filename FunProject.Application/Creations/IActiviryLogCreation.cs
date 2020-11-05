using FunProject.Domain.Entities;
using FunProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunProject.Application.Creations
{
    public interface IActiviryLogCreation
    {
        ActivityLog CreateActivityLog(Customer customer, ActionType ActionType);
    }
}
