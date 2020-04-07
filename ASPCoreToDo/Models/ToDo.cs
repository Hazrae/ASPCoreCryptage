using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreToDo.Models
{
    public class ToDo
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Descr { get; set; }
        public bool State { get; set; }
        public int UserId { get; set; }
    
    }
}
