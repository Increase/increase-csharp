using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundMailItems = Increase.Api.Models.InboundMailItems;

namespace Increase.Api.Tests.Models.InboundMailItems;

public class InboundMailItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundMailItems::InboundMailItem
        {
            ID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
            Checks =
            [
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
            RecipientName = "Ian Crease",
            RejectionReason = null,
            Status = InboundMailItems::InboundMailItemStatus.Processed,
            Type = InboundMailItems::Type.InboundMailItem,
        };

        string expectedID = "inbound_mail_item_q6rrg7mmqpplx80zceev";
        List<InboundMailItems::InboundMailItemCheck> expectedChecks =
        [
            new()
            {
                Amount = 1750,
                BackFileID = "file_makxrc67oh9l6sg7w9yc",
                CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                Status = InboundMailItems::Status.Deposited,
            },
            new()
            {
                Amount = 1750,
                BackFileID = "file_makxrc67oh9l6sg7w9yc",
                CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                Status = InboundMailItems::Status.Deposited,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedLockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6";
        string expectedLockboxRecipientID = "lockbox_3xt21ok13q19advds4t5";
        string expectedRecipientName = "Ian Crease";
        ApiEnum<string, InboundMailItems::InboundMailItemStatus> expectedStatus =
            InboundMailItems::InboundMailItemStatus.Processed;
        ApiEnum<string, InboundMailItems::Type> expectedType =
            InboundMailItems::Type.InboundMailItem;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChecks.Count, model.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], model.Checks[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedLockboxAddressID, model.LockboxAddressID);
        Assert.Equal(expectedLockboxRecipientID, model.LockboxRecipientID);
        Assert.Equal(expectedRecipientName, model.RecipientName);
        Assert.Null(model.RejectionReason);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundMailItems::InboundMailItem
        {
            ID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
            Checks =
            [
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
            RecipientName = "Ian Crease",
            RejectionReason = null,
            Status = InboundMailItems::InboundMailItemStatus.Processed,
            Type = InboundMailItems::Type.InboundMailItem,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMailItems::InboundMailItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundMailItems::InboundMailItem
        {
            ID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
            Checks =
            [
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
            RecipientName = "Ian Crease",
            RejectionReason = null,
            Status = InboundMailItems::InboundMailItemStatus.Processed,
            Type = InboundMailItems::Type.InboundMailItem,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMailItems::InboundMailItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "inbound_mail_item_q6rrg7mmqpplx80zceev";
        List<InboundMailItems::InboundMailItemCheck> expectedChecks =
        [
            new()
            {
                Amount = 1750,
                BackFileID = "file_makxrc67oh9l6sg7w9yc",
                CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                Status = InboundMailItems::Status.Deposited,
            },
            new()
            {
                Amount = 1750,
                BackFileID = "file_makxrc67oh9l6sg7w9yc",
                CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                Status = InboundMailItems::Status.Deposited,
            },
        ];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedLockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6";
        string expectedLockboxRecipientID = "lockbox_3xt21ok13q19advds4t5";
        string expectedRecipientName = "Ian Crease";
        ApiEnum<string, InboundMailItems::InboundMailItemStatus> expectedStatus =
            InboundMailItems::InboundMailItemStatus.Processed;
        ApiEnum<string, InboundMailItems::Type> expectedType =
            InboundMailItems::Type.InboundMailItem;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChecks.Count, deserialized.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], deserialized.Checks[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedLockboxAddressID, deserialized.LockboxAddressID);
        Assert.Equal(expectedLockboxRecipientID, deserialized.LockboxRecipientID);
        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
        Assert.Null(deserialized.RejectionReason);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundMailItems::InboundMailItem
        {
            ID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
            Checks =
            [
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
            RecipientName = "Ian Crease",
            RejectionReason = null,
            Status = InboundMailItems::InboundMailItemStatus.Processed,
            Type = InboundMailItems::Type.InboundMailItem,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundMailItems::InboundMailItem
        {
            ID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
            Checks =
            [
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
                new()
                {
                    Amount = 1750,
                    BackFileID = "file_makxrc67oh9l6sg7w9yc",
                    CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                    FrontFileID = "file_makxrc67oh9l6sg7w9yc",
                    Status = InboundMailItems::Status.Deposited,
                },
            ],
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            LockboxAddressID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
            LockboxRecipientID = "lockbox_3xt21ok13q19advds4t5",
            RecipientName = "Ian Crease",
            RejectionReason = null,
            Status = InboundMailItems::InboundMailItemStatus.Processed,
            Type = InboundMailItems::Type.InboundMailItem,
        };

        InboundMailItems::InboundMailItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InboundMailItemCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundMailItems::InboundMailItemCheck
        {
            Amount = 1750,
            BackFileID = "file_makxrc67oh9l6sg7w9yc",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            FrontFileID = "file_makxrc67oh9l6sg7w9yc",
            Status = InboundMailItems::Status.Deposited,
        };

        long expectedAmount = 1750;
        string expectedBackFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        string expectedFrontFileID = "file_makxrc67oh9l6sg7w9yc";
        ApiEnum<string, InboundMailItems::Status> expectedStatus =
            InboundMailItems::Status.Deposited;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBackFileID, model.BackFileID);
        Assert.Equal(expectedCheckDepositID, model.CheckDepositID);
        Assert.Equal(expectedFrontFileID, model.FrontFileID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundMailItems::InboundMailItemCheck
        {
            Amount = 1750,
            BackFileID = "file_makxrc67oh9l6sg7w9yc",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            FrontFileID = "file_makxrc67oh9l6sg7w9yc",
            Status = InboundMailItems::Status.Deposited,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMailItems::InboundMailItemCheck>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundMailItems::InboundMailItemCheck
        {
            Amount = 1750,
            BackFileID = "file_makxrc67oh9l6sg7w9yc",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            FrontFileID = "file_makxrc67oh9l6sg7w9yc",
            Status = InboundMailItems::Status.Deposited,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMailItems::InboundMailItemCheck>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 1750;
        string expectedBackFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        string expectedFrontFileID = "file_makxrc67oh9l6sg7w9yc";
        ApiEnum<string, InboundMailItems::Status> expectedStatus =
            InboundMailItems::Status.Deposited;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBackFileID, deserialized.BackFileID);
        Assert.Equal(expectedCheckDepositID, deserialized.CheckDepositID);
        Assert.Equal(expectedFrontFileID, deserialized.FrontFileID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundMailItems::InboundMailItemCheck
        {
            Amount = 1750,
            BackFileID = "file_makxrc67oh9l6sg7w9yc",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            FrontFileID = "file_makxrc67oh9l6sg7w9yc",
            Status = InboundMailItems::Status.Deposited,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundMailItems::InboundMailItemCheck
        {
            Amount = 1750,
            BackFileID = "file_makxrc67oh9l6sg7w9yc",
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            FrontFileID = "file_makxrc67oh9l6sg7w9yc",
            Status = InboundMailItems::Status.Deposited,
        };

        InboundMailItems::InboundMailItemCheck copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(InboundMailItems::Status.Pending)]
    [InlineData(InboundMailItems::Status.Deposited)]
    [InlineData(InboundMailItems::Status.Ignored)]
    public void Validation_Works(InboundMailItems::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundMailItems::Status.Pending)]
    [InlineData(InboundMailItems::Status.Deposited)]
    [InlineData(InboundMailItems::Status.Ignored)]
    public void SerializationRoundtrip_Works(InboundMailItems::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RejectionReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundMailItems::RejectionReason.NoMatchingLockbox)]
    [InlineData(InboundMailItems::RejectionReason.NoCheck)]
    [InlineData(InboundMailItems::RejectionReason.LockboxNotActive)]
    [InlineData(InboundMailItems::RejectionReason.LockboxAddressNotActive)]
    [InlineData(InboundMailItems::RejectionReason.LockboxRecipientNotActive)]
    public void Validation_Works(InboundMailItems::RejectionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::RejectionReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::RejectionReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundMailItems::RejectionReason.NoMatchingLockbox)]
    [InlineData(InboundMailItems::RejectionReason.NoCheck)]
    [InlineData(InboundMailItems::RejectionReason.LockboxNotActive)]
    [InlineData(InboundMailItems::RejectionReason.LockboxAddressNotActive)]
    [InlineData(InboundMailItems::RejectionReason.LockboxRecipientNotActive)]
    public void SerializationRoundtrip_Works(InboundMailItems::RejectionReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::RejectionReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundMailItems::RejectionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::RejectionReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundMailItems::RejectionReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundMailItemStatusTest : TestBase
{
    [Theory]
    [InlineData(InboundMailItems::InboundMailItemStatus.Pending)]
    [InlineData(InboundMailItems::InboundMailItemStatus.Processed)]
    [InlineData(InboundMailItems::InboundMailItemStatus.Rejected)]
    public void Validation_Works(InboundMailItems::InboundMailItemStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::InboundMailItemStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundMailItems::InboundMailItemStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundMailItems::InboundMailItemStatus.Pending)]
    [InlineData(InboundMailItems::InboundMailItemStatus.Processed)]
    [InlineData(InboundMailItems::InboundMailItemStatus.Rejected)]
    public void SerializationRoundtrip_Works(InboundMailItems::InboundMailItemStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::InboundMailItemStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundMailItems::InboundMailItemStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundMailItems::InboundMailItemStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundMailItems::InboundMailItemStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(InboundMailItems::Type.InboundMailItem)]
    public void Validation_Works(InboundMailItems::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundMailItems::Type.InboundMailItem)]
    public void SerializationRoundtrip_Works(InboundMailItems::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
