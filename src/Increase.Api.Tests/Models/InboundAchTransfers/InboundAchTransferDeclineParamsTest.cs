using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Tests.Models.InboundAchTransfers;

public class InboundAchTransferDeclineParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundAchTransferDeclineParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            Reason = Reason.PaymentStopped,
        };

        string expectedInboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev";
        ApiEnum<string, Reason> expectedReason = Reason.PaymentStopped;

        Assert.Equal(expectedInboundAchTransferID, parameters.InboundAchTransferID);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundAchTransferDeclineParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
        };

        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundAchTransferDeclineParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundAchTransferDeclineParams parameters = new()
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/inbound_ach_transfers/inbound_ach_transfer_tdrwqr3fq9gnnq49odev/decline"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundAchTransferDeclineParams
        {
            InboundAchTransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
            Reason = Reason.PaymentStopped,
        };

        InboundAchTransferDeclineParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.InsufficientFunds)]
    [InlineData(Reason.ReturnedPerOdfiRequest)]
    [InlineData(Reason.AuthorizationRevokedByCustomer)]
    [InlineData(Reason.PaymentStopped)]
    [InlineData(Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete)]
    [InlineData(Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity)]
    [InlineData(Reason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(Reason.CreditEntryRefusedByReceiver)]
    [InlineData(Reason.DuplicateEntry)]
    [InlineData(Reason.CorporateCustomerAdvisedNotAuthorized)]
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
    [InlineData(Reason.InsufficientFunds)]
    [InlineData(Reason.ReturnedPerOdfiRequest)]
    [InlineData(Reason.AuthorizationRevokedByCustomer)]
    [InlineData(Reason.PaymentStopped)]
    [InlineData(Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete)]
    [InlineData(Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity)]
    [InlineData(Reason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(Reason.CreditEntryRefusedByReceiver)]
    [InlineData(Reason.DuplicateEntry)]
    [InlineData(Reason.CorporateCustomerAdvisedNotAuthorized)]
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
