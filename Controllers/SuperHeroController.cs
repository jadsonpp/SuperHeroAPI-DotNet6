using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services;
namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public SuperHeroService HeroService;

        public SuperHeroController(SuperHeroService HeroService)
        {
            this.HeroService = HeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await HeroService.Get());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await HeroService.Get(id);
            if(hero == null)
            {
                return NotFound("Hero not found.");
            }
            
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {
            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }

            var hero2 = await HeroService.AddHero(hero);

            return Ok(hero2);
        }
        
        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = await HeroService.Get(request.Id);
            
            if (hero == null)
            {
                return NotFound("Hero not found.");
            }

            var dbHero = await HeroService.UpdateHero(request);


            return Ok(dbHero);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = await HeroService.Get(id);

            if (hero == null)
            {
                return NotFound("Hero not found.");
            }

            var dbHero = await HeroService.DeleteHero(id);

            return Ok(dbHero);
        }
    }
}
