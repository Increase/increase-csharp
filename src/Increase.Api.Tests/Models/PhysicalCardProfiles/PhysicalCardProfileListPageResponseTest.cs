using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using PhysicalCardProfiles = Increase.Api.Models.PhysicalCardProfiles;

namespace Increase.Api.Tests.Models.PhysicalCardProfiles;

public class PhysicalCardProfileListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCardProfiles::PhysicalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CarrierImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    ContactPhone = "+16505046304",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Creator = PhysicalCardProfiles::Creator.User,
                    Description = "Corporate logo card",
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    IsDefault = false,
                    ProgramID = "program_i2v2os4mwza1oetokh9i",
                    Status = PhysicalCardProfiles::PhysicalCardProfileStatus.Active,
                    Type = PhysicalCardProfiles::Type.PhysicalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<PhysicalCardProfiles::PhysicalCardProfile> expectedData =
        [
            new()
            {
                ID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                CarrierImageFileID = "file_makxrc67oh9l6sg7w9yc",
                ContactPhone = "+16505046304",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Creator = PhysicalCardProfiles::Creator.User,
                Description = "Corporate logo card",
                FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                IdempotencyKey = null,
                IsDefault = false,
                ProgramID = "program_i2v2os4mwza1oetokh9i",
                Status = PhysicalCardProfiles::PhysicalCardProfileStatus.Active,
                Type = PhysicalCardProfiles::Type.PhysicalCardProfile,
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
        var model = new PhysicalCardProfiles::PhysicalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CarrierImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    ContactPhone = "+16505046304",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Creator = PhysicalCardProfiles::Creator.User,
                    Description = "Corporate logo card",
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    IsDefault = false,
                    ProgramID = "program_i2v2os4mwza1oetokh9i",
                    Status = PhysicalCardProfiles::PhysicalCardProfileStatus.Active,
                    Type = PhysicalCardProfiles::Type.PhysicalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PhysicalCardProfiles::PhysicalCardProfileListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCardProfiles::PhysicalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CarrierImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    ContactPhone = "+16505046304",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Creator = PhysicalCardProfiles::Creator.User,
                    Description = "Corporate logo card",
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    IsDefault = false,
                    ProgramID = "program_i2v2os4mwza1oetokh9i",
                    Status = PhysicalCardProfiles::PhysicalCardProfileStatus.Active,
                    Type = PhysicalCardProfiles::Type.PhysicalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PhysicalCardProfiles::PhysicalCardProfileListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<PhysicalCardProfiles::PhysicalCardProfile> expectedData =
        [
            new()
            {
                ID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                CarrierImageFileID = "file_makxrc67oh9l6sg7w9yc",
                ContactPhone = "+16505046304",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Creator = PhysicalCardProfiles::Creator.User,
                Description = "Corporate logo card",
                FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                IdempotencyKey = null,
                IsDefault = false,
                ProgramID = "program_i2v2os4mwza1oetokh9i",
                Status = PhysicalCardProfiles::PhysicalCardProfileStatus.Active,
                Type = PhysicalCardProfiles::Type.PhysicalCardProfile,
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
        var model = new PhysicalCardProfiles::PhysicalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CarrierImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    ContactPhone = "+16505046304",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Creator = PhysicalCardProfiles::Creator.User,
                    Description = "Corporate logo card",
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    IsDefault = false,
                    ProgramID = "program_i2v2os4mwza1oetokh9i",
                    Status = PhysicalCardProfiles::PhysicalCardProfileStatus.Active,
                    Type = PhysicalCardProfiles::Type.PhysicalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCardProfiles::PhysicalCardProfileListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    CarrierImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    ContactPhone = "+16505046304",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Creator = PhysicalCardProfiles::Creator.User,
                    Description = "Corporate logo card",
                    FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                    IdempotencyKey = null,
                    IsDefault = false,
                    ProgramID = "program_i2v2os4mwza1oetokh9i",
                    Status = PhysicalCardProfiles::PhysicalCardProfileStatus.Active,
                    Type = PhysicalCardProfiles::Type.PhysicalCardProfile,
                },
            ],
            NextCursor = "v57w5d",
        };

        PhysicalCardProfiles::PhysicalCardProfileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
