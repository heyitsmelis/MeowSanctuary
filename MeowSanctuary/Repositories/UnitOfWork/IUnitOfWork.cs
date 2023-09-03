namespace MeowSanctuary.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable

    {
        IWorkerRepository Workers { get; }
        IShelterRepository Shelters { get; }
        ICatRepository Cats { get; }
        IUserRepository Users { get; }
        IJobRepository Jobs { get; }
        int Save();
    }
}
