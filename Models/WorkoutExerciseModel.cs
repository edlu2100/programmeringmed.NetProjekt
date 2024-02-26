using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace programmeringmed.NetProjekt.Models
{
    public class WorkoutExerciseModel
    {
        public int Id { get; set; }
        public int? WorkoutId { get; set; }
        public WorkoutModel? Workout { get; set; }
        public int? ExerciseId { get; set; }
        public ExerciseModel? Exercise { get; set; }
    }
}