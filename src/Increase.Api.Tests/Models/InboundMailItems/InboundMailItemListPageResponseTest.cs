using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using InboundMailItems = Increase.Api.Models.InboundMailItems;

namespace Increase.Api.Tests.Models.InboundMailItems;

public class InboundMailItemListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundMailItems::InboundMailItemListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<InboundMailItems::InboundMailItem> expectedData =
        [
            new()
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
        var model = new InboundMailItems::InboundMailItemListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundMailItems::InboundMailItemListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundMailItems::InboundMailItemListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundMailItems::InboundMailItemListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<InboundMailItems::InboundMailItem> expectedData =
        [
            new()
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
        var model = new InboundMailItems::InboundMailItemListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundMailItems::InboundMailItemListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        InboundMailItems::InboundMailItemListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
