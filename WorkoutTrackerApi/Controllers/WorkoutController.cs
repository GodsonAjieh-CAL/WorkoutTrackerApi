using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkoutTrackerApi.Models;
using WorkoutTrackerApi.Services;

namespace WorkoutTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutServices _workoutServices;

        public WorkoutController(IWorkoutServices workoutServices)
        {
            _workoutServices = workoutServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Workout>>> GetAll()
        {
            var result = await _workoutServices.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult?> GetById(int id)
        {
            var result = await _workoutServices.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Workout>> Create(Workout workout)
        {
            var result = await _workoutServices.CreateAsync(workout);

            return CreatedAtAction(nameof(GetById), new { id = result.Id}, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, Workout workout)
        {
            var result = await _workoutServices.UpdateAsync(id, workout);
            if(!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _workoutServices.DeleteAsync(id);
            if(result == null)
            {
                return NoContent();
            }
            return Ok();
        }

    }
}
