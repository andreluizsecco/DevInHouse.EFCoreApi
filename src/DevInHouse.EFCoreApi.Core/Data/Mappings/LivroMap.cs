using DevInHouse.EFCoreApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevInHouse.EFCoreApi.Core.Data.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            // Opcional, pois por convenção nossa propriedade já seria a chave primária
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.DataPublicacao)
                .HasColumnType("date");

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Autor)
                .WithMany(p => p.Livros)
                .HasForeignKey(p => p.AutorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Livros)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}