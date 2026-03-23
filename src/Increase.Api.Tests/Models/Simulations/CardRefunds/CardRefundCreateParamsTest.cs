using System;
using Increase.Api.Models.Simulations.CardRefunds;

namespace Increase.Api.Tests.Models.Simulations.CardRefunds;

public class CardRefundCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardRefundCreateParams
        {
            Amount = 1,
            PendingTransactionID = "pending_transaction_id",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        long expectedAmount = 1;
        string expectedPendingTransactionID = "pending_transaction_id";
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedPendingTransactionID, parameters.PendingTransactionID);
        Assert.Equal(expectedTransactionID, parameters.TransactionID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardRefundCreateParams { };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.PendingTransactionID);
        Assert.False(parameters.RawBodyData.ContainsKey("pending_transaction_id"));
        Assert.Null(parameters.TransactionID);
        Assert.False(parameters.RawBodyData.ContainsKey("transaction_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardRefundCreateParams
        {
            // Null should be interpreted as omitted for these properties
            Amount = null,
            PendingTransactionID = null,
            TransactionID = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
        Assert.Null(parameters.PendingTransactionID);
        Assert.False(parameters.RawBodyData.ContainsKey("pending_transaction_id"));
        Assert.Null(parameters.TransactionID);
        Assert.False(parameters.RawBodyData.ContainsKey("transaction_id"));
    }

    [Fact]
    public void Url_Works()
    {
        CardRefundCreateParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/simulations/card_refunds"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardRefundCreateParams
        {
            Amount = 1,
            PendingTransactionID = "pending_transaction_id",
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        CardRefundCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
