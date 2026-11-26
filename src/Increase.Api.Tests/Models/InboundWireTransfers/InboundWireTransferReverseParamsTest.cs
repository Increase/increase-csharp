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
            Amount = 1,
        };

        string expectedInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";
        ApiEnum<string, Reason> expectedReason = Reason.CreditorRequest;
        long expectedAmount = 1;

        Assert.Equal(expectedInboundWireTransferID, parameters.InboundWireTransferID);
        Assert.Equal(expectedReason, parameters.Reason);
        Assert.Equal(expectedAmount, parameters.Amount);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundWireTransferReverseParams
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = Reason.CreditorRequest,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundWireTransferReverseParams
        {
            InboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
            Reason = Reason.CreditorRequest,

            // Null should be interpreted as omitted for these properties
            Amount = null,
        };

        Assert.Null(parameters.Amount);
        Assert.False(parameters.RawBodyData.ContainsKey("amount"));
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
            Amount = 1,
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
    [InlineData(Reason.Fraud)]
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
    [InlineData(Reason.Fraud)]
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
