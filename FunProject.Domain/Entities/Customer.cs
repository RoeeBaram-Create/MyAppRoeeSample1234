using System.Collections.Generic;

namespace FunProject.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}