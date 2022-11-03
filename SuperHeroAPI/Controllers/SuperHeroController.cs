using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //(comentário apenas estético)para retornar valores no conteudo da Task no swagger é necessário colocar <List<SuperHero>>
        //para retornar valor é ir no swagger, na task superhero, click no try it out, execute e vualah
        private static List<SuperHero> heroes = new List<SuperHero>
        {
                new SuperHero {
                    Id = 1,
                    Name = "Hulk",
                    FirstName = "Bruce",
                    LastName="Banner",
                    Place="Rio de Janeiro City"
                },
                new SuperHero {
                    Id = 2,
                    Name = "IronMan",
                    FirstName = "Tony",
                    LastName="Stark",
                    Place="Los Angeles City"
                },
                new SuperHero {
                    Id = 3,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName="Parker",
                    Place="New York City"
                }
        };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            //retorno no método heroes de héroi não encotrado(404)
            //return NotFound(heroes);
            return Ok(heroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if(hero == null){
                return BadRequest("Hero not found.");
            }
            else {
                return Ok(hero);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
    }
}
