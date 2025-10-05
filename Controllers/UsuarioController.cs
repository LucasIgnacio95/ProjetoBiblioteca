using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        // 1. Declare os campos para os serviços necessários
        private readonly UsuarioService _usuarioService;
        private readonly AutenticacaoService _autenticacaoService;

        // 2. Crie o construtor para receber os serviços
        public UsuarioController(UsuarioService usuarioService, AutenticacaoService autenticacaoService)
        {
            _usuarioService = usuarioService;
            _autenticacaoService = autenticacaoService;
        }

        // Lista -----------
        public IActionResult ListaDeUsuarios()
        {
            // 3. Use as instâncias dos serviços
            _autenticacaoService.CheckLogin(this);
            _autenticacaoService.verificaSeUsuarioEAdmin(this);
            return View(_usuarioService.Listar());
        }

        // Inserção --------
        public IActionResult RegistrarUsuario()
        {
            _autenticacaoService.CheckLogin(this);
            _autenticacaoService.verificaSeUsuarioEAdmin(this);
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(Usuario novoUsuario)
        {
            // A criptografia já é feita dentro do incluirUsuario, para manter o padrão
            _usuarioService.incluirUsuario(novoUsuario);
            return RedirectToAction("CadastroRealizado"); // Redireciona para a lista
        }

        public IActionResult CadastroRealizado()
        {
            {
            _autenticacaoService.CheckLogin(this);
            return View();
            }
        }

        // Edição ---------
        public IActionResult EditarUsuario(int id)
        {
            _autenticacaoService.CheckLogin(this);
            _autenticacaoService.verificaSeUsuarioEAdmin(this);
            Usuario? u = _usuarioService.Listar(id);
            return View(u);
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario userEditado)
        {
            _usuarioService.editarUsuario(userEditado);
            return RedirectToAction("ListaDeUsuarios");
        }
        
        // Exclusão ---------
        public IActionResult ExcluirUsuario(int id)
        {
            _autenticacaoService.CheckLogin(this);
            _autenticacaoService.verificaSeUsuarioEAdmin(this);
            return View(_usuarioService.Listar(id));
        }

        [HttpPost]
        public IActionResult ExcluirUsuario(string decisao, int id)
        {
            if (decisao == "EXCLUIR")
            {
                // Usa o serviço injetado para buscar o nome antes de excluir
                string nomeUsuario = _usuarioService.Listar(id).Nome;
                _usuarioService.excluirUsuario(id);

                // Usa TempData para enviar a mensagem através do redirect
                TempData["Mensagem"] = "Exclusão do usuário " + nomeUsuario + " realizada com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Exclusão Cancelada.";
            }

            // Redireciona o usuário para página de Listagem
            return RedirectToAction("ListaDeUsuarios");
        }

        // Funções Extras ------
        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult NeedAdmin()
        {
            _autenticacaoService.CheckLogin(this);
            return View();
        }
    }
}