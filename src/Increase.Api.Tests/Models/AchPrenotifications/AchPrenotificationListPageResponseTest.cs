using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using AchPrenotifications = Increase.Api.Models.AchPrenotifications;

namespace Increase.Api.Tests.Models.AchPrenotifications;

public class AchPrenotificationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AchPrenotifications::AchPrenotificationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<AchPrenotifications::AchPrenotification> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AchPrenotifications::AchPrenotificationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchPrenotifications::AchPrenotificationListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AchPrenotifications::AchPrenotificationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AchPrenotifications::AchPrenotificationListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<AchPrenotifications::AchPrenotification> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AchPrenotifications::AchPrenotificationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AchPrenotifications::AchPrenotificationListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        AchPrenotifications::AchPrenotificationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
