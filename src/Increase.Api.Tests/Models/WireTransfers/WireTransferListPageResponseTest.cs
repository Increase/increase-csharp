using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using WireTransfers = Increase.Api.Models.WireTransfers;

namespace Increase.Api.Tests.Models.WireTransfers;

public class WireTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireTransfers::WireTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<WireTransfers::WireTransfer> expectedData =
        [
            new()
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
        var model = new WireTransfers::WireTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireTransfers::WireTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireTransfers::WireTransferListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WireTransfers::WireTransfer> expectedData =
        [
            new()
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
        var model = new WireTransfers::WireTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireTransfers::WireTransferListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        WireTransfers::WireTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
