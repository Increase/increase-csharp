using System;
using Increase.Api.Models.ExternalAccounts;

namespace Increase.Api.Tests.Models.ExternalAccounts;

public class ExternalAccountRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalAccountRetrieveParams
        {
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
        };

        string expectedExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv";

        Assert.Equal(expectedExternalAccountID, parameters.ExternalAccountID);
    }

    [Fact]
    public void Url_Works()
    {
        ExternalAccountRetrieveParams parameters = new()
        {
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/external_accounts/external_account_ukk55lr923a3ac0pp7iv"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalAccountRetrieveParams
        {
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
        };

        ExternalAccountRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
