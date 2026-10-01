using System;
using Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment;

namespace Increase.Api.Tests.Models.InboundRealTimePaymentsRequestsForPayment;

public class InboundRealTimePaymentsRequestsForPaymentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundRealTimePaymentsRequestsForPaymentRetrieveParams
        {
            InboundRealTimePaymentsRequestForPaymentID =
                "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
        };

        string expectedInboundRealTimePaymentsRequestForPaymentID =
            "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky";

        Assert.Equal(
            expectedInboundRealTimePaymentsRequestForPaymentID,
            parameters.InboundRealTimePaymentsRequestForPaymentID
        );
    }

    [Fact]
    public void Url_Works()
    {
        InboundRealTimePaymentsRequestsForPaymentRetrieveParams parameters = new()
        {
            InboundRealTimePaymentsRequestForPaymentID =
                "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_real_time_payments_requests_for_payment/inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundRealTimePaymentsRequestsForPaymentRetrieveParams
        {
            InboundRealTimePaymentsRequestForPaymentID =
                "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
        };

        InboundRealTimePaymentsRequestsForPaymentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
