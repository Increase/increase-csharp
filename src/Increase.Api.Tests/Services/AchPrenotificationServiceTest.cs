using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class AchPrenotificationServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var achPrenotification = await this.client.AchPrenotifications.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumber = "987654321",
                RoutingNumber = "101050001",
            },
            TestContext.Current.CancellationToken
        );
        achPrenotification.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var achPrenotification = await this.client.AchPrenotifications.Retrieve(
            "ach_prenotification_ubjf9qqsxl3obbcn1u34",
            new(),
            TestContext.Current.CancellationToken
        );
        achPrenotification.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.AchPrenotifications.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
