using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.RealTimePaymentsRequestsForPayment;

namespace Increase.Api.Tests.Models.RealTimePaymentsRequestsForPayment;

public class RealTimePaymentsRequestsForPaymentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Debtor = new()
            {
                Address = new()
                {
                    Country = "US",
                    AddressLine2 = "x",
                    BuildingNumber = "x",
                    City = "x",
                    PostalCode = "x",
                    State = "xx",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            UnstructuredRemittanceInformation = "Invoice 29582",
            CreditorName = "National Phonograph Company",
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        Debtor expectedDebtor = new()
        {
            Address = new()
            {
                Country = "US",
                AddressLine2 = "x",
                BuildingNumber = "x",
                City = "x",
                PostalCode = "x",
                State = "xx",
                StreetName = "Liberty Street",
            },
            Name = "Ian Crease",
        };
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorRoutingNumber = "101050001";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z");
        DateTimeOffset expectedRequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z");
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";
        string expectedCreditorName = "National Phonograph Company";

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedDebtor, parameters.Debtor);
        Assert.Equal(expectedDebtorAccountNumber, parameters.DebtorAccountNumber);
        Assert.Equal(expectedDebtorRoutingNumber, parameters.DebtorRoutingNumber);
        Assert.Equal(expectedExpiresAt, parameters.ExpiresAt);
        Assert.Equal(expectedRequestedExecutionAt, parameters.RequestedExecutionAt);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
        Assert.Equal(expectedCreditorName, parameters.CreditorName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Debtor = new()
            {
                Address = new()
                {
                    Country = "US",
                    AddressLine2 = "x",
                    BuildingNumber = "x",
                    City = "x",
                    PostalCode = "x",
                    State = "xx",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        Assert.Null(parameters.CreditorName);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Debtor = new()
            {
                Address = new()
                {
                    Country = "US",
                    AddressLine2 = "x",
                    BuildingNumber = "x",
                    City = "x",
                    PostalCode = "x",
                    State = "xx",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            UnstructuredRemittanceInformation = "Invoice 29582",

            // Null should be interpreted as omitted for these properties
            CreditorName = null,
        };

        Assert.Null(parameters.CreditorName);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_name"));
    }

    [Fact]
    public void Url_Works()
    {
        RealTimePaymentsRequestsForPaymentCreateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Debtor = new()
            {
                Address = new()
                {
                    Country = "US",
                    AddressLine2 = "x",
                    BuildingNumber = "x",
                    City = "x",
                    PostalCode = "x",
                    State = "xx",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/real_time_payments_requests_for_payment"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 100,
            Debtor = new()
            {
                Address = new()
                {
                    Country = "US",
                    AddressLine2 = "x",
                    BuildingNumber = "x",
                    City = "x",
                    PostalCode = "x",
                    State = "xx",
                    StreetName = "Liberty Street",
                },
                Name = "Ian Crease",
            },
            DebtorAccountNumber = "987654321",
            DebtorRoutingNumber = "101050001",
            ExpiresAt = DateTimeOffset.Parse("2020-02-14T23:59:59Z"),
            RequestedExecutionAt = DateTimeOffset.Parse("2020-02-07T23:59:59Z"),
            UnstructuredRemittanceInformation = "Invoice 29582",
            CreditorName = "National Phonograph Company",
        };

        RealTimePaymentsRequestsForPaymentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DebtorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Debtor
        {
            Address = new()
            {
                Country = "x",
                AddressLine2 = "x",
                BuildingNumber = "x",
                City = "x",
                PostalCode = "x",
                State = "xx",
                StreetName = "x",
            },
            Name = "name",
        };

        Address expectedAddress = new()
        {
            Country = "x",
            AddressLine2 = "x",
            BuildingNumber = "x",
            City = "x",
            PostalCode = "x",
            State = "xx",
            StreetName = "x",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Debtor
        {
            Address = new()
            {
                Country = "x",
                AddressLine2 = "x",
                BuildingNumber = "x",
                City = "x",
                PostalCode = "x",
                State = "xx",
                StreetName = "x",
            },
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Debtor>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Debtor
        {
            Address = new()
            {
                Country = "x",
                AddressLine2 = "x",
                BuildingNumber = "x",
                City = "x",
                PostalCode = "x",
                State = "xx",
                StreetName = "x",
            },
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Debtor>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Address expectedAddress = new()
        {
            Country = "x",
            AddressLine2 = "x",
            BuildingNumber = "x",
            City = "x",
            PostalCode = "x",
            State = "xx",
            StreetName = "x",
        };
        string expectedName = "name";

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Debtor
        {
            Address = new()
            {
                Country = "x",
                AddressLine2 = "x",
                BuildingNumber = "x",
                City = "x",
                PostalCode = "x",
                State = "xx",
                StreetName = "x",
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Debtor
        {
            Address = new()
            {
                Country = "x",
                AddressLine2 = "x",
                BuildingNumber = "x",
                City = "x",
                PostalCode = "x",
                State = "xx",
                StreetName = "x",
            },
            Name = "name",
        };

        Debtor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Address
        {
            Country = "x",
            AddressLine2 = "x",
            BuildingNumber = "x",
            City = "x",
            PostalCode = "x",
            State = "xx",
            StreetName = "x",
        };

        string expectedCountry = "x";
        string expectedAddressLine2 = "x";
        string expectedBuildingNumber = "x";
        string expectedCity = "x";
        string expectedPostalCode = "x";
        string expectedState = "xx";
        string expectedStreetName = "x";

        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedAddressLine2, model.AddressLine2);
        Assert.Equal(expectedBuildingNumber, model.BuildingNumber);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreetName, model.StreetName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Address
        {
            Country = "x",
            AddressLine2 = "x",
            BuildingNumber = "x",
            City = "x",
            PostalCode = "x",
            State = "xx",
            StreetName = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Address
        {
            Country = "x",
            AddressLine2 = "x",
            BuildingNumber = "x",
            City = "x",
            PostalCode = "x",
            State = "xx",
            StreetName = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountry = "x";
        string expectedAddressLine2 = "x";
        string expectedBuildingNumber = "x";
        string expectedCity = "x";
        string expectedPostalCode = "x";
        string expectedState = "xx";
        string expectedStreetName = "x";

        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedAddressLine2, deserialized.AddressLine2);
        Assert.Equal(expectedBuildingNumber, deserialized.BuildingNumber);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreetName, deserialized.StreetName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Address
        {
            Country = "x",
            AddressLine2 = "x",
            BuildingNumber = "x",
            City = "x",
            PostalCode = "x",
            State = "xx",
            StreetName = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Address { Country = "x" };

        Assert.Null(model.AddressLine2);
        Assert.False(model.RawData.ContainsKey("address_line2"));
        Assert.Null(model.BuildingNumber);
        Assert.False(model.RawData.ContainsKey("building_number"));
        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.StreetName);
        Assert.False(model.RawData.ContainsKey("street_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Address { Country = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Address
        {
            Country = "x",

            // Null should be interpreted as omitted for these properties
            AddressLine2 = null,
            BuildingNumber = null,
            City = null,
            PostalCode = null,
            State = null,
            StreetName = null,
        };

        Assert.Null(model.AddressLine2);
        Assert.False(model.RawData.ContainsKey("address_line2"));
        Assert.Null(model.BuildingNumber);
        Assert.False(model.RawData.ContainsKey("building_number"));
        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
        Assert.Null(model.StreetName);
        Assert.False(model.RawData.ContainsKey("street_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Address
        {
            Country = "x",

            // Null should be interpreted as omitted for these properties
            AddressLine2 = null,
            BuildingNumber = null,
            City = null,
            PostalCode = null,
            State = null,
            StreetName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Address
        {
            Country = "x",
            AddressLine2 = "x",
            BuildingNumber = "x",
            City = "x",
            PostalCode = "x",
            State = "xx",
            StreetName = "x",
        };

        Address copied = new(model);

        Assert.Equal(model, copied);
    }
}
