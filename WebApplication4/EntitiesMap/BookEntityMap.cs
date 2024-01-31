using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication4.Entities;

namespace WebApplication4.EntitiesMap;

public class BookEntityMap : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.PrintYear).HasMaxLength(4);
        builder.Property(_ => _.Category).HasMaxLength(50);
        builder.Property(_ => _.Author).HasMaxLength(50).IsRequired();
    }
}