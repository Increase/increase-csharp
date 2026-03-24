using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using CheckDeposits = Increase.Api.Models.CheckDeposits;

namespace Increase.Api.Tests.Models.CheckDeposits;

public class CheckDepositListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckDeposits::CheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1000,
                    BackImageFileID = "file_26khfk98mzfz90a11oqx",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DepositAcceptance = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 1000,
                        AuxiliaryOnUs = "101",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::Currency.Usd,
                        RoutingNumber = "101050001",
                        SerialNumber = null,
                    },
                    DepositAdjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Amount = 1750,
                            Reason = CheckDeposits::Reason.AdjustedAmount,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                    ],
                    DepositRejection = new()
                    {
                        Amount = 1750,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositRejectionCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    DepositReturn = new()
                    {
                        Amount = 100,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositReturnCurrency.Usd,
                        ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    DepositSubmission = new()
                    {
                        BackFileID = "file_frhw4s443nh7noss55kq",
                        FrontFileID = "file_j7ed9mrve741m6yui9ju",
                        SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    },
                    Description = null,
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = CheckDeposits::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = CheckDeposits::Status.Held,
                        Type = CheckDeposits::Type.InboundFundsHold,
                    },
                    InboundMailItemID = null,
                    LockboxID = null,
                    Status = CheckDeposits::CheckDepositStatus.Submitted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = CheckDeposits::CheckDepositType.CheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<CheckDeposits::CheckDeposit> expectedData =
        [
            new()
            {
                ID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 1000,
                BackImageFileID = "file_26khfk98mzfz90a11oqx",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DepositAcceptance = new()
                {
                    AccountNumber = "987654321",
                    Amount = 1000,
                    AuxiliaryOnUs = "101",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    Currency = CheckDeposits::Currency.Usd,
                    RoutingNumber = "101050001",
                    SerialNumber = null,
                },
                DepositAdjustments =
                [
                    new()
                    {
                        AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Amount = 1750,
                        Reason = CheckDeposits::Reason.AdjustedAmount,
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                ],
                DepositRejection = new()
                {
                    Amount = 1750,
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    Currency = CheckDeposits::DepositRejectionCurrency.Usd,
                    DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                    Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
                    RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
                DepositReturn = new()
                {
                    Amount = 100,
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    Currency = CheckDeposits::DepositReturnCurrency.Usd,
                    ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
                    ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                },
                DepositSubmission = new()
                {
                    BackFileID = "file_frhw4s443nh7noss55kq",
                    FrontFileID = "file_j7ed9mrve741m6yui9ju",
                    SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                },
                Description = null,
                FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                IdempotencyKey = null,
                InboundFundsHold = new()
                {
                    Amount = 100,
                    AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = CheckDeposits::InboundFundsHoldCurrency.Usd,
                    HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    ReleasedAt = null,
                    Status = CheckDeposits::Status.Held,
                    Type = CheckDeposits::Type.InboundFundsHold,
                },
                InboundMailItemID = null,
                LockboxID = null,
                Status = CheckDeposits::CheckDepositStatus.Submitted,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = CheckDeposits::CheckDepositType.CheckDeposit,
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
        var model = new CheckDeposits::CheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1000,
                    BackImageFileID = "file_26khfk98mzfz90a11oqx",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DepositAcceptance = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 1000,
                        AuxiliaryOnUs = "101",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::Currency.Usd,
                        RoutingNumber = "101050001",
                        SerialNumber = null,
                    },
                    DepositAdjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Amount = 1750,
                            Reason = CheckDeposits::Reason.AdjustedAmount,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                    ],
                    DepositRejection = new()
                    {
                        Amount = 1750,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositRejectionCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    DepositReturn = new()
                    {
                        Amount = 100,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositReturnCurrency.Usd,
                        ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    DepositSubmission = new()
                    {
                        BackFileID = "file_frhw4s443nh7noss55kq",
                        FrontFileID = "file_j7ed9mrve741m6yui9ju",
                        SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    },
                    Description = null,
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = CheckDeposits::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = CheckDeposits::Status.Held,
                        Type = CheckDeposits::Type.InboundFundsHold,
                    },
                    InboundMailItemID = null,
                    LockboxID = null,
                    Status = CheckDeposits::CheckDepositStatus.Submitted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = CheckDeposits::CheckDepositType.CheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::CheckDepositListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckDeposits::CheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1000,
                    BackImageFileID = "file_26khfk98mzfz90a11oqx",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DepositAcceptance = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 1000,
                        AuxiliaryOnUs = "101",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::Currency.Usd,
                        RoutingNumber = "101050001",
                        SerialNumber = null,
                    },
                    DepositAdjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Amount = 1750,
                            Reason = CheckDeposits::Reason.AdjustedAmount,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                    ],
                    DepositRejection = new()
                    {
                        Amount = 1750,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositRejectionCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    DepositReturn = new()
                    {
                        Amount = 100,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositReturnCurrency.Usd,
                        ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    DepositSubmission = new()
                    {
                        BackFileID = "file_frhw4s443nh7noss55kq",
                        FrontFileID = "file_j7ed9mrve741m6yui9ju",
                        SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    },
                    Description = null,
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = CheckDeposits::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = CheckDeposits::Status.Held,
                        Type = CheckDeposits::Type.InboundFundsHold,
                    },
                    InboundMailItemID = null,
                    LockboxID = null,
                    Status = CheckDeposits::CheckDepositStatus.Submitted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = CheckDeposits::CheckDepositType.CheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::CheckDepositListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CheckDeposits::CheckDeposit> expectedData =
        [
            new()
            {
                ID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 1000,
                BackImageFileID = "file_26khfk98mzfz90a11oqx",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DepositAcceptance = new()
                {
                    AccountNumber = "987654321",
                    Amount = 1000,
                    AuxiliaryOnUs = "101",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    Currency = CheckDeposits::Currency.Usd,
                    RoutingNumber = "101050001",
                    SerialNumber = null,
                },
                DepositAdjustments =
                [
                    new()
                    {
                        AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Amount = 1750,
                        Reason = CheckDeposits::Reason.AdjustedAmount,
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                ],
                DepositRejection = new()
                {
                    Amount = 1750,
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    Currency = CheckDeposits::DepositRejectionCurrency.Usd,
                    DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                    Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
                    RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
                DepositReturn = new()
                {
                    Amount = 100,
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    Currency = CheckDeposits::DepositReturnCurrency.Usd,
                    ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
                    ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                },
                DepositSubmission = new()
                {
                    BackFileID = "file_frhw4s443nh7noss55kq",
                    FrontFileID = "file_j7ed9mrve741m6yui9ju",
                    SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                },
                Description = null,
                FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                IdempotencyKey = null,
                InboundFundsHold = new()
                {
                    Amount = 100,
                    AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = CheckDeposits::InboundFundsHoldCurrency.Usd,
                    HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    ReleasedAt = null,
                    Status = CheckDeposits::Status.Held,
                    Type = CheckDeposits::Type.InboundFundsHold,
                },
                InboundMailItemID = null,
                LockboxID = null,
                Status = CheckDeposits::CheckDepositStatus.Submitted,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = CheckDeposits::CheckDepositType.CheckDeposit,
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
        var model = new CheckDeposits::CheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1000,
                    BackImageFileID = "file_26khfk98mzfz90a11oqx",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DepositAcceptance = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 1000,
                        AuxiliaryOnUs = "101",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::Currency.Usd,
                        RoutingNumber = "101050001",
                        SerialNumber = null,
                    },
                    DepositAdjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Amount = 1750,
                            Reason = CheckDeposits::Reason.AdjustedAmount,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                    ],
                    DepositRejection = new()
                    {
                        Amount = 1750,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositRejectionCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    DepositReturn = new()
                    {
                        Amount = 100,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositReturnCurrency.Usd,
                        ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    DepositSubmission = new()
                    {
                        BackFileID = "file_frhw4s443nh7noss55kq",
                        FrontFileID = "file_j7ed9mrve741m6yui9ju",
                        SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    },
                    Description = null,
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = CheckDeposits::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = CheckDeposits::Status.Held,
                        Type = CheckDeposits::Type.InboundFundsHold,
                    },
                    InboundMailItemID = null,
                    LockboxID = null,
                    Status = CheckDeposits::CheckDepositStatus.Submitted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = CheckDeposits::CheckDepositType.CheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckDeposits::CheckDepositListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 1000,
                    BackImageFileID = "file_26khfk98mzfz90a11oqx",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DepositAcceptance = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 1000,
                        AuxiliaryOnUs = "101",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::Currency.Usd,
                        RoutingNumber = "101050001",
                        SerialNumber = null,
                    },
                    DepositAdjustments =
                    [
                        new()
                        {
                            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Amount = 1750,
                            Reason = CheckDeposits::Reason.AdjustedAmount,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                    ],
                    DepositRejection = new()
                    {
                        Amount = 1750,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositRejectionCurrency.Usd,
                        DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
                        Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
                        RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    },
                    DepositReturn = new()
                    {
                        Amount = 100,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = CheckDeposits::DepositReturnCurrency.Usd,
                        ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    DepositSubmission = new()
                    {
                        BackFileID = "file_frhw4s443nh7noss55kq",
                        FrontFileID = "file_j7ed9mrve741m6yui9ju",
                        SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    },
                    Description = null,
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    InboundFundsHold = new()
                    {
                        Amount = 100,
                        AutomaticallyReleasesAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Currency = CheckDeposits::InboundFundsHoldCurrency.Usd,
                        HeldTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                        ReleasedAt = null,
                        Status = CheckDeposits::Status.Held,
                        Type = CheckDeposits::Type.InboundFundsHold,
                    },
                    InboundMailItemID = null,
                    LockboxID = null,
                    Status = CheckDeposits::CheckDepositStatus.Submitted,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = CheckDeposits::CheckDepositType.CheckDeposit,
                },
            ],
            NextCursor = "v57w5d",
        };

        CheckDeposits::CheckDepositListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
