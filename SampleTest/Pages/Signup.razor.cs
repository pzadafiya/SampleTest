using Newtonsoft.Json;
using SampleTest.Models;
using System.Threading.Tasks;

namespace SampleTest.Pages
{
	public partial class Signup
	{
        public IPInfoResponse IPInfoResponse { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private void onSignUpClick()
        {
            string iPInfoResponseObj = JsonConvert.SerializeObject(IPInfoResponse);
        }
    }
}
