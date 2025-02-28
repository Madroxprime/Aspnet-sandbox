Welcome to ASP.NET sandbox.

YOu will need to install a couple of things to Debug and get the most of out this. 
1) Visual Studio Community 2022 - > https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&passive=false&cid=2030
2) When installing Visual Studio you need the "ASP.NET and Web development package" at the very least.
3) When you open VS for the first time, there will be an option on the upper left hand corner to start a project by cloning a repository
	Clone https://github.com/Madroxprime/Aspnet-sandbox
4) There are a couple of dependencies I'm building this off if you go to View -> Terminal and run the command 
	dotnet restore  
   VS should install them all


Starter tasks:
	1) Add a check for your username in the Pages-> Index.cshtml.cs to redirect you to DurowsDashboard.
	2) On DurowsDashboard, how do you change the LocationsIds in the Requests to the LocationNames?
	3) There is an endpoint for a RESTful API that will add a user to a location:
	  /api/v1/sandbox?userid={userid}&locationId={locationId}  
