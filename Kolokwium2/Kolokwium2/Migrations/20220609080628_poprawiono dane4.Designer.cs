﻿// <auto-generated />
using System;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(MasterDbContext))]
    [Migration("20220609080628_poprawiono dane4")]
    partial class poprawionodane4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kolokwium2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .HasColumnType("int");

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublishDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Mroczne dni",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("Labels");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "Black"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musicians");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "Krzysztof",
                            LastName = "Bolec",
                            Nickname = "Ból"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Karolina",
                            LastName = "Różycka",
                            Nickname = "Róża"
                        },
                        new
                        {
                            IdMusician = 3,
                            FirstName = "Adam",
                            LastName = "Josełka"
                        },
                        new
                        {
                            IdMusician = 4,
                            FirstName = "Adam",
                            LastName = "Josełka"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.HasKey("IdTrack", "IdMusician");

                    b.HasIndex("IdMusician");

                    b.ToTable("Musician_Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 1,
                            IdMusician = 2
                        },
                        new
                        {
                            IdTrack = 2,
                            IdMusician = 2
                        },
                        new
                        {
                            IdTrack = 3,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 4,
                            IdMusician = 4
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 330f,
                            IdMusicAlbum = 1,
                            TrackName = "Róże"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 425f,
                            IdMusicAlbum = 1,
                            TrackName = "Kwiaty wojny"
                        },
                        new
                        {
                            IdTrack = 3,
                            Duration = 255f,
                            IdMusicAlbum = 1,
                            TrackName = "Ostatni raz"
                        },
                        new
                        {
                            IdTrack = 4,
                            Duration = 115f,
                            TrackName = "Work in progress"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Album", b =>
                {
                    b.HasOne("Kolokwium2.Models.MusicLabel", "Label")
                        .WithMany("Albums")
                        .HasForeignKey("IdAlbum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Label");
                });

            modelBuilder.Entity("Kolokwium2.Models.Musician_Track", b =>
                {
                    b.HasOne("Kolokwium2.Models.Musician", "Musician")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Track", "Track")
                        .WithMany("Musicians")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Kolokwium2.Models.Track", b =>
                {
                    b.HasOne("Kolokwium2.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Kolokwium2.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Kolokwium2.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("Kolokwium2.Models.Musician", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Kolokwium2.Models.Track", b =>
                {
                    b.Navigation("Musicians");
                });
#pragma warning restore 612, 618
        }
    }
}
