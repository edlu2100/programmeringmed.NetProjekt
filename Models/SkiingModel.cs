using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class SkiingModel
    {
        public int Id { get; set; }
        public string? Location { get; set; }
        public int? OrganizationId { get; set; }
        public OrganizationModel? Organization { get; set; }
        [Required(ErrorMessage = "Diciplin är obligatorisk.")]
        public int? DisciplineId { get; set; }
        public DisciplineModel? Discipline { get; set; }

        [Required(ErrorMessage = "Metod är obligatorisk.")]
        public int? MethodId { get; set; }
        public MethodModel? Method { get; set; }
        public int? FocusId { get; set; }
        public SkiingFocusModel? Focus { get; set; }
        public int? TurnsPerRun { get; set; }
        public int? GateDistance { get; set; }
        public int? Freeruns { get; set; }
        public int? Runs { get; set; }
        public int? CompletedRuns { get; set; }
        public int? ApproachToTask { get; set; }
        public string? Goal { get; set; }
        // Navigation property för en-till-en-relationen med WorkoutModel
        public int? WorkoutId { get; set; }
        public WorkoutModel? Workout { get; set; }


    }
}