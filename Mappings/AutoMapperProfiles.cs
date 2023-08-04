using AutoMapper;
using CZTrails.Models.Domain;
using CZTrails.Models.DTO;

namespace CZTrails.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap(); //automapper z region(domain model) do regiondto, reversemap = moznost pozdeji mapovat i z dto do domainu, oba zdorje musi mit stejne pojmenovane promenne
            CreateMap<CreateRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();
            CreateMap<AddTrailRequestDTO, Trail>().ReverseMap();
            CreateMap<Trail, TrailDTO>().ReverseMap();
            CreateMap<TrailDifficulty, DifficultyDTO>().ReverseMap();
            CreateMap<UpdateTrailRequestDTO, Trail>().ReverseMap();
        }
    }
}
