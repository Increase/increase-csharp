using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using EntityOnboardingSessions = Increase.Api.Models.EntityOnboardingSessions;

namespace Increase.Api.Tests.Models.EntityOnboardingSessions;

public class EntityOnboardingSessionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityOnboardingSessions::EntityOnboardingSession
        {
            ID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExpiresAt = DateTimeOffset.Parse("2020-02-01T05:59:59+00:00"),
            IdempotencyKey = null,
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/completed",
            SessionUrl =
                "https://onboarding.increase.com/onboarding/sessions?id=HIrdj46cXyyNqT5RDcIR38dzPqzRBgTdG84XwzOz",
            Status = EntityOnboardingSessions::EntityOnboardingSessionStatus.Active,
            Type = EntityOnboardingSessions::Type.EntityOnboardingSession,
        };

        string expectedID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-02-01T05:59:59+00:00");
        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";
        string expectedRedirectUrl = "https://example.com/onboarding/completed";
        string expectedSessionUrl =
            "https://onboarding.increase.com/onboarding/sessions?id=HIrdj46cXyyNqT5RDcIR38dzPqzRBgTdG84XwzOz";
        ApiEnum<string, EntityOnboardingSessions::EntityOnboardingSessionStatus> expectedStatus =
            EntityOnboardingSessions::EntityOnboardingSessionStatus.Active;
        ApiEnum<string, EntityOnboardingSessions::Type> expectedType =
            EntityOnboardingSessions::Type.EntityOnboardingSession;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedProgramID, model.ProgramID);
        Assert.Equal(expectedRedirectUrl, model.RedirectUrl);
        Assert.Equal(expectedSessionUrl, model.SessionUrl);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EntityOnboardingSessions::EntityOnboardingSession
        {
            ID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExpiresAt = DateTimeOffset.Parse("2020-02-01T05:59:59+00:00"),
            IdempotencyKey = null,
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/completed",
            SessionUrl =
                "https://onboarding.increase.com/onboarding/sessions?id=HIrdj46cXyyNqT5RDcIR38dzPqzRBgTdG84XwzOz",
            Status = EntityOnboardingSessions::EntityOnboardingSessionStatus.Active,
            Type = EntityOnboardingSessions::Type.EntityOnboardingSession,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityOnboardingSessions::EntityOnboardingSession>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityOnboardingSessions::EntityOnboardingSession
        {
            ID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExpiresAt = DateTimeOffset.Parse("2020-02-01T05:59:59+00:00"),
            IdempotencyKey = null,
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/completed",
            SessionUrl =
                "https://onboarding.increase.com/onboarding/sessions?id=HIrdj46cXyyNqT5RDcIR38dzPqzRBgTdG84XwzOz",
            Status = EntityOnboardingSessions::EntityOnboardingSessionStatus.Active,
            Type = EntityOnboardingSessions::Type.EntityOnboardingSession,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityOnboardingSessions::EntityOnboardingSession>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2020-02-01T05:59:59+00:00");
        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";
        string expectedRedirectUrl = "https://example.com/onboarding/completed";
        string expectedSessionUrl =
            "https://onboarding.increase.com/onboarding/sessions?id=HIrdj46cXyyNqT5RDcIR38dzPqzRBgTdG84XwzOz";
        ApiEnum<string, EntityOnboardingSessions::EntityOnboardingSessionStatus> expectedStatus =
            EntityOnboardingSessions::EntityOnboardingSessionStatus.Active;
        ApiEnum<string, EntityOnboardingSessions::Type> expectedType =
            EntityOnboardingSessions::Type.EntityOnboardingSession;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedProgramID, deserialized.ProgramID);
        Assert.Equal(expectedRedirectUrl, deserialized.RedirectUrl);
        Assert.Equal(expectedSessionUrl, deserialized.SessionUrl);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EntityOnboardingSessions::EntityOnboardingSession
        {
            ID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExpiresAt = DateTimeOffset.Parse("2020-02-01T05:59:59+00:00"),
            IdempotencyKey = null,
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/completed",
            SessionUrl =
                "https://onboarding.increase.com/onboarding/sessions?id=HIrdj46cXyyNqT5RDcIR38dzPqzRBgTdG84XwzOz",
            Status = EntityOnboardingSessions::EntityOnboardingSessionStatus.Active,
            Type = EntityOnboardingSessions::Type.EntityOnboardingSession,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityOnboardingSessions::EntityOnboardingSession
        {
            ID = "entity_onboarding_session_wid2ug11fsmvh3k9hymd",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            ExpiresAt = DateTimeOffset.Parse("2020-02-01T05:59:59+00:00"),
            IdempotencyKey = null,
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/completed",
            SessionUrl =
                "https://onboarding.increase.com/onboarding/sessions?id=HIrdj46cXyyNqT5RDcIR38dzPqzRBgTdG84XwzOz",
            Status = EntityOnboardingSessions::EntityOnboardingSessionStatus.Active,
            Type = EntityOnboardingSessions::Type.EntityOnboardingSession,
        };

        EntityOnboardingSessions::EntityOnboardingSession copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntityOnboardingSessionStatusTest : TestBase
{
    [Theory]
    [InlineData(EntityOnboardingSessions::EntityOnboardingSessionStatus.Active)]
    [InlineData(EntityOnboardingSessions::EntityOnboardingSessionStatus.Expired)]
    public void Validation_Works(EntityOnboardingSessions::EntityOnboardingSessionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityOnboardingSessions::EntityOnboardingSessionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityOnboardingSessions::EntityOnboardingSessionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityOnboardingSessions::EntityOnboardingSessionStatus.Active)]
    [InlineData(EntityOnboardingSessions::EntityOnboardingSessionStatus.Expired)]
    public void SerializationRoundtrip_Works(
        EntityOnboardingSessions::EntityOnboardingSessionStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityOnboardingSessions::EntityOnboardingSessionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityOnboardingSessions::EntityOnboardingSessionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EntityOnboardingSessions::EntityOnboardingSessionStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityOnboardingSessions::EntityOnboardingSessionStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(EntityOnboardingSessions::Type.EntityOnboardingSession)]
    public void Validation_Works(EntityOnboardingSessions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityOnboardingSessions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityOnboardingSessions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EntityOnboardingSessions::Type.EntityOnboardingSession)]
    public void SerializationRoundtrip_Works(EntityOnboardingSessions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EntityOnboardingSessions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityOnboardingSessions::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EntityOnboardingSessions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EntityOnboardingSessions::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
