using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.WireDrawdownRequests;

namespace Increase.Api.Tests.Models.WireDrawdownRequests;

public class WireDrawdownRequestCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WireDrawdownRequestCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 10000,
            CreditorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "National Phonograph Company",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "Ian Crease",
            UnstructuredRemittanceInformation = "Invoice 29582",
            ChargeBearer = ChargeBearer.Shared,
            DebtorAccountNumber = "987654321",
            DebtorExternalAccountID = "debtor_external_account_id",
            DebtorRoutingNumber = "101050001",
            EndToEndIdentification = "x",
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 10000;
        CreditorAddress expectedCreditorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = "x",
            PostalCode = "10045",
            State = "NY",
        };
        string expectedCreditorName = "National Phonograph Company";
        DebtorAddress expectedDebtorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = "x",
            PostalCode = "10045",
            State = "NY",
        };
        string expectedDebtorName = "Ian Crease";
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";
        ApiEnum<string, ChargeBearer> expectedChargeBearer = ChargeBearer.Shared;
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorExternalAccountID = "debtor_external_account_id";
        string expectedDebtorRoutingNumber = "101050001";
        string expectedEndToEndIdentification = "x";

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCreditorAddress, parameters.CreditorAddress);
        Assert.Equal(expectedCreditorName, parameters.CreditorName);
        Assert.Equal(expectedDebtorAddress, parameters.DebtorAddress);
        Assert.Equal(expectedDebtorName, parameters.DebtorName);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
        Assert.Equal(expectedChargeBearer, parameters.ChargeBearer);
        Assert.Equal(expectedDebtorAccountNumber, parameters.DebtorAccountNumber);
        Assert.Equal(expectedDebtorExternalAccountID, parameters.DebtorExternalAccountID);
        Assert.Equal(expectedDebtorRoutingNumber, parameters.DebtorRoutingNumber);
        Assert.Equal(expectedEndToEndIdentification, parameters.EndToEndIdentification);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WireDrawdownRequestCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 10000,
            CreditorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "National Phonograph Company",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "Ian Crease",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        Assert.Null(parameters.ChargeBearer);
        Assert.False(parameters.RawBodyData.ContainsKey("charge_bearer"));
        Assert.Null(parameters.DebtorAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_account_number"));
        Assert.Null(parameters.DebtorExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_external_account_id"));
        Assert.Null(parameters.DebtorRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_routing_number"));
        Assert.Null(parameters.EndToEndIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("end_to_end_identification"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new WireDrawdownRequestCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 10000,
            CreditorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "National Phonograph Company",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "Ian Crease",
            UnstructuredRemittanceInformation = "Invoice 29582",

            // Null should be interpreted as omitted for these properties
            ChargeBearer = null,
            DebtorAccountNumber = null,
            DebtorExternalAccountID = null,
            DebtorRoutingNumber = null,
            EndToEndIdentification = null,
        };

        Assert.Null(parameters.ChargeBearer);
        Assert.False(parameters.RawBodyData.ContainsKey("charge_bearer"));
        Assert.Null(parameters.DebtorAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_account_number"));
        Assert.Null(parameters.DebtorExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_external_account_id"));
        Assert.Null(parameters.DebtorRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_routing_number"));
        Assert.Null(parameters.EndToEndIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("end_to_end_identification"));
    }

    [Fact]
    public void Url_Works()
    {
        WireDrawdownRequestCreateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 10000,
            CreditorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "National Phonograph Company",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "Ian Crease",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/wire_drawdown_requests"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WireDrawdownRequestCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 10000,
            CreditorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            CreditorName = "National Phonograph Company",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "x",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "Ian Crease",
            UnstructuredRemittanceInformation = "Invoice 29582",
            ChargeBearer = ChargeBearer.Shared,
            DebtorAccountNumber = "987654321",
            DebtorExternalAccountID = "debtor_external_account_id",
            DebtorRoutingNumber = "101050001",
            EndToEndIdentification = "x",
        };

        WireDrawdownRequestCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CreditorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        string expectedCity = "x";
        string expectedCountry = "x";
        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";

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
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedCountry = "x";
        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";

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
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
        };

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
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            PostalCode = null,
            State = null,
        };

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
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        CreditorAddress copied = new(model);

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
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        string expectedCity = "x";
        string expectedCountry = "x";
        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";

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
        var model = new DebtorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
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
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedCountry = "x";
        string expectedLine1 = "x";
        string expectedLine2 = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";

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
        var model = new DebtorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
        };

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
        var model = new DebtorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            PostalCode = null,
            State = null,
        };

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
        var model = new DebtorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            Country = "x",
            Line1 = "x",
            Line2 = "x",
            PostalCode = "x",
            State = "x",
        };

        DebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeBearerTest : TestBase
{
    [Theory]
    [InlineData(ChargeBearer.Shared)]
    [InlineData(ChargeBearer.Debtor)]
    [InlineData(ChargeBearer.Creditor)]
    [InlineData(ChargeBearer.ServiceLevel)]
    public void Validation_Works(ChargeBearer rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeBearer> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeBearer>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeBearer.Shared)]
    [InlineData(ChargeBearer.Debtor)]
    [InlineData(ChargeBearer.Creditor)]
    [InlineData(ChargeBearer.ServiceLevel)]
    public void SerializationRoundtrip_Works(ChargeBearer rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeBearer> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeBearer>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeBearer>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeBearer>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
