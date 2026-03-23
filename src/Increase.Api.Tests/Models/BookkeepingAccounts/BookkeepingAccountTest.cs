using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Tests.Models.BookkeepingAccounts;

public class BookkeepingAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingAccount
        {
            ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            AccountID = null,
            ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            IdempotencyKey = null,
            Name = "John Doe Balance",
            Type = Type.BookkeepingAccount,
        };

        string expectedID = "bookkeeping_account_e37p1f1iuocw5intf35v";
        ApiEnum<string, BookkeepingAccountComplianceCategory> expectedComplianceCategory =
            BookkeepingAccountComplianceCategory.CustomerBalance;
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        string expectedName = "John Doe Balance";
        ApiEnum<string, Type> expectedType = Type.BookkeepingAccount;

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.AccountID);
        Assert.Equal(expectedComplianceCategory, model.ComplianceCategory);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookkeepingAccount
        {
            ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            AccountID = null,
            ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            IdempotencyKey = null,
            Name = "John Doe Balance",
            Type = Type.BookkeepingAccount,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingAccount
        {
            ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            AccountID = null,
            ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            IdempotencyKey = null,
            Name = "John Doe Balance",
            Type = Type.BookkeepingAccount,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "bookkeeping_account_e37p1f1iuocw5intf35v";
        ApiEnum<string, BookkeepingAccountComplianceCategory> expectedComplianceCategory =
            BookkeepingAccountComplianceCategory.CustomerBalance;
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        string expectedName = "John Doe Balance";
        ApiEnum<string, Type> expectedType = Type.BookkeepingAccount;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.AccountID);
        Assert.Equal(expectedComplianceCategory, deserialized.ComplianceCategory);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookkeepingAccount
        {
            ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            AccountID = null,
            ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            IdempotencyKey = null,
            Name = "John Doe Balance",
            Type = Type.BookkeepingAccount,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingAccount
        {
            ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            AccountID = null,
            ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            IdempotencyKey = null,
            Name = "John Doe Balance",
            Type = Type.BookkeepingAccount,
        };

        BookkeepingAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BookkeepingAccountComplianceCategoryTest : TestBase
{
    [Theory]
    [InlineData(BookkeepingAccountComplianceCategory.CommingledCash)]
    [InlineData(BookkeepingAccountComplianceCategory.CustomerBalance)]
    public void Validation_Works(BookkeepingAccountComplianceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BookkeepingAccountComplianceCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BookkeepingAccountComplianceCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BookkeepingAccountComplianceCategory.CommingledCash)]
    [InlineData(BookkeepingAccountComplianceCategory.CustomerBalance)]
    public void SerializationRoundtrip_Works(BookkeepingAccountComplianceCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BookkeepingAccountComplianceCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BookkeepingAccountComplianceCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BookkeepingAccountComplianceCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BookkeepingAccountComplianceCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.BookkeepingAccount)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.BookkeepingAccount)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
