using System;
using Increase.Api.Models.Simulations.Checkbooks;

namespace Increase.Api.Tests.Models.Simulations.Checkbooks;

public class CheckbookMailParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckbookMailParams { CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y" };

        string expectedCheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y";

        Assert.Equal(expectedCheckbookID, parameters.CheckbookID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckbookMailParams parameters = new() { CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/checkbooks/checkbook_7iudxhxum6vlkcjxmi8y/mail"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckbookMailParams { CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y" };

        CheckbookMailParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
