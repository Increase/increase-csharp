using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.FednowTransfers;

namespace Increase.Api.Tests.Models.Simulations.FednowTransfers;

public class FednowTransferCompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FednowTransferCompleteParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
            Rejection = new(RejectReasonCode.AccountClosed),
        };

        string expectedFednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg";
        Rejection expectedRejection = new(RejectReasonCode.AccountClosed);

        Assert.Equal(expectedFednowTransferID, parameters.FednowTransferID);
        Assert.Equal(expectedRejection, parameters.Rejection);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FednowTransferCompleteParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        Assert.Null(parameters.Rejection);
        Assert.False(parameters.RawBodyData.ContainsKey("rejection"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FednowTransferCompleteParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",

            // Null should be interpreted as omitted for these properties
            Rejection = null,
        };

        Assert.Null(parameters.Rejection);
        Assert.False(parameters.RawBodyData.ContainsKey("rejection"));
    }

    [Fact]
    public void Url_Works()
    {
        FednowTransferCompleteParams parameters = new()
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/fednow_transfers/fednow_transfer_4i0mptrdu1mueg1196bg/complete"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FednowTransferCompleteParams
        {
            FednowTransferID = "fednow_transfer_4i0mptrdu1mueg1196bg",
            Rejection = new(RejectReasonCode.AccountClosed),
        };

        FednowTransferCompleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RejectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rejection { RejectReasonCode = RejectReasonCode.AccountClosed };

        ApiEnum<string, RejectReasonCode> expectedRejectReasonCode = RejectReasonCode.AccountClosed;

        Assert.Equal(expectedRejectReasonCode, model.RejectReasonCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rejection { RejectReasonCode = RejectReasonCode.AccountClosed };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rejection>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rejection { RejectReasonCode = RejectReasonCode.AccountClosed };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rejection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RejectReasonCode> expectedRejectReasonCode = RejectReasonCode.AccountClosed;

        Assert.Equal(expectedRejectReasonCode, deserialized.RejectReasonCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rejection { RejectReasonCode = RejectReasonCode.AccountClosed };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rejection { RejectReasonCode = RejectReasonCode.AccountClosed };

        Rejection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RejectReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(RejectReasonCode.AccountClosed)]
    [InlineData(RejectReasonCode.AccountBlocked)]
    [InlineData(RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier)]
    [InlineData(RejectReasonCode.EndCustomerDeceased)]
    [InlineData(RejectReasonCode.Narrative)]
    [InlineData(RejectReasonCode.TransactionForbidden)]
    [InlineData(RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RejectReasonCode.Timeout)]
    [InlineData(RejectReasonCode.ProcessingError)]
    [InlineData(RejectReasonCode.Other)]
    public void Validation_Works(RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RejectReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RejectReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RejectReasonCode.AccountClosed)]
    [InlineData(RejectReasonCode.AccountBlocked)]
    [InlineData(RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier)]
    [InlineData(RejectReasonCode.EndCustomerDeceased)]
    [InlineData(RejectReasonCode.Narrative)]
    [InlineData(RejectReasonCode.TransactionForbidden)]
    [InlineData(RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RejectReasonCode.Timeout)]
    [InlineData(RejectReasonCode.ProcessingError)]
    [InlineData(RejectReasonCode.Other)]
    public void SerializationRoundtrip_Works(RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RejectReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RejectReasonCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RejectReasonCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RejectReasonCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
