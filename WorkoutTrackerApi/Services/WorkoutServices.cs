using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WorkoutTrackerApi.Data;
using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Services
{
    public class WorkoutServices : IWorkoutServices
    {
        private readonly AppDbContext _context;

        public WorkoutServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetAllAsync()
        {
            var result = await _context.Workouts.ToListAsync();

            return result;
        }

        public async Task<Workout?> GetByIdAsync(int id)
        {
            var findWorkout = await _context.Workouts.FindAsync(id);

            if(findWorkout == null)
            {
                return null;
            }
            return findWorkout;
        }

        public async Task<Workout> CreateAsync(Workout workout)
        {
            workout.Id = 0;
            workout.TimePeriod = DateTime.UtcNow;
            _context.Add(workout);
            await _context.SaveChangesAsync();

            return workout;
        }

        public async Task<bool> UpdateAsync(int id, Workout workout)
        {
            var findWorkout = await _context.Workouts.FindAsync(id);
            if(findWorkout == null)
            {
                return false;
            }
            findWorkout.Name = workout.Name;
            findWorkout.Reps = workout.Reps;
            findWorkout.TimePeriod = workout.TimePeriod;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var findWorkout = await _context.Workouts.FindAsync(id);
            if(findWorkout == null)
            {
                return false;
            }
            _context.Remove(findWorkout);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
