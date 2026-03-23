using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.RealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.Simulations.RealTimePaymentsTransfers;

public class RealTimePaymentsTransferCompleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimePaymentsTransferCompleteParams
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            Rejection = new(RejectReasonCode.AccountClosed),
        };

        string expectedRealTimePaymentsTransferID =
            "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq";
        Rejection expectedRejection = new(RejectReasonCode.AccountClosed);

        Assert.Equal(expectedRealTimePaymentsTransferID, parameters.RealTimePaymentsTransferID);
        Assert.Equal(expectedRejection, parameters.Rejection);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RealTimePaymentsTransferCompleteParams
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        Assert.Null(parameters.Rejection);
        Assert.False(parameters.RawBodyData.ContainsKey("rejection"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RealTimePaymentsTransferCompleteParams
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",

            // Null should be interpreted as omitted for these properties
            Rejection = null,
        };

        Assert.Null(parameters.Rejection);
        Assert.False(parameters.RawBodyData.ContainsKey("rejection"));
    }

    [Fact]
    public void Url_Works()
    {
        RealTimePaymentsTransferCompleteParams parameters = new()
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/real_time_payments_transfers/real_time_payments_transfer_iyuhl5kdn7ssmup83mvq/complete"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimePaymentsTransferCompleteParams
        {
            RealTimePaymentsTransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
            Rejection = new(RejectReasonCode.AccountClosed),
        };

        RealTimePaymentsTransferCompleteParams copied = new(parameters);

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
    [InlineData(RejectReasonCode.UnexpectedAmount)]
    [InlineData(RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RejectReasonCode.UnknownEndCustomer)]
    [InlineData(RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RejectReasonCode.Timeout)]
    [InlineData(RejectReasonCode.UnsupportedMessageForRecipient)]
    [InlineData(RejectReasonCode.RecipientConnectionNotAvailable)]
    [InlineData(RejectReasonCode.RealTimePaymentsSuspended)]
    [InlineData(RejectReasonCode.InstructedAgentSignedOff)]
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
    [InlineData(RejectReasonCode.UnexpectedAmount)]
    [InlineData(RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RejectReasonCode.UnknownEndCustomer)]
    [InlineData(RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RejectReasonCode.Timeout)]
    [InlineData(RejectReasonCode.UnsupportedMessageForRecipient)]
    [InlineData(RejectReasonCode.RecipientConnectionNotAvailable)]
    [InlineData(RejectReasonCode.RealTimePaymentsSuspended)]
    [InlineData(RejectReasonCode.InstructedAgentSignedOff)]
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
