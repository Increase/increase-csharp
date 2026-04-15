using System;
using Increase.Api.Models.PendingTransactions;

namespace Increase.Api.Tests.Models.PendingTransactions;

public class PendingTransactionReleaseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PendingTransactionReleaseParams
        {
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
        };

        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";

        Assert.Equal(expectedPendingTransactionID, parameters.PendingTransactionID);
    }

    [Fact]
    public void Url_Works()
    {
        PendingTransactionReleaseParams parameters = new()
        {
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/pending_transactions/pending_transaction_k1sfetcau2qbvjbzgju4/release"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PendingTransactionReleaseParams
        {
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
        };

        PendingTransactionReleaseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
