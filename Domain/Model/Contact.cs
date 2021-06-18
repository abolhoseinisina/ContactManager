using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeTelephone { get; set; }
        [Required]
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SkypeName { get; set; }
    }
}
