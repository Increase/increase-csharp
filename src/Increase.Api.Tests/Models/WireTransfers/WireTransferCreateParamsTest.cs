using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.WireTransfers;

namespace Increase.Api.Tests.Models.WireTransfers;

public class WireTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WireTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Creditor = new()
            {
                Name = "Ian Crease",
                Address = new()
                {
                    Structured = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = "line2",
                        PostalCode = "10045",
                        State = "NY",
                    },
                },
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "483310694",
                    TypeCode = "1I5r3",
                },
                Unstructured = new("New account transfer"),
            },
            AccountNumber = "987654321",
            Debtor = new()
            {
                Name = "name",
                Address = new()
                {
                    Structured = new()
                    {
                        City = "city",
                        Country = "xx",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postal_code",
                        State = "state",
                    },
                },
            },
            ExternalAccountID = "external_account_id",
            InboundWireDrawdownRequestID = "inbound_wire_drawdown_request_id",
            RequireApproval = true,
            RoutingNumber = "101050001",
            SourceAccountNumberID = "source_account_number_id",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 100;
        Creditor expectedCreditor = new()
        {
            Name = "Ian Crease",
            Address = new()
            {
                Structured = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = "line2",
                    PostalCode = "10045",
                    State = "NY",
                },
            },
        };
        Remittance expectedRemittance = new()
        {
            Category = Category.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "483310694",
                TypeCode = "1I5r3",
            },
            Unstructured = new("New account transfer"),
        };
        string expectedAccountNumber = "987654321";
        Debtor expectedDebtor = new()
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };
        string expectedExternalAccountID = "external_account_id";
        string expectedInboundWireDrawdownRequestID = "inbound_wire_drawdown_request_id";
        bool expectedRequireApproval = true;
        string expectedRoutingNumber = "101050001";
        string expectedSourceAccountNumberID = "source_account_number_id";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCreditor, parameters.Creditor);
        Assert.Equal(expectedRemittance, parameters.Remittance);
        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedDebtor, parameters.Debtor);
        Assert.Equal(expectedExternalAccountID, parameters.ExternalAccountID);
        Assert.Equal(expectedInboundWireDrawdownRequestID, parameters.InboundWireDrawdownRequestID);
        Assert.Equal(expectedRequireApproval, parameters.RequireApproval);
        Assert.Equal(expectedRoutingNumber, parameters.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, parameters.SourceAccountNumberID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WireTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Creditor = new()
            {
                Name = "Ian Crease",
                Address = new()
                {
                    Structured = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = "line2",
                        PostalCode = "10045",
                        State = "NY",
                    },
                },
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "483310694",
                    TypeCode = "1I5r3",
                },
                Unstructured = new("New account transfer"),
            },
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.Debtor);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
        Assert.Null(parameters.InboundWireDrawdownRequestID);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_wire_drawdown_request_id"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
        Assert.Null(parameters.SourceAccountNumberID);
        Assert.False(parameters.RawBodyData.ContainsKey("source_account_number_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WireTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Creditor = new()
            {
                Name = "Ian Crease",
                Address = new()
                {
                    Structured = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = "line2",
                        PostalCode = "10045",
                        State = "NY",
                    },
                },
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "483310694",
                    TypeCode = "1I5r3",
                },
                Unstructured = new("New account transfer"),
            },

            // Null should be interpreted as omitted for these properties
            AccountNumber = null,
            Debtor = null,
            ExternalAccountID = null,
            InboundWireDrawdownRequestID = null,
            RequireApproval = null,
            RoutingNumber = null,
            SourceAccountNumberID = null,
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.Debtor);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
        Assert.Null(parameters.InboundWireDrawdownRequestID);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_wire_drawdown_request_id"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
        Assert.Null(parameters.SourceAccountNumberID);
        Assert.False(parameters.RawBodyData.ContainsKey("source_account_number_id"));
    }

    [Fact]
    public void Url_Works()
    {
        WireTransferCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Creditor = new()
            {
                Name = "Ian Crease",
                Address = new()
                {
                    Structured = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = "line2",
                        PostalCode = "10045",
                        State = "NY",
                    },
                },
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "483310694",
                    TypeCode = "1I5r3",
                },
                Unstructured = new("New account transfer"),
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/wire_transfers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WireTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Creditor = new()
            {
                Name = "Ian Crease",
                Address = new()
                {
                    Structured = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = "line2",
                        PostalCode = "10045",
                        State = "NY",
                    },
                },
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "483310694",
                    TypeCode = "1I5r3",
                },
                Unstructured = new("New account transfer"),
            },
            AccountNumber = "987654321",
            Debtor = new()
            {
                Name = "name",
                Address = new()
                {
                    Structured = new()
                    {
                        City = "city",
                        Country = "xx",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postal_code",
                        State = "state",
                    },
                },
            },
            ExternalAccountID = "external_account_id",
            InboundWireDrawdownRequestID = "inbound_wire_drawdown_request_id",
            RequireApproval = true,
            RoutingNumber = "101050001",
            SourceAccountNumberID = "source_account_number_id",
        };

        WireTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CreditorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Creditor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        string expectedName = "name";
        Address expectedAddress = new()
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Creditor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Creditor>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Creditor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Creditor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        Address expectedAddress = new()
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Creditor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Creditor { Name = "name" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Creditor { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Creditor
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Address = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Creditor
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Address = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Creditor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        Creditor copied = new(model);

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
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        Structured expectedStructured = new()
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        Assert.Equal(expectedStructured, model.Structured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Address
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
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
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Structured expectedStructured = new()
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        Assert.Equal(expectedStructured, deserialized.Structured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Address
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Address { };

        Assert.Null(model.Structured);
        Assert.False(model.RawData.ContainsKey("structured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Address { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Address
        {
            // Null should be interpreted as omitted for these properties
            Structured = null,
        };

        Assert.Null(model.Structured);
        Assert.False(model.RawData.ContainsKey("structured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Address
        {
            // Null should be interpreted as omitted for these properties
            Structured = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Address
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        Address copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Structured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "xx";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Structured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Structured>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Structured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Structured>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "xx";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Structured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Structured { City = "city", Country = "xx" };

        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Structured { City = "city", Country = "xx" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Structured
        {
            City = "city",
            Country = "xx",

            // Null should be interpreted as omitted for these properties
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Structured
        {
            City = "city",
            Country = "xx",

            // Null should be interpreted as omitted for these properties
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Structured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        Structured copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RemittanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Remittance
        {
            Category = Category.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "483310694",
                TypeCode = "1I5r3",
            },
            Unstructured = new("message"),
        };

        ApiEnum<string, Category> expectedCategory = Category.Unstructured;
        Tax expectedTax = new()
        {
            Date = "2019-12-27",
            IdentificationNumber = "483310694",
            TypeCode = "1I5r3",
        };
        Unstructured expectedUnstructured = new("message");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedUnstructured, model.Unstructured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Remittance
        {
            Category = Category.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "483310694",
                TypeCode = "1I5r3",
            },
            Unstructured = new("message"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Remittance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Remittance
        {
            Category = Category.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "483310694",
                TypeCode = "1I5r3",
            },
            Unstructured = new("message"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Remittance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Category> expectedCategory = Category.Unstructured;
        Tax expectedTax = new()
        {
            Date = "2019-12-27",
            IdentificationNumber = "483310694",
            TypeCode = "1I5r3",
        };
        Unstructured expectedUnstructured = new("message");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedUnstructured, deserialized.Unstructured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Remittance
        {
            Category = Category.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "483310694",
                TypeCode = "1I5r3",
            },
            Unstructured = new("message"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Remittance { Category = Category.Unstructured };

        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
        Assert.Null(model.Unstructured);
        Assert.False(model.RawData.ContainsKey("unstructured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Remittance { Category = Category.Unstructured };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Remittance
        {
            Category = Category.Unstructured,

            // Null should be interpreted as omitted for these properties
            Tax = null,
            Unstructured = null,
        };

        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
        Assert.Null(model.Unstructured);
        Assert.False(model.RawData.ContainsKey("unstructured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Remittance
        {
            Category = Category.Unstructured,

            // Null should be interpreted as omitted for these properties
            Tax = null,
            Unstructured = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Remittance
        {
            Category = Category.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "483310694",
                TypeCode = "1I5r3",
            },
            Unstructured = new("message"),
        };

        Remittance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Unstructured)]
    [InlineData(Category.Tax)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Unstructured)]
    [InlineData(Category.Tax)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TaxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Tax
        {
            Date = "2019-12-27",
            IdentificationNumber = "483310694",
            TypeCode = "1I5r3",
        };

        string expectedDate = "2019-12-27";
        string expectedIdentificationNumber = "483310694";
        string expectedTypeCode = "1I5r3";

        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedIdentificationNumber, model.IdentificationNumber);
        Assert.Equal(expectedTypeCode, model.TypeCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Tax
        {
            Date = "2019-12-27",
            IdentificationNumber = "483310694",
            TypeCode = "1I5r3",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tax>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Tax
        {
            Date = "2019-12-27",
            IdentificationNumber = "483310694",
            TypeCode = "1I5r3",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tax>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDate = "2019-12-27";
        string expectedIdentificationNumber = "483310694";
        string expectedTypeCode = "1I5r3";

        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedIdentificationNumber, deserialized.IdentificationNumber);
        Assert.Equal(expectedTypeCode, deserialized.TypeCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Tax
        {
            Date = "2019-12-27",
            IdentificationNumber = "483310694",
            TypeCode = "1I5r3",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tax
        {
            Date = "2019-12-27",
            IdentificationNumber = "483310694",
            TypeCode = "1I5r3",
        };

        Tax copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnstructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Unstructured { Message = "message" };

        string expectedMessage = "message";

        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Unstructured { Message = "message" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Unstructured>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Unstructured { Message = "message" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Unstructured>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";

        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Unstructured { Message = "message" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Unstructured { Message = "message" };

        Unstructured copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DebtorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Debtor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        string expectedName = "name";
        DebtorAddress expectedAddress = new()
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Debtor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
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
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Debtor>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        DebtorAddress expectedAddress = new()
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Debtor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Debtor { Name = "name" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Debtor { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Debtor
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Address = null,
        };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Debtor
        {
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Address = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Debtor
        {
            Name = "name",
            Address = new()
            {
                Structured = new()
                {
                    City = "city",
                    Country = "xx",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postal_code",
                    State = "state",
                },
            },
        };

        Debtor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DebtorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DebtorAddress
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        DebtorAddressStructured expectedStructured = new()
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        Assert.Equal(expectedStructured, model.Structured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DebtorAddress
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DebtorAddress
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DebtorAddressStructured expectedStructured = new()
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        Assert.Equal(expectedStructured, deserialized.Structured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DebtorAddress
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DebtorAddress { };

        Assert.Null(model.Structured);
        Assert.False(model.RawData.ContainsKey("structured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DebtorAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            // Null should be interpreted as omitted for these properties
            Structured = null,
        };

        Assert.Null(model.Structured);
        Assert.False(model.RawData.ContainsKey("structured"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DebtorAddress
        {
            // Null should be interpreted as omitted for these properties
            Structured = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DebtorAddress
        {
            Structured = new()
            {
                City = "city",
                Country = "xx",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postal_code",
                State = "state",
            },
        };

        DebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DebtorAddressStructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DebtorAddressStructured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "xx";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DebtorAddressStructured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddressStructured>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DebtorAddressStructured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddressStructured>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "xx";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DebtorAddressStructured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DebtorAddressStructured { City = "city", Country = "xx" };

        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DebtorAddressStructured { City = "city", Country = "xx" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DebtorAddressStructured
        {
            City = "city",
            Country = "xx",

            // Null should be interpreted as omitted for these properties
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postal_code"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DebtorAddressStructured
        {
            City = "city",
            Country = "xx",

            // Null should be interpreted as omitted for these properties
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DebtorAddressStructured
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        DebtorAddressStructured copied = new(model);

        Assert.Equal(model, copied);
    }
}
