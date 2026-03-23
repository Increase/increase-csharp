using System.Threading.Tasks;
using Increase.Api.Models.OAuthTokens;

namespace Increase.Api.Tests.Services;

public class OAuthTokenServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var oauthToken = await this.client.OAuthTokens.Create(
            new() { GrantType = GrantType.AuthorizationCode },
            TestContext.Current.CancellationToken
        );
        oauthToken.Validate();
    }
}
