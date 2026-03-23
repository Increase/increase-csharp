using System;
using Increase.Api.Models.OAuthApplications;

namespace Increase.Api.Tests.Models.OAuthApplications;

public class OAuthApplicationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new OAuthApplicationRetrieveParams
        {
            OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
        };

        string expectedOAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy";

        Assert.Equal(expectedOAuthApplicationID, parameters.OAuthApplicationID);
    }

    [Fact]
    public void Url_Works()
    {
        OAuthApplicationRetrieveParams parameters = new()
        {
            OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/oauth_applications/application_gj9ufmpgh5i56k4vyriy"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new OAuthApplicationRetrieveParams
        {
            OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
        };

        OAuthApplicationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
