﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {DateOfBirthday.ToShortDateString()} {Age}";
        }
    }
}
