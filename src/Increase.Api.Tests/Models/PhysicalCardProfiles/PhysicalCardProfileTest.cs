using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using PhysicalCardProfiles = Increase.Api.Models.PhysicalCardProfiles;

namespace Increase.Api.Tests.Models.PhysicalCardProfiles;

public class PhysicalCardProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCardProfiles::PhysicalCardProfile
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
        };

        string expectedID = "physical_card_profile_m534d5rn9qyy9ufqxoec";
        string expectedBackImageFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedCarrierImageFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedContactPhone = "+16505046304";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, PhysicalCardProfiles::Creator> expectedCreator =
            PhysicalCardProfiles::Creator.User;
        string expectedDescription = "Corporate logo card";
        string expectedFrontImageFileID = "file_makxrc67oh9l6sg7w9yc";
        bool expectedIsDefault = false;
        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";
        ApiEnum<string, PhysicalCardProfiles::PhysicalCardProfileStatus> expectedStatus =
            PhysicalCardProfiles::PhysicalCardProfileStatus.Active;
        ApiEnum<string, PhysicalCardProfiles::Type> expectedType =
            PhysicalCardProfiles::Type.PhysicalCardProfile;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBackImageFileID, model.BackImageFileID);
        Assert.Equal(expectedCarrierImageFileID, model.CarrierImageFileID);
        Assert.Equal(expectedContactPhone, model.ContactPhone);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedFrontImageFileID, model.FrontImageFileID);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedIsDefault, model.IsDefault);
        Assert.Equal(expectedProgramID, model.ProgramID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCardProfiles::PhysicalCardProfile
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCardProfiles::PhysicalCardProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCardProfiles::PhysicalCardProfile
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCardProfiles::PhysicalCardProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "physical_card_profile_m534d5rn9qyy9ufqxoec";
        string expectedBackImageFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedCarrierImageFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedContactPhone = "+16505046304";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, PhysicalCardProfiles::Creator> expectedCreator =
            PhysicalCardProfiles::Creator.User;
        string expectedDescription = "Corporate logo card";
        string expectedFrontImageFileID = "file_makxrc67oh9l6sg7w9yc";
        bool expectedIsDefault = false;
        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";
        ApiEnum<string, PhysicalCardProfiles::PhysicalCardProfileStatus> expectedStatus =
            PhysicalCardProfiles::PhysicalCardProfileStatus.Active;
        ApiEnum<string, PhysicalCardProfiles::Type> expectedType =
            PhysicalCardProfiles::Type.PhysicalCardProfile;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBackImageFileID, deserialized.BackImageFileID);
        Assert.Equal(expectedCarrierImageFileID, deserialized.CarrierImageFileID);
        Assert.Equal(expectedContactPhone, deserialized.ContactPhone);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedFrontImageFileID, deserialized.FrontImageFileID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedIsDefault, deserialized.IsDefault);
        Assert.Equal(expectedProgramID, deserialized.ProgramID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCardProfiles::PhysicalCardProfile
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCardProfiles::PhysicalCardProfile
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
        };

        PhysicalCardProfiles::PhysicalCardProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatorTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCardProfiles::Creator.Increase)]
    [InlineData(PhysicalCardProfiles::Creator.User)]
    public void Validation_Works(PhysicalCardProfiles::Creator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCardProfiles::Creator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCardProfiles::Creator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCardProfiles::Creator.Increase)]
    [InlineData(PhysicalCardProfiles::Creator.User)]
    public void SerializationRoundtrip_Works(PhysicalCardProfiles::Creator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCardProfiles::Creator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCardProfiles::Creator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCardProfiles::Creator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCardProfiles::Creator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PhysicalCardProfileStatusTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.PendingCreating)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.PendingReviewing)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.Rejected)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.PendingSubmitting)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.Active)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.Archived)]
    public void Validation_Works(PhysicalCardProfiles::PhysicalCardProfileStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCardProfiles::PhysicalCardProfileStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCardProfiles::PhysicalCardProfileStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.PendingCreating)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.PendingReviewing)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.Rejected)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.PendingSubmitting)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.Active)]
    [InlineData(PhysicalCardProfiles::PhysicalCardProfileStatus.Archived)]
    public void SerializationRoundtrip_Works(
        PhysicalCardProfiles::PhysicalCardProfileStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCardProfiles::PhysicalCardProfileStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCardProfiles::PhysicalCardProfileStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCardProfiles::PhysicalCardProfileStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCardProfiles::PhysicalCardProfileStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCardProfiles::Type.PhysicalCardProfile)]
    public void Validation_Works(PhysicalCardProfiles::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCardProfiles::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCardProfiles::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCardProfiles::Type.PhysicalCardProfile)]
    public void SerializationRoundtrip_Works(PhysicalCardProfiles::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCardProfiles::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCardProfiles::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCardProfiles::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCardProfiles::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
