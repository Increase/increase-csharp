using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using EntityOnboardingSessions = Increase.Api.Models.EntityOnboardingSessions;

namespace Increase.Api.Tests.Models.EntityOnboardingSessions;

public class EntityOnboardingSessionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EntityOnboardingSessions::EntityOnboardingSessionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<EntityOnboardingSessions::EntityOnboardingSession> expectedData =
        [
            new()
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
        var model = new EntityOnboardingSessions::EntityOnboardingSessionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityOnboardingSessions::EntityOnboardingSessionListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EntityOnboardingSessions::EntityOnboardingSessionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<EntityOnboardingSessions::EntityOnboardingSessionListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<EntityOnboardingSessions::EntityOnboardingSession> expectedData =
        [
            new()
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
        var model = new EntityOnboardingSessions::EntityOnboardingSessionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EntityOnboardingSessions::EntityOnboardingSessionListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        EntityOnboardingSessions::EntityOnboardingSessionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
