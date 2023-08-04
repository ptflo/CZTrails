using AutoMapper;
using CZTrails.Models.Domain;
using CZTrails.Models.DTO;
using CZTrails.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CZTrails.Controllers
{
    [Route("api/[controller]")] //api/trails
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITrailRepository trailRepository;

        public TrailsController(IMapper mapper, ITrailRepository trailRepository)
        {
            this.mapper = mapper;
            this.trailRepository = trailRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTrailRequestDTO addTrailRequestDTO)
        {
            //map addtrailrequest dto to trail domain model
            var trailDomainModel = mapper.Map<Trail>(addTrailRequestDTO);

            await trailRepository.CreateAsync(trailDomainModel);
            //map domain model to dto

            return Ok(mapper.Map<TrailDTO>(trailDomainModel));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trailsDomainModel = await trailRepository.GetAllAsync();
            //map domain model to dto
            return Ok(mapper.Map<List<TrailDTO>>(trailsDomainModel));
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var trailsDomainModel = await trailRepository.GetAsync(id);
            if (trailsDomainModel == null)
            {
                return NotFound();
            }
            //map domain to dto
            return Ok(mapper.Map<TrailDTO>(trailsDomainModel));
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, UpdateTrailRequestDTO updateTrailRequestDTO)
        {
            //map dto to domain
            var trailDomainModel = mapper.Map<Trail>(updateTrailRequestDTO);

            trailDomainModel = await trailRepository.UpdateAsync(id, trailDomainModel);

            if (trailDomainModel == null)
            {
                return NotFound();
            }
            //map domain to dto
            return Ok(mapper.Map<TrailDTO>(trailDomainModel));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deletedTrailDomainModel = await trailRepository.DeleteAsync(id);
            if (deletedTrailDomainModel == null)
            {
                return NotFound();
            }
            //map domain to dto
            return Ok(mapper.Map<TrailDTO>(deletedTrailDomainModel));
        }
    }
}
