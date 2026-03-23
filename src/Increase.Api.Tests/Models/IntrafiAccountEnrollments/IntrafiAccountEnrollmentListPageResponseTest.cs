using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using IntrafiAccountEnrollments = Increase.Api.Models.IntrafiAccountEnrollments;

namespace Increase.Api.Tests.Models.IntrafiAccountEnrollments;

public class IntrafiAccountEnrollmentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollmentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EmailAddress = null,
                    IdempotencyKey = null,
                    IntrafiID = "01234abcd",
                    Status =
                        IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
                    Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<IntrafiAccountEnrollments::IntrafiAccountEnrollment> expectedData =
        [
            new()
            {
                ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EmailAddress = null,
                IdempotencyKey = null,
                IntrafiID = "01234abcd",
                Status = IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
                Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollmentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EmailAddress = null,
                    IdempotencyKey = null,
                    IntrafiID = "01234abcd",
                    Status =
                        IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
                    Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntrafiAccountEnrollments::IntrafiAccountEnrollmentListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollmentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EmailAddress = null,
                    IdempotencyKey = null,
                    IntrafiID = "01234abcd",
                    Status =
                        IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
                    Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntrafiAccountEnrollments::IntrafiAccountEnrollmentListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<IntrafiAccountEnrollments::IntrafiAccountEnrollment> expectedData =
        [
            new()
            {
                ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
                AccountID = "account_in71c4amph0vgo2qllky",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                EmailAddress = null,
                IdempotencyKey = null,
                IntrafiID = "01234abcd",
                Status = IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
                Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollmentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EmailAddress = null,
                    IdempotencyKey = null,
                    IntrafiID = "01234abcd",
                    Status =
                        IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
                    Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntrafiAccountEnrollments::IntrafiAccountEnrollmentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "intrafi_account_enrollment_w8l97znzreopkwf2tg75",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    EmailAddress = null,
                    IdempotencyKey = null,
                    IntrafiID = "01234abcd",
                    Status =
                        IntrafiAccountEnrollments::IntrafiAccountEnrollmentStatus.PendingEnrolling,
                    Type = IntrafiAccountEnrollments::Type.IntrafiAccountEnrollment,
                },
            ],
            NextCursor = "v57w5d",
        };

        IntrafiAccountEnrollments::IntrafiAccountEnrollmentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
