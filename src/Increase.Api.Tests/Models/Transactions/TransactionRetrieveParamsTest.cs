using System;
using Increase.Api.Models.Transactions;

namespace Increase.Api.Tests.Models.Transactions;

public class TransactionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TransactionRetrieveParams
        {
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";

        Assert.Equal(expectedTransactionID, parameters.TransactionID);
    }

    [Fact]
    public void Url_Works()
    {
        TransactionRetrieveParams parameters = new()
        {
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/transactions/transaction_uyrp7fld2ium70oa7oi"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TransactionRetrieveParams
        {
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        TransactionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
