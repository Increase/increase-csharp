using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class CheckDepositServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var checkDeposit = await this.client.CheckDeposits.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 1000,
                BackImageFileID = "file_26khfk98mzfz90a11oqx",
                FrontImageFileID = "file_hkv175ovmc2tb2v2zbrm",
            },
            TestContext.Current.CancellationToken
        );
        checkDeposit.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var checkDeposit = await this.client.CheckDeposits.Retrieve(
            "check_deposit_f06n9gpg7sxn8t19lfc1",
            new(),
            TestContext.Current.CancellationToken
        );
        checkDeposit.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CheckDeposits.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
