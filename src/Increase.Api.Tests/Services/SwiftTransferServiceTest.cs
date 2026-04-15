using System.Threading.Tasks;
using Increase.Api.Models.SwiftTransfers;

namespace Increase.Api.Tests.Services;

public class SwiftTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var swiftTransfer = await this.client.SwiftTransfers.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumber = "987654321",
                BankIdentificationCode = "ECBFDEFFTPP",
                CreditorAddress = new()
                {
                    City = "Frankfurt",
                    Country = "DE",
                    Line1 = "Sonnemannstrasse 20",
                    Line2 = "line2",
                    PostalCode = "60314",
                    State = "state",
                },
                CreditorName = "Ian Crease",
                DebtorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = "line2",
                    PostalCode = "10045",
                    State = "NY",
                },
                DebtorName = "National Phonograph Company",
                InstructedAmount = 100,
                InstructedCurrency = InstructedCurrency.Usd,
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                UnstructuredRemittanceInformation = "New Swift transfer",
            },
            TestContext.Current.CancellationToken
        );
        swiftTransfer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var swiftTransfer = await this.client.SwiftTransfers.Retrieve(
            "swift_transfer_29h21xkng03788zwd3fh",
            new(),
            TestContext.Current.CancellationToken
        );
        swiftTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.SwiftTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var swiftTransfer = await this.client.SwiftTransfers.Approve(
            "swift_transfer_29h21xkng03788zwd3fh",
            new(),
            TestContext.Current.CancellationToken
        );
        swiftTransfer.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var swiftTransfer = await this.client.SwiftTransfers.Cancel(
            "swift_transfer_29h21xkng03788zwd3fh",
            new(),
            TestContext.Current.CancellationToken
        );
        swiftTransfer.Validate();
    }
}
