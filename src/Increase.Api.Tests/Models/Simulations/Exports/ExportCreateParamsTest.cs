using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.Exports;

namespace Increase.Api.Tests.Models.Simulations.Exports;

public class ExportCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExportCreateParams
        {
            Category = Category.Form1099Int,
            Form1099Int = new("account_in71c4amph0vgo2qllky"),
        };

        ApiEnum<string, Category> expectedCategory = Category.Form1099Int;
        Form1099Int expectedForm1099Int = new("account_in71c4amph0vgo2qllky");

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedForm1099Int, parameters.Form1099Int);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExportCreateParams { Category = Category.Form1099Int };

        Assert.Null(parameters.Form1099Int);
        Assert.False(parameters.RawBodyData.ContainsKey("form_1099_int"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExportCreateParams
        {
            Category = Category.Form1099Int,

            // Null should be interpreted as omitted for these properties
            Form1099Int = null,
        };

        Assert.Null(parameters.Form1099Int);
        Assert.False(parameters.RawBodyData.ContainsKey("form_1099_int"));
    }

    [Fact]
    public void Url_Works()
    {
        ExportCreateParams parameters = new() { Category = Category.Form1099Int };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/simulations/exports"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExportCreateParams
        {
            Category = Category.Form1099Int,
            Form1099Int = new("account_in71c4amph0vgo2qllky"),
        };

        ExportCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Form1099Int)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Form1099Int)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class Form1099IntTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        string expectedAccountID = "account_id";

        Assert.Equal(expectedAccountID, model.AccountID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Form1099Int>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Form1099Int>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        Form1099Int copied = new(model);

        Assert.Equal(model, copied);
    }
}
