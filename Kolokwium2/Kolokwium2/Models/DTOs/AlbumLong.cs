using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models.DTOs
{
    public class AlbumLong
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime? PublishDate { get; set; }
        public string Label { get; set; }
        public IEnumerable<TrackShort> Tracks { get; set; }
    }
}
