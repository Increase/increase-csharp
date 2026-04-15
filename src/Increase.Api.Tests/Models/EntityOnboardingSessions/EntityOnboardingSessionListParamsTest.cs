using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.EntityOnboardingSessions;

namespace Increase.Api.Tests.Models.EntityOnboardingSessions;

public class EntityOnboardingSessionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityOnboardingSessionListParams
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.Active] },
        };

        string expectedCursor = "cursor";
        string expectedIdempotencyKey = "x";
        long expectedLimit = 1;
        Status expectedStatus = new() { In = [In.Active] };

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityOnboardingSessionListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityOnboardingSessionListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            IdempotencyKey = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityOnboardingSessionListParams parameters = new()
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.Active] },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/entity_onboarding_sessions?cursor=cursor&idempotency_key=x&limit=1&status.in=active"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityOnboardingSessionListParams
        {
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.Active] },
        };

        EntityOnboardingSessionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Status { In = [In.Active] };

        List<ApiEnum<string, In>> expectedIn = [In.Active];

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
        var model = new Status { In = [In.Active] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Status { In = [In.Active] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ApiEnum<string, In>> expectedIn = [In.Active];

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
        var model = new Status { In = [In.Active] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Status { };

        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Status { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Status
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
        var model = new Status
        {
            // Null should be interpreted as omitted for these properties
            In = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Status { In = [In.Active] };

        Status copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InTest : TestBase
{
    [Theory]
    [InlineData(In.Active)]
    [InlineData(In.Expired)]
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
    [InlineData(In.Active)]
    [InlineData(In.Expired)]
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
