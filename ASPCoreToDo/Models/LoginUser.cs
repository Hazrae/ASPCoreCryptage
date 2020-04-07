using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreToDo.Models
{
    public class LoginUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
