using Microsoft.AspNetCore.Mvc;
using RotativoO9.Data;
using RotativoO9.Entities;
using RotativoO9.Models;
using RotativoO9.UseCases;
using System.Diagnostics;

namespace RotativoO9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CriarCadastro([FromServices] ICadastroUseCase cadastroUC)
        {
            Cadastro c = new Cadastro();
            c.Id = Guid.NewGuid();
            c.Nome = "Cadastro de Teste";
            c.Quantidade = 10;
            c.Tipo = TipoCadastroEnum.Cliente;

            cadastroUC.AdmissaoNovoUsuarioRotativo(c);

            return RedirectToAction("Cadastro");
        }

        public IActionResult Cadastro()
        {
            List<Cadastro> cadastros = _dbContext.Cadastros.Where(c => c.Quantidade > 5).ToList();
            List<Cadastro> cadastros2 = _dbContext.Cadastros.ToList().Where(c => c.Quantidade > 5).ToList();

            return View(cadastros);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
