﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime? PublishDate { get; set; }
        public int IdMusicLabel { get; set; }

        public virtual MusicLabel Label { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
