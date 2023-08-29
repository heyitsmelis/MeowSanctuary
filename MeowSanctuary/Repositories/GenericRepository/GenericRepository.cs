using MeowSanctuary.Data;
using MeowSanctuary.Models.Base;
using MeowSanctuary.Repositories.IGenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MeowSanctuary.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SanctuaryContext _context;

        public GenericRepository(SanctuaryContext context)
        {
            _context = context;
        }

        public GenericRepository()
        {
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await Task.CompletedTask;
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await Task.CompletedTask;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

    }
}
