using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeWork38.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Configurations;

internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams")
            .HasKey(x => x.Id);

        builder.HasOne(x => x.Coach)
            .WithMany()
            .HasForeignKey(x => x.CoachId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Players)
            .WithOne(x => x.Team)
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        builder.Property(x => x.Titles)
            .HasColumnName("Titles")
            .HasColumnType("int")
            .IsRequired();
    }
}
