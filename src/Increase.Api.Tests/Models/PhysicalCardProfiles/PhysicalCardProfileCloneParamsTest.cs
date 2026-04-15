using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.PhysicalCardProfiles;

namespace Increase.Api.Tests.Models.PhysicalCardProfiles;

public class PhysicalCardProfileCloneParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCardProfileCloneParams
        {
            PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
            CarrierImageFileID = "carrier_image_file_id",
            ContactPhone = "x",
            Description = "x",
            FrontImageFileID = "file_o6aex13wm1jcc36sgcj1",
            FrontText = new() { Line1 = "x", Line2 = "x" },
            ProgramID = "program_id",
        };

        string expectedPhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec";
        string expectedCarrierImageFileID = "carrier_image_file_id";
        string expectedContactPhone = "x";
        string expectedDescription = "x";
        string expectedFrontImageFileID = "file_o6aex13wm1jcc36sgcj1";
        PhysicalCardProfileCloneParamsFrontText expectedFrontText = new()
        {
            Line1 = "x",
            Line2 = "x",
        };
        string expectedProgramID = "program_id";

        Assert.Equal(expectedPhysicalCardProfileID, parameters.PhysicalCardProfileID);
        Assert.Equal(expectedCarrierImageFileID, parameters.CarrierImageFileID);
        Assert.Equal(expectedContactPhone, parameters.ContactPhone);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedFrontImageFileID, parameters.FrontImageFileID);
        Assert.Equal(expectedFrontText, parameters.FrontText);
        Assert.Equal(expectedProgramID, parameters.ProgramID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhysicalCardProfileCloneParams
        {
            PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
        };

        Assert.Null(parameters.CarrierImageFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("carrier_image_file_id"));
        Assert.Null(parameters.ContactPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_phone"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.FrontImageFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("front_image_file_id"));
        Assert.Null(parameters.FrontText);
        Assert.False(parameters.RawBodyData.ContainsKey("front_text"));
        Assert.Null(parameters.ProgramID);
        Assert.False(parameters.RawBodyData.ContainsKey("program_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhysicalCardProfileCloneParams
        {
            PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",

            // Null should be interpreted as omitted for these properties
            CarrierImageFileID = null,
            ContactPhone = null,
            Description = null,
            FrontImageFileID = null,
            FrontText = null,
            ProgramID = null,
        };

        Assert.Null(parameters.CarrierImageFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("carrier_image_file_id"));
        Assert.Null(parameters.ContactPhone);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_phone"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.FrontImageFileID);
        Assert.False(parameters.RawBodyData.ContainsKey("front_image_file_id"));
        Assert.Null(parameters.FrontText);
        Assert.False(parameters.RawBodyData.ContainsKey("front_text"));
        Assert.Null(parameters.ProgramID);
        Assert.False(parameters.RawBodyData.ContainsKey("program_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCardProfileCloneParams parameters = new()
        {
            PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/physical_card_profiles/physical_card_profile_m534d5rn9qyy9ufqxoec/clone"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCardProfileCloneParams
        {
            PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
            CarrierImageFileID = "carrier_image_file_id",
            ContactPhone = "x",
            Description = "x",
            FrontImageFileID = "file_o6aex13wm1jcc36sgcj1",
            FrontText = new() { Line1 = "x", Line2 = "x" },
            ProgramID = "program_id",
        };

        PhysicalCardProfileCloneParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PhysicalCardProfileCloneParamsFrontTextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText { Line1 = "x", Line2 = "x" };

        string expectedLine1 = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText { Line1 = "x", Line2 = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCardProfileCloneParamsFrontText>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText { Line1 = "x", Line2 = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCardProfileCloneParamsFrontText>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLine1 = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText { Line1 = "x", Line2 = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText { Line1 = "x" };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText { Line1 = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText
        {
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText
        {
            Line1 = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCardProfileCloneParamsFrontText { Line1 = "x", Line2 = "x" };

        PhysicalCardProfileCloneParamsFrontText copied = new(model);

        Assert.Equal(model, copied);
    }
}
