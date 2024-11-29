using Azure.Core;
using Microsoft.Extensions.Configuration;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class FacebookTokenService: IFacebookTokenService
{
	private readonly HttpClient _httpClient;
	private readonly IConfiguration _config;
	private IRepository _repo;

	public FacebookTokenService(IConfiguration config, HttpClient httpClient, IRepositoryFactory repo)
	{
		_httpClient = httpClient;
		_repo = repo.Create("AGGRDB");
		_config = config;
	}

	public async Task<TokenResponse> ExchangeForLongLivedTokenAsync(string shortLivedAccessToken)
	{
		// Your Facebook App credentials
		string appId = _config.GetSection("FacebookSetting:AppId").Value;
		string appSecret = _config.GetSection("FacebookSetting:AppSecret").Value;

		// URL to exchange short-lived token for long-lived token
		string url = $"https://graph.facebook.com/v17.0/oauth/access_token" +
					 $"?client_id={appId}" +
					 $"&client_secret={appSecret}" +
					 $"&grant_type=fb_exchange_token" +
					 $"&fb_exchange_token={shortLivedAccessToken}";

		try
		{
			// Make the HTTP GET request to Facebook API
			var response = await _httpClient.GetAsync(url);

			// Ensure the response is successful
			response.EnsureSuccessStatusCode();

			// Parse the response (JSON) to get the long-lived token
			var jsonResponse = await response.Content.ReadAsStringAsync();

			// Assuming the response contains 'access_token' and 'expires_in'
			if (jsonResponse.Contains("access_token"))
			{
				// Parse the access token (you can use a library like Newtonsoft.Json if needed)
				var tokenData = System.Text.Json.JsonSerializer.Deserialize<TokenResponse>(jsonResponse);

				// Returning the long-lived access token
				return tokenData;
			}
			else
			{
				// Handle case where access token is not returned
				Console.WriteLine("Error: " + jsonResponse);
				return null;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("An error occurred: " + ex.Message);
			return null;
		}
	}

	private async Task<string> GetPageAccessToken()
	{
		var appId = _config.GetSection("FacebookSetting:AppId").Value;
		var userAccessToken = _repo.Filter<FacebookToken>(e => e.appId == appId).FirstOrDefault();
		var url = $"https://graph.facebook.com/me/accounts?access_token={userAccessToken.longToken}";
		var pageId = _config.GetSection("FacebookSetting:PageId").Value;
		var response = await _httpClient.GetStringAsync(url);
		dynamic result = JsonConvert.DeserializeObject(response);
		if (result != null)
		{
			foreach (var pageAccessToken in result.data)
			{
				if (pageAccessToken.id == pageId)
				{
					return pageAccessToken.access_token;
				}
			}
		}
		return null;
	}

	public async Task PublishPostAsync(string pageId, string postContent)
	{
		var pageAccessToken =await  GetPageAccessToken();
		var url = $"https://graph.facebook.com/v15.0/{pageId}/feed";
		var data = new Dictionary<string, string>
		{
			{ "message", postContent },
			{ "access_token", pageAccessToken }
		};

		var content = new FormUrlEncodedContent(data);
		var response = await _httpClient.PostAsync(url, content);
		if (response.IsSuccessStatusCode)
		{
			var result = await response.Content.ReadAsStringAsync();
			// Handle success
		}
		else
		{
			var error = await response.Content.ReadAsStringAsync();
			// Handle error
		}

	}

	// Response object model for the token exchange response
	public class TokenResponse
	{
		public string access_token { get; set; }
	}
}
