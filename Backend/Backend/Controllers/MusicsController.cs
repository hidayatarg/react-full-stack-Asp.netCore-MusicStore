using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DataAccess.Abstruct;
using Backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class MusicsController : Controller
    {
        private IMusicDal _musicDal;
        // Dependency Injection
        public MusicsController(IMusicDal musicDal)
        {
            _musicDal = musicDal;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var musics =  _musicDal.GetList();
            return Ok(musics);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var music = _musicDal.Get(m => m.Id == id);
            if(music == null)
            {
                return NotFound($"There is no Music with Id {id}");
            }
            return Ok(music);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Music music)
        {
            _musicDal.Add(music);
            return new StatusCodeResult(201);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Music music)
        {
            _musicDal.Update(music);
            return Ok(music);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _musicDal.Delete(new Music { Id = id });
            return Ok();
        }
    }
}
