using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class UserModel
    {
        //[Required]
        //[Display(Name = "Some Id")]
        //public int Id { get; set; }
        //[Required]
        //[Display(Name = "Some Name")]
        //public string Name { get; set; }

        //[Required]
        //[Display(Name = "Some Date Of Birth")]
        //public DateTime Dob { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool IsAuthorisedUser { get; set; }

    }
}
