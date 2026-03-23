using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.BeneficialOwners;

/// <summary>
/// Archive a Beneficial Owner
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BeneficialOwnerArchiveParams : ParamsBase
{
    public string? EntityBeneficialOwnerID { get; init; }

    public BeneficialOwnerArchiveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BeneficialOwnerArchiveParams(BeneficialOwnerArchiveParams beneficialOwnerArchiveParams)
        : base(beneficialOwnerArchiveParams)
    {
        this.EntityBeneficialOwnerID = beneficialOwnerArchiveParams.EntityBeneficialOwnerID;
    }
#pragma warning restore CS8618

    public BeneficialOwnerArchiveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BeneficialOwnerArchiveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string entityBeneficialOwnerID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.EntityBeneficialOwnerID = entityBeneficialOwnerID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BeneficialOwnerArchiveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string entityBeneficialOwnerID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            entityBeneficialOwnerID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["EntityBeneficialOwnerID"] = JsonSerializer.SerializeToElement(
                        this.EntityBeneficialOwnerID
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

    public virtual bool Equals(BeneficialOwnerArchiveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.EntityBeneficialOwnerID?.Equals(other.EntityBeneficialOwnerID)
                ?? other.EntityBeneficialOwnerID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/entity_beneficial_owners/{0}/archive",
                    this.EntityBeneficialOwnerID
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
