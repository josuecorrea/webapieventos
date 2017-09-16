using ApiEventosCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEventosCore.Data.EntitieTypeConfiguration
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("USUA_ID")
                   .IsRequired();

            builder.Property(c => c.Nome)
                   .HasColumnName("USUA_NOME")
                   .HasMaxLength(60)
                   .IsRequired();

            builder.Property(c => c.UserName)
                   .HasColumnName("USUA_USER_NAME")
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(c => c.Senha)
                   .HasColumnName("USUA_SENHA")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(c => c.Email)
                   .HasColumnName("USUA_EMAIL")
                   .HasMaxLength(60)
                   .IsRequired();


            builder.Property(c => c.DataCadastro)
                   .HasColumnName("USUA_DATACADASTRO")
                   .IsRequired();

            builder.ToTable("USUARIO");
        }
    }
}
