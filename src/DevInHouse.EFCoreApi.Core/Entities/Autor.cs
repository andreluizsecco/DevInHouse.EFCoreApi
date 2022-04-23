namespace DevInHouse.EFCoreApi.Core.Entities
{
    public class Autor : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public ICollection<Livro> Livros { get; private set; }
    }
}