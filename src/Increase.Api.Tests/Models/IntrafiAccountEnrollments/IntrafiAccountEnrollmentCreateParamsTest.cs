using System;
using Increase.Api.Models.IntrafiAccountEnrollments;

namespace Increase.Api.Tests.Models.IntrafiAccountEnrollments;

public class IntrafiAccountEnrollmentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrafiAccountEnrollmentCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            EmailAddress = "user@example.com",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedEmailAddress = "user@example.com";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedEmailAddress, parameters.EmailAddress);
    }

    [Fact]
    public void Url_Works()
    {
        IntrafiAccountEnrollmentCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            EmailAddress = "user@example.com",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/intrafi_account_enrollments"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrafiAccountEnrollmentCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            EmailAddress = "user@example.com",
        };

        IntrafiAccountEnrollmentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
