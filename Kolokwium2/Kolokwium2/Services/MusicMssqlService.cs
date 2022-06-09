using Kolokwium2.Models;
using Kolokwium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Services
{
    public class MusicMssqlService : IMusicService
    {
        private readonly MasterDbContext _context;
        public MusicMssqlService(MasterDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteMusician(int id)
        {
            var musician = await _context.Musicians.Where(e => e.IdMusician == id).ToListAsync();
            if (musician.Count == 0)
                return -2;
            var musicianTracks = await _context.Tracks.Include(e => e.Musicians).Where(e => e.Musicians.Select(m => m.IdMusician).Contains(id)).Where(e => e.IdMusicAlbum != 0).ToListAsync();
            if (musicianTracks.Count != 0)
                return -1;

            var tracksToDelete = await _context.Tracks.Include(e => e.Musicians).Where(e => e.Musicians.Select(m => m.IdMusician).Contains(id)).Where(e => e.IdMusicAlbum == 0).ToListAsync();
            using (var tran = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    tracksToDelete.ForEach(e => _context.Tracks.Remove(e));
                    await _context.SaveChangesAsync();
                    _context.Musicians.Remove(musician.First());
                    await _context.SaveChangesAsync();
                    await tran.CommitAsync();
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    return -3;
                }
            }
            return 0;
        }

        public async Task<AlbumLong> GetAlbum(int id)
        {
            var isAlbum = await _context.Albums.Where(e => e.IdAlbum == id).ToListAsync();
            if (isAlbum.Count == 0)
                return null;
            var album = await _context.Albums.Where(e => e.IdAlbum == id).Include(e => e.Label).Include(e => e.Tracks).Select(a =>
                new AlbumLong
                {
                    IdAlbum = a.IdAlbum,
                    AlbumName = a.AlbumName,
                    PublishDate = a.PublishDate,
                    Label = a.Label.Name,
                    Tracks = a.Tracks.Select(e => new TrackShort
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.TrackName,
                        Duration = e.Duration,
                    }).OrderBy(e => e.Duration).ToList()
                }).FirstAsync();
            return album;
        }
    }
}
