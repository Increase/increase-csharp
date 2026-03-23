using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using ExternalAccounts = Increase.Api.Models.ExternalAccounts;

namespace Increase.Api.Tests.Models.ExternalAccounts;

public class ExternalAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalAccounts::ExternalAccount
        {
            ID = "external_account_ukk55lr923a3ac0pp7iv",
            AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
            AccountNumber = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Landlord",
            Funding = ExternalAccounts::ExternalAccountFunding.Checking,
            IdempotencyKey = null,
            RoutingNumber = "101050001",
            Status = ExternalAccounts::ExternalAccountStatus.Active,
            Type = ExternalAccounts::Type.ExternalAccount,
        };

        string expectedID = "external_account_ukk55lr923a3ac0pp7iv";
        ApiEnum<string, ExternalAccounts::ExternalAccountAccountHolder> expectedAccountHolder =
            ExternalAccounts::ExternalAccountAccountHolder.Business;
        string expectedAccountNumber = "987654321";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Landlord";
        ApiEnum<string, ExternalAccounts::ExternalAccountFunding> expectedFunding =
            ExternalAccounts::ExternalAccountFunding.Checking;
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, ExternalAccounts::ExternalAccountStatus> expectedStatus =
            ExternalAccounts::ExternalAccountStatus.Active;
        ApiEnum<string, ExternalAccounts::Type> expectedType =
            ExternalAccounts::Type.ExternalAccount;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountHolder, model.AccountHolder);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFunding, model.Funding);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalAccounts::ExternalAccount
        {
            ID = "external_account_ukk55lr923a3ac0pp7iv",
            AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
            AccountNumber = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Landlord",
            Funding = ExternalAccounts::ExternalAccountFunding.Checking,
            IdempotencyKey = null,
            RoutingNumber = "101050001",
            Status = ExternalAccounts::ExternalAccountStatus.Active,
            Type = ExternalAccounts::Type.ExternalAccount,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalAccounts::ExternalAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalAccounts::ExternalAccount
        {
            ID = "external_account_ukk55lr923a3ac0pp7iv",
            AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
            AccountNumber = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Landlord",
            Funding = ExternalAccounts::ExternalAccountFunding.Checking,
            IdempotencyKey = null,
            RoutingNumber = "101050001",
            Status = ExternalAccounts::ExternalAccountStatus.Active,
            Type = ExternalAccounts::Type.ExternalAccount,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalAccounts::ExternalAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "external_account_ukk55lr923a3ac0pp7iv";
        ApiEnum<string, ExternalAccounts::ExternalAccountAccountHolder> expectedAccountHolder =
            ExternalAccounts::ExternalAccountAccountHolder.Business;
        string expectedAccountNumber = "987654321";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Landlord";
        ApiEnum<string, ExternalAccounts::ExternalAccountFunding> expectedFunding =
            ExternalAccounts::ExternalAccountFunding.Checking;
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, ExternalAccounts::ExternalAccountStatus> expectedStatus =
            ExternalAccounts::ExternalAccountStatus.Active;
        ApiEnum<string, ExternalAccounts::Type> expectedType =
            ExternalAccounts::Type.ExternalAccount;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountHolder, deserialized.AccountHolder);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFunding, deserialized.Funding);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalAccounts::ExternalAccount
        {
            ID = "external_account_ukk55lr923a3ac0pp7iv",
            AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
            AccountNumber = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Landlord",
            Funding = ExternalAccounts::ExternalAccountFunding.Checking,
            IdempotencyKey = null,
            RoutingNumber = "101050001",
            Status = ExternalAccounts::ExternalAccountStatus.Active,
            Type = ExternalAccounts::Type.ExternalAccount,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalAccounts::ExternalAccount
        {
            ID = "external_account_ukk55lr923a3ac0pp7iv",
            AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
            AccountNumber = "987654321",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Landlord",
            Funding = ExternalAccounts::ExternalAccountFunding.Checking,
            IdempotencyKey = null,
            RoutingNumber = "101050001",
            Status = ExternalAccounts::ExternalAccountStatus.Active,
            Type = ExternalAccounts::Type.ExternalAccount,
        };

        ExternalAccounts::ExternalAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExternalAccountAccountHolderTest : TestBase
{
    [Theory]
    [InlineData(ExternalAccounts::ExternalAccountAccountHolder.Business)]
    [InlineData(ExternalAccounts::ExternalAccountAccountHolder.Individual)]
    [InlineData(ExternalAccounts::ExternalAccountAccountHolder.Unknown)]
    public void Validation_Works(ExternalAccounts::ExternalAccountAccountHolder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccounts::ExternalAccountAccountHolder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountAccountHolder>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalAccounts::ExternalAccountAccountHolder.Business)]
    [InlineData(ExternalAccounts::ExternalAccountAccountHolder.Individual)]
    [InlineData(ExternalAccounts::ExternalAccountAccountHolder.Unknown)]
    public void SerializationRoundtrip_Works(
        ExternalAccounts::ExternalAccountAccountHolder rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccounts::ExternalAccountAccountHolder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountAccountHolder>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountAccountHolder>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountAccountHolder>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExternalAccountFundingTest : TestBase
{
    [Theory]
    [InlineData(ExternalAccounts::ExternalAccountFunding.Checking)]
    [InlineData(ExternalAccounts::ExternalAccountFunding.Savings)]
    [InlineData(ExternalAccounts::ExternalAccountFunding.GeneralLedger)]
    [InlineData(ExternalAccounts::ExternalAccountFunding.Other)]
    public void Validation_Works(ExternalAccounts::ExternalAccountFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccounts::ExternalAccountFunding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountFunding>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalAccounts::ExternalAccountFunding.Checking)]
    [InlineData(ExternalAccounts::ExternalAccountFunding.Savings)]
    [InlineData(ExternalAccounts::ExternalAccountFunding.GeneralLedger)]
    [InlineData(ExternalAccounts::ExternalAccountFunding.Other)]
    public void SerializationRoundtrip_Works(ExternalAccounts::ExternalAccountFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccounts::ExternalAccountFunding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountFunding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountFunding>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountFunding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExternalAccountStatusTest : TestBase
{
    [Theory]
    [InlineData(ExternalAccounts::ExternalAccountStatus.Active)]
    [InlineData(ExternalAccounts::ExternalAccountStatus.Archived)]
    public void Validation_Works(ExternalAccounts::ExternalAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccounts::ExternalAccountStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalAccounts::ExternalAccountStatus.Active)]
    [InlineData(ExternalAccounts::ExternalAccountStatus.Archived)]
    public void SerializationRoundtrip_Works(ExternalAccounts::ExternalAccountStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccounts::ExternalAccountStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccounts::ExternalAccountStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(ExternalAccounts::Type.ExternalAccount)]
    public void Validation_Works(ExternalAccounts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccounts::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalAccounts::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalAccounts::Type.ExternalAccount)]
    public void SerializationRoundtrip_Works(ExternalAccounts::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccounts::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExternalAccounts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalAccounts::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExternalAccounts::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
