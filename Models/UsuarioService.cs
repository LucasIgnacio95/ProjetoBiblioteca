using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; // Pode ser necessário adicionar este using


namespace Biblioteca.Models
{
    public class UsuarioService
    {
        // 1. Campo privado para armazenar o context
        private readonly BibliotecaContext _context;

        public UsuarioService(BibliotecaContext context)
        {
            _context = context;
        }


        public List<Usuario> Listar()     
            {
                return _context.Usuarios.ToList();
            }
        
        public Usuario? Listar(int id)           
            {
                return _context.Usuarios.Find(id);
            }
        

        public void incluirUsuario(Usuario u)
        {       
                // 1. Criptografa a senha ANTES de salvar
                u.Senha = Criptografo.TextoCriptografo(u.Senha);     
                _context.Add(u);
                _context.SaveChanges();            
        }
        public void editarUsuario(Usuario userEditado)
        {
            Usuario? usuarioDB = _context.Usuarios.Find(userEditado.Id);
            if (usuarioDB != null)
            {
                usuarioDB.Login = userEditado.Login;
                usuarioDB.Nome = userEditado.Nome;
                usuarioDB.Tipo = userEditado.Tipo;

                // Só atualiza a senha se uma nova senha for fornecida
                if (!String.IsNullOrEmpty(userEditado.Senha))
                {
                    usuarioDB.Senha = Criptografo.TextoCriptografo(userEditado.Senha);
                }

                _context.SaveChanges();
            }

                   
        }
        public void excluirUsuario(int id)
        {
            // 1. Encontre o usuário no banco de dados pelo id
            Usuario? usuarioParaExcluir = _context.Usuarios.Find(id);

            // 2. Se o usuário for encontrado, remova o objeto
            if (usuarioParaExcluir != null)
            {
            _context.Usuarios.Remove(usuarioParaExcluir);
            _context.SaveChanges();            
            }
            
        }
    }

}