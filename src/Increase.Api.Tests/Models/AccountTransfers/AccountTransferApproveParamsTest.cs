using System;
using Increase.Api.Models.AccountTransfers;

namespace Increase.Api.Tests.Models.AccountTransfers;

public class AccountTransferApproveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountTransferApproveParams
        {
            AccountTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        string expectedAccountTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n";

        Assert.Equal(expectedAccountTransferID, parameters.AccountTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        AccountTransferApproveParams parameters = new()
        {
            AccountTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/account_transfers/account_transfer_7k9qe1ysdgqztnt63l7n/approve"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountTransferApproveParams
        {
            AccountTransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
        };

        AccountTransferApproveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
