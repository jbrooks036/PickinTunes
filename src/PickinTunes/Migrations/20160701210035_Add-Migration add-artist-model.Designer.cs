using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PickinTunes.Models;

namespace PickinTunes.Migrations
{
    [DbContext(typeof(PickinTunesContext))]
    [Migration("20160701210035_Add-Migration add-artist-model")]
    partial class AddMigrationaddartistmodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PickinTunes.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistName");

                    b.Property<int?>("TuneId");

                    b.HasKey("ArtistId");

                    b.HasIndex("TuneId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("PickinTunes.Models.Tune", b =>
                {
                    b.Property<int>("TuneId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TuneTitle");

                    b.HasKey("TuneId");

                    b.ToTable("Tune");
                });

            modelBuilder.Entity("PickinTunes.Models.Artist", b =>
                {
                    b.HasOne("PickinTunes.Models.Tune")
                        .WithMany()
                        .HasForeignKey("TuneId");
                });
        }
    }
}
