using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using IntrafiExclusions = Increase.Api.Models.IntrafiExclusions;

namespace Increase.Api.Tests.Models.IntrafiExclusions;

public class IntrafiExclusionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntrafiExclusions::IntrafiExclusionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
                    BankName = "Example Bank",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
                    FdicCertificateNumber = "314159",
                    IdempotencyKey = null,
                    Status = IntrafiExclusions::Status.Completed,
                    SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    Type = IntrafiExclusions::Type.IntrafiExclusion,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<IntrafiExclusions::IntrafiExclusion> expectedData =
        [
            new()
            {
                ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
                BankName = "Example Bank",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
                FdicCertificateNumber = "314159",
                IdempotencyKey = null,
                Status = IntrafiExclusions::Status.Completed,
                SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                Type = IntrafiExclusions::Type.IntrafiExclusion,
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
        var model = new IntrafiExclusions::IntrafiExclusionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
                    BankName = "Example Bank",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
                    FdicCertificateNumber = "314159",
                    IdempotencyKey = null,
                    Status = IntrafiExclusions::Status.Completed,
                    SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    Type = IntrafiExclusions::Type.IntrafiExclusion,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntrafiExclusions::IntrafiExclusionListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntrafiExclusions::IntrafiExclusionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
                    BankName = "Example Bank",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
                    FdicCertificateNumber = "314159",
                    IdempotencyKey = null,
                    Status = IntrafiExclusions::Status.Completed,
                    SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    Type = IntrafiExclusions::Type.IntrafiExclusion,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntrafiExclusions::IntrafiExclusionListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<IntrafiExclusions::IntrafiExclusion> expectedData =
        [
            new()
            {
                ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
                BankName = "Example Bank",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
                FdicCertificateNumber = "314159",
                IdempotencyKey = null,
                Status = IntrafiExclusions::Status.Completed,
                SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                Type = IntrafiExclusions::Type.IntrafiExclusion,
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
        var model = new IntrafiExclusions::IntrafiExclusionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
                    BankName = "Example Bank",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
                    FdicCertificateNumber = "314159",
                    IdempotencyKey = null,
                    Status = IntrafiExclusions::Status.Completed,
                    SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    Type = IntrafiExclusions::Type.IntrafiExclusion,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntrafiExclusions::IntrafiExclusionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
                    BankName = "Example Bank",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
                    FdicCertificateNumber = "314159",
                    IdempotencyKey = null,
                    Status = IntrafiExclusions::Status.Completed,
                    SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
                    Type = IntrafiExclusions::Type.IntrafiExclusion,
                },
            ],
            NextCursor = "v57w5d",
        };

        IntrafiExclusions::IntrafiExclusionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
