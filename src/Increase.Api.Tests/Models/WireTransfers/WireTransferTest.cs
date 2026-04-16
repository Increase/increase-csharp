using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using WireTransfers = Increase.Api.Models.WireTransfers;

namespace Increase.Api.Tests.Models.WireTransfers;

public class WireTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransfer
        {
            ID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = WireTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Creditor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferCreditorAddressUnstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Line3 = null,
                    }
                ),
                Name = "National Phonograph Company",
            },
            Currency = WireTransfers::Currency.Usd,
            Debtor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferDebtorAddressUnstructured()
                    {
                        Line1 = "line1",
                        Line2 = "line2",
                        Line3 = "line3",
                    }
                ),
                Name = "name",
            },
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            IdempotencyKey = null,
            InboundWireDrawdownRequestID = null,
            Network = WireTransfers::Network.Wire,
            PendingTransactionID = null,
            Remittance = new()
            {
                Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "identification_number",
                    TypeCode = "type_code",
                },
                Unstructured = new("Invoice 29582"),
            },
            Reversal = new()
            {
                Amount = 12345,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DebtorRoutingNumber = "101050001",
                Description = "Inbound wire reversal 2022021100335128",
                InputCycleDate = "2022-02-11",
                InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                InputSequenceNumber = "11023",
                InputSource = "B6B7HU2R",
                InstructionIdentification = null,
                ReturnReasonAdditionalInformation = null,
                ReturnReasonCode = null,
                ReturnReasonCodeDescription = null,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = null,
            Status = WireTransfers::WireTransferStatus.Complete,
            Submission = new()
            {
                InputMessageAccountabilityData = "20220118MMQFMP0P000002",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = WireTransfers::Type.WireTransfer,
            UniqueEndToEndTransactionReference = null,
        };

        string expectedID = "wire_transfer_5akynk7dqsq25qwk9q2u";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        long expectedAmount = 100;
        WireTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        WireTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        WireTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = WireTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        WireTransfers::WireTransferCreditor expectedCreditor = new()
        {
            Address = new(
                new WireTransfers::WireTransferCreditorAddressUnstructured()
                {
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    Line3 = null,
                }
            ),
            Name = "National Phonograph Company",
        };
        ApiEnum<string, WireTransfers::Currency> expectedCurrency = WireTransfers::Currency.Usd;
        WireTransfers::WireTransferDebtor expectedDebtor = new()
        {
            Address = new(
                new WireTransfers::WireTransferDebtorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };
        string expectedExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv";
        ApiEnum<string, WireTransfers::Network> expectedNetwork = WireTransfers::Network.Wire;
        WireTransfers::WireTransferRemittance expectedRemittance = new()
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "identification_number",
                TypeCode = "type_code",
            },
            Unstructured = new("Invoice 29582"),
        };
        WireTransfers::Reversal expectedReversal = new()
        {
            Amount = 12345,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DebtorRoutingNumber = "101050001",
            Description = "Inbound wire reversal 2022021100335128",
            InputCycleDate = "2022-02-11",
            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
            InputSequenceNumber = "11023",
            InputSource = "B6B7HU2R",
            InstructionIdentification = null,
            ReturnReasonAdditionalInformation = null,
            ReturnReasonCode = null,
            ReturnReasonCodeDescription = null,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, WireTransfers::WireTransferStatus> expectedStatus =
            WireTransfers::WireTransferStatus.Complete;
        WireTransfers::Submission expectedSubmission = new()
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000002",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, WireTransfers::Type> expectedType = WireTransfers::Type.WireTransfer;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedCancellation, model.Cancellation);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedCreditor, model.Creditor);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtor, model.Debtor);
        Assert.Equal(expectedExternalAccountID, model.ExternalAccountID);
        Assert.Null(model.IdempotencyKey);
        Assert.Null(model.InboundWireDrawdownRequestID);
        Assert.Equal(expectedNetwork, model.Network);
        Assert.Null(model.PendingTransactionID);
        Assert.Equal(expectedRemittance, model.Remittance);
        Assert.Equal(expectedReversal, model.Reversal);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Null(model.SourceAccountNumberID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
        Assert.Null(model.UniqueEndToEndTransactionReference);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransfer
        {
            ID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = WireTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Creditor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferCreditorAddressUnstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Line3 = null,
                    }
                ),
                Name = "National Phonograph Company",
            },
            Currency = WireTransfers::Currency.Usd,
            Debtor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferDebtorAddressUnstructured()
                    {
                        Line1 = "line1",
                        Line2 = "line2",
                        Line3 = "line3",
                    }
                ),
                Name = "name",
            },
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            IdempotencyKey = null,
            InboundWireDrawdownRequestID = null,
            Network = WireTransfers::Network.Wire,
            PendingTransactionID = null,
            Remittance = new()
            {
                Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "identification_number",
                    TypeCode = "type_code",
                },
                Unstructured = new("Invoice 29582"),
            },
            Reversal = new()
            {
                Amount = 12345,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DebtorRoutingNumber = "101050001",
                Description = "Inbound wire reversal 2022021100335128",
                InputCycleDate = "2022-02-11",
                InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                InputSequenceNumber = "11023",
                InputSource = "B6B7HU2R",
                InstructionIdentification = null,
                ReturnReasonAdditionalInformation = null,
                ReturnReasonCode = null,
                ReturnReasonCodeDescription = null,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = null,
            Status = WireTransfers::WireTransferStatus.Complete,
            Submission = new()
            {
                InputMessageAccountabilityData = "20220118MMQFMP0P000002",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = WireTransfers::Type.WireTransfer,
            UniqueEndToEndTransactionReference = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransfer
        {
            ID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = WireTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Creditor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferCreditorAddressUnstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Line3 = null,
                    }
                ),
                Name = "National Phonograph Company",
            },
            Currency = WireTransfers::Currency.Usd,
            Debtor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferDebtorAddressUnstructured()
                    {
                        Line1 = "line1",
                        Line2 = "line2",
                        Line3 = "line3",
                    }
                ),
                Name = "name",
            },
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            IdempotencyKey = null,
            InboundWireDrawdownRequestID = null,
            Network = WireTransfers::Network.Wire,
            PendingTransactionID = null,
            Remittance = new()
            {
                Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "identification_number",
                    TypeCode = "type_code",
                },
                Unstructured = new("Invoice 29582"),
            },
            Reversal = new()
            {
                Amount = 12345,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DebtorRoutingNumber = "101050001",
                Description = "Inbound wire reversal 2022021100335128",
                InputCycleDate = "2022-02-11",
                InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                InputSequenceNumber = "11023",
                InputSource = "B6B7HU2R",
                InstructionIdentification = null,
                ReturnReasonAdditionalInformation = null,
                ReturnReasonCode = null,
                ReturnReasonCodeDescription = null,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = null,
            Status = WireTransfers::WireTransferStatus.Complete,
            Submission = new()
            {
                InputMessageAccountabilityData = "20220118MMQFMP0P000002",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = WireTransfers::Type.WireTransfer,
            UniqueEndToEndTransactionReference = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "wire_transfer_5akynk7dqsq25qwk9q2u";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        long expectedAmount = 100;
        WireTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        WireTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        WireTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = WireTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        WireTransfers::WireTransferCreditor expectedCreditor = new()
        {
            Address = new(
                new WireTransfers::WireTransferCreditorAddressUnstructured()
                {
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    Line3 = null,
                }
            ),
            Name = "National Phonograph Company",
        };
        ApiEnum<string, WireTransfers::Currency> expectedCurrency = WireTransfers::Currency.Usd;
        WireTransfers::WireTransferDebtor expectedDebtor = new()
        {
            Address = new(
                new WireTransfers::WireTransferDebtorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };
        string expectedExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv";
        ApiEnum<string, WireTransfers::Network> expectedNetwork = WireTransfers::Network.Wire;
        WireTransfers::WireTransferRemittance expectedRemittance = new()
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "identification_number",
                TypeCode = "type_code",
            },
            Unstructured = new("Invoice 29582"),
        };
        WireTransfers::Reversal expectedReversal = new()
        {
            Amount = 12345,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DebtorRoutingNumber = "101050001",
            Description = "Inbound wire reversal 2022021100335128",
            InputCycleDate = "2022-02-11",
            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
            InputSequenceNumber = "11023",
            InputSource = "B6B7HU2R",
            InstructionIdentification = null,
            ReturnReasonAdditionalInformation = null,
            ReturnReasonCode = null,
            ReturnReasonCodeDescription = null,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, WireTransfers::WireTransferStatus> expectedStatus =
            WireTransfers::WireTransferStatus.Complete;
        WireTransfers::Submission expectedSubmission = new()
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000002",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, WireTransfers::Type> expectedType = WireTransfers::Type.WireTransfer;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(expectedCancellation, deserialized.Cancellation);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedCreditor, deserialized.Creditor);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtor, deserialized.Debtor);
        Assert.Equal(expectedExternalAccountID, deserialized.ExternalAccountID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Null(deserialized.InboundWireDrawdownRequestID);
        Assert.Equal(expectedNetwork, deserialized.Network);
        Assert.Null(deserialized.PendingTransactionID);
        Assert.Equal(expectedRemittance, deserialized.Remittance);
        Assert.Equal(expectedReversal, deserialized.Reversal);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Null(deserialized.SourceAccountNumberID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Null(deserialized.UniqueEndToEndTransactionReference);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransfer
        {
            ID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = WireTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Creditor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferCreditorAddressUnstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Line3 = null,
                    }
                ),
                Name = "National Phonograph Company",
            },
            Currency = WireTransfers::Currency.Usd,
            Debtor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferDebtorAddressUnstructured()
                    {
                        Line1 = "line1",
                        Line2 = "line2",
                        Line3 = "line3",
                    }
                ),
                Name = "name",
            },
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            IdempotencyKey = null,
            InboundWireDrawdownRequestID = null,
            Network = WireTransfers::Network.Wire,
            PendingTransactionID = null,
            Remittance = new()
            {
                Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "identification_number",
                    TypeCode = "type_code",
                },
                Unstructured = new("Invoice 29582"),
            },
            Reversal = new()
            {
                Amount = 12345,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DebtorRoutingNumber = "101050001",
                Description = "Inbound wire reversal 2022021100335128",
                InputCycleDate = "2022-02-11",
                InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                InputSequenceNumber = "11023",
                InputSource = "B6B7HU2R",
                InstructionIdentification = null,
                ReturnReasonAdditionalInformation = null,
                ReturnReasonCode = null,
                ReturnReasonCodeDescription = null,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = null,
            Status = WireTransfers::WireTransferStatus.Complete,
            Submission = new()
            {
                InputMessageAccountabilityData = "20220118MMQFMP0P000002",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = WireTransfers::Type.WireTransfer,
            UniqueEndToEndTransactionReference = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransfer
        {
            ID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = WireTransfers::CreatedByCategory.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Creditor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferCreditorAddressUnstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Line3 = null,
                    }
                ),
                Name = "National Phonograph Company",
            },
            Currency = WireTransfers::Currency.Usd,
            Debtor = new()
            {
                Address = new(
                    new WireTransfers::WireTransferDebtorAddressUnstructured()
                    {
                        Line1 = "line1",
                        Line2 = "line2",
                        Line3 = "line3",
                    }
                ),
                Name = "name",
            },
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            IdempotencyKey = null,
            InboundWireDrawdownRequestID = null,
            Network = WireTransfers::Network.Wire,
            PendingTransactionID = null,
            Remittance = new()
            {
                Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "identification_number",
                    TypeCode = "type_code",
                },
                Unstructured = new("Invoice 29582"),
            },
            Reversal = new()
            {
                Amount = 12345,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DebtorRoutingNumber = "101050001",
                Description = "Inbound wire reversal 2022021100335128",
                InputCycleDate = "2022-02-11",
                InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                InputSequenceNumber = "11023",
                InputSource = "B6B7HU2R",
                InstructionIdentification = null,
                ReturnReasonAdditionalInformation = null,
                ReturnReasonCode = null,
                ReturnReasonCodeDescription = null,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
            },
            RoutingNumber = "101050001",
            SourceAccountNumberID = null,
            Status = WireTransfers::WireTransferStatus.Complete,
            Submission = new()
            {
                InputMessageAccountabilityData = "20220118MMQFMP0P000002",
                SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = WireTransfers::Type.WireTransfer,
            UniqueEndToEndTransactionReference = null,
        };

        WireTransfers::WireTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedApprovedAt, model.ApprovedAt);
        Assert.Null(model.ApprovedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::Approval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::Approval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedApprovedAt, deserialized.ApprovedAt);
        Assert.Null(deserialized.ApprovedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        WireTransfers::Approval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Null(model.CanceledBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::Cancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::Cancellation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Null(deserialized.CanceledBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        WireTransfers::Cancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, WireTransfers::CreatedByCategory> expectedCategory =
            WireTransfers::CreatedByCategory.User;
        WireTransfers::ApiKey expectedApiKey = new("description");
        WireTransfers::OAuthApplication expectedOAuthApplication = new("name");
        WireTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, WireTransfers::CreatedByCategory> expectedCategory =
            WireTransfers::CreatedByCategory.User;
        WireTransfers::ApiKey expectedApiKey = new("description");
        WireTransfers::OAuthApplication expectedOAuthApplication = new("name");
        WireTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,
        };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.OAuthApplication);
        Assert.False(model.RawData.ContainsKey("oauth_application"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        Assert.Null(model.ApiKey);
        Assert.True(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.OAuthApplication);
        Assert.True(model.RawData.ContainsKey("oauth_application"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::CreatedBy
        {
            Category = WireTransfers::CreatedByCategory.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        WireTransfers::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByCategoryTest : TestBase
{
    [Theory]
    [InlineData(WireTransfers::CreatedByCategory.ApiKey)]
    [InlineData(WireTransfers::CreatedByCategory.OAuthApplication)]
    [InlineData(WireTransfers::CreatedByCategory.User)]
    public void Validation_Works(WireTransfers::CreatedByCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::CreatedByCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::CreatedByCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WireTransfers::CreatedByCategory.ApiKey)]
    [InlineData(WireTransfers::CreatedByCategory.OAuthApplication)]
    [InlineData(WireTransfers::CreatedByCategory.User)]
    public void SerializationRoundtrip_Works(WireTransfers::CreatedByCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::CreatedByCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WireTransfers::CreatedByCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::CreatedByCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WireTransfers::CreatedByCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::ApiKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::ApiKey { Description = "description" };

        WireTransfers::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::OAuthApplication>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::OAuthApplication { Name = "name" };

        WireTransfers::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::User>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::User { Email = "email" };

        WireTransfers::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferCreditorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferCreditor
        {
            Address = new(
                new WireTransfers::WireTransferCreditorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        WireTransfers::WireTransferCreditorAddress expectedAddress = new(
            new WireTransfers::WireTransferCreditorAddressUnstructured()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            }
        );
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferCreditor
        {
            Address = new(
                new WireTransfers::WireTransferCreditorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferCreditor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferCreditor
        {
            Address = new(
                new WireTransfers::WireTransferCreditorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferCreditor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WireTransfers::WireTransferCreditorAddress expectedAddress = new(
            new WireTransfers::WireTransferCreditorAddressUnstructured()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            }
        );
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferCreditor
        {
            Address = new(
                new WireTransfers::WireTransferCreditorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferCreditor
        {
            Address = new(
                new WireTransfers::WireTransferCreditorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        WireTransfers::WireTransferCreditor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferCreditorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        WireTransfers::WireTransferCreditorAddressUnstructured expectedUnstructured = new()
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        Assert.Equal(expectedUnstructured, model.Unstructured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferCreditorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferCreditorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WireTransfers::WireTransferCreditorAddressUnstructured expectedUnstructured = new()
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        Assert.Equal(expectedUnstructured, deserialized.Unstructured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        WireTransfers::WireTransferCreditorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferCreditorAddressUnstructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedLine3 = "line3";

        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedLine3, model.Line3);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireTransfers::WireTransferCreditorAddressUnstructured>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireTransfers::WireTransferCreditorAddressUnstructured>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedLine3 = "line3";

        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedLine3, deserialized.Line3);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferCreditorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        WireTransfers::WireTransferCreditorAddressUnstructured copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(WireTransfers::Currency.Usd)]
    public void Validation_Works(WireTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WireTransfers::Currency.Usd)]
    public void SerializationRoundtrip_Works(WireTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WireTransferDebtorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferDebtor
        {
            Address = new(
                new WireTransfers::WireTransferDebtorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        WireTransfers::WireTransferDebtorAddress expectedAddress = new(
            new WireTransfers::WireTransferDebtorAddressUnstructured()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            }
        );
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferDebtor
        {
            Address = new(
                new WireTransfers::WireTransferDebtorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferDebtor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferDebtor
        {
            Address = new(
                new WireTransfers::WireTransferDebtorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferDebtor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WireTransfers::WireTransferDebtorAddress expectedAddress = new(
            new WireTransfers::WireTransferDebtorAddressUnstructured()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            }
        );
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferDebtor
        {
            Address = new(
                new WireTransfers::WireTransferDebtorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferDebtor
        {
            Address = new(
                new WireTransfers::WireTransferDebtorAddressUnstructured()
                {
                    Line1 = "line1",
                    Line2 = "line2",
                    Line3 = "line3",
                }
            ),
            Name = "name",
        };

        WireTransfers::WireTransferDebtor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferDebtorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        WireTransfers::WireTransferDebtorAddressUnstructured expectedUnstructured = new()
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        Assert.Equal(expectedUnstructured, model.Unstructured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferDebtorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferDebtorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WireTransfers::WireTransferDebtorAddressUnstructured expectedUnstructured = new()
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        Assert.Equal(expectedUnstructured, deserialized.Unstructured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddress
        {
            Unstructured = new()
            {
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
            },
        };

        WireTransfers::WireTransferDebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferDebtorAddressUnstructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedLine3 = "line3";

        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedLine3, model.Line3);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireTransfers::WireTransferDebtorAddressUnstructured>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireTransfers::WireTransferDebtorAddressUnstructured>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedLine3 = "line3";

        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedLine3, deserialized.Line3);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferDebtorAddressUnstructured
        {
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
        };

        WireTransfers::WireTransferDebtorAddressUnstructured copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NetworkTest : TestBase
{
    [Theory]
    [InlineData(WireTransfers::Network.Wire)]
    public void Validation_Works(WireTransfers::Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::Network> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Network>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WireTransfers::Network.Wire)]
    public void SerializationRoundtrip_Works(WireTransfers::Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::Network> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Network>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Network>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Network>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WireTransferRemittanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "identification_number",
                TypeCode = "type_code",
            },
            Unstructured = new("Invoice 29582"),
        };

        ApiEnum<string, WireTransfers::WireTransferRemittanceCategory> expectedCategory =
            WireTransfers::WireTransferRemittanceCategory.Unstructured;
        WireTransfers::WireTransferRemittanceTax expectedTax = new()
        {
            Date = "2019-12-27",
            IdentificationNumber = "identification_number",
            TypeCode = "type_code",
        };
        WireTransfers::WireTransferRemittanceUnstructured expectedUnstructured = new(
            "Invoice 29582"
        );

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedUnstructured, model.Unstructured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "identification_number",
                TypeCode = "type_code",
            },
            Unstructured = new("Invoice 29582"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferRemittance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "identification_number",
                TypeCode = "type_code",
            },
            Unstructured = new("Invoice 29582"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferRemittance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, WireTransfers::WireTransferRemittanceCategory> expectedCategory =
            WireTransfers::WireTransferRemittanceCategory.Unstructured;
        WireTransfers::WireTransferRemittanceTax expectedTax = new()
        {
            Date = "2019-12-27",
            IdentificationNumber = "identification_number",
            TypeCode = "type_code",
        };
        WireTransfers::WireTransferRemittanceUnstructured expectedUnstructured = new(
            "Invoice 29582"
        );

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedUnstructured, deserialized.Unstructured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "identification_number",
                TypeCode = "type_code",
            },
            Unstructured = new("Invoice 29582"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
        };

        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
        Assert.Null(model.Unstructured);
        Assert.False(model.RawData.ContainsKey("unstructured"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,

            Tax = null,
            Unstructured = null,
        };

        Assert.Null(model.Tax);
        Assert.True(model.RawData.ContainsKey("tax"));
        Assert.Null(model.Unstructured);
        Assert.True(model.RawData.ContainsKey("unstructured"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,

            Tax = null,
            Unstructured = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferRemittance
        {
            Category = WireTransfers::WireTransferRemittanceCategory.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "identification_number",
                TypeCode = "type_code",
            },
            Unstructured = new("Invoice 29582"),
        };

        WireTransfers::WireTransferRemittance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferRemittanceCategoryTest : TestBase
{
    [Theory]
    [InlineData(WireTransfers::WireTransferRemittanceCategory.Unstructured)]
    [InlineData(WireTransfers::WireTransferRemittanceCategory.Tax)]
    public void Validation_Works(WireTransfers::WireTransferRemittanceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::WireTransferRemittanceCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WireTransfers::WireTransferRemittanceCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WireTransfers::WireTransferRemittanceCategory.Unstructured)]
    [InlineData(WireTransfers::WireTransferRemittanceCategory.Tax)]
    public void SerializationRoundtrip_Works(WireTransfers::WireTransferRemittanceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::WireTransferRemittanceCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WireTransfers::WireTransferRemittanceCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WireTransfers::WireTransferRemittanceCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WireTransfers::WireTransferRemittanceCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WireTransferRemittanceTaxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceTax
        {
            Date = "2019-12-27",
            IdentificationNumber = "identification_number",
            TypeCode = "type_code",
        };

        string expectedDate = "2019-12-27";
        string expectedIdentificationNumber = "identification_number";
        string expectedTypeCode = "type_code";

        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedIdentificationNumber, model.IdentificationNumber);
        Assert.Equal(expectedTypeCode, model.TypeCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceTax
        {
            Date = "2019-12-27",
            IdentificationNumber = "identification_number",
            TypeCode = "type_code",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferRemittanceTax>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceTax
        {
            Date = "2019-12-27",
            IdentificationNumber = "identification_number",
            TypeCode = "type_code",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferRemittanceTax>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDate = "2019-12-27";
        string expectedIdentificationNumber = "identification_number";
        string expectedTypeCode = "type_code";

        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedIdentificationNumber, deserialized.IdentificationNumber);
        Assert.Equal(expectedTypeCode, deserialized.TypeCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceTax
        {
            Date = "2019-12-27",
            IdentificationNumber = "identification_number",
            TypeCode = "type_code",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceTax
        {
            Date = "2019-12-27",
            IdentificationNumber = "identification_number",
            TypeCode = "type_code",
        };

        WireTransfers::WireTransferRemittanceTax copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferRemittanceUnstructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceUnstructured { Message = "message" };

        string expectedMessage = "message";

        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceUnstructured { Message = "message" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireTransfers::WireTransferRemittanceUnstructured>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceUnstructured { Message = "message" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireTransfers::WireTransferRemittanceUnstructured>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";

        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceUnstructured { Message = "message" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferRemittanceUnstructured { Message = "message" };

        WireTransfers::WireTransferRemittanceUnstructured copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReversalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::Reversal
        {
            Amount = 12345,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DebtorRoutingNumber = "101050001",
            Description = "Inbound wire reversal 2022021100335128",
            InputCycleDate = "2022-02-11",
            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
            InputSequenceNumber = "11023",
            InputSource = "B6B7HU2R",
            InstructionIdentification = null,
            ReturnReasonAdditionalInformation = null,
            ReturnReasonCode = null,
            ReturnReasonCodeDescription = null,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        long expectedAmount = 12345;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDebtorRoutingNumber = "101050001";
        string expectedDescription = "Inbound wire reversal 2022021100335128";
        string expectedInputCycleDate = "2022-02-11";
        string expectedInputMessageAccountabilityData = "20220211B6B7HU2R011023";
        string expectedInputSequenceNumber = "11023";
        string expectedInputSource = "B6B7HU2R";
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedWireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDebtorRoutingNumber, model.DebtorRoutingNumber);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedInputCycleDate, model.InputCycleDate);
        Assert.Equal(expectedInputMessageAccountabilityData, model.InputMessageAccountabilityData);
        Assert.Equal(expectedInputSequenceNumber, model.InputSequenceNumber);
        Assert.Equal(expectedInputSource, model.InputSource);
        Assert.Null(model.InstructionIdentification);
        Assert.Null(model.ReturnReasonAdditionalInformation);
        Assert.Null(model.ReturnReasonCode);
        Assert.Null(model.ReturnReasonCodeDescription);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedWireTransferID, model.WireTransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::Reversal
        {
            Amount = 12345,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DebtorRoutingNumber = "101050001",
            Description = "Inbound wire reversal 2022021100335128",
            InputCycleDate = "2022-02-11",
            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
            InputSequenceNumber = "11023",
            InputSource = "B6B7HU2R",
            InstructionIdentification = null,
            ReturnReasonAdditionalInformation = null,
            ReturnReasonCode = null,
            ReturnReasonCodeDescription = null,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::Reversal>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::Reversal
        {
            Amount = 12345,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DebtorRoutingNumber = "101050001",
            Description = "Inbound wire reversal 2022021100335128",
            InputCycleDate = "2022-02-11",
            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
            InputSequenceNumber = "11023",
            InputSource = "B6B7HU2R",
            InstructionIdentification = null,
            ReturnReasonAdditionalInformation = null,
            ReturnReasonCode = null,
            ReturnReasonCodeDescription = null,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::Reversal>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 12345;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDebtorRoutingNumber = "101050001";
        string expectedDescription = "Inbound wire reversal 2022021100335128";
        string expectedInputCycleDate = "2022-02-11";
        string expectedInputMessageAccountabilityData = "20220211B6B7HU2R011023";
        string expectedInputSequenceNumber = "11023";
        string expectedInputSource = "B6B7HU2R";
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedWireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDebtorRoutingNumber, deserialized.DebtorRoutingNumber);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedInputCycleDate, deserialized.InputCycleDate);
        Assert.Equal(
            expectedInputMessageAccountabilityData,
            deserialized.InputMessageAccountabilityData
        );
        Assert.Equal(expectedInputSequenceNumber, deserialized.InputSequenceNumber);
        Assert.Equal(expectedInputSource, deserialized.InputSource);
        Assert.Null(deserialized.InstructionIdentification);
        Assert.Null(deserialized.ReturnReasonAdditionalInformation);
        Assert.Null(deserialized.ReturnReasonCode);
        Assert.Null(deserialized.ReturnReasonCodeDescription);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedWireTransferID, deserialized.WireTransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::Reversal
        {
            Amount = 12345,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DebtorRoutingNumber = "101050001",
            Description = "Inbound wire reversal 2022021100335128",
            InputCycleDate = "2022-02-11",
            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
            InputSequenceNumber = "11023",
            InputSource = "B6B7HU2R",
            InstructionIdentification = null,
            ReturnReasonAdditionalInformation = null,
            ReturnReasonCode = null,
            ReturnReasonCodeDescription = null,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::Reversal
        {
            Amount = 12345,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DebtorRoutingNumber = "101050001",
            Description = "Inbound wire reversal 2022021100335128",
            InputCycleDate = "2022-02-11",
            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
            InputSequenceNumber = "11023",
            InputSource = "B6B7HU2R",
            InstructionIdentification = null,
            ReturnReasonAdditionalInformation = null,
            ReturnReasonCode = null,
            ReturnReasonCodeDescription = null,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
        };

        WireTransfers::Reversal copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(WireTransfers::WireTransferStatus.PendingApproval)]
    [InlineData(WireTransfers::WireTransferStatus.Canceled)]
    [InlineData(WireTransfers::WireTransferStatus.PendingReviewing)]
    [InlineData(WireTransfers::WireTransferStatus.Rejected)]
    [InlineData(WireTransfers::WireTransferStatus.RequiresAttention)]
    [InlineData(WireTransfers::WireTransferStatus.PendingCreating)]
    [InlineData(WireTransfers::WireTransferStatus.Reversed)]
    [InlineData(WireTransfers::WireTransferStatus.Submitted)]
    [InlineData(WireTransfers::WireTransferStatus.Complete)]
    public void Validation_Works(WireTransfers::WireTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::WireTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::WireTransferStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WireTransfers::WireTransferStatus.PendingApproval)]
    [InlineData(WireTransfers::WireTransferStatus.Canceled)]
    [InlineData(WireTransfers::WireTransferStatus.PendingReviewing)]
    [InlineData(WireTransfers::WireTransferStatus.Rejected)]
    [InlineData(WireTransfers::WireTransferStatus.RequiresAttention)]
    [InlineData(WireTransfers::WireTransferStatus.PendingCreating)]
    [InlineData(WireTransfers::WireTransferStatus.Reversed)]
    [InlineData(WireTransfers::WireTransferStatus.Submitted)]
    [InlineData(WireTransfers::WireTransferStatus.Complete)]
    public void SerializationRoundtrip_Works(WireTransfers::WireTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::WireTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WireTransfers::WireTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::WireTransferStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WireTransfers::WireTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000002",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string expectedInputMessageAccountabilityData = "20220118MMQFMP0P000002";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedInputMessageAccountabilityData, model.InputMessageAccountabilityData);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireTransfers::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000002",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000002",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInputMessageAccountabilityData = "20220118MMQFMP0P000002";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(
            expectedInputMessageAccountabilityData,
            deserialized.InputMessageAccountabilityData
        );
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireTransfers::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000002",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000002",
            SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        WireTransfers::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(WireTransfers::Type.WireTransfer)]
    public void Validation_Works(WireTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WireTransfers::Type.WireTransfer)]
    public void SerializationRoundtrip_Works(WireTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WireTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
