using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class OrganizationModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn på metod är obligatorisk.")]
        public string? OrganizationName { get; set; }

        public List<SkiingModel>? Skiing { get; set; }
    }
}