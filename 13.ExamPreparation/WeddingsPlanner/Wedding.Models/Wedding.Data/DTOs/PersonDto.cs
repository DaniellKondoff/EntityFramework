﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Models.Enums;

namespace Wedding.Data.DTOs
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
