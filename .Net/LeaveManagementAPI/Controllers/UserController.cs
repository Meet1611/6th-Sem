using LeaveManagementAPI.Data;
using LeaveManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LeaveManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UserController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _db.Users
                    .Select(u => new
                    {
                        u.Id,
                        u.Name,
                        u.Email,
                        Role = u.Role.Name
                    })
                    .ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error while fetching Users : ", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _db.Users
                    .Where(u => u.Id == id)
                    .Select(u => new
                    {
                        u.Id,
                        u.Name,
                        u.Email,
                        Role = u.Role.Name
                    })
                    .ToListAsync();
                if(user == null)
                {
                    return BadRequest(new { message = "User not found" });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error while fetching Users : ", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 6)
                {
                    return BadRequest(new { message = "Password must be at least 6 characters" });
                }

                bool exists = await _db.Users.AnyAsync(u => u.Email == user.Email);
                if(exists == null)
                {
                    return BadRequest(new { message = "Email already registered" });
                }

                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                return Created("", new { user.Id, user.Name, user.Email });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error while creating User : ", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            try
            {
                var exists = await _db.Users.FindAsync(id);
                if (exists == null)
                    return NotFound(new { message = "User not found" });

                exists.Name = user.Name;
                exists.Email = user.Email;
                exists.Password = user.Password;
                exists.RoleId = user.RoleId;

                await _db.SaveChangesAsync();
                return Ok(new { message = "User updated successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating user", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);   
                if(user == null)
                {
                    return NotFound(new { message = "User not found" });
                }

                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
                return Ok(new { message = "User deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting user", error = ex.Message });

            }
        }
    }
}
