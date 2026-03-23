using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Accounts;

namespace Increase.Api.Tests.Models.Accounts;

public class BalanceLookupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceLookup
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AvailableBalance = 100,
            CurrentBalance = 100,
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            Type = BalanceLookupType.BalanceLookup,
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAvailableBalance = 100;
        long expectedCurrentBalance = 100;
        BalanceLookupLoan expectedLoan = new()
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };
        ApiEnum<string, BalanceLookupType> expectedType = BalanceLookupType.BalanceLookup;

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAvailableBalance, model.AvailableBalance);
        Assert.Equal(expectedCurrentBalance, model.CurrentBalance);
        Assert.Equal(expectedLoan, model.Loan);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceLookup
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AvailableBalance = 100,
            CurrentBalance = 100,
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            Type = BalanceLookupType.BalanceLookup,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceLookup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceLookup
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AvailableBalance = 100,
            CurrentBalance = 100,
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            Type = BalanceLookupType.BalanceLookup,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceLookup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAvailableBalance = 100;
        long expectedCurrentBalance = 100;
        BalanceLookupLoan expectedLoan = new()
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };
        ApiEnum<string, BalanceLookupType> expectedType = BalanceLookupType.BalanceLookup;

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAvailableBalance, deserialized.AvailableBalance);
        Assert.Equal(expectedCurrentBalance, deserialized.CurrentBalance);
        Assert.Equal(expectedLoan, deserialized.Loan);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceLookup
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AvailableBalance = 100,
            CurrentBalance = 100,
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            Type = BalanceLookupType.BalanceLookup,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceLookup
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AvailableBalance = 100,
            CurrentBalance = 100,
            Loan = new()
            {
                DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DueBalance = 0,
                PastDueBalance = 0,
            },
            Type = BalanceLookupType.BalanceLookup,
        };

        BalanceLookup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BalanceLookupLoanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceLookupLoan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDueBalance = 0;
        long expectedPastDueBalance = 0;

        Assert.Equal(expectedDueAt, model.DueAt);
        Assert.Equal(expectedDueBalance, model.DueBalance);
        Assert.Equal(expectedPastDueBalance, model.PastDueBalance);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceLookupLoan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceLookupLoan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceLookupLoan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceLookupLoan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedDueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDueBalance = 0;
        long expectedPastDueBalance = 0;

        Assert.Equal(expectedDueAt, deserialized.DueAt);
        Assert.Equal(expectedDueBalance, deserialized.DueBalance);
        Assert.Equal(expectedPastDueBalance, deserialized.PastDueBalance);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceLookupLoan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceLookupLoan
        {
            DueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DueBalance = 0,
            PastDueBalance = 0,
        };

        BalanceLookupLoan copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BalanceLookupTypeTest : TestBase
{
    [Theory]
    [InlineData(BalanceLookupType.BalanceLookup)]
    public void Validation_Works(BalanceLookupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceLookupType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceLookupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BalanceLookupType.BalanceLookup)]
    public void SerializationRoundtrip_Works(BalanceLookupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceLookupType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceLookupType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceLookupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceLookupType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
