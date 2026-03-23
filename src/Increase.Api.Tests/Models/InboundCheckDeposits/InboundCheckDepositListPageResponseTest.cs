using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using InboundCheckDeposits = Increase.Api.Models.InboundCheckDeposits;

namespace Increase.Api.Tests.Models.InboundCheckDeposits;

public class InboundCheckDepositListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundCheckDeposits::InboundCheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Adjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Amount = 0,
                            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                            TransactionID = "transaction_id",
                        },
                    ],
                    Amount = 1000,
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    BankOfFirstDepositRoutingNumber = "101050001",
                    CheckNumber = "123",
                    CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = InboundCheckDeposits::Currency.Usd,
                    DeclinedAt = null,
                    DeclinedTransactionID = null,
                    DepositReturn = new()
                    {
                        Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    PayeeNameAnalysis = InboundCheckDeposits::PayeeNameAnalysis.NameMatches,
                    Status = InboundCheckDeposits::Status.Accepted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundCheckDeposits::Type.InboundCheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<InboundCheckDeposits::InboundCheckDeposit> expectedData =
        [
            new()
            {
                ID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Adjustments =
                [
                    new()
                    {
                        AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Amount = 0,
                        Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                        TransactionID = "transaction_id",
                    },
                ],
                Amount = 1000,
                BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                BankOfFirstDepositRoutingNumber = "101050001",
                CheckNumber = "123",
                CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = InboundCheckDeposits::Currency.Usd,
                DeclinedAt = null,
                DeclinedTransactionID = null,
                DepositReturn = new()
                {
                    Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
                    ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransactionID = "transaction_id",
                },
                FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                PayeeNameAnalysis = InboundCheckDeposits::PayeeNameAnalysis.NameMatches,
                Status = InboundCheckDeposits::Status.Accepted,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = InboundCheckDeposits::Type.InboundCheckDeposit,
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
        var model = new InboundCheckDeposits::InboundCheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Adjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Amount = 0,
                            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                            TransactionID = "transaction_id",
                        },
                    ],
                    Amount = 1000,
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    BankOfFirstDepositRoutingNumber = "101050001",
                    CheckNumber = "123",
                    CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = InboundCheckDeposits::Currency.Usd,
                    DeclinedAt = null,
                    DeclinedTransactionID = null,
                    DepositReturn = new()
                    {
                        Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    PayeeNameAnalysis = InboundCheckDeposits::PayeeNameAnalysis.NameMatches,
                    Status = InboundCheckDeposits::Status.Accepted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundCheckDeposits::Type.InboundCheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundCheckDeposits::InboundCheckDepositListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundCheckDeposits::InboundCheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Adjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Amount = 0,
                            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                            TransactionID = "transaction_id",
                        },
                    ],
                    Amount = 1000,
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    BankOfFirstDepositRoutingNumber = "101050001",
                    CheckNumber = "123",
                    CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = InboundCheckDeposits::Currency.Usd,
                    DeclinedAt = null,
                    DeclinedTransactionID = null,
                    DepositReturn = new()
                    {
                        Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    PayeeNameAnalysis = InboundCheckDeposits::PayeeNameAnalysis.NameMatches,
                    Status = InboundCheckDeposits::Status.Accepted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundCheckDeposits::Type.InboundCheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundCheckDeposits::InboundCheckDepositListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<InboundCheckDeposits::InboundCheckDeposit> expectedData =
        [
            new()
            {
                ID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Adjustments =
                [
                    new()
                    {
                        AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Amount = 0,
                        Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                        TransactionID = "transaction_id",
                    },
                ],
                Amount = 1000,
                BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                BankOfFirstDepositRoutingNumber = "101050001",
                CheckNumber = "123",
                CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = InboundCheckDeposits::Currency.Usd,
                DeclinedAt = null,
                DeclinedTransactionID = null,
                DepositReturn = new()
                {
                    Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
                    ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    TransactionID = "transaction_id",
                },
                FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                PayeeNameAnalysis = InboundCheckDeposits::PayeeNameAnalysis.NameMatches,
                Status = InboundCheckDeposits::Status.Accepted,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = InboundCheckDeposits::Type.InboundCheckDeposit,
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
        var model = new InboundCheckDeposits::InboundCheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Adjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Amount = 0,
                            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                            TransactionID = "transaction_id",
                        },
                    ],
                    Amount = 1000,
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    BankOfFirstDepositRoutingNumber = "101050001",
                    CheckNumber = "123",
                    CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = InboundCheckDeposits::Currency.Usd,
                    DeclinedAt = null,
                    DeclinedTransactionID = null,
                    DepositReturn = new()
                    {
                        Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    PayeeNameAnalysis = InboundCheckDeposits::PayeeNameAnalysis.NameMatches,
                    Status = InboundCheckDeposits::Status.Accepted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundCheckDeposits::Type.InboundCheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundCheckDeposits::InboundCheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Adjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            Amount = 0,
                            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                            TransactionID = "transaction_id",
                        },
                    ],
                    Amount = 1000,
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    BankOfFirstDepositRoutingNumber = "101050001",
                    CheckNumber = "123",
                    CheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = InboundCheckDeposits::Currency.Usd,
                    DeclinedAt = null,
                    DeclinedTransactionID = null,
                    DepositReturn = new()
                    {
                        Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
                        ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        TransactionID = "transaction_id",
                    },
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    PayeeNameAnalysis = InboundCheckDeposits::PayeeNameAnalysis.NameMatches,
                    Status = InboundCheckDeposits::Status.Accepted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundCheckDeposits::Type.InboundCheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        InboundCheckDeposits::InboundCheckDepositListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
