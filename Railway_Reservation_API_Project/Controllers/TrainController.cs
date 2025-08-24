using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;

namespace Railway_Reservation_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _service;

        public TrainController(ITrainService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Train>>> GetTrains()
        {
            var trains = await _service.GetAllTrainsAsync();
            return Ok(trains);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Train>> GetTrain(int id)
        {
            var train = await _service.GetTrainByIdAsync(id);
            if (train == null)
                return NotFound();
            return Ok(train);
        }

        [HttpPost]
        public async Task<ActionResult<Train>> PostTrain(Train train)
        {
            var newTrain = await _service.AddTrainAsync(train);
            return CreatedAtAction(nameof(GetTrain), new { id = newTrain.TrainId }, newTrain);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrain(int id, Train train)
        {
            try
            {
                await _service.UpdateTrainAsync(id, train);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            try
            {
                await _service.DeleteTrainAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
