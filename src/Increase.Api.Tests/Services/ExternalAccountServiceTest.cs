using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class ExternalAccountServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var externalAccount = await this.client.ExternalAccounts.Create(
            new()
            {
                AccountNumber = "987654321",
                Description = "Landlord",
                RoutingNumber = "101050001",
            },
            TestContext.Current.CancellationToken
        );
        externalAccount.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var externalAccount = await this.client.ExternalAccounts.Retrieve(
            "external_account_ukk55lr923a3ac0pp7iv",
            new(),
            TestContext.Current.CancellationToken
        );
        externalAccount.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var externalAccount = await this.client.ExternalAccounts.Update(
            "external_account_ukk55lr923a3ac0pp7iv",
            new(),
            TestContext.Current.CancellationToken
        );
        externalAccount.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.ExternalAccounts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
