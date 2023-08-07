using AutoMapper;
using CZTrails.CustomActionFilters;
using CZTrails.Data;
using CZTrails.Models.Domain;
using CZTrails.Models.DTO;
using CZTrails.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using System.Collections.Generic;

namespace CZTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly CZTrailsDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(CZTrailsDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() //async Task - asynchronous - muze bezet zaroven se zbytkem programu - efficiency
        {
            //get data from database
            var regionsDomain =await regionRepository.GetAllAsync();
            //map domain models to DTOs
            //var regionsDto = new List<RegionDTO>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDTO()
            //    {
            //        Id = regionDomain.Id,
            //        Name = regionDomain.Name,
            //        Code = regionDomain.Code,
            //        Spz = regionDomain.Spz
            //    });
            //}

            //map domain models to dtos
            var regionsDto = mapper.Map<List<RegionDTO>>(regionsDomain);

            //return DTOs
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //https://localhost:PORT/api/regions/{id}
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            //get region domain model from database
            var regionDomain = await regionRepository.GetAsync(id); //asynchronous - if db communication takes longer. the following code doesnt wait for this result
            if (regionDomain == null)
            {
                return NotFound();
            }
            //map region domain model to DTO
            //var regionDto = new RegionDTO
            //{
            //    Name = regionDomain.Name,
            //    Code = regionDomain.Code,
            //    Spz = regionDomain.Spz
            //};

            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionRequestDTO createRegionRequestDTO) //we recieve a body from the client in the psot method
        {

            if (ModelState.IsValid) //misto tohoto if-else zaobaleni lze pouzit custom validatemodel atribut, demonstrovano nasledovne
            {
                //map dto to domain model
                var regionDomainModel = mapper.Map<Region>(createRegionRequestDTO);
                //use domain model to create region

                /*await dbContext.Regions.AddAsync(regionDomainModel); //pri pokusu o async tohoto radku generuje chybovy kod 500 -> upd: uz ne
                await dbContext.SaveChangesAsync();*/
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //map domain model back to dto
                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

                return CreatedAtAction(nameof(Get), new { id = regionDto.Id }, regionDto); //vraci hodnotu 201 pri uspesnem pridani - different form 200 tim, ze si v response headeru vygeneruju link kterym muzu primo pristoupit k vytvoreny polozce
                /*return: {
                "id": "2cd9d729-63a1-4219-1687-08db8aecf294",
                "code": "PHA",
                "name": "Hlavní město Praha",
                "spz": "A"
                }*/
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            //map dto to domain model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);

            //check if region exists
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null) //0 pokud neexistuje, Guid pokud existuje
            {
                return NotFound();
            }
            //map dto to domain model
            /*regionDomainModel.Code = updateRegionRequestDTO.Code;
            regionDomainModel.Name = updateRegionRequestDTO.Name;
            regionDomainModel.Spz = updateRegionRequestDTO.Spz;

            await dbContext.SaveChangesAsync();
            //^handled by the repository now */

            //convert domain model to dto
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);
            return Ok(regionDto); //never pass domain model,always pass DTo to client (safety, the whole reason to use DTOs)
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task <IActionResult> Delete([FromRoute] Guid id)
        {
            //check if region exists
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //delete it - moved to repository
            /*dbContext.Regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync();*/

            //return deleted region (optional)
            //var regionDto = new RegionDTO
            //{
            //    //Id = regionDomainModel.Id,
            //    //Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    //Spz = regionDomainModel.Spz
            //};
            var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok($"Region {regionDto.Name} byl úspěšně odstraněn.");
        }
    }
}  
