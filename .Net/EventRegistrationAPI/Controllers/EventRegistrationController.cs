using EventRegistrationAPI.Data;
using EventRegistrationAPI.DTOs;
using EventRegistrationAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRegistrationController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EventRegistrationController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var registrations = _db.EventRegistrations.ToList();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registration = await _db.EventRegistrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            return Ok(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventRegistrationDto dto)
        {
            var entity = new EventRegistration
            {
                ParticipantName = dto.ParticipantName,
                Email = dto.Email,
                EventName = dto.EventName,
                Age = dto.Age,
                RegistrationDate = DateTime.UtcNow
            };

            _db.EventRegistrations.Add(entity);
            await _db.SaveChangesAsync();   
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEventRegistrationDto dto)
        {
            var registration = await _db.EventRegistrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            registration.ParticipantName = dto.ParticipantName;
            registration.Email = dto.Email;
            registration.EventName = dto.EventName;
            registration.Age = dto.Age;
            await _db.SaveChangesAsync();
            return Ok(registration);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registration = await _db.EventRegistrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            _db.EventRegistrations.Remove(registration);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
