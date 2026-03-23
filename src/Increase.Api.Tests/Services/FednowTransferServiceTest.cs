using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class FednowTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var fednowTransfer = await this.client.FednowTransfers.Create(
            new()
            {
                Amount = 100,
                CreditorName = "Ian Crease",
                DebtorName = "National Phonograph Company",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                UnstructuredRemittanceInformation = "Invoice 29582",
            },
            TestContext.Current.CancellationToken
        );
        fednowTransfer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var fednowTransfer = await this.client.FednowTransfers.Retrieve(
            "fednow_transfer_4i0mptrdu1mueg1196bg",
            new(),
            TestContext.Current.CancellationToken
        );
        fednowTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.FednowTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var fednowTransfer = await this.client.FednowTransfers.Approve(
            "fednow_transfer_4i0mptrdu1mueg1196bg",
            new(),
            TestContext.Current.CancellationToken
        );
        fednowTransfer.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var fednowTransfer = await this.client.FednowTransfers.Cancel(
            "fednow_transfer_4i0mptrdu1mueg1196bg",
            new(),
            TestContext.Current.CancellationToken
        );
        fednowTransfer.Validate();
    }
}
