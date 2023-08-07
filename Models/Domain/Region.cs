namespace CZTrails.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public char Spz { get; set; }

        //navigation property
        public  IEnumerable<Trail> Trails { get; set; } //one region can have multiple trails inside
    }
}
