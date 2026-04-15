using System.Threading.Tasks;
using Increase.Api.Models.WireTransfers;

namespace Increase.Api.Tests.Services;

public class WireTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var wireTransfer = await this.client.WireTransfers.Create(
            new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                Creditor = new()
                {
                    Name = "Ian Crease",
                    Address = new(
                        new Unstructured()
                        {
                            Line1 = "33 Liberty Street",
                            Line2 = "New York",
                            Line3 = "NY 10045",
                        }
                    ),
                },
                Remittance = new()
                {
                    Category = Category.Unstructured,
                    Tax = new()
                    {
                        Date = "2019-12-27",
                        IdentificationNumber = "483310694",
                        TypeCode = "1I5r3",
                    },
                    Unstructured = new("New account transfer"),
                },
            },
            TestContext.Current.CancellationToken
        );
        wireTransfer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var wireTransfer = await this.client.WireTransfers.Retrieve(
            "wire_transfer_5akynk7dqsq25qwk9q2u",
            new(),
            TestContext.Current.CancellationToken
        );
        wireTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.WireTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var wireTransfer = await this.client.WireTransfers.Approve(
            "wire_transfer_5akynk7dqsq25qwk9q2u",
            new(),
            TestContext.Current.CancellationToken
        );
        wireTransfer.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var wireTransfer = await this.client.WireTransfers.Cancel(
            "wire_transfer_5akynk7dqsq25qwk9q2u",
            new(),
            TestContext.Current.CancellationToken
        );
        wireTransfer.Validate();
    }
}
