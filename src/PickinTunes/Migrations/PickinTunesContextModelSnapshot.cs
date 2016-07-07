using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PickinTunes.Models;

namespace PickinTunes.Migrations
{
    [DbContext(typeof(PickinTunesContext))]
    partial class PickinTunesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PickinTunes.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistName");

                    b.HasKey("ArtistId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("PickinTunes.Models.Tune", b =>
                {
                    b.Property<int>("TuneId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistId");

                    b.Property<string>("TuneTitle");

                    b.HasKey("TuneId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Tune");
                });

            modelBuilder.Entity("PickinTunes.Models.Tune", b =>
                {
                    b.HasOne("PickinTunes.Models.Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
