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
            InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
            InboundChecks = new(
                AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
            ),
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
        };

        string expectedID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberValue = "987654321";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        AccountNumbers::AccountNumberInboundAch expectedInboundAch = new(
            AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked
        );
        AccountNumbers::AccountNumberInboundChecks expectedInboundChecks = new(
            AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
        );
        string expectedName = "ACH";
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, AccountNumbers::AccountNumberStatus> expectedStatus =
            AccountNumbers::AccountNumberStatus.Active;
        ApiEnum<string, AccountNumbers::Type> expectedType = AccountNumbers::Type.AccountNumber;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumberValue, model.AccountNumberValue);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedInboundAch, model.InboundAch);
        Assert.Equal(expectedInboundChecks, model.InboundChecks);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
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
            InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
            InboundChecks = new(
                AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
            ),
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
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
            InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
            InboundChecks = new(
                AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
            ),
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
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
        AccountNumbers::AccountNumberInboundAch expectedInboundAch = new(
            AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked
        );
        AccountNumbers::AccountNumberInboundChecks expectedInboundChecks = new(
            AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
        );
        string expectedName = "ACH";
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, AccountNumbers::AccountNumberStatus> expectedStatus =
            AccountNumbers::AccountNumberStatus.Active;
        ApiEnum<string, AccountNumbers::Type> expectedType = AccountNumbers::Type.AccountNumber;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumberValue, deserialized.AccountNumberValue);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedInboundAch, deserialized.InboundAch);
        Assert.Equal(expectedInboundChecks, deserialized.InboundChecks);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
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
            InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
            InboundChecks = new(
                AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
            ),
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
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
            InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
            InboundChecks = new(
                AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
            ),
            Name = "ACH",
            RoutingNumber = "101050001",
            Status = AccountNumbers::AccountNumberStatus.Active,
            Type = AccountNumbers::Type.AccountNumber,
        };

        AccountNumbers::AccountNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountNumberInboundAchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundAch
        {
            DebitStatus = AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed,
        };

        ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebitStatus> expectedDebitStatus =
            AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed;

        Assert.Equal(expectedDebitStatus, model.DebitStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundAch
        {
            DebitStatus = AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumbers::AccountNumberInboundAch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundAch
        {
            DebitStatus = AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumbers::AccountNumberInboundAch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebitStatus> expectedDebitStatus =
            AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed;

        Assert.Equal(expectedDebitStatus, deserialized.DebitStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundAch
        {
            DebitStatus = AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundAch
        {
            DebitStatus = AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed,
        };

        AccountNumbers::AccountNumberInboundAch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountNumberInboundAchDebitStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed)]
    [InlineData(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked)]
    public void Validation_Works(AccountNumbers::AccountNumberInboundAchDebitStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebitStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebitStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumbers::AccountNumberInboundAchDebitStatus.Allowed)]
    [InlineData(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked)]
    public void SerializationRoundtrip_Works(
        AccountNumbers::AccountNumberInboundAchDebitStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebitStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebitStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebitStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundAchDebitStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountNumberInboundChecksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundChecks
        {
            Status = AccountNumbers::AccountNumberInboundChecksStatus.Allowed,
        };

        ApiEnum<string, AccountNumbers::AccountNumberInboundChecksStatus> expectedStatus =
            AccountNumbers::AccountNumberInboundChecksStatus.Allowed;

        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundChecks
        {
            Status = AccountNumbers::AccountNumberInboundChecksStatus.Allowed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumbers::AccountNumberInboundChecks>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundChecks
        {
            Status = AccountNumbers::AccountNumberInboundChecksStatus.Allowed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumbers::AccountNumberInboundChecks>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccountNumbers::AccountNumberInboundChecksStatus> expectedStatus =
            AccountNumbers::AccountNumberInboundChecksStatus.Allowed;

        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundChecks
        {
            Status = AccountNumbers::AccountNumberInboundChecksStatus.Allowed,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountNumbers::AccountNumberInboundChecks
        {
            Status = AccountNumbers::AccountNumberInboundChecksStatus.Allowed,
        };

        AccountNumbers::AccountNumberInboundChecks copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountNumberInboundChecksStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountNumbers::AccountNumberInboundChecksStatus.Allowed)]
    [InlineData(AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly)]
    public void Validation_Works(AccountNumbers::AccountNumberInboundChecksStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberInboundChecksStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundChecksStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumbers::AccountNumberInboundChecksStatus.Allowed)]
    [InlineData(AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly)]
    public void SerializationRoundtrip_Works(
        AccountNumbers::AccountNumberInboundChecksStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumbers::AccountNumberInboundChecksStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundChecksStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundChecksStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumbers::AccountNumberInboundChecksStatus>
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
