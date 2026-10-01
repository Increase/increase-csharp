using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using RealTimePaymentsRequestsForPayment = Increase.Api.Models.RealTimePaymentsRequestsForPayment;

namespace Increase.Api.Tests.Models.RealTimePaymentsRequestsForPayment;

public class RealTimePaymentsRequestForPaymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment
        {
            ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Cancellation = new()
            {
                AdditionalInformation = null,
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorName = "National Phonograph Company",
            Currency = RealTimePaymentsRequestsForPayment::Currency.Usd,
            Debtor = new()
            {
                Address = new()
                {
                    AddressLine2 = "Unit 2",
                    BuildingNumber = "33",
                    City = "New York",
                    Country = "US",
                    PostalCode = "10045",
                    State = "NY",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            FulfillmentInboundRealTimePaymentsTransferID = null,
            IdempotencyKey = null,
            Refusal = new()
            {
                RefusalReasonAdditionalInformation = null,
                RefusalReasonCode =
                    RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
                RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode =
                    RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            Status = RealTimePaymentsRequestsForPayment::Status.PendingResponse,
            Submission = new("20220501234567891T1BSLZO01745013025"),
            Type = RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string expectedID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        RealTimePaymentsRequestsForPayment::Cancellation expectedCancellation = new()
        {
            AdditionalInformation = null,
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorName = "National Phonograph Company";
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Currency> expectedCurrency =
            RealTimePaymentsRequestsForPayment::Currency.Usd;
        RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor expectedDebtor =
            new()
            {
                Address = new()
                {
                    AddressLine2 = "Unit 2",
                    BuildingNumber = "33",
                    City = "New York",
                    Country = "US",
                    PostalCode = "10045",
                    State = "NY",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            };
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorRoutingNumber = "101050001";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z");
        RealTimePaymentsRequestsForPayment::Refusal expectedRefusal = new()
        {
            RefusalReasonAdditionalInformation = null,
            RefusalReasonCode =
                RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
            RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        RealTimePaymentsRequestsForPayment::Rejection expectedRejection = new()
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        DateTimeOffset expectedRequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z");
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Status> expectedStatus =
            RealTimePaymentsRequestsForPayment::Status.PendingResponse;
        RealTimePaymentsRequestsForPayment::Submission expectedSubmission = new(
            "20220501234567891T1BSLZO01745013025"
        );
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Type> expectedType =
            RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCancellation, model.Cancellation);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtor, model.Debtor);
        Assert.Equal(expectedDebtorAccountNumber, model.DebtorAccountNumber);
        Assert.Equal(expectedDebtorRoutingNumber, model.DebtorRoutingNumber);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Null(model.FulfillmentInboundRealTimePaymentsTransferID);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedRefusal, model.Refusal);
        Assert.Equal(expectedRejection, model.Rejection);
        Assert.Equal(expectedRequestedExecutionAt, model.RequestedExecutionAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment
        {
            ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Cancellation = new()
            {
                AdditionalInformation = null,
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorName = "National Phonograph Company",
            Currency = RealTimePaymentsRequestsForPayment::Currency.Usd,
            Debtor = new()
            {
                Address = new()
                {
                    AddressLine2 = "Unit 2",
                    BuildingNumber = "33",
                    City = "New York",
                    Country = "US",
                    PostalCode = "10045",
                    State = "NY",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            FulfillmentInboundRealTimePaymentsTransferID = null,
            IdempotencyKey = null,
            Refusal = new()
            {
                RefusalReasonAdditionalInformation = null,
                RefusalReasonCode =
                    RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
                RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode =
                    RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            Status = RealTimePaymentsRequestsForPayment::Status.PendingResponse,
            Submission = new("20220501234567891T1BSLZO01745013025"),
            Type = RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment
        {
            ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Cancellation = new()
            {
                AdditionalInformation = null,
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorName = "National Phonograph Company",
            Currency = RealTimePaymentsRequestsForPayment::Currency.Usd,
            Debtor = new()
            {
                Address = new()
                {
                    AddressLine2 = "Unit 2",
                    BuildingNumber = "33",
                    City = "New York",
                    Country = "US",
                    PostalCode = "10045",
                    State = "NY",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            FulfillmentInboundRealTimePaymentsTransferID = null,
            IdempotencyKey = null,
            Refusal = new()
            {
                RefusalReasonAdditionalInformation = null,
                RefusalReasonCode =
                    RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
                RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode =
                    RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            Status = RealTimePaymentsRequestsForPayment::Status.PendingResponse,
            Submission = new("20220501234567891T1BSLZO01745013025"),
            Type = RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        RealTimePaymentsRequestsForPayment::Cancellation expectedCancellation = new()
        {
            AdditionalInformation = null,
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorName = "National Phonograph Company";
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Currency> expectedCurrency =
            RealTimePaymentsRequestsForPayment::Currency.Usd;
        RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor expectedDebtor =
            new()
            {
                Address = new()
                {
                    AddressLine2 = "Unit 2",
                    BuildingNumber = "33",
                    City = "New York",
                    Country = "US",
                    PostalCode = "10045",
                    State = "NY",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            };
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorRoutingNumber = "101050001";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z");
        RealTimePaymentsRequestsForPayment::Refusal expectedRefusal = new()
        {
            RefusalReasonAdditionalInformation = null,
            RefusalReasonCode =
                RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
            RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        RealTimePaymentsRequestsForPayment::Rejection expectedRejection = new()
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };
        DateTimeOffset expectedRequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z");
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Status> expectedStatus =
            RealTimePaymentsRequestsForPayment::Status.PendingResponse;
        RealTimePaymentsRequestsForPayment::Submission expectedSubmission = new(
            "20220501234567891T1BSLZO01745013025"
        );
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Type> expectedType =
            RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCancellation, deserialized.Cancellation);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtor, deserialized.Debtor);
        Assert.Equal(expectedDebtorAccountNumber, deserialized.DebtorAccountNumber);
        Assert.Equal(expectedDebtorRoutingNumber, deserialized.DebtorRoutingNumber);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Null(deserialized.FulfillmentInboundRealTimePaymentsTransferID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedRefusal, deserialized.Refusal);
        Assert.Equal(expectedRejection, deserialized.Rejection);
        Assert.Equal(expectedRequestedExecutionAt, deserialized.RequestedExecutionAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment
        {
            ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Cancellation = new()
            {
                AdditionalInformation = null,
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorName = "National Phonograph Company",
            Currency = RealTimePaymentsRequestsForPayment::Currency.Usd,
            Debtor = new()
            {
                Address = new()
                {
                    AddressLine2 = "Unit 2",
                    BuildingNumber = "33",
                    City = "New York",
                    Country = "US",
                    PostalCode = "10045",
                    State = "NY",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            FulfillmentInboundRealTimePaymentsTransferID = null,
            IdempotencyKey = null,
            Refusal = new()
            {
                RefusalReasonAdditionalInformation = null,
                RefusalReasonCode =
                    RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
                RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode =
                    RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            Status = RealTimePaymentsRequestsForPayment::Status.PendingResponse,
            Submission = new("20220501234567891T1BSLZO01745013025"),
            Type = RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment
        {
            ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Cancellation = new()
            {
                AdditionalInformation = null,
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorName = "National Phonograph Company",
            Currency = RealTimePaymentsRequestsForPayment::Currency.Usd,
            Debtor = new()
            {
                Address = new()
                {
                    AddressLine2 = "Unit 2",
                    BuildingNumber = "33",
                    City = "New York",
                    Country = "US",
                    PostalCode = "10045",
                    State = "NY",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            FulfillmentInboundRealTimePaymentsTransferID = null,
            IdempotencyKey = null,
            Refusal = new()
            {
                RefusalReasonAdditionalInformation = null,
                RefusalReasonCode =
                    RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
                RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            Rejection = new()
            {
                RejectReasonAdditionalInformation = null,
                RejectReasonCode =
                    RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
                RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            },
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            Status = RealTimePaymentsRequestsForPayment::Status.PendingResponse,
            Submission = new("20220501234567891T1BSLZO01745013025"),
            Type = RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Cancellation
        {
            AdditionalInformation = null,
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
        };

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, RealTimePaymentsRequestsForPayment::CancellationReason> expectedReason =
            RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer;

        Assert.Null(model.AdditionalInformation);
        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Cancellation
        {
            AdditionalInformation = null,
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::Cancellation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Cancellation
        {
            AdditionalInformation = null,
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::Cancellation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, RealTimePaymentsRequestsForPayment::CancellationReason> expectedReason =
            RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer;

        Assert.Null(deserialized.AdditionalInformation);
        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Cancellation
        {
            AdditionalInformation = null,
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Cancellation
        {
            AdditionalInformation = null,
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Reason = RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
        };

        RealTimePaymentsRequestsForPayment::Cancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationReasonTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer)]
    [InlineData(RealTimePaymentsRequestsForPayment::CancellationReason.PaidByOtherMeans)]
    [InlineData(RealTimePaymentsRequestsForPayment::CancellationReason.Duplicate)]
    [InlineData(RealTimePaymentsRequestsForPayment::CancellationReason.WrongAmount)]
    public void Validation_Works(RealTimePaymentsRequestsForPayment::CancellationReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::CancellationReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::CancellationReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer)]
    [InlineData(RealTimePaymentsRequestsForPayment::CancellationReason.PaidByOtherMeans)]
    [InlineData(RealTimePaymentsRequestsForPayment::CancellationReason.Duplicate)]
    [InlineData(RealTimePaymentsRequestsForPayment::CancellationReason.WrongAmount)]
    public void SerializationRoundtrip_Works(
        RealTimePaymentsRequestsForPayment::CancellationReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::CancellationReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::CancellationReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::CancellationReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::CancellationReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::Currency.Usd)]
    public void Validation_Works(RealTimePaymentsRequestsForPayment::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Currency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::Currency.Usd)]
    public void SerializationRoundtrip_Works(RealTimePaymentsRequestsForPayment::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Currency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimePaymentsRequestForPaymentDebtorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor
        {
            Address = new()
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            },
            Name = "name",
        };

        RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress expectedAddress =
            new()
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            };
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor
        {
            Address = new()
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            },
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor
        {
            Address = new()
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            },
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress expectedAddress =
            new()
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            };
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor
        {
            Address = new()
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor
        {
            Address = new()
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            },
            Name = "name",
        };

        RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtor copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class RealTimePaymentsRequestForPaymentDebtorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            };

        string expectedAddressLine2 = "address_line2";
        string expectedBuildingNumber = "building_number";
        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";
        string expectedStreetName = "street_name";

        Assert.Equal(expectedAddressLine2, model.AddressLine2);
        Assert.Equal(expectedBuildingNumber, model.BuildingNumber);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreetName, model.StreetName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAddressLine2 = "address_line2";
        string expectedBuildingNumber = "building_number";
        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";
        string expectedStreetName = "street_name";

        Assert.Equal(expectedAddressLine2, deserialized.AddressLine2);
        Assert.Equal(expectedBuildingNumber, deserialized.BuildingNumber);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreetName, deserialized.StreetName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress
            {
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
                City = "city",
                Country = "country",
                PostalCode = "postal_code",
                State = "state",
                StreetName = "street_name",
            };

        RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPaymentDebtorAddress copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class RefusalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Refusal
        {
            RefusalReasonAdditionalInformation = null,
            RefusalReasonCode =
                RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
            RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        ApiEnum<
            string,
            RealTimePaymentsRequestsForPayment::RefusalReasonCode
        > expectedRefusalReasonCode =
            RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked;
        DateTimeOffset expectedRefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(model.RefusalReasonAdditionalInformation);
        Assert.Equal(expectedRefusalReasonCode, model.RefusalReasonCode);
        Assert.Equal(expectedRefusedAt, model.RefusedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Refusal
        {
            RefusalReasonAdditionalInformation = null,
            RefusalReasonCode =
                RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
            RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::Refusal>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Refusal
        {
            RefusalReasonAdditionalInformation = null,
            RefusalReasonCode =
                RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
            RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::Refusal>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            RealTimePaymentsRequestsForPayment::RefusalReasonCode
        > expectedRefusalReasonCode =
            RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked;
        DateTimeOffset expectedRefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(deserialized.RefusalReasonAdditionalInformation);
        Assert.Equal(expectedRefusalReasonCode, deserialized.RefusalReasonCode);
        Assert.Equal(expectedRefusedAt, deserialized.RefusedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Refusal
        {
            RefusalReasonAdditionalInformation = null,
            RefusalReasonCode =
                RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
            RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Refusal
        {
            RefusalReasonAdditionalInformation = null,
            RefusalReasonCode =
                RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked,
            RefusedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        RealTimePaymentsRequestsForPayment::Refusal copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RefusalReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.TransactionForbidden)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.TransactionTypeNotSupported)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.UnexpectedAmount)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.AmountExceedsBankLimits)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.InvalidDebtorAddress)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.InvalidCreditorAddress)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.CreditorIdentifierIncorrect)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.RequestedByCustomer)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.OrderRejected)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.EndCustomerDeceased)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.CustomerHasOptedOut)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.Other)]
    public void Validation_Works(RealTimePaymentsRequestsForPayment::RefusalReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::RefusalReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::RefusalReasonCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.AccountBlocked)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.TransactionForbidden)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.TransactionTypeNotSupported)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.UnexpectedAmount)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.AmountExceedsBankLimits)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.InvalidDebtorAddress)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.InvalidCreditorAddress)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.CreditorIdentifierIncorrect)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.RequestedByCustomer)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.OrderRejected)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.EndCustomerDeceased)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.CustomerHasOptedOut)]
    [InlineData(RealTimePaymentsRequestsForPayment::RefusalReasonCode.Other)]
    public void SerializationRoundtrip_Works(
        RealTimePaymentsRequestsForPayment::RefusalReasonCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::RefusalReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::RefusalReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::RefusalReasonCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::RefusalReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RejectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        ApiEnum<
            string,
            RealTimePaymentsRequestsForPayment::RejectReasonCode
        > expectedRejectReasonCode =
            RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(model.RejectReasonAdditionalInformation);
        Assert.Equal(expectedRejectReasonCode, model.RejectReasonCode);
        Assert.Equal(expectedRejectedAt, model.RejectedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::Rejection>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::Rejection>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            RealTimePaymentsRequestsForPayment::RejectReasonCode
        > expectedRejectReasonCode =
            RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed;
        DateTimeOffset expectedRejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Null(deserialized.RejectReasonAdditionalInformation);
        Assert.Equal(expectedRejectReasonCode, deserialized.RejectReasonCode);
        Assert.Equal(expectedRejectedAt, deserialized.RejectedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Rejection
        {
            RejectReasonAdditionalInformation = null,
            RejectReasonCode = RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed,
            RejectedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        RealTimePaymentsRequestsForPayment::Rejection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RejectReasonCodeTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountBlocked)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(
        RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier
    )]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.EndCustomerDeceased)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.Narrative)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.TransactionForbidden)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.UnexpectedAmount)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.UnknownEndCustomer)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.Timeout)]
    [InlineData(
        RealTimePaymentsRequestsForPayment::RejectReasonCode.UnsupportedMessageForRecipient
    )]
    [InlineData(
        RealTimePaymentsRequestsForPayment::RejectReasonCode.RecipientConnectionNotAvailable
    )]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.RealTimePaymentsSuspended)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InstructedAgentSignedOff)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.ProcessingError)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.Other)]
    public void Validation_Works(RealTimePaymentsRequestsForPayment::RejectReasonCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::RejectReasonCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::RejectReasonCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountClosed)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.AccountBlocked)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidCreditorAccountType)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidCreditorAccountNumber)]
    [InlineData(
        RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidCreditorFinancialInstitutionIdentifier
    )]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.EndCustomerDeceased)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.Narrative)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.TransactionForbidden)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.TransactionTypeNotSupported)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.UnexpectedAmount)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.AmountExceedsBankLimits)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidCreditorAddress)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.UnknownEndCustomer)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InvalidDebtorAddress)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.Timeout)]
    [InlineData(
        RealTimePaymentsRequestsForPayment::RejectReasonCode.UnsupportedMessageForRecipient
    )]
    [InlineData(
        RealTimePaymentsRequestsForPayment::RejectReasonCode.RecipientConnectionNotAvailable
    )]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.RealTimePaymentsSuspended)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.InstructedAgentSignedOff)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.ProcessingError)]
    [InlineData(RealTimePaymentsRequestsForPayment::RejectReasonCode.Other)]
    public void SerializationRoundtrip_Works(
        RealTimePaymentsRequestsForPayment::RejectReasonCode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::RejectReasonCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::RejectReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::RejectReasonCode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::RejectReasonCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.PendingSubmission)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.PendingResponse)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Rejected)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Accepted)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Refused)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Fulfilled)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Canceled)]
    public void Validation_Works(RealTimePaymentsRequestsForPayment::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Status>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.PendingSubmission)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.PendingResponse)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Rejected)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Accepted)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Refused)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Fulfilled)]
    [InlineData(RealTimePaymentsRequestsForPayment::Status.Canceled)]
    public void SerializationRoundtrip_Works(RealTimePaymentsRequestsForPayment::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Status>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Submission
        {
            PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
        };

        string expectedPaymentInformationIdentification = "20220501234567891T1BSLZO01745013025";

        Assert.Equal(
            expectedPaymentInformationIdentification,
            model.PaymentInformationIdentification
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Submission
        {
            PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::Submission>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Submission
        {
            PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::Submission>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedPaymentInformationIdentification = "20220501234567891T1BSLZO01745013025";

        Assert.Equal(
            expectedPaymentInformationIdentification,
            deserialized.PaymentInformationIdentification
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Submission
        {
            PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimePaymentsRequestsForPayment::Submission
        {
            PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
        };

        RealTimePaymentsRequestsForPayment::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment)]
    public void Validation_Works(RealTimePaymentsRequestsForPayment::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment)]
    public void SerializationRoundtrip_Works(RealTimePaymentsRequestsForPayment::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimePaymentsRequestsForPayment::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimePaymentsRequestsForPayment::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
