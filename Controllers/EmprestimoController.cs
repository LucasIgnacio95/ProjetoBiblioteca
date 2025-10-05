using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Biblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        // 1. Declare fields for ALL services needed
        private readonly LivroService _livroService;
        private readonly EmprestimoService _emprestimoService;
        private readonly AutenticacaoService _autenticacaoService;

        // 2. Create a constructor that receives all the services
        public EmprestimoController(
            LivroService livroService, 
            EmprestimoService emprestimoService, 
            AutenticacaoService autenticacaoService)
        {
            _livroService = livroService;
            _emprestimoService = emprestimoService;
            _autenticacaoService = autenticacaoService;
        }

        public IActionResult Cadastro()
        {
            // 3. Use the injected services
            _autenticacaoService.CheckLogin(this);

            CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();
            cadModel.Livros = _livroService.ListarDisponiveis(); // Use ListarDisponiveis for new loans
            return View(cadModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CadEmprestimoViewModel viewModel)
        {
            if (viewModel.Emprestimo.Id == 0)
            {
                _emprestimoService.Inserir(viewModel.Emprestimo);
            }
            else
            {
                _emprestimoService.Atualizar(viewModel.Emprestimo);
            }
            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro)
        {
            _autenticacaoService.CheckLogin(this); 
            
            FiltrosEmprestimos objFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosEmprestimos();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }

            return View(_emprestimoService.ListarTodos(objFiltro));
        }

        public IActionResult Edicao(int id)
        {
            _autenticacaoService.CheckLogin(this);

            Emprestimo e = _emprestimoService.ObterPorId(id);

            CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();
            cadModel.Livros = _livroService.ListarTodos(); // For editing, showing all books is fine
            cadModel.Emprestimo = e;

            return View(cadModel);
        }
    }
}