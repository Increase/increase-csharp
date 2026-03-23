using System;
using Increase.Api.Models.CardDisputes;

namespace Increase.Api.Tests.Models.CardDisputes;

public class CardDisputeRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardDisputeRetrieveParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
        };

        string expectedCardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men";

        Assert.Equal(expectedCardDisputeID, parameters.CardDisputeID);
    }

    [Fact]
    public void Url_Works()
    {
        CardDisputeRetrieveParams parameters = new()
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/card_disputes/card_dispute_h9sc95nbl1cgltpp7men"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardDisputeRetrieveParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
        };

        CardDisputeRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
