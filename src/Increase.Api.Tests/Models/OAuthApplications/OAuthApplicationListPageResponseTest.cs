using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using OAuthApplications = Increase.Api.Models.OAuthApplications;

namespace Increase.Api.Tests.Models.OAuthApplications;

public class OAuthApplicationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OAuthApplications::OAuthApplicationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "application_gj9ufmpgh5i56k4vyriy",
                    ClientID = "client_id_ec79nb1bukwwafdewe88",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    Name = "Ian Crease's App",
                    Status = OAuthApplications::OAuthApplicationStatus.Active,
                    Type = OAuthApplications::Type.OAuthApplication,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<OAuthApplications::OAuthApplication> expectedData =
        [
            new()
            {
                ID = "application_gj9ufmpgh5i56k4vyriy",
                ClientID = "client_id_ec79nb1bukwwafdewe88",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DeletedAt = null,
                Name = "Ian Crease's App",
                Status = OAuthApplications::OAuthApplicationStatus.Active,
                Type = OAuthApplications::Type.OAuthApplication,
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
        var model = new OAuthApplications::OAuthApplicationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "application_gj9ufmpgh5i56k4vyriy",
                    ClientID = "client_id_ec79nb1bukwwafdewe88",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    Name = "Ian Crease's App",
                    Status = OAuthApplications::OAuthApplicationStatus.Active,
                    Type = OAuthApplications::Type.OAuthApplication,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OAuthApplications::OAuthApplicationListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OAuthApplications::OAuthApplicationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "application_gj9ufmpgh5i56k4vyriy",
                    ClientID = "client_id_ec79nb1bukwwafdewe88",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    Name = "Ian Crease's App",
                    Status = OAuthApplications::OAuthApplicationStatus.Active,
                    Type = OAuthApplications::Type.OAuthApplication,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<OAuthApplications::OAuthApplicationListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<OAuthApplications::OAuthApplication> expectedData =
        [
            new()
            {
                ID = "application_gj9ufmpgh5i56k4vyriy",
                ClientID = "client_id_ec79nb1bukwwafdewe88",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DeletedAt = null,
                Name = "Ian Crease's App",
                Status = OAuthApplications::OAuthApplicationStatus.Active,
                Type = OAuthApplications::Type.OAuthApplication,
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
        var model = new OAuthApplications::OAuthApplicationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "application_gj9ufmpgh5i56k4vyriy",
                    ClientID = "client_id_ec79nb1bukwwafdewe88",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    Name = "Ian Crease's App",
                    Status = OAuthApplications::OAuthApplicationStatus.Active,
                    Type = OAuthApplications::Type.OAuthApplication,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OAuthApplications::OAuthApplicationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "application_gj9ufmpgh5i56k4vyriy",
                    ClientID = "client_id_ec79nb1bukwwafdewe88",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DeletedAt = null,
                    Name = "Ian Crease's App",
                    Status = OAuthApplications::OAuthApplicationStatus.Active,
                    Type = OAuthApplications::Type.OAuthApplication,
                },
            ],
            NextCursor = "v57w5d",
        };

        OAuthApplications::OAuthApplicationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
