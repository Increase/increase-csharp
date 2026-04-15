using System;
using Increase.Api.Models.EntityOnboardingSessions;

namespace Increase.Api.Tests.Models.EntityOnboardingSessions;

public class EntityOnboardingSessionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityOnboardingSessionCreateParams
        {
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/session",
            EntityID = "entity_id",
        };

        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";
        string expectedRedirectUrl = "https://example.com/onboarding/session";
        string expectedEntityID = "entity_id";

        Assert.Equal(expectedProgramID, parameters.ProgramID);
        Assert.Equal(expectedRedirectUrl, parameters.RedirectUrl);
        Assert.Equal(expectedEntityID, parameters.EntityID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EntityOnboardingSessionCreateParams
        {
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/session",
        };

        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EntityOnboardingSessionCreateParams
        {
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/session",

            // Null should be interpreted as omitted for these properties
            EntityID = null,
        };

        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_id"));
    }

    [Fact]
    public void Url_Works()
    {
        EntityOnboardingSessionCreateParams parameters = new()
        {
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/session",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/entity_onboarding_sessions"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityOnboardingSessionCreateParams
        {
            ProgramID = "program_i2v2os4mwza1oetokh9i",
            RedirectUrl = "https://example.com/onboarding/session",
            EntityID = "entity_id",
        };

        EntityOnboardingSessionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
