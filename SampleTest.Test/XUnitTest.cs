using Bunit;
using SampleTest.Component;
using SampleTest.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SampleTest.Test
{
	public class XUnitTest
	{

		[Fact]
		public void GetIpAddressOnCompomnentLoad()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			// Arrange: render the AddressComponentForUSA.razor component
			var cut = ctx.RenderComponent<AddressComponentForUSA>();
			var ipAddress = cut.Instance.GetServerIPAddress();
			// Act: check ip address on load

			Assert.NotNull(ipAddress);
			// Assert: verfiy ip address
		}

        [Fact]
        public async Task GetAddressDetailsFromIpOnCompomnentLoad()
        {
            using var ctx = new TestContext();
            ctx.JSInterop.Mode = JSRuntimeMode.Loose;
            // Arrange: render the AddressComponentForUSA.razor component
            //using var ctx = new TestContext();
            var cut = ctx.RenderComponent<AddressComponentForUSA>();
            var ipInfo = await cut.Instance.GetIPInfo("52.8.76.51");
            // Act: check address details based on ip address on load

            Assert.NotNull(ipInfo.Country);
            // Assert: verfiy address details based on ip address.

        }
    }
}
