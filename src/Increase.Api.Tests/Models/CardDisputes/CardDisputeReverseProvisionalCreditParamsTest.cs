using System;
using Increase.Api.Models.CardDisputes;

namespace Increase.Api.Tests.Models.CardDisputes;

public class CardDisputeReverseProvisionalCreditParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardDisputeReverseProvisionalCreditParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
        };

        string expectedCardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men";

        Assert.Equal(expectedCardDisputeID, parameters.CardDisputeID);
    }

    [Fact]
    public void Url_Works()
    {
        CardDisputeReverseProvisionalCreditParams parameters = new()
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/card_disputes/card_dispute_h9sc95nbl1cgltpp7men/reverse_provisional_credit"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardDisputeReverseProvisionalCreditParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
        };

        CardDisputeReverseProvisionalCreditParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
