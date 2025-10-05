using System;
using Biblioteca.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        // 1. CRIE CAMPOS PRIVADOS PARA OS SERVIÇOS QUE O CONTROLLER VAI USAR
        private readonly LivroService _livroService;
        private readonly AutenticacaoService _autenticacaoService;

        // 2. CRIE UM CONSTRUTOR QUE RECEBE OS SERVIÇOS POR INJEÇÃO DE DEPENDÊNCIA
        public LivroController(LivroService livroService, AutenticacaoService autenticacaoService)
        {
            _livroService = livroService;
            _autenticacaoService = autenticacaoService;
        }

        public IActionResult Cadastro()
        {
            // 3. USE AS INSTÂNCIAS DOS SERVIÇOS EM VEZ DE CHAMADAS ESTÁTICAS OU "NEW"
            _autenticacaoService.CheckLogin(this);
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Livro l)
        {
            if(l.Id == 0)
            {
                _livroService.Inserir(l);
            }
            else
            {
                _livroService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, int PaginaAtual = 1, int itensPorPagina = 10) // Removi parâmetros não utilizados para simplificar
        {
            _autenticacaoService.CheckLogin(this);
            
            FiltrosLivros objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosLivros();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }

            // Define os valores do ViewData que estavam faltando
            ViewData["livrosPorPagina"] = itensPorPagina;
            ViewData["PaginaAtual"] = PaginaAtual;
            
            // Obtém a lista completa de livros
            List<Livro> listaDeLivros = _livroService.ListarTodos(objFiltro).ToList();
    
            return View(listaDeLivros);
        }

        public IActionResult Edicao(int id)
        {
            _autenticacaoService.CheckLogin(this);
            Livro l = _livroService.ObterPorId(id);
            return View(l);
        }
    }
}