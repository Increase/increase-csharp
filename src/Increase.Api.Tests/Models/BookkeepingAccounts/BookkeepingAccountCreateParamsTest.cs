using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Tests.Models.BookkeepingAccounts;

public class BookkeepingAccountCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingAccountCreateParams
        {
            Name = "New Account!",
            AccountID = "account_id",
            ComplianceCategory = ComplianceCategory.CommingledCash,
            EntityID = "entity_id",
        };

        string expectedName = "New Account!";
        string expectedAccountID = "account_id";
        ApiEnum<string, ComplianceCategory> expectedComplianceCategory =
            ComplianceCategory.CommingledCash;
        string expectedEntityID = "entity_id";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedComplianceCategory, parameters.ComplianceCategory);
        Assert.Equal(expectedEntityID, parameters.EntityID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BookkeepingAccountCreateParams { Name = "New Account!" };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("account_id"));
        Assert.Null(parameters.ComplianceCategory);
        Assert.False(parameters.RawBodyData.ContainsKey("compliance_category"));
        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BookkeepingAccountCreateParams
        {
            Name = "New Account!",

            // Null should be interpreted as omitted for these properties
            AccountID = null,
            ComplianceCategory = null,
            EntityID = null,
        };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("account_id"));
        Assert.Null(parameters.ComplianceCategory);
        Assert.False(parameters.RawBodyData.ContainsKey("compliance_category"));
        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_id"));
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingAccountCreateParams parameters = new() { Name = "New Account!" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/bookkeeping_accounts"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingAccountCreateParams
        {
            Name = "New Account!",
            AccountID = "account_id",
            ComplianceCategory = ComplianceCategory.CommingledCash,
            EntityID = "entity_id",
        };

        BookkeepingAccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ComplianceCategoryTest : TestBase
{
    [Theory]
    [InlineData(ComplianceCategory.CommingledCash)]
    [InlineData(ComplianceCategory.CustomerBalance)]
    public void Validation_Works(ComplianceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComplianceCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComplianceCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ComplianceCategory.CommingledCash)]
    [InlineData(ComplianceCategory.CustomerBalance)]
    public void SerializationRoundtrip_Works(ComplianceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComplianceCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComplianceCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComplianceCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComplianceCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
