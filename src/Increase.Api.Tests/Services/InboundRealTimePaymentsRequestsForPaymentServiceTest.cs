using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class InboundRealTimePaymentsRequestsForPaymentServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var inboundRealTimePaymentsRequestForPayment =
            await this.client.InboundRealTimePaymentsRequestsForPayment.Retrieve(
                "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
                new(),
                TestContext.Current.CancellationToken
            );
        inboundRealTimePaymentsRequestForPayment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.InboundRealTimePaymentsRequestsForPayment.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
