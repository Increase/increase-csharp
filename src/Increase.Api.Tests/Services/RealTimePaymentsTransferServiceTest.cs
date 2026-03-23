using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class RealTimePaymentsTransferServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var realTimePaymentsTransfer = await this.client.RealTimePaymentsTransfers.Create(
            new()
            {
                Amount = 100,
                CreditorName = "Ian Crease",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                UnstructuredRemittanceInformation = "Invoice 29582",
            },
            TestContext.Current.CancellationToken
        );
        realTimePaymentsTransfer.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var realTimePaymentsTransfer = await this.client.RealTimePaymentsTransfers.Retrieve(
            "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            new(),
            TestContext.Current.CancellationToken
        );
        realTimePaymentsTransfer.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.RealTimePaymentsTransfers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Approve_Works()
    {
        var realTimePaymentsTransfer = await this.client.RealTimePaymentsTransfers.Approve(
            "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            new(),
            TestContext.Current.CancellationToken
        );
        realTimePaymentsTransfer.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var realTimePaymentsTransfer = await this.client.RealTimePaymentsTransfers.Cancel(
            "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            new(),
            TestContext.Current.CancellationToken
        );
        realTimePaymentsTransfer.Validate();
    }
}
