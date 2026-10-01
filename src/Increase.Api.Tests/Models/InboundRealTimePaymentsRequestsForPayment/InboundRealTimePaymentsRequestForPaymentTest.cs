using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundRealTimePaymentsRequestsForPayment = Increase.Api.Models.InboundRealTimePaymentsRequestsForPayment;

namespace Increase.Api.Tests.Models.InboundRealTimePaymentsRequestsForPayment;

public class InboundRealTimePaymentsRequestForPaymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment
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
            };

        string expectedID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        InboundRealTimePaymentsRequestsForPayment::Creditor expectedCreditor = new()
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
        };
        string expectedCreditorAccountNumber = "987654321";
        string expectedCreditorRoutingNumber = "101050001";
        ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Currency> expectedCurrency =
            InboundRealTimePaymentsRequestsForPayment::Currency.Usd;
        string expectedDebtorName = "Ian Crease";
        string expectedEndToEndIdentification = "Invoice 29582";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z");
        string expectedPaymentInformationIdentification = "20220501234567891T1BSLZO01745013025";
        DateTimeOffset expectedRequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Type> expectedType =
            InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditor, model.Creditor);
        Assert.Equal(expectedCreditorAccountNumber, model.CreditorAccountNumber);
        Assert.Equal(expectedCreditorRoutingNumber, model.CreditorRoutingNumber);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Equal(expectedEndToEndIdentification, model.EndToEndIdentification);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Null(model.FulfillmentRealTimePaymentsTransferID);
        Assert.Null(model.InvoicerIdentification);
        Assert.Equal(
            expectedPaymentInformationIdentification,
            model.PaymentInformationIdentification
        );
        Assert.Equal(expectedRequestedExecutionAt, model.RequestedExecutionAt);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment
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
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment
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
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "inbound_real_time_payments_request_for_payment_j9c5rm4hr6qf34en8tky";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        InboundRealTimePaymentsRequestsForPayment::Creditor expectedCreditor = new()
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
        };
        string expectedCreditorAccountNumber = "987654321";
        string expectedCreditorRoutingNumber = "101050001";
        ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Currency> expectedCurrency =
            InboundRealTimePaymentsRequestsForPayment::Currency.Usd;
        string expectedDebtorName = "Ian Crease";
        string expectedEndToEndIdentification = "Invoice 29582";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z");
        string expectedPaymentInformationIdentification = "20220501234567891T1BSLZO01745013025";
        DateTimeOffset expectedRequestedExecutionAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Type> expectedType =
            InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditor, deserialized.Creditor);
        Assert.Equal(expectedCreditorAccountNumber, deserialized.CreditorAccountNumber);
        Assert.Equal(expectedCreditorRoutingNumber, deserialized.CreditorRoutingNumber);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Equal(expectedEndToEndIdentification, deserialized.EndToEndIdentification);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Null(deserialized.FulfillmentRealTimePaymentsTransferID);
        Assert.Null(deserialized.InvoicerIdentification);
        Assert.Equal(
            expectedPaymentInformationIdentification,
            deserialized.PaymentInformationIdentification
        );
        Assert.Equal(expectedRequestedExecutionAt, deserialized.RequestedExecutionAt);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment
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
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment
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
            };

        InboundRealTimePaymentsRequestsForPayment::InboundRealTimePaymentsRequestForPayment copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsRequestsForPayment::Creditor
        {
            AccountName = "account_name",
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

        string expectedAccountName = "account_name";
        InboundRealTimePaymentsRequestsForPayment::Address expectedAddress = new()
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

        Assert.Equal(expectedAccountName, model.AccountName);
        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsRequestsForPayment::Creditor
        {
            AccountName = "account_name",
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
            JsonSerializer.Deserialize<InboundRealTimePaymentsRequestsForPayment::Creditor>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundRealTimePaymentsRequestsForPayment::Creditor
        {
            AccountName = "account_name",
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
            JsonSerializer.Deserialize<InboundRealTimePaymentsRequestsForPayment::Creditor>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAccountName = "account_name";
        InboundRealTimePaymentsRequestsForPayment::Address expectedAddress = new()
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

        Assert.Equal(expectedAccountName, deserialized.AccountName);
        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundRealTimePaymentsRequestsForPayment::Creditor
        {
            AccountName = "account_name",
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
        var model = new InboundRealTimePaymentsRequestsForPayment::Creditor
        {
            AccountName = "account_name",
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

        InboundRealTimePaymentsRequestsForPayment::Creditor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsRequestsForPayment::Address
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
        var model = new InboundRealTimePaymentsRequestsForPayment::Address
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
            JsonSerializer.Deserialize<InboundRealTimePaymentsRequestsForPayment::Address>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundRealTimePaymentsRequestsForPayment::Address
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
            JsonSerializer.Deserialize<InboundRealTimePaymentsRequestsForPayment::Address>(
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
        var model = new InboundRealTimePaymentsRequestsForPayment::Address
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
        var model = new InboundRealTimePaymentsRequestsForPayment::Address
        {
            AddressLine2 = "address_line2",
            BuildingNumber = "building_number",
            City = "city",
            Country = "country",
            PostalCode = "postal_code",
            State = "state",
            StreetName = "street_name",
        };

        InboundRealTimePaymentsRequestsForPayment::Address copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(InboundRealTimePaymentsRequestsForPayment::Currency.Usd)]
    public void Validation_Works(InboundRealTimePaymentsRequestsForPayment::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Currency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundRealTimePaymentsRequestsForPayment::Currency.Usd)]
    public void SerializationRoundtrip_Works(
        InboundRealTimePaymentsRequestsForPayment::Currency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Currency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(
        InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment
    )]
    public void Validation_Works(InboundRealTimePaymentsRequestsForPayment::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        InboundRealTimePaymentsRequestsForPayment::Type.InboundRealTimePaymentsRequestForPayment
    )]
    public void SerializationRoundtrip_Works(
        InboundRealTimePaymentsRequestsForPayment::Type rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsRequestsForPayment::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
