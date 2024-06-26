﻿using FormulaOne.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IAchievementsRepository:IGenericRepository<Achievement>
    {
        Task<Achievement?> GetDriverAchievementsAsync(Guid driverId);
    }
}
