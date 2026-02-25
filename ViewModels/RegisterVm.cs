using System.ComponentModel.DataAnnotations;

namespace BizSecureDemo_22180064.ViewModels
{
    public class RegisterVm
    {
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Required, MinLength(6)]
        public string Password { get; set; } = "";
    }

}
