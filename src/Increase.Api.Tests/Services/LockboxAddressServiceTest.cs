using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class LockboxAddressServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var lockboxAddress = await this.client.LockboxAddresses.Create(
            new(),
            TestContext.Current.CancellationToken
        );
        lockboxAddress.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var lockboxAddress = await this.client.LockboxAddresses.Retrieve(
            "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            new(),
            TestContext.Current.CancellationToken
        );
        lockboxAddress.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var lockboxAddress = await this.client.LockboxAddresses.Update(
            "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            new(),
            TestContext.Current.CancellationToken
        );
        lockboxAddress.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.LockboxAddresses.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
