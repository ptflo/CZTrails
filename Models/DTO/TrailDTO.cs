namespace CZTrails.Models.DTO
{
    public class TrailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public string? TrailImageUrl { get; set; }

        public RegionDTO region { get; set; }
        public DifficultyDTO difficulty { get; set; }
    }
}
