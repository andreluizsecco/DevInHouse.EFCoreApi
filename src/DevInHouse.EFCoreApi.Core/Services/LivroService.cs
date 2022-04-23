using DevInHouse.EFCoreApi.Core.Data.Context;
using DevInHouse.EFCoreApi.Core.Entities;
using DevInHouse.EFCoreApi.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInHouse.EFCoreApi.Core.Services
{
    public class LivroService : ILivroService
    {
        private readonly DataContext _context;

        public LivroService(DataContext context)
        {
            _context = context;
        }

        public List<Livro> ObterLivros(string titulo)
        {
            return _context.Livros
                .Include(p => p.Categoria)
                .Include(p => p.Autor)
                .Where(p => string.IsNullOrWhiteSpace(titulo) || p.Titulo.Contains(titulo))
                .ToList();
        }

        public Livro? ObterPorId(int id)
        {
            return _context.Livros
                .Include(p => p.Categoria)
                .Include(p => p.Autor)
                .FirstOrDefault(p => p.Id == id);
        }

        public int CriarLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return livro.Id;
        }

        public void AtualizarLivro(Livro livroOriginal, Livro livroAlteracoes)
        {
            livroOriginal.AlterarDados(livroAlteracoes.Titulo,
                                       livroAlteracoes.CategoriaId,
                                       livroAlteracoes.AutorId,
                                       livroAlteracoes.DataPublicacao,
                                       livroAlteracoes.Preco);
            _context.SaveChanges();
        }

        public void RemoverLivro(int id)
        {
            var livro = ObterPorId(id);
            if (livro == null)
                throw new Exception("O livro com o identificador informado não existe");

            _context.Livros.Remove(livro);
            _context.SaveChanges();
        }
    }
}