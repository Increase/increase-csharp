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
                Address = new(
                    new Unstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = "New York",
                        Line3 = "NY 10045",
                    }
                ),
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "xxxxxxxxx",
                    TypeCode = "xxxxx",
                },
                Unstructured = new("New account transfer"),
            },
            AccountNumber = "987654321",
            Debtor = new()
            {
                Name = "x",
                Address = new(
                    new DebtorAddressUnstructured()
                    {
                        Line1 = "x",
                        Line2 = "x",
                        Line3 = "x",
                    }
                ),
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
            Address = new(
                new Unstructured()
                {
                    Line1 = "33 Liberty Street",
                    Line2 = "New York",
                    Line3 = "NY 10045",
                }
            ),
        };
        Remittance expectedRemittance = new()
        {
            Category = Category.Unstructured,
            Tax = new()
            {
                Date = "2019-12-27",
                IdentificationNumber = "xxxxxxxxx",
                TypeCode = "xxxxx",
            },
            Unstructured = new("New account transfer"),
        };
        string expectedAccountNumber = "987654321";
        Debtor expectedDebtor = new()
        {
            Name = "x",
            Address = new(
                new DebtorAddressUnstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
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
                Address = new(
                    new Unstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = "New York",
                        Line3 = "NY 10045",
                    }
                ),
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "xxxxxxxxx",
                    TypeCode = "xxxxx",
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
                Address = new(
                    new Unstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = "New York",
                        Line3 = "NY 10045",
                    }
                ),
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "xxxxxxxxx",
                    TypeCode = "xxxxx",
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
                Address = new(
                    new Unstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = "New York",
                        Line3 = "NY 10045",
                    }
                ),
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "xxxxxxxxx",
                    TypeCode = "xxxxx",
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
                Address = new(
                    new Unstructured()
                    {
                        Line1 = "33 Liberty Street",
                        Line2 = "New York",
                        Line3 = "NY 10045",
                    }
                ),
            },
            Remittance = new()
            {
                Category = Category.Unstructured,
                Tax = new()
                {
                    Date = "2019-12-27",
                    IdentificationNumber = "xxxxxxxxx",
                    TypeCode = "xxxxx",
                },
                Unstructured = new("New account transfer"),
            },
            AccountNumber = "987654321",
            Debtor = new()
            {
                Name = "x",
                Address = new(
                    new DebtorAddressUnstructured()
                    {
                        Line1 = "x",
                        Line2 = "x",
                        Line3 = "x",
                    }
                ),
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
            Name = "x",
            Address = new(
                new Unstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
        };

        string expectedName = "x";
        Address expectedAddress = new(
            new Unstructured()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            }
        );

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Creditor
        {
            Name = "x",
            Address = new(
                new Unstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
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
            Name = "x",
            Address = new(
                new Unstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Creditor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        Address expectedAddress = new(
            new Unstructured()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            }
        );

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Creditor
        {
            Name = "x",
            Address = new(
                new Unstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Creditor { Name = "x" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Creditor { Name = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Creditor
        {
            Name = "x",

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
            Name = "x",

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
            Name = "x",
            Address = new(
                new Unstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
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
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            },
        };

        Unstructured expectedUnstructured = new()
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        Assert.Equal(expectedUnstructured, model.Unstructured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Address
        {
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
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
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Unstructured expectedUnstructured = new()
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        Assert.Equal(expectedUnstructured, deserialized.Unstructured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Address
        {
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Address
        {
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            },
        };

        Address copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnstructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Unstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedLine3 = "x";

        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedLine3, model.Line3);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Unstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

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
        var model = new Unstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Unstructured>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedLine3 = "x";

        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedLine3, deserialized.Line3);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Unstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Unstructured { Line1 = "x" };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Line3);
        Assert.False(model.RawData.ContainsKey("line3"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Unstructured { Line1 = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Unstructured
        {
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Line3 = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Line3);
        Assert.False(model.RawData.ContainsKey("line3"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Unstructured
        {
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Line3 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Unstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        Unstructured copied = new(model);

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
                IdentificationNumber = "xxxxxxxxx",
                TypeCode = "xxxxx",
            },
            Unstructured = new("x"),
        };

        ApiEnum<string, Category> expectedCategory = Category.Unstructured;
        Tax expectedTax = new()
        {
            Date = "2019-12-27",
            IdentificationNumber = "xxxxxxxxx",
            TypeCode = "xxxxx",
        };
        RemittanceUnstructured expectedUnstructured = new("x");

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
                IdentificationNumber = "xxxxxxxxx",
                TypeCode = "xxxxx",
            },
            Unstructured = new("x"),
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
                IdentificationNumber = "xxxxxxxxx",
                TypeCode = "xxxxx",
            },
            Unstructured = new("x"),
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
            IdentificationNumber = "xxxxxxxxx",
            TypeCode = "xxxxx",
        };
        RemittanceUnstructured expectedUnstructured = new("x");

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
                IdentificationNumber = "xxxxxxxxx",
                TypeCode = "xxxxx",
            },
            Unstructured = new("x"),
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
                IdentificationNumber = "xxxxxxxxx",
                TypeCode = "xxxxx",
            },
            Unstructured = new("x"),
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
            IdentificationNumber = "xxxxxxxxx",
            TypeCode = "xxxxx",
        };

        string expectedDate = "2019-12-27";
        string expectedIdentificationNumber = "xxxxxxxxx";
        string expectedTypeCode = "xxxxx";

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
            IdentificationNumber = "xxxxxxxxx",
            TypeCode = "xxxxx",
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
            IdentificationNumber = "xxxxxxxxx",
            TypeCode = "xxxxx",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Tax>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDate = "2019-12-27";
        string expectedIdentificationNumber = "xxxxxxxxx";
        string expectedTypeCode = "xxxxx";

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
            IdentificationNumber = "xxxxxxxxx",
            TypeCode = "xxxxx",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Tax
        {
            Date = "2019-12-27",
            IdentificationNumber = "xxxxxxxxx",
            TypeCode = "xxxxx",
        };

        Tax copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RemittanceUnstructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RemittanceUnstructured { Message = "x" };

        string expectedMessage = "x";

        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RemittanceUnstructured { Message = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RemittanceUnstructured>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RemittanceUnstructured { Message = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RemittanceUnstructured>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "x";

        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RemittanceUnstructured { Message = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RemittanceUnstructured { Message = "x" };

        RemittanceUnstructured copied = new(model);

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
            Name = "x",
            Address = new(
                new DebtorAddressUnstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
        };

        string expectedName = "x";
        DebtorAddress expectedAddress = new(
            new DebtorAddressUnstructured()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            }
        );

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedAddress, model.Address);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Debtor
        {
            Name = "x",
            Address = new(
                new DebtorAddressUnstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
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
            Name = "x",
            Address = new(
                new DebtorAddressUnstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Debtor>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedName = "x";
        DebtorAddress expectedAddress = new(
            new DebtorAddressUnstructured()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            }
        );

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedAddress, deserialized.Address);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Debtor
        {
            Name = "x",
            Address = new(
                new DebtorAddressUnstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Debtor { Name = "x" };

        Assert.Null(model.Address);
        Assert.False(model.RawData.ContainsKey("address"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Debtor { Name = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Debtor
        {
            Name = "x",

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
            Name = "x",

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
            Name = "x",
            Address = new(
                new DebtorAddressUnstructured()
                {
                    Line1 = "x",
                    Line2 = "x",
                    Line3 = "x",
                }
            ),
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
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            },
        };

        DebtorAddressUnstructured expectedUnstructured = new()
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        Assert.Equal(expectedUnstructured, model.Unstructured);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DebtorAddress
        {
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
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
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DebtorAddressUnstructured expectedUnstructured = new()
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        Assert.Equal(expectedUnstructured, deserialized.Unstructured);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DebtorAddress
        {
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DebtorAddress
        {
            Unstructured = new()
            {
                Line1 = "x",
                Line2 = "x",
                Line3 = "x",
            },
        };

        DebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DebtorAddressUnstructuredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DebtorAddressUnstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedLine3 = "x";

        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedLine3, model.Line3);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DebtorAddressUnstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddressUnstructured>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DebtorAddressUnstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddressUnstructured>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedLine3 = "x";

        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedLine3, deserialized.Line3);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DebtorAddressUnstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DebtorAddressUnstructured { Line1 = "x" };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Line3);
        Assert.False(model.RawData.ContainsKey("line3"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DebtorAddressUnstructured { Line1 = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DebtorAddressUnstructured
        {
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Line3 = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Line3);
        Assert.False(model.RawData.ContainsKey("line3"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DebtorAddressUnstructured
        {
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Line3 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DebtorAddressUnstructured
        {
            Line1 = "x",
            Line2 = "x",
            Line3 = "x",
        };

        DebtorAddressUnstructured copied = new(model);

        Assert.Equal(model, copied);
    }
}
