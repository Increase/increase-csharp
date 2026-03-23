using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.DeclinedTransactions;

namespace Increase.Api.Tests.Models.DeclinedTransactions;

public class DeclinedTransactionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DeclinedTransactionListParams
        {
            AccountID = "account_id",
            Category = new() { In = [In.AchDecline] },
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Cursor = "cursor",
            Limit = 1,
            RouteID = "route_id",
        };

        string expectedAccountID = "account_id";
        Category expectedCategory = new() { In = [In.AchDecline] };
        CreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCursor = "cursor";
        long expectedLimit = 1;
        string expectedRouteID = "route_id";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedCreatedAt, parameters.CreatedAt);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedRouteID, parameters.RouteID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DeclinedTransactionListParams { };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.RouteID);
        Assert.False(parameters.RawQueryData.ContainsKey("route_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DeclinedTransactionListParams
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Category = null,
            CreatedAt = null,
            Cursor = null,
            Limit = null,
            RouteID = null,
        };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.RouteID);
        Assert.False(parameters.RawQueryData.ContainsKey("route_id"));
    }

    [Fact]
    public void Url_Works()
    {
        DeclinedTransactionListParams parameters = new()
        {
            AccountID = "account_id",
            Category = new() { In = [In.AchDecline] },
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Cursor = "cursor",
            Limit = 1,
            RouteID = "route_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/declined_transactions?account_id=account_id&category.in=ach_decline&created_at.after=2019-12-27T18%3a11%3a19.117Z&created_at.before=2019-12-27T18%3a11%3a19.117Z&created_at.on_or_after=2019-12-27T18%3a11%3a19.117Z&created_at.on_or_before=2019-12-27T18%3a11%3a19.117Z&cursor=cursor&limit=1&route_id=route_id"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DeclinedTransactionListParams
        {
            AccountID = "account_id",
            Category = new() { In = [In.AchDecline] },
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Cursor = "cursor",
            Limit = 1,
            RouteID = "route_id",
        };

        DeclinedTransactionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Category { In = [In.AchDecline] };

        List<ApiEnum<string, In>> expectedIn = [In.AchDecline];

        Assert.NotNull(model.In);
        Assert.Equal(expectedIn.Count, model.In.Count);
        for (int i = 0; i < expectedIn.Count; i++)
        {
            Assert.Equal(expectedIn[i], model.In[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Category { In = [In.AchDecline] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Category>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Category { In = [In.AchDecline] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Category>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, In>> expectedIn = [In.AchDecline];

        Assert.NotNull(deserialized.In);
        Assert.Equal(expectedIn.Count, deserialized.In.Count);
        for (int i = 0; i < expectedIn.Count; i++)
        {
            Assert.Equal(expectedIn[i], deserialized.In[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Category { In = [In.AchDecline] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Category { };

        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Category { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Category
        {
            // Null should be interpreted as omitted for these properties
            In = null,
        };

        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Category
        {
            // Null should be interpreted as omitted for these properties
            In = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Category { In = [In.AchDecline] };

        Category copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InTest : TestBase
{
    [Theory]
    [InlineData(In.AchDecline)]
    [InlineData(In.CardDecline)]
    [InlineData(In.CheckDecline)]
    [InlineData(In.InboundRealTimePaymentsTransferDecline)]
    [InlineData(In.InboundFednowTransferDecline)]
    [InlineData(In.WireDecline)]
    [InlineData(In.CheckDepositRejection)]
    [InlineData(In.Other)]
    public void Validation_Works(In rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, In> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(In.AchDecline)]
    [InlineData(In.CardDecline)]
    [InlineData(In.CheckDecline)]
    [InlineData(In.InboundRealTimePaymentsTransferDecline)]
    [InlineData(In.InboundFednowTransferDecline)]
    [InlineData(In.WireDecline)]
    [InlineData(In.CheckDepositRejection)]
    [InlineData(In.Other)]
    public void SerializationRoundtrip_Works(In rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, In> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
        Assert.Equal(expectedOnOrAfter, model.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, model.OnOrBefore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
        Assert.Equal(expectedOnOrAfter, deserialized.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, deserialized.OnOrBefore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreatedAt { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}
