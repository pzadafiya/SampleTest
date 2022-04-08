using Microsoft.AspNetCore.Components;
using SampleTest.Helper;
using SampleTest.Models;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SampleTest.Component
{
	public partial class AddressComponentForUSA
	{
		[Inject]
		private NavigationManager NavigationManager { get; set; }


		[Parameter]
		public IPInfoResponse IPInfoResponse { get; set; }

		[Parameter]
		public EventCallback<IPInfoResponse> IPInfoResponseChanged { get; set; }


		public string _ipAddress { get; set; }
		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
			_ipAddress = GetServerIPAddress();
			IPInfoResponse = await GetIPInfo();
		}

		public async Task<IPInfoResponse> GetIPInfo()
		{
			var token = ConfigSetting.IpLocationApiAccessToken;
			var host = ConfigSetting.IpLocationApiUrl;
			var ipInfoApi = new IpInfoApi(host, token);
			IPInfoResponse = await ipInfoApi.GetInformationByIpsAsync(_ipAddress);
			await IPInfoResponseChanged.InvokeAsync(IPInfoResponse);
			return IPInfoResponse;
		}

		//public async Task onLookUpClick()
		//{
		//	IPInfoResponse = await GetIPInfo();
		//}

		public string GetServerIPAddress()
		{
			var IsLocal = NavigationManager.BaseUri.StartsWith("http://localhost") ||
			NavigationManager.BaseUri.StartsWith("https://localhost");

			if (IsLocal)
			{
				using (var client = new WebClient())
				{
					return client.DownloadString("http://ifconfig.me").Replace("\n", "");
				}
			}
			else
			{
				var host = Dns.GetHostEntry(Dns.GetHostName());
				foreach (var ip in host.AddressList)
				{
					if (ip.AddressFamily == AddressFamily.InterNetwork)
						return ip.ToString();
				}
				throw new Exception("No network adapters with an IPv4 address in the system!");
			}
		}
	}
}
