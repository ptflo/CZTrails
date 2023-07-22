using CZTrails.Data;
using CZTrails.Models.Domain;
using CZTrails.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace CZTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly CZTrailsDbContext dbContext;

        public RegionsController(CZTrailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //get data from database
            var regionsDomain = dbContext.Regions.ToList();
            //map domain models to DTOs
            var regionsDto = new List<RegionDTO>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDTO()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    Spz = regionDomain.Spz
                });
            }
            //return DTOs
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //https://localhost:PORT/api/regions/{id}
        public IActionResult Get([FromRoute] Guid id)
        {
            //get region domain model from database
            var regionDomain = dbContext.Regions.Find(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //map region domain model to DTO
            var regionDto = new RegionDTO
            {
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                Spz = regionDomain.Spz
            };

            return Ok(regionDomain);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRegionRequestDTO createRegionRequestDTO) //we recieve a body from the client in the psot method
        {
            //map dto to domain model
            var regionDomainModel = new Region
            {
                Code = createRegionRequestDTO.Code,
                Name = createRegionRequestDTO.Name,
                Spz = createRegionRequestDTO.Spz
            };
            //use domain model to create region
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();
            //map domain model back to dto
            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                Spz = regionDomainModel.Spz
            };

            return CreatedAtAction(nameof(Get), new { id = regionDto.Id }, regionDto); //vraci hodnotu 201 pri uspesnem pridani - different form 200 tim, ze si v response headeru vygeneruju link kterym muzu primo pristoupit k vytvoreny polozce
            /*return: {
            "id": "2cd9d729-63a1-4219-1687-08db8aecf294",
            "code": "PHA",
            "name": "Hlavní město Praha",
            "spz": "A"
            }*/
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            //check if region exists
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomainModel == null) //0 pokud neexistuje, Guid pokud existuje
            {
                return NotFound();
            }
            //map dto to domain model
            regionDomainModel.Code = updateRegionRequestDTO.Code;
            regionDomainModel.Name = updateRegionRequestDTO.Name;
            regionDomainModel.Spz = updateRegionRequestDTO.Spz;

            dbContext.SaveChanges();
            //convert domain model to dto
            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                Spz = regionDomainModel.Spz
            };
            return Ok(regionDto); //never pass domain model,always pass DTo to client (safety, the whole reason to use DTOs)
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            //check if region exists
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }
            //delete it
            dbContext.Regions.Remove(regionDomainModel);
            dbContext.SaveChanges();

            //return deleted region (optional)
            var regionDto = new RegionDTO
            {
                //Id = regionDomainModel.Id,
                //Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                //Spz = regionDomainModel.Spz
            };

            return Ok($"Region {regionDto.Name} byl úspěšně odstraněn.");
        }
    }
}
