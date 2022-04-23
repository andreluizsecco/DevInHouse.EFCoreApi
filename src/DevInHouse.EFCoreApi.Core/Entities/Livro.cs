namespace DevInHouse.EFCoreApi.Core.Entities
{
    public class Livro : Entity
    {
        public string Titulo { get; private set; }
        public int CategoriaId { get; set; }
        public int AutorId { get; set; }
        public DateTime DataPublicacao { get; private set; }
        public decimal Preco { get; private set; }

        public Categoria Categoria { get; private set; }
        public Autor Autor { get; private set; }
    }
}