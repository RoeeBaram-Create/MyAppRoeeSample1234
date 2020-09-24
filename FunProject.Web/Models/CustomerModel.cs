using System.ComponentModel.DataAnnotations;

namespace FunProject.Application.Dtos
{
    public class CustomerModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
