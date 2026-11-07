using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Tests.Models.AccountNumbers;

public class AccountNumberUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountNumberUpdateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            InboundAchDebits = AccountNumberUpdateParamsInboundAchDebits.Blocked,
            Name = "x",
            Status = Status.Disabled,
            UnregisteredInboundChecks = AccountNumberUpdateParamsUnregisteredInboundChecks.Allowed,
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits> expectedInboundAchDebits =
            AccountNumberUpdateParamsInboundAchDebits.Blocked;
        string expectedName = "x";
        ApiEnum<string, Status> expectedStatus = Status.Disabled;
        ApiEnum<
            string,
            AccountNumberUpdateParamsUnregisteredInboundChecks
        > expectedUnregisteredInboundChecks =
            AccountNumberUpdateParamsUnregisteredInboundChecks.Allowed;

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedInboundAchDebits, parameters.InboundAchDebits);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedUnregisteredInboundChecks, parameters.UnregisteredInboundChecks);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountNumberUpdateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        Assert.Null(parameters.InboundAchDebits);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_ach_debits"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.UnregisteredInboundChecks);
        Assert.False(parameters.RawBodyData.ContainsKey("unregistered_inbound_checks"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountNumberUpdateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",

            // Null should be interpreted as omitted for these properties
            InboundAchDebits = null,
            Name = null,
            Status = null,
            UnregisteredInboundChecks = null,
        };

        Assert.Null(parameters.InboundAchDebits);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_ach_debits"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.UnregisteredInboundChecks);
        Assert.False(parameters.RawBodyData.ContainsKey("unregistered_inbound_checks"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountNumberUpdateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/account_numbers/account_number_v18nkfqm6afpsrvy82b2"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountNumberUpdateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            InboundAchDebits = AccountNumberUpdateParamsInboundAchDebits.Blocked,
            Name = "x",
            Status = Status.Disabled,
            UnregisteredInboundChecks = AccountNumberUpdateParamsUnregisteredInboundChecks.Allowed,
        };

        AccountNumberUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountNumberUpdateParamsInboundAchDebitsTest : TestBase
{
    [Theory]
    [InlineData(AccountNumberUpdateParamsInboundAchDebits.Allowed)]
    [InlineData(AccountNumberUpdateParamsInboundAchDebits.Blocked)]
    public void Validation_Works(AccountNumberUpdateParamsInboundAchDebits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumberUpdateParamsInboundAchDebits.Allowed)]
    [InlineData(AccountNumberUpdateParamsInboundAchDebits.Blocked)]
    public void SerializationRoundtrip_Works(AccountNumberUpdateParamsInboundAchDebits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundAchDebits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    [InlineData(Status.Canceled)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    [InlineData(Status.Canceled)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AccountNumberUpdateParamsUnregisteredInboundChecksTest : TestBase
{
    [Theory]
    [InlineData(AccountNumberUpdateParamsUnregisteredInboundChecks.Allowed)]
    [InlineData(AccountNumberUpdateParamsUnregisteredInboundChecks.Blocked)]
    public void Validation_Works(AccountNumberUpdateParamsUnregisteredInboundChecks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsUnregisteredInboundChecks> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsUnregisteredInboundChecks>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumberUpdateParamsUnregisteredInboundChecks.Allowed)]
    [InlineData(AccountNumberUpdateParamsUnregisteredInboundChecks.Blocked)]
    public void SerializationRoundtrip_Works(
        AccountNumberUpdateParamsUnregisteredInboundChecks rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsUnregisteredInboundChecks> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsUnregisteredInboundChecks>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsUnregisteredInboundChecks>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsUnregisteredInboundChecks>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
