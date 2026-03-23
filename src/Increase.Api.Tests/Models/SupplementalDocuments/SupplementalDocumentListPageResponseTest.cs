using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using SupplementalDocuments = Increase.Api.Models.SupplementalDocuments;

namespace Increase.Api.Tests.Models.SupplementalDocuments;

public class SupplementalDocumentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SupplementalDocuments::SupplementalDocumentListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<SupplementalDocuments::EntitySupplementalDocument> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                FileID = "file_makxrc67oh9l6sg7w9yc",
                IdempotencyKey = null,
                Type = SupplementalDocuments::Type.EntitySupplementalDocument,
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SupplementalDocuments::SupplementalDocumentListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SupplementalDocuments::SupplementalDocumentListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SupplementalDocuments::SupplementalDocumentListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SupplementalDocuments::SupplementalDocumentListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<SupplementalDocuments::EntitySupplementalDocument> expectedData =
        [
            new()
            {
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                FileID = "file_makxrc67oh9l6sg7w9yc",
                IdempotencyKey = null,
                Type = SupplementalDocuments::Type.EntitySupplementalDocument,
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SupplementalDocuments::SupplementalDocumentListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SupplementalDocuments::SupplementalDocumentListPageResponse
        {
            Data =
            [
                new()
                {
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    FileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    Type = SupplementalDocuments::Type.EntitySupplementalDocument,
                },
            ],
            NextCursor = "v57w5d",
        };

        SupplementalDocuments::SupplementalDocumentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
