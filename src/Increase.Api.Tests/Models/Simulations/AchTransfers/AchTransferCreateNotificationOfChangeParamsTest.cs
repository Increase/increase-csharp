using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.AchTransfers;

namespace Increase.Api.Tests.Models.Simulations.AchTransfers;

public class AchTransferCreateNotificationOfChangeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchTransferCreateNotificationOfChangeParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            ChangeCode = ChangeCode.IncorrectRoutingNumber,
            CorrectedData = "123456789",
        };

        string expectedAchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";
        ApiEnum<string, ChangeCode> expectedChangeCode = ChangeCode.IncorrectRoutingNumber;
        string expectedCorrectedData = "123456789";

        Assert.Equal(expectedAchTransferID, parameters.AchTransferID);
        Assert.Equal(expectedChangeCode, parameters.ChangeCode);
        Assert.Equal(expectedCorrectedData, parameters.CorrectedData);
    }

    [Fact]
    public void Url_Works()
    {
        AchTransferCreateNotificationOfChangeParams parameters = new()
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            ChangeCode = ChangeCode.IncorrectRoutingNumber,
            CorrectedData = "123456789",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/ach_transfers/ach_transfer_uoxatyh3lt5evrsdvo7q/create_notification_of_change"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchTransferCreateNotificationOfChangeParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            ChangeCode = ChangeCode.IncorrectRoutingNumber,
            CorrectedData = "123456789",
        };

        AchTransferCreateNotificationOfChangeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChangeCodeTest : TestBase
{
    [Theory]
    [InlineData(ChangeCode.IncorrectAccountNumber)]
    [InlineData(ChangeCode.IncorrectRoutingNumber)]
    [InlineData(ChangeCode.IncorrectRoutingNumberAndAccountNumber)]
    [InlineData(ChangeCode.IncorrectTransactionCode)]
    [InlineData(ChangeCode.IncorrectAccountNumberAndTransactionCode)]
    [InlineData(ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode)]
    [InlineData(ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification)]
    [InlineData(ChangeCode.IncorrectIndividualIdentificationNumber)]
    [InlineData(ChangeCode.AddendaFormatError)]
    [InlineData(ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment)]
    [InlineData(ChangeCode.MisroutedNotificationOfChange)]
    [InlineData(ChangeCode.IncorrectTraceNumber)]
    [InlineData(ChangeCode.IncorrectCompanyIdentificationNumber)]
    [InlineData(ChangeCode.IncorrectIdentificationNumber)]
    [InlineData(ChangeCode.IncorrectlyFormattedCorrectedData)]
    [InlineData(ChangeCode.IncorrectDiscretionaryData)]
    [InlineData(ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord)]
    [InlineData(
        ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord
    )]
    [InlineData(ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution)]
    public void Validation_Works(ChangeCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChangeCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChangeCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChangeCode.IncorrectAccountNumber)]
    [InlineData(ChangeCode.IncorrectRoutingNumber)]
    [InlineData(ChangeCode.IncorrectRoutingNumberAndAccountNumber)]
    [InlineData(ChangeCode.IncorrectTransactionCode)]
    [InlineData(ChangeCode.IncorrectAccountNumberAndTransactionCode)]
    [InlineData(ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode)]
    [InlineData(ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification)]
    [InlineData(ChangeCode.IncorrectIndividualIdentificationNumber)]
    [InlineData(ChangeCode.AddendaFormatError)]
    [InlineData(ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment)]
    [InlineData(ChangeCode.MisroutedNotificationOfChange)]
    [InlineData(ChangeCode.IncorrectTraceNumber)]
    [InlineData(ChangeCode.IncorrectCompanyIdentificationNumber)]
    [InlineData(ChangeCode.IncorrectIdentificationNumber)]
    [InlineData(ChangeCode.IncorrectlyFormattedCorrectedData)]
    [InlineData(ChangeCode.IncorrectDiscretionaryData)]
    [InlineData(ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord)]
    [InlineData(
        ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord
    )]
    [InlineData(ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution)]
    public void SerializationRoundtrip_Works(ChangeCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChangeCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChangeCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChangeCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChangeCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
