namespace DevInHouse.EFCoreApi.Core.Entities
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }

        public ICollection<Livro> Livros { get; private set; }
    }
}