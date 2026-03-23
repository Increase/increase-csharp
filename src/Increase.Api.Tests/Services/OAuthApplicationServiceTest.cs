using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class OAuthApplicationServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var oauthApplication = await this.client.OAuthApplications.Retrieve(
            "application_gj9ufmpgh5i56k4vyriy",
            new(),
            TestContext.Current.CancellationToken
        );
        oauthApplication.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.OAuthApplications.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
