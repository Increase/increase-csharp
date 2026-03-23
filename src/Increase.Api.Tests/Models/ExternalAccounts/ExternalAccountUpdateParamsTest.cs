using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.ExternalAccounts;

namespace Increase.Api.Tests.Models.ExternalAccounts;

public class ExternalAccountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExternalAccountUpdateParams
        {
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            AccountHolder = ExternalAccountUpdateParamsAccountHolder.Business,
            Description = "New description",
            Funding = ExternalAccountUpdateParamsFunding.Checking,
            Status = Status.Active,
        };

        string expectedExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv";
        ApiEnum<string, ExternalAccountUpdateParamsAccountHolder> expectedAccountHolder =
            ExternalAccountUpdateParamsAccountHolder.Business;
        string expectedDescription = "New description";
        ApiEnum<string, ExternalAccountUpdateParamsFunding> expectedFunding =
            ExternalAccountUpdateParamsFunding.Checking;
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedExternalAccountID, parameters.ExternalAccountID);
        Assert.Equal(expectedAccountHolder, parameters.AccountHolder);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedFunding, parameters.Funding);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExternalAccountUpdateParams
        {
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
        };

        Assert.Null(parameters.AccountHolder);
        Assert.False(parameters.RawBodyData.ContainsKey("account_holder"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Funding);
        Assert.False(parameters.RawBodyData.ContainsKey("funding"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExternalAccountUpdateParams
        {
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",

            // Null should be interpreted as omitted for these properties
            AccountHolder = null,
            Description = null,
            Funding = null,
            Status = null,
        };

        Assert.Null(parameters.AccountHolder);
        Assert.False(parameters.RawBodyData.ContainsKey("account_holder"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Funding);
        Assert.False(parameters.RawBodyData.ContainsKey("funding"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        ExternalAccountUpdateParams parameters = new()
        {
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/external_accounts/external_account_ukk55lr923a3ac0pp7iv"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExternalAccountUpdateParams
        {
            ExternalAccountID = "external_account_ukk55lr923a3ac0pp7iv",
            AccountHolder = ExternalAccountUpdateParamsAccountHolder.Business,
            Description = "New description",
            Funding = ExternalAccountUpdateParamsFunding.Checking,
            Status = Status.Active,
        };

        ExternalAccountUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ExternalAccountUpdateParamsAccountHolderTest : TestBase
{
    [Theory]
    [InlineData(ExternalAccountUpdateParamsAccountHolder.Business)]
    [InlineData(ExternalAccountUpdateParamsAccountHolder.Individual)]
    public void Validation_Works(ExternalAccountUpdateParamsAccountHolder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccountUpdateParamsAccountHolder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccountUpdateParamsAccountHolder>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalAccountUpdateParamsAccountHolder.Business)]
    [InlineData(ExternalAccountUpdateParamsAccountHolder.Individual)]
    public void SerializationRoundtrip_Works(ExternalAccountUpdateParamsAccountHolder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccountUpdateParamsAccountHolder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccountUpdateParamsAccountHolder>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccountUpdateParamsAccountHolder>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccountUpdateParamsAccountHolder>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExternalAccountUpdateParamsFundingTest : TestBase
{
    [Theory]
    [InlineData(ExternalAccountUpdateParamsFunding.Checking)]
    [InlineData(ExternalAccountUpdateParamsFunding.Savings)]
    [InlineData(ExternalAccountUpdateParamsFunding.GeneralLedger)]
    [InlineData(ExternalAccountUpdateParamsFunding.Other)]
    public void Validation_Works(ExternalAccountUpdateParamsFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccountUpdateParamsFunding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalAccountUpdateParamsFunding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExternalAccountUpdateParamsFunding.Checking)]
    [InlineData(ExternalAccountUpdateParamsFunding.Savings)]
    [InlineData(ExternalAccountUpdateParamsFunding.GeneralLedger)]
    [InlineData(ExternalAccountUpdateParamsFunding.Other)]
    public void SerializationRoundtrip_Works(ExternalAccountUpdateParamsFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExternalAccountUpdateParamsFunding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccountUpdateParamsFunding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExternalAccountUpdateParamsFunding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExternalAccountUpdateParamsFunding>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Archived)]
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
    [InlineData(Status.Archived)]
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
