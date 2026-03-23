using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class IntrafiAccountEnrollmentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var intrafiAccountEnrollment = await this.client.IntrafiAccountEnrollments.Create(
            new() { AccountID = "account_in71c4amph0vgo2qllky", EmailAddress = "user@example.com" },
            TestContext.Current.CancellationToken
        );
        intrafiAccountEnrollment.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var intrafiAccountEnrollment = await this.client.IntrafiAccountEnrollments.Retrieve(
            "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
            new(),
            TestContext.Current.CancellationToken
        );
        intrafiAccountEnrollment.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.IntrafiAccountEnrollments.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Unenroll_Works()
    {
        var intrafiAccountEnrollment = await this.client.IntrafiAccountEnrollments.Unenroll(
            "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
            new(),
            TestContext.Current.CancellationToken
        );
        intrafiAccountEnrollment.Validate();
    }
}
