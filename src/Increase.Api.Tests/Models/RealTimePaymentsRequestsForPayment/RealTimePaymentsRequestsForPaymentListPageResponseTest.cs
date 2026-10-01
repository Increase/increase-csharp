using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using RealTimePaymentsRequestsForPayment = Increase.Api.Models.RealTimePaymentsRequestsForPayment;

namespace Increase.Api.Tests.Models.RealTimePaymentsRequestsForPayment;

public class RealTimePaymentsRequestsForPaymentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Cancellation = new()
                        {
                            AdditionalInformation = null,
                            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Reason =
                                RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
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
                        Type =
                            RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        List<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment> expectedData =
        [
            new()
            {
                ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                Cancellation = new()
                {
                    AdditionalInformation = null,
                    CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Reason =
                        RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
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
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Cancellation = new()
                        {
                            AdditionalInformation = null,
                            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Reason =
                                RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
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
                        Type =
                            RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestsForPaymentListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Cancellation = new()
                        {
                            AdditionalInformation = null,
                            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Reason =
                                RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
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
                        Type =
                            RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestsForPaymentListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestForPayment> expectedData =
        [
            new()
            {
                ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                Cancellation = new()
                {
                    AdditionalInformation = null,
                    CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Reason =
                        RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
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
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Cancellation = new()
                        {
                            AdditionalInformation = null,
                            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Reason =
                                RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
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
                        Type =
                            RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Cancellation = new()
                        {
                            AdditionalInformation = null,
                            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Reason =
                                RealTimePaymentsRequestsForPayment::CancellationReason.RequestedByCustomer,
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
                        Type =
                            RealTimePaymentsRequestsForPayment::Type.RealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        RealTimePaymentsRequestsForPayment::RealTimePaymentsRequestsForPaymentListPageResponse copied =
            new(model);

        Assert.Equal(model, copied);
    }
}
