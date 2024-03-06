using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class DisciplineModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn på disciplin är obligatorisk.")]
        public string? DisciplineName { get; set; }
        public List<SkiingModel>? Skiing { get; set; }
    }

}