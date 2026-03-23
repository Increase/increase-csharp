using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using AchPrenotifications = Increase.Api.Models.AchPrenotifications;

namespace Increase.Api.Tests.Models.AchPrenotifications;

public class AchPrenotificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchPrenotifications::AchPrenotification
        {
            ID = "ach_prenotification_ubjf9qqsxl3obbcn1u34",
            AccountID = null,
            AccountNumber = "987654321",
            Addendum = null,
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyName = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditDebitIndicator = null,
            EffectiveDate = null,
            IdempotencyKey = null,
            IndividualID = null,
            IndividualName = null,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PrenotificationReturn = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ReturnReasonCode =
                    AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
            },
            RoutingNumber = "101050001",
            StandardEntryClassCode = null,
            Status = AchPrenotifications::Status.Submitted,
            Type = AchPrenotifications::Type.AchPrenotification,
        };

        string expectedID = "ach_prenotification_ubjf9qqsxl3obbcn1u34";
        string expectedAccountNumber = "987654321";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        List<AchPrenotifications::NotificationsOfChange> expectedNotificationsOfChange =
        [
            new()
            {
                ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
                CorrectedData = "32",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
        ];
        AchPrenotifications::PrenotificationReturn expectedPrenotificationReturn = new()
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ReturnReasonCode =
                AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
        };
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, AchPrenotifications::Status> expectedStatus =
            AchPrenotifications::Status.Submitted;
        ApiEnum<string, AchPrenotifications::Type> expectedType =
            AchPrenotifications::Type.AchPrenotification;

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.AccountID);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Null(model.Addendum);
        Assert.Null(model.CompanyDescriptiveDate);
        Assert.Null(model.CompanyDiscretionaryData);
        Assert.Null(model.CompanyEntryDescription);
        Assert.Null(model.CompanyName);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.CreditDebitIndicator);
        Assert.Null(model.EffectiveDate);
        Assert.Null(model.IdempotencyKey);
        Assert.Null(model.IndividualID);
        Assert.Null(model.IndividualName);
        Assert.Equal(expectedNotificationsOfChange.Count, model.NotificationsOfChange.Count);
        for (int i = 0; i < expectedNotificationsOfChange.Count; i++)
        {
            Assert.Equal(expectedNotificationsOfChange[i], model.NotificationsOfChange[i]);
        }
        Assert.Equal(expectedPrenotificationReturn, model.PrenotificationReturn);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Null(model.StandardEntryClassCode);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchPrenotifications::AchPrenotification
        {
            ID = "ach_prenotification_ubjf9qqsxl3obbcn1u34",
            AccountID = null,
            AccountNumber = "987654321",
            Addendum = null,
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyName = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditDebitIndicator = null,
            EffectiveDate = null,
            IdempotencyKey = null,
            IndividualID = null,
            IndividualName = null,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PrenotificationReturn = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ReturnReasonCode =
                    AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
            },
            RoutingNumber = "101050001",
            StandardEntryClassCode = null,
            Status = AchPrenotifications::Status.Submitted,
            Type = AchPrenotifications::Type.AchPrenotification,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchPrenotifications::AchPrenotification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchPrenotifications::AchPrenotification
        {
            ID = "ach_prenotification_ubjf9qqsxl3obbcn1u34",
            AccountID = null,
            AccountNumber = "987654321",
            Addendum = null,
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyName = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditDebitIndicator = null,
            EffectiveDate = null,
            IdempotencyKey = null,
            IndividualID = null,
            IndividualName = null,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PrenotificationReturn = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ReturnReasonCode =
                    AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
            },
            RoutingNumber = "101050001",
            StandardEntryClassCode = null,
            Status = AchPrenotifications::Status.Submitted,
            Type = AchPrenotifications::Type.AchPrenotification,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchPrenotifications::AchPrenotification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ach_prenotification_ubjf9qqsxl3obbcn1u34";
        string expectedAccountNumber = "987654321";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        List<AchPrenotifications::NotificationsOfChange> expectedNotificationsOfChange =
        [
            new()
            {
                ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
                CorrectedData = "32",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
        ];
        AchPrenotifications::PrenotificationReturn expectedPrenotificationReturn = new()
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ReturnReasonCode =
                AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
        };
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, AchPrenotifications::Status> expectedStatus =
            AchPrenotifications::Status.Submitted;
        ApiEnum<string, AchPrenotifications::Type> expectedType =
            AchPrenotifications::Type.AchPrenotification;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.AccountID);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Null(deserialized.Addendum);
        Assert.Null(deserialized.CompanyDescriptiveDate);
        Assert.Null(deserialized.CompanyDiscretionaryData);
        Assert.Null(deserialized.CompanyEntryDescription);
        Assert.Null(deserialized.CompanyName);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.CreditDebitIndicator);
        Assert.Null(deserialized.EffectiveDate);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Null(deserialized.IndividualID);
        Assert.Null(deserialized.IndividualName);
        Assert.Equal(expectedNotificationsOfChange.Count, deserialized.NotificationsOfChange.Count);
        for (int i = 0; i < expectedNotificationsOfChange.Count; i++)
        {
            Assert.Equal(expectedNotificationsOfChange[i], deserialized.NotificationsOfChange[i]);
        }
        Assert.Equal(expectedPrenotificationReturn, deserialized.PrenotificationReturn);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Null(deserialized.StandardEntryClassCode);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchPrenotifications::AchPrenotification
        {
            ID = "ach_prenotification_ubjf9qqsxl3obbcn1u34",
            AccountID = null,
            AccountNumber = "987654321",
            Addendum = null,
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyName = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditDebitIndicator = null,
            EffectiveDate = null,
            IdempotencyKey = null,
            IndividualID = null,
            IndividualName = null,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PrenotificationReturn = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ReturnReasonCode =
                    AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
            },
            RoutingNumber = "101050001",
            StandardEntryClassCode = null,
            Status = AchPrenotifications::Status.Submitted,
            Type = AchPrenotifications::Type.AchPrenotification,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchPrenotifications::AchPrenotification
        {
            ID = "ach_prenotification_ubjf9qqsxl3obbcn1u34",
            AccountID = null,
            AccountNumber = "987654321",
            Addendum = null,
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyName = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditDebitIndicator = null,
            EffectiveDate = null,
            IdempotencyKey = null,
            IndividualID = null,
            IndividualName = null,
            NotificationsOfChange =
            [
                new()
                {
                    ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
                    CorrectedData = "32",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            PrenotificationReturn = new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ReturnReasonCode =
                    AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
            },
            RoutingNumber = "101050001",
            StandardEntryClassCode = null,
            Status = AchPrenotifications::Status.Submitted,
            Type = AchPrenotifications::Type.AchPrenotification,
        };

        AchPrenotifications::AchPrenotification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchPrenotificationCreditDebitIndicatorTest : TestBase
{
    [Theory]
    [InlineData(AchPrenotifications::AchPrenotificationCreditDebitIndicator.Credit)]
    [InlineData(AchPrenotifications::AchPrenotificationCreditDebitIndicator.Debit)]
    public void Validation_Works(
        AchPrenotifications::AchPrenotificationCreditDebitIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::AchPrenotificationCreditDebitIndicator> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::AchPrenotificationCreditDebitIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchPrenotifications::AchPrenotificationCreditDebitIndicator.Credit)]
    [InlineData(AchPrenotifications::AchPrenotificationCreditDebitIndicator.Debit)]
    public void SerializationRoundtrip_Works(
        AchPrenotifications::AchPrenotificationCreditDebitIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::AchPrenotificationCreditDebitIndicator> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::AchPrenotificationCreditDebitIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::AchPrenotificationCreditDebitIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::AchPrenotificationCreditDebitIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NotificationsOfChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchPrenotifications::NotificationsOfChange
        {
            ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        ApiEnum<string, AchPrenotifications::ChangeCode> expectedChangeCode =
            AchPrenotifications::ChangeCode.IncorrectTransactionCode;
        string expectedCorrectedData = "32";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedChangeCode, model.ChangeCode);
        Assert.Equal(expectedCorrectedData, model.CorrectedData);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchPrenotifications::NotificationsOfChange
        {
            ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchPrenotifications::NotificationsOfChange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchPrenotifications::NotificationsOfChange
        {
            ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchPrenotifications::NotificationsOfChange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AchPrenotifications::ChangeCode> expectedChangeCode =
            AchPrenotifications::ChangeCode.IncorrectTransactionCode;
        string expectedCorrectedData = "32";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedChangeCode, deserialized.ChangeCode);
        Assert.Equal(expectedCorrectedData, deserialized.CorrectedData);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchPrenotifications::NotificationsOfChange
        {
            ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchPrenotifications::NotificationsOfChange
        {
            ChangeCode = AchPrenotifications::ChangeCode.IncorrectTransactionCode,
            CorrectedData = "32",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        AchPrenotifications::NotificationsOfChange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChangeCodeTest : TestBase
{
    [Theory]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectAccountNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectRoutingNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectRoutingNumberAndAccountNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectTransactionCode)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectAccountNumberAndTransactionCode)]
    [InlineData(
        AchPrenotifications::ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode
    )]
    [InlineData(
        AchPrenotifications::ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification
    )]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectIndividualIdentificationNumber)]
    [InlineData(AchPrenotifications::ChangeCode.AddendaFormatError)]
    [InlineData(
        AchPrenotifications::ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment
    )]
    [InlineData(AchPrenotifications::ChangeCode.MisroutedNotificationOfChange)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectTraceNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectCompanyIdentificationNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectIdentificationNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectlyFormattedCorrectedData)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectDiscretionaryData)]
    [InlineData(AchPrenotifications::ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord)]
    [InlineData(
        AchPrenotifications::ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord
    )]
    [InlineData(
        AchPrenotifications::ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution
    )]
    public void Validation_Works(AchPrenotifications::ChangeCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::ChangeCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::ChangeCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectAccountNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectRoutingNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectRoutingNumberAndAccountNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectTransactionCode)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectAccountNumberAndTransactionCode)]
    [InlineData(
        AchPrenotifications::ChangeCode.IncorrectRoutingNumberAccountNumberAndTransactionCode
    )]
    [InlineData(
        AchPrenotifications::ChangeCode.IncorrectReceivingDepositoryFinancialInstitutionIdentification
    )]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectIndividualIdentificationNumber)]
    [InlineData(AchPrenotifications::ChangeCode.AddendaFormatError)]
    [InlineData(
        AchPrenotifications::ChangeCode.IncorrectStandardEntryClassCodeForOutboundInternationalPayment
    )]
    [InlineData(AchPrenotifications::ChangeCode.MisroutedNotificationOfChange)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectTraceNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectCompanyIdentificationNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectIdentificationNumber)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectlyFormattedCorrectedData)]
    [InlineData(AchPrenotifications::ChangeCode.IncorrectDiscretionaryData)]
    [InlineData(AchPrenotifications::ChangeCode.RoutingNumberNotFromOriginalEntryDetailRecord)]
    [InlineData(
        AchPrenotifications::ChangeCode.DepositoryFinancialInstitutionAccountNumberNotFromOriginalEntryDetailRecord
    )]
    [InlineData(
        AchPrenotifications::ChangeCode.IncorrectTransactionCodeByOriginatingDepositoryFinancialInstitution
    )]
    public void SerializationRoundtrip_Works(AchPrenotifications::ChangeCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::ChangeCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::ChangeCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::ChangeCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::ChangeCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PrenotificationReturnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchPrenotifications::PrenotificationReturn
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ReturnReasonCode =
                AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, AchPrenotifications::ReturnReasonCode> expectedReturnReasonCode =
            AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized;

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedReturnReasonCode, model.ReturnReasonCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchPrenotifications::PrenotificationReturn
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ReturnReasonCode =
                AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchPrenotifications::PrenotificationReturn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchPrenotifications::PrenotificationReturn
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ReturnReasonCode =
                AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AchPrenotifications::PrenotificationReturn>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, AchPrenotifications::ReturnReasonCode> expectedReturnReasonCode =
            AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized;

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedReturnReasonCode, deserialized.ReturnReasonCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchPrenotifications::PrenotificationReturn
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ReturnReasonCode =
                AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchPrenotifications::PrenotificationReturn
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ReturnReasonCode =
                AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized,
        };

        AchPrenotifications::PrenotificationReturn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReturnReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(AchPrenotifications::ReturnReasonCode.InsufficientFund)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NoAccount)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AccountClosed)]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidAccountNumberStructure)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction)]
    [InlineData(AchPrenotifications::ReturnReasonCode.CreditEntryRefusedByReceiver)]
    [InlineData(
        AchPrenotifications::ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode
    )]
    [InlineData(AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized)]
    [InlineData(AchPrenotifications::ReturnReasonCode.PaymentStopped)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NonTransactionAccount)]
    [InlineData(AchPrenotifications::ReturnReasonCode.UncollectedFunds)]
    [InlineData(AchPrenotifications::ReturnReasonCode.RoutingNumberCheckDigitError)]
    [InlineData(
        AchPrenotifications::ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(AchPrenotifications::ReturnReasonCode.AmountFieldError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AuthorizationRevokedByCustomer)]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidAchRoutingNumber)]
    [InlineData(AchPrenotifications::ReturnReasonCode.FileRecordEditCriteria)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidIndividualName)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnedPerOdfiRequest)]
    [InlineData(AchPrenotifications::ReturnReasonCode.LimitedParticipationDfi)]
    [InlineData(AchPrenotifications::ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AccountSoldToAnotherDfi)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AddendaError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(AchPrenotifications::ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms)]
    [InlineData(AchPrenotifications::ReturnReasonCode.CorrectedReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.DuplicateEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.DuplicateReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrDuplicateEnrollment)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidDfiAccountNumber)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidIndividualIDNumber)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidTransactionCode)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrReturnOfEnrEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrRoutingNumberCheckDigitError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EntryNotProcessedByGateway)]
    [InlineData(AchPrenotifications::ReturnReasonCode.FieldError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ForeignReceivingDfiUnableToSettle)]
    [InlineData(AchPrenotifications::ReturnReasonCode.IatEntryCodingError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ImproperEffectiveEntryDate)]
    [InlineData(
        AchPrenotifications::ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented
    )]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidCompanyID)]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidForeignReceivingDfiIdentification)]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidIndividualIDNumber)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ItemAndRckEntryPresentedForPayment)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ItemRelatedToRckEntryIsIneligible)]
    [InlineData(AchPrenotifications::ReturnReasonCode.MandatoryFieldError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.MisroutedDishonoredReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.MisroutedReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NoErrorsFound)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NonParticipantInIatProgram)]
    [InlineData(AchPrenotifications::ReturnReasonCode.PermissibleReturnEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.PermissibleReturnEntryNotAccepted)]
    [InlineData(AchPrenotifications::ReturnReasonCode.RdfiNonSettlement)]
    [InlineData(AchPrenotifications::ReturnReasonCode.RdfiParticipantInCheckTruncationProgram)]
    [InlineData(
        AchPrenotifications::ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnNotADuplicate)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnOfErroneousOrReversingDebit)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnOfImproperCreditEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnOfImproperDebitEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnOfXckEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.SourceDocumentPresentedForPayment)]
    [InlineData(AchPrenotifications::ReturnReasonCode.StateLawAffectingRckAcceptance)]
    [InlineData(AchPrenotifications::ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.StopPaymentOnSourceDocument)]
    [InlineData(AchPrenotifications::ReturnReasonCode.TimelyOriginalReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.TraceNumberError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.UntimelyDishonoredReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.UntimelyReturn)]
    public void Validation_Works(AchPrenotifications::ReturnReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::ReturnReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::ReturnReasonCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchPrenotifications::ReturnReasonCode.InsufficientFund)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NoAccount)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AccountClosed)]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidAccountNumberStructure)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AccountFrozenEntryReturnedPerOfacInstruction)]
    [InlineData(AchPrenotifications::ReturnReasonCode.CreditEntryRefusedByReceiver)]
    [InlineData(
        AchPrenotifications::ReturnReasonCode.UnauthorizedDebitToConsumerAccountUsingCorporateSecCode
    )]
    [InlineData(AchPrenotifications::ReturnReasonCode.CorporateCustomerAdvisedNotAuthorized)]
    [InlineData(AchPrenotifications::ReturnReasonCode.PaymentStopped)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NonTransactionAccount)]
    [InlineData(AchPrenotifications::ReturnReasonCode.UncollectedFunds)]
    [InlineData(AchPrenotifications::ReturnReasonCode.RoutingNumberCheckDigitError)]
    [InlineData(
        AchPrenotifications::ReturnReasonCode.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(AchPrenotifications::ReturnReasonCode.AmountFieldError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AuthorizationRevokedByCustomer)]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidAchRoutingNumber)]
    [InlineData(AchPrenotifications::ReturnReasonCode.FileRecordEditCriteria)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidIndividualName)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnedPerOdfiRequest)]
    [InlineData(AchPrenotifications::ReturnReasonCode.LimitedParticipationDfi)]
    [InlineData(AchPrenotifications::ReturnReasonCode.IncorrectlyCodedOutboundInternationalPayment)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AccountSoldToAnotherDfi)]
    [InlineData(AchPrenotifications::ReturnReasonCode.AddendaError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(AchPrenotifications::ReturnReasonCode.CustomerAdvisedNotWithinAuthorizationTerms)]
    [InlineData(AchPrenotifications::ReturnReasonCode.CorrectedReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.DuplicateEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.DuplicateReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrDuplicateEnrollment)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidDfiAccountNumber)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidIndividualIDNumber)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidRepresentativePayeeIndicator)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrInvalidTransactionCode)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrReturnOfEnrEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EnrRoutingNumberCheckDigitError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.EntryNotProcessedByGateway)]
    [InlineData(AchPrenotifications::ReturnReasonCode.FieldError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ForeignReceivingDfiUnableToSettle)]
    [InlineData(AchPrenotifications::ReturnReasonCode.IatEntryCodingError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ImproperEffectiveEntryDate)]
    [InlineData(
        AchPrenotifications::ReturnReasonCode.ImproperSourceDocumentSourceDocumentPresented
    )]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidCompanyID)]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidForeignReceivingDfiIdentification)]
    [InlineData(AchPrenotifications::ReturnReasonCode.InvalidIndividualIDNumber)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ItemAndRckEntryPresentedForPayment)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ItemRelatedToRckEntryIsIneligible)]
    [InlineData(AchPrenotifications::ReturnReasonCode.MandatoryFieldError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.MisroutedDishonoredReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.MisroutedReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NoErrorsFound)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NonAcceptanceOfR62DishonoredReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.NonParticipantInIatProgram)]
    [InlineData(AchPrenotifications::ReturnReasonCode.PermissibleReturnEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.PermissibleReturnEntryNotAccepted)]
    [InlineData(AchPrenotifications::ReturnReasonCode.RdfiNonSettlement)]
    [InlineData(AchPrenotifications::ReturnReasonCode.RdfiParticipantInCheckTruncationProgram)]
    [InlineData(
        AchPrenotifications::ReturnReasonCode.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnNotADuplicate)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnOfErroneousOrReversingDebit)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnOfImproperCreditEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnOfImproperDebitEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.ReturnOfXckEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.SourceDocumentPresentedForPayment)]
    [InlineData(AchPrenotifications::ReturnReasonCode.StateLawAffectingRckAcceptance)]
    [InlineData(AchPrenotifications::ReturnReasonCode.StopPaymentOnItemRelatedToRckEntry)]
    [InlineData(AchPrenotifications::ReturnReasonCode.StopPaymentOnSourceDocument)]
    [InlineData(AchPrenotifications::ReturnReasonCode.TimelyOriginalReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.TraceNumberError)]
    [InlineData(AchPrenotifications::ReturnReasonCode.UntimelyDishonoredReturn)]
    [InlineData(AchPrenotifications::ReturnReasonCode.UntimelyReturn)]
    public void SerializationRoundtrip_Works(AchPrenotifications::ReturnReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::ReturnReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::ReturnReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::ReturnReasonCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::ReturnReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AchPrenotificationStandardEntryClassCodeTest : TestBase
{
    [Theory]
    [InlineData(
        AchPrenotifications::AchPrenotificationStandardEntryClassCode.CorporateCreditOrDebit
    )]
    [InlineData(
        AchPrenotifications::AchPrenotificationStandardEntryClassCode.CorporateTradeExchange
    )]
    [InlineData(
        AchPrenotifications::AchPrenotificationStandardEntryClassCode.PrearrangedPaymentsAndDeposit
    )]
    [InlineData(AchPrenotifications::AchPrenotificationStandardEntryClassCode.InternetInitiated)]
    public void Validation_Works(
        AchPrenotifications::AchPrenotificationStandardEntryClassCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::AchPrenotificationStandardEntryClassCode> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::AchPrenotificationStandardEntryClassCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        AchPrenotifications::AchPrenotificationStandardEntryClassCode.CorporateCreditOrDebit
    )]
    [InlineData(
        AchPrenotifications::AchPrenotificationStandardEntryClassCode.CorporateTradeExchange
    )]
    [InlineData(
        AchPrenotifications::AchPrenotificationStandardEntryClassCode.PrearrangedPaymentsAndDeposit
    )]
    [InlineData(AchPrenotifications::AchPrenotificationStandardEntryClassCode.InternetInitiated)]
    public void SerializationRoundtrip_Works(
        AchPrenotifications::AchPrenotificationStandardEntryClassCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::AchPrenotificationStandardEntryClassCode> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::AchPrenotificationStandardEntryClassCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::AchPrenotificationStandardEntryClassCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AchPrenotifications::AchPrenotificationStandardEntryClassCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(AchPrenotifications::Status.PendingSubmitting)]
    [InlineData(AchPrenotifications::Status.RequiresAttention)]
    [InlineData(AchPrenotifications::Status.Returned)]
    [InlineData(AchPrenotifications::Status.Submitted)]
    public void Validation_Works(AchPrenotifications::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchPrenotifications::Status.PendingSubmitting)]
    [InlineData(AchPrenotifications::Status.RequiresAttention)]
    [InlineData(AchPrenotifications::Status.Returned)]
    [InlineData(AchPrenotifications::Status.Submitted)]
    public void SerializationRoundtrip_Works(AchPrenotifications::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(AchPrenotifications::Type.AchPrenotification)]
    public void Validation_Works(AchPrenotifications::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AchPrenotifications::Type.AchPrenotification)]
    public void SerializationRoundtrip_Works(AchPrenotifications::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AchPrenotifications::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AchPrenotifications::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
