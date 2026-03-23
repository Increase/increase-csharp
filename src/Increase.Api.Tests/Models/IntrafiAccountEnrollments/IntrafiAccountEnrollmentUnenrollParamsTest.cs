using System;
using Increase.Api.Models.IntrafiAccountEnrollments;

namespace Increase.Api.Tests.Models.IntrafiAccountEnrollments;

public class IntrafiAccountEnrollmentUnenrollParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrafiAccountEnrollmentUnenrollParams
        {
            IntrafiAccountEnrollmentID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
        };

        string expectedIntrafiAccountEnrollmentID =
            "intrafi_account_enrollment_w8l97znzreopkwf2tg75";

        Assert.Equal(expectedIntrafiAccountEnrollmentID, parameters.IntrafiAccountEnrollmentID);
    }

    [Fact]
    public void Url_Works()
    {
        IntrafiAccountEnrollmentUnenrollParams parameters = new()
        {
            IntrafiAccountEnrollmentID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/intrafi_account_enrollments/intrafi_account_enrollment_w8l97znzreopkwf2tg75/unenroll"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrafiAccountEnrollmentUnenrollParams
        {
            IntrafiAccountEnrollmentID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
        };

        IntrafiAccountEnrollmentUnenrollParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
