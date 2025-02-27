using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRequestTracker.Data;

namespace ServiceRequestTracker.Controller
{
    public class SandboxController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger<SandboxController> _logger;
        public SandboxController(AppDBContext dBContext, ILogger<SandboxController> logger)
        {
            _logger = logger;
            _dbContext = dBContext;

            _logger.LogInformation("This is an example of using the log.");
        }
        [HttpGet]
        public async Task<IActionResult> AddLocationToUser([FromQuery]int UserId, [FromQuery]int LocationId)
        {
            var user = await _dbContext.Users
                .Include(u => u.Locations)
                .FirstOrDefaultAsync(u => u.UserId == UserId);

            var location = await _dbContext.Locations.FindAsync(LocationId);

            if(user == null || location == null)
            {
                return NotFound(new { Message = "User or location not found." });
            }

            if (!user.Locations.Contains(location))
            {
                user.Locations.Add(location);
                await _dbContext.SaveChangesAsync();
            }

            return Ok(new { Message = "Location is in User records", UserId, LocationId });
        }
    }
}
