using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Controllers
{
    [ApiController]
    [Route("/albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly IMusicService _musicService;
        public AlbumsController(IMusicService musicService)
        {
            _musicService = musicService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumAsync(int id)
        {
            Console.WriteLine("In");
            var albumFull = await _musicService.GetAlbum(id);
            if (albumFull == null)
                return NotFound("Nie znaleziono albumu o id " + id);
            return Ok(albumFull);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicianAsync(int id)
        {
            var result = await _musicService.DeleteMusician(id);
            switch (result)
            {
                case -1: return BadRequest("Nie można usunąć muzyka - jego utwory są na albumach");
                case -2: return NotFound($"Nie ma muzyka o id {id}");
                case -3: return BadRequest("Wystąpił błąd i nie udało się usunąć muzyka");
                default: return Ok("Usunięto muzyka");
            }
        }
    }
}
