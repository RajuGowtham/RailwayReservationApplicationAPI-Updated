using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Railway_Reservation_API_Project.Interfaces;
using Railway_Reservation_API_Project.Models;
using Railway_Reservation_API_Project.Services;

namespace Railway_Reservation_API_Project.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PassengerController : ControllerBase
        {
            private readonly IPassengerService _service;

            public PassengerController(IPassengerService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllPassengers()
            {
                var passengers = await _service.GetAllPassengersAsync();
                return Ok(passengers);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var passenger = await _service.GetPassengerByIdAsync(id);
                if (passenger == null) return NotFound();
                return Ok(passenger);
            }

            [HttpPost]
            [Authorize(Roles = "User, Admin")]
            public async Task<IActionResult> Create([FromBody] Passenger passenger)
            {
                var created = await _service.CreatePassengerAsync(passenger);
                return CreatedAtAction(nameof(GetById), new { id = created.PassengerId }, created);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] Passenger passenger)
            {
                if (id != passenger.PassengerId) return BadRequest();

                var updated = await _service.UpdatePassengerAsync(passenger);
                if (updated == null) return NotFound();
                return Ok(updated);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var deleted = await _service.DeletePassengerAsync(id);
                if (!deleted) return NotFound();

                return NoContent();
            }


        // additional operations

        [HttpGet("search")]
        public async Task<IActionResult> Search(string name)
        {
            var result = await _service.SearchPassengersAsync(name);
            return Ok(result);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter(int minAge, int maxAge)
        {
            var result = await _service.FilterPassengersByAgeAsync(minAge, maxAge);
            return Ok(result);
        }

        [HttpGet("sort")]
        public async Task<IActionResult> Sort(bool ascending = true)
        {
            var result = await _service.SortPassengersByNameAsync(ascending);
            return Ok(result);
        }


    }
}
