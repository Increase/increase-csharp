using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Programs = Increase.Api.Models.Programs;

namespace Increase.Api.Tests.Models.Programs;

public class ProgramTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Programs::Program
        {
            ID = "program_i2v2os4mwza1oetokh9i",
            Bank = Programs::Bank.FirstInternetBank,
            BillingAccountID = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DefaultDigitalCardProfileID = null,
            InterestRate = "0.01",
            Lending = new(0),
            Name = "Commercial Banking",
            Type = Programs::Type.Program,
            UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string expectedID = "program_i2v2os4mwza1oetokh9i";
        ApiEnum<string, Programs::Bank> expectedBank = Programs::Bank.FirstInternetBank;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedInterestRate = "0.01";
        Programs::Lending expectedLending = new(0);
        string expectedName = "Commercial Banking";
        ApiEnum<string, Programs::Type> expectedType = Programs::Type.Program;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBank, model.Bank);
        Assert.Null(model.BillingAccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.DefaultDigitalCardProfileID);
        Assert.Equal(expectedInterestRate, model.InterestRate);
        Assert.Equal(expectedLending, model.Lending);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Programs::Program
        {
            ID = "program_i2v2os4mwza1oetokh9i",
            Bank = Programs::Bank.FirstInternetBank,
            BillingAccountID = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DefaultDigitalCardProfileID = null,
            InterestRate = "0.01",
            Lending = new(0),
            Name = "Commercial Banking",
            Type = Programs::Type.Program,
            UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Programs::Program>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Programs::Program
        {
            ID = "program_i2v2os4mwza1oetokh9i",
            Bank = Programs::Bank.FirstInternetBank,
            BillingAccountID = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DefaultDigitalCardProfileID = null,
            InterestRate = "0.01",
            Lending = new(0),
            Name = "Commercial Banking",
            Type = Programs::Type.Program,
            UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Programs::Program>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "program_i2v2os4mwza1oetokh9i";
        ApiEnum<string, Programs::Bank> expectedBank = Programs::Bank.FirstInternetBank;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedInterestRate = "0.01";
        Programs::Lending expectedLending = new(0);
        string expectedName = "Commercial Banking";
        ApiEnum<string, Programs::Type> expectedType = Programs::Type.Program;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBank, deserialized.Bank);
        Assert.Null(deserialized.BillingAccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.DefaultDigitalCardProfileID);
        Assert.Equal(expectedInterestRate, deserialized.InterestRate);
        Assert.Equal(expectedLending, deserialized.Lending);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Programs::Program
        {
            ID = "program_i2v2os4mwza1oetokh9i",
            Bank = Programs::Bank.FirstInternetBank,
            BillingAccountID = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DefaultDigitalCardProfileID = null,
            InterestRate = "0.01",
            Lending = new(0),
            Name = "Commercial Banking",
            Type = Programs::Type.Program,
            UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Programs::Program
        {
            ID = "program_i2v2os4mwza1oetokh9i",
            Bank = Programs::Bank.FirstInternetBank,
            BillingAccountID = null,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DefaultDigitalCardProfileID = null,
            InterestRate = "0.01",
            Lending = new(0),
            Name = "Commercial Banking",
            Type = Programs::Type.Program,
            UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
        };

        Programs::Program copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BankTest : TestBase
{
    [Theory]
    [InlineData(Programs::Bank.CoreBank)]
    [InlineData(Programs::Bank.FirstInternetBank)]
    [InlineData(Programs::Bank.GrasshopperBank)]
    public void Validation_Works(Programs::Bank rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Programs::Bank> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Programs::Bank>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Programs::Bank.CoreBank)]
    [InlineData(Programs::Bank.FirstInternetBank)]
    [InlineData(Programs::Bank.GrasshopperBank)]
    public void SerializationRoundtrip_Works(Programs::Bank rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Programs::Bank> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Programs::Bank>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Programs::Bank>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Programs::Bank>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LendingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Programs::Lending { MaximumExtendableCredit = 0 };

        long expectedMaximumExtendableCredit = 0;

        Assert.Equal(expectedMaximumExtendableCredit, model.MaximumExtendableCredit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Programs::Lending { MaximumExtendableCredit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Programs::Lending>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Programs::Lending { MaximumExtendableCredit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Programs::Lending>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMaximumExtendableCredit = 0;

        Assert.Equal(expectedMaximumExtendableCredit, deserialized.MaximumExtendableCredit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Programs::Lending { MaximumExtendableCredit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Programs::Lending { MaximumExtendableCredit = 0 };

        Programs::Lending copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Programs::Type.Program)]
    public void Validation_Works(Programs::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Programs::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Programs::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Programs::Type.Program)]
    public void SerializationRoundtrip_Works(Programs::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Programs::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Programs::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Programs::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Programs::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
