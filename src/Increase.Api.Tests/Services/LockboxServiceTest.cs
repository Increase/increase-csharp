using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class LockboxServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var lockbox = await this.client.Lockboxes.Create(
            new() { AccountID = "account_in71c4amph0vgo2qllky" },
            TestContext.Current.CancellationToken
        );
        lockbox.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var lockbox = await this.client.Lockboxes.Retrieve(
            "lockbox_3xt21ok13q19advds4t5",
            new(),
            TestContext.Current.CancellationToken
        );
        lockbox.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var lockbox = await this.client.Lockboxes.Update(
            "lockbox_3xt21ok13q19advds4t5",
            new(),
            TestContext.Current.CancellationToken
        );
        lockbox.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Lockboxes.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
