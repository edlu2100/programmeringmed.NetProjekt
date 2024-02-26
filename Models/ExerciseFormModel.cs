using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models;
public class ExerciseFormModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Träningstyp är obligatorisk.")]
    public string? ExerciseForm { get; set; }
    public List<WorkoutModel>? Workout { get; set; }


}