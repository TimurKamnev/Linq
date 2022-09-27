using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeWork38.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Configurations
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.ToTable("Coaches")
                .HasKey(x => x.Id);

            builder.HasOne(x => x.Team)
                .WithOne(x => x.Coach)
                .HasForeignKey<Team>(x => x.CoachId)
                .IsRequired();

            builder.HasMany(x => x.Players)
                .WithOne(x => x.Coach)
                .HasForeignKey(x => x.CoachId)
                .IsRequired();

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.Age)
                .HasColumnName("Age")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Standing)
                .HasColumnName("Standing")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
