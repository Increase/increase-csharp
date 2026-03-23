using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundCheckDeposits;

namespace Increase.Api.Tests.Models.InboundCheckDeposits;

public class InboundCheckDepositReturnParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundCheckDepositReturnParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = Reason.AlteredOrFictitious,
        };

        string expectedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra";
        ApiEnum<string, Reason> expectedReason = Reason.AlteredOrFictitious;

        Assert.Equal(expectedInboundCheckDepositID, parameters.InboundCheckDepositID);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void Url_Works()
    {
        InboundCheckDepositReturnParams parameters = new()
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = Reason.AlteredOrFictitious,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/inbound_check_deposits/inbound_check_deposit_zoshvqybq0cjjm31mra/return"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundCheckDepositReturnParams
        {
            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
            Reason = Reason.AlteredOrFictitious,
        };

        InboundCheckDepositReturnParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.AlteredOrFictitious)]
    [InlineData(Reason.NotAuthorized)]
    [InlineData(Reason.DuplicatePresentment)]
    [InlineData(Reason.EndorsementMissing)]
    [InlineData(Reason.EndorsementIrregular)]
    [InlineData(Reason.ReferToMaker)]
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
    [InlineData(Reason.AlteredOrFictitious)]
    [InlineData(Reason.NotAuthorized)]
    [InlineData(Reason.DuplicatePresentment)]
    [InlineData(Reason.EndorsementMissing)]
    [InlineData(Reason.EndorsementIrregular)]
    [InlineData(Reason.ReferToMaker)]
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
