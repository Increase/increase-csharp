using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Files = Increase.Api.Models.Files;

namespace Increase.Api.Tests.Models.Files;

public class FileListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::FileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "file_makxrc67oh9l6sg7w9yc",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "2022-05 statement for checking account",
                    Direction = Files::Direction.FromIncrease,
                    Filename = "statement.pdf",
                    IdempotencyKey = null,
                    MimeType = "application/pdf",
                    Purpose = Files::FilePurpose.IncreaseStatement,
                    Type = Files::Type.File,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Files::File> expectedData =
        [
            new()
            {
                ID = "file_makxrc67oh9l6sg7w9yc",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "2022-05 statement for checking account",
                Direction = Files::Direction.FromIncrease,
                Filename = "statement.pdf",
                IdempotencyKey = null,
                MimeType = "application/pdf",
                Purpose = Files::FilePurpose.IncreaseStatement,
                Type = Files::Type.File,
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
        var model = new Files::FileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "file_makxrc67oh9l6sg7w9yc",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "2022-05 statement for checking account",
                    Direction = Files::Direction.FromIncrease,
                    Filename = "statement.pdf",
                    IdempotencyKey = null,
                    MimeType = "application/pdf",
                    Purpose = Files::FilePurpose.IncreaseStatement,
                    Type = Files::Type.File,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::FileListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::FileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "file_makxrc67oh9l6sg7w9yc",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "2022-05 statement for checking account",
                    Direction = Files::Direction.FromIncrease,
                    Filename = "statement.pdf",
                    IdempotencyKey = null,
                    MimeType = "application/pdf",
                    Purpose = Files::FilePurpose.IncreaseStatement,
                    Type = Files::Type.File,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::FileListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Files::File> expectedData =
        [
            new()
            {
                ID = "file_makxrc67oh9l6sg7w9yc",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "2022-05 statement for checking account",
                Direction = Files::Direction.FromIncrease,
                Filename = "statement.pdf",
                IdempotencyKey = null,
                MimeType = "application/pdf",
                Purpose = Files::FilePurpose.IncreaseStatement,
                Type = Files::Type.File,
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
        var model = new Files::FileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "file_makxrc67oh9l6sg7w9yc",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "2022-05 statement for checking account",
                    Direction = Files::Direction.FromIncrease,
                    Filename = "statement.pdf",
                    IdempotencyKey = null,
                    MimeType = "application/pdf",
                    Purpose = Files::FilePurpose.IncreaseStatement,
                    Type = Files::Type.File,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Files::FileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "file_makxrc67oh9l6sg7w9yc",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "2022-05 statement for checking account",
                    Direction = Files::Direction.FromIncrease,
                    Filename = "statement.pdf",
                    IdempotencyKey = null,
                    MimeType = "application/pdf",
                    Purpose = Files::FilePurpose.IncreaseStatement,
                    Type = Files::Type.File,
                },
            ],
            NextCursor = "v57w5d",
        };

        Files::FileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
