using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Tests.Models.BookkeepingAccounts;

public class BookkeepingBalanceLookupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingBalanceLookup
        {
            Balance = 100,
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Type = BookkeepingBalanceLookupType.BookkeepingBalanceLookup,
        };

        long expectedBalance = 100;
        string expectedBookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v";
        ApiEnum<string, BookkeepingBalanceLookupType> expectedType =
            BookkeepingBalanceLookupType.BookkeepingBalanceLookup;

        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedBookkeepingAccountID, model.BookkeepingAccountID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BookkeepingBalanceLookup
        {
            Balance = 100,
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Type = BookkeepingBalanceLookupType.BookkeepingBalanceLookup,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingBalanceLookup>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingBalanceLookup
        {
            Balance = 100,
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Type = BookkeepingBalanceLookupType.BookkeepingBalanceLookup,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingBalanceLookup>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBalance = 100;
        string expectedBookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v";
        ApiEnum<string, BookkeepingBalanceLookupType> expectedType =
            BookkeepingBalanceLookupType.BookkeepingBalanceLookup;

        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedBookkeepingAccountID, deserialized.BookkeepingAccountID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BookkeepingBalanceLookup
        {
            Balance = 100,
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Type = BookkeepingBalanceLookupType.BookkeepingBalanceLookup,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingBalanceLookup
        {
            Balance = 100,
            BookkeepingAccountID = "bookkeeping_account_e37p1f1iuocw5intf35v",
            Type = BookkeepingBalanceLookupType.BookkeepingBalanceLookup,
        };

        BookkeepingBalanceLookup copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BookkeepingBalanceLookupTypeTest : TestBase
{
    [Theory]
    [InlineData(BookkeepingBalanceLookupType.BookkeepingBalanceLookup)]
    public void Validation_Works(BookkeepingBalanceLookupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BookkeepingBalanceLookupType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingBalanceLookupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BookkeepingBalanceLookupType.BookkeepingBalanceLookup)]
    public void SerializationRoundtrip_Works(BookkeepingBalanceLookupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BookkeepingBalanceLookupType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BookkeepingBalanceLookupType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BookkeepingBalanceLookupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BookkeepingBalanceLookupType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
