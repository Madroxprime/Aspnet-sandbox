using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceRequestTracker.Data;
using ServiceRequestTracker.Models;

namespace ServiceRequestTracker.Pages
{
    public class ItQueueModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger<ItQueueModel> _logger;
        List<ServiceRequest> Requests;

        public ItQueueModel(AppDBContext dBContext, ILogger<ItQueueModel> logger)
        {
            _dbContext = dBContext;
            _logger = logger;
        }
    }
}
