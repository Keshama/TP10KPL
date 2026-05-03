using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TP_MODUL10_NIM.Models;

namespace TP_MODUL10_NIM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private static List<Film> _filmList = new List<Film>
        {
            new Film { Id = 1, Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0" },
            new Film { Id = 2, Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi", Rating = "8.7" },
            new Film { Id = 3, Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6" }
        };

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _filmList;
        }

        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            var film = _filmList.FirstOrDefault(f => f.Id == id);
            if (film == null)
            {
                return NotFound("Film tidak ditemukan");
            }
            return film;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Film filmBaru)
        {
            _filmList.Add(filmBaru);
            return Ok("Film berhasil ditambahkan");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var film = _filmList.FirstOrDefault(f => f.Id == id);
            if (film == null)
            {
                return NotFound("Film tidak ditemukan");
            }

            _filmList.Remove(film);
            return Ok("Film berhasil dihapus");
        }
    }
}