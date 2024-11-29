using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MWS.Business.Shared;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using static FacebookTokenService;

public class FacebookBackgroundService : BackgroundService
{
	private readonly ILogger<FacebookBackgroundService> _logger;
	IServiceProvider _serviceProvider;
	IConfiguration _config;
	//private IFacebookTokenService _facebookTokenService;
	public FacebookBackgroundService(IConfiguration config,ILogger<FacebookBackgroundService> logger, IServiceProvider serviceProvider/*,IFacebookTokenService facebookTokenService*/)
	{
		_logger = logger;
		_config = config;
		_serviceProvider = serviceProvider;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		// Interval for 50 days (in milliseconds)
		int TokenRefreshDays = int.Parse(_config.GetSection("FacebookSetting:TokenRefreshDays").Value);
		var interval = TimeSpan.FromDays(TokenRefreshDays);

		while (!stoppingToken.IsCancellationRequested)
		{
			// Log the current task run time
			_logger.LogInformation($"Service running at: {DateTime.Now}");
			// Your task logic here
			refreshToken();
			// Wait for the next interval (58 days)
			await Task.Delay(interval, stoppingToken);
		}
	}

	private async Task refreshToken()
	{
		var httpClient = new HttpClient();
		try
		{
			using (var scope = _serviceProvider.CreateScope())
			{
				var facebookTokenService = scope.ServiceProvider.GetRequiredService<IFacebookTokenService>();
				var repo = scope.ServiceProvider.GetRequiredService<IRepositoryFactory>();
				int tokenExpiryDays = int.Parse(_config.GetSection("FacebookSetting:TokenExpiryDays").Value);
				var _repo = repo.Create("AGGRDB");
				var appId = _config.GetSection("FacebookSetting:AppId").Value;
				var pageId = _config.GetSection("FacebookSetting:PageId").Value;
				//facebookTokenService.PublishPostAsync(pageId, "test from background");
				FacebookToken facebookToken = _repo.Filter<FacebookToken>(e => e.appId == appId).FirstOrDefault();
				TokenResponse longLivedToken = await facebookTokenService.ExchangeForLongLivedTokenAsync(facebookToken.longToken);
				facebookToken.longToken = longLivedToken.access_token;
				facebookToken.expiryDate = DateTime.Now.AddDays(tokenExpiryDays);
				_repo.Update(facebookToken);
				await _repo.SaveChangesAsync();
				// Implement your background task logic here
				_logger.LogInformation("Performing background task...");
			}
		}catch(Exception ex) { }
	}
}
