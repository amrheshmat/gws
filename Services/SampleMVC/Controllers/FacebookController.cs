using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using Newtonsoft.Json;
using MWS.Business.Shared;

namespace SampleMVC.Controllers
{
    public class FacebookController : Controller
    {
        private IRepository _repo;
		private readonly IConfiguration _config;
		private IFacebookTokenService _facebookTokenService;
		public FacebookController(IConfiguration config, IRepositoryFactory repo,IFacebookTokenService facebookTokenService)
        {
            _config = config;
			_repo = repo.Create("AGGRDB");
			_facebookTokenService = facebookTokenService;
		}
		//public IActionResult Index()
		//{
			
		//	return Redirect("https://www.facebook.com/v17.0/dialog/oauth?client_id=290171780857940&redirect_uri=https://localhost:7254/accessCode&scope=publish_pages");
		//}
		//[Route("accessCode")]
		//public async Task accessCode()
		//{
		//	string shortLivedAccessToken = Request.Query["code"];
		//	var httpClient = new HttpClient();

		//	// Initialize your Facebook Token Service
		//	var tokenService = new FacebookTokenService(_config, httpClient);

		//	TokenResponse longLivedToken = await tokenService.ExchangeForLongLivedTokenAsync(shortLivedAccessToken);

		//}
		public IActionResult Login()
		{
			var redirectUrl = Url.Action("FacebookResponse", "Facebook");  // Define the callback URL
			var properties = new AuthenticationProperties { RedirectUri = redirectUrl };

			// Initiate the login process
			return Challenge(properties, FacebookDefaults.AuthenticationScheme);
		}
		public async Task FacebookResponse()
		{
			var authenticateResult = await HttpContext.AuthenticateAsync();
			if (authenticateResult != null)
			{
				var shortAccessToken = authenticateResult.Properties.GetTokenValue("access_token");  // Access token from Facebook
				var userId = authenticateResult.Principal.FindFirst("sub")?.Value;  // User's Facebook ID
				var longTokenResponse = await _facebookTokenService.ExchangeForLongLivedTokenAsync(shortAccessToken);
				int tokenExpiryDays = int.Parse(_config.GetSection("FacebookSetting:TokenExpiryDays").Value);
				FacebookToken facebookToken = new FacebookToken();
				facebookToken.appId = _config.GetSection("FacebookSetting:AppId").Value;
				facebookToken.appSecret = _config.GetSection("FacebookSetting:AppSecret").Value;
				facebookToken.shortToken = shortAccessToken;
				facebookToken.longToken = longTokenResponse.access_token;
				facebookToken.expiryDate = DateTime.Now.AddDays(tokenExpiryDays);
				await _repo.CreateAsync(facebookToken);
				await _repo.SaveChangesAsync();
			}
		}
	}
}
