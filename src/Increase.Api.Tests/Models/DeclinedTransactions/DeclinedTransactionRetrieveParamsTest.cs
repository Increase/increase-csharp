using System;
using Increase.Api.Models.DeclinedTransactions;

namespace Increase.Api.Tests.Models.DeclinedTransactions;

public class DeclinedTransactionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeclinedTransactionRetrieveParams
        {
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
        };

        string expectedDeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8";

        Assert.Equal(expectedDeclinedTransactionID, parameters.DeclinedTransactionID);
    }

    [Fact]
    public void Url_Works()
    {
        DeclinedTransactionRetrieveParams parameters = new()
        {
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/declined_transactions/declined_transaction_17jbn0yyhvkt4v4ooym8"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeclinedTransactionRetrieveParams
        {
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
        };

        DeclinedTransactionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
