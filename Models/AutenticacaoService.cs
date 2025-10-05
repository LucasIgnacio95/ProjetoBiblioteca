// NOVO ARQUIVO: AutenticacaoService.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class AutenticacaoService
    {
        private readonly BibliotecaContext _context;

        public AutenticacaoService(BibliotecaContext context)
        {
            _context = context;
        }

        public void CheckLogin(Controller controller)
        {
            if (string.IsNullOrEmpty(controller.HttpContext.Session.GetString("Login")))
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }
        }

        public bool verificaLoginSenha(string Login, string senha, Controller controller)
        {
            verificaSeUsuarioAdminExiste(); // O context já está disponível na classe

            // Atenção: o nome do seu método de criptografia pode ser diferente
            string senhaCriptografada = Criptografo.TextoCriptografo(senha); 

            IQueryable<Usuario> UsuarioEncontrado = _context.Usuarios.Where(u => u.Login == Login && u.Senha == senhaCriptografada);
            
            Usuario? usuario = UsuarioEncontrado.FirstOrDefault(); // Mais eficiente que ToList()

            if (usuario == null)
            {
                return false;
            }
            else
            {
                controller.HttpContext.Session.SetString("Login", usuario.Login);
                controller.HttpContext.Session.SetString("Nome", usuario.Nome);
                controller.HttpContext.Session.SetInt32("Tipo", usuario.Tipo);
                return true;
            }
        }

        public void verificaSeUsuarioAdminExiste()
        {
            IQueryable<Usuario> userEncontrado = _context.Usuarios.Where(u => u.Login == "admin");

            if (!userEncontrado.Any()) // Mais eficiente que ToList().Count
            {
                Usuario admin = new Usuario();
                admin.Login = "admin";
                admin.Senha = Criptografo.TextoCriptografo("123");
                admin.Tipo = Usuario.admin;
                admin.Nome = "Administrador";

                _context.Usuarios.Add(admin);
                _context.SaveChanges();
            }
        }

        public void verificaSeUsuarioEAdmin(Controller controller)
        {
            if (!(controller.HttpContext.Session.GetInt32("Tipo") == Usuario.admin))
            {
                controller.Request.HttpContext.Response.Redirect("/Usuario/NeedAdmin");
            }
        }
    }
}