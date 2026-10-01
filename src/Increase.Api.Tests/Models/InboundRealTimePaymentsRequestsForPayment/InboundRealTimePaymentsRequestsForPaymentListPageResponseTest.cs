using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using InboundRealTimePaymentsRequestsForPayment = Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment;

namespace Increase.Api.Tests.Models.InboundRealTimePaymentsRequestsForPayment;

public class InboundRealTimePaymentsRequestsForPaymentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Creditor = new()
                        {
                            AccountName = "National Phonograph Company",
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
                            Name = "National Phonograph Company",
                        },
                        CreditorAccountNumber = "987654321",
                        CreditorRoutingNumber = "101050001",
                        Currency = InboundRealTimePaymentsRequestsForPayment::Currency.Usd,
                        DebtorName = "Ian Crease",
                        EndToEndIdentification = "Invoice 29582",
                        ExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
                        FulfillmentRealTimePaymentsTransferID = null,
                        InvoicerIdentification = null,
                        PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
                        RequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Type =
                            InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        List<InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment> expectedData =
        [
            new()
            {
                ID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Creditor = new()
                {
                    AccountName = "National Phonograph Company",
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
                    Name = "National Phonograph Company",
                },
                CreditorAccountNumber = "987654321",
                CreditorRoutingNumber = "101050001",
                Currency = InboundRealTimePaymentsRequestsForPayment::Currency.Usd,
                DebtorName = "Ian Crease",
                EndToEndIdentification = "Invoice 29582",
                ExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
                FulfillmentRealTimePaymentsTransferID = null,
                InvoicerIdentification = null,
                PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
                RequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Type =
                    InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment,
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
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Creditor = new()
                        {
                            AccountName = "National Phonograph Company",
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
                            Name = "National Phonograph Company",
                        },
                        CreditorAccountNumber = "987654321",
                        CreditorRoutingNumber = "101050001",
                        Currency = InboundRealTimePaymentsRequestsForPayment::Currency.Usd,
                        DebtorName = "Ian Crease",
                        EndToEndIdentification = "Invoice 29582",
                        ExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
                        FulfillmentRealTimePaymentsTransferID = null,
                        InvoicerIdentification = null,
                        PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
                        RequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Type =
                            InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestsForPaymentListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Creditor = new()
                        {
                            AccountName = "National Phonograph Company",
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
                            Name = "National Phonograph Company",
                        },
                        CreditorAccountNumber = "987654321",
                        CreditorRoutingNumber = "101050001",
                        Currency = InboundRealTimePaymentsRequestsForPayment::Currency.Usd,
                        DebtorName = "Ian Crease",
                        EndToEndIdentification = "Invoice 29582",
                        ExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
                        FulfillmentRealTimePaymentsTransferID = null,
                        InvoicerIdentification = null,
                        PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
                        RequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Type =
                            InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestsForPaymentListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment> expectedData =
        [
            new()
            {
                ID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Creditor = new()
                {
                    AccountName = "National Phonograph Company",
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
                    Name = "National Phonograph Company",
                },
                CreditorAccountNumber = "987654321",
                CreditorRoutingNumber = "101050001",
                Currency = InboundRealTimePaymentsRequestsForPayment::Currency.Usd,
                DebtorName = "Ian Crease",
                EndToEndIdentification = "Invoice 29582",
                ExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
                FulfillmentRealTimePaymentsTransferID = null,
                InvoicerIdentification = null,
                PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
                RequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Type =
                    InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment,
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
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Creditor = new()
                        {
                            AccountName = "National Phonograph Company",
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
                            Name = "National Phonograph Company",
                        },
                        CreditorAccountNumber = "987654321",
                        CreditorRoutingNumber = "101050001",
                        Currency = InboundRealTimePaymentsRequestsForPayment::Currency.Usd,
                        DebtorName = "Ian Crease",
                        EndToEndIdentification = "Invoice 29582",
                        ExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
                        FulfillmentRealTimePaymentsTransferID = null,
                        InvoicerIdentification = null,
                        PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
                        RequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Type =
                            InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment,
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
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestsForPaymentListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Creditor = new()
                        {
                            AccountName = "National Phonograph Company",
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
                            Name = "National Phonograph Company",
                        },
                        CreditorAccountNumber = "987654321",
                        CreditorRoutingNumber = "101050001",
                        Currency = InboundRealTimePaymentsRequestsForPayment::Currency.Usd,
                        DebtorName = "Ian Crease",
                        EndToEndIdentification = "Invoice 29582",
                        ExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
                        FulfillmentRealTimePaymentsTransferID = null,
                        InvoicerIdentification = null,
                        PaymentInformationIdentification = "20220501234567891T1BSLZO01745013025",
                        RequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Type =
                            InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestsForPaymentListPageResponse copied =
            new(model);

        Assert.Equal(model, copied);
    }
}
