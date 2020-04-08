using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreToDo.Models
{
    public class RegisterUser
    {
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirmation Password")]
        public string Confirm { get; set; }
    }
}
