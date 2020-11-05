using FunProject.Domain.Enums;
using System;

namespace FunProject.Domain.Entities
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime ActivityDate { get; set; }
        public string FullName { get; set; }
    }

  
}