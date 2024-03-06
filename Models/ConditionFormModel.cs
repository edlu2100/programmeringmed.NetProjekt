using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class ConditionFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn på metod är obligatorisk.")]
        public string? ConditionName { get; set; }

        public List<ConditionModel>? Condition { get; set; }
    }
}