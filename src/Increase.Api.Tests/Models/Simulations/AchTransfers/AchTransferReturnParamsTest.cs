using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.AchTransfers;

namespace Increase.Api.Tests.Models.Simulations.AchTransfers;

public class AchTransferReturnParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchTransferReturnParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            Reason = Reason.InsufficientFund,
        };

        string expectedAchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";
        ApiEnum<string, Reason> expectedReason = Reason.InsufficientFund;

        Assert.Equal(expectedAchTransferID, parameters.AchTransferID);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AchTransferReturnParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AchTransferReturnParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        AchTransferReturnParams parameters = new()
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/simulations/ach_transfers/ach_transfer_uoxatyh3lt5evrsdvo7q/return"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchTransferReturnParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            Reason = Reason.InsufficientFund,
        };

        AchTransferReturnParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.InsufficientFund)]
    [InlineData(Reason.NoAccount)]
    [InlineData(Reason.AccountClosed)]
    [InlineData(Reason.InvalidAccountNumberStructure)]
    [InlineData(Reason.AccountFrozenEntryReturnedPerOfacInstruction)]
    [InlineData(Reason.CreditEntryRefusedByReceiver)]
    [InlineData(Reason.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode)]
    [InlineData(Reason.CorporateCustomerAdvisedNotAuthorized)]
    [InlineData(Reason.PaymentStopped)]
    [InlineData(Reason.NonTransactionAccount)]
    [InlineData(Reason.UncollectedFunds)]
    [InlineData(Reason.RoutingNumberCheckDigitError)]
    [InlineData(Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete)]
    [InlineData(Reason.AmountFieldError)]
    [InlineData(Reason.AuthorizationRevokedByCustomer)]
    [InlineData(Reason.InvalidAchRoutingNumber)]
    [InlineData(Reason.FileRecordEditCriteria)]
    [InlineData(Reason.EnrInvalidIndividualName)]
    [InlineData(Reason.ReturnedPerOdfiRequest)]
    [InlineData(Reason.LimitedParticipationDfi)]
    [InlineData(Reason.IncorrectlyCodedOutboundInternationalPayment)]
    [InlineData(Reason.AccountSoldToAnotherDfi)]
    [InlineData(Reason.AddendaError)]
    [InlineData(Reason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(Reason.CustomerAdvisedNotWithinAuthorizationTerms)]
    [InlineData(Reason.CorrectedReturn)]
    [InlineData(Reason.DuplicateEntry)]
    [InlineData(Reason.DuplicateReturn)]
    [InlineData(Reason.EnrDuplicateEnrollment)]
    [InlineData(Reason.EnrInvalidDfiAccountNumber)]
    [InlineData(Reason.EnrInvalidIndividualIDNumber)]
    [InlineData(Reason.EnrInvalidRepresentativePayeeIndicator)]
    [InlineData(Reason.EnrInvalidTransactionCode)]
    [InlineData(Reason.EnrReturnOfEnrEntry)]
    [InlineData(Reason.EnrRoutingNumberCheckDigitError)]
    [InlineData(Reason.EntryNotProcessedByGateway)]
    [InlineData(Reason.FieldError)]
    [InlineData(Reason.ForeignReceivingDfiUnableToSettle)]
    [InlineData(Reason.IatEntryCodingError)]
    [InlineData(Reason.ImproperEffectiveEntryDate)]
    [InlineData(Reason.ImproperSourceDocumentSourceDocumentPresented)]
    [InlineData(Reason.InvalidCompanyID)]
    [InlineData(Reason.InvalidForeignReceivingDfiIdentification)]
    [InlineData(Reason.InvalidIndividualIDNumber)]
    [InlineData(Reason.ItemAndRckEntryPresentedForPayment)]
    [InlineData(Reason.ItemRelatedToRckEntryIsIneligible)]
    [InlineData(Reason.MandatoryFieldError)]
    [InlineData(Reason.MisroutedDishonoredReturn)]
    [InlineData(Reason.MisroutedReturn)]
    [InlineData(Reason.NoErrorsFound)]
    [InlineData(Reason.NonAcceptanceOfR62DishonoredReturn)]
    [InlineData(Reason.NonParticipantInIatProgram)]
    [InlineData(Reason.PermissibleReturnEntry)]
    [InlineData(Reason.PermissibleReturnEntryNotAccepted)]
    [InlineData(Reason.RdfiNonSettlement)]
    [InlineData(Reason.RdfiParticipantInCheckTruncationProgram)]
    [InlineData(Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity)]
    [InlineData(Reason.ReturnNotADuplicate)]
    [InlineData(Reason.ReturnOfErroneousOrReversingDebit)]
    [InlineData(Reason.ReturnOfImproperCreditEntry)]
    [InlineData(Reason.ReturnOfImproperDebitEntry)]
    [InlineData(Reason.ReturnOfXckEntry)]
    [InlineData(Reason.SourceDocumentPresentedForPayment)]
    [InlineData(Reason.StateLawAffectingRckAcceptance)]
    [InlineData(Reason.StopPaymentOnItemRelatedToRckEntry)]
    [InlineData(Reason.StopPaymentOnSourceDocument)]
    [InlineData(Reason.TimelyOriginalReturn)]
    [InlineData(Reason.TraceNumberError)]
    [InlineData(Reason.UntimelyDishonoredReturn)]
    [InlineData(Reason.UntimelyReturn)]
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
    [InlineData(Reason.InsufficientFund)]
    [InlineData(Reason.NoAccount)]
    [InlineData(Reason.AccountClosed)]
    [InlineData(Reason.InvalidAccountNumberStructure)]
    [InlineData(Reason.AccountFrozenEntryReturnedPerOfacInstruction)]
    [InlineData(Reason.CreditEntryRefusedByReceiver)]
    [InlineData(Reason.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode)]
    [InlineData(Reason.CorporateCustomerAdvisedNotAuthorized)]
    [InlineData(Reason.PaymentStopped)]
    [InlineData(Reason.NonTransactionAccount)]
    [InlineData(Reason.UncollectedFunds)]
    [InlineData(Reason.RoutingNumberCheckDigitError)]
    [InlineData(Reason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete)]
    [InlineData(Reason.AmountFieldError)]
    [InlineData(Reason.AuthorizationRevokedByCustomer)]
    [InlineData(Reason.InvalidAchRoutingNumber)]
    [InlineData(Reason.FileRecordEditCriteria)]
    [InlineData(Reason.EnrInvalidIndividualName)]
    [InlineData(Reason.ReturnedPerOdfiRequest)]
    [InlineData(Reason.LimitedParticipationDfi)]
    [InlineData(Reason.IncorrectlyCodedOutboundInternationalPayment)]
    [InlineData(Reason.AccountSoldToAnotherDfi)]
    [InlineData(Reason.AddendaError)]
    [InlineData(Reason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(Reason.CustomerAdvisedNotWithinAuthorizationTerms)]
    [InlineData(Reason.CorrectedReturn)]
    [InlineData(Reason.DuplicateEntry)]
    [InlineData(Reason.DuplicateReturn)]
    [InlineData(Reason.EnrDuplicateEnrollment)]
    [InlineData(Reason.EnrInvalidDfiAccountNumber)]
    [InlineData(Reason.EnrInvalidIndividualIDNumber)]
    [InlineData(Reason.EnrInvalidRepresentativePayeeIndicator)]
    [InlineData(Reason.EnrInvalidTransactionCode)]
    [InlineData(Reason.EnrReturnOfEnrEntry)]
    [InlineData(Reason.EnrRoutingNumberCheckDigitError)]
    [InlineData(Reason.EntryNotProcessedByGateway)]
    [InlineData(Reason.FieldError)]
    [InlineData(Reason.ForeignReceivingDfiUnableToSettle)]
    [InlineData(Reason.IatEntryCodingError)]
    [InlineData(Reason.ImproperEffectiveEntryDate)]
    [InlineData(Reason.ImproperSourceDocumentSourceDocumentPresented)]
    [InlineData(Reason.InvalidCompanyID)]
    [InlineData(Reason.InvalidForeignReceivingDfiIdentification)]
    [InlineData(Reason.InvalidIndividualIDNumber)]
    [InlineData(Reason.ItemAndRckEntryPresentedForPayment)]
    [InlineData(Reason.ItemRelatedToRckEntryIsIneligible)]
    [InlineData(Reason.MandatoryFieldError)]
    [InlineData(Reason.MisroutedDishonoredReturn)]
    [InlineData(Reason.MisroutedReturn)]
    [InlineData(Reason.NoErrorsFound)]
    [InlineData(Reason.NonAcceptanceOfR62DishonoredReturn)]
    [InlineData(Reason.NonParticipantInIatProgram)]
    [InlineData(Reason.PermissibleReturnEntry)]
    [InlineData(Reason.PermissibleReturnEntryNotAccepted)]
    [InlineData(Reason.RdfiNonSettlement)]
    [InlineData(Reason.RdfiParticipantInCheckTruncationProgram)]
    [InlineData(Reason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity)]
    [InlineData(Reason.ReturnNotADuplicate)]
    [InlineData(Reason.ReturnOfErroneousOrReversingDebit)]
    [InlineData(Reason.ReturnOfImproperCreditEntry)]
    [InlineData(Reason.ReturnOfImproperDebitEntry)]
    [InlineData(Reason.ReturnOfXckEntry)]
    [InlineData(Reason.SourceDocumentPresentedForPayment)]
    [InlineData(Reason.StateLawAffectingRckAcceptance)]
    [InlineData(Reason.StopPaymentOnItemRelatedToRckEntry)]
    [InlineData(Reason.StopPaymentOnSourceDocument)]
    [InlineData(Reason.TimelyOriginalReturn)]
    [InlineData(Reason.TraceNumberError)]
    [InlineData(Reason.UntimelyDishonoredReturn)]
    [InlineData(Reason.UntimelyReturn)]
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
