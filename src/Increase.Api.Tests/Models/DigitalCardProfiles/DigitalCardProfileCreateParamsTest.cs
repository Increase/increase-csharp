using System;
using System.Collections.Generic;
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
            CardDescription = "National Phonograph Card",
            Description = "My Card Profile",
            ApplePay = new()
            {
                AssociatedApplicationIdentifiers =
                [
                    new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
                ],
                AssociatedStoreIdentifiers = [new("26")],
            },
            ContactEmail = "user@example.com",
            ContactName = "National Phonograph Company",
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
        string expectedCardDescription = "National Phonograph Card";
        string expectedDescription = "My Card Profile";
        ApplePay expectedApplePay = new()
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };
        string expectedContactEmail = "user@example.com";
        string expectedContactName = "National Phonograph Company";
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
        Assert.Equal(expectedApplePay, parameters.ApplePay);
        Assert.Equal(expectedContactEmail, parameters.ContactEmail);
        Assert.Equal(expectedContactName, parameters.ContactName);
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
            CardDescription = "National Phonograph Card",
            Description = "My Card Profile",
        };

        Assert.Null(parameters.ApplePay);
        Assert.False(parameters.RawBodyData.ContainsKey("apple_pay"));
        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.ContactName);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_name"));
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
            CardDescription = "National Phonograph Card",
            Description = "My Card Profile",

            // Null should be interpreted as omitted for these properties
            ApplePay = null,
            ContactEmail = null,
            ContactName = null,
            ContactPhone = null,
            ContactWebsite = null,
            TextColor = null,
        };

        Assert.Null(parameters.ApplePay);
        Assert.False(parameters.RawBodyData.ContainsKey("apple_pay"));
        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.ContactName);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_name"));
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
            CardDescription = "National Phonograph Card",
            Description = "My Card Profile",
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
            CardDescription = "National Phonograph Card",
            Description = "My Card Profile",
            ApplePay = new()
            {
                AssociatedApplicationIdentifiers =
                [
                    new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
                ],
                AssociatedStoreIdentifiers = [new("26")],
            },
            ContactEmail = "user@example.com",
            ContactName = "National Phonograph Company",
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

public class ApplePayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        List<AssociatedApplicationIdentifier> expectedAssociatedApplicationIdentifiers =
        [
            new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
        ];
        List<AssociatedStoreIdentifier> expectedAssociatedStoreIdentifiers = [new("26")];

        Assert.NotNull(model.AssociatedApplicationIdentifiers);
        Assert.Equal(
            expectedAssociatedApplicationIdentifiers.Count,
            model.AssociatedApplicationIdentifiers.Count
        );
        for (int i = 0; i < expectedAssociatedApplicationIdentifiers.Count; i++)
        {
            Assert.Equal(
                expectedAssociatedApplicationIdentifiers[i],
                model.AssociatedApplicationIdentifiers[i]
            );
        }
        Assert.NotNull(model.AssociatedStoreIdentifiers);
        Assert.Equal(
            expectedAssociatedStoreIdentifiers.Count,
            model.AssociatedStoreIdentifiers.Count
        );
        for (int i = 0; i < expectedAssociatedStoreIdentifiers.Count; i++)
        {
            Assert.Equal(
                expectedAssociatedStoreIdentifiers[i],
                model.AssociatedStoreIdentifiers[i]
            );
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApplePay>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApplePay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AssociatedApplicationIdentifier> expectedAssociatedApplicationIdentifiers =
        [
            new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
        ];
        List<AssociatedStoreIdentifier> expectedAssociatedStoreIdentifiers = [new("26")];

        Assert.NotNull(deserialized.AssociatedApplicationIdentifiers);
        Assert.Equal(
            expectedAssociatedApplicationIdentifiers.Count,
            deserialized.AssociatedApplicationIdentifiers.Count
        );
        for (int i = 0; i < expectedAssociatedApplicationIdentifiers.Count; i++)
        {
            Assert.Equal(
                expectedAssociatedApplicationIdentifiers[i],
                deserialized.AssociatedApplicationIdentifiers[i]
            );
        }
        Assert.NotNull(deserialized.AssociatedStoreIdentifiers);
        Assert.Equal(
            expectedAssociatedStoreIdentifiers.Count,
            deserialized.AssociatedStoreIdentifiers.Count
        );
        for (int i = 0; i < expectedAssociatedStoreIdentifiers.Count; i++)
        {
            Assert.Equal(
                expectedAssociatedStoreIdentifiers[i],
                deserialized.AssociatedStoreIdentifiers[i]
            );
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApplePay { };

        Assert.Null(model.AssociatedApplicationIdentifiers);
        Assert.False(model.RawData.ContainsKey("associated_application_identifiers"));
        Assert.Null(model.AssociatedStoreIdentifiers);
        Assert.False(model.RawData.ContainsKey("associated_store_identifiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApplePay { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApplePay
        {
            // Null should be interpreted as omitted for these properties
            AssociatedApplicationIdentifiers = null,
            AssociatedStoreIdentifiers = null,
        };

        Assert.Null(model.AssociatedApplicationIdentifiers);
        Assert.False(model.RawData.ContainsKey("associated_application_identifiers"));
        Assert.Null(model.AssociatedStoreIdentifiers);
        Assert.False(model.RawData.ContainsKey("associated_store_identifiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApplePay
        {
            // Null should be interpreted as omitted for these properties
            AssociatedApplicationIdentifiers = null,
            AssociatedStoreIdentifiers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        ApplePay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AssociatedApplicationIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        string expectedIdentifier =
            "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssociatedApplicationIdentifier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssociatedApplicationIdentifier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedIdentifier =
            "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N";

        Assert.Equal(expectedIdentifier, deserialized.Identifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        AssociatedApplicationIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AssociatedStoreIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AssociatedStoreIdentifier { Identifier = "26" };

        string expectedIdentifier = "26";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AssociatedStoreIdentifier { Identifier = "26" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssociatedStoreIdentifier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AssociatedStoreIdentifier { Identifier = "26" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AssociatedStoreIdentifier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedIdentifier = "26";

        Assert.Equal(expectedIdentifier, deserialized.Identifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AssociatedStoreIdentifier { Identifier = "26" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AssociatedStoreIdentifier { Identifier = "26" };

        AssociatedStoreIdentifier copied = new(model);

        Assert.Equal(model, copied);
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
