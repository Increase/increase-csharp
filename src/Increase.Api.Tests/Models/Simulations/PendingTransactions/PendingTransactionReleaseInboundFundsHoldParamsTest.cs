using System;
using Increase.Api.Models.Simulations.PendingTransactions;

namespace Increase.Api.Tests.Models.Simulations.PendingTransactions;

public class PendingTransactionReleaseInboundFundsHoldParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PendingTransactionReleaseInboundFundsHoldParams
        {
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
        };

        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";

        Assert.Equal(expectedPendingTransactionID, parameters.PendingTransactionID);
    }

    [Fact]
    public void Url_Works()
    {
        PendingTransactionReleaseInboundFundsHoldParams parameters = new()
        {
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/pending_transactions/pending_transaction_k1sfetcau2qbvjbzgju4/release_inbound_funds_hold"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PendingTransactionReleaseInboundFundsHoldParams
        {
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
        };

        PendingTransactionReleaseInboundFundsHoldParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
