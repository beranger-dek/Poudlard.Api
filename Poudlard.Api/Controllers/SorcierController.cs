using Dapper;
using Microsoft.AspNetCore.Mvc;
using Poudlard.Api.Models.Dtos;
using Poudlard.Api.Models.Entities;
using Poudlard.Api.Repositories;
using System.Data.Common;

namespace Poudlard.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SorcierController : ControllerBase
    {
        private readonly SorcierRepository _repository;

        public SorcierController(SorcierRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] CreerSorcierDto dto)
        {
            try
            {
                int rows = _repository.Creer(dto);

                if (rows == 1)
                {
                    return NoContent();
                }
                return BadRequest();
                
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            var sorcier = _repository.GetById(id);

            if (sorcier is null)
            {
                return NotFound();
            }
            return Ok(sorcier);
        }
    }
}
