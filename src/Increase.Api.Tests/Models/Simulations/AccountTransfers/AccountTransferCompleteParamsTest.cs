using System;
using Increase.Api.Models.Simulations.AccountTransfers;

namespace Increase.Api.Tests.Models.Simulations.AccountTransfers;

public class AccountTransferCompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountTransferCompleteParams
        {
            AccountTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        string expectedAccountTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n";

        Assert.Equal(expectedAccountTransferID, parameters.AccountTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountTransferCompleteParams parameters = new()
        {
            AccountTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/account_transfers/account_transfer_7k9qe1ysdgqztnt63l7n/complete"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountTransferCompleteParams
        {
            AccountTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        AccountTransferCompleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
