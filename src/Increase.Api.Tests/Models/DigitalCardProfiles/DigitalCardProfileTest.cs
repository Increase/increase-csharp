using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using DigitalCardProfiles = Increase.Api.Models.DigitalCardProfiles;

namespace Increase.Api.Tests.Models.DigitalCardProfiles;

public class DigitalCardProfileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfile
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
        };

        string expectedID = "digital_card_profile_s3puplu90f04xhcwkiga";
        string expectedAppIconFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedBackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedCardDescription = "Black Card";
        string expectedContactEmail = "user@example.com";
        string expectedContactPhone = "+18882988865";
        string expectedContactWebsite = "https://example.com";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Corporate logo Apple Pay Card";
        string expectedIssuerName = "National Phonograph Company";
        ApiEnum<string, DigitalCardProfiles::DigitalCardProfileStatus> expectedStatus =
            DigitalCardProfiles::DigitalCardProfileStatus.Active;
        DigitalCardProfiles::DigitalCardProfileTextColor expectedTextColor = new()
        {
            Blue = 230,
            Green = 255,
            Red = 189,
        };
        ApiEnum<string, DigitalCardProfiles::Type> expectedType =
            DigitalCardProfiles::Type.DigitalCardProfile;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAppIconFileID, model.AppIconFileID);
        Assert.Equal(expectedBackgroundImageFileID, model.BackgroundImageFileID);
        Assert.Equal(expectedCardDescription, model.CardDescription);
        Assert.Equal(expectedContactEmail, model.ContactEmail);
        Assert.Equal(expectedContactPhone, model.ContactPhone);
        Assert.Equal(expectedContactWebsite, model.ContactWebsite);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedIssuerName, model.IssuerName);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTextColor, model.TextColor);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfile
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalCardProfiles::DigitalCardProfile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfile
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalCardProfiles::DigitalCardProfile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "digital_card_profile_s3puplu90f04xhcwkiga";
        string expectedAppIconFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedBackgroundImageFileID = "file_makxrc67oh9l6sg7w9yc";
        string expectedCardDescription = "Black Card";
        string expectedContactEmail = "user@example.com";
        string expectedContactPhone = "+18882988865";
        string expectedContactWebsite = "https://example.com";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Corporate logo Apple Pay Card";
        string expectedIssuerName = "National Phonograph Company";
        ApiEnum<string, DigitalCardProfiles::DigitalCardProfileStatus> expectedStatus =
            DigitalCardProfiles::DigitalCardProfileStatus.Active;
        DigitalCardProfiles::DigitalCardProfileTextColor expectedTextColor = new()
        {
            Blue = 230,
            Green = 255,
            Red = 189,
        };
        ApiEnum<string, DigitalCardProfiles::Type> expectedType =
            DigitalCardProfiles::Type.DigitalCardProfile;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAppIconFileID, deserialized.AppIconFileID);
        Assert.Equal(expectedBackgroundImageFileID, deserialized.BackgroundImageFileID);
        Assert.Equal(expectedCardDescription, deserialized.CardDescription);
        Assert.Equal(expectedContactEmail, deserialized.ContactEmail);
        Assert.Equal(expectedContactPhone, deserialized.ContactPhone);
        Assert.Equal(expectedContactWebsite, deserialized.ContactWebsite);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedIssuerName, deserialized.IssuerName);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTextColor, deserialized.TextColor);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfile
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfile
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
        };

        DigitalCardProfiles::DigitalCardProfile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalCardProfileStatusTest : TestBase
{
    [Theory]
    [InlineData(DigitalCardProfiles::DigitalCardProfileStatus.Pending)]
    [InlineData(DigitalCardProfiles::DigitalCardProfileStatus.Rejected)]
    [InlineData(DigitalCardProfiles::DigitalCardProfileStatus.Active)]
    [InlineData(DigitalCardProfiles::DigitalCardProfileStatus.Archived)]
    public void Validation_Works(DigitalCardProfiles::DigitalCardProfileStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalCardProfiles::DigitalCardProfileStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalCardProfiles::DigitalCardProfileStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalCardProfiles::DigitalCardProfileStatus.Pending)]
    [InlineData(DigitalCardProfiles::DigitalCardProfileStatus.Rejected)]
    [InlineData(DigitalCardProfiles::DigitalCardProfileStatus.Active)]
    [InlineData(DigitalCardProfiles::DigitalCardProfileStatus.Archived)]
    public void SerializationRoundtrip_Works(DigitalCardProfiles::DigitalCardProfileStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalCardProfiles::DigitalCardProfileStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalCardProfiles::DigitalCardProfileStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalCardProfiles::DigitalCardProfileStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DigitalCardProfiles::DigitalCardProfileStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DigitalCardProfileTextColorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfileTextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        long expectedBlue = 0;
        long expectedGreen = 0;
        long expectedRed = 0;

        Assert.Equal(expectedBlue, model.Blue);
        Assert.Equal(expectedGreen, model.Green);
        Assert.Equal(expectedRed, model.Red);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfileTextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalCardProfiles::DigitalCardProfileTextColor>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfileTextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalCardProfiles::DigitalCardProfileTextColor>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedBlue = 0;
        long expectedGreen = 0;
        long expectedRed = 0;

        Assert.Equal(expectedBlue, deserialized.Blue);
        Assert.Equal(expectedGreen, deserialized.Green);
        Assert.Equal(expectedRed, deserialized.Red);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfileTextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalCardProfiles::DigitalCardProfileTextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        DigitalCardProfiles::DigitalCardProfileTextColor copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(DigitalCardProfiles::Type.DigitalCardProfile)]
    public void Validation_Works(DigitalCardProfiles::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalCardProfiles::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalCardProfiles::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DigitalCardProfiles::Type.DigitalCardProfile)]
    public void SerializationRoundtrip_Works(DigitalCardProfiles::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DigitalCardProfiles::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigitalCardProfiles::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DigitalCardProfiles::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DigitalCardProfiles::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
