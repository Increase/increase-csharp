using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using IntrafiExclusions = Increase.Api.Models.IntrafiExclusions;

namespace Increase.Api.Tests.Models.IntrafiExclusions;

public class IntrafiExclusionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntrafiExclusions::IntrafiExclusion
        {
            ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
            BankName = "Example Bank",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
            FdicCertificateNumber = "314159",
            IdempotencyKey = null,
            Status = IntrafiExclusions::Status.Completed,
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
            Type = IntrafiExclusions::Type.IntrafiExclusion,
        };

        string expectedID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh";
        string expectedBankName = "Example Bank";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        DateTimeOffset expectedExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00");
        string expectedFdicCertificateNumber = "314159";
        ApiEnum<string, IntrafiExclusions::Status> expectedStatus =
            IntrafiExclusions::Status.Completed;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00");
        ApiEnum<string, IntrafiExclusions::Type> expectedType =
            IntrafiExclusions::Type.IntrafiExclusion;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBankName, model.BankName);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedExcludedAt, model.ExcludedAt);
        Assert.Equal(expectedFdicCertificateNumber, model.FdicCertificateNumber);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntrafiExclusions::IntrafiExclusion
        {
            ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
            BankName = "Example Bank",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
            FdicCertificateNumber = "314159",
            IdempotencyKey = null,
            Status = IntrafiExclusions::Status.Completed,
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
            Type = IntrafiExclusions::Type.IntrafiExclusion,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntrafiExclusions::IntrafiExclusion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntrafiExclusions::IntrafiExclusion
        {
            ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
            BankName = "Example Bank",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
            FdicCertificateNumber = "314159",
            IdempotencyKey = null,
            Status = IntrafiExclusions::Status.Completed,
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
            Type = IntrafiExclusions::Type.IntrafiExclusion,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntrafiExclusions::IntrafiExclusion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh";
        string expectedBankName = "Example Bank";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        DateTimeOffset expectedExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00");
        string expectedFdicCertificateNumber = "314159";
        ApiEnum<string, IntrafiExclusions::Status> expectedStatus =
            IntrafiExclusions::Status.Completed;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00");
        ApiEnum<string, IntrafiExclusions::Type> expectedType =
            IntrafiExclusions::Type.IntrafiExclusion;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBankName, deserialized.BankName);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedExcludedAt, deserialized.ExcludedAt);
        Assert.Equal(expectedFdicCertificateNumber, deserialized.FdicCertificateNumber);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntrafiExclusions::IntrafiExclusion
        {
            ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
            BankName = "Example Bank",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
            FdicCertificateNumber = "314159",
            IdempotencyKey = null,
            Status = IntrafiExclusions::Status.Completed,
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
            Type = IntrafiExclusions::Type.IntrafiExclusion,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntrafiExclusions::IntrafiExclusion
        {
            ID = "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
            BankName = "Example Bank",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExcludedAt = DateTimeOffset.Parse("2020-02-01T23:59:59+00:00"),
            FdicCertificateNumber = "314159",
            IdempotencyKey = null,
            Status = IntrafiExclusions::Status.Completed,
            SubmittedAt = DateTimeOffset.Parse("2020-02-01T00:59:59+00:00"),
            Type = IntrafiExclusions::Type.IntrafiExclusion,
        };

        IntrafiExclusions::IntrafiExclusion copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(IntrafiExclusions::Status.Pending)]
    [InlineData(IntrafiExclusions::Status.Completed)]
    [InlineData(IntrafiExclusions::Status.Archived)]
    [InlineData(IntrafiExclusions::Status.Ineligible)]
    public void Validation_Works(IntrafiExclusions::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntrafiExclusions::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntrafiExclusions::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntrafiExclusions::Status.Pending)]
    [InlineData(IntrafiExclusions::Status.Completed)]
    [InlineData(IntrafiExclusions::Status.Archived)]
    [InlineData(IntrafiExclusions::Status.Ineligible)]
    public void SerializationRoundtrip_Works(IntrafiExclusions::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntrafiExclusions::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntrafiExclusions::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntrafiExclusions::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntrafiExclusions::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(IntrafiExclusions::Type.IntrafiExclusion)]
    public void Validation_Works(IntrafiExclusions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntrafiExclusions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntrafiExclusions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntrafiExclusions::Type.IntrafiExclusion)]
    public void SerializationRoundtrip_Works(IntrafiExclusions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntrafiExclusions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntrafiExclusions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntrafiExclusions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, IntrafiExclusions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
