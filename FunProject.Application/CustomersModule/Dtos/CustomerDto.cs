using System.ComponentModel.DataAnnotations;

namespace FunProject.Application.CustomersModule.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
