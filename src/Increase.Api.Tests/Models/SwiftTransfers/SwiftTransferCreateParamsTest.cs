using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.SwiftTransfers;

namespace Increase.Api.Tests.Models.SwiftTransfers;

public class SwiftTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SwiftTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            BankIdentificationCode = "ECBFDEFFTPP",
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = "line2",
                PostalCode = "60314",
                State = "state",
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "line2",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "National Phonograph Company",
            InstructedAmount = 100,
            InstructedCurrency = InstructedCurrency.Usd,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "New Swift transfer",
            RequireApproval = true,
            RoutingNumber = "sq",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        string expectedBankIdentificationCode = "ECBFDEFFTPP";
        CreditorAddress expectedCreditorAddress = new()
        {
            City = "Frankfurt",
            Country = "DE",
            Line1 = "Sonnemannstrasse 20",
            Line2 = "line2",
            PostalCode = "60314",
            State = "state",
        };
        string expectedCreditorName = "Ian Crease";
        DebtorAddress expectedDebtorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = "line2",
            PostalCode = "10045",
            State = "NY",
        };
        string expectedDebtorName = "National Phonograph Company";
        long expectedInstructedAmount = 100;
        ApiEnum<string, InstructedCurrency> expectedInstructedCurrency = InstructedCurrency.Usd;
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedUnstructuredRemittanceInformation = "New Swift transfer";
        bool expectedRequireApproval = true;
        string expectedRoutingNumber = "sq";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedBankIdentificationCode, parameters.BankIdentificationCode);
        Assert.Equal(expectedCreditorAddress, parameters.CreditorAddress);
        Assert.Equal(expectedCreditorName, parameters.CreditorName);
        Assert.Equal(expectedDebtorAddress, parameters.DebtorAddress);
        Assert.Equal(expectedDebtorName, parameters.DebtorName);
        Assert.Equal(expectedInstructedAmount, parameters.InstructedAmount);
        Assert.Equal(expectedInstructedCurrency, parameters.InstructedCurrency);
        Assert.Equal(expectedSourceAccountNumberID, parameters.SourceAccountNumberID);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
        Assert.Equal(expectedRequireApproval, parameters.RequireApproval);
        Assert.Equal(expectedRoutingNumber, parameters.RoutingNumber);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SwiftTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            BankIdentificationCode = "ECBFDEFFTPP",
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = "line2",
                PostalCode = "60314",
                State = "state",
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "line2",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "National Phonograph Company",
            InstructedAmount = 100,
            InstructedCurrency = InstructedCurrency.Usd,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "New Swift transfer",
        };

        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SwiftTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            BankIdentificationCode = "ECBFDEFFTPP",
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = "line2",
                PostalCode = "60314",
                State = "state",
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "line2",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "National Phonograph Company",
            InstructedAmount = 100,
            InstructedCurrency = InstructedCurrency.Usd,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "New Swift transfer",

            // Null should be interpreted as omitted for these properties
            RequireApproval = null,
            RoutingNumber = null,
        };

        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
    }

    [Fact]
    public void Url_Works()
    {
        SwiftTransferCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            BankIdentificationCode = "ECBFDEFFTPP",
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = "line2",
                PostalCode = "60314",
                State = "state",
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "line2",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "National Phonograph Company",
            InstructedAmount = 100,
            InstructedCurrency = InstructedCurrency.Usd,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "New Swift transfer",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/swift_transfers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SwiftTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            BankIdentificationCode = "ECBFDEFFTPP",
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = "line2",
                PostalCode = "60314",
                State = "state",
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = "line2",
                PostalCode = "10045",
                State = "NY",
            },
            DebtorName = "National Phonograph Company",
            InstructedAmount = 100,
            InstructedCurrency = InstructedCurrency.Usd,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "New Swift transfer",
            RequireApproval = true,
            RoutingNumber = "sq",
        };

        SwiftTransferCreateParams copied = new(parameters);

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
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "xx";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = ")(";
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
        var model = new CreditorAddress
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
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
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "xx";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = ")(";
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
        var model = new CreditorAddress
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditorAddress
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
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
            City = "city",
            Country = "xx",
            Line1 = "line1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreditorAddress
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",

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
            City = "city",
            Country = "xx",
            Line1 = "line1",

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
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
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
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "xx";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = ")(";
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
        var model = new DebtorAddress
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
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
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "xx";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = ")(";
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
        var model = new DebtorAddress
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",
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
            City = "city",
            Country = "xx",
            Line1 = "line1",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "xx",
            Line1 = "line1",

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
            City = "city",
            Country = "xx",
            Line1 = "line1",

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
            City = "city",
            Country = "xx",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = ")(",
            State = "state",
        };

        DebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InstructedCurrencyTest : TestBase
{
    [Theory]
    [InlineData(InstructedCurrency.Usd)]
    public void Validation_Works(InstructedCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InstructedCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InstructedCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InstructedCurrency.Usd)]
    public void SerializationRoundtrip_Works(InstructedCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InstructedCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InstructedCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InstructedCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InstructedCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
