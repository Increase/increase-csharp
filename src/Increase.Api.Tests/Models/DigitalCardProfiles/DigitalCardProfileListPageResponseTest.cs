using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using DigitalCardProfiles = Increase.Api.Models.DigitalCardProfiles;

namespace Increase.Api.Tests.Models.DigitalCardProfiles;

public class DigitalCardProfileListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "digital_card_profile_s3puplu90f04xhcwkiga",
                    AppIconFileID = "file_makxrc67oh9l6sg7w9yc",
                    BackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CardDescription = "Black Card",
                    ContactEmail = "user@example.com",
                    ContactPhone = "+18882988865",
                    ContactWebsite = "https://example.com",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Corporate logo Apple Pay Card",
                    IdempotencyKey = null,
                    IssuerName = "National Phonograph Company",
                    Status = DigitalCardProfiles::DigitalCardProfileStatus.Active,
                    TextColor = new()
                    {
                        Blue = 230,
                        Green = 255,
                        Red = 189,
                    },
                    Type = DigitalCardProfiles::Type.DigitalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<DigitalCardProfiles::DigitalCardProfile> expectedData =
        [
            new()
            {
                ID = "digital_card_profile_s3puplu90f04xhcwkiga",
                AppIconFileID = "file_makxrc67oh9l6sg7w9yc",
                BackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc",
                CardDescription = "Black Card",
                ContactEmail = "user@example.com",
                ContactPhone = "+18882988865",
                ContactWebsite = "https://example.com",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "Corporate logo Apple Pay Card",
                IdempotencyKey = null,
                IssuerName = "National Phonograph Company",
                Status = DigitalCardProfiles::DigitalCardProfileStatus.Active,
                TextColor = new()
                {
                    Blue = 230,
                    Green = 255,
                    Red = 189,
                },
                Type = DigitalCardProfiles::Type.DigitalCardProfile,
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
        var model = new DigitalCardProfiles::DigitalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "digital_card_profile_s3puplu90f04xhcwkiga",
                    AppIconFileID = "file_makxrc67oh9l6sg7w9yc",
                    BackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CardDescription = "Black Card",
                    ContactEmail = "user@example.com",
                    ContactPhone = "+18882988865",
                    ContactWebsite = "https://example.com",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Corporate logo Apple Pay Card",
                    IdempotencyKey = null,
                    IssuerName = "National Phonograph Company",
                    Status = DigitalCardProfiles::DigitalCardProfileStatus.Active,
                    TextColor = new()
                    {
                        Blue = 230,
                        Green = 255,
                        Red = 189,
                    },
                    Type = DigitalCardProfiles::Type.DigitalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalCardProfiles::DigitalCardProfileListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "digital_card_profile_s3puplu90f04xhcwkiga",
                    AppIconFileID = "file_makxrc67oh9l6sg7w9yc",
                    BackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CardDescription = "Black Card",
                    ContactEmail = "user@example.com",
                    ContactPhone = "+18882988865",
                    ContactWebsite = "https://example.com",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Corporate logo Apple Pay Card",
                    IdempotencyKey = null,
                    IssuerName = "National Phonograph Company",
                    Status = DigitalCardProfiles::DigitalCardProfileStatus.Active,
                    TextColor = new()
                    {
                        Blue = 230,
                        Green = 255,
                        Red = 189,
                    },
                    Type = DigitalCardProfiles::Type.DigitalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalCardProfiles::DigitalCardProfileListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<DigitalCardProfiles::DigitalCardProfile> expectedData =
        [
            new()
            {
                ID = "digital_card_profile_s3puplu90f04xhcwkiga",
                AppIconFileID = "file_makxrc67oh9l6sg7w9yc",
                BackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc",
                CardDescription = "Black Card",
                ContactEmail = "user@example.com",
                ContactPhone = "+18882988865",
                ContactWebsite = "https://example.com",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "Corporate logo Apple Pay Card",
                IdempotencyKey = null,
                IssuerName = "National Phonograph Company",
                Status = DigitalCardProfiles::DigitalCardProfileStatus.Active,
                TextColor = new()
                {
                    Blue = 230,
                    Green = 255,
                    Red = 189,
                },
                Type = DigitalCardProfiles::Type.DigitalCardProfile,
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
        var model = new DigitalCardProfiles::DigitalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "digital_card_profile_s3puplu90f04xhcwkiga",
                    AppIconFileID = "file_makxrc67oh9l6sg7w9yc",
                    BackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CardDescription = "Black Card",
                    ContactEmail = "user@example.com",
                    ContactPhone = "+18882988865",
                    ContactWebsite = "https://example.com",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Corporate logo Apple Pay Card",
                    IdempotencyKey = null,
                    IssuerName = "National Phonograph Company",
                    Status = DigitalCardProfiles::DigitalCardProfileStatus.Active,
                    TextColor = new()
                    {
                        Blue = 230,
                        Green = 255,
                        Red = 189,
                    },
                    Type = DigitalCardProfiles::Type.DigitalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "digital_card_profile_s3puplu90f04xhcwkiga",
                    AppIconFileID = "file_makxrc67oh9l6sg7w9yc",
                    BackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CardDescription = "Black Card",
                    ContactEmail = "user@example.com",
                    ContactPhone = "+18882988865",
                    ContactWebsite = "https://example.com",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Corporate logo Apple Pay Card",
                    IdempotencyKey = null,
                    IssuerName = "National Phonograph Company",
                    Status = DigitalCardProfiles::DigitalCardProfileStatus.Active,
                    TextColor = new()
                    {
                        Blue = 230,
                        Green = 255,
                        Red = 189,
                    },
                    Type = DigitalCardProfiles::Type.DigitalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        DigitalCardProfiles::DigitalCardProfileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
