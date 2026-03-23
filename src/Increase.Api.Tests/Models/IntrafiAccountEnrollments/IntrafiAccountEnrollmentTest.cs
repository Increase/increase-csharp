using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using IntrafiAccountEnrollments = Increase.Api.Models.IntrafiAccountEnrollments;

namespace Increase.Api.Tests.Models.IntrafiAccountEnrollments;

public class IntrafiAccountEnrollmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollment
        {
            ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EmailAddress = null,
            IdempotencyKey = null,
            IntrafiID = "01234abcd",
            Status = IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
            Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
        };

        string expectedID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedIntrafiID = "01234abcd";
        ApiEnum<string, IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus> expectedStatus =
            IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling;
        ApiEnum<string, IntrafiAccountEnrollments::Type> expectedType =
            IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.EmailAddress);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedIntrafiID, model.IntrafiID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollment
        {
            ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EmailAddress = null,
            IdempotencyKey = null,
            IntrafiID = "01234abcd",
            Status = IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
            Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntrafiAccountEnrollments::IntrafiAccountEnrollment>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollment
        {
            ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EmailAddress = null,
            IdempotencyKey = null,
            IntrafiID = "01234abcd",
            Status = IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
            Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntrafiAccountEnrollments::IntrafiAccountEnrollment>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedIntrafiID = "01234abcd";
        ApiEnum<string, IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus> expectedStatus =
            IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling;
        ApiEnum<string, IntrafiAccountEnrollments::Type> expectedType =
            IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.EmailAddress);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedIntrafiID, deserialized.IntrafiID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollment
        {
            ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EmailAddress = null,
            IdempotencyKey = null,
            IntrafiID = "01234abcd",
            Status = IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
            Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollment
        {
            ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
            AccountID = "account_in71c4amph0vgo2qllky",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EmailAddress = null,
            IdempotencyKey = null,
            IntrafiID = "01234abcd",
            Status = IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
            Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
        };

        IntrafiAccountEnrollments::IntrafiAccountEnrollment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntrafiAccountEnrollmentStatusTest : TestBase
{
    [Theory]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling)]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.Enrolled)]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingUnenrolling)]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.Unenrolled)]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.RequiresAttention)]
    public void Validation_Works(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling)]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.Enrolled)]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingUnenrolling)]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.Unenrolled)]
    [InlineData(IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.RequiresAttention)]
    public void SerializationRoundtrip_Works(
        IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment)]
    public void Validation_Works(IntrafiAccountEnrollments::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntrafiAccountEnrollments::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntrafiAccountEnrollments::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment)]
    public void SerializationRoundtrip_Works(IntrafiAccountEnrollments::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntrafiAccountEnrollments::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntrafiAccountEnrollments::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, IntrafiAccountEnrollments::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntrafiAccountEnrollments::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
