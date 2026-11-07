using System;
using Increase.Api.Models.Checkbooks;

namespace Increase.Api.Tests.Models.Checkbooks;

public class CheckbookRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckbookRetrieveParams
        {
            CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
        };

        string expectedCheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y";

        Assert.Equal(expectedCheckbookID, parameters.CheckbookID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckbookRetrieveParams parameters = new()
        {
            CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/checkbooks/checkbook_7iudxhxum6vlkcjxmi8y"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckbookRetrieveParams
        {
            CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
        };

        CheckbookRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
