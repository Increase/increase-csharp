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
                DueFees = 0,
                DueInterest = 0,
                DuePrincipal = 0,
                NotDueFees = 0,
                NotDueInterest = 0,
                NotDuePrincipal = 0,
            },
            Type = BalanceLookupType.BalanceLookup,
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAvailableBalance = 100;
        long expectedCurrentBalance = 100;
        BalanceLookupLoan expectedLoan = new()
        {
            DueFees = 0,
            DueInterest = 0,
            DuePrincipal = 0,
            NotDueFees = 0,
            NotDueInterest = 0,
            NotDuePrincipal = 0,
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
                DueFees = 0,
                DueInterest = 0,
                DuePrincipal = 0,
                NotDueFees = 0,
                NotDueInterest = 0,
                NotDuePrincipal = 0,
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
                DueFees = 0,
                DueInterest = 0,
                DuePrincipal = 0,
                NotDueFees = 0,
                NotDueInterest = 0,
                NotDuePrincipal = 0,
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
            DueFees = 0,
            DueInterest = 0,
            DuePrincipal = 0,
            NotDueFees = 0,
            NotDueInterest = 0,
            NotDuePrincipal = 0,
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
                DueFees = 0,
                DueInterest = 0,
                DuePrincipal = 0,
                NotDueFees = 0,
                NotDueInterest = 0,
                NotDuePrincipal = 0,
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
                DueFees = 0,
                DueInterest = 0,
                DuePrincipal = 0,
                NotDueFees = 0,
                NotDueInterest = 0,
                NotDuePrincipal = 0,
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
            DueFees = 0,
            DueInterest = 0,
            DuePrincipal = 0,
            NotDueFees = 0,
            NotDueInterest = 0,
            NotDuePrincipal = 0,
        };

        long expectedDueFees = 0;
        long expectedDueInterest = 0;
        long expectedDuePrincipal = 0;
        long expectedNotDueFees = 0;
        long expectedNotDueInterest = 0;
        long expectedNotDuePrincipal = 0;

        Assert.Equal(expectedDueFees, model.DueFees);
        Assert.Equal(expectedDueInterest, model.DueInterest);
        Assert.Equal(expectedDuePrincipal, model.DuePrincipal);
        Assert.Equal(expectedNotDueFees, model.NotDueFees);
        Assert.Equal(expectedNotDueInterest, model.NotDueInterest);
        Assert.Equal(expectedNotDuePrincipal, model.NotDuePrincipal);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceLookupLoan
        {
            DueFees = 0,
            DueInterest = 0,
            DuePrincipal = 0,
            NotDueFees = 0,
            NotDueInterest = 0,
            NotDuePrincipal = 0,
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
            DueFees = 0,
            DueInterest = 0,
            DuePrincipal = 0,
            NotDueFees = 0,
            NotDueInterest = 0,
            NotDuePrincipal = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BalanceLookupLoan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDueFees = 0;
        long expectedDueInterest = 0;
        long expectedDuePrincipal = 0;
        long expectedNotDueFees = 0;
        long expectedNotDueInterest = 0;
        long expectedNotDuePrincipal = 0;

        Assert.Equal(expectedDueFees, deserialized.DueFees);
        Assert.Equal(expectedDueInterest, deserialized.DueInterest);
        Assert.Equal(expectedDuePrincipal, deserialized.DuePrincipal);
        Assert.Equal(expectedNotDueFees, deserialized.NotDueFees);
        Assert.Equal(expectedNotDueInterest, deserialized.NotDueInterest);
        Assert.Equal(expectedNotDuePrincipal, deserialized.NotDuePrincipal);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BalanceLookupLoan
        {
            DueFees = 0,
            DueInterest = 0,
            DuePrincipal = 0,
            NotDueFees = 0,
            NotDueInterest = 0,
            NotDuePrincipal = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BalanceLookupLoan
        {
            DueFees = 0,
            DueInterest = 0,
            DuePrincipal = 0,
            NotDueFees = 0,
            NotDueInterest = 0,
            NotDuePrincipal = 0,
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
