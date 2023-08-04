namespace CZTrails.Models.DTO
{
    public class AddTrailRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public string? TrailImageUrl { get; set; }
        public Guid RegionID { get; set; }
        public Guid TrailDifficultyID { get; set; }
    }
}
