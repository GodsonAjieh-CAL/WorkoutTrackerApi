using WorkoutTrackerApi.Models;

namespace WorkoutTrackerApi.Services
{
    public interface IWorkoutServices
    {
        Task<List<Workout>> GetAllAsync();
        Task<Workout?> GetByIdAsync(int id);
        Task<Workout> CreateAsync(Workout workout);
        Task<bool> UpdateAsync(int id, Workout workout);
        Task<bool> DeleteAsync(int id);
    }
}
