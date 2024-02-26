using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using programmeringmed.NetProjekt.Models;


namespace programmeringmed.NetProjekt.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ExerciseModel> Exercise { get; set; }   
    public DbSet<WorkoutModel> Workout { get; set; }
    public DbSet<WorkoutExerciseModel> WorkoutExercise { get; set; }
    public DbSet<BodyPartModel> BodyPart { get; set; }
    public DbSet<ExerciseFormModel> ExerciseForm { get; set; }
}
