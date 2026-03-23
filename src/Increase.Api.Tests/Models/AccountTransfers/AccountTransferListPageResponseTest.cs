using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using AccountTransfers = Increase.Api.Models.AccountTransfers;

namespace Increase.Api.Tests.Models.AccountTransfers;

public class AccountTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountTransfers::AccountTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    AccountID = "account_in71c4amph0vgo2qllky",
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
                        Category = AccountTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = AccountTransfers::Currency.Usd,
                    Description = "Move money into savings",
                    DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                    DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Status = AccountTransfers::Status.Complete,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AccountTransfers::Type.AccountTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<AccountTransfers::AccountTransfer> expectedData =
        [
            new()
            {
                ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                AccountID = "account_in71c4amph0vgo2qllky",
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
                    Category = AccountTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                Currency = AccountTransfers::Currency.Usd,
                Description = "Move money into savings",
                DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
                IdempotencyKey = null,
                PendingTransactionID = null,
                Status = AccountTransfers::Status.Complete,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = AccountTransfers::Type.AccountTransfer,
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
        var model = new AccountTransfers::AccountTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    AccountID = "account_in71c4amph0vgo2qllky",
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
                        Category = AccountTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = AccountTransfers::Currency.Usd,
                    Description = "Move money into savings",
                    DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                    DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Status = AccountTransfers::Status.Complete,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AccountTransfers::Type.AccountTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountTransfers::AccountTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransfers::AccountTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    AccountID = "account_in71c4amph0vgo2qllky",
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
                        Category = AccountTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = AccountTransfers::Currency.Usd,
                    Description = "Move money into savings",
                    DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                    DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Status = AccountTransfers::Status.Complete,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AccountTransfers::Type.AccountTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountTransfers::AccountTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<AccountTransfers::AccountTransfer> expectedData =
        [
            new()
            {
                ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                AccountID = "account_in71c4amph0vgo2qllky",
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
                    Category = AccountTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                Currency = AccountTransfers::Currency.Usd,
                Description = "Move money into savings",
                DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
                IdempotencyKey = null,
                PendingTransactionID = null,
                Status = AccountTransfers::Status.Complete,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = AccountTransfers::Type.AccountTransfer,
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
        var model = new AccountTransfers::AccountTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    AccountID = "account_in71c4amph0vgo2qllky",
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
                        Category = AccountTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = AccountTransfers::Currency.Usd,
                    Description = "Move money into savings",
                    DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                    DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Status = AccountTransfers::Status.Complete,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AccountTransfers::Type.AccountTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransfers::AccountTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    AccountID = "account_in71c4amph0vgo2qllky",
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
                        Category = AccountTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = AccountTransfers::Currency.Usd,
                    Description = "Move money into savings",
                    DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                    DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
                    IdempotencyKey = null,
                    PendingTransactionID = null,
                    Status = AccountTransfers::Status.Complete,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = AccountTransfers::Type.AccountTransfer,
                },
            ],
            NextCursor = "v57w5d",
        };

        AccountTransfers::AccountTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
