using DevInHouse.EFCoreApi.Core.Entities;

namespace DevInHouse.EFCoreApi.Core.Interfaces
{
    public interface ILivroService
    {
        public List<Livro> ObterLivros(string titulo);

        public Livro? ObterPorId(int id);

        public int CriarLivro(Livro livro);

        public void AtualizarLivro(Livro livroOriginal, Livro livroAlteracoes);

        public void RemoverLivro(int id);
    }
}