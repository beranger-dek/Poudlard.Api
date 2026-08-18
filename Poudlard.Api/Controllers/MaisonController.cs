using Microsoft.AspNetCore.Mvc;
using Poudlard.Api.Models.Entities;
using Poudlard.Api.Repositories;


namespace Poudlard.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MaisonController : ControllerBase
    {
        private readonly MaisonRepository _maisonRepository;
        private readonly SorcierRepository _sorcierRepository;

        public MaisonController(MaisonRepository maisonRepository, SorcierRepository sorcierRepository)
        {
            _maisonRepository = maisonRepository;
            _sorcierRepository = sorcierRepository;
        }

        [HttpGet]
        public ActionResult<List<Maison>> GetAll()
        {
            return Ok(_maisonRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Maison> GetById(Guid id)
        {
            var maison = _maisonRepository.GetById(id);

            if (maison is null)
            {
                return NotFound();
            }

            return Ok(maison);
        }
        [HttpGet("{id}/Sorciers")]
        public ActionResult<List<Sorcier>> GetAllSorciers(Guid id)
        {
            var maison = _maisonRepository.GetById(id);
            if (maison is null)
            {
                return NotFound();
            }

            return Ok(_sorcierRepository.GetAllByMaisonId(id));
        }
    }
}
