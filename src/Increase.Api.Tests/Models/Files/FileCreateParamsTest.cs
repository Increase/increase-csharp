using System;
using System.Text;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Files;

namespace Increase.Api.Tests.Models.Files;

public class FileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileCreateParams
        {
            File = file,
            Purpose = Purpose.CheckImageFront,
            Description = "x",
        };

        BinaryContent expectedFile = file;
        ApiEnum<string, Purpose> expectedPurpose = Purpose.CheckImageFront;
        string expectedDescription = "x";

        Assert.Equal(expectedFile, parameters.File);
        Assert.Equal(expectedPurpose, parameters.Purpose);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileCreateParams { File = file, Purpose = Purpose.CheckImageFront };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileCreateParams
        {
            File = file,
            Purpose = Purpose.CheckImageFront,

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        FileCreateParams parameters = new()
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            Purpose = Purpose.CheckImageFront,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/files"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileCreateParams
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            Purpose = Purpose.CheckImageFront,
            Description = "x",
        };

        FileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PurposeTest : TestBase
{
    [Theory]
    [InlineData(Purpose.CardDisputeAttachment)]
    [InlineData(Purpose.CheckImageFront)]
    [InlineData(Purpose.CheckImageBack)]
    [InlineData(Purpose.MailedCheckImage)]
    [InlineData(Purpose.CheckAttachment)]
    [InlineData(Purpose.CheckVoucherImage)]
    [InlineData(Purpose.CheckSignature)]
    [InlineData(Purpose.FormSS4)]
    [InlineData(Purpose.IdentityDocument)]
    [InlineData(Purpose.LoanApplicationSupplementalDocument)]
    [InlineData(Purpose.Other)]
    [InlineData(Purpose.TrustFormationDocument)]
    [InlineData(Purpose.DigitalWalletArtwork)]
    [InlineData(Purpose.DigitalWalletAppIcon)]
    [InlineData(Purpose.PhysicalCardFront)]
    [InlineData(Purpose.PhysicalCardCarrier)]
    [InlineData(Purpose.DocumentRequest)]
    [InlineData(Purpose.EntitySupplementalDocument)]
    [InlineData(Purpose.UnusualActivityReportAttachment)]
    [InlineData(Purpose.ProofOfAuthorizationRequestSubmission)]
    public void Validation_Works(Purpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Purpose> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Purpose>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Purpose.CardDisputeAttachment)]
    [InlineData(Purpose.CheckImageFront)]
    [InlineData(Purpose.CheckImageBack)]
    [InlineData(Purpose.MailedCheckImage)]
    [InlineData(Purpose.CheckAttachment)]
    [InlineData(Purpose.CheckVoucherImage)]
    [InlineData(Purpose.CheckSignature)]
    [InlineData(Purpose.FormSS4)]
    [InlineData(Purpose.IdentityDocument)]
    [InlineData(Purpose.LoanApplicationSupplementalDocument)]
    [InlineData(Purpose.Other)]
    [InlineData(Purpose.TrustFormationDocument)]
    [InlineData(Purpose.DigitalWalletArtwork)]
    [InlineData(Purpose.DigitalWalletAppIcon)]
    [InlineData(Purpose.PhysicalCardFront)]
    [InlineData(Purpose.PhysicalCardCarrier)]
    [InlineData(Purpose.DocumentRequest)]
    [InlineData(Purpose.EntitySupplementalDocument)]
    [InlineData(Purpose.UnusualActivityReportAttachment)]
    [InlineData(Purpose.ProofOfAuthorizationRequestSubmission)]
    public void SerializationRoundtrip_Works(Purpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Purpose> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Purpose>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Purpose>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Purpose>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
