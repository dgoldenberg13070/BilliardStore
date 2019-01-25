//using System.ComponentModel.DataAnnotations;

namespace BilliardStore.Models.ViewModels
{

    public class LoginModel
    {

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";

    }

}

