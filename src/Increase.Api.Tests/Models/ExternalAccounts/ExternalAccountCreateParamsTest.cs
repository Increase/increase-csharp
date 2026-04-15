using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.ExternalAccounts;

namespace Increase.Api.Tests.Models.ExternalAccounts;

public class ExternalAccountCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalAccountCreateParams
        {
            AccountNumber = "987654321",
            Description = "Landlord",
            RoutingNumber = "101050001",
            AccountHolder = AccountHolder.Business,
            Funding = Funding.Checking,
        };

        string expectedAccountNumber = "987654321";
        string expectedDescription = "Landlord";
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, AccountHolder> expectedAccountHolder = AccountHolder.Business;
        ApiEnum<string, Funding> expectedFunding = Funding.Checking;

        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedRoutingNumber, parameters.RoutingNumber);
        Assert.Equal(expectedAccountHolder, parameters.AccountHolder);
        Assert.Equal(expectedFunding, parameters.Funding);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalAccountCreateParams
        {
            AccountNumber = "987654321",
            Description = "Landlord",
            RoutingNumber = "101050001",
        };

        Assert.Null(parameters.AccountHolder);
        Assert.False(parameters.RawBodyData.ContainsKey("account_holder"));
        Assert.Null(parameters.Funding);
        Assert.False(parameters.RawBodyData.ContainsKey("funding"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalAccountCreateParams
        {
            AccountNumber = "987654321",
            Description = "Landlord",
            RoutingNumber = "101050001",

            // Null should be interpreted as omitted for these properties
            AccountHolder = null,
            Funding = null,
        };

        Assert.Null(parameters.AccountHolder);
        Assert.False(parameters.RawBodyData.ContainsKey("account_holder"));
        Assert.Null(parameters.Funding);
        Assert.False(parameters.RawBodyData.ContainsKey("funding"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalAccountCreateParams parameters = new()
        {
            AccountNumber = "987654321",
            Description = "Landlord",
            RoutingNumber = "101050001",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/external_accounts"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalAccountCreateParams
        {
            AccountNumber = "987654321",
            Description = "Landlord",
            RoutingNumber = "101050001",
            AccountHolder = AccountHolder.Business,
            Funding = Funding.Checking,
        };

        ExternalAccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountHolderTest : TestBase
{
    [Theory]
    [InlineData(AccountHolder.Business)]
    [InlineData(AccountHolder.Individual)]
    [InlineData(AccountHolder.Unknown)]
    public void Validation_Works(AccountHolder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountHolder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountHolder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountHolder.Business)]
    [InlineData(AccountHolder.Individual)]
    [InlineData(AccountHolder.Unknown)]
    public void SerializationRoundtrip_Works(AccountHolder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountHolder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountHolder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountHolder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountHolder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FundingTest : TestBase
{
    [Theory]
    [InlineData(Funding.Checking)]
    [InlineData(Funding.Savings)]
    [InlineData(Funding.GeneralLedger)]
    [InlineData(Funding.Other)]
    public void Validation_Works(Funding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Funding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Funding.Checking)]
    [InlineData(Funding.Savings)]
    [InlineData(Funding.GeneralLedger)]
    [InlineData(Funding.Other)]
    public void SerializationRoundtrip_Works(Funding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Funding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
