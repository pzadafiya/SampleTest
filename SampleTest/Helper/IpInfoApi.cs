using SampleTest.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace SampleTest.Helper
{
	public class IpInfoApi
	{

		public string _Host { get; set; }
		public string _Token { get; set; }
		public IpInfoApi(string host, string token)
		{
			_Host = host;
			_Token = token;
		}

		/// <param name="ipAddress"></param>
		/// <summary>Returns ip information about the given ip.</summary>
		/// <returns>response object.</returns>
		/// <exception cref="ApiException">A server side error occurred.</exception>
		public async Task<IPInfoResponse> GetInformationByIpsAsync(string ipAddress)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					string url = string.Format("{0}{1}", _Host, ipAddress);
					client.BaseAddress = new Uri(_Host);
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _Token);
					var response = await client.GetAsync(url);
					if (response != null)
					{
						var jsonString = await response.Content.ReadAsStringAsync();
						return JsonConvert.DeserializeObject<IPInfoResponse>(jsonString);
					}
				}
			}
			catch (Exception ex)
			{
				return null;
			}
			return null;
		}
	}
}
