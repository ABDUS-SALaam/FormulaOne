﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Request
{
    public class CreateDriverRequest
    {
        public string FirstName { get; set; }=string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int DriverNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
