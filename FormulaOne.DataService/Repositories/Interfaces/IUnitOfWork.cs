using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IDriverRepository DriverRepository { get; }

        public IAchievementsRepository AchievementsRepository { get;  }

        Task<bool> CompleteAsync();
    }
}
