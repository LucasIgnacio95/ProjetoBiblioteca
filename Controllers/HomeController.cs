using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // 1. Declare the service field
        private readonly AutenticacaoService _autenticacaoService;

        // 2. Add the service to the constructor
        public HomeController(ILogger<HomeController> logger, AutenticacaoService autenticacaoService)
        {
            _logger = logger;
            _autenticacaoService = autenticacaoService;
        }

        public IActionResult Index()
        {
            // 3. Use the service instance
            _autenticacaoService.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            // 3. Use the service instance here as well
            if(_autenticacaoService.verificaLoginSenha(login, senha, this))
            {
                return RedirectToAction("index");
            }
            else
            {
                ViewData["Erro"] = "Senha inválida";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}