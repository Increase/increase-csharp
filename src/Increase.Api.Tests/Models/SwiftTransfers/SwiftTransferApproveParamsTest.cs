using System;
using Increase.Api.Models.SwiftTransfers;

namespace Increase.Api.Tests.Models.SwiftTransfers;

public class SwiftTransferApproveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SwiftTransferApproveParams
        {
            SwiftTransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        string expectedSwiftTransferID = "swift_transfer_29h21xkng03788zwd3fh";

        Assert.Equal(expectedSwiftTransferID, parameters.SwiftTransferID);
    }

    [Fact]
    public void Url_Works()
    {
        SwiftTransferApproveParams parameters = new()
        {
            SwiftTransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/swift_transfers/swift_transfer_29h21xkng03788zwd3fh/approve"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SwiftTransferApproveParams
        {
            SwiftTransferID = "swift_transfer_29h21xkng03788zwd3fh",
        };

        SwiftTransferApproveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
