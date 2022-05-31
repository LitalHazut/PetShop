using System.ComponentModel.DataAnnotations;

namespace PetShop.Client.Models
{
    public class LoginPageModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
