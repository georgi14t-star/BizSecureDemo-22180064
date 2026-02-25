using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BizSecureDemo_22180064.ViewModels
{
    

    public class CreateOrderVm
    {
        [Required, MaxLength(80)]
        //[Required, MaxLength(300)]
        public string Title { get; set; } = "";
        [Required]
        public decimal Amount { get; set; }
       

    }


}
