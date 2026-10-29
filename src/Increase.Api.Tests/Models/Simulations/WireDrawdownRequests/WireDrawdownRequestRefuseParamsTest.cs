using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.WireDrawdownRequests;

namespace Increase.Api.Tests.Models.Simulations.WireDrawdownRequests;

public class WireDrawdownRequestRefuseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WireDrawdownRequestRefuseParams
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
            RefusalReasonAdditionalInformation = "x",
            RefusalReasonCode = RefusalReasonCode.InvalidDebtorAccountNumber,
        };

        string expectedWireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3";
        string expectedRefusalReasonAdditionalInformation = "x";
        ApiEnum<string, RefusalReasonCode> expectedRefusalReasonCode =
            RefusalReasonCode.InvalidDebtorAccountNumber;

        Assert.Equal(expectedWireDrawdownRequestID, parameters.WireDrawdownRequestID);
        Assert.Equal(
            expectedRefusalReasonAdditionalInformation,
            parameters.RefusalReasonAdditionalInformation
        );
        Assert.Equal(expectedRefusalReasonCode, parameters.RefusalReasonCode);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WireDrawdownRequestRefuseParams
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
        };

        Assert.Null(parameters.RefusalReasonAdditionalInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("refusal_reason_additional_information"));
        Assert.Null(parameters.RefusalReasonCode);
        Assert.False(parameters.RawBodyData.ContainsKey("refusal_reason_code"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WireDrawdownRequestRefuseParams
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",

            // Null should be interpreted as omitted for these properties
            RefusalReasonAdditionalInformation = null,
            RefusalReasonCode = null,
        };

        Assert.Null(parameters.RefusalReasonAdditionalInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("refusal_reason_additional_information"));
        Assert.Null(parameters.RefusalReasonCode);
        Assert.False(parameters.RawBodyData.ContainsKey("refusal_reason_code"));
    }

    [Fact]
    public void Url_Works()
    {
        WireDrawdownRequestRefuseParams parameters = new()
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/wire_drawdown_requests/wire_drawdown_request_q6lmocus3glo0lr2bfv3/refuse"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WireDrawdownRequestRefuseParams
        {
            WireDrawdownRequestID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
            RefusalReasonAdditionalInformation = "x",
            RefusalReasonCode = RefusalReasonCode.InvalidDebtorAccountNumber,
        };

        WireDrawdownRequestRefuseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RefusalReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(RefusalReasonCode.InvalidDebtorAccountNumber)]
    [InlineData(RefusalReasonCode.TransactionForbidden)]
    [InlineData(RefusalReasonCode.UnsuccessfulDirectDebit)]
    [InlineData(RefusalReasonCode.InconsistentWithEndCustomer)]
    [InlineData(RefusalReasonCode.Narrative)]
    [InlineData(RefusalReasonCode.Other)]
    public void Validation_Works(RefusalReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefusalReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RefusalReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RefusalReasonCode.InvalidDebtorAccountNumber)]
    [InlineData(RefusalReasonCode.TransactionForbidden)]
    [InlineData(RefusalReasonCode.UnsuccessfulDirectDebit)]
    [InlineData(RefusalReasonCode.InconsistentWithEndCustomer)]
    [InlineData(RefusalReasonCode.Narrative)]
    [InlineData(RefusalReasonCode.Other)]
    public void SerializationRoundtrip_Works(RefusalReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RefusalReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RefusalReasonCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RefusalReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RefusalReasonCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
