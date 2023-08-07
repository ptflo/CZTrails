using System.ComponentModel.DataAnnotations;

namespace CZTrails.Models.DTO
{
    public class UpdateTrailRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Length { get; set; }
        public string? TrailImageUrl { get; set; }
        [Required]
        public Guid RegionID { get; set; }
        [Required]
        public Guid TrailDifficultyID { get; set; }
    }
}
