using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class SkiingFocusModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn på focusområde är obligatorisk.")]
        public string? FocusName { get; set; }
        public List<SkiingModel>? Skiing { get; set; }
    }

}