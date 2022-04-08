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

		private string _host { get; set; }
		private string token { get; set; }
		public IpInfoApi(string host, string token)
		{
			_host = host;
			this.token = token;
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
					string url = string.Format("{0}{1}", _host, ipAddress);
					client.BaseAddress = new Uri(_host);
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
