using System;
using Increase.Api.Models.SwiftTransfers;

namespace Increase.Api.Tests.Models.SwiftTransfers;

public class SwiftTransferRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SwiftTransferRetrieveParams
        {
            SwiftTransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        string expectedSwiftTransferID = "swift_transfer_29h21xkng03788zwd3fh";

        Assert.Equal(expectedSwiftTransferID, parameters.SwiftTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        SwiftTransferRetrieveParams parameters = new()
        {
            SwiftTransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/swift_transfers/swift_transfer_29h21xkng03788zwd3fh"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SwiftTransferRetrieveParams
        {
            SwiftTransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        SwiftTransferRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
