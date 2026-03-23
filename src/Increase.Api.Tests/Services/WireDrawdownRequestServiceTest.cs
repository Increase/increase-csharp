using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class WireDrawdownRequestServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var wireDrawdownRequest = await this.client.WireDrawdownRequests.Create(
            new()
            {
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 10000,
                CreditorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = "x",
                    PostalCode = "10045",
                    State = "NY",
                },
                CreditorName = "National Phonograph Company",
                DebtorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = "x",
                    PostalCode = "10045",
                    State = "NY",
                },
                DebtorName = "Ian Crease",
                UnstructuredRemittanceInformation = "Invoice 29582",
            },
            TestContext.Current.CancellationToken
        );
        wireDrawdownRequest.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var wireDrawdownRequest = await this.client.WireDrawdownRequests.Retrieve(
            "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
            new(),
            TestContext.Current.CancellationToken
        );
        wireDrawdownRequest.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.WireDrawdownRequests.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
