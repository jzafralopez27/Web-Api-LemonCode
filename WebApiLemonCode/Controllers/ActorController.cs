using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebApiLemonCode.Contract;
using WebApiLemonCode.Models;

namespace WebApiLemonCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        [HttpGet]
        public ActionResult<List<Actor>> GetAll()
        {
            return _actorRepository.GetActors();
        }

        [HttpGet("{id}")]
        public ActionResult<Actor> GetbyId(int id)
        {
            var actor = _actorRepository.GetActorbyId(id);
            return actor;
        }

        [HttpPatch("{id}/{name}/{surname}")]
        public ActionResult<Actor> UpdateActor(int id, string name, string surname, [FromBody] Actor actorModificado)
        {
            Actor actorMod = _actorRepository.GetActorbyId(id);
            actorMod.Name = name;
            actorMod.Surname = surname;
            return actorMod;
        }

        [HttpDelete]
        public ActionResult<Actor> DeleteActor(int id)
        {
            return _actorRepository.DeleteActor(id);
            
            
        }
    }
}
