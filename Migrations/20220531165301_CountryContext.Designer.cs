﻿// <auto-generated />
using System;
using CR_back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CR_back.Migrations
{
    [DbContext(typeof(CountryContext))]
    [Migration("20220531165301_CountryContext")]
    partial class CountryContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CR_back.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("country_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ligaID")
                        .HasColumnType("int");

                    b.HasKey("CountryID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("CR_back.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CR_back.Models.liga", b =>
                {
                    b.Property<int>("ligaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InCountryID")
                        .HasColumnType("int");

                    b.Property<string>("liga_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ligaID");

                    b.HasIndex("InCountryID")
                        .IsUnique();

                    b.ToTable("liga");
                });

            modelBuilder.Entity("CR_back.Models.player", b =>
                {
                    b.Property<int>("playerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cost")
                        .HasColumnType("int");

                    b.Property<int>("inTeamID")
                        .HasColumnType("int");

                    b.Property<string>("position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("playerID");

                    b.HasIndex("inTeamID");

                    b.ToTable("player");
                });

            modelBuilder.Entity("CR_back.Models.team", b =>
                {
                    b.Property<int>("teamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cost")
                        .HasColumnType("int");

                    b.Property<int>("liga_idliga")
                        .HasColumnType("int");

                    b.Property<string>("teamname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("teamID");

                    b.HasIndex("liga_idliga");

                    b.ToTable("team");
                });

            modelBuilder.Entity("CR_back.Models.liga", b =>
                {
                    b.HasOne("CR_back.Models.Country", "Country")
                        .WithOne("liga")
                        .HasForeignKey("CR_back.Models.liga", "InCountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CR_back.Models.player", b =>
                {
                    b.HasOne("CR_back.Models.team", "team")
                        .WithMany("player")
                        .HasForeignKey("inTeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CR_back.Models.team", b =>
                {
                    b.HasOne("CR_back.Models.liga", "liga")
                        .WithMany("team")
                        .HasForeignKey("liga_idliga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
