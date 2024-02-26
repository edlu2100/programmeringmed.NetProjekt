using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models;
public class ExerciseModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Övningens namn är obligatorisk.")]
    public string? ExerciseName { get; set; }
    [Required(ErrorMessage = "Beskrivning är obligatorisk.")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "URL är obligatorisk.")]
    [Url]
    public string? VideoUrl { get; set; }
    // Navigation property för relationen till WorkoutModel (många-till-många)
    public int? BodyPartId { get; set; }
    public BodyPartModel? BodyPart { get; set; }
    public ICollection<WorkoutExerciseModel>? WorkoutExercises { get; set; }


}
