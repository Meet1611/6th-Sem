using LeaveManagementAPI.Data;
using LeaveManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public RolesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _db.Roles.ToListAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error while fetching Roles : ", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var role = await _db.Roles.FindAsync(id);
                if (role == null)
                {
                    return NotFound(new { Message = "Role not found" });
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error while fetching Role : ", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                bool exists = await _db.Roles.AnyAsync(r => r.Name == role.Name);
                if (exists)
                {
                    return BadRequest(new { message = "Role already exists" });
                }

                _db.Roles.Add(role);
                await _db.SaveChangesAsync();

                return Created("role : ", role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error while creating Role : ", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, Role role)
        {
            try
            {
                if (id != role.Id)
                {
                    return BadRequest(new { Message = "Role ID mismatch" });
                }

                var existingRole = await _db.Roles.FindAsync(id);
                if (existingRole == null)
                {
                    return NotFound(new { Message = "Role not found" });
                }

                existingRole.Name = role.Name;
                await _db.SaveChangesAsync();

                return Ok(existingRole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error while updating Role : ", error = ex.Message });

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var role = await _db.Roles.FindAsync(id);
                if(role == null)
                {
                    return NotFound(new { Message = "Role not found" });
                }
                _db.Roles.Remove(role);
                await _db.SaveChangesAsync();
                return Ok(new { Message = "Role deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error while deleting Role : ", error = ex.Message });
            }
        }
    }
}
