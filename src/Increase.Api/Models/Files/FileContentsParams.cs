using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Increase.Api.Core;

namespace Increase.Api.Models.Files;

/// <summary>
/// Download the contents of a File. Responds with a 307 redirect whose `Location`
/// header points at a short-lived, pre-signed URL. Our [SDKs](/documentation/software-development-kits)
/// follow the redirect and return the File's contents; if you call the API directly,
/// follow the redirect to download it. The pre-signed URL serves the File with a
/// `Content-Type` matching its `mime` and a `Content-Disposition` header set to
/// its `filename`. It expires in 10 minutes. To share a File with someone who doesn't
/// have access to your API key, create a File Link.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FileContentsParams : ParamsBase
{
    public string? FileID { get; init; }

    public FileContentsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileContentsParams(FileContentsParams fileContentsParams)
        : base(fileContentsParams)
    {
        this.FileID = fileContentsParams.FileID;
    }
#pragma warning restore CS8618

    public FileContentsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileContentsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string fileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.FileID = fileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FileContentsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string fileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            fileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FileID"] = JsonSerializer.SerializeToElement(this.FileID),
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

    public virtual bool Equals(FileContentsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.FileID?.Equals(other.FileID) ?? other.FileID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/files/{0}/contents", this.FileID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        request.Headers.Add("Accept", "application/octet-stream");
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
