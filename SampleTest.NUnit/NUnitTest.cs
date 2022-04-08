using Bunit;
using SampleTest.Component;
using NUnit.Framework;
using System.Threading.Tasks;

namespace SampleTest.NUnit
{
	public abstract class BunitTestContext : TestContextWrapper
	{
		[SetUp]
		public void Setup() => TestContext = new Bunit.TestContext();

		[TearDown]
		public void TearDown() => TestContext?.Dispose();
	}

	public class NUnitTest : BunitTestContext
	{

		[Test]
		public void GetIpAddressOnCompomnentLoadNUnit()
		{
			// Arrange: render the AddressComponentForUSA.razor component
			var cut = RenderComponent<AddressComponentForUSA>();
			var ipAddress = cut.Instance.GetServerIPAddress();
			// Act: check ip address on load

			Assert.NotNull(ipAddress);
			// Assert: verfiy ip address
		}

		[Test]
		public async Task GetAddressDetailsFromIpOnCompomnentLoadNUnit()
		{
			// Arrange: render the AddressComponentForUSA.razor component
			//using var ctx = new TestContext();
			var cut = RenderComponent<AddressComponentForUSA>();
			var ipInfo = await cut.Instance.GetIPInfo();
			// Act: check address details based on ip address on load

			Assert.NotNull(ipInfo.Country);
			// Assert: verfiy address details based on ip address.

		}
	}
}