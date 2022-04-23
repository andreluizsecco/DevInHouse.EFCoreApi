using System.Text.Json.Serialization;

namespace DevInHouse.EFCoreApi.Core.Entities
{
    public class Autor : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        [JsonIgnore]
        public ICollection<Livro> Livros { get; private set; }

        public Autor(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
    }
}