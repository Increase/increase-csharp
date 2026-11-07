using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Tests.Models.AccountNumbers;

public class AccountNumberCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountNumberCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",
            InboundAchDebits = InboundAchDebits.Allowed,
            UnregisteredInboundChecks = UnregisteredInboundChecks.Allowed,
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedName = "Rent payments";
        ApiEnum<string, InboundAchDebits> expectedInboundAchDebits = InboundAchDebits.Allowed;
        ApiEnum<string, UnregisteredInboundChecks> expectedUnregisteredInboundChecks =
            UnregisteredInboundChecks.Allowed;

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedInboundAchDebits, parameters.InboundAchDebits);
        Assert.Equal(expectedUnregisteredInboundChecks, parameters.UnregisteredInboundChecks);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountNumberCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",
        };

        Assert.Null(parameters.InboundAchDebits);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_ach_debits"));
        Assert.Null(parameters.UnregisteredInboundChecks);
        Assert.False(parameters.RawBodyData.ContainsKey("unregistered_inbound_checks"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountNumberCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",

            // Null should be interpreted as omitted for these properties
            InboundAchDebits = null,
            UnregisteredInboundChecks = null,
        };

        Assert.Null(parameters.InboundAchDebits);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_ach_debits"));
        Assert.Null(parameters.UnregisteredInboundChecks);
        Assert.False(parameters.RawBodyData.ContainsKey("unregistered_inbound_checks"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountNumberCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/account_numbers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountNumberCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",
            InboundAchDebits = InboundAchDebits.Allowed,
            UnregisteredInboundChecks = UnregisteredInboundChecks.Allowed,
        };

        AccountNumberCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InboundAchDebitsTest : TestBase
{
    [Theory]
    [InlineData(InboundAchDebits.Allowed)]
    [InlineData(InboundAchDebits.Blocked)]
    public void Validation_Works(InboundAchDebits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchDebits> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchDebits>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundAchDebits.Allowed)]
    [InlineData(InboundAchDebits.Blocked)]
    public void SerializationRoundtrip_Works(InboundAchDebits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundAchDebits> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundAchDebits>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundAchDebits>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundAchDebits>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnregisteredInboundChecksTest : TestBase
{
    [Theory]
    [InlineData(UnregisteredInboundChecks.Allowed)]
    [InlineData(UnregisteredInboundChecks.Blocked)]
    public void Validation_Works(UnregisteredInboundChecks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnregisteredInboundChecks> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnregisteredInboundChecks>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnregisteredInboundChecks.Allowed)]
    [InlineData(UnregisteredInboundChecks.Blocked)]
    public void SerializationRoundtrip_Works(UnregisteredInboundChecks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnregisteredInboundChecks> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnregisteredInboundChecks>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UnregisteredInboundChecks>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UnregisteredInboundChecks>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
