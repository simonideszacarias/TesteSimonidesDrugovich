using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteSimonides2.Models;

namespace TesteSimonides2.Data.Map
{
    public class GrupoClienteMap:IEntityTypeConfiguration<GrupoCliente>
    {
        public void Configure(EntityTypeBuilder<GrupoCliente> builder)
        {
            builder.HasKey(x => x.Codigo);
        }
    }
}
