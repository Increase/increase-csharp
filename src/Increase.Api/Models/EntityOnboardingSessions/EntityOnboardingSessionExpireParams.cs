using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.EntityOnboardingSessions;

/// <summary>
/// Expire an Entity Onboarding Session
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntityOnboardingSessionExpireParams : ParamsBase
{
    public string? EntityOnboardingSessionID { get; init; }

    public EntityOnboardingSessionExpireParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityOnboardingSessionExpireParams(
        EntityOnboardingSessionExpireParams entityOnboardingSessionExpireParams
    )
        : base(entityOnboardingSessionExpireParams)
    {
        this.EntityOnboardingSessionID =
            entityOnboardingSessionExpireParams.EntityOnboardingSessionID;
    }
#pragma warning restore CS8618

    public EntityOnboardingSessionExpireParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EntityOnboardingSessionExpireParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string entityOnboardingSessionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.EntityOnboardingSessionID = entityOnboardingSessionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntityOnboardingSessionExpireParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string entityOnboardingSessionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            entityOnboardingSessionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["EntityOnboardingSessionID"] = JsonSerializer.SerializeToElement(
                        this.EntityOnboardingSessionID
                    ),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(EntityOnboardingSessionExpireParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.EntityOnboardingSessionID?.Equals(other.EntityOnboardingSessionID)
                ?? other.EntityOnboardingSessionID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/entity_onboarding_sessions/{0}/expire",
                    this.EntityOnboardingSessionID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
