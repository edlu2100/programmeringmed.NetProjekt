using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models;
public class WorkoutModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Beskrivning på träningspasset är obligatoriskt.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Datum för träningspass är obligatoriskt.")]
    [Display(Name = "Datum för träningspass")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? Date { get; set; }
    [Required(ErrorMessage = "Om träningspassetär avslutat är obligatoriskt")]
    public bool Completed { get; set; } = false;
    public string? Comment { get; set; }
    [Range(1, 5, ErrorMessage = "Rating måste vara mellan 1 och 5.")]
    public int? Rating { get; set; }
    public int? Length { get; set; }
    public string? Username { get; set; }
    public int? BodyPartId { get; set; }
    public BodyPartModel? BodyPart { get; set; }
    public int? ExerciseFormId { get; set; }
    public ExerciseFormModel? ExerciseForm { get; set; }
    // Navigation property för relationen till ExerciseModel (många-till-många)
    public ICollection<WorkoutExerciseModel>? WorkoutExercises { get; set; }

    // Navigation property för en-till-en-relationen med SkiingModel
    public int? SkiingId { get; set; }
    public SkiingModel? Skiing { get; set; }

        // Navigation property för en-till-en-relationen med SkiingModel
    public int? ConditionId { get; set; }
    public ConditionModel? Condition { get; set; }


}