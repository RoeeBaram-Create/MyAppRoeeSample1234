using System;

namespace FunProject.Domain.Entities
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