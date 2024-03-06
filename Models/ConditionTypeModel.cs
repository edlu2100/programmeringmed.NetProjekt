using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class ConditionTypeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn på metod är obligatorisk.")]
        public string? ConditionType { get; set; }

        public List<ConditionModel>? Condition { get; set; }
    }
}