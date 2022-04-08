using Newtonsoft.Json;
using SampleTest.Models;
using System.Threading.Tasks;

namespace SampleTest.Pages
{
	public partial class Signup
	{
        private IPInfoResponse IPInfoResponse { get; set; }
        private string _feedbackMessage { get; set; } = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private void onSignUpClick()
        {
            string iPInfoResponseObj = JsonConvert.SerializeObject(IPInfoResponse);
            _feedbackMessage = "Success" + System.Environment.NewLine + "{" + iPInfoResponseObj + "}";
        }
    }
}
