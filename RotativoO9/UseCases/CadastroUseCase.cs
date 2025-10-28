using Microsoft.EntityFrameworkCore;
using RotativoO9.Data;
using RotativoO9.Entities;
using RotativoO9.Repository;
using RotativoO9.WorkInProgress;

namespace RotativoO9.UseCases
{
    public interface ICadastroUseCase
    {
        void AdmissaoNovoUsuarioRotativo(Cadastro c);
    }

    public class CadastroUseCase : ICadastroUseCase
    {
        private readonly ICadastroRepository _cadastroRep;
        private readonly IWorkInProgress _wip;

        // private readonly ApplicationDbContext _dbContext;

        public CadastroUseCase(ICadastroRepository cadastroRep, IWorkInProgress wip)
        {
            _cadastroRep = cadastroRep;
            _wip = wip;
        }

        public void AdmissaoNovoUsuarioRotativo(Cadastro c)
        {
            try
            {
                //BEGINTRANSACTION
                _wip.BeginTransaction();


                _cadastroRep.SalvaCadastro(c); //cadastro do usuário

                //cadastrar veículos
                // _veiculosRep.SalvaVeiculos(vs);

                //registrar cartao de credito em formato seguro
                // _formaPgtoRep.Salvar(fp);


                //COMMIT
                _wip.Commit();
            }
            catch (Exception ex)
            {
                //ROLLBACK
                _wip.Rollback(ex);

                throw ex;
            }

        }


    }
}
