using RotativoO9.Data;
using RotativoO9.Entities;

namespace RotativoO9.Repository
{

    public interface ICadastroRepository
    {
        void SalvaCadastro(Cadastro c);
    }

    public class CadastroRepository : ICadastroRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CadastroRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SalvaCadastro(Cadastro c)
        {
            _dbContext.Cadastros.Add(c);
            //_dbContext.SaveChanges();
        }
    }
}
