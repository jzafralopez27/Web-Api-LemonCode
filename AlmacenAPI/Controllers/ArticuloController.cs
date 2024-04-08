using AlmacenAPI.Contracts;
using AlmacenAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloRepository _articuloRepository;
        public ArticuloController(IArticuloRepository actorRepository)
        {
            _articuloRepository = actorRepository;
        }

        [HttpPost]
        public ActionResult<List<Articulo>> AddArticulo (Articulo a)
        {
           return _articuloRepository.AddArticulo(a);
        }

        [HttpPatch("in/{id}/{cantidad}")]
        public ActionResult<List<Articulo>> ArticuloIn(int id, int cantidad)
        {

            try
            {
                var articuloMod = _articuloRepository.ArticuloIn(id, cantidad);
                return articuloMod;
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("out/{id}/{cantidad}")]
        public ActionResult<List<Articulo>> ArticuloOut(int id, int cantidad)
        {
            try
            {
                var articuloMod = _articuloRepository.ArticuloOut(id, cantidad);
                return articuloMod;
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
