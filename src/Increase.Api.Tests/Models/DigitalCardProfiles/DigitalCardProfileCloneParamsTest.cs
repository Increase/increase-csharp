using System;
using System.Collections.Generic;
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
            ApplePay = new()
            {
                AssociatedApplicationIdentifiers =
                [
                    new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
                ],
                AssociatedStoreIdentifiers = [new("26")],
            },
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "x",
            ContactEmail = "dev@stainless.com",
            ContactName = "x",
            ContactPhone = "x",
            ContactWebsite = "contact_website",
            Description = "x",
            TextColor = new()
            {
                Blue = 0,
                Green = 0,
                Red = 0,
            },
        };

        string expectedDigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga";
        string expectedAppIconFileID = "app_icon_file_id";
        DigitalCardProfileCloneParamsApplePay expectedApplePay = new()
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };
        string expectedBackgroundImageFileID = "file_1ai913suu1zfn1pdetru";
        string expectedCardDescription = "x";
        string expectedContactEmail = "dev@stainless.com";
        string expectedContactName = "x";
        string expectedContactPhone = "x";
        string expectedContactWebsite = "contact_website";
        string expectedDescription = "x";
        DigitalCardProfileCloneParamsTextColor expectedTextColor = new()
        {
            Blue = 0,
            Green = 0,
            Red = 0,
        };

        Assert.Equal(expectedDigitalCardProfileID, parameters.DigitalCardProfileID);
        Assert.Equal(expectedAppIconFileID, parameters.AppIconFileID);
        Assert.Equal(expectedApplePay, parameters.ApplePay);
        Assert.Equal(expectedBackgroundImageFileID, parameters.BackgroundImageFileID);
        Assert.Equal(expectedCardDescription, parameters.CardDescription);
        Assert.Equal(expectedContactEmail, parameters.ContactEmail);
        Assert.Equal(expectedContactName, parameters.ContactName);
        Assert.Equal(expectedContactPhone, parameters.ContactPhone);
        Assert.Equal(expectedContactWebsite, parameters.ContactWebsite);
        Assert.Equal(expectedDescription, parameters.Description);
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
        Assert.Null(parameters.ApplePay);
        Assert.False(parameters.RawBodyData.ContainsKey("apple_pay"));
        Assert.Null(parameters.BackgroundImageFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("background_image_file_id"));
        Assert.Null(parameters.CardDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("card_description"));
        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.ContactName);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_name"));
        Assert.Null(parameters.ContactPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_phone"));
        Assert.Null(parameters.ContactWebsite);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_website"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
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
            ApplePay = null,
            BackgroundImageFileID = null,
            CardDescription = null,
            ContactEmail = null,
            ContactName = null,
            ContactPhone = null,
            ContactWebsite = null,
            Description = null,
            TextColor = null,
        };

        Assert.Null(parameters.AppIconFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("app_icon_file_id"));
        Assert.Null(parameters.ApplePay);
        Assert.False(parameters.RawBodyData.ContainsKey("apple_pay"));
        Assert.Null(parameters.BackgroundImageFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("background_image_file_id"));
        Assert.Null(parameters.CardDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("card_description"));
        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.ContactName);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_name"));
        Assert.Null(parameters.ContactPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_phone"));
        Assert.Null(parameters.ContactWebsite);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_website"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
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

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/digital_card_profiles/digital_card_profile_s3puplu90f04xhcwkiga/clone"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DigitalCardProfileCloneParams
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
            AppIconFileID = "app_icon_file_id",
            ApplePay = new()
            {
                AssociatedApplicationIdentifiers =
                [
                    new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
                ],
                AssociatedStoreIdentifiers = [new("26")],
            },
            BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
            CardDescription = "x",
            ContactEmail = "dev@stainless.com",
            ContactName = "x",
            ContactPhone = "x",
            ContactWebsite = "contact_website",
            Description = "x",
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

public class DigitalCardProfileCloneParamsApplePayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        List<DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier> expectedAssociatedApplicationIdentifiers =
        [
            new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
        ];
        List<DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier> expectedAssociatedStoreIdentifiers =
        [
            new("26"),
        ];

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
        var model = new DigitalCardProfileCloneParamsApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalCardProfileCloneParamsApplePay>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalCardProfileCloneParamsApplePay>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier> expectedAssociatedApplicationIdentifiers =
        [
            new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
        ];
        List<DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier> expectedAssociatedStoreIdentifiers =
        [
            new("26"),
        ];

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
        var model = new DigitalCardProfileCloneParamsApplePay
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
        var model = new DigitalCardProfileCloneParamsApplePay { };

        Assert.Null(model.AssociatedApplicationIdentifiers);
        Assert.False(model.RawData.ContainsKey("associated_application_identifiers"));
        Assert.Null(model.AssociatedStoreIdentifiers);
        Assert.False(model.RawData.ContainsKey("associated_store_identifiers"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePay { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePay
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
        var model = new DigitalCardProfileCloneParamsApplePay
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
        var model = new DigitalCardProfileCloneParamsApplePay
        {
            AssociatedApplicationIdentifiers =
            [
                new("210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N"),
            ],
            AssociatedStoreIdentifiers = [new("26")],
        };

        DigitalCardProfileCloneParamsApplePay copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier
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
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier>(
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
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier
        {
            Identifier = "210B9798AD.---aH0O-6L.8tjDQ-3.-K-h.8asJ.WN--u-kX-Q.l3VU-F.-i-5p54n-N",
        };

        DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier
        {
            Identifier = "26",
        };

        string expectedIdentifier = "26";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier
        {
            Identifier = "26",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier
        {
            Identifier = "26",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier>(
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
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier
        {
            Identifier = "26",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier
        {
            Identifier = "26",
        };

        DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier copied = new(model);

        Assert.Equal(model, copied);
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
