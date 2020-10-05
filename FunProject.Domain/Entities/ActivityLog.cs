using FunProject.Domain.Entities;
using System;

namespace FunProject.Persistence
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ActionType { get; set; }
        public DateTime ActivityDate { get; set; }

        public Customer Customer { get; set; }
    }
}