using System.Linq;
using System.Collections.Generic;
using System.Collections;
using Microsoft.EntityFrameworkCore; // Pode ser necessário adicionar este using

namespace Biblioteca.Models
{
    public class LivroService
    {
        // 1. Campo privado para armazenar o context
        private readonly BibliotecaContext _context;

        // 2. Construtor que recebe o context via injeção de dependência
        public LivroService(BibliotecaContext context)
        {
            _context = context;
        }

        public void Inserir(Livro l)
        {
            // 3. Usando o _context injetado
            _context.Livros.Add(l);
            _context.SaveChanges();
        }

        public void Atualizar(Livro l)
        {
            // 3. Usando o _context injetado
            Livro livro = _context.Livros.Find(l.Id);
            livro.Autor = l.Autor;
            livro.Titulo = l.Titulo;

            _context.SaveChanges();
        }

        public ICollection<Livro> ListarTodos(FiltrosLivros filtro = null)
        {
            // 3. Usando o _context injetado
            IQueryable<Livro> query;
            
            if(filtro != null)
            {
                switch(filtro.TipoFiltro)
                {
                    case "Autor":
                        query = _context.Livros.Where(l => l.Autor.Contains(filtro.Filtro));
                        break;
                    case "Titulo":
                        query = _context.Livros.Where(l => l.Titulo.Contains(filtro.Filtro));
                        break;
                    default:
                        query = _context.Livros;
                        break;
                }
            }
            else
            {
                query = _context.Livros;
            }
            
            return query.OrderBy(l => l.Titulo).ToList();
        }

        public ICollection<Livro> ListarDisponiveis()
        {
            // 3. Usando o _context injetado
            return _context.Livros
                .Where(l => !(_context.Emprestimos.Where(e => e.Devolvido == false).Select(e => e.LivroId).Contains(l.Id)))
                .ToList();
        }

        public Livro ObterPorId(int id)
        {
            // 3. Usando o _context injetado
            return _context.Livros.Find(id);
        }
    }
}