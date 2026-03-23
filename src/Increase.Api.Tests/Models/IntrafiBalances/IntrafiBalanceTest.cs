using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.IntrafiBalances;

namespace Increase.Api.Tests.Models.IntrafiBalances;

public class IntrafiBalanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntrafiBalance
        {
            Balances =
            [
                new()
                {
                    BalanceValue = 1750,
                    Bank = "Example Bank",
                    BankLocation = new() { City = "New York", State = "NY" },
                    FdicCertificateNumber = "314159",
                },
            ],
            Currency = Currency.Usd,
            EffectiveDate = "2020-01-31",
            TotalBalance = 1750,
            Type = Type.IntrafiBalance,
        };

        List<Balance> expectedBalances =
        [
            new()
            {
                BalanceValue = 1750,
                Bank = "Example Bank",
                BankLocation = new() { City = "New York", State = "NY" },
                FdicCertificateNumber = "314159",
            },
        ];
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;
        string expectedEffectiveDate = "2020-01-31";
        long expectedTotalBalance = 1750;
        ApiEnum<string, Type> expectedType = Type.IntrafiBalance;

        Assert.Equal(expectedBalances.Count, model.Balances.Count);
        for (int i = 0; i < expectedBalances.Count; i++)
        {
            Assert.Equal(expectedBalances[i], model.Balances[i]);
        }
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedTotalBalance, model.TotalBalance);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntrafiBalance
        {
            Balances =
            [
                new()
                {
                    BalanceValue = 1750,
                    Bank = "Example Bank",
                    BankLocation = new() { City = "New York", State = "NY" },
                    FdicCertificateNumber = "314159",
                },
            ],
            Currency = Currency.Usd,
            EffectiveDate = "2020-01-31",
            TotalBalance = 1750,
            Type = Type.IntrafiBalance,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntrafiBalance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntrafiBalance
        {
            Balances =
            [
                new()
                {
                    BalanceValue = 1750,
                    Bank = "Example Bank",
                    BankLocation = new() { City = "New York", State = "NY" },
                    FdicCertificateNumber = "314159",
                },
            ],
            Currency = Currency.Usd,
            EffectiveDate = "2020-01-31",
            TotalBalance = 1750,
            Type = Type.IntrafiBalance,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntrafiBalance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Balance> expectedBalances =
        [
            new()
            {
                BalanceValue = 1750,
                Bank = "Example Bank",
                BankLocation = new() { City = "New York", State = "NY" },
                FdicCertificateNumber = "314159",
            },
        ];
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;
        string expectedEffectiveDate = "2020-01-31";
        long expectedTotalBalance = 1750;
        ApiEnum<string, Type> expectedType = Type.IntrafiBalance;

        Assert.Equal(expectedBalances.Count, deserialized.Balances.Count);
        for (int i = 0; i < expectedBalances.Count; i++)
        {
            Assert.Equal(expectedBalances[i], deserialized.Balances[i]);
        }
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedTotalBalance, deserialized.TotalBalance);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntrafiBalance
        {
            Balances =
            [
                new()
                {
                    BalanceValue = 1750,
                    Bank = "Example Bank",
                    BankLocation = new() { City = "New York", State = "NY" },
                    FdicCertificateNumber = "314159",
                },
            ],
            Currency = Currency.Usd,
            EffectiveDate = "2020-01-31",
            TotalBalance = 1750,
            Type = Type.IntrafiBalance,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntrafiBalance
        {
            Balances =
            [
                new()
                {
                    BalanceValue = 1750,
                    Bank = "Example Bank",
                    BankLocation = new() { City = "New York", State = "NY" },
                    FdicCertificateNumber = "314159",
                },
            ],
            Currency = Currency.Usd,
            EffectiveDate = "2020-01-31",
            TotalBalance = 1750,
            Type = Type.IntrafiBalance,
        };

        IntrafiBalance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BalanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Balance
        {
            BalanceValue = 0,
            Bank = "bank",
            BankLocation = new() { City = "city", State = "state" },
            FdicCertificateNumber = "fdic_certificate_number",
        };

        long expectedBalanceValue = 0;
        string expectedBank = "bank";
        BankLocation expectedBankLocation = new() { City = "city", State = "state" };
        string expectedFdicCertificateNumber = "fdic_certificate_number";

        Assert.Equal(expectedBalanceValue, model.BalanceValue);
        Assert.Equal(expectedBank, model.Bank);
        Assert.Equal(expectedBankLocation, model.BankLocation);
        Assert.Equal(expectedFdicCertificateNumber, model.FdicCertificateNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Balance
        {
            BalanceValue = 0,
            Bank = "bank",
            BankLocation = new() { City = "city", State = "state" },
            FdicCertificateNumber = "fdic_certificate_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Balance>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Balance
        {
            BalanceValue = 0,
            Bank = "bank",
            BankLocation = new() { City = "city", State = "state" },
            FdicCertificateNumber = "fdic_certificate_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Balance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBalanceValue = 0;
        string expectedBank = "bank";
        BankLocation expectedBankLocation = new() { City = "city", State = "state" };
        string expectedFdicCertificateNumber = "fdic_certificate_number";

        Assert.Equal(expectedBalanceValue, deserialized.BalanceValue);
        Assert.Equal(expectedBank, deserialized.Bank);
        Assert.Equal(expectedBankLocation, deserialized.BankLocation);
        Assert.Equal(expectedFdicCertificateNumber, deserialized.FdicCertificateNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Balance
        {
            BalanceValue = 0,
            Bank = "bank",
            BankLocation = new() { City = "city", State = "state" },
            FdicCertificateNumber = "fdic_certificate_number",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Balance
        {
            BalanceValue = 0,
            Bank = "bank",
            BankLocation = new() { City = "city", State = "state" },
            FdicCertificateNumber = "fdic_certificate_number",
        };

        Balance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BankLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BankLocation { City = "city", State = "state" };

        string expectedCity = "city";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BankLocation { City = "city", State = "state" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BankLocation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BankLocation { City = "city", State = "state" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BankLocation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BankLocation { City = "city", State = "state" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BankLocation { City = "city", State = "state" };

        BankLocation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Currency.Usd)]
    public void Validation_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Currency.Usd)]
    public void SerializationRoundtrip_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.IntrafiBalance)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.IntrafiBalance)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
