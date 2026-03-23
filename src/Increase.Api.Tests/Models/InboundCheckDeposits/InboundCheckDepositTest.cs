using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundCheckDeposits = Increase.Api.Models.InboundCheckDeposits;

namespace Increase.Api.Tests.Models.InboundCheckDeposits;

public class InboundCheckDepositTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundCheckDeposits::InboundCheckDeposit
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
        };

        string expectedID = "inbound_check_deposit_zoshvqybq0cjjm31mra";
        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        List<InboundCheckDeposits::Adjustment> expectedAdjustments =
        [
            new()
            {
                AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Amount = 0,
                Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                TransactionID = "transaction_id",
            },
        ];
        long expectedAmount = 1000;
        string expectedBackImageFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedBankOfFirstDepositRoutingNumber = "101050001";
        string expectedCheckNumber = "123";
        string expectedCheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, InboundCheckDeposits::Currency> expectedCurrency =
            InboundCheckDeposits::Currency.Usd;
        InboundCheckDeposits::DepositReturn expectedDepositReturn = new()
        {
            Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };
        string expectedFrontImageFileID = "file_makxrc67oh9l6sg7w9yc";
        ApiEnum<string, InboundCheckDeposits::PayeeNameAnalysis> expectedPayeeNameAnalysis =
            InboundCheckDeposits::PayeeNameAnalysis.NameMatches;
        ApiEnum<string, InboundCheckDeposits::Status> expectedStatus =
            InboundCheckDeposits::Status.Accepted;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, InboundCheckDeposits::Type> expectedType =
            InboundCheckDeposits::Type.InboundCheckDeposit;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAcceptedAt, model.AcceptedAt);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedAdjustments.Count, model.Adjustments.Count);
        for (int i = 0; i < expectedAdjustments.Count; i++)
        {
            Assert.Equal(expectedAdjustments[i], model.Adjustments[i]);
        }
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBackImageFileID, model.BackImageFileID);
        Assert.Equal(
            expectedBankOfFirstDepositRoutingNumber,
            model.BankOfFirstDepositRoutingNumber
        );
        Assert.Equal(expectedCheckNumber, model.CheckNumber);
        Assert.Equal(expectedCheckTransferID, model.CheckTransferID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Null(model.DeclinedAt);
        Assert.Null(model.DeclinedTransactionID);
        Assert.Equal(expectedDepositReturn, model.DepositReturn);
        Assert.Equal(expectedFrontImageFileID, model.FrontImageFileID);
        Assert.Equal(expectedPayeeNameAnalysis, model.PayeeNameAnalysis);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundCheckDeposits::InboundCheckDeposit
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundCheckDeposits::InboundCheckDeposit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundCheckDeposits::InboundCheckDeposit
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundCheckDeposits::InboundCheckDeposit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "inbound_check_deposit_zoshvqybq0cjjm31mra";
        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        List<InboundCheckDeposits::Adjustment> expectedAdjustments =
        [
            new()
            {
                AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Amount = 0,
                Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
                TransactionID = "transaction_id",
            },
        ];
        long expectedAmount = 1000;
        string expectedBackImageFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedBankOfFirstDepositRoutingNumber = "101050001";
        string expectedCheckNumber = "123";
        string expectedCheckTransferID = "check_transfer_30b43acfu9vw8fyc4f5";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, InboundCheckDeposits::Currency> expectedCurrency =
            InboundCheckDeposits::Currency.Usd;
        InboundCheckDeposits::DepositReturn expectedDepositReturn = new()
        {
            Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };
        string expectedFrontImageFileID = "file_makxrc67oh9l6sg7w9yc";
        ApiEnum<string, InboundCheckDeposits::PayeeNameAnalysis> expectedPayeeNameAnalysis =
            InboundCheckDeposits::PayeeNameAnalysis.NameMatches;
        ApiEnum<string, InboundCheckDeposits::Status> expectedStatus =
            InboundCheckDeposits::Status.Accepted;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, InboundCheckDeposits::Type> expectedType =
            InboundCheckDeposits::Type.InboundCheckDeposit;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAcceptedAt, deserialized.AcceptedAt);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedAdjustments.Count, deserialized.Adjustments.Count);
        for (int i = 0; i < expectedAdjustments.Count; i++)
        {
            Assert.Equal(expectedAdjustments[i], deserialized.Adjustments[i]);
        }
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBackImageFileID, deserialized.BackImageFileID);
        Assert.Equal(
            expectedBankOfFirstDepositRoutingNumber,
            deserialized.BankOfFirstDepositRoutingNumber
        );
        Assert.Equal(expectedCheckNumber, deserialized.CheckNumber);
        Assert.Equal(expectedCheckTransferID, deserialized.CheckTransferID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Null(deserialized.DeclinedAt);
        Assert.Null(deserialized.DeclinedTransactionID);
        Assert.Equal(expectedDepositReturn, deserialized.DepositReturn);
        Assert.Equal(expectedFrontImageFileID, deserialized.FrontImageFileID);
        Assert.Equal(expectedPayeeNameAnalysis, deserialized.PayeeNameAnalysis);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundCheckDeposits::InboundCheckDeposit
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundCheckDeposits::InboundCheckDeposit
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
        };

        InboundCheckDeposits::InboundCheckDeposit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundCheckDeposits::Adjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Amount = 0,
            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
            TransactionID = "transaction_id",
        };

        DateTimeOffset expectedAdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedAmount = 0;
        ApiEnum<string, InboundCheckDeposits::AdjustmentReason> expectedReason =
            InboundCheckDeposits::AdjustmentReason.LateReturn;
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedAdjustedAt, model.AdjustedAt);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundCheckDeposits::Adjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Amount = 0,
            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
            TransactionID = "transaction_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundCheckDeposits::Adjustment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundCheckDeposits::Adjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Amount = 0,
            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
            TransactionID = "transaction_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundCheckDeposits::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedAmount = 0;
        ApiEnum<string, InboundCheckDeposits::AdjustmentReason> expectedReason =
            InboundCheckDeposits::AdjustmentReason.LateReturn;
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedAdjustedAt, deserialized.AdjustedAt);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundCheckDeposits::Adjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Amount = 0,
            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
            TransactionID = "transaction_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundCheckDeposits::Adjustment
        {
            AdjustedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Amount = 0,
            Reason = InboundCheckDeposits::AdjustmentReason.LateReturn,
            TransactionID = "transaction_id",
        };

        InboundCheckDeposits::Adjustment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AdjustmentReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundCheckDeposits::AdjustmentReason.LateReturn)]
    [InlineData(InboundCheckDeposits::AdjustmentReason.WrongPayeeCredit)]
    [InlineData(InboundCheckDeposits::AdjustmentReason.AdjustedAmount)]
    [InlineData(InboundCheckDeposits::AdjustmentReason.NonConformingItem)]
    [InlineData(InboundCheckDeposits::AdjustmentReason.Paid)]
    public void Validation_Works(InboundCheckDeposits::AdjustmentReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::AdjustmentReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::AdjustmentReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundCheckDeposits::AdjustmentReason.LateReturn)]
    [InlineData(InboundCheckDeposits::AdjustmentReason.WrongPayeeCredit)]
    [InlineData(InboundCheckDeposits::AdjustmentReason.AdjustedAmount)]
    [InlineData(InboundCheckDeposits::AdjustmentReason.NonConformingItem)]
    [InlineData(InboundCheckDeposits::AdjustmentReason.Paid)]
    public void SerializationRoundtrip_Works(InboundCheckDeposits::AdjustmentReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::AdjustmentReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::AdjustmentReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::AdjustmentReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::AdjustmentReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(InboundCheckDeposits::Currency.Usd)]
    public void Validation_Works(InboundCheckDeposits::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundCheckDeposits::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundCheckDeposits::Currency.Usd)]
    public void SerializationRoundtrip_Works(InboundCheckDeposits::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundCheckDeposits::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DepositReturnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundCheckDeposits::DepositReturn
        {
            Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        ApiEnum<string, InboundCheckDeposits::DepositReturnReason> expectedReason =
            InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious;
        DateTimeOffset expectedReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReturnedAt, model.ReturnedAt);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundCheckDeposits::DepositReturn
        {
            Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundCheckDeposits::DepositReturn>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundCheckDeposits::DepositReturn
        {
            Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundCheckDeposits::DepositReturn>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InboundCheckDeposits::DepositReturnReason> expectedReason =
            InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious;
        DateTimeOffset expectedReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReturnedAt, deserialized.ReturnedAt);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundCheckDeposits::DepositReturn
        {
            Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundCheckDeposits::DepositReturn
        {
            Reason = InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious,
            ReturnedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        InboundCheckDeposits::DepositReturn copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DepositReturnReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.NotAuthorized)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.DuplicatePresentment)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.EndorsementMissing)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.EndorsementIrregular)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.ReferToMaker)]
    public void Validation_Works(InboundCheckDeposits::DepositReturnReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::DepositReturnReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::DepositReturnReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundCheckDeposits::DepositReturnReason.AlteredOrFictitious)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.NotAuthorized)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.DuplicatePresentment)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.EndorsementMissing)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.EndorsementIrregular)]
    [InlineData(InboundCheckDeposits::DepositReturnReason.ReferToMaker)]
    public void SerializationRoundtrip_Works(InboundCheckDeposits::DepositReturnReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::DepositReturnReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::DepositReturnReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::DepositReturnReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::DepositReturnReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PayeeNameAnalysisTest : TestBase
{
    [Theory]
    [InlineData(InboundCheckDeposits::PayeeNameAnalysis.NameMatches)]
    [InlineData(InboundCheckDeposits::PayeeNameAnalysis.DoesNotMatch)]
    [InlineData(InboundCheckDeposits::PayeeNameAnalysis.NotEvaluated)]
    public void Validation_Works(InboundCheckDeposits::PayeeNameAnalysis rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::PayeeNameAnalysis> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::PayeeNameAnalysis>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundCheckDeposits::PayeeNameAnalysis.NameMatches)]
    [InlineData(InboundCheckDeposits::PayeeNameAnalysis.DoesNotMatch)]
    [InlineData(InboundCheckDeposits::PayeeNameAnalysis.NotEvaluated)]
    public void SerializationRoundtrip_Works(InboundCheckDeposits::PayeeNameAnalysis rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::PayeeNameAnalysis> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::PayeeNameAnalysis>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::PayeeNameAnalysis>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::PayeeNameAnalysis>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(InboundCheckDeposits::Status.Pending)]
    [InlineData(InboundCheckDeposits::Status.Accepted)]
    [InlineData(InboundCheckDeposits::Status.Declined)]
    [InlineData(InboundCheckDeposits::Status.Returned)]
    [InlineData(InboundCheckDeposits::Status.RequiresAttention)]
    public void Validation_Works(InboundCheckDeposits::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundCheckDeposits::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundCheckDeposits::Status.Pending)]
    [InlineData(InboundCheckDeposits::Status.Accepted)]
    [InlineData(InboundCheckDeposits::Status.Declined)]
    [InlineData(InboundCheckDeposits::Status.Returned)]
    [InlineData(InboundCheckDeposits::Status.RequiresAttention)]
    public void SerializationRoundtrip_Works(InboundCheckDeposits::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundCheckDeposits::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundCheckDeposits::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(InboundCheckDeposits::Type.InboundCheckDeposit)]
    public void Validation_Works(InboundCheckDeposits::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundCheckDeposits::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundCheckDeposits::Type.InboundCheckDeposit)]
    public void SerializationRoundtrip_Works(InboundCheckDeposits::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundCheckDeposits::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundCheckDeposits::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundCheckDeposits::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundCheckDeposits::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
