using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using AccountNumbers = Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Tests.Models.AccountNumbers;

public class AccountNumberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountNumbers::AccountNumber
        {
            ID = "account_number_v18nkfqm6afpsrvy82b2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberValue = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            InboundAchDebits = AccountNumbers::AccountNumberInboundAchDebits.Blocked,
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
            UnregisteredInboundChecks =
                AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked,
        };

        string expectedID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberValue = "987654321";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebits> expectedInboundAchDebits =
            AccountNumbers::AccountNumberInboundAchDebits.Blocked;
        string expectedName = "ACH";
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, AccountNumbers::AccountNumberStatus> expectedStatus =
            AccountNumbers::AccountNumberStatus.Active;
        ApiEnum<string, AccountNumbers::Type> expectedType = AccountNumbers::Type.AccountNumber;
        ApiEnum<
            string,
            AccountNumbers::AccountNumberUnregisteredInboundChecks
        > expectedUnregisteredInboundChecks =
            AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumberValue, model.AccountNumberValue);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedInboundAchDebits, model.InboundAchDebits);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUnregisteredInboundChecks, model.UnregisteredInboundChecks);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountNumbers::AccountNumber
        {
            ID = "account_number_v18nkfqm6afpsrvy82b2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberValue = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            InboundAchDebits = AccountNumbers::AccountNumberInboundAchDebits.Blocked,
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
            UnregisteredInboundChecks =
                AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumbers::AccountNumber>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountNumbers::AccountNumber
        {
            ID = "account_number_v18nkfqm6afpsrvy82b2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberValue = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            InboundAchDebits = AccountNumbers::AccountNumberInboundAchDebits.Blocked,
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
            UnregisteredInboundChecks =
                AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumbers::AccountNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberValue = "987654321";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebits> expectedInboundAchDebits =
            AccountNumbers::AccountNumberInboundAchDebits.Blocked;
        string expectedName = "ACH";
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, AccountNumbers::AccountNumberStatus> expectedStatus =
            AccountNumbers::AccountNumberStatus.Active;
        ApiEnum<string, AccountNumbers::Type> expectedType = AccountNumbers::Type.AccountNumber;
        ApiEnum<
            string,
            AccountNumbers::AccountNumberUnregisteredInboundChecks
        > expectedUnregisteredInboundChecks =
            AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumberValue, deserialized.AccountNumberValue);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedInboundAchDebits, deserialized.InboundAchDebits);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUnregisteredInboundChecks, deserialized.UnregisteredInboundChecks);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountNumbers::AccountNumber
        {
            ID = "account_number_v18nkfqm6afpsrvy82b2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberValue = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            InboundAchDebits = AccountNumbers::AccountNumberInboundAchDebits.Blocked,
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
            UnregisteredInboundChecks =
                AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountNumbers::AccountNumber
        {
            ID = "account_number_v18nkfqm6afpsrvy82b2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumberValue = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            InboundAchDebits = AccountNumbers::AccountNumberInboundAchDebits.Blocked,
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
            UnregisteredInboundChecks =
                AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked,
        };

        AccountNumbers::AccountNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountNumberInboundAchDebitsTest : TestBase
{
    [Theory]
    [InlineData(AccountNumbers::AccountNumberInboundAchDebits.Allowed)]
    [InlineData(AccountNumbers::AccountNumberInboundAchDebits.Blocked)]
    public void Validation_Works(AccountNumbers::AccountNumberInboundAchDebits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebits> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumbers::AccountNumberInboundAchDebits.Allowed)]
    [InlineData(AccountNumbers::AccountNumberInboundAchDebits.Blocked)]
    public void SerializationRoundtrip_Works(AccountNumbers::AccountNumberInboundAchDebits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebits> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountNumberStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountNumbers::AccountNumberStatus.Active)]
    [InlineData(AccountNumbers::AccountNumberStatus.Disabled)]
    [InlineData(AccountNumbers::AccountNumberStatus.Canceled)]
    public void Validation_Works(AccountNumbers::AccountNumberStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumbers::AccountNumberStatus.Active)]
    [InlineData(AccountNumbers::AccountNumberStatus.Disabled)]
    [InlineData(AccountNumbers::AccountNumberStatus.Canceled)]
    public void SerializationRoundtrip_Works(AccountNumbers::AccountNumberStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(AccountNumbers::Type.AccountNumber)]
    public void Validation_Works(AccountNumbers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountNumbers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumbers::Type.AccountNumber)]
    public void SerializationRoundtrip_Works(AccountNumbers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountNumbers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountNumbers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountNumbers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AccountNumberUnregisteredInboundChecksTest : TestBase
{
    [Theory]
    [InlineData(AccountNumbers::AccountNumberUnregisteredInboundChecks.Allowed)]
    [InlineData(AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked)]
    public void Validation_Works(AccountNumbers::AccountNumberUnregisteredInboundChecks rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberUnregisteredInboundChecks> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberUnregisteredInboundChecks>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumbers::AccountNumberUnregisteredInboundChecks.Allowed)]
    [InlineData(AccountNumbers::AccountNumberUnregisteredInboundChecks.Blocked)]
    public void SerializationRoundtrip_Works(
        AccountNumbers::AccountNumberUnregisteredInboundChecks rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberUnregisteredInboundChecks> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberUnregisteredInboundChecks>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberUnregisteredInboundChecks>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberUnregisteredInboundChecks>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
