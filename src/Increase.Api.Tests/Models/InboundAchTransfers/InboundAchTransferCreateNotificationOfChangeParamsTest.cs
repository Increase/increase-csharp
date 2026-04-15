using System;
using Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Tests.Models.InboundAchTransfers;

public class InboundAchTransferCreateNotificationOfChangeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundAchTransferCreateNotificationOfChangeParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            UpdatedAccountNumber = "987654321",
            UpdatedRoutingNumber = "101050001",
        };

        string expectedInboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev";
        string expectedUpdatedAccountNumber = "987654321";
        string expectedUpdatedRoutingNumber = "101050001";

        Assert.Equal(expectedInboundAchTransferID, parameters.InboundAchTransferID);
        Assert.Equal(expectedUpdatedAccountNumber, parameters.UpdatedAccountNumber);
        Assert.Equal(expectedUpdatedRoutingNumber, parameters.UpdatedRoutingNumber);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundAchTransferCreateNotificationOfChangeParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
        };

        Assert.Null(parameters.UpdatedAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("updated_account_number"));
        Assert.Null(parameters.UpdatedRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("updated_routing_number"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundAchTransferCreateNotificationOfChangeParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",

            // Null should be interpreted as omitted for these properties
            UpdatedAccountNumber = null,
            UpdatedRoutingNumber = null,
        };

        Assert.Null(parameters.UpdatedAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("updated_account_number"));
        Assert.Null(parameters.UpdatedRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("updated_routing_number"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundAchTransferCreateNotificationOfChangeParams parameters = new()
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_ach_transfers/inbound_ach_transfer_tdrwqr3fq9gnnq49odev/create_notification_of_change"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundAchTransferCreateNotificationOfChangeParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            UpdatedAccountNumber = "987654321",
            UpdatedRoutingNumber = "101050001",
        };

        InboundAchTransferCreateNotificationOfChangeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
