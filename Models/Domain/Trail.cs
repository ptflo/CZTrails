namespace CZTrails.Models.Domain
{
    public class Trail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionID { get; set; }
        public Guid TrailDifficultyID { get; set; }

        //navigation properties
        public Region Region { get; set; }
        public TrailDifficulty TrailDifficulty { get; set; } //connecting to the other  domains
    }
}
