using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using CheckTransfers = Increase.Api.Models.CheckTransfers;

namespace Increase.Api.Tests.Models.CheckTransfers;

public class CheckTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransfer
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
                Payer = [new("Ian Crease"), new("33 Liberty Street"), new("New York, NY 10045")],
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
                        Country = "country",
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
        };

        string expectedID = "check_transfer_30b43acfu9vw8fyc4f5";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        long expectedAmount = 1000;
        CheckTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        string expectedApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra";
        CheckTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        string expectedCheckNumber = "123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        CheckTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = CheckTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        ApiEnum<string, CheckTransfers::Currency> expectedCurrency = CheckTransfers::Currency.Usd;
        ApiEnum<string, CheckTransfers::CheckTransferFulfillmentMethod> expectedFulfillmentMethod =
            CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck;
        CheckTransfers::Mailing expectedMailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z"));
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        CheckTransfers::CheckTransferPhysicalCheck expectedPhysicalCheck = new()
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
            Payer = [new("Ian Crease"), new("33 Liberty Street"), new("New York, NY 10045")],
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
                    Country = "country",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                },
            ],
        };
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, CheckTransfers::CheckTransferStatus> expectedStatus =
            CheckTransfers::CheckTransferStatus.Mailed;
        CheckTransfers::StopPaymentRequest expectedStopPaymentRequest = new()
        {
            Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
            RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
        };
        CheckTransfers::Submission expectedSubmission = new()
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
        };
        CheckTransfers::CheckTransferThirdParty expectedThirdParty = new("recipient_name");
        ApiEnum<string, CheckTransfers::CheckTransferType> expectedType =
            CheckTransfers::CheckTransferType.CheckTransfer;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedApprovedInboundCheckDepositID, model.ApprovedInboundCheckDepositID);
        Assert.Null(model.BalanceCheck);
        Assert.Equal(expectedCancellation, model.Cancellation);
        Assert.Equal(expectedCheckNumber, model.CheckNumber);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedFulfillmentMethod, model.FulfillmentMethod);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedMailing, model.Mailing);
        Assert.Equal(expectedPendingTransactionID, model.PendingTransactionID);
        Assert.Equal(expectedPhysicalCheck, model.PhysicalCheck);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, model.SourceAccountNumberID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStopPaymentRequest, model.StopPaymentRequest);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedThirdParty, model.ThirdParty);
        Assert.Equal(expectedType, model.Type);
        Assert.Null(model.ValidUntilDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransfer
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
                Payer = [new("Ian Crease"), new("33 Liberty Street"), new("New York, NY 10045")],
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
                        Country = "country",
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::CheckTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CheckTransfer
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
                Payer = [new("Ian Crease"), new("33 Liberty Street"), new("New York, NY 10045")],
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
                        Country = "country",
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::CheckTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "check_transfer_30b43acfu9vw8fyc4f5";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        long expectedAmount = 1000;
        CheckTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        string expectedApprovedInboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra";
        CheckTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        string expectedCheckNumber = "123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        CheckTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = CheckTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        ApiEnum<string, CheckTransfers::Currency> expectedCurrency = CheckTransfers::Currency.Usd;
        ApiEnum<string, CheckTransfers::CheckTransferFulfillmentMethod> expectedFulfillmentMethod =
            CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck;
        CheckTransfers::Mailing expectedMailing = new(DateTimeOffset.Parse("2020-01-31T23:59:59Z"));
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        CheckTransfers::CheckTransferPhysicalCheck expectedPhysicalCheck = new()
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
            Payer = [new("Ian Crease"), new("33 Liberty Street"), new("New York, NY 10045")],
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
                    Country = "country",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                },
            ],
        };
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, CheckTransfers::CheckTransferStatus> expectedStatus =
            CheckTransfers::CheckTransferStatus.Mailed;
        CheckTransfers::StopPaymentRequest expectedStopPaymentRequest = new()
        {
            Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
            RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
        };
        CheckTransfers::Submission expectedSubmission = new()
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
        };
        CheckTransfers::CheckTransferThirdParty expectedThirdParty = new("recipient_name");
        ApiEnum<string, CheckTransfers::CheckTransferType> expectedType =
            CheckTransfers::CheckTransferType.CheckTransfer;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(
            expectedApprovedInboundCheckDepositID,
            deserialized.ApprovedInboundCheckDepositID
        );
        Assert.Null(deserialized.BalanceCheck);
        Assert.Equal(expectedCancellation, deserialized.Cancellation);
        Assert.Equal(expectedCheckNumber, deserialized.CheckNumber);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedFulfillmentMethod, deserialized.FulfillmentMethod);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedMailing, deserialized.Mailing);
        Assert.Equal(expectedPendingTransactionID, deserialized.PendingTransactionID);
        Assert.Equal(expectedPhysicalCheck, deserialized.PhysicalCheck);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, deserialized.SourceAccountNumberID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStopPaymentRequest, deserialized.StopPaymentRequest);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedThirdParty, deserialized.ThirdParty);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Null(deserialized.ValidUntilDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::CheckTransfer
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
                Payer = [new("Ian Crease"), new("33 Liberty Street"), new("New York, NY 10045")],
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
                        Country = "country",
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CheckTransfer
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
                Payer = [new("Ian Crease"), new("33 Liberty Street"), new("New York, NY 10045")],
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
                        Country = "country",
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
        };

        CheckTransfers::CheckTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedApprovedAt, model.ApprovedAt);
        Assert.Null(model.ApprovedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::Approval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::Approval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedApprovedAt, deserialized.ApprovedAt);
        Assert.Null(deserialized.ApprovedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        CheckTransfers::Approval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferBalanceCheckTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::CheckTransferBalanceCheck.Full)]
    [InlineData(CheckTransfers::CheckTransferBalanceCheck.None)]
    public void Validation_Works(CheckTransfers::CheckTransferBalanceCheck rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferBalanceCheck> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferBalanceCheck>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::CheckTransferBalanceCheck.Full)]
    [InlineData(CheckTransfers::CheckTransferBalanceCheck.None)]
    public void SerializationRoundtrip_Works(CheckTransfers::CheckTransferBalanceCheck rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferBalanceCheck> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferBalanceCheck>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferBalanceCheck>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferBalanceCheck>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Null(model.CanceledBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::Cancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::Cancellation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Null(deserialized.CanceledBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        CheckTransfers::Cancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CreatedBy
        {
            Category = CheckTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, CheckTransfers::Category> expectedCategory = CheckTransfers::Category.User;
        CheckTransfers::ApiKey expectedApiKey = new("description");
        CheckTransfers::OAuthApplication expectedOAuthApplication = new("name");
        CheckTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::CreatedBy
        {
            Category = CheckTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CreatedBy
        {
            Category = CheckTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CheckTransfers::Category> expectedCategory = CheckTransfers::Category.User;
        CheckTransfers::ApiKey expectedApiKey = new("description");
        CheckTransfers::OAuthApplication expectedOAuthApplication = new("name");
        CheckTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::CreatedBy
        {
            Category = CheckTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckTransfers::CreatedBy { Category = CheckTransfers::Category.User };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.OAuthApplication);
        Assert.False(model.RawData.ContainsKey("oauth_application"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckTransfers::CreatedBy { Category = CheckTransfers::Category.User };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckTransfers::CreatedBy
        {
            Category = CheckTransfers::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        Assert.Null(model.ApiKey);
        Assert.True(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.OAuthApplication);
        Assert.True(model.RawData.ContainsKey("oauth_application"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckTransfers::CreatedBy
        {
            Category = CheckTransfers::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CreatedBy
        {
            Category = CheckTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        CheckTransfers::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::Category.ApiKey)]
    [InlineData(CheckTransfers::Category.OAuthApplication)]
    [InlineData(CheckTransfers::Category.User)]
    public void Validation_Works(CheckTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::Category.ApiKey)]
    [InlineData(CheckTransfers::Category.OAuthApplication)]
    [InlineData(CheckTransfers::Category.User)]
    public void SerializationRoundtrip_Works(CheckTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::ApiKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::ApiKey { Description = "description" };

        CheckTransfers::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::OAuthApplication>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::OAuthApplication { Name = "name" };

        CheckTransfers::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::User>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::User { Email = "email" };

        CheckTransfers::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::Currency.Usd)]
    public void Validation_Works(CheckTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::Currency.Usd)]
    public void SerializationRoundtrip_Works(CheckTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CheckTransferFulfillmentMethodTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck)]
    [InlineData(CheckTransfers::CheckTransferFulfillmentMethod.ThirdParty)]
    public void Validation_Works(CheckTransfers::CheckTransferFulfillmentMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferFulfillmentMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferFulfillmentMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::CheckTransferFulfillmentMethod.PhysicalCheck)]
    [InlineData(CheckTransfers::CheckTransferFulfillmentMethod.ThirdParty)]
    public void SerializationRoundtrip_Works(
        CheckTransfers::CheckTransferFulfillmentMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferFulfillmentMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferFulfillmentMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferFulfillmentMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferFulfillmentMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MailingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::Mailing
        {
            MailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedMailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedMailedAt, model.MailedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::Mailing
        {
            MailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::Mailing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::Mailing
        {
            MailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::Mailing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedMailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedMailedAt, deserialized.MailedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::Mailing
        {
            MailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::Mailing
        {
            MailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CheckTransfers::Mailing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferPhysicalCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheck
        {
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            MailingAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            Memo = "memo",
            Note = "note",
            Payer = [new("contents")],
            RecipientName = "recipient_name",
            ReturnAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            ShippingMethod =
                CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "text" },
            TrackingUpdates =
            [
                new()
                {
                    Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                    Country = "country",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                },
            ],
        };

        string expectedAttachmentFileID = "attachment_file_id";
        string expectedCheckVoucherImageFileID = "check_voucher_image_file_id";
        CheckTransfers::CheckTransferPhysicalCheckMailingAddress expectedMailingAddress = new()
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };
        string expectedMemo = "memo";
        string expectedNote = "note";
        List<CheckTransfers::CheckTransferPhysicalCheckPayer> expectedPayer = [new("contents")];
        string expectedRecipientName = "recipient_name";
        CheckTransfers::CheckTransferPhysicalCheckReturnAddress expectedReturnAddress = new()
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };
        ApiEnum<
            string,
            CheckTransfers::CheckTransferPhysicalCheckShippingMethod
        > expectedShippingMethod =
            CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass;
        CheckTransfers::CheckTransferPhysicalCheckSignature expectedSignature = new()
        {
            ImageFileID = "image_file_id",
            Text = "text",
        };
        List<CheckTransfers::TrackingUpdate> expectedTrackingUpdates =
        [
            new()
            {
                Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                Country = "country",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PostalCode = "postal_code",
            },
        ];

        Assert.Equal(expectedAttachmentFileID, model.AttachmentFileID);
        Assert.Equal(expectedCheckVoucherImageFileID, model.CheckVoucherImageFileID);
        Assert.Equal(expectedMailingAddress, model.MailingAddress);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedNote, model.Note);
        Assert.Equal(expectedPayer.Count, model.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], model.Payer[i]);
        }
        Assert.Equal(expectedRecipientName, model.RecipientName);
        Assert.Equal(expectedReturnAddress, model.ReturnAddress);
        Assert.Equal(expectedShippingMethod, model.ShippingMethod);
        Assert.Equal(expectedSignature, model.Signature);
        Assert.Equal(expectedTrackingUpdates.Count, model.TrackingUpdates.Count);
        for (int i = 0; i < expectedTrackingUpdates.Count; i++)
        {
            Assert.Equal(expectedTrackingUpdates[i], model.TrackingUpdates[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheck
        {
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            MailingAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            Memo = "memo",
            Note = "note",
            Payer = [new("contents")],
            RecipientName = "recipient_name",
            ReturnAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            ShippingMethod =
                CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "text" },
            TrackingUpdates =
            [
                new()
                {
                    Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                    Country = "country",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheck>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheck
        {
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            MailingAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            Memo = "memo",
            Note = "note",
            Payer = [new("contents")],
            RecipientName = "recipient_name",
            ReturnAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            ShippingMethod =
                CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "text" },
            TrackingUpdates =
            [
                new()
                {
                    Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                    Country = "country",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheck>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttachmentFileID = "attachment_file_id";
        string expectedCheckVoucherImageFileID = "check_voucher_image_file_id";
        CheckTransfers::CheckTransferPhysicalCheckMailingAddress expectedMailingAddress = new()
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };
        string expectedMemo = "memo";
        string expectedNote = "note";
        List<CheckTransfers::CheckTransferPhysicalCheckPayer> expectedPayer = [new("contents")];
        string expectedRecipientName = "recipient_name";
        CheckTransfers::CheckTransferPhysicalCheckReturnAddress expectedReturnAddress = new()
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };
        ApiEnum<
            string,
            CheckTransfers::CheckTransferPhysicalCheckShippingMethod
        > expectedShippingMethod =
            CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass;
        CheckTransfers::CheckTransferPhysicalCheckSignature expectedSignature = new()
        {
            ImageFileID = "image_file_id",
            Text = "text",
        };
        List<CheckTransfers::TrackingUpdate> expectedTrackingUpdates =
        [
            new()
            {
                Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                Country = "country",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PostalCode = "postal_code",
            },
        ];

        Assert.Equal(expectedAttachmentFileID, deserialized.AttachmentFileID);
        Assert.Equal(expectedCheckVoucherImageFileID, deserialized.CheckVoucherImageFileID);
        Assert.Equal(expectedMailingAddress, deserialized.MailingAddress);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedNote, deserialized.Note);
        Assert.Equal(expectedPayer.Count, deserialized.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], deserialized.Payer[i]);
        }
        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
        Assert.Equal(expectedReturnAddress, deserialized.ReturnAddress);
        Assert.Equal(expectedShippingMethod, deserialized.ShippingMethod);
        Assert.Equal(expectedSignature, deserialized.Signature);
        Assert.Equal(expectedTrackingUpdates.Count, deserialized.TrackingUpdates.Count);
        for (int i = 0; i < expectedTrackingUpdates.Count; i++)
        {
            Assert.Equal(expectedTrackingUpdates[i], deserialized.TrackingUpdates[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheck
        {
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            MailingAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            Memo = "memo",
            Note = "note",
            Payer = [new("contents")],
            RecipientName = "recipient_name",
            ReturnAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            ShippingMethod =
                CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "text" },
            TrackingUpdates =
            [
                new()
                {
                    Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                    Country = "country",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheck
        {
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            MailingAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            Memo = "memo",
            Note = "note",
            Payer = [new("contents")],
            RecipientName = "recipient_name",
            ReturnAddress = new()
            {
                City = "city",
                Line1 = "line1",
                Line2 = "line2",
                Name = "name",
                Phone = "phone",
                PostalCode = "postal_code",
                State = "state",
            },
            ShippingMethod =
                CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "text" },
            TrackingUpdates =
            [
                new()
                {
                    Category = CheckTransfers::TrackingUpdateCategory.InTransit,
                    Country = "country",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                },
            ],
        };

        CheckTransfers::CheckTransferPhysicalCheck copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferPhysicalCheckMailingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheckMailingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheckMailingAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        CheckTransfers::CheckTransferPhysicalCheckMailingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferPhysicalCheckPayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckPayer { Contents = "contents" };

        string expectedContents = "contents";

        Assert.Equal(expectedContents, model.Contents);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckPayer { Contents = "contents" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheckPayer>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckPayer { Contents = "contents" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheckPayer>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedContents = "contents";

        Assert.Equal(expectedContents, deserialized.Contents);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckPayer { Contents = "contents" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckPayer { Contents = "contents" };

        CheckTransfers::CheckTransferPhysicalCheckPayer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferPhysicalCheckReturnAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheckReturnAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheckReturnAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        CheckTransfers::CheckTransferPhysicalCheckReturnAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferPhysicalCheckShippingMethodTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass)]
    [InlineData(CheckTransfers::CheckTransferPhysicalCheckShippingMethod.FedexOvernight)]
    public void Validation_Works(CheckTransfers::CheckTransferPhysicalCheckShippingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferPhysicalCheckShippingMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferPhysicalCheckShippingMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::CheckTransferPhysicalCheckShippingMethod.UspsFirstClass)]
    [InlineData(CheckTransfers::CheckTransferPhysicalCheckShippingMethod.FedexOvernight)]
    public void SerializationRoundtrip_Works(
        CheckTransfers::CheckTransferPhysicalCheckShippingMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferPhysicalCheckShippingMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferPhysicalCheckShippingMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferPhysicalCheckShippingMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferPhysicalCheckShippingMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckTransferPhysicalCheckSignatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckSignature
        {
            ImageFileID = "image_file_id",
            Text = "text",
        };

        string expectedImageFileID = "image_file_id";
        string expectedText = "text";

        Assert.Equal(expectedImageFileID, model.ImageFileID);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckSignature
        {
            ImageFileID = "image_file_id",
            Text = "text",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheckSignature>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckSignature
        {
            ImageFileID = "image_file_id",
            Text = "text",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckTransfers::CheckTransferPhysicalCheckSignature>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedImageFileID = "image_file_id";
        string expectedText = "text";

        Assert.Equal(expectedImageFileID, deserialized.ImageFileID);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckSignature
        {
            ImageFileID = "image_file_id",
            Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CheckTransferPhysicalCheckSignature
        {
            ImageFileID = "image_file_id",
            Text = "text",
        };

        CheckTransfers::CheckTransferPhysicalCheckSignature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrackingUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::TrackingUpdate
        {
            Category = CheckTransfers::TrackingUpdateCategory.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        ApiEnum<string, CheckTransfers::TrackingUpdateCategory> expectedCategory =
            CheckTransfers::TrackingUpdateCategory.InTransit;
        string expectedCountry = "country";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPostalCode = "postal_code";

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPostalCode, model.PostalCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::TrackingUpdate
        {
            Category = CheckTransfers::TrackingUpdateCategory.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::TrackingUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::TrackingUpdate
        {
            Category = CheckTransfers::TrackingUpdateCategory.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::TrackingUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CheckTransfers::TrackingUpdateCategory> expectedCategory =
            CheckTransfers::TrackingUpdateCategory.InTransit;
        string expectedCountry = "country";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPostalCode = "postal_code";

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::TrackingUpdate
        {
            Category = CheckTransfers::TrackingUpdateCategory.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::TrackingUpdate
        {
            Category = CheckTransfers::TrackingUpdateCategory.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        CheckTransfers::TrackingUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrackingUpdateCategoryTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::TrackingUpdateCategory.InTransit)]
    [InlineData(CheckTransfers::TrackingUpdateCategory.ProcessedForDelivery)]
    [InlineData(CheckTransfers::TrackingUpdateCategory.Delivered)]
    [InlineData(CheckTransfers::TrackingUpdateCategory.DeliveryIssue)]
    [InlineData(CheckTransfers::TrackingUpdateCategory.ReturnedToSender)]
    public void Validation_Works(CheckTransfers::TrackingUpdateCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::TrackingUpdateCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::TrackingUpdateCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::TrackingUpdateCategory.InTransit)]
    [InlineData(CheckTransfers::TrackingUpdateCategory.ProcessedForDelivery)]
    [InlineData(CheckTransfers::TrackingUpdateCategory.Delivered)]
    [InlineData(CheckTransfers::TrackingUpdateCategory.DeliveryIssue)]
    [InlineData(CheckTransfers::TrackingUpdateCategory.ReturnedToSender)]
    public void SerializationRoundtrip_Works(CheckTransfers::TrackingUpdateCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::TrackingUpdateCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::TrackingUpdateCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::TrackingUpdateCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::TrackingUpdateCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CheckTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::CheckTransferStatus.PendingApproval)]
    [InlineData(CheckTransfers::CheckTransferStatus.Canceled)]
    [InlineData(CheckTransfers::CheckTransferStatus.PendingSubmission)]
    [InlineData(CheckTransfers::CheckTransferStatus.RequiresAttention)]
    [InlineData(CheckTransfers::CheckTransferStatus.Rejected)]
    [InlineData(CheckTransfers::CheckTransferStatus.PendingMailing)]
    [InlineData(CheckTransfers::CheckTransferStatus.Mailed)]
    [InlineData(CheckTransfers::CheckTransferStatus.Deposited)]
    [InlineData(CheckTransfers::CheckTransferStatus.Stopped)]
    [InlineData(CheckTransfers::CheckTransferStatus.Returned)]
    public void Validation_Works(CheckTransfers::CheckTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::CheckTransferStatus.PendingApproval)]
    [InlineData(CheckTransfers::CheckTransferStatus.Canceled)]
    [InlineData(CheckTransfers::CheckTransferStatus.PendingSubmission)]
    [InlineData(CheckTransfers::CheckTransferStatus.RequiresAttention)]
    [InlineData(CheckTransfers::CheckTransferStatus.Rejected)]
    [InlineData(CheckTransfers::CheckTransferStatus.PendingMailing)]
    [InlineData(CheckTransfers::CheckTransferStatus.Mailed)]
    [InlineData(CheckTransfers::CheckTransferStatus.Deposited)]
    [InlineData(CheckTransfers::CheckTransferStatus.Stopped)]
    [InlineData(CheckTransfers::CheckTransferStatus.Returned)]
    public void SerializationRoundtrip_Works(CheckTransfers::CheckTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StopPaymentRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::StopPaymentRequest
        {
            Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
            RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
        };

        ApiEnum<string, CheckTransfers::StopPaymentRequestReason> expectedReason =
            CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed;
        DateTimeOffset expectedRequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTransferID = "check_transfer_30b43acfu9vw8fyc4f5";
        ApiEnum<string, CheckTransfers::Type> expectedType =
            CheckTransfers::Type.CheckTransferStopPaymentRequest;

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedRequestedAt, model.RequestedAt);
        Assert.Equal(expectedTransferID, model.TransferID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::StopPaymentRequest
        {
            Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
            RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::StopPaymentRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::StopPaymentRequest
        {
            Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
            RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::StopPaymentRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CheckTransfers::StopPaymentRequestReason> expectedReason =
            CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed;
        DateTimeOffset expectedRequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedTransferID = "check_transfer_30b43acfu9vw8fyc4f5";
        ApiEnum<string, CheckTransfers::Type> expectedType =
            CheckTransfers::Type.CheckTransferStopPaymentRequest;

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedRequestedAt, deserialized.RequestedAt);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::StopPaymentRequest
        {
            Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
            RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::StopPaymentRequest
        {
            Reason = CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed,
            RequestedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
            Type = CheckTransfers::Type.CheckTransferStopPaymentRequest,
        };

        CheckTransfers::StopPaymentRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StopPaymentRequestReasonTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed)]
    [InlineData(CheckTransfers::StopPaymentRequestReason.RejectedByIncrease)]
    [InlineData(CheckTransfers::StopPaymentRequestReason.NotAuthorized)]
    [InlineData(CheckTransfers::StopPaymentRequestReason.ValidUntilDatePassed)]
    [InlineData(CheckTransfers::StopPaymentRequestReason.Unknown)]
    public void Validation_Works(CheckTransfers::StopPaymentRequestReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::StopPaymentRequestReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::StopPaymentRequestReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::StopPaymentRequestReason.MailDeliveryFailed)]
    [InlineData(CheckTransfers::StopPaymentRequestReason.RejectedByIncrease)]
    [InlineData(CheckTransfers::StopPaymentRequestReason.NotAuthorized)]
    [InlineData(CheckTransfers::StopPaymentRequestReason.ValidUntilDatePassed)]
    [InlineData(CheckTransfers::StopPaymentRequestReason.Unknown)]
    public void SerializationRoundtrip_Works(CheckTransfers::StopPaymentRequestReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::StopPaymentRequestReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::StopPaymentRequestReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::StopPaymentRequestReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::StopPaymentRequestReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::Type.CheckTransferStopPaymentRequest)]
    public void Validation_Works(CheckTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::Type.CheckTransferStopPaymentRequest)]
    public void SerializationRoundtrip_Works(CheckTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::Submission
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
        };

        CheckTransfers::SubmittedAddress expectedSubmittedAddress = new()
        {
            City = "NEW YORK",
            Line1 = "33 LIBERTY STREET",
            Line2 = null,
            RecipientName = "IAN CREASE",
            State = "NY",
            Zip = "10045",
        };
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(model.PreviewFileID);
        Assert.Equal(expectedSubmittedAddress, model.SubmittedAddress);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Null(model.TrackingNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::Submission
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::Submission
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CheckTransfers::SubmittedAddress expectedSubmittedAddress = new()
        {
            City = "NEW YORK",
            Line1 = "33 LIBERTY STREET",
            Line2 = null,
            RecipientName = "IAN CREASE",
            State = "NY",
            Zip = "10045",
        };
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(deserialized.PreviewFileID);
        Assert.Equal(expectedSubmittedAddress, deserialized.SubmittedAddress);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Null(deserialized.TrackingNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::Submission
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::Submission
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
        };

        CheckTransfers::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubmittedAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::SubmittedAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            RecipientName = "recipient_name",
            State = "state",
            Zip = "zip",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedRecipientName = "recipient_name";
        string expectedState = "state";
        string expectedZip = "zip";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedRecipientName, model.RecipientName);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedZip, model.Zip);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::SubmittedAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            RecipientName = "recipient_name",
            State = "state",
            Zip = "zip",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::SubmittedAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::SubmittedAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            RecipientName = "recipient_name",
            State = "state",
            Zip = "zip",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::SubmittedAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedRecipientName = "recipient_name";
        string expectedState = "state";
        string expectedZip = "zip";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedZip, deserialized.Zip);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::SubmittedAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            RecipientName = "recipient_name",
            State = "state",
            Zip = "zip",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::SubmittedAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            RecipientName = "recipient_name",
            State = "state",
            Zip = "zip",
        };

        CheckTransfers::SubmittedAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferThirdPartyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferThirdParty
        {
            RecipientName = "recipient_name",
        };

        string expectedRecipientName = "recipient_name";

        Assert.Equal(expectedRecipientName, model.RecipientName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckTransfers::CheckTransferThirdParty
        {
            RecipientName = "recipient_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::CheckTransferThirdParty>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckTransfers::CheckTransferThirdParty
        {
            RecipientName = "recipient_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckTransfers::CheckTransferThirdParty>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRecipientName = "recipient_name";

        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckTransfers::CheckTransferThirdParty
        {
            RecipientName = "recipient_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckTransfers::CheckTransferThirdParty
        {
            RecipientName = "recipient_name",
        };

        CheckTransfers::CheckTransferThirdParty copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckTransferTypeTest : TestBase
{
    [Theory]
    [InlineData(CheckTransfers::CheckTransferType.CheckTransfer)]
    public void Validation_Works(CheckTransfers::CheckTransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::CheckTransferType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckTransfers::CheckTransferType.CheckTransfer)]
    public void SerializationRoundtrip_Works(CheckTransfers::CheckTransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckTransfers::CheckTransferType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckTransfers::CheckTransferType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CheckTransfers::CheckTransferType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
