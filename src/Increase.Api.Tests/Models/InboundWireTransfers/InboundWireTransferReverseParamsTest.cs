using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundWireTransfers;

namespace Increase.Api.Tests.Models.InboundWireTransfers;

public class InboundWireTransferReverseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundWireTransferReverseParams
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = Reason.CreditorRequest,
        };

        string expectedInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";
        ApiEnum<string, Reason> expectedReason = Reason.CreditorRequest;

        Assert.Equal(expectedInboundWireTransferID, parameters.InboundWireTransferID);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void Url_Works()
    {
        InboundWireTransferReverseParams parameters = new()
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = Reason.CreditorRequest,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_wire_transfers/inbound_wire_transfer_f228m6bmhtcxjco9pwp0/reverse"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundWireTransferReverseParams
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = Reason.CreditorRequest,
        };

        InboundWireTransferReverseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.Duplicate)]
    [InlineData(Reason.CreditorRequest)]
    [InlineData(Reason.TransactionForbidden)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.Duplicate)]
    [InlineData(Reason.CreditorRequest)]
    [InlineData(Reason.TransactionForbidden)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
