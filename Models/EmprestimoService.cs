using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class EmprestimoService 
    {
        // 1. Campo privado para armazenar o context
        private readonly BibliotecaContext _context;

        // 2. Construtor que recebe o context via injeção de dependência
        public EmprestimoService(BibliotecaContext context)
        {
            _context = context;
        }

        public void Inserir(Emprestimo e)
        {
            // 3. Usando o _context injetado
            _context.Emprestimos.Add(e);
            _context.SaveChanges();
        }

        public void Atualizar(Emprestimo e)
        {
            // 3. Usando o _context injetado
            Emprestimo emprestimo = _context.Emprestimos.Find(e.Id);
            emprestimo.NomeUsuario = e.NomeUsuario;
            emprestimo.Telefone = e.Telefone;
            emprestimo.LivroId = e.LivroId;
            emprestimo.DataEmprestimo = e.DataEmprestimo;
            emprestimo.DataDevolucao = e.DataDevolucao;
            emprestimo.Devolvido = e.Devolvido;

            _context.SaveChanges();
        }

        public ICollection<Emprestimo> ListarTodos(FiltrosEmprestimos filtro = null)
        {
            // 3. Usando o _context injetado
            IQueryable<Emprestimo> query = _context.Emprestimos.Include(e => e.Livro);

            if(filtro != null)
            {
                switch(filtro.TipoFiltro)
                {
                    case "NomeUsuario":
                        query = query.Where(e => e.NomeUsuario.Contains(filtro.Filtro));
                        break;
                    case "Livro":
                        query = query.Where(e => e.Livro.Titulo.Contains(filtro.Filtro));
                        break;
                }
            }
            
            return query.OrderByDescending(e => e.DataEmprestimo).ToList();
        }

        public Emprestimo ObterPorId(int id)
        {
            // 3. Usando o _context injetado
            return _context.Emprestimos.Include(e => e.Livro).FirstOrDefault(e => e.Id == id);
        }
    }
}