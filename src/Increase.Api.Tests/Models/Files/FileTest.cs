using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Files = Increase.Api.Models.Files;

namespace Increase.Api.Tests.Models.Files;

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Files::File
        {
            ID = "file_makxrc67oh9l6sg7w9yc",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "2022-05 statement for checking account",
            Direction = Files::Direction.FromIncrease,
            Filename = "statement.pdf",
            IdempotencyKey = null,
            MimeType = "application/pdf",
            Purpose = Files::FilePurpose.IncreaseStatement,
            Type = Files::Type.File,
        };

        string expectedID = "file_makxrc67oh9l6sg7w9yc";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "2022-05 statement for checking account";
        ApiEnum<string, Files::Direction> expectedDirection = Files::Direction.FromIncrease;
        string expectedFilename = "statement.pdf";
        string expectedMimeType = "application/pdf";
        ApiEnum<string, Files::FilePurpose> expectedPurpose = Files::FilePurpose.IncreaseStatement;
        ApiEnum<string, Files::Type> expectedType = Files::Type.File;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedFilename, model.Filename);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedMimeType, model.MimeType);
        Assert.Equal(expectedPurpose, model.Purpose);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Files::File
        {
            ID = "file_makxrc67oh9l6sg7w9yc",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "2022-05 statement for checking account",
            Direction = Files::Direction.FromIncrease,
            Filename = "statement.pdf",
            IdempotencyKey = null,
            MimeType = "application/pdf",
            Purpose = Files::FilePurpose.IncreaseStatement,
            Type = Files::Type.File,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::File>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Files::File
        {
            ID = "file_makxrc67oh9l6sg7w9yc",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "2022-05 statement for checking account",
            Direction = Files::Direction.FromIncrease,
            Filename = "statement.pdf",
            IdempotencyKey = null,
            MimeType = "application/pdf",
            Purpose = Files::FilePurpose.IncreaseStatement,
            Type = Files::Type.File,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Files::File>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "file_makxrc67oh9l6sg7w9yc";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "2022-05 statement for checking account";
        ApiEnum<string, Files::Direction> expectedDirection = Files::Direction.FromIncrease;
        string expectedFilename = "statement.pdf";
        string expectedMimeType = "application/pdf";
        ApiEnum<string, Files::FilePurpose> expectedPurpose = Files::FilePurpose.IncreaseStatement;
        ApiEnum<string, Files::Type> expectedType = Files::Type.File;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedMimeType, deserialized.MimeType);
        Assert.Equal(expectedPurpose, deserialized.Purpose);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Files::File
        {
            ID = "file_makxrc67oh9l6sg7w9yc",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "2022-05 statement for checking account",
            Direction = Files::Direction.FromIncrease,
            Filename = "statement.pdf",
            IdempotencyKey = null,
            MimeType = "application/pdf",
            Purpose = Files::FilePurpose.IncreaseStatement,
            Type = Files::Type.File,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Files::File
        {
            ID = "file_makxrc67oh9l6sg7w9yc",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "2022-05 statement for checking account",
            Direction = Files::Direction.FromIncrease,
            Filename = "statement.pdf",
            IdempotencyKey = null,
            MimeType = "application/pdf",
            Purpose = Files::FilePurpose.IncreaseStatement,
            Type = Files::Type.File,
        };

        Files::File copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DirectionTest : TestBase
{
    [Theory]
    [InlineData(Files::Direction.ToIncrease)]
    [InlineData(Files::Direction.FromIncrease)]
    public void Validation_Works(Files::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Direction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::Direction.ToIncrease)]
    [InlineData(Files::Direction.FromIncrease)]
    public void SerializationRoundtrip_Works(Files::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Direction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Direction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Direction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FilePurposeTest : TestBase
{
    [Theory]
    [InlineData(Files::FilePurpose.CardDisputeAttachment)]
    [InlineData(Files::FilePurpose.CheckImageFront)]
    [InlineData(Files::FilePurpose.CheckImageBack)]
    [InlineData(Files::FilePurpose.ProcessedCheckImageFront)]
    [InlineData(Files::FilePurpose.ProcessedCheckImageBack)]
    [InlineData(Files::FilePurpose.MailedCheckImage)]
    [InlineData(Files::FilePurpose.CheckAttachment)]
    [InlineData(Files::FilePurpose.CheckVoucherImage)]
    [InlineData(Files::FilePurpose.CheckSignature)]
    [InlineData(Files::FilePurpose.InboundMailItem)]
    [InlineData(Files::FilePurpose.Form1099Int)]
    [InlineData(Files::FilePurpose.Form1099Misc)]
    [InlineData(Files::FilePurpose.FormSS4)]
    [InlineData(Files::FilePurpose.IdentityDocument)]
    [InlineData(Files::FilePurpose.IncreaseStatement)]
    [InlineData(Files::FilePurpose.LoanApplicationSupplementalDocument)]
    [InlineData(Files::FilePurpose.Other)]
    [InlineData(Files::FilePurpose.TrustFormationDocument)]
    [InlineData(Files::FilePurpose.DigitalWalletArtwork)]
    [InlineData(Files::FilePurpose.DigitalWalletAppIcon)]
    [InlineData(Files::FilePurpose.PhysicalCardFront)]
    [InlineData(Files::FilePurpose.PhysicalCardBack)]
    [InlineData(Files::FilePurpose.PhysicalCardCarrier)]
    [InlineData(Files::FilePurpose.DocumentRequest)]
    [InlineData(Files::FilePurpose.EntitySupplementalDocument)]
    [InlineData(Files::FilePurpose.Export)]
    [InlineData(Files::FilePurpose.FeeStatement)]
    [InlineData(Files::FilePurpose.UnusualActivityReportAttachment)]
    [InlineData(Files::FilePurpose.DepositAccountControlAgreement)]
    [InlineData(Files::FilePurpose.ProofOfAuthorizationRequestSubmission)]
    [InlineData(Files::FilePurpose.AccountVerificationLetter)]
    [InlineData(Files::FilePurpose.FundingInstructions)]
    [InlineData(Files::FilePurpose.HoldHarmlessLetter)]
    public void Validation_Works(Files::FilePurpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FilePurpose> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::FilePurpose>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::FilePurpose.CardDisputeAttachment)]
    [InlineData(Files::FilePurpose.CheckImageFront)]
    [InlineData(Files::FilePurpose.CheckImageBack)]
    [InlineData(Files::FilePurpose.ProcessedCheckImageFront)]
    [InlineData(Files::FilePurpose.ProcessedCheckImageBack)]
    [InlineData(Files::FilePurpose.MailedCheckImage)]
    [InlineData(Files::FilePurpose.CheckAttachment)]
    [InlineData(Files::FilePurpose.CheckVoucherImage)]
    [InlineData(Files::FilePurpose.CheckSignature)]
    [InlineData(Files::FilePurpose.InboundMailItem)]
    [InlineData(Files::FilePurpose.Form1099Int)]
    [InlineData(Files::FilePurpose.Form1099Misc)]
    [InlineData(Files::FilePurpose.FormSS4)]
    [InlineData(Files::FilePurpose.IdentityDocument)]
    [InlineData(Files::FilePurpose.IncreaseStatement)]
    [InlineData(Files::FilePurpose.LoanApplicationSupplementalDocument)]
    [InlineData(Files::FilePurpose.Other)]
    [InlineData(Files::FilePurpose.TrustFormationDocument)]
    [InlineData(Files::FilePurpose.DigitalWalletArtwork)]
    [InlineData(Files::FilePurpose.DigitalWalletAppIcon)]
    [InlineData(Files::FilePurpose.PhysicalCardFront)]
    [InlineData(Files::FilePurpose.PhysicalCardBack)]
    [InlineData(Files::FilePurpose.PhysicalCardCarrier)]
    [InlineData(Files::FilePurpose.DocumentRequest)]
    [InlineData(Files::FilePurpose.EntitySupplementalDocument)]
    [InlineData(Files::FilePurpose.Export)]
    [InlineData(Files::FilePurpose.FeeStatement)]
    [InlineData(Files::FilePurpose.UnusualActivityReportAttachment)]
    [InlineData(Files::FilePurpose.DepositAccountControlAgreement)]
    [InlineData(Files::FilePurpose.ProofOfAuthorizationRequestSubmission)]
    [InlineData(Files::FilePurpose.AccountVerificationLetter)]
    [InlineData(Files::FilePurpose.FundingInstructions)]
    [InlineData(Files::FilePurpose.HoldHarmlessLetter)]
    public void SerializationRoundtrip_Works(Files::FilePurpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::FilePurpose> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::FilePurpose>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::FilePurpose>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::FilePurpose>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Files::Type.File)]
    public void Validation_Works(Files::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Files::Type.File)]
    public void SerializationRoundtrip_Works(Files::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Files::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Files::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
