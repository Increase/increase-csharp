using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using CheckDeposits = Increase.Api.Models.CheckDeposits;

namespace Increase.Api.Tests.Models.CheckDeposits;

public class CheckDepositTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckDeposits::CheckDeposit
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
        };

        string expectedID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 1000;
        string expectedBackImageFileID = "file_26khfk98mzfz90a11oqx";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        CheckDeposits::DepositAcceptance expectedDepositAcceptance = new()
        {
            AccountNumber = "987654321",
            Amount = 1000,
            AuxiliaryOnUs = "101",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::Currency.Usd,
            RoutingNumber = "101050001",
            SerialNumber = null,
        };
        List<CheckDeposits::DepositAdjustment> expectedDepositAdjustments =
        [
            new()
            {
                AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Amount = 1750,
                Reason = CheckDeposits::Reason.AdjustedAmount,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            },
        ];
        CheckDeposits::DepositRejection expectedDepositRejection = new()
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        CheckDeposits::DepositReturn expectedDepositReturn = new()
        {
            Amount = 100,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositReturnCurrency.Usd,
            ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };
        CheckDeposits::DepositSubmission expectedDepositSubmission = new()
        {
            BackFileID = "file_frhw4s443nh7noss55kq",
            FrontFileID = "file_j7ed9mrve741m6yui9ju",
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
        };
        string expectedFrontImageFileID = "file_makxrc67oh9l6sg7w9yc";
        CheckDeposits::InboundFundsHold expectedInboundFundsHold = new()
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
        };
        ApiEnum<string, CheckDeposits::CheckDepositStatus> expectedStatus =
            CheckDeposits::CheckDepositStatus.Submitted;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, CheckDeposits::CheckDepositType> expectedType =
            CheckDeposits::CheckDepositType.CheckDeposit;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBackImageFileID, model.BackImageFileID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDepositAcceptance, model.DepositAcceptance);
        Assert.Equal(expectedDepositAdjustments.Count, model.DepositAdjustments.Count);
        for (int i = 0; i < expectedDepositAdjustments.Count; i++)
        {
            Assert.Equal(expectedDepositAdjustments[i], model.DepositAdjustments[i]);
        }
        Assert.Equal(expectedDepositRejection, model.DepositRejection);
        Assert.Equal(expectedDepositReturn, model.DepositReturn);
        Assert.Equal(expectedDepositSubmission, model.DepositSubmission);
        Assert.Null(model.Description);
        Assert.Equal(expectedFrontImageFileID, model.FrontImageFileID);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedInboundFundsHold, model.InboundFundsHold);
        Assert.Null(model.InboundMailItemID);
        Assert.Null(model.LockboxID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckDeposits::CheckDeposit
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::CheckDeposit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckDeposits::CheckDeposit
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::CheckDeposit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 1000;
        string expectedBackImageFileID = "file_26khfk98mzfz90a11oqx";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        CheckDeposits::DepositAcceptance expectedDepositAcceptance = new()
        {
            AccountNumber = "987654321",
            Amount = 1000,
            AuxiliaryOnUs = "101",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::Currency.Usd,
            RoutingNumber = "101050001",
            SerialNumber = null,
        };
        List<CheckDeposits::DepositAdjustment> expectedDepositAdjustments =
        [
            new()
            {
                AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Amount = 1750,
                Reason = CheckDeposits::Reason.AdjustedAmount,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            },
        ];
        CheckDeposits::DepositRejection expectedDepositRejection = new()
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        CheckDeposits::DepositReturn expectedDepositReturn = new()
        {
            Amount = 100,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositReturnCurrency.Usd,
            ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };
        CheckDeposits::DepositSubmission expectedDepositSubmission = new()
        {
            BackFileID = "file_frhw4s443nh7noss55kq",
            FrontFileID = "file_j7ed9mrve741m6yui9ju",
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
        };
        string expectedFrontImageFileID = "file_makxrc67oh9l6sg7w9yc";
        CheckDeposits::InboundFundsHold expectedInboundFundsHold = new()
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
        };
        ApiEnum<string, CheckDeposits::CheckDepositStatus> expectedStatus =
            CheckDeposits::CheckDepositStatus.Submitted;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, CheckDeposits::CheckDepositType> expectedType =
            CheckDeposits::CheckDepositType.CheckDeposit;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBackImageFileID, deserialized.BackImageFileID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDepositAcceptance, deserialized.DepositAcceptance);
        Assert.Equal(expectedDepositAdjustments.Count, deserialized.DepositAdjustments.Count);
        for (int i = 0; i < expectedDepositAdjustments.Count; i++)
        {
            Assert.Equal(expectedDepositAdjustments[i], deserialized.DepositAdjustments[i]);
        }
        Assert.Equal(expectedDepositRejection, deserialized.DepositRejection);
        Assert.Equal(expectedDepositReturn, deserialized.DepositReturn);
        Assert.Equal(expectedDepositSubmission, deserialized.DepositSubmission);
        Assert.Null(deserialized.Description);
        Assert.Equal(expectedFrontImageFileID, deserialized.FrontImageFileID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedInboundFundsHold, deserialized.InboundFundsHold);
        Assert.Null(deserialized.InboundMailItemID);
        Assert.Null(deserialized.LockboxID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckDeposits::CheckDeposit
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckDeposits::CheckDeposit
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
        };

        CheckDeposits::CheckDeposit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DepositAcceptanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositAcceptance
        {
            AccountNumber = "987654321",
            Amount = 1000,
            AuxiliaryOnUs = "101",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::Currency.Usd,
            RoutingNumber = "101050001",
            SerialNumber = null,
        };

        string expectedAccountNumber = "987654321";
        long expectedAmount = 1000;
        string expectedAuxiliaryOnUs = "101";
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, CheckDeposits::Currency> expectedCurrency = CheckDeposits::Currency.Usd;
        string expectedRoutingNumber = "101050001";

        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedAuxiliaryOnUs, model.AuxiliaryOnUs);
        Assert.Equal(expectedCheckDepositID, model.CheckDepositID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Null(model.SerialNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositAcceptance
        {
            AccountNumber = "987654321",
            Amount = 1000,
            AuxiliaryOnUs = "101",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::Currency.Usd,
            RoutingNumber = "101050001",
            SerialNumber = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositAcceptance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckDeposits::DepositAcceptance
        {
            AccountNumber = "987654321",
            Amount = 1000,
            AuxiliaryOnUs = "101",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::Currency.Usd,
            RoutingNumber = "101050001",
            SerialNumber = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositAcceptance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountNumber = "987654321";
        long expectedAmount = 1000;
        string expectedAuxiliaryOnUs = "101";
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, CheckDeposits::Currency> expectedCurrency = CheckDeposits::Currency.Usd;
        string expectedRoutingNumber = "101050001";

        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedAuxiliaryOnUs, deserialized.AuxiliaryOnUs);
        Assert.Equal(expectedCheckDepositID, deserialized.CheckDepositID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Null(deserialized.SerialNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckDeposits::DepositAcceptance
        {
            AccountNumber = "987654321",
            Amount = 1000,
            AuxiliaryOnUs = "101",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::Currency.Usd,
            RoutingNumber = "101050001",
            SerialNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckDeposits::DepositAcceptance
        {
            AccountNumber = "987654321",
            Amount = 1000,
            AuxiliaryOnUs = "101",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::Currency.Usd,
            RoutingNumber = "101050001",
            SerialNumber = null,
        };

        CheckDeposits::DepositAcceptance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::Currency.Usd)]
    public void Validation_Works(CheckDeposits::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::Currency.Usd)]
    public void SerializationRoundtrip_Works(CheckDeposits::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DepositAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositAdjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Amount = 1750,
            Reason = CheckDeposits::Reason.AdjustedAmount,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        DateTimeOffset expectedAdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        long expectedAmount = 1750;
        ApiEnum<string, CheckDeposits::Reason> expectedReason =
            CheckDeposits::Reason.AdjustedAmount;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";

        Assert.Equal(expectedAdjustedAt, model.AdjustedAt);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositAdjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Amount = 1750,
            Reason = CheckDeposits::Reason.AdjustedAmount,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositAdjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckDeposits::DepositAdjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Amount = 1750,
            Reason = CheckDeposits::Reason.AdjustedAmount,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositAdjustment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        long expectedAmount = 1750;
        ApiEnum<string, CheckDeposits::Reason> expectedReason =
            CheckDeposits::Reason.AdjustedAmount;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";

        Assert.Equal(expectedAdjustedAt, deserialized.AdjustedAt);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckDeposits::DepositAdjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Amount = 1750,
            Reason = CheckDeposits::Reason.AdjustedAmount,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckDeposits::DepositAdjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Amount = 1750,
            Reason = CheckDeposits::Reason.AdjustedAmount,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        CheckDeposits::DepositAdjustment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::Reason.AdjustedAmount)]
    [InlineData(CheckDeposits::Reason.NonConformingItem)]
    [InlineData(CheckDeposits::Reason.Paid)]
    public void Validation_Works(CheckDeposits::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::Reason.AdjustedAmount)]
    [InlineData(CheckDeposits::Reason.NonConformingItem)]
    [InlineData(CheckDeposits::Reason.Paid)]
    public void SerializationRoundtrip_Works(CheckDeposits::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DepositRejectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        long expectedAmount = 1750;
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, CheckDeposits::DepositRejectionCurrency> expectedCurrency =
            CheckDeposits::DepositRejectionCurrency.Usd;
        string expectedDeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8";
        ApiEnum<string, CheckDeposits::DepositRejectionReason> expectedReason =
            CheckDeposits::DepositRejectionReason.IncompleteImage;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCheckDepositID, model.CheckDepositID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDeclinedTransactionID, model.DeclinedTransactionID);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRejectedAt, model.RejectedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositRejection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckDeposits::DepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositRejection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 1750;
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, CheckDeposits::DepositRejectionCurrency> expectedCurrency =
            CheckDeposits::DepositRejectionCurrency.Usd;
        string expectedDeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8";
        ApiEnum<string, CheckDeposits::DepositRejectionReason> expectedReason =
            CheckDeposits::DepositRejectionReason.IncompleteImage;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCheckDepositID, deserialized.CheckDepositID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDeclinedTransactionID, deserialized.DeclinedTransactionID);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRejectedAt, deserialized.RejectedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckDeposits::DepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckDeposits::DepositRejection
        {
            Amount = 1750,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositRejectionCurrency.Usd,
            DeclinedTransactionID = "declined_transaction_17jbn0yyhvkt4v4ooym8",
            Reason = CheckDeposits::DepositRejectionReason.IncompleteImage,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        CheckDeposits::DepositRejection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DepositRejectionCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::DepositRejectionCurrency.Usd)]
    public void Validation_Works(CheckDeposits::DepositRejectionCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::DepositRejectionCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositRejectionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::DepositRejectionCurrency.Usd)]
    public void SerializationRoundtrip_Works(CheckDeposits::DepositRejectionCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::DepositRejectionCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositRejectionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositRejectionCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositRejectionCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DepositRejectionReasonTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::DepositRejectionReason.IncompleteImage)]
    [InlineData(CheckDeposits::DepositRejectionReason.Duplicate)]
    [InlineData(CheckDeposits::DepositRejectionReason.PoorImageQuality)]
    [InlineData(CheckDeposits::DepositRejectionReason.IncorrectAmount)]
    [InlineData(CheckDeposits::DepositRejectionReason.IncorrectRecipient)]
    [InlineData(CheckDeposits::DepositRejectionReason.NotEligibleForMobileDeposit)]
    [InlineData(CheckDeposits::DepositRejectionReason.MissingRequiredDataElements)]
    [InlineData(CheckDeposits::DepositRejectionReason.SuspectedFraud)]
    [InlineData(CheckDeposits::DepositRejectionReason.DepositWindowExpired)]
    [InlineData(CheckDeposits::DepositRejectionReason.RequestedByUser)]
    [InlineData(CheckDeposits::DepositRejectionReason.International)]
    [InlineData(CheckDeposits::DepositRejectionReason.Unknown)]
    public void Validation_Works(CheckDeposits::DepositRejectionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::DepositRejectionReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositRejectionReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::DepositRejectionReason.IncompleteImage)]
    [InlineData(CheckDeposits::DepositRejectionReason.Duplicate)]
    [InlineData(CheckDeposits::DepositRejectionReason.PoorImageQuality)]
    [InlineData(CheckDeposits::DepositRejectionReason.IncorrectAmount)]
    [InlineData(CheckDeposits::DepositRejectionReason.IncorrectRecipient)]
    [InlineData(CheckDeposits::DepositRejectionReason.NotEligibleForMobileDeposit)]
    [InlineData(CheckDeposits::DepositRejectionReason.MissingRequiredDataElements)]
    [InlineData(CheckDeposits::DepositRejectionReason.SuspectedFraud)]
    [InlineData(CheckDeposits::DepositRejectionReason.DepositWindowExpired)]
    [InlineData(CheckDeposits::DepositRejectionReason.RequestedByUser)]
    [InlineData(CheckDeposits::DepositRejectionReason.International)]
    [InlineData(CheckDeposits::DepositRejectionReason.Unknown)]
    public void SerializationRoundtrip_Works(CheckDeposits::DepositRejectionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::DepositRejectionReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositRejectionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositRejectionReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositRejectionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DepositReturnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositReturn
        {
            Amount = 100,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositReturnCurrency.Usd,
            ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        long expectedAmount = 100;
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, CheckDeposits::DepositReturnCurrency> expectedCurrency =
            CheckDeposits::DepositReturnCurrency.Usd;
        ApiEnum<string, CheckDeposits::ReturnReason> expectedReturnReason =
            CheckDeposits::ReturnReason.InsufficientFunds;
        DateTimeOffset expectedReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCheckDepositID, model.CheckDepositID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedReturnReason, model.ReturnReason);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositReturn
        {
            Amount = 100,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositReturnCurrency.Usd,
            ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositReturn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckDeposits::DepositReturn
        {
            Amount = 100,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositReturnCurrency.Usd,
            ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositReturn>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        ApiEnum<string, CheckDeposits::DepositReturnCurrency> expectedCurrency =
            CheckDeposits::DepositReturnCurrency.Usd;
        ApiEnum<string, CheckDeposits::ReturnReason> expectedReturnReason =
            CheckDeposits::ReturnReason.InsufficientFunds;
        DateTimeOffset expectedReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCheckDepositID, deserialized.CheckDepositID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedReturnReason, deserialized.ReturnReason);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckDeposits::DepositReturn
        {
            Amount = 100,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositReturnCurrency.Usd,
            ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckDeposits::DepositReturn
        {
            Amount = 100,
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Currency = CheckDeposits::DepositReturnCurrency.Usd,
            ReturnReason = CheckDeposits::ReturnReason.InsufficientFunds,
            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        CheckDeposits::DepositReturn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DepositReturnCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::DepositReturnCurrency.Usd)]
    public void Validation_Works(CheckDeposits::DepositReturnCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::DepositReturnCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositReturnCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::DepositReturnCurrency.Usd)]
    public void SerializationRoundtrip_Works(CheckDeposits::DepositReturnCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::DepositReturnCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositReturnCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositReturnCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::DepositReturnCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ReturnReasonTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::ReturnReason.AchConversionNotSupported)]
    [InlineData(CheckDeposits::ReturnReason.ClosedAccount)]
    [InlineData(CheckDeposits::ReturnReason.DuplicateSubmission)]
    [InlineData(CheckDeposits::ReturnReason.InsufficientFunds)]
    [InlineData(CheckDeposits::ReturnReason.NoAccount)]
    [InlineData(CheckDeposits::ReturnReason.NotAuthorized)]
    [InlineData(CheckDeposits::ReturnReason.StaleDated)]
    [InlineData(CheckDeposits::ReturnReason.StopPayment)]
    [InlineData(CheckDeposits::ReturnReason.UnknownReason)]
    [InlineData(CheckDeposits::ReturnReason.UnmatchedDetails)]
    [InlineData(CheckDeposits::ReturnReason.UnreadableImage)]
    [InlineData(CheckDeposits::ReturnReason.EndorsementIrregular)]
    [InlineData(CheckDeposits::ReturnReason.AlteredOrFictitiousItem)]
    [InlineData(CheckDeposits::ReturnReason.FrozenOrBlockedAccount)]
    [InlineData(CheckDeposits::ReturnReason.PostDated)]
    [InlineData(CheckDeposits::ReturnReason.EndorsementMissing)]
    [InlineData(CheckDeposits::ReturnReason.SignatureMissing)]
    [InlineData(CheckDeposits::ReturnReason.StopPaymentSuspect)]
    [InlineData(CheckDeposits::ReturnReason.UnusableImage)]
    [InlineData(CheckDeposits::ReturnReason.ImageFailsSecurityCheck)]
    [InlineData(CheckDeposits::ReturnReason.CannotDetermineAmount)]
    [InlineData(CheckDeposits::ReturnReason.SignatureIrregular)]
    [InlineData(CheckDeposits::ReturnReason.NonCashItem)]
    [InlineData(CheckDeposits::ReturnReason.UnableToProcess)]
    [InlineData(CheckDeposits::ReturnReason.ItemExceedsDollarLimit)]
    [InlineData(CheckDeposits::ReturnReason.BranchOrAccountSold)]
    public void Validation_Works(CheckDeposits::ReturnReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::ReturnReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::ReturnReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::ReturnReason.AchConversionNotSupported)]
    [InlineData(CheckDeposits::ReturnReason.ClosedAccount)]
    [InlineData(CheckDeposits::ReturnReason.DuplicateSubmission)]
    [InlineData(CheckDeposits::ReturnReason.InsufficientFunds)]
    [InlineData(CheckDeposits::ReturnReason.NoAccount)]
    [InlineData(CheckDeposits::ReturnReason.NotAuthorized)]
    [InlineData(CheckDeposits::ReturnReason.StaleDated)]
    [InlineData(CheckDeposits::ReturnReason.StopPayment)]
    [InlineData(CheckDeposits::ReturnReason.UnknownReason)]
    [InlineData(CheckDeposits::ReturnReason.UnmatchedDetails)]
    [InlineData(CheckDeposits::ReturnReason.UnreadableImage)]
    [InlineData(CheckDeposits::ReturnReason.EndorsementIrregular)]
    [InlineData(CheckDeposits::ReturnReason.AlteredOrFictitiousItem)]
    [InlineData(CheckDeposits::ReturnReason.FrozenOrBlockedAccount)]
    [InlineData(CheckDeposits::ReturnReason.PostDated)]
    [InlineData(CheckDeposits::ReturnReason.EndorsementMissing)]
    [InlineData(CheckDeposits::ReturnReason.SignatureMissing)]
    [InlineData(CheckDeposits::ReturnReason.StopPaymentSuspect)]
    [InlineData(CheckDeposits::ReturnReason.UnusableImage)]
    [InlineData(CheckDeposits::ReturnReason.ImageFailsSecurityCheck)]
    [InlineData(CheckDeposits::ReturnReason.CannotDetermineAmount)]
    [InlineData(CheckDeposits::ReturnReason.SignatureIrregular)]
    [InlineData(CheckDeposits::ReturnReason.NonCashItem)]
    [InlineData(CheckDeposits::ReturnReason.UnableToProcess)]
    [InlineData(CheckDeposits::ReturnReason.ItemExceedsDollarLimit)]
    [InlineData(CheckDeposits::ReturnReason.BranchOrAccountSold)]
    public void SerializationRoundtrip_Works(CheckDeposits::ReturnReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::ReturnReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::ReturnReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::ReturnReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::ReturnReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DepositSubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositSubmission
        {
            BackFileID = "file_frhw4s443nh7noss55kq",
            FrontFileID = "file_j7ed9mrve741m6yui9ju",
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
        };

        string expectedBackFileID = "file_frhw4s443nh7noss55kq";
        string expectedFrontFileID = "file_j7ed9mrve741m6yui9ju";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00");

        Assert.Equal(expectedBackFileID, model.BackFileID);
        Assert.Equal(expectedFrontFileID, model.FrontFileID);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckDeposits::DepositSubmission
        {
            BackFileID = "file_frhw4s443nh7noss55kq",
            FrontFileID = "file_j7ed9mrve741m6yui9ju",
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositSubmission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckDeposits::DepositSubmission
        {
            BackFileID = "file_frhw4s443nh7noss55kq",
            FrontFileID = "file_j7ed9mrve741m6yui9ju",
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::DepositSubmission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBackFileID = "file_frhw4s443nh7noss55kq";
        string expectedFrontFileID = "file_j7ed9mrve741m6yui9ju";
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00");

        Assert.Equal(expectedBackFileID, deserialized.BackFileID);
        Assert.Equal(expectedFrontFileID, deserialized.FrontFileID);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckDeposits::DepositSubmission
        {
            BackFileID = "file_frhw4s443nh7noss55kq",
            FrontFileID = "file_j7ed9mrve741m6yui9ju",
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckDeposits::DepositSubmission
        {
            BackFileID = "file_frhw4s443nh7noss55kq",
            FrontFileID = "file_j7ed9mrve741m6yui9ju",
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
        };

        CheckDeposits::DepositSubmission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundFundsHoldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckDeposits::InboundFundsHold
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
        };

        long expectedAmount = 100;
        DateTimeOffset expectedAutomaticallyReleasesAt = DateTimeOffset.Parse(
            "2020-01-31T23:59:59Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, CheckDeposits::InboundFundsHoldCurrency> expectedCurrency =
            CheckDeposits::InboundFundsHoldCurrency.Usd;
        string expectedHeldTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        ApiEnum<string, CheckDeposits::Status> expectedStatus = CheckDeposits::Status.Held;
        ApiEnum<string, CheckDeposits::Type> expectedType = CheckDeposits::Type.InboundFundsHold;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedAutomaticallyReleasesAt, model.AutomaticallyReleasesAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedHeldTransactionID, model.HeldTransactionID);
        Assert.Equal(expectedPendingTransactionID, model.PendingTransactionID);
        Assert.Null(model.ReleasedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckDeposits::InboundFundsHold
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::InboundFundsHold>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckDeposits::InboundFundsHold
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckDeposits::InboundFundsHold>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 100;
        DateTimeOffset expectedAutomaticallyReleasesAt = DateTimeOffset.Parse(
            "2020-01-31T23:59:59Z"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, CheckDeposits::InboundFundsHoldCurrency> expectedCurrency =
            CheckDeposits::InboundFundsHoldCurrency.Usd;
        string expectedHeldTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        ApiEnum<string, CheckDeposits::Status> expectedStatus = CheckDeposits::Status.Held;
        ApiEnum<string, CheckDeposits::Type> expectedType = CheckDeposits::Type.InboundFundsHold;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedAutomaticallyReleasesAt, deserialized.AutomaticallyReleasesAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedHeldTransactionID, deserialized.HeldTransactionID);
        Assert.Equal(expectedPendingTransactionID, deserialized.PendingTransactionID);
        Assert.Null(deserialized.ReleasedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckDeposits::InboundFundsHold
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckDeposits::InboundFundsHold
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
        };

        CheckDeposits::InboundFundsHold copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundFundsHoldCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::InboundFundsHoldCurrency.Usd)]
    public void Validation_Works(CheckDeposits::InboundFundsHoldCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::InboundFundsHoldCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::InboundFundsHoldCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::InboundFundsHoldCurrency.Usd)]
    public void SerializationRoundtrip_Works(CheckDeposits::InboundFundsHoldCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::InboundFundsHoldCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::InboundFundsHoldCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::InboundFundsHoldCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::InboundFundsHoldCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::Status.Held)]
    [InlineData(CheckDeposits::Status.Complete)]
    public void Validation_Works(CheckDeposits::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::Status.Held)]
    [InlineData(CheckDeposits::Status.Complete)]
    public void SerializationRoundtrip_Works(CheckDeposits::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::Type.InboundFundsHold)]
    public void Validation_Works(CheckDeposits::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::Type.InboundFundsHold)]
    public void SerializationRoundtrip_Works(CheckDeposits::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CheckDepositStatusTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::CheckDepositStatus.Pending)]
    [InlineData(CheckDeposits::CheckDepositStatus.Submitted)]
    [InlineData(CheckDeposits::CheckDepositStatus.Rejected)]
    [InlineData(CheckDeposits::CheckDepositStatus.Returned)]
    public void Validation_Works(CheckDeposits::CheckDepositStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::CheckDepositStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::CheckDepositStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::CheckDepositStatus.Pending)]
    [InlineData(CheckDeposits::CheckDepositStatus.Submitted)]
    [InlineData(CheckDeposits::CheckDepositStatus.Rejected)]
    [InlineData(CheckDeposits::CheckDepositStatus.Returned)]
    public void SerializationRoundtrip_Works(CheckDeposits::CheckDepositStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::CheckDepositStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::CheckDepositStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::CheckDepositStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::CheckDepositStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckDepositTypeTest : TestBase
{
    [Theory]
    [InlineData(CheckDeposits::CheckDepositType.CheckDeposit)]
    public void Validation_Works(CheckDeposits::CheckDepositType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::CheckDepositType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::CheckDepositType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckDeposits::CheckDepositType.CheckDeposit)]
    public void SerializationRoundtrip_Works(CheckDeposits::CheckDepositType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckDeposits::CheckDepositType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::CheckDepositType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckDeposits::CheckDepositType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckDeposits::CheckDepositType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
