using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.PhysicalCardProfiles;

namespace Increase.Api.Tests.Models.PhysicalCardProfiles;

public class PhysicalCardProfileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCardProfileCreateParams
        {
            CarrierImageFileID = "file_h6v7mtipe119os47ehlu",
            ContactPhone = "+16505046304",
            Description = "My Card Profile",
            FrontImageFileID = "file_o6aex13wm1jcc36sgcj1",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            FrontText = new() { Line1 = "x", Line2 = "x" },
        };

        string expectedCarrierImageFileID = "file_h6v7mtipe119os47ehlu";
        string expectedContactPhone = "+16505046304";
        string expectedDescription = "My Card Profile";
        string expectedFrontImageFileID = "file_o6aex13wm1jcc36sgcj1";
        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";
        FrontText expectedFrontText = new() { Line1 = "x", Line2 = "x" };

        Assert.Equal(expectedCarrierImageFileID, parameters.CarrierImageFileID);
        Assert.Equal(expectedContactPhone, parameters.ContactPhone);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedFrontImageFileID, parameters.FrontImageFileID);
        Assert.Equal(expectedProgramID, parameters.ProgramID);
        Assert.Equal(expectedFrontText, parameters.FrontText);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhysicalCardProfileCreateParams
        {
            CarrierImageFileID = "file_h6v7mtipe119os47ehlu",
            ContactPhone = "+16505046304",
            Description = "My Card Profile",
            FrontImageFileID = "file_o6aex13wm1jcc36sgcj1",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
        };

        Assert.Null(parameters.FrontText);
        Assert.False(parameters.RawBodyData.ContainsKey("front_text"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhysicalCardProfileCreateParams
        {
            CarrierImageFileID = "file_h6v7mtipe119os47ehlu",
            ContactPhone = "+16505046304",
            Description = "My Card Profile",
            FrontImageFileID = "file_o6aex13wm1jcc36sgcj1",
            ProgramID = "program_i2v2os4mwza1oetokh9i",

            // Null should be interpreted as omitted for these properties
            FrontText = null,
        };

        Assert.Null(parameters.FrontText);
        Assert.False(parameters.RawBodyData.ContainsKey("front_text"));
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCardProfileCreateParams parameters = new()
        {
            CarrierImageFileID = "file_h6v7mtipe119os47ehlu",
            ContactPhone = "+16505046304",
            Description = "My Card Profile",
            FrontImageFileID = "file_o6aex13wm1jcc36sgcj1",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/physical_card_profiles"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCardProfileCreateParams
        {
            CarrierImageFileID = "file_h6v7mtipe119os47ehlu",
            ContactPhone = "+16505046304",
            Description = "My Card Profile",
            FrontImageFileID = "file_o6aex13wm1jcc36sgcj1",
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            FrontText = new() { Line1 = "x", Line2 = "x" },
        };

        PhysicalCardProfileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FrontTextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FrontText { Line1 = "x", Line2 = "x" };

        string expectedLine1 = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FrontText { Line1 = "x", Line2 = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FrontText>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FrontText { Line1 = "x", Line2 = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FrontText>(
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
        var model = new FrontText { Line1 = "x", Line2 = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FrontText { Line1 = "x" };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FrontText { Line1 = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FrontText
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
        var model = new FrontText
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
        var model = new FrontText { Line1 = "x", Line2 = "x" };

        FrontText copied = new(model);

        Assert.Equal(model, copied);
    }
}
