using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreToDo.Models
{
    public class User : LoginUser
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
     
    }
}
