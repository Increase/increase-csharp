using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using SwiftTransfers = Increase.Api.Models.SwiftTransfers;

namespace Increase.Api.Tests.Models.SwiftTransfers;

public class SwiftTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwiftTransfers::SwiftTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "swift_transfer_29h21xkng03788zwd3fh",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 100,
                    BankIdentificationCode = "ECBFDEFFTPP",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = SwiftTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorAddress = new()
                    {
                        City = "Frankfurt",
                        Country = "DE",
                        Line1 = "Sonnemannstrasse 20",
                        Line2 = null,
                        PostalCode = "60314",
                        State = null,
                    },
                    CreditorName = "Ian Crease",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = null,
                    },
                    DebtorName = "National Phonograph Company",
                    IdempotencyKey = null,
                    InstructedAmount = 100,
                    InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    RoutingNumber = null,
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = SwiftTransfers::SwiftTransferStatus.Initiated,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = SwiftTransfers::Type.SwiftTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "Remittance information",
                },
            ],
            NextCursor = "v57w5d",
        };

        List<SwiftTransfers::SwiftTransfer> expectedData =
        [
            new()
            {
                ID = "swift_transfer_29h21xkng03788zwd3fh",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumber = "987654321",
                Amount = 100,
                BankIdentificationCode = "ECBFDEFFTPP",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = SwiftTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                CreditorAddress = new()
                {
                    City = "Frankfurt",
                    Country = "DE",
                    Line1 = "Sonnemannstrasse 20",
                    Line2 = null,
                    PostalCode = "60314",
                    State = null,
                },
                CreditorName = "Ian Crease",
                DebtorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    PostalCode = "10045",
                    State = null,
                },
                DebtorName = "National Phonograph Company",
                IdempotencyKey = null,
                InstructedAmount = 100,
                InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                RoutingNumber = null,
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Status = SwiftTransfers::SwiftTransferStatus.Initiated,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = SwiftTransfers::Type.SwiftTransfer,
                UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                UnstructuredRemittanceInformation = "Remittance information",
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
        var model = new SwiftTransfers::SwiftTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "swift_transfer_29h21xkng03788zwd3fh",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 100,
                    BankIdentificationCode = "ECBFDEFFTPP",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = SwiftTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorAddress = new()
                    {
                        City = "Frankfurt",
                        Country = "DE",
                        Line1 = "Sonnemannstrasse 20",
                        Line2 = null,
                        PostalCode = "60314",
                        State = null,
                    },
                    CreditorName = "Ian Crease",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = null,
                    },
                    DebtorName = "National Phonograph Company",
                    IdempotencyKey = null,
                    InstructedAmount = 100,
                    InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    RoutingNumber = null,
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = SwiftTransfers::SwiftTransferStatus.Initiated,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = SwiftTransfers::Type.SwiftTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "Remittance information",
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SwiftTransfers::SwiftTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwiftTransfers::SwiftTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "swift_transfer_29h21xkng03788zwd3fh",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 100,
                    BankIdentificationCode = "ECBFDEFFTPP",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = SwiftTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorAddress = new()
                    {
                        City = "Frankfurt",
                        Country = "DE",
                        Line1 = "Sonnemannstrasse 20",
                        Line2 = null,
                        PostalCode = "60314",
                        State = null,
                    },
                    CreditorName = "Ian Crease",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = null,
                    },
                    DebtorName = "National Phonograph Company",
                    IdempotencyKey = null,
                    InstructedAmount = 100,
                    InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    RoutingNumber = null,
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = SwiftTransfers::SwiftTransferStatus.Initiated,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = SwiftTransfers::Type.SwiftTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "Remittance information",
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SwiftTransfers::SwiftTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<SwiftTransfers::SwiftTransfer> expectedData =
        [
            new()
            {
                ID = "swift_transfer_29h21xkng03788zwd3fh",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumber = "987654321",
                Amount = 100,
                BankIdentificationCode = "ECBFDEFFTPP",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = SwiftTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                CreditorAddress = new()
                {
                    City = "Frankfurt",
                    Country = "DE",
                    Line1 = "Sonnemannstrasse 20",
                    Line2 = null,
                    PostalCode = "60314",
                    State = null,
                },
                CreditorName = "Ian Crease",
                DebtorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    PostalCode = "10045",
                    State = null,
                },
                DebtorName = "National Phonograph Company",
                IdempotencyKey = null,
                InstructedAmount = 100,
                InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                RoutingNumber = null,
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Status = SwiftTransfers::SwiftTransferStatus.Initiated,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = SwiftTransfers::Type.SwiftTransfer,
                UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                UnstructuredRemittanceInformation = "Remittance information",
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
        var model = new SwiftTransfers::SwiftTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "swift_transfer_29h21xkng03788zwd3fh",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 100,
                    BankIdentificationCode = "ECBFDEFFTPP",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = SwiftTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorAddress = new()
                    {
                        City = "Frankfurt",
                        Country = "DE",
                        Line1 = "Sonnemannstrasse 20",
                        Line2 = null,
                        PostalCode = "60314",
                        State = null,
                    },
                    CreditorName = "Ian Crease",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = null,
                    },
                    DebtorName = "National Phonograph Company",
                    IdempotencyKey = null,
                    InstructedAmount = 100,
                    InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    RoutingNumber = null,
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = SwiftTransfers::SwiftTransferStatus.Initiated,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = SwiftTransfers::Type.SwiftTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "Remittance information",
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SwiftTransfers::SwiftTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "swift_transfer_29h21xkng03788zwd3fh",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 100,
                    BankIdentificationCode = "ECBFDEFFTPP",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = SwiftTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    CreditorAddress = new()
                    {
                        City = "Frankfurt",
                        Country = "DE",
                        Line1 = "Sonnemannstrasse 20",
                        Line2 = null,
                        PostalCode = "60314",
                        State = null,
                    },
                    CreditorName = "Ian Crease",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = null,
                    },
                    DebtorName = "National Phonograph Company",
                    IdempotencyKey = null,
                    InstructedAmount = 100,
                    InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    RoutingNumber = null,
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = SwiftTransfers::SwiftTransferStatus.Initiated,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = SwiftTransfers::Type.SwiftTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "Remittance information",
                },
            ],
            NextCursor = "v57w5d",
        };

        SwiftTransfers::SwiftTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
