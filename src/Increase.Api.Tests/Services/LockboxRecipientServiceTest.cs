using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class LockboxRecipientServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var lockboxRecipient = await this.client.LockboxRecipients.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            },
            TestContext.Current.CancellationToken
        );
        lockboxRecipient.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var lockboxRecipient = await this.client.LockboxRecipients.Retrieve(
            "lockbox_3xt21ok13q19advds4t5",
            new(),
            TestContext.Current.CancellationToken
        );
        lockboxRecipient.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var lockboxRecipient = await this.client.LockboxRecipients.Update(
            "lockbox_3xt21ok13q19advds4t5",
            new(),
            TestContext.Current.CancellationToken
        );
        lockboxRecipient.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.LockboxRecipients.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
