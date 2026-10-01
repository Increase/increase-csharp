using System;
using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class RealTimePaymentsRequestsForPaymentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var realTimePaymentsRequestForPayment =
            await this.client.RealTimePaymentsRequestsForPayment.Create(
                new()
                {
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    Debtor = new()
                    {
                        Address = new()
                        {
                            Country = "US",
                            AddressLine2 = "x",
                            BuildingNumber = "x",
                            City = "x",
                            PostalCode = "x",
                            State = "xx",
                            StreetName = "Liberty Street",
                        },
                        Name = "Ian Crease",
                    },
                    DebtorAccountNumber = "987654321",
                    DebtorRoutingNumber = "101050001",
                    ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
                    RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
                TestContext.Current.CancellationToken
            );
        realTimePaymentsRequestForPayment.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var realTimePaymentsRequestForPayment =
            await this.client.RealTimePaymentsRequestsForPayment.Retrieve(
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                new(),
                TestContext.Current.CancellationToken
            );
        realTimePaymentsRequestForPayment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.RealTimePaymentsRequestsForPayment.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var realTimePaymentsRequestForPayment =
            await this.client.RealTimePaymentsRequestsForPayment.Cancel(
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                new(),
                TestContext.Current.CancellationToken
            );
        realTimePaymentsRequestForPayment.Validate();
    }
}
