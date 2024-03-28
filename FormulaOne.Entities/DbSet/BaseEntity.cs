﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public  class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int status { get; set;  }
    }

}
