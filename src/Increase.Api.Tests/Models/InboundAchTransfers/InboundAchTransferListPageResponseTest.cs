using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using InboundAchTransfers = Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Tests.Models.InboundAchTransfers;

public class InboundAchTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::InboundAchTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Addenda = new()
                    {
                        Category = InboundAchTransfers::Category.Freeform,
                        Freeform = new([new("payment_related_information")]),
                    },
                    Amount = 100,
                    AutomaticallyResolvesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DeclinedTransactionID = "declined_transaction_id",
                        Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
                    },
                    Direction = InboundAchTransfers::Direction.Credit,
                    EffectiveDate = "2023-04-02",
                    InternationalAddenda = new()
                    {
                        DestinationCountryCode = "US",
                        DestinationCurrencyCode = "USD",
                        ForeignExchangeIndicator =
                            InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
                        ForeignExchangeReference = null,
                        ForeignExchangeReferenceIndicator =
                            InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank,
                        ForeignPaymentAmount = 199,
                        ForeignTraceNumber = null,
                        InternationalTransactionTypeCode =
                            InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated,
                        OriginatingCurrencyCode = "USD",
                        OriginatingDepositoryFinancialInstitutionBranchCountry = "US",
                        OriginatingDepositoryFinancialInstitutionID = "091000019",
                        OriginatingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        OriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK",
                        OriginatorCity = "BERLIN",
                        OriginatorCountry = "DE",
                        OriginatorIdentification = "770510487A",
                        OriginatorName = "BERGHAIN",
                        OriginatorPostalCode = "50825",
                        OriginatorStateOrProvince = null,
                        OriginatorStreetAddress = "Ruedersdorferstr. 7",
                        PaymentRelatedInformation = null,
                        PaymentRelatedInformation2 = null,
                        ReceiverCity = "BEVERLY HILLS",
                        ReceiverCountry = "US",
                        ReceiverIdentificationNumber = "1018790279274",
                        ReceiverPostalCode = "90210",
                        ReceiverStateOrProvince = "CA",
                        ReceiverStreetAddress = "123 FAKE ST",
                        ReceivingCompanyOrIndividualName = "IAN CREASE",
                        ReceivingDepositoryFinancialInstitutionCountry = "US",
                        ReceivingDepositoryFinancialInstitutionID = "101050001",
                        ReceivingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        ReceivingDepositoryFinancialInstitutionName =
                            "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
                    },
                    NotificationOfChange = new()
                    {
                        UpdatedAccountNumber = "updated_account_number",
                        UpdatedRoutingNumber = "updated_routing_number",
                    },
                    OriginatorCompanyDescriptiveDate = "230401",
                    OriginatorCompanyDiscretionaryData = "WEB AUTOPAY",
                    OriginatorCompanyEntryDescription = "INVOICE 2468",
                    OriginatorCompanyID = "0987654321",
                    OriginatorCompanyName = "PAYROLL COMPANY",
                    OriginatorRoutingNumber = "101050001",
                    ReceiverIDNumber = null,
                    ReceiverName = "Ian Crease",
                    Settlement = new()
                    {
                        SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
                    },
                    StandardEntryClassCode =
                        InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
                    Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
                    TraceNumber = "021000038461022",
                    TransferReturn = new()
                    {
                        Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    Type = InboundAchTransfers::Type.InboundAchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<InboundAchTransfers::InboundAchTransfer> expectedData =
        [
            new()
            {
                ID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                Acceptance = new()
                {
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                },
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Addenda = new()
                {
                    Category = InboundAchTransfers::Category.Freeform,
                    Freeform = new([new("payment_related_information")]),
                },
                Amount = 100,
                AutomaticallyResolvesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Decline = new()
                {
                    DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeclinedTransactionID = "declined_transaction_id",
                    Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
                },
                Direction = InboundAchTransfers::Direction.Credit,
                EffectiveDate = "2023-04-02",
                InternationalAddenda = new()
                {
                    DestinationCountryCode = "US",
                    DestinationCurrencyCode = "USD",
                    ForeignExchangeIndicator =
                        InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
                    ForeignExchangeReference = null,
                    ForeignExchangeReferenceIndicator =
                        InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank,
                    ForeignPaymentAmount = 199,
                    ForeignTraceNumber = null,
                    InternationalTransactionTypeCode =
                        InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated,
                    OriginatingCurrencyCode = "USD",
                    OriginatingDepositoryFinancialInstitutionBranchCountry = "US",
                    OriginatingDepositoryFinancialInstitutionID = "091000019",
                    OriginatingDepositoryFinancialInstitutionIDQualifier =
                        InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                    OriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK",
                    OriginatorCity = "BERLIN",
                    OriginatorCountry = "DE",
                    OriginatorIdentification = "770510487A",
                    OriginatorName = "BERGHAIN",
                    OriginatorPostalCode = "50825",
                    OriginatorStateOrProvince = null,
                    OriginatorStreetAddress = "Ruedersdorferstr. 7",
                    PaymentRelatedInformation = null,
                    PaymentRelatedInformation2 = null,
                    ReceiverCity = "BEVERLY HILLS",
                    ReceiverCountry = "US",
                    ReceiverIdentificationNumber = "1018790279274",
                    ReceiverPostalCode = "90210",
                    ReceiverStateOrProvince = "CA",
                    ReceiverStreetAddress = "123 FAKE ST",
                    ReceivingCompanyOrIndividualName = "IAN CREASE",
                    ReceivingDepositoryFinancialInstitutionCountry = "US",
                    ReceivingDepositoryFinancialInstitutionID = "101050001",
                    ReceivingDepositoryFinancialInstitutionIDQualifier =
                        InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                    ReceivingDepositoryFinancialInstitutionName =
                        "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
                },
                NotificationOfChange = new()
                {
                    UpdatedAccountNumber = "updated_account_number",
                    UpdatedRoutingNumber = "updated_routing_number",
                },
                OriginatorCompanyDescriptiveDate = "230401",
                OriginatorCompanyDiscretionaryData = "WEB AUTOPAY",
                OriginatorCompanyEntryDescription = "INVOICE 2468",
                OriginatorCompanyID = "0987654321",
                OriginatorCompanyName = "PAYROLL COMPANY",
                OriginatorRoutingNumber = "101050001",
                ReceiverIDNumber = null,
                ReceiverName = "Ian Crease",
                Settlement = new()
                {
                    SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
                },
                StandardEntryClassCode =
                    InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
                Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
                TraceNumber = "021000038461022",
                TransferReturn = new()
                {
                    Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                    ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransactionID = "transaction_id",
                },
                Type = InboundAchTransfers::Type.InboundAchTransfer,
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
        var model = new InboundAchTransfers::InboundAchTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Addenda = new()
                    {
                        Category = InboundAchTransfers::Category.Freeform,
                        Freeform = new([new("payment_related_information")]),
                    },
                    Amount = 100,
                    AutomaticallyResolvesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DeclinedTransactionID = "declined_transaction_id",
                        Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
                    },
                    Direction = InboundAchTransfers::Direction.Credit,
                    EffectiveDate = "2023-04-02",
                    InternationalAddenda = new()
                    {
                        DestinationCountryCode = "US",
                        DestinationCurrencyCode = "USD",
                        ForeignExchangeIndicator =
                            InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
                        ForeignExchangeReference = null,
                        ForeignExchangeReferenceIndicator =
                            InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank,
                        ForeignPaymentAmount = 199,
                        ForeignTraceNumber = null,
                        InternationalTransactionTypeCode =
                            InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated,
                        OriginatingCurrencyCode = "USD",
                        OriginatingDepositoryFinancialInstitutionBranchCountry = "US",
                        OriginatingDepositoryFinancialInstitutionID = "091000019",
                        OriginatingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        OriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK",
                        OriginatorCity = "BERLIN",
                        OriginatorCountry = "DE",
                        OriginatorIdentification = "770510487A",
                        OriginatorName = "BERGHAIN",
                        OriginatorPostalCode = "50825",
                        OriginatorStateOrProvince = null,
                        OriginatorStreetAddress = "Ruedersdorferstr. 7",
                        PaymentRelatedInformation = null,
                        PaymentRelatedInformation2 = null,
                        ReceiverCity = "BEVERLY HILLS",
                        ReceiverCountry = "US",
                        ReceiverIdentificationNumber = "1018790279274",
                        ReceiverPostalCode = "90210",
                        ReceiverStateOrProvince = "CA",
                        ReceiverStreetAddress = "123 FAKE ST",
                        ReceivingCompanyOrIndividualName = "IAN CREASE",
                        ReceivingDepositoryFinancialInstitutionCountry = "US",
                        ReceivingDepositoryFinancialInstitutionID = "101050001",
                        ReceivingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        ReceivingDepositoryFinancialInstitutionName =
                            "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
                    },
                    NotificationOfChange = new()
                    {
                        UpdatedAccountNumber = "updated_account_number",
                        UpdatedRoutingNumber = "updated_routing_number",
                    },
                    OriginatorCompanyDescriptiveDate = "230401",
                    OriginatorCompanyDiscretionaryData = "WEB AUTOPAY",
                    OriginatorCompanyEntryDescription = "INVOICE 2468",
                    OriginatorCompanyID = "0987654321",
                    OriginatorCompanyName = "PAYROLL COMPANY",
                    OriginatorRoutingNumber = "101050001",
                    ReceiverIDNumber = null,
                    ReceiverName = "Ian Crease",
                    Settlement = new()
                    {
                        SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
                    },
                    StandardEntryClassCode =
                        InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
                    Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
                    TraceNumber = "021000038461022",
                    TransferReturn = new()
                    {
                        Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    Type = InboundAchTransfers::Type.InboundAchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundAchTransfers::InboundAchTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::InboundAchTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Addenda = new()
                    {
                        Category = InboundAchTransfers::Category.Freeform,
                        Freeform = new([new("payment_related_information")]),
                    },
                    Amount = 100,
                    AutomaticallyResolvesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DeclinedTransactionID = "declined_transaction_id",
                        Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
                    },
                    Direction = InboundAchTransfers::Direction.Credit,
                    EffectiveDate = "2023-04-02",
                    InternationalAddenda = new()
                    {
                        DestinationCountryCode = "US",
                        DestinationCurrencyCode = "USD",
                        ForeignExchangeIndicator =
                            InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
                        ForeignExchangeReference = null,
                        ForeignExchangeReferenceIndicator =
                            InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank,
                        ForeignPaymentAmount = 199,
                        ForeignTraceNumber = null,
                        InternationalTransactionTypeCode =
                            InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated,
                        OriginatingCurrencyCode = "USD",
                        OriginatingDepositoryFinancialInstitutionBranchCountry = "US",
                        OriginatingDepositoryFinancialInstitutionID = "091000019",
                        OriginatingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        OriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK",
                        OriginatorCity = "BERLIN",
                        OriginatorCountry = "DE",
                        OriginatorIdentification = "770510487A",
                        OriginatorName = "BERGHAIN",
                        OriginatorPostalCode = "50825",
                        OriginatorStateOrProvince = null,
                        OriginatorStreetAddress = "Ruedersdorferstr. 7",
                        PaymentRelatedInformation = null,
                        PaymentRelatedInformation2 = null,
                        ReceiverCity = "BEVERLY HILLS",
                        ReceiverCountry = "US",
                        ReceiverIdentificationNumber = "1018790279274",
                        ReceiverPostalCode = "90210",
                        ReceiverStateOrProvince = "CA",
                        ReceiverStreetAddress = "123 FAKE ST",
                        ReceivingCompanyOrIndividualName = "IAN CREASE",
                        ReceivingDepositoryFinancialInstitutionCountry = "US",
                        ReceivingDepositoryFinancialInstitutionID = "101050001",
                        ReceivingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        ReceivingDepositoryFinancialInstitutionName =
                            "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
                    },
                    NotificationOfChange = new()
                    {
                        UpdatedAccountNumber = "updated_account_number",
                        UpdatedRoutingNumber = "updated_routing_number",
                    },
                    OriginatorCompanyDescriptiveDate = "230401",
                    OriginatorCompanyDiscretionaryData = "WEB AUTOPAY",
                    OriginatorCompanyEntryDescription = "INVOICE 2468",
                    OriginatorCompanyID = "0987654321",
                    OriginatorCompanyName = "PAYROLL COMPANY",
                    OriginatorRoutingNumber = "101050001",
                    ReceiverIDNumber = null,
                    ReceiverName = "Ian Crease",
                    Settlement = new()
                    {
                        SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
                    },
                    StandardEntryClassCode =
                        InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
                    Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
                    TraceNumber = "021000038461022",
                    TransferReturn = new()
                    {
                        Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    Type = InboundAchTransfers::Type.InboundAchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundAchTransfers::InboundAchTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<InboundAchTransfers::InboundAchTransfer> expectedData =
        [
            new()
            {
                ID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                Acceptance = new()
                {
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                },
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Addenda = new()
                {
                    Category = InboundAchTransfers::Category.Freeform,
                    Freeform = new([new("payment_related_information")]),
                },
                Amount = 100,
                AutomaticallyResolvesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Decline = new()
                {
                    DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeclinedTransactionID = "declined_transaction_id",
                    Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
                },
                Direction = InboundAchTransfers::Direction.Credit,
                EffectiveDate = "2023-04-02",
                InternationalAddenda = new()
                {
                    DestinationCountryCode = "US",
                    DestinationCurrencyCode = "USD",
                    ForeignExchangeIndicator =
                        InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
                    ForeignExchangeReference = null,
                    ForeignExchangeReferenceIndicator =
                        InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank,
                    ForeignPaymentAmount = 199,
                    ForeignTraceNumber = null,
                    InternationalTransactionTypeCode =
                        InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated,
                    OriginatingCurrencyCode = "USD",
                    OriginatingDepositoryFinancialInstitutionBranchCountry = "US",
                    OriginatingDepositoryFinancialInstitutionID = "091000019",
                    OriginatingDepositoryFinancialInstitutionIDQualifier =
                        InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                    OriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK",
                    OriginatorCity = "BERLIN",
                    OriginatorCountry = "DE",
                    OriginatorIdentification = "770510487A",
                    OriginatorName = "BERGHAIN",
                    OriginatorPostalCode = "50825",
                    OriginatorStateOrProvince = null,
                    OriginatorStreetAddress = "Ruedersdorferstr. 7",
                    PaymentRelatedInformation = null,
                    PaymentRelatedInformation2 = null,
                    ReceiverCity = "BEVERLY HILLS",
                    ReceiverCountry = "US",
                    ReceiverIdentificationNumber = "1018790279274",
                    ReceiverPostalCode = "90210",
                    ReceiverStateOrProvince = "CA",
                    ReceiverStreetAddress = "123 FAKE ST",
                    ReceivingCompanyOrIndividualName = "IAN CREASE",
                    ReceivingDepositoryFinancialInstitutionCountry = "US",
                    ReceivingDepositoryFinancialInstitutionID = "101050001",
                    ReceivingDepositoryFinancialInstitutionIDQualifier =
                        InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                    ReceivingDepositoryFinancialInstitutionName =
                        "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
                },
                NotificationOfChange = new()
                {
                    UpdatedAccountNumber = "updated_account_number",
                    UpdatedRoutingNumber = "updated_routing_number",
                },
                OriginatorCompanyDescriptiveDate = "230401",
                OriginatorCompanyDiscretionaryData = "WEB AUTOPAY",
                OriginatorCompanyEntryDescription = "INVOICE 2468",
                OriginatorCompanyID = "0987654321",
                OriginatorCompanyName = "PAYROLL COMPANY",
                OriginatorRoutingNumber = "101050001",
                ReceiverIDNumber = null,
                ReceiverName = "Ian Crease",
                Settlement = new()
                {
                    SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
                },
                StandardEntryClassCode =
                    InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
                Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
                TraceNumber = "021000038461022",
                TransferReturn = new()
                {
                    Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                    ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransactionID = "transaction_id",
                },
                Type = InboundAchTransfers::Type.InboundAchTransfer,
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
        var model = new InboundAchTransfers::InboundAchTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Addenda = new()
                    {
                        Category = InboundAchTransfers::Category.Freeform,
                        Freeform = new([new("payment_related_information")]),
                    },
                    Amount = 100,
                    AutomaticallyResolvesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DeclinedTransactionID = "declined_transaction_id",
                        Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
                    },
                    Direction = InboundAchTransfers::Direction.Credit,
                    EffectiveDate = "2023-04-02",
                    InternationalAddenda = new()
                    {
                        DestinationCountryCode = "US",
                        DestinationCurrencyCode = "USD",
                        ForeignExchangeIndicator =
                            InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
                        ForeignExchangeReference = null,
                        ForeignExchangeReferenceIndicator =
                            InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank,
                        ForeignPaymentAmount = 199,
                        ForeignTraceNumber = null,
                        InternationalTransactionTypeCode =
                            InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated,
                        OriginatingCurrencyCode = "USD",
                        OriginatingDepositoryFinancialInstitutionBranchCountry = "US",
                        OriginatingDepositoryFinancialInstitutionID = "091000019",
                        OriginatingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        OriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK",
                        OriginatorCity = "BERLIN",
                        OriginatorCountry = "DE",
                        OriginatorIdentification = "770510487A",
                        OriginatorName = "BERGHAIN",
                        OriginatorPostalCode = "50825",
                        OriginatorStateOrProvince = null,
                        OriginatorStreetAddress = "Ruedersdorferstr. 7",
                        PaymentRelatedInformation = null,
                        PaymentRelatedInformation2 = null,
                        ReceiverCity = "BEVERLY HILLS",
                        ReceiverCountry = "US",
                        ReceiverIdentificationNumber = "1018790279274",
                        ReceiverPostalCode = "90210",
                        ReceiverStateOrProvince = "CA",
                        ReceiverStreetAddress = "123 FAKE ST",
                        ReceivingCompanyOrIndividualName = "IAN CREASE",
                        ReceivingDepositoryFinancialInstitutionCountry = "US",
                        ReceivingDepositoryFinancialInstitutionID = "101050001",
                        ReceivingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        ReceivingDepositoryFinancialInstitutionName =
                            "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
                    },
                    NotificationOfChange = new()
                    {
                        UpdatedAccountNumber = "updated_account_number",
                        UpdatedRoutingNumber = "updated_routing_number",
                    },
                    OriginatorCompanyDescriptiveDate = "230401",
                    OriginatorCompanyDiscretionaryData = "WEB AUTOPAY",
                    OriginatorCompanyEntryDescription = "INVOICE 2468",
                    OriginatorCompanyID = "0987654321",
                    OriginatorCompanyName = "PAYROLL COMPANY",
                    OriginatorRoutingNumber = "101050001",
                    ReceiverIDNumber = null,
                    ReceiverName = "Ian Crease",
                    Settlement = new()
                    {
                        SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
                    },
                    StandardEntryClassCode =
                        InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
                    Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
                    TraceNumber = "021000038461022",
                    TransferReturn = new()
                    {
                        Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    Type = InboundAchTransfers::Type.InboundAchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::InboundAchTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Addenda = new()
                    {
                        Category = InboundAchTransfers::Category.Freeform,
                        Freeform = new([new("payment_related_information")]),
                    },
                    Amount = 100,
                    AutomaticallyResolvesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Decline = new()
                    {
                        DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DeclinedTransactionID = "declined_transaction_id",
                        Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
                    },
                    Direction = InboundAchTransfers::Direction.Credit,
                    EffectiveDate = "2023-04-02",
                    InternationalAddenda = new()
                    {
                        DestinationCountryCode = "US",
                        DestinationCurrencyCode = "USD",
                        ForeignExchangeIndicator =
                            InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
                        ForeignExchangeReference = null,
                        ForeignExchangeReferenceIndicator =
                            InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank,
                        ForeignPaymentAmount = 199,
                        ForeignTraceNumber = null,
                        InternationalTransactionTypeCode =
                            InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated,
                        OriginatingCurrencyCode = "USD",
                        OriginatingDepositoryFinancialInstitutionBranchCountry = "US",
                        OriginatingDepositoryFinancialInstitutionID = "091000019",
                        OriginatingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        OriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK",
                        OriginatorCity = "BERLIN",
                        OriginatorCountry = "DE",
                        OriginatorIdentification = "770510487A",
                        OriginatorName = "BERGHAIN",
                        OriginatorPostalCode = "50825",
                        OriginatorStateOrProvince = null,
                        OriginatorStreetAddress = "Ruedersdorferstr. 7",
                        PaymentRelatedInformation = null,
                        PaymentRelatedInformation2 = null,
                        ReceiverCity = "BEVERLY HILLS",
                        ReceiverCountry = "US",
                        ReceiverIdentificationNumber = "1018790279274",
                        ReceiverPostalCode = "90210",
                        ReceiverStateOrProvince = "CA",
                        ReceiverStreetAddress = "123 FAKE ST",
                        ReceivingCompanyOrIndividualName = "IAN CREASE",
                        ReceivingDepositoryFinancialInstitutionCountry = "US",
                        ReceivingDepositoryFinancialInstitutionID = "101050001",
                        ReceivingDepositoryFinancialInstitutionIDQualifier =
                            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber,
                        ReceivingDepositoryFinancialInstitutionName =
                            "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
                    },
                    NotificationOfChange = new()
                    {
                        UpdatedAccountNumber = "updated_account_number",
                        UpdatedRoutingNumber = "updated_routing_number",
                    },
                    OriginatorCompanyDescriptiveDate = "230401",
                    OriginatorCompanyDiscretionaryData = "WEB AUTOPAY",
                    OriginatorCompanyEntryDescription = "INVOICE 2468",
                    OriginatorCompanyID = "0987654321",
                    OriginatorCompanyName = "PAYROLL COMPANY",
                    OriginatorRoutingNumber = "101050001",
                    ReceiverIDNumber = null,
                    ReceiverName = "Ian Crease",
                    Settlement = new()
                    {
                        SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
                    },
                    StandardEntryClassCode =
                        InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
                    Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
                    TraceNumber = "021000038461022",
                    TransferReturn = new()
                    {
                        Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    Type = InboundAchTransfers::Type.InboundAchTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        InboundAchTransfers::InboundAchTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
