using System;
using Increase.Api.Models.CardDisputes;

namespace Increase.Api.Tests.Models.CardDisputes;

public class CardDisputeWithdrawParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardDisputeWithdrawParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Explanation = "The explanation for withdrawing the Card Dispute.",
        };

        string expectedCardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men";
        string expectedExplanation = "The explanation for withdrawing the Card Dispute.";

        Assert.Equal(expectedCardDisputeID, parameters.CardDisputeID);
        Assert.Equal(expectedExplanation, parameters.Explanation);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardDisputeWithdrawParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
        };

        Assert.Null(parameters.Explanation);
        Assert.False(parameters.RawBodyData.ContainsKey("explanation"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardDisputeWithdrawParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",

            // Null should be interpreted as omitted for these properties
            Explanation = null,
        };

        Assert.Null(parameters.Explanation);
        Assert.False(parameters.RawBodyData.ContainsKey("explanation"));
    }

    [Fact]
    public void Url_Works()
    {
        CardDisputeWithdrawParams parameters = new()
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/card_disputes/card_dispute_h9sc95nbl1cgltpp7men/withdraw"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardDisputeWithdrawParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Explanation = "The explanation for withdrawing the Card Dispute.",
        };

        CardDisputeWithdrawParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
