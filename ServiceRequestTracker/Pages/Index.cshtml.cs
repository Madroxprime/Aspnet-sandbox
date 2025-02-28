using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceRequestTracker.Data;
using ServiceRequestTracker.Models;

namespace ServiceRequestTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDBContext _appDBContext;

        public Location Location { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _appDBContext = appDBContext;
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.Identity.Name == "FARGO\\durows" || User.Identity.Name == "FARGO\\madrox")
                {
                    return RedirectToPage("/DurowsDashboard");
                }
                return Page();
            }
            return RedirectToPage("/NotAuthorized");
        }
    }
}
