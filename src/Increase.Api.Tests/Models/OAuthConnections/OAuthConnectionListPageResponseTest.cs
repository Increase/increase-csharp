using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using OAuthConnections = Increase.Api.Models.OAuthConnections;

namespace Increase.Api.Tests.Models.OAuthConnections;

public class OAuthConnectionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OAuthConnections::OAuthConnectionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "connection_dauknoksyr4wilz4e6my",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    GroupID = "group_1g4mhziu6kvrs3vz35um",
                    OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
                    Status = OAuthConnections::OAuthConnectionStatus.Active,
                    Type = OAuthConnections::Type.OAuthConnection,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<OAuthConnections::OAuthConnection> expectedData =
        [
            new()
            {
                ID = "connection_dauknoksyr4wilz4e6my",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DeletedAt = null,
                GroupID = "group_1g4mhziu6kvrs3vz35um",
                OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
                Status = OAuthConnections::OAuthConnectionStatus.Active,
                Type = OAuthConnections::Type.OAuthConnection,
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
        var model = new OAuthConnections::OAuthConnectionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "connection_dauknoksyr4wilz4e6my",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    GroupID = "group_1g4mhziu6kvrs3vz35um",
                    OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
                    Status = OAuthConnections::OAuthConnectionStatus.Active,
                    Type = OAuthConnections::Type.OAuthConnection,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OAuthConnections::OAuthConnectionListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OAuthConnections::OAuthConnectionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "connection_dauknoksyr4wilz4e6my",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    GroupID = "group_1g4mhziu6kvrs3vz35um",
                    OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
                    Status = OAuthConnections::OAuthConnectionStatus.Active,
                    Type = OAuthConnections::Type.OAuthConnection,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OAuthConnections::OAuthConnectionListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<OAuthConnections::OAuthConnection> expectedData =
        [
            new()
            {
                ID = "connection_dauknoksyr4wilz4e6my",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DeletedAt = null,
                GroupID = "group_1g4mhziu6kvrs3vz35um",
                OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
                Status = OAuthConnections::OAuthConnectionStatus.Active,
                Type = OAuthConnections::Type.OAuthConnection,
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
        var model = new OAuthConnections::OAuthConnectionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "connection_dauknoksyr4wilz4e6my",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    GroupID = "group_1g4mhziu6kvrs3vz35um",
                    OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
                    Status = OAuthConnections::OAuthConnectionStatus.Active,
                    Type = OAuthConnections::Type.OAuthConnection,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OAuthConnections::OAuthConnectionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "connection_dauknoksyr4wilz4e6my",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    GroupID = "group_1g4mhziu6kvrs3vz35um",
                    OAuthApplicationID = "application_gj9ufmpgh5i56k4vyriy",
                    Status = OAuthConnections::OAuthConnectionStatus.Active,
                    Type = OAuthConnections::Type.OAuthConnection,
                },
            ],
            NextCursor = "v57w5d",
        };

        OAuthConnections::OAuthConnectionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
