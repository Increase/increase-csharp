using System;
using Increase.Api.Models.Simulations.CardSettlements;

namespace Increase.Api.Tests.Models.Simulations.CardSettlements;

public class CardSettlementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardSettlementCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            Amount = 1,
        };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        long expectedAmount = 1;

        Assert.Equal(expectedCardID, parameters.CardID);
        Assert.Equal(expectedPendingTransactionID, parameters.PendingTransactionID);
        Assert.Equal(expectedAmount, parameters.Amount);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardSettlementCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardSettlementCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",

            // Null should be interpreted as omitted for these properties
            Amount = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void Url_Works()
    {
        CardSettlementCreateParams parameters = new()
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/card_settlements"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardSettlementCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            Amount = 1,
        };

        CardSettlementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
