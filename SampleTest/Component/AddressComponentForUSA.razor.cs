using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        private IJSRuntime _jsRuntime { get; set; }

        [Parameter]
        public IPInfoResponse IPInfoResponse { get; set; }

        [Parameter]
        public EventCallback<IPInfoResponse> IPInfoResponseChanged { get; set; }

        public string _ipAddress { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _ipAddress = await GetServerIPAddress();
                IPInfoResponse = await GetIPInfo();
            }
        }
        public async Task<IPInfoResponse> GetIPInfo()
        {
            var token = ConfigSetting.IpLocationApiAccessToken;
            var host = ConfigSetting.IpLocationApiUrl;
            var ipInfoApi = new IpInfoApi(host, token);
            if (string.IsNullOrWhiteSpace(_ipAddress))
                return new IPInfoResponse();
            IPInfoResponse = await ipInfoApi.GetInformationByIpsAsync(_ipAddress);
            await IPInfoResponseChanged.InvokeAsync(IPInfoResponse);
            return IPInfoResponse;
        }

        //public async Task onLookUpClick()
        //{
        //    IPInfoResponse = await GetIPInfo();
        //}

        public async Task<string> GetServerIPAddress()
        {
            var ipAddress = await _jsRuntime.InvokeAsync<string>("getIpAddress")
                    .ConfigureAwait(true);
            return ipAddress;
        }
    }
}
