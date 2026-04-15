using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.DigitalCardProfiles;

namespace Increase.Api.Tests.Models.DigitalCardProfiles;

public class DigitalCardProfileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DigitalCardProfileCreateParams
        {
            AppIconFileID = "file_8zxqkwlh43wo144u8yec",
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "MyBank Signature Card",
            Description = "My Card Profile",
            IssuerName = "MyBank",
            ContactEmail = "user@example.com",
            ContactPhone = "+18885551212",
            ContactWebsite = "https://example.com",
            TextColor = new()
            {
                Blue = 59,
                Green = 43,
                Red = 26,
            },
        };

        string expectedAppIconFileID = "file_8zxqkwlh43wo144u8yec";
        string expectedBackgroundImageFileID = "file_1ai913suu1zfn1pdetru";
        string expectedCardDescription = "MyBank Signature Card";
        string expectedDescription = "My Card Profile";
        string expectedIssuerName = "MyBank";
        string expectedContactEmail = "user@example.com";
        string expectedContactPhone = "+18885551212";
        string expectedContactWebsite = "https://example.com";
        TextColor expectedTextColor = new()
        {
            Blue = 59,
            Green = 43,
            Red = 26,
        };

        Assert.Equal(expectedAppIconFileID, parameters.AppIconFileID);
        Assert.Equal(expectedBackgroundImageFileID, parameters.BackgroundImageFileID);
        Assert.Equal(expectedCardDescription, parameters.CardDescription);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedIssuerName, parameters.IssuerName);
        Assert.Equal(expectedContactEmail, parameters.ContactEmail);
        Assert.Equal(expectedContactPhone, parameters.ContactPhone);
        Assert.Equal(expectedContactWebsite, parameters.ContactWebsite);
        Assert.Equal(expectedTextColor, parameters.TextColor);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DigitalCardProfileCreateParams
        {
            AppIconFileID = "file_8zxqkwlh43wo144u8yec",
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "MyBank Signature Card",
            Description = "My Card Profile",
            IssuerName = "MyBank",
        };

        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.ContactPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_phone"));
        Assert.Null(parameters.ContactWebsite);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_website"));
        Assert.Null(parameters.TextColor);
        Assert.False(parameters.RawBodyData.ContainsKey("text_color"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DigitalCardProfileCreateParams
        {
            AppIconFileID = "file_8zxqkwlh43wo144u8yec",
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "MyBank Signature Card",
            Description = "My Card Profile",
            IssuerName = "MyBank",

            // Null should be interpreted as omitted for these properties
            ContactEmail = null,
            ContactPhone = null,
            ContactWebsite = null,
            TextColor = null,
        };

        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.ContactPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_phone"));
        Assert.Null(parameters.ContactWebsite);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_website"));
        Assert.Null(parameters.TextColor);
        Assert.False(parameters.RawBodyData.ContainsKey("text_color"));
    }

    [Fact]
    public void Url_Works()
    {
        DigitalCardProfileCreateParams parameters = new()
        {
            AppIconFileID = "file_8zxqkwlh43wo144u8yec",
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "MyBank Signature Card",
            Description = "My Card Profile",
            IssuerName = "MyBank",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/digital_card_profiles"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DigitalCardProfileCreateParams
        {
            AppIconFileID = "file_8zxqkwlh43wo144u8yec",
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "MyBank Signature Card",
            Description = "My Card Profile",
            IssuerName = "MyBank",
            ContactEmail = "user@example.com",
            ContactPhone = "+18885551212",
            ContactWebsite = "https://example.com",
            TextColor = new()
            {
                Blue = 59,
                Green = 43,
                Red = 26,
            },
        };

        DigitalCardProfileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TextColorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextColor
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
        var model = new TextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextColor>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextColor>(
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
        var model = new TextColor
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
        var model = new TextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        TextColor copied = new(model);

        Assert.Equal(model, copied);
    }
}
