using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models;
public class WorkoutModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Namn på träningspass är obligatorisk.")]
    public string? WorkoutName { get; set; }
    [Required(ErrorMessage = "Beskrivning på träningspasset är obligatoriskt.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Datum för träningspass är obligatoriskt.")]
    [Display(Name = "Datum för träningspass")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? Date { get; set; }
    [Required(ErrorMessage = "Om träningspassetär avslutat är obligatoriskt")]
    public bool Completed { get; set; } = false;
    public int? BodyPartId { get; set; }
    public BodyPartModel? BodyPart { get; set; }
    public int? ExerciseFormId { get; set; }
    public ExerciseFormModel? ExerciseForm { get; set; }
    // Navigation property för relationen till ExerciseModel (många-till-många)
    public ICollection<WorkoutExerciseModel>? WorkoutExercises { get; set; }


}