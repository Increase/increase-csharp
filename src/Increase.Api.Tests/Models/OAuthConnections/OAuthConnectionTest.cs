using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using OAuthConnections = Increase.Api.Models.OAuthConnections;

namespace Increase.Api.Tests.Models.OAuthConnections;

public class OAuthConnectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OAuthConnections::OAuthConnection
        {
            ID = "connection_dauknoksyr4wilz4e6my",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
            Status = OAuthConnections::OAuthConnectionStatus.Active,
            Type = OAuthConnections::Type.OAuthConnection,
        };

        string expectedID = "connection_dauknoksyr4wilz4e6my";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedGroupID = "group_1g4mhziu6kvrs3vz35um";
        string expectedOAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy";
        ApiEnum<string, OAuthConnections::OAuthConnectionStatus> expectedStatus =
            OAuthConnections::OAuthConnectionStatus.Active;
        ApiEnum<string, OAuthConnections::Type> expectedType =
            OAuthConnections::Type.OAuthConnection;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.DeletedAt);
        Assert.Equal(expectedGroupID, model.GroupID);
        Assert.Equal(expectedOAuthApplicationID, model.OAuthApplicationID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OAuthConnections::OAuthConnection
        {
            ID = "connection_dauknoksyr4wilz4e6my",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
            Status = OAuthConnections::OAuthConnectionStatus.Active,
            Type = OAuthConnections::Type.OAuthConnection,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OAuthConnections::OAuthConnection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OAuthConnections::OAuthConnection
        {
            ID = "connection_dauknoksyr4wilz4e6my",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
            Status = OAuthConnections::OAuthConnectionStatus.Active,
            Type = OAuthConnections::Type.OAuthConnection,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OAuthConnections::OAuthConnection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "connection_dauknoksyr4wilz4e6my";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedGroupID = "group_1g4mhziu6kvrs3vz35um";
        string expectedOAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy";
        ApiEnum<string, OAuthConnections::OAuthConnectionStatus> expectedStatus =
            OAuthConnections::OAuthConnectionStatus.Active;
        ApiEnum<string, OAuthConnections::Type> expectedType =
            OAuthConnections::Type.OAuthConnection;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.DeletedAt);
        Assert.Equal(expectedGroupID, deserialized.GroupID);
        Assert.Equal(expectedOAuthApplicationID, deserialized.OAuthApplicationID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OAuthConnections::OAuthConnection
        {
            ID = "connection_dauknoksyr4wilz4e6my",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
            Status = OAuthConnections::OAuthConnectionStatus.Active,
            Type = OAuthConnections::Type.OAuthConnection,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OAuthConnections::OAuthConnection
        {
            ID = "connection_dauknoksyr4wilz4e6my",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            GroupID = "group_1g4mhziu6kvrs3vz35um",
            OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
            Status = OAuthConnections::OAuthConnectionStatus.Active,
            Type = OAuthConnections::Type.OAuthConnection,
        };

        OAuthConnections::OAuthConnection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthConnectionStatusTest : TestBase
{
    [Theory]
    [InlineData(OAuthConnections::OAuthConnectionStatus.Active)]
    [InlineData(OAuthConnections::OAuthConnectionStatus.Inactive)]
    public void Validation_Works(OAuthConnections::OAuthConnectionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OAuthConnections::OAuthConnectionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OAuthConnections::OAuthConnectionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OAuthConnections::OAuthConnectionStatus.Active)]
    [InlineData(OAuthConnections::OAuthConnectionStatus.Inactive)]
    public void SerializationRoundtrip_Works(OAuthConnections::OAuthConnectionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OAuthConnections::OAuthConnectionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OAuthConnections::OAuthConnectionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OAuthConnections::OAuthConnectionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OAuthConnections::OAuthConnectionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(OAuthConnections::Type.OAuthConnection)]
    public void Validation_Works(OAuthConnections::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OAuthConnections::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OAuthConnections::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OAuthConnections::Type.OAuthConnection)]
    public void SerializationRoundtrip_Works(OAuthConnections::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OAuthConnections::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OAuthConnections::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OAuthConnections::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OAuthConnections::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
