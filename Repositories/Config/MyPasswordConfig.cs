using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class MyPasswordConfig : IEntityTypeConfiguration<MyPassword>
    {
        public void Configure(EntityTypeBuilder<MyPassword> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
