using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using CheckTransfers = Increase.Api.Models.CheckTransfers;

namespace Increase.Api.Tests.Models.CheckTransfers;

public class CheckTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_transfer_30b43acfu9vw8fyc4f5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 1000,
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    ApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    BalanceCheck = null,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CheckNumber = "123",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CheckTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = CheckTransfers::Currency.Usd,
                    FulfillmentMethod =
                        CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck,
                    IdempotencyKey = null,
                    Mailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    PhysicalCheck = new()
                    {
                        AttachmentFileID = null,
                        CheckVoucherImageFileID = null,
                        MailingAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Memo = "Invoice 29582",
                        Note = null,
                        Payer =
                        [
                            new("Ian Crease"),
                            new("33 Liberty Street"),
                            new("New York, NY 10045"),
                        ],
                        RecipientName = "Ian Crease",
                        ReturnAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        ShippingMethod = null,
                        Signature = new() { ImageFileID = null, Text = "Ian Crease" },
                        TrackingUpdates =
                        [
                            new()
                            {
                                Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PostalCode = "postal_code",
                            },
                        ],
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CheckTransfers::CheckTransferStatus.Mailed,
                    StopPaymentRequest = new()
                    {
                        Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
                        RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
                    },
                    Submission = new()
                    {
                        PreviewFileID = null,
                        SubmittedAddress = new()
                        {
                            City = "NEW YORK",
                            Line1 = "33 LIBERTY STREET",
                            Line2 = null,
                            RecipientName = "IAN CREASE",
                            State = "NY",
                            Zip = "10045",
                        },
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TrackingNumber = null,
                    },
                    ThirdParty = new("recipient_name"),
                    Type = CheckTransfers::CheckTransferType.CheckTransfer,
                    ValidUntilDate = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<CheckTransfers::CheckTransfer> expectedData =
        [
            new()
            {
                ID = "check_transfer_30b43acfu9vw8fyc4f5",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumber = "987654321",
                Amount = 1000,
                Approval = new()
                {
                    ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ApprovedBy = null,
                },
                ApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                BalanceCheck = null,
                Cancellation = new()
                {
                    CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CanceledBy = null,
                },
                CheckNumber = "123",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = CheckTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                Currency = CheckTransfers::Currency.Usd,
                FulfillmentMethod = CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck,
                IdempotencyKey = null,
                Mailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                PhysicalCheck = new()
                {
                    AttachmentFileID = null,
                    CheckVoucherImageFileID = null,
                    MailingAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        Phone = "+16505046304",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Memo = "Invoice 29582",
                    Note = null,
                    Payer =
                    [
                        new("Ian Crease"),
                        new("33 Liberty Street"),
                        new("New York, NY 10045"),
                    ],
                    RecipientName = "Ian Crease",
                    ReturnAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        Phone = "+16505046304",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    ShippingMethod = null,
                    Signature = new() { ImageFileID = null, Text = "Ian Crease" },
                    TrackingUpdates =
                    [
                        new()
                        {
                            Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PostalCode = "postal_code",
                        },
                    ],
                },
                RoutingNumber = "101050001",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Status = CheckTransfers::CheckTransferStatus.Mailed,
                StopPaymentRequest = new()
                {
                    Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
                    RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
                },
                Submission = new()
                {
                    PreviewFileID = null,
                    SubmittedAddress = new()
                    {
                        City = "NEW YORK",
                        Line1 = "33 LIBERTY STREET",
                        Line2 = null,
                        RecipientName = "IAN CREASE",
                        State = "NY",
                        Zip = "10045",
                    },
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TrackingNumber = null,
                },
                ThirdParty = new("recipient_name"),
                Type = CheckTransfers::CheckTransferType.CheckTransfer,
                ValidUntilDate = null,
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
        var model = new CheckTransfers::CheckTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_transfer_30b43acfu9vw8fyc4f5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 1000,
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    ApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    BalanceCheck = null,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CheckNumber = "123",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CheckTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = CheckTransfers::Currency.Usd,
                    FulfillmentMethod =
                        CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck,
                    IdempotencyKey = null,
                    Mailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    PhysicalCheck = new()
                    {
                        AttachmentFileID = null,
                        CheckVoucherImageFileID = null,
                        MailingAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Memo = "Invoice 29582",
                        Note = null,
                        Payer =
                        [
                            new("Ian Crease"),
                            new("33 Liberty Street"),
                            new("New York, NY 10045"),
                        ],
                        RecipientName = "Ian Crease",
                        ReturnAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        ShippingMethod = null,
                        Signature = new() { ImageFileID = null, Text = "Ian Crease" },
                        TrackingUpdates =
                        [
                            new()
                            {
                                Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PostalCode = "postal_code",
                            },
                        ],
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CheckTransfers::CheckTransferStatus.Mailed,
                    StopPaymentRequest = new()
                    {
                        Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
                        RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
                    },
                    Submission = new()
                    {
                        PreviewFileID = null,
                        SubmittedAddress = new()
                        {
                            City = "NEW YORK",
                            Line1 = "33 LIBERTY STREET",
                            Line2 = null,
                            RecipientName = "IAN CREASE",
                            State = "NY",
                            Zip = "10045",
                        },
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TrackingNumber = null,
                    },
                    ThirdParty = new("recipient_name"),
                    Type = CheckTransfers::CheckTransferType.CheckTransfer,
                    ValidUntilDate = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CheckTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_transfer_30b43acfu9vw8fyc4f5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 1000,
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    ApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    BalanceCheck = null,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CheckNumber = "123",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CheckTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = CheckTransfers::Currency.Usd,
                    FulfillmentMethod =
                        CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck,
                    IdempotencyKey = null,
                    Mailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    PhysicalCheck = new()
                    {
                        AttachmentFileID = null,
                        CheckVoucherImageFileID = null,
                        MailingAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Memo = "Invoice 29582",
                        Note = null,
                        Payer =
                        [
                            new("Ian Crease"),
                            new("33 Liberty Street"),
                            new("New York, NY 10045"),
                        ],
                        RecipientName = "Ian Crease",
                        ReturnAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        ShippingMethod = null,
                        Signature = new() { ImageFileID = null, Text = "Ian Crease" },
                        TrackingUpdates =
                        [
                            new()
                            {
                                Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PostalCode = "postal_code",
                            },
                        ],
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CheckTransfers::CheckTransferStatus.Mailed,
                    StopPaymentRequest = new()
                    {
                        Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
                        RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
                    },
                    Submission = new()
                    {
                        PreviewFileID = null,
                        SubmittedAddress = new()
                        {
                            City = "NEW YORK",
                            Line1 = "33 LIBERTY STREET",
                            Line2 = null,
                            RecipientName = "IAN CREASE",
                            State = "NY",
                            Zip = "10045",
                        },
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TrackingNumber = null,
                    },
                    ThirdParty = new("recipient_name"),
                    Type = CheckTransfers::CheckTransferType.CheckTransfer,
                    ValidUntilDate = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<CheckTransfers::CheckTransfer> expectedData =
        [
            new()
            {
                ID = "check_transfer_30b43acfu9vw8fyc4f5",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumber = "987654321",
                Amount = 1000,
                Approval = new()
                {
                    ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    ApprovedBy = null,
                },
                ApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                BalanceCheck = null,
                Cancellation = new()
                {
                    CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CanceledBy = null,
                },
                CheckNumber = "123",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreatedBy = new()
                {
                    Category = CheckTransfers::Category.User,
                    ApiKey = new("description"),
                    OAuthApplication = new("name"),
                    User = new("user@example.com"),
                },
                Currency = CheckTransfers::Currency.Usd,
                FulfillmentMethod = CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck,
                IdempotencyKey = null,
                Mailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                PhysicalCheck = new()
                {
                    AttachmentFileID = null,
                    CheckVoucherImageFileID = null,
                    MailingAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        Phone = "+16505046304",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Memo = "Invoice 29582",
                    Note = null,
                    Payer =
                    [
                        new("Ian Crease"),
                        new("33 Liberty Street"),
                        new("New York, NY 10045"),
                    ],
                    RecipientName = "Ian Crease",
                    ReturnAddress = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        Name = "Ian Crease",
                        Phone = "+16505046304",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    ShippingMethod = null,
                    Signature = new() { ImageFileID = null, Text = "Ian Crease" },
                    TrackingUpdates =
                    [
                        new()
                        {
                            Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            PostalCode = "postal_code",
                        },
                    ],
                },
                RoutingNumber = "101050001",
                SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Status = CheckTransfers::CheckTransferStatus.Mailed,
                StopPaymentRequest = new()
                {
                    Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
                    RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
                },
                Submission = new()
                {
                    PreviewFileID = null,
                    SubmittedAddress = new()
                    {
                        City = "NEW YORK",
                        Line1 = "33 LIBERTY STREET",
                        Line2 = null,
                        RecipientName = "IAN CREASE",
                        State = "NY",
                        Zip = "10045",
                    },
                    SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TrackingNumber = null,
                },
                ThirdParty = new("recipient_name"),
                Type = CheckTransfers::CheckTransferType.CheckTransfer,
                ValidUntilDate = null,
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
        var model = new CheckTransfers::CheckTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_transfer_30b43acfu9vw8fyc4f5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 1000,
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    ApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    BalanceCheck = null,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CheckNumber = "123",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CheckTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = CheckTransfers::Currency.Usd,
                    FulfillmentMethod =
                        CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck,
                    IdempotencyKey = null,
                    Mailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    PhysicalCheck = new()
                    {
                        AttachmentFileID = null,
                        CheckVoucherImageFileID = null,
                        MailingAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Memo = "Invoice 29582",
                        Note = null,
                        Payer =
                        [
                            new("Ian Crease"),
                            new("33 Liberty Street"),
                            new("New York, NY 10045"),
                        ],
                        RecipientName = "Ian Crease",
                        ReturnAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        ShippingMethod = null,
                        Signature = new() { ImageFileID = null, Text = "Ian Crease" },
                        TrackingUpdates =
                        [
                            new()
                            {
                                Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PostalCode = "postal_code",
                            },
                        ],
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CheckTransfers::CheckTransferStatus.Mailed,
                    StopPaymentRequest = new()
                    {
                        Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
                        RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
                    },
                    Submission = new()
                    {
                        PreviewFileID = null,
                        SubmittedAddress = new()
                        {
                            City = "NEW YORK",
                            Line1 = "33 LIBERTY STREET",
                            Line2 = null,
                            RecipientName = "IAN CREASE",
                            State = "NY",
                            Zip = "10045",
                        },
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TrackingNumber = null,
                    },
                    ThirdParty = new("recipient_name"),
                    Type = CheckTransfers::CheckTransferType.CheckTransfer,
                    ValidUntilDate = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CheckTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "check_transfer_30b43acfu9vw8fyc4f5",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumber = "987654321",
                    Amount = 1000,
                    Approval = new()
                    {
                        ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        ApprovedBy = null,
                    },
                    ApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                    BalanceCheck = null,
                    Cancellation = new()
                    {
                        CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CanceledBy = null,
                    },
                    CheckNumber = "123",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreatedBy = new()
                    {
                        Category = CheckTransfers::Category.User,
                        ApiKey = new("description"),
                        OAuthApplication = new("name"),
                        User = new("user@example.com"),
                    },
                    Currency = CheckTransfers::Currency.Usd,
                    FulfillmentMethod =
                        CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck,
                    IdempotencyKey = null,
                    Mailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z")),
                    PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
                    PhysicalCheck = new()
                    {
                        AttachmentFileID = null,
                        CheckVoucherImageFileID = null,
                        MailingAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Memo = "Invoice 29582",
                        Note = null,
                        Payer =
                        [
                            new("Ian Crease"),
                            new("33 Liberty Street"),
                            new("New York, NY 10045"),
                        ],
                        RecipientName = "Ian Crease",
                        ReturnAddress = new()
                        {
                            City = "New York",
                            Line1 = "33 Liberty Street",
                            Line2 = null,
                            Name = "Ian Crease",
                            Phone = "+16505046304",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        ShippingMethod = null,
                        Signature = new() { ImageFileID = null, Text = "Ian Crease" },
                        TrackingUpdates =
                        [
                            new()
                            {
                                Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                                PostalCode = "postal_code",
                            },
                        ],
                    },
                    RoutingNumber = "101050001",
                    SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Status = CheckTransfers::CheckTransferStatus.Mailed,
                    StopPaymentRequest = new()
                    {
                        Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
                        RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
                    },
                    Submission = new()
                    {
                        PreviewFileID = null,
                        SubmittedAddress = new()
                        {
                            City = "NEW YORK",
                            Line1 = "33 LIBERTY STREET",
                            Line2 = null,
                            RecipientName = "IAN CREASE",
                            State = "NY",
                            Zip = "10045",
                        },
                        SubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TrackingNumber = null,
                    },
                    ThirdParty = new("recipient_name"),
                    Type = CheckTransfers::CheckTransferType.CheckTransfer,
                    ValidUntilDate = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        CheckTransfers::CheckTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
