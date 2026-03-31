using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundAchTransfers = Increase.Api.Models.InboundAchTransfers;

namespace Increase.Api.Tests.Models.InboundAchTransfers;

public class InboundAchTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::InboundAchTransfer
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
                ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
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
            StandardEntryClassCode = InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
            Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
            TraceNumber = "021000038461022",
            TransferReturn = new()
            {
                Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TransactionID = "transaction_id",
            },
            Type = InboundAchTransfers::Type.InboundAchTransfer,
        };

        string expectedID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev";
        InboundAchTransfers::Acceptance expectedAcceptance = new()
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        InboundAchTransfers::Addenda expectedAddenda = new()
        {
            Category = InboundAchTransfers::Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };
        long expectedAmount = 100;
        DateTimeOffset expectedAutomaticallyResolvesAt = DateTimeOffset.Parse(
            "2020-01-31T23:59:59Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        InboundAchTransfers::Decline expectedDecline = new()
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
        };
        ApiEnum<string, InboundAchTransfers::Direction> expectedDirection =
            InboundAchTransfers::Direction.Credit;
        string expectedEffectiveDate = "2023-04-02";
        InboundAchTransfers::InternationalAddenda expectedInternationalAddenda = new()
        {
            DestinationCountryCode = "US",
            DestinationCurrencyCode = "USD",
            ForeignExchangeIndicator = InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
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
            ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
        };
        InboundAchTransfers::NotificationOfChange expectedNotificationOfChange = new()
        {
            UpdatedAccountNumber = "updated_account_number",
            UpdatedRoutingNumber = "updated_routing_number",
        };
        string expectedOriginatorCompanyDescriptiveDate = "230401";
        string expectedOriginatorCompanyDiscretionaryData = "WEB AUTOPAY";
        string expectedOriginatorCompanyEntryDescription = "INVOICE 2468";
        string expectedOriginatorCompanyID = "0987654321";
        string expectedOriginatorCompanyName = "PAYROLL COMPANY";
        string expectedOriginatorRoutingNumber = "101050001";
        string expectedReceiverName = "Ian Crease";
        InboundAchTransfers::Settlement expectedSettlement = new()
        {
            SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
        };
        ApiEnum<
            string,
            InboundAchTransfers::StandardEntryClassCode
        > expectedStandardEntryClassCode =
            InboundAchTransfers::StandardEntryClassCode.InternetInitiated;
        ApiEnum<string, InboundAchTransfers::InboundAchTransferStatus> expectedStatus =
            InboundAchTransfers::InboundAchTransferStatus.Accepted;
        string expectedTraceNumber = "021000038461022";
        InboundAchTransfers::TransferReturn expectedTransferReturn = new()
        {
            Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };
        ApiEnum<string, InboundAchTransfers::Type> expectedType =
            InboundAchTransfers::Type.InboundAchTransfer;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAcceptance, model.Acceptance);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedAddenda, model.Addenda);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedAutomaticallyResolvesAt, model.AutomaticallyResolvesAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDecline, model.Decline);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedInternationalAddenda, model.InternationalAddenda);
        Assert.Equal(expectedNotificationOfChange, model.NotificationOfChange);
        Assert.Equal(
            expectedOriginatorCompanyDescriptiveDate,
            model.OriginatorCompanyDescriptiveDate
        );
        Assert.Equal(
            expectedOriginatorCompanyDiscretionaryData,
            model.OriginatorCompanyDiscretionaryData
        );
        Assert.Equal(
            expectedOriginatorCompanyEntryDescription,
            model.OriginatorCompanyEntryDescription
        );
        Assert.Equal(expectedOriginatorCompanyID, model.OriginatorCompanyID);
        Assert.Equal(expectedOriginatorCompanyName, model.OriginatorCompanyName);
        Assert.Equal(expectedOriginatorRoutingNumber, model.OriginatorRoutingNumber);
        Assert.Null(model.ReceiverIDNumber);
        Assert.Equal(expectedReceiverName, model.ReceiverName);
        Assert.Equal(expectedSettlement, model.Settlement);
        Assert.Equal(expectedStandardEntryClassCode, model.StandardEntryClassCode);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
        Assert.Equal(expectedTransferReturn, model.TransferReturn);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::InboundAchTransfer
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
                ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
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
            StandardEntryClassCode = InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
            Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
            TraceNumber = "021000038461022",
            TransferReturn = new()
            {
                Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TransactionID = "transaction_id",
            },
            Type = InboundAchTransfers::Type.InboundAchTransfer,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::InboundAchTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::InboundAchTransfer
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
                ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
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
            StandardEntryClassCode = InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
            Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
            TraceNumber = "021000038461022",
            TransferReturn = new()
            {
                Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TransactionID = "transaction_id",
            },
            Type = InboundAchTransfers::Type.InboundAchTransfer,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::InboundAchTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev";
        InboundAchTransfers::Acceptance expectedAcceptance = new()
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        InboundAchTransfers::Addenda expectedAddenda = new()
        {
            Category = InboundAchTransfers::Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };
        long expectedAmount = 100;
        DateTimeOffset expectedAutomaticallyResolvesAt = DateTimeOffset.Parse(
            "2020-01-31T23:59:59Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        InboundAchTransfers::Decline expectedDecline = new()
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
        };
        ApiEnum<string, InboundAchTransfers::Direction> expectedDirection =
            InboundAchTransfers::Direction.Credit;
        string expectedEffectiveDate = "2023-04-02";
        InboundAchTransfers::InternationalAddenda expectedInternationalAddenda = new()
        {
            DestinationCountryCode = "US",
            DestinationCurrencyCode = "USD",
            ForeignExchangeIndicator = InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
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
            ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
        };
        InboundAchTransfers::NotificationOfChange expectedNotificationOfChange = new()
        {
            UpdatedAccountNumber = "updated_account_number",
            UpdatedRoutingNumber = "updated_routing_number",
        };
        string expectedOriginatorCompanyDescriptiveDate = "230401";
        string expectedOriginatorCompanyDiscretionaryData = "WEB AUTOPAY";
        string expectedOriginatorCompanyEntryDescription = "INVOICE 2468";
        string expectedOriginatorCompanyID = "0987654321";
        string expectedOriginatorCompanyName = "PAYROLL COMPANY";
        string expectedOriginatorRoutingNumber = "101050001";
        string expectedReceiverName = "Ian Crease";
        InboundAchTransfers::Settlement expectedSettlement = new()
        {
            SettledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
        };
        ApiEnum<
            string,
            InboundAchTransfers::StandardEntryClassCode
        > expectedStandardEntryClassCode =
            InboundAchTransfers::StandardEntryClassCode.InternetInitiated;
        ApiEnum<string, InboundAchTransfers::InboundAchTransferStatus> expectedStatus =
            InboundAchTransfers::InboundAchTransferStatus.Accepted;
        string expectedTraceNumber = "021000038461022";
        InboundAchTransfers::TransferReturn expectedTransferReturn = new()
        {
            Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };
        ApiEnum<string, InboundAchTransfers::Type> expectedType =
            InboundAchTransfers::Type.InboundAchTransfer;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAcceptance, deserialized.Acceptance);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedAddenda, deserialized.Addenda);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedAutomaticallyResolvesAt, deserialized.AutomaticallyResolvesAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDecline, deserialized.Decline);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedInternationalAddenda, deserialized.InternationalAddenda);
        Assert.Equal(expectedNotificationOfChange, deserialized.NotificationOfChange);
        Assert.Equal(
            expectedOriginatorCompanyDescriptiveDate,
            deserialized.OriginatorCompanyDescriptiveDate
        );
        Assert.Equal(
            expectedOriginatorCompanyDiscretionaryData,
            deserialized.OriginatorCompanyDiscretionaryData
        );
        Assert.Equal(
            expectedOriginatorCompanyEntryDescription,
            deserialized.OriginatorCompanyEntryDescription
        );
        Assert.Equal(expectedOriginatorCompanyID, deserialized.OriginatorCompanyID);
        Assert.Equal(expectedOriginatorCompanyName, deserialized.OriginatorCompanyName);
        Assert.Equal(expectedOriginatorRoutingNumber, deserialized.OriginatorRoutingNumber);
        Assert.Null(deserialized.ReceiverIDNumber);
        Assert.Equal(expectedReceiverName, deserialized.ReceiverName);
        Assert.Equal(expectedSettlement, deserialized.Settlement);
        Assert.Equal(expectedStandardEntryClassCode, deserialized.StandardEntryClassCode);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
        Assert.Equal(expectedTransferReturn, deserialized.TransferReturn);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::InboundAchTransfer
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
                ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
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
            StandardEntryClassCode = InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
            Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
            TraceNumber = "021000038461022",
            TransferReturn = new()
            {
                Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TransactionID = "transaction_id",
            },
            Type = InboundAchTransfers::Type.InboundAchTransfer,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::InboundAchTransfer
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
                ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
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
            StandardEntryClassCode = InboundAchTransfers::StandardEntryClassCode.InternetInitiated,
            Status = InboundAchTransfers::InboundAchTransferStatus.Accepted,
            TraceNumber = "021000038461022",
            TransferReturn = new()
            {
                Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
                ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                TransactionID = "transaction_id",
            },
            Type = InboundAchTransfers::Type.InboundAchTransfer,
        };

        InboundAchTransfers::InboundAchTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcceptanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedAcceptedAt, model.AcceptedAt);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Acceptance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Acceptance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedAcceptedAt, deserialized.AcceptedAt);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        InboundAchTransfers::Acceptance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddendaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Addenda
        {
            Category = InboundAchTransfers::Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };

        ApiEnum<string, InboundAchTransfers::Category> expectedCategory =
            InboundAchTransfers::Category.Freeform;
        InboundAchTransfers::Freeform expectedFreeform = new([new("payment_related_information")]);

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedFreeform, model.Freeform);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Addenda
        {
            Category = InboundAchTransfers::Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Addenda>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::Addenda
        {
            Category = InboundAchTransfers::Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Addenda>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InboundAchTransfers::Category> expectedCategory =
            InboundAchTransfers::Category.Freeform;
        InboundAchTransfers::Freeform expectedFreeform = new([new("payment_related_information")]);

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedFreeform, deserialized.Freeform);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::Addenda
        {
            Category = InboundAchTransfers::Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::Addenda
        {
            Category = InboundAchTransfers::Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };

        InboundAchTransfers::Addenda copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::Category.Freeform)]
    public void Validation_Works(InboundAchTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::Category.Freeform)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::Category>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::Category>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FreeformTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Freeform
        {
            Entries = [new("payment_related_information")],
        };

        List<InboundAchTransfers::Entry> expectedEntries = [new("payment_related_information")];

        Assert.Equal(expectedEntries.Count, model.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], model.Entries[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Freeform
        {
            Entries = [new("payment_related_information")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Freeform>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::Freeform
        {
            Entries = [new("payment_related_information")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Freeform>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<InboundAchTransfers::Entry> expectedEntries = [new("payment_related_information")];

        Assert.Equal(expectedEntries.Count, deserialized.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], deserialized.Entries[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::Freeform
        {
            Entries = [new("payment_related_information")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::Freeform
        {
            Entries = [new("payment_related_information")],
        };

        InboundAchTransfers::Freeform copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Entry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        string expectedPaymentRelatedInformation = "payment_related_information";

        Assert.Equal(expectedPaymentRelatedInformation, model.PaymentRelatedInformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Entry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Entry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::Entry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Entry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPaymentRelatedInformation = "payment_related_information";

        Assert.Equal(expectedPaymentRelatedInformation, deserialized.PaymentRelatedInformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::Entry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::Entry
        {
            PaymentRelatedInformation = "payment_related_information",
        };

        InboundAchTransfers::Entry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
        };

        DateTimeOffset expectedDeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeclinedTransactionID = "declined_transaction_id";
        ApiEnum<string, InboundAchTransfers::DeclineReason> expectedReason =
            InboundAchTransfers::DeclineReason.AchRouteCanceled;

        Assert.Equal(expectedDeclinedAt, model.DeclinedAt);
        Assert.Equal(expectedDeclinedTransactionID, model.DeclinedTransactionID);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Decline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Decline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedDeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeclinedTransactionID = "declined_transaction_id";
        ApiEnum<string, InboundAchTransfers::DeclineReason> expectedReason =
            InboundAchTransfers::DeclineReason.AchRouteCanceled;

        Assert.Equal(expectedDeclinedAt, deserialized.DeclinedAt);
        Assert.Equal(expectedDeclinedTransactionID, deserialized.DeclinedTransactionID);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundAchTransfers::DeclineReason.AchRouteCanceled,
        };

        InboundAchTransfers::Decline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::DeclineReason.AchRouteCanceled)]
    [InlineData(InboundAchTransfers::DeclineReason.AchRouteDisabled)]
    [InlineData(InboundAchTransfers::DeclineReason.BreachesLimit)]
    [InlineData(InboundAchTransfers::DeclineReason.EntityNotActive)]
    [InlineData(InboundAchTransfers::DeclineReason.GroupLocked)]
    [InlineData(InboundAchTransfers::DeclineReason.TransactionNotAllowed)]
    [InlineData(InboundAchTransfers::DeclineReason.ReturnedPerOdfiRequest)]
    [InlineData(InboundAchTransfers::DeclineReason.UserInitiated)]
    [InlineData(InboundAchTransfers::DeclineReason.InsufficientFunds)]
    [InlineData(InboundAchTransfers::DeclineReason.AuthorizationRevokedByCustomer)]
    [InlineData(InboundAchTransfers::DeclineReason.PaymentStopped)]
    [InlineData(
        InboundAchTransfers::DeclineReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(
        InboundAchTransfers::DeclineReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(InboundAchTransfers::DeclineReason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(InboundAchTransfers::DeclineReason.CreditEntryRefusedByReceiver)]
    [InlineData(InboundAchTransfers::DeclineReason.DuplicateEntry)]
    [InlineData(InboundAchTransfers::DeclineReason.CorporateCustomerAdvisedNotAuthorized)]
    public void Validation_Works(InboundAchTransfers::DeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::DeclineReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::DeclineReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::DeclineReason.AchRouteCanceled)]
    [InlineData(InboundAchTransfers::DeclineReason.AchRouteDisabled)]
    [InlineData(InboundAchTransfers::DeclineReason.BreachesLimit)]
    [InlineData(InboundAchTransfers::DeclineReason.EntityNotActive)]
    [InlineData(InboundAchTransfers::DeclineReason.GroupLocked)]
    [InlineData(InboundAchTransfers::DeclineReason.TransactionNotAllowed)]
    [InlineData(InboundAchTransfers::DeclineReason.ReturnedPerOdfiRequest)]
    [InlineData(InboundAchTransfers::DeclineReason.UserInitiated)]
    [InlineData(InboundAchTransfers::DeclineReason.InsufficientFunds)]
    [InlineData(InboundAchTransfers::DeclineReason.AuthorizationRevokedByCustomer)]
    [InlineData(InboundAchTransfers::DeclineReason.PaymentStopped)]
    [InlineData(
        InboundAchTransfers::DeclineReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(
        InboundAchTransfers::DeclineReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(InboundAchTransfers::DeclineReason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(InboundAchTransfers::DeclineReason.CreditEntryRefusedByReceiver)]
    [InlineData(InboundAchTransfers::DeclineReason.DuplicateEntry)]
    [InlineData(InboundAchTransfers::DeclineReason.CorporateCustomerAdvisedNotAuthorized)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::DeclineReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::DeclineReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::DeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::DeclineReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::DeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DirectionTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::Direction.Credit)]
    [InlineData(InboundAchTransfers::Direction.Debit)]
    public void Validation_Works(InboundAchTransfers::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::Direction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::Direction.Credit)]
    [InlineData(InboundAchTransfers::Direction.Debit)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::Direction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::Direction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::Direction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InternationalAddendaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::InternationalAddenda
        {
            DestinationCountryCode = "US",
            DestinationCurrencyCode = "USD",
            ForeignExchangeIndicator = InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
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
            ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
        };

        string expectedDestinationCountryCode = "US";
        string expectedDestinationCurrencyCode = "USD";
        ApiEnum<
            string,
            InboundAchTransfers::ForeignExchangeIndicator
        > expectedForeignExchangeIndicator =
            InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed;
        ApiEnum<
            string,
            InboundAchTransfers::ForeignExchangeReferenceIndicator
        > expectedForeignExchangeReferenceIndicator =
            InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank;
        long expectedForeignPaymentAmount = 199;
        ApiEnum<
            string,
            InboundAchTransfers::InternationalTransactionTypeCode
        > expectedInternationalTransactionTypeCode =
            InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated;
        string expectedOriginatingCurrencyCode = "USD";
        string expectedOriginatingDepositoryFinancialInstitutionBranchCountry = "US";
        string expectedOriginatingDepositoryFinancialInstitutionID = "091000019";
        ApiEnum<
            string,
            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
        > expectedOriginatingDepositoryFinancialInstitutionIDQualifier =
            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber;
        string expectedOriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK";
        string expectedOriginatorCity = "BERLIN";
        string expectedOriginatorCountry = "DE";
        string expectedOriginatorIdentification = "770510487A";
        string expectedOriginatorName = "BERGHAIN";
        string expectedOriginatorPostalCode = "50825";
        string expectedOriginatorStreetAddress = "Ruedersdorferstr. 7";
        string expectedReceiverCity = "BEVERLY HILLS";
        string expectedReceiverCountry = "US";
        string expectedReceiverIdentificationNumber = "1018790279274";
        string expectedReceiverPostalCode = "90210";
        string expectedReceiverStateOrProvince = "CA";
        string expectedReceiverStreetAddress = "123 FAKE ST";
        string expectedReceivingCompanyOrIndividualName = "IAN CREASE";
        string expectedReceivingDepositoryFinancialInstitutionCountry = "US";
        string expectedReceivingDepositoryFinancialInstitutionID = "101050001";
        ApiEnum<
            string,
            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier
        > expectedReceivingDepositoryFinancialInstitutionIDQualifier =
            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber;
        string expectedReceivingDepositoryFinancialInstitutionName =
            "BLUE RIDGE BANK, NATIONAL ASSOCIATI";

        Assert.Equal(expectedDestinationCountryCode, model.DestinationCountryCode);
        Assert.Equal(expectedDestinationCurrencyCode, model.DestinationCurrencyCode);
        Assert.Equal(expectedForeignExchangeIndicator, model.ForeignExchangeIndicator);
        Assert.Null(model.ForeignExchangeReference);
        Assert.Equal(
            expectedForeignExchangeReferenceIndicator,
            model.ForeignExchangeReferenceIndicator
        );
        Assert.Equal(expectedForeignPaymentAmount, model.ForeignPaymentAmount);
        Assert.Null(model.ForeignTraceNumber);
        Assert.Equal(
            expectedInternationalTransactionTypeCode,
            model.InternationalTransactionTypeCode
        );
        Assert.Equal(expectedOriginatingCurrencyCode, model.OriginatingCurrencyCode);
        Assert.Equal(
            expectedOriginatingDepositoryFinancialInstitutionBranchCountry,
            model.OriginatingDepositoryFinancialInstitutionBranchCountry
        );
        Assert.Equal(
            expectedOriginatingDepositoryFinancialInstitutionID,
            model.OriginatingDepositoryFinancialInstitutionID
        );
        Assert.Equal(
            expectedOriginatingDepositoryFinancialInstitutionIDQualifier,
            model.OriginatingDepositoryFinancialInstitutionIDQualifier
        );
        Assert.Equal(
            expectedOriginatingDepositoryFinancialInstitutionName,
            model.OriginatingDepositoryFinancialInstitutionName
        );
        Assert.Equal(expectedOriginatorCity, model.OriginatorCity);
        Assert.Equal(expectedOriginatorCountry, model.OriginatorCountry);
        Assert.Equal(expectedOriginatorIdentification, model.OriginatorIdentification);
        Assert.Equal(expectedOriginatorName, model.OriginatorName);
        Assert.Equal(expectedOriginatorPostalCode, model.OriginatorPostalCode);
        Assert.Null(model.OriginatorStateOrProvince);
        Assert.Equal(expectedOriginatorStreetAddress, model.OriginatorStreetAddress);
        Assert.Null(model.PaymentRelatedInformation);
        Assert.Null(model.PaymentRelatedInformation2);
        Assert.Equal(expectedReceiverCity, model.ReceiverCity);
        Assert.Equal(expectedReceiverCountry, model.ReceiverCountry);
        Assert.Equal(expectedReceiverIdentificationNumber, model.ReceiverIdentificationNumber);
        Assert.Equal(expectedReceiverPostalCode, model.ReceiverPostalCode);
        Assert.Equal(expectedReceiverStateOrProvince, model.ReceiverStateOrProvince);
        Assert.Equal(expectedReceiverStreetAddress, model.ReceiverStreetAddress);
        Assert.Equal(
            expectedReceivingCompanyOrIndividualName,
            model.ReceivingCompanyOrIndividualName
        );
        Assert.Equal(
            expectedReceivingDepositoryFinancialInstitutionCountry,
            model.ReceivingDepositoryFinancialInstitutionCountry
        );
        Assert.Equal(
            expectedReceivingDepositoryFinancialInstitutionID,
            model.ReceivingDepositoryFinancialInstitutionID
        );
        Assert.Equal(
            expectedReceivingDepositoryFinancialInstitutionIDQualifier,
            model.ReceivingDepositoryFinancialInstitutionIDQualifier
        );
        Assert.Equal(
            expectedReceivingDepositoryFinancialInstitutionName,
            model.ReceivingDepositoryFinancialInstitutionName
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::InternationalAddenda
        {
            DestinationCountryCode = "US",
            DestinationCurrencyCode = "USD",
            ForeignExchangeIndicator = InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
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
            ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::InternationalAddenda>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::InternationalAddenda
        {
            DestinationCountryCode = "US",
            DestinationCurrencyCode = "USD",
            ForeignExchangeIndicator = InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
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
            ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::InternationalAddenda>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDestinationCountryCode = "US";
        string expectedDestinationCurrencyCode = "USD";
        ApiEnum<
            string,
            InboundAchTransfers::ForeignExchangeIndicator
        > expectedForeignExchangeIndicator =
            InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed;
        ApiEnum<
            string,
            InboundAchTransfers::ForeignExchangeReferenceIndicator
        > expectedForeignExchangeReferenceIndicator =
            InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank;
        long expectedForeignPaymentAmount = 199;
        ApiEnum<
            string,
            InboundAchTransfers::InternationalTransactionTypeCode
        > expectedInternationalTransactionTypeCode =
            InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated;
        string expectedOriginatingCurrencyCode = "USD";
        string expectedOriginatingDepositoryFinancialInstitutionBranchCountry = "US";
        string expectedOriginatingDepositoryFinancialInstitutionID = "091000019";
        ApiEnum<
            string,
            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
        > expectedOriginatingDepositoryFinancialInstitutionIDQualifier =
            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber;
        string expectedOriginatingDepositoryFinancialInstitutionName = "WELLS FARGO BANK";
        string expectedOriginatorCity = "BERLIN";
        string expectedOriginatorCountry = "DE";
        string expectedOriginatorIdentification = "770510487A";
        string expectedOriginatorName = "BERGHAIN";
        string expectedOriginatorPostalCode = "50825";
        string expectedOriginatorStreetAddress = "Ruedersdorferstr. 7";
        string expectedReceiverCity = "BEVERLY HILLS";
        string expectedReceiverCountry = "US";
        string expectedReceiverIdentificationNumber = "1018790279274";
        string expectedReceiverPostalCode = "90210";
        string expectedReceiverStateOrProvince = "CA";
        string expectedReceiverStreetAddress = "123 FAKE ST";
        string expectedReceivingCompanyOrIndividualName = "IAN CREASE";
        string expectedReceivingDepositoryFinancialInstitutionCountry = "US";
        string expectedReceivingDepositoryFinancialInstitutionID = "101050001";
        ApiEnum<
            string,
            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier
        > expectedReceivingDepositoryFinancialInstitutionIDQualifier =
            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber;
        string expectedReceivingDepositoryFinancialInstitutionName =
            "BLUE RIDGE BANK, NATIONAL ASSOCIATI";

        Assert.Equal(expectedDestinationCountryCode, deserialized.DestinationCountryCode);
        Assert.Equal(expectedDestinationCurrencyCode, deserialized.DestinationCurrencyCode);
        Assert.Equal(expectedForeignExchangeIndicator, deserialized.ForeignExchangeIndicator);
        Assert.Null(deserialized.ForeignExchangeReference);
        Assert.Equal(
            expectedForeignExchangeReferenceIndicator,
            deserialized.ForeignExchangeReferenceIndicator
        );
        Assert.Equal(expectedForeignPaymentAmount, deserialized.ForeignPaymentAmount);
        Assert.Null(deserialized.ForeignTraceNumber);
        Assert.Equal(
            expectedInternationalTransactionTypeCode,
            deserialized.InternationalTransactionTypeCode
        );
        Assert.Equal(expectedOriginatingCurrencyCode, deserialized.OriginatingCurrencyCode);
        Assert.Equal(
            expectedOriginatingDepositoryFinancialInstitutionBranchCountry,
            deserialized.OriginatingDepositoryFinancialInstitutionBranchCountry
        );
        Assert.Equal(
            expectedOriginatingDepositoryFinancialInstitutionID,
            deserialized.OriginatingDepositoryFinancialInstitutionID
        );
        Assert.Equal(
            expectedOriginatingDepositoryFinancialInstitutionIDQualifier,
            deserialized.OriginatingDepositoryFinancialInstitutionIDQualifier
        );
        Assert.Equal(
            expectedOriginatingDepositoryFinancialInstitutionName,
            deserialized.OriginatingDepositoryFinancialInstitutionName
        );
        Assert.Equal(expectedOriginatorCity, deserialized.OriginatorCity);
        Assert.Equal(expectedOriginatorCountry, deserialized.OriginatorCountry);
        Assert.Equal(expectedOriginatorIdentification, deserialized.OriginatorIdentification);
        Assert.Equal(expectedOriginatorName, deserialized.OriginatorName);
        Assert.Equal(expectedOriginatorPostalCode, deserialized.OriginatorPostalCode);
        Assert.Null(deserialized.OriginatorStateOrProvince);
        Assert.Equal(expectedOriginatorStreetAddress, deserialized.OriginatorStreetAddress);
        Assert.Null(deserialized.PaymentRelatedInformation);
        Assert.Null(deserialized.PaymentRelatedInformation2);
        Assert.Equal(expectedReceiverCity, deserialized.ReceiverCity);
        Assert.Equal(expectedReceiverCountry, deserialized.ReceiverCountry);
        Assert.Equal(
            expectedReceiverIdentificationNumber,
            deserialized.ReceiverIdentificationNumber
        );
        Assert.Equal(expectedReceiverPostalCode, deserialized.ReceiverPostalCode);
        Assert.Equal(expectedReceiverStateOrProvince, deserialized.ReceiverStateOrProvince);
        Assert.Equal(expectedReceiverStreetAddress, deserialized.ReceiverStreetAddress);
        Assert.Equal(
            expectedReceivingCompanyOrIndividualName,
            deserialized.ReceivingCompanyOrIndividualName
        );
        Assert.Equal(
            expectedReceivingDepositoryFinancialInstitutionCountry,
            deserialized.ReceivingDepositoryFinancialInstitutionCountry
        );
        Assert.Equal(
            expectedReceivingDepositoryFinancialInstitutionID,
            deserialized.ReceivingDepositoryFinancialInstitutionID
        );
        Assert.Equal(
            expectedReceivingDepositoryFinancialInstitutionIDQualifier,
            deserialized.ReceivingDepositoryFinancialInstitutionIDQualifier
        );
        Assert.Equal(
            expectedReceivingDepositoryFinancialInstitutionName,
            deserialized.ReceivingDepositoryFinancialInstitutionName
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::InternationalAddenda
        {
            DestinationCountryCode = "US",
            DestinationCurrencyCode = "USD",
            ForeignExchangeIndicator = InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
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
            ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::InternationalAddenda
        {
            DestinationCountryCode = "US",
            DestinationCurrencyCode = "USD",
            ForeignExchangeIndicator = InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed,
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
            ReceivingDepositoryFinancialInstitutionName = "BLUE RIDGE BANK, NATIONAL ASSOCIATI",
        };

        InboundAchTransfers::InternationalAddenda copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ForeignExchangeIndicatorTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::ForeignExchangeIndicator.FixedToVariable)]
    [InlineData(InboundAchTransfers::ForeignExchangeIndicator.VariableToFixed)]
    [InlineData(InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed)]
    public void Validation_Works(InboundAchTransfers::ForeignExchangeIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::ForeignExchangeIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ForeignExchangeIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::ForeignExchangeIndicator.FixedToVariable)]
    [InlineData(InboundAchTransfers::ForeignExchangeIndicator.VariableToFixed)]
    [InlineData(InboundAchTransfers::ForeignExchangeIndicator.FixedToFixed)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::ForeignExchangeIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::ForeignExchangeIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ForeignExchangeIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ForeignExchangeIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ForeignExchangeIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ForeignExchangeReferenceIndicatorTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::ForeignExchangeReferenceIndicator.ForeignExchangeRate)]
    [InlineData(
        InboundAchTransfers::ForeignExchangeReferenceIndicator.ForeignExchangeReferenceNumber
    )]
    [InlineData(InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank)]
    public void Validation_Works(InboundAchTransfers::ForeignExchangeReferenceIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::ForeignExchangeReferenceIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ForeignExchangeReferenceIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::ForeignExchangeReferenceIndicator.ForeignExchangeRate)]
    [InlineData(
        InboundAchTransfers::ForeignExchangeReferenceIndicator.ForeignExchangeReferenceNumber
    )]
    [InlineData(InboundAchTransfers::ForeignExchangeReferenceIndicator.Blank)]
    public void SerializationRoundtrip_Works(
        InboundAchTransfers::ForeignExchangeReferenceIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::ForeignExchangeReferenceIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ForeignExchangeReferenceIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ForeignExchangeReferenceIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ForeignExchangeReferenceIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InternationalTransactionTypeCodeTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Annuity)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.BusinessOrCommercial)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Deposit)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Loan)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Miscellaneous)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Mortgage)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Pension)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Remittance)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.RentOrLease)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.SalaryOrPayroll)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Tax)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.AccountsReceivable)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.BackOfficeConversion)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.MachineTransfer)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.PointOfPurchase)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.PointOfSale)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.RepresentedCheck)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.SharedNetworkTransaction)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.TelphoneInitiated)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated)]
    public void Validation_Works(InboundAchTransfers::InternationalTransactionTypeCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::InternationalTransactionTypeCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::InternationalTransactionTypeCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Annuity)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.BusinessOrCommercial)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Deposit)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Loan)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Miscellaneous)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Mortgage)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Pension)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Remittance)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.RentOrLease)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.SalaryOrPayroll)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.Tax)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.AccountsReceivable)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.BackOfficeConversion)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.MachineTransfer)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.PointOfPurchase)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.PointOfSale)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.RepresentedCheck)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.SharedNetworkTransaction)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.TelphoneInitiated)]
    [InlineData(InboundAchTransfers::InternationalTransactionTypeCode.InternetInitiated)]
    public void SerializationRoundtrip_Works(
        InboundAchTransfers::InternationalTransactionTypeCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::InternationalTransactionTypeCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::InternationalTransactionTypeCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::InternationalTransactionTypeCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::InternationalTransactionTypeCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class OriginatingDepositoryFinancialInstitutionIDQualifierTest : TestBase
{
    [Theory]
    [InlineData(
        InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber
    )]
    [InlineData(InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.BicCode)]
    [InlineData(InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.Iban)]
    public void Validation_Works(
        InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber
    )]
    [InlineData(InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.BicCode)]
    [InlineData(InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier.Iban)]
    public void SerializationRoundtrip_Works(
        InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                InboundAchTransfers::OriginatingDepositoryFinancialInstitutionIDQualifier
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReceivingDepositoryFinancialInstitutionIDQualifierTest : TestBase
{
    [Theory]
    [InlineData(
        InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber
    )]
    [InlineData(InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.BicCode)]
    [InlineData(InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.Iban)]
    public void Validation_Works(
        InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.NationalClearingSystemNumber
    )]
    [InlineData(InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.BicCode)]
    [InlineData(InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier.Iban)]
    public void SerializationRoundtrip_Works(
        InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::ReceivingDepositoryFinancialInstitutionIDQualifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NotificationOfChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::NotificationOfChange
        {
            UpdatedAccountNumber = "updated_account_number",
            UpdatedRoutingNumber = "updated_routing_number",
        };

        string expectedUpdatedAccountNumber = "updated_account_number";
        string expectedUpdatedRoutingNumber = "updated_routing_number";

        Assert.Equal(expectedUpdatedAccountNumber, model.UpdatedAccountNumber);
        Assert.Equal(expectedUpdatedRoutingNumber, model.UpdatedRoutingNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::NotificationOfChange
        {
            UpdatedAccountNumber = "updated_account_number",
            UpdatedRoutingNumber = "updated_routing_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::NotificationOfChange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::NotificationOfChange
        {
            UpdatedAccountNumber = "updated_account_number",
            UpdatedRoutingNumber = "updated_routing_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::NotificationOfChange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUpdatedAccountNumber = "updated_account_number";
        string expectedUpdatedRoutingNumber = "updated_routing_number";

        Assert.Equal(expectedUpdatedAccountNumber, deserialized.UpdatedAccountNumber);
        Assert.Equal(expectedUpdatedRoutingNumber, deserialized.UpdatedRoutingNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::NotificationOfChange
        {
            UpdatedAccountNumber = "updated_account_number",
            UpdatedRoutingNumber = "updated_routing_number",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::NotificationOfChange
        {
            UpdatedAccountNumber = "updated_account_number",
            UpdatedRoutingNumber = "updated_routing_number",
        };

        InboundAchTransfers::NotificationOfChange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SettlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
        };

        DateTimeOffset expectedSettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, InboundAchTransfers::SettlementSchedule> expectedSettlementSchedule =
            InboundAchTransfers::SettlementSchedule.SameDay;

        Assert.Equal(expectedSettledAt, model.SettledAt);
        Assert.Equal(expectedSettlementSchedule, model.SettlementSchedule);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Settlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::Settlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedSettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, InboundAchTransfers::SettlementSchedule> expectedSettlementSchedule =
            InboundAchTransfers::SettlementSchedule.SameDay;

        Assert.Equal(expectedSettledAt, deserialized.SettledAt);
        Assert.Equal(expectedSettlementSchedule, deserialized.SettlementSchedule);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::Settlement
        {
            SettledAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SettlementSchedule = InboundAchTransfers::SettlementSchedule.SameDay,
        };

        InboundAchTransfers::Settlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SettlementScheduleTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::SettlementSchedule.SameDay)]
    [InlineData(InboundAchTransfers::SettlementSchedule.FutureDated)]
    public void Validation_Works(InboundAchTransfers::SettlementSchedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::SettlementSchedule> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::SettlementSchedule>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::SettlementSchedule.SameDay)]
    [InlineData(InboundAchTransfers::SettlementSchedule.FutureDated)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::SettlementSchedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::SettlementSchedule> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::SettlementSchedule>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::SettlementSchedule>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::SettlementSchedule>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StandardEntryClassCodeTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.InternetInitiated)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.PointOfSale)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.TelephoneInitiated)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.CustomerInitiated)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.AccountsReceivable)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.MachineTransfer)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.SharedNetworkTransaction)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.RepresentedCheck)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.BackOfficeConversion)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.PointOfPurchase)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.CheckTruncation)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.DestroyedCheck)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.InternationalAchTransaction)]
    public void Validation_Works(InboundAchTransfers::StandardEntryClassCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::StandardEntryClassCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::StandardEntryClassCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.InternetInitiated)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.PointOfSale)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.TelephoneInitiated)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.CustomerInitiated)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.AccountsReceivable)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.MachineTransfer)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.SharedNetworkTransaction)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.RepresentedCheck)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.BackOfficeConversion)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.PointOfPurchase)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.CheckTruncation)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.DestroyedCheck)]
    [InlineData(InboundAchTransfers::StandardEntryClassCode.InternationalAchTransaction)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::StandardEntryClassCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::StandardEntryClassCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::StandardEntryClassCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::StandardEntryClassCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::StandardEntryClassCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundAchTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::InboundAchTransferStatus.Pending)]
    [InlineData(InboundAchTransfers::InboundAchTransferStatus.Declined)]
    [InlineData(InboundAchTransfers::InboundAchTransferStatus.Accepted)]
    [InlineData(InboundAchTransfers::InboundAchTransferStatus.Returned)]
    public void Validation_Works(InboundAchTransfers::InboundAchTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::InboundAchTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::InboundAchTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::InboundAchTransferStatus.Pending)]
    [InlineData(InboundAchTransfers::InboundAchTransferStatus.Declined)]
    [InlineData(InboundAchTransfers::InboundAchTransferStatus.Accepted)]
    [InlineData(InboundAchTransfers::InboundAchTransferStatus.Returned)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::InboundAchTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::InboundAchTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::InboundAchTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::InboundAchTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::InboundAchTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TransferReturnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAchTransfers::TransferReturn
        {
            Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        ApiEnum<string, InboundAchTransfers::TransferReturnReason> expectedReason =
            InboundAchTransfers::TransferReturnReason.InsufficientFunds;
        DateTimeOffset expectedReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAchTransfers::TransferReturn
        {
            Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::TransferReturn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAchTransfers::TransferReturn
        {
            Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAchTransfers::TransferReturn>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InboundAchTransfers::TransferReturnReason> expectedReason =
            InboundAchTransfers::TransferReturnReason.InsufficientFunds;
        DateTimeOffset expectedReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAchTransfers::TransferReturn
        {
            Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAchTransfers::TransferReturn
        {
            Reason = InboundAchTransfers::TransferReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        InboundAchTransfers::TransferReturn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransferReturnReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::TransferReturnReason.InsufficientFunds)]
    [InlineData(InboundAchTransfers::TransferReturnReason.ReturnedPerOdfiRequest)]
    [InlineData(InboundAchTransfers::TransferReturnReason.AuthorizationRevokedByCustomer)]
    [InlineData(InboundAchTransfers::TransferReturnReason.PaymentStopped)]
    [InlineData(
        InboundAchTransfers::TransferReturnReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(
        InboundAchTransfers::TransferReturnReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(InboundAchTransfers::TransferReturnReason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(InboundAchTransfers::TransferReturnReason.CreditEntryRefusedByReceiver)]
    [InlineData(InboundAchTransfers::TransferReturnReason.DuplicateEntry)]
    [InlineData(InboundAchTransfers::TransferReturnReason.CorporateCustomerAdvisedNotAuthorized)]
    public void Validation_Works(InboundAchTransfers::TransferReturnReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::TransferReturnReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::TransferReturnReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::TransferReturnReason.InsufficientFunds)]
    [InlineData(InboundAchTransfers::TransferReturnReason.ReturnedPerOdfiRequest)]
    [InlineData(InboundAchTransfers::TransferReturnReason.AuthorizationRevokedByCustomer)]
    [InlineData(InboundAchTransfers::TransferReturnReason.PaymentStopped)]
    [InlineData(
        InboundAchTransfers::TransferReturnReason.CustomerAdvisedUnauthorizedImproperIneligibleOrIncomplete
    )]
    [InlineData(
        InboundAchTransfers::TransferReturnReason.RepresentativePayeeDeceasedOrUnableToContinueInThatCapacity
    )]
    [InlineData(InboundAchTransfers::TransferReturnReason.BeneficiaryOrAccountHolderDeceased)]
    [InlineData(InboundAchTransfers::TransferReturnReason.CreditEntryRefusedByReceiver)]
    [InlineData(InboundAchTransfers::TransferReturnReason.DuplicateEntry)]
    [InlineData(InboundAchTransfers::TransferReturnReason.CorporateCustomerAdvisedNotAuthorized)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::TransferReturnReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::TransferReturnReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::TransferReturnReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::TransferReturnReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundAchTransfers::TransferReturnReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(InboundAchTransfers::Type.InboundAchTransfer)]
    public void Validation_Works(InboundAchTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchTransfers::Type.InboundAchTransfer)]
    public void SerializationRoundtrip_Works(InboundAchTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundAchTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
