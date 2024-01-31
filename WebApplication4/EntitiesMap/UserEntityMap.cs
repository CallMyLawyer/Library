using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication4.Entities;

namespace WebApplication4.EntitiesMap;

public class UserEntityMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.Email).HasMaxLength(30).HasColumnType("varchar").IsRequired();
    }
}