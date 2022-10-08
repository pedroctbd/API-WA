using Microsoft.EntityFrameworkCore;
using WAAPI.Application.Interfaces;
using WAAPI.Infrastructure.Context;

namespace WAAPI.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {

        private readonly ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity obj)
        {

            _context.Set<TEntity>().Add(obj);
            _context.SaveChangesAsync();

        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChangesAsync();
        }

        public void Update(TEntity obj)
        {

            _context.Set<TEntity>().Update(obj);
            _context.SaveChangesAsync();
        }
    
        public async Task<IEnumerable<TEntity>> GetAll()
        {
           return await _context.Set<TEntity>().ToListAsync();
           
        }

        public async Task<TEntity> GetById(int id)
        {       
           return await _context.Set<TEntity>().FindAsync(id);       
          
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}