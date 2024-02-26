using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models;
public class BodyPartModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Kroppsdel är obligatorisk.")]
    public string? BodyPart { get; set; }
    public List<WorkoutModel>? Workout { get; set; }
    public List<ExerciseModel>? Exercise { get; set; }

}