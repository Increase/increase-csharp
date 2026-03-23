using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.DigitalCardProfiles;

namespace Increase.Api.Tests.Models.DigitalCardProfiles;

public class DigitalCardProfileCloneParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DigitalCardProfileCloneParams
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
            AppIconFileID = "app_icon_file_id",
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "x",
            ContactEmail = "dev@stainless.com",
            ContactPhone = "x",
            ContactWebsite = "contact_website",
            Description = "x",
            IssuerName = "x",
            TextColor = new()
            {
                Blue = 0,
                Green = 0,
                Red = 0,
            },
        };

        string expectedDigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga";
        string expectedAppIconFileID = "app_icon_file_id";
        string expectedBackgroundImageFileID = "file_1ai913suu1zfn1pdetru";
        string expectedCardDescription = "x";
        string expectedContactEmail = "dev@stainless.com";
        string expectedContactPhone = "x";
        string expectedContactWebsite = "contact_website";
        string expectedDescription = "x";
        string expectedIssuerName = "x";
        DigitalCardProfileCloneParamsTextColor expectedTextColor = new()
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        Assert.Equal(expectedDigitalCardProfileID, parameters.DigitalCardProfileID);
        Assert.Equal(expectedAppIconFileID, parameters.AppIconFileID);
        Assert.Equal(expectedBackgroundImageFileID, parameters.BackgroundImageFileID);
        Assert.Equal(expectedCardDescription, parameters.CardDescription);
        Assert.Equal(expectedContactEmail, parameters.ContactEmail);
        Assert.Equal(expectedContactPhone, parameters.ContactPhone);
        Assert.Equal(expectedContactWebsite, parameters.ContactWebsite);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedIssuerName, parameters.IssuerName);
        Assert.Equal(expectedTextColor, parameters.TextColor);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DigitalCardProfileCloneParams
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
        };

        Assert.Null(parameters.AppIconFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("app_icon_file_id"));
        Assert.Null(parameters.BackgroundImageFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("background_image_file_id"));
        Assert.Null(parameters.CardDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("card_description"));
        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.ContactPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_phone"));
        Assert.Null(parameters.ContactWebsite);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_website"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.IssuerName);
        Assert.False(parameters.RawBodyData.ContainsKey("issuer_name"));
        Assert.Null(parameters.TextColor);
        Assert.False(parameters.RawBodyData.ContainsKey("text_color"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DigitalCardProfileCloneParams
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",

            // Null should be interpreted as omitted for these properties
            AppIconFileID = null,
            BackgroundImageFileID = null,
            CardDescription = null,
            ContactEmail = null,
            ContactPhone = null,
            ContactWebsite = null,
            Description = null,
            IssuerName = null,
            TextColor = null,
        };

        Assert.Null(parameters.AppIconFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("app_icon_file_id"));
        Assert.Null(parameters.BackgroundImageFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("background_image_file_id"));
        Assert.Null(parameters.CardDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("card_description"));
        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.ContactPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_phone"));
        Assert.Null(parameters.ContactWebsite);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_website"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.IssuerName);
        Assert.False(parameters.RawBodyData.ContainsKey("issuer_name"));
        Assert.Null(parameters.TextColor);
        Assert.False(parameters.RawBodyData.ContainsKey("text_color"));
    }

    [Fact]
    public void Url_Works()
    {
        DigitalCardProfileCloneParams parameters = new()
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/digital_card_profiles/digital_card_profile_s3puplu90f04xhcwkiga/clone"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DigitalCardProfileCloneParams
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
            AppIconFileID = "app_icon_file_id",
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "x",
            ContactEmail = "dev@stainless.com",
            ContactPhone = "x",
            ContactWebsite = "contact_website",
            Description = "x",
            IssuerName = "x",
            TextColor = new()
            {
                Blue = 0,
                Green = 0,
                Red = 0,
            },
        };

        DigitalCardProfileCloneParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DigitalCardProfileCloneParamsTextColorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalCardProfileCloneParamsTextColor
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
        var model = new DigitalCardProfileCloneParamsTextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalCardProfileCloneParamsTextColor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalCardProfileCloneParamsTextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalCardProfileCloneParamsTextColor>(
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
        var model = new DigitalCardProfileCloneParamsTextColor
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
        var model = new DigitalCardProfileCloneParamsTextColor
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        DigitalCardProfileCloneParamsTextColor copied = new(model);

        Assert.Equal(model, copied);
    }
}
