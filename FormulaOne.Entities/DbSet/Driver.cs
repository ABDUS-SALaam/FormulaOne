﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public  class Driver:BaseEntity
    {
        public Driver()
        {
            Achievements = new HashSet<Achievement>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DriverNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set;}
    }
}
