using System;
using Increase.Api.Models.CheckbookChecks;

namespace Increase.Api.Tests.Models.CheckbookChecks;

public class CheckbookCheckStopParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckbookCheckStopParams
        {
            CheckbookCheckID = "checkbook_check_klgh3z50guf6jcnfhibb",
        };

        string expectedCheckbookCheckID = "checkbook_check_klgh3z50guf6jcnfhibb";

        Assert.Equal(expectedCheckbookCheckID, parameters.CheckbookCheckID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckbookCheckStopParams parameters = new()
        {
            CheckbookCheckID = "checkbook_check_klgh3z50guf6jcnfhibb",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/checkbook_checks/checkbook_check_klgh3z50guf6jcnfhibb/stop"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckbookCheckStopParams
        {
            CheckbookCheckID = "checkbook_check_klgh3z50guf6jcnfhibb",
        };

        CheckbookCheckStopParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
