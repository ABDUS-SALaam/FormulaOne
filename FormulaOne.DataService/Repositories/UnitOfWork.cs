using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public IDriverRepository DriverRepository { get; }

        public IAchievementsRepository AchievementsRepository { get; }


        public UnitOfWork(AppDbContext dbContext,ILoggerFactory loggerFactory)
        {
            _context = dbContext;
            _logger = loggerFactory.CreateLogger("logs");
            DriverRepository = new DriverRepository(_context,_logger);
            AchievementsRepository=new AchievementsRepository(_context,_logger);
        }
        public async Task<bool> CompleteAsync()
        {
            var result=await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
