using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class MasterDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> Labels { get; set; }

        public MasterDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Musician>(m =>
            {
                m.HasKey(e => e.IdMusician);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.Nickname).HasMaxLength(20);

                m.HasData(new Musician
                {
                    IdMusician = 1,
                    FirstName = "Krzysztof",
                    LastName = "Bolec",
                    Nickname = "Ból"
                }, new Musician
                {
                    IdMusician = 2,
                    FirstName = "Karolina",
                    LastName = "Różycka",
                    Nickname = "Róża"
                }, new Musician
                {
                    IdMusician = 3,
                    FirstName = "Adam",
                    LastName = "Josełka",
                }, new Musician
                {
                    IdMusician = 4,
                    FirstName = "Adam",
                    LastName = "Wierzbicki",
                });
            });
            builder.Entity<MusicLabel>(m =>
            {
                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name).IsRequired().HasMaxLength(50);

                m.HasData(new MusicLabel
                {
                    IdMusicLabel = 1,
                    Name = "Black"
                });
            });
            builder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate).IsRequired();

                a.HasOne(e => e.Label).WithMany(e => e.Albums).HasForeignKey(e => e.IdAlbum);

                a.HasData(new Album
                {
                    IdAlbum = 1,
                    AlbumName = "Mroczne dni",
                    PublishDate = DateTime.Parse("2022-06-09"),
                    IdMusicLabel = 1
                });
            });
            builder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();

                t.HasOne(t => t.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);

                t.HasData(new Track
                {
                    IdTrack = 1,
                    TrackName = "Róże",
                    Duration = 3_30,
                    IdMusicAlbum = 1
                }, new Track
                {
                    IdTrack = 2,
                    TrackName = "Kwiaty wojny",
                    Duration = 04_25,
                    IdMusicAlbum = 1
                }, new Track
                {
                    IdTrack = 3,
                    TrackName = "Ostatni raz",
                    Duration = 2_55,
                    IdMusicAlbum = 1
                }, new Track
                {
                    IdTrack = 4,
                    TrackName = "Work in progress",
                    Duration = 1_15,
                });
            });
            builder.Entity<Musician_Track>(m =>
            {
                m.HasKey(e => new { e.IdTrack, e.IdMusician });

                m.HasOne(e => e.Track).WithMany(e => e.Musicians).HasForeignKey(e => e.IdTrack);
                m.HasOne(e => e.Musician).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusician);

                m.HasData(new Musician_Track
                {
                    IdTrack = 1,
                    IdMusician = 1
                }, new Musician_Track
                {
                    IdTrack = 1,
                    IdMusician = 2
                }, new Musician_Track
                {
                    IdTrack = 2,
                    IdMusician = 2
                }, new Musician_Track
                {
                    IdTrack = 3,
                    IdMusician = 1
                }, new Musician_Track
                {
                    IdTrack = 4,
                    IdMusician = 4
                });
            });
        }
    }
}
