using MeowSanctuary.Models.Base;

namespace MeowSanctuary.Repositories.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity

    {
        Task<List<TEntity>> GetAll();

        Task<TEntity?> GetById(int id);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);


    }
}
