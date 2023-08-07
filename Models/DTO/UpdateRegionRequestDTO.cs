using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CZTrails.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Kód musí obsahovat 3 písmena")]
        [MaxLength(3, ErrorMessage = "Kód musí obsahovat 3 písmena")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maximální počet znaků je 100")]
        public string Name { get; set; }
        [Required]
        //[MinLength(1, ErrorMessage = "SPZ musí obsahovat pouze 1 znak")] -- limit nefunguje na pozadavek typu char
        //[MaxLength(1, ErrorMessage = "SPZ musí obsahovat pouze 1 znak")]
        public char Spz { get; set; }
    }
}
