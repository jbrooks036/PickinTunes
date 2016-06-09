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

            modelBuilder.Entity("PickinTunes.Models.Tune", b =>
                {
                    b.Property<int>("TuneId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TuneTitle");

                    b.HasKey("TuneId");

                    b.ToTable("Tune");
                });
        }
    }
}
