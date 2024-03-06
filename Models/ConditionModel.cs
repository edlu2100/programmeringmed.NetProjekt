using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class ConditionModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Konditionstyp är obligatorisk.")]
        public int? ConditionTypeId { get; set; }
        public ConditionTypeModel? ConditionType { get; set; }

        [Required(ErrorMessage = "Konditionsmetod är obligatorisk.")]
        public int? ConditionFormId { get; set; }
        public ConditionFormModel? ConditionForm { get; set; }

        // Navigation property för en-till-en-relationen med WorkoutModel
        public int? WorkoutId { get; set; }
        public WorkoutModel? Workout { get; set; }


    }
}