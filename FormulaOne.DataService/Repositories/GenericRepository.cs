using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ILogger _logger;

        protected AppDbContext _context;


        internal DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context,ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet =context.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            try
            {
                /* Write code here to fetch all records*/
                await _dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(T));
                throw;
            }
            
        }

        public async virtual Task<IEnumerable<T>> All()
        {
            try
            {
                /* Write code here to fetch all records*/
                var records = await _dbSet.ToListAsync();
                return records;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} All function error", typeof(T));
                throw;
            }
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
