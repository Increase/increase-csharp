using System;
using Increase.Api.Models.RealTimePaymentsRequestsForPayment;

namespace Increase.Api.Tests.Models.RealTimePaymentsRequestsForPayment;

public class RealTimePaymentsRequestsForPaymentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentRetrieveParams
        {
            RealTimePaymentsRequestForPaymentID =
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
        };

        string expectedRealTimePaymentsRequestForPaymentID =
            "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7";

        Assert.Equal(
            expectedRealTimePaymentsRequestForPaymentID,
            parameters.RealTimePaymentsRequestForPaymentID
        );
    }

    [Fact]
    public void Url_Works()
    {
        RealTimePaymentsRequestsForPaymentRetrieveParams parameters = new()
        {
            RealTimePaymentsRequestForPaymentID =
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/real_time_payments_requests_for_payment/real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentRetrieveParams
        {
            RealTimePaymentsRequestForPaymentID =
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
        };

        RealTimePaymentsRequestsForPaymentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
