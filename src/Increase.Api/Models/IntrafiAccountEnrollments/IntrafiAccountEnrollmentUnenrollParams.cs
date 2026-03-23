using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.IntrafiAccountEnrollments;

/// <summary>
/// Unenroll an account from IntraFi
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IntrafiAccountEnrollmentUnenrollParams : ParamsBase
{
    public string? IntrafiAccountEnrollmentID { get; init; }

    public IntrafiAccountEnrollmentUnenrollParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntrafiAccountEnrollmentUnenrollParams(
        IntrafiAccountEnrollmentUnenrollParams intrafiAccountEnrollmentUnenrollParams
    )
        : base(intrafiAccountEnrollmentUnenrollParams)
    {
        this.IntrafiAccountEnrollmentID =
            intrafiAccountEnrollmentUnenrollParams.IntrafiAccountEnrollmentID;
    }
#pragma warning restore CS8618

    public IntrafiAccountEnrollmentUnenrollParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntrafiAccountEnrollmentUnenrollParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string intrafiAccountEnrollmentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.IntrafiAccountEnrollmentID = intrafiAccountEnrollmentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static IntrafiAccountEnrollmentUnenrollParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string intrafiAccountEnrollmentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            intrafiAccountEnrollmentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["IntrafiAccountEnrollmentID"] = JsonSerializer.SerializeToElement(
                        this.IntrafiAccountEnrollmentID
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

    public virtual bool Equals(IntrafiAccountEnrollmentUnenrollParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.IntrafiAccountEnrollmentID?.Equals(other.IntrafiAccountEnrollmentID)
                ?? other.IntrafiAccountEnrollmentID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/intrafi_account_enrollments/{0}/unenroll",
                    this.IntrafiAccountEnrollmentID
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
