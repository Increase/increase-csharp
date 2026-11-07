using System;
using Increase.Api.Models.Checkbooks;

namespace Increase.Api.Tests.Models.Checkbooks;

public class CheckbookStopParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckbookStopParams { CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y" };

        string expectedCheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y";

        Assert.Equal(expectedCheckbookID, parameters.CheckbookID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckbookStopParams parameters = new() { CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/checkbooks/checkbook_7iudxhxum6vlkcjxmi8y/stop"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckbookStopParams { CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y" };

        CheckbookStopParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
