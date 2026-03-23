using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.IntrafiAccountEnrollments;

namespace Increase.Api.Tests.Models.IntrafiAccountEnrollments;

public class IntrafiAccountEnrollmentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrafiAccountEnrollmentListParams
        {
            AccountID = "account_id",
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.PendingEnrolling] },
        };

        string expectedAccountID = "account_id";
        string expectedCursor = "cursor";
        string expectedIdempotencyKey = "x";
        long expectedLimit = 1;
        Status expectedStatus = new() { In = [In.PendingEnrolling] };

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntrafiAccountEnrollmentListParams { };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
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
        var parameters = new IntrafiAccountEnrollmentListParams
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
            Cursor = null,
            IdempotencyKey = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.AccountID);
        Assert.False(parameters.RawQueryData.ContainsKey("account_id"));
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
        IntrafiAccountEnrollmentListParams parameters = new()
        {
            AccountID = "account_id",
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.PendingEnrolling] },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/intrafi_account_enrollments?account_id=account_id&cursor=cursor&idempotency_key=x&limit=1&status.in=pending_enrolling"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrafiAccountEnrollmentListParams
        {
            AccountID = "account_id",
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.PendingEnrolling] },
        };

        IntrafiAccountEnrollmentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Status { In = [In.PendingEnrolling] };

        List<ApiEnum<string, In>> expectedIn = [In.PendingEnrolling];

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
        var model = new Status { In = [In.PendingEnrolling] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Status { In = [In.PendingEnrolling] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ApiEnum<string, In>> expectedIn = [In.PendingEnrolling];

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
        var model = new Status { In = [In.PendingEnrolling] };

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
        var model = new Status { In = [In.PendingEnrolling] };

        Status copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InTest : TestBase
{
    [Theory]
    [InlineData(In.PendingEnrolling)]
    [InlineData(In.Enrolled)]
    [InlineData(In.PendingUnenrolling)]
    [InlineData(In.Unenrolled)]
    [InlineData(In.RequiresAttention)]
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
    [InlineData(In.PendingEnrolling)]
    [InlineData(In.Enrolled)]
    [InlineData(In.PendingUnenrolling)]
    [InlineData(In.Unenrolled)]
    [InlineData(In.RequiresAttention)]
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
