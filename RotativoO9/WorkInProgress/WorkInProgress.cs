using RotativoO9.Data;

namespace RotativoO9.WorkInProgress
{
    public interface IWorkInProgress
    {
        void BeginTransaction();
        void Commit();
        void Rollback(Exception ex);    
    }
    public class WorkInProgress : IWorkInProgress
    {
        private readonly ApplicationDbContext _dbContext;
        public WorkInProgress(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void BeginTransaction()
        {
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback(Exception ex)
        {
        }
    }
}
