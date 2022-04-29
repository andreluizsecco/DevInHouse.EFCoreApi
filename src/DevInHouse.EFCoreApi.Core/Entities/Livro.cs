namespace DevInHouse.EFCoreApi.Core.Entities
{
    public class Livro : Entity
    {
        public string Titulo { get; private set; }
        public int CategoriaId { get; private set; }
        public int AutorId { get; private set; }
        public DateTime DataPublicacao { get; private set; }
        public decimal Preco { get; private set; }

        public Categoria? Categoria { get; private set; }
        public Autor? Autor { get; private set; }

        public Livro(string titulo, int categoriaId, int autorId, DateTime dataPublicacao, decimal preco)
        {
            Titulo = titulo;
            CategoriaId = categoriaId;
            AutorId = autorId;
            DataPublicacao = dataPublicacao;
            Preco = preco;
        }

        public void AlterarDados(string titulo, int categoriaId, int autorId, DateTime dataPublicacao, decimal preco)
        {
            Titulo = titulo;
            CategoriaId = categoriaId;
            AutorId = autorId;
            DataPublicacao = dataPublicacao;
            Preco = preco;
        }

        public void AlterarPrecoLivro(decimal preco)
        {
            Preco = preco;
        }
    }
}