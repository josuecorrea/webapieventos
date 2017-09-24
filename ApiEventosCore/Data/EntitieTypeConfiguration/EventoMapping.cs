using ApiEventosCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEventosCore.Data.EntitieTypeConfiguration
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("EVEN_ID")
                   .IsRequired();

            builder.Property(c => c.UsuarioId)
                   .HasColumnName("EVEN_USUARIO_ID")
                   .IsRequired();

            builder.Property(c => c.Nome)
                   .HasColumnName("EVEN_NOME")
                   .HasMaxLength(60)
                   .IsRequired();

            builder.Property(c => c.DataInicio)
                   .HasColumnName("EVEN_DATA_INICIO")
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(c => c.DataFim)
                   .HasColumnName("EVEN_DATA_FIM")
                   .HasMaxLength(15)
                   .IsRequired();

            builder.Property(c => c.HoraInicio)
                   .HasColumnName("EVEN_HORA_INICIO")
                   .IsRequired();

            builder.Property(c => c.HoraFim)
                   .HasColumnName("EVEN_HORA_FIM")
                   .IsRequired();

            builder.Property(c => c.Descricao)
                   .HasColumnName("EVEN_DESCRICAO")
                   .IsRequired();

            builder.Property(c => c.Cancelado)
                   .HasColumnName("EVEN_CANCELADO");

            builder.Property(c => c.DataDeCadastro)
                   .HasColumnName("EVEN_DATA_DE_CADASTRO")
                   .IsRequired();

            builder.ToTable("EVENTO");
        }
    }
}
