﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreToDo.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public bool State { get; set; }
        public int UserId { get; set; }
    
    }
}
