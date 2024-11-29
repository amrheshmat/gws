using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FacebookTokenService;

namespace MWS.Business.Shared
{
	public interface IFacebookTokenService
	{
		public Task<TokenResponse> ExchangeForLongLivedTokenAsync(string shortLivedAccessToken);
		public Task PublishPostAsync(string pageId, string message);
	}
}
