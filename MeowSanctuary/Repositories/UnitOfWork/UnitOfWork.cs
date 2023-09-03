using MeowSanctuary.Data;

namespace MeowSanctuary.Repositories.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private SanctuaryContext context;
        public UnitOfWork(SanctuaryContext context)
        {
            this.context = context;

            Workers = new WorkerRepository(context);
            Users = new UserRepository(context);
            Jobs = new JobRepository(context);
            Shelters = new ShelterRepository(context);
            Cats = new CatRepository(context);


        }
        public IWorkerRepository Workers
        {
            get;
            private set;
        }
        public IShelterRepository Shelters
        {
            get;
            private set;
        }
        public ICatRepository Cats
        {
            get;
            private set;
        }
        public IUserRepository Users
        {
            get;
            private set;
        }
        public IJobRepository Jobs
        {
            get;
            private set;
        }

        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
