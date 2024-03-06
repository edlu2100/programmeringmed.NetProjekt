using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class MethodModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn på metod är obligatorisk.")]
        public string? MethodName { get; set; }

        public List<SkiingModel>? Skiing { get; set; }
    }
}