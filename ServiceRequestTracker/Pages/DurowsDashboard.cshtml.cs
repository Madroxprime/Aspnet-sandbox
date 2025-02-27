using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceRequestTracker.Data;
using ServiceRequestTracker.Models;

namespace ServiceRequestTracker.Pages
{
    [Authorize]
    public class DurowsDashboardModel : PageModel
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger<DurowsDashboardModel> _logger;

        public List<User> Users { get; set; }
        public List<Location> Locations { get; set; }
        public List<ServiceRequest> EagerRequests { get;set;}

        /*
         * So the general idea of division of code / single responsiblilty principle is
         * we want each peice of code in charge of doing a single thing 
         * ( If you are literal minded like I am I would like to warn you that "single" here is very misleading )  
         * Our View accepts the Model data, constructs the page, and manages user response.
         * Our view model here does server side stuff, prepping data,sanatizing it for the user, and validating their input
         */
        public DurowsDashboardModel(AppDBContext context, ILogger<DurowsDashboardModel> logger)
        {
            _dbContext = context;
            _logger = logger;
        }

        /*  
         *  Wanted to leave a note here about this method signature.
         *  Public is the access level, we talked about this last night.
         *  "async" is a method that tells the program that this might take a while.
         *  It doesn't return the immediate return item, but returns a Task<T> (<T> here means any arbitary type), 
         *  which is like an IOU<T>. 
         *  
         *  Async methods will have an "await" key word in them, to let everyone know what data it's waiting on before
         *  it pays off the Task.
         */
        public async Task<IActionResult> OnGetAsync()
        {
            // This is how you'd make database calls asyncronously, but sqlite doesn't support async operations
            //Users = await _dbContext.Users.ToListAsync();
            Users = _dbContext.Users.ToList();

            // This will simply query the resource from the context, and return a List<T> of all the resources of <T>
            // A List is very similiar to an Array but it's got some overhead for using Linq commands.

            Locations = _dbContext.Locations.ToList();

            // This will "eagerly" load all the related objects we specify to each Request by using those previously mentioned Linq commands.
            // This is one of the areas where the explicit static typeing of c# comes in handy.   Since we know with certainty that every 
            // element of <T> all have the same properties, we don't have to wait for parsing to validate the members and fields of what
            // a variable might hold.  

            EagerRequests = _dbContext.Requests
                .Include(r => r.Requester)
                .ThenInclude(u => u.Locations)
                .ToList();
            /*
             *  Since we have said that a Request has a User called Requester, we can tell the context grab the User object and "inflate" it
             *  with all it's data from the database and include it.  
             *  It doesn't grab all of the extended related Classes by default because that can get pretty heavy, 
             *  so the design philosophy is include the smallest amount required.
             *  
             *  If you find yourself doing a lot of lengthy linq commands, you can create extension methods to encapsulate it.
             *  
             */

            return Page();
        }

    }
}
