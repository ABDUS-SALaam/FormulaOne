using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class AchievementsRepository : GenericRepository<Achievement>, IAchievementsRepository
    {
        public AchievementsRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Achievement?> GetDriverAchievementsAsync(Guid driverId)
        {
            try
            {

                return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId );

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetDriverAchievementsAsync function error", typeof(Achievement));
                throw;
            }
        }


        public override async Task<IEnumerable<Achievement>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.status == 1)
                    .AsNoTracking().AsSplitQuery().OrderBy(x => x.AddedDate).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(Achievement));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null) return false;
                result.status = 0;
                result.UpdatedDate = DateTime.UtcNow;
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Delete function error", typeof(Achievement));
                throw;
            }
        }

        public override async Task<bool> Update(Achievement achievement)
        {
            try
            {
                /*Bug over here need to figure out way to deal with id not with driverId*/
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);
                if (result == null) return false;
                result.status = 0;
                result.UpdatedDate = DateTime.UtcNow;
                result.FastestLap = achievement.FastestLap;
                result.PolePosition = achievement.PolePosition;
                result.RaceWins = achievement.RaceWins;
                result.WorldChampionship = achievement.WorldChampionship;
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} Update function error", typeof(Achievement));
                throw;
            }
        }


    }
}

