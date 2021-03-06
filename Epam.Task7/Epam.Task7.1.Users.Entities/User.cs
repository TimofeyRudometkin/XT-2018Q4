﻿using System;

namespace Epam.Task7._1.Users.Entities
{
    public class User
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {DateOfBirthday.ToShortDateString()} {Age}";
        }
    }
}
