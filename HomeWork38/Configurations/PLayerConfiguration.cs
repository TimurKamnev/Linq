using HomeWork38.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork38.Configurations
{
    public class PLayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players")
                .HasKey(x => x.Id);

            builder.HasOne(x => x.Coach)
                .WithMany()
                .HasForeignKey(x => x.CoachId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Team)
            .WithMany()
            .HasForeignKey(x => x.TeamId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.CoachId)
                .HasColumnName("coach_id")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(x => x.FullName)
                .HasColumnName("FullName")
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Number)
                .HasColumnName("JorseyNumber")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Age)
                .HasColumnName("Age")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.BirthOfDate)
                .HasColumnName("DateOfBirth")
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
