using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using FileLinks = Increase.Api.Models.FileLinks;

namespace Increase.Api.Tests.Models.FileLinks;

public class FileLinkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileLinks::FileLink
        {
            ID = "file_link_roapsuicj7kp1lzyus04",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = FileLinks::Type.FileLink,
            UnauthenticatedUrl = "https://example.com/file.pdf",
        };

        string expectedID = "file_link_roapsuicj7kp1lzyus04";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        ApiEnum<string, FileLinks::Type> expectedType = FileLinks::Type.FileLink;
        string expectedUnauthenticatedUrl = "https://example.com/file.pdf";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUnauthenticatedUrl, model.UnauthenticatedUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileLinks::FileLink
        {
            ID = "file_link_roapsuicj7kp1lzyus04",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = FileLinks::Type.FileLink,
            UnauthenticatedUrl = "https://example.com/file.pdf",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileLinks::FileLink>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileLinks::FileLink
        {
            ID = "file_link_roapsuicj7kp1lzyus04",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = FileLinks::Type.FileLink,
            UnauthenticatedUrl = "https://example.com/file.pdf",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileLinks::FileLink>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "file_link_roapsuicj7kp1lzyus04";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        ApiEnum<string, FileLinks::Type> expectedType = FileLinks::Type.FileLink;
        string expectedUnauthenticatedUrl = "https://example.com/file.pdf";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUnauthenticatedUrl, deserialized.UnauthenticatedUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileLinks::FileLink
        {
            ID = "file_link_roapsuicj7kp1lzyus04",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = FileLinks::Type.FileLink,
            UnauthenticatedUrl = "https://example.com/file.pdf",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileLinks::FileLink
        {
            ID = "file_link_roapsuicj7kp1lzyus04",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ExpiresAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = FileLinks::Type.FileLink,
            UnauthenticatedUrl = "https://example.com/file.pdf",
        };

        FileLinks::FileLink copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(FileLinks::Type.FileLink)]
    public void Validation_Works(FileLinks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FileLinks::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FileLinks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FileLinks::Type.FileLink)]
    public void SerializationRoundtrip_Works(FileLinks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FileLinks::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FileLinks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FileLinks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FileLinks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
