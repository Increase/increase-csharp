using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using SupplementalDocuments = Increase.Api.Models.SupplementalDocuments;

namespace Increase.Api.Tests.Models.SupplementalDocuments;

public class EntitySupplementalDocumentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SupplementalDocuments::EntitySupplementalDocument
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = SupplementalDocuments::Type.EntitySupplementalDocument,
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        ApiEnum<string, SupplementalDocuments::Type> expectedType =
            SupplementalDocuments::Type.EntitySupplementalDocument;

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SupplementalDocuments::EntitySupplementalDocument
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = SupplementalDocuments::Type.EntitySupplementalDocument,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SupplementalDocuments::EntitySupplementalDocument>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SupplementalDocuments::EntitySupplementalDocument
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = SupplementalDocuments::Type.EntitySupplementalDocument,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SupplementalDocuments::EntitySupplementalDocument>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";
        ApiEnum<string, SupplementalDocuments::Type> expectedType =
            SupplementalDocuments::Type.EntitySupplementalDocument;

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SupplementalDocuments::EntitySupplementalDocument
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = SupplementalDocuments::Type.EntitySupplementalDocument,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SupplementalDocuments::EntitySupplementalDocument
        {
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FileID = "file_makxrc67oh9l6sg7w9yc",
            IdempotencyKey = null,
            Type = SupplementalDocuments::Type.EntitySupplementalDocument,
        };

        SupplementalDocuments::EntitySupplementalDocument copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(SupplementalDocuments::Type.EntitySupplementalDocument)]
    public void Validation_Works(SupplementalDocuments::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SupplementalDocuments::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SupplementalDocuments::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SupplementalDocuments::Type.EntitySupplementalDocument)]
    public void SerializationRoundtrip_Works(SupplementalDocuments::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SupplementalDocuments::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SupplementalDocuments::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SupplementalDocuments::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SupplementalDocuments::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
