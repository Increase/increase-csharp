using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Tests.Models.InboundAchTransfers;

public class InboundAchTransferTransferReturnParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundAchTransferTransferReturnParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            Reason = InboundAchTransferTransferReturnParamsReason.PaymentStopped,
        };

        string expectedInboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev";
        ApiEnum<string, InboundAchTransferTransferReturnParamsReason> expectedReason =
            InboundAchTransferTransferReturnParamsReason.PaymentStopped;

        Assert.Equal(expectedInboundAchTransferID, parameters.InboundAchTransferID);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void Url_Works()
    {
        InboundAchTransferTransferReturnParams parameters = new()
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            Reason = InboundAchTransferTransferReturnParamsReason.PaymentStopped,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_ach_transfers/inbound_ach_transfer_tdrwqr3fq9gnnq49odev/transfer_return"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundAchTransferTransferReturnParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            Reason = InboundAchTransferTransferReturnParamsReason.PaymentStopped,
        };

        InboundAchTransferTransferReturnParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InboundAchTransferTransferReturnParamsReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransferTransferReturnParamsReason.InsufficientFunds)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.AuthorizationRevokedByCustomer)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.PaymentStopped)]
    [InlineData(
        InboundAchTransferTransferReturnParamsReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(
        InboundAchTransferTransferReturnParamsReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(InboundAchTransferTransferReturnParamsReason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.CreditEntryRefusedByReceiver)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.DuplicateEntry)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.CorporateCustomerAdvisedNotAuthorized)]
    public void Validation_Works(InboundAchTransferTransferReturnParamsReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransferTransferReturnParamsReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransferTransferReturnParamsReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransferTransferReturnParamsReason.InsufficientFunds)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.AuthorizationRevokedByCustomer)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.PaymentStopped)]
    [InlineData(
        InboundAchTransferTransferReturnParamsReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(
        InboundAchTransferTransferReturnParamsReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(InboundAchTransferTransferReturnParamsReason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.CreditEntryRefusedByReceiver)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.DuplicateEntry)]
    [InlineData(InboundAchTransferTransferReturnParamsReason.CorporateCustomerAdvisedNotAuthorized)]
    public void SerializationRoundtrip_Works(InboundAchTransferTransferReturnParamsReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransferTransferReturnParamsReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransferTransferReturnParamsReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransferTransferReturnParamsReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransferTransferReturnParamsReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
