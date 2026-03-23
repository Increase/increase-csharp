using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.ExternalAccounts;

/// <summary>
/// List External Accounts
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalAccountListParams : ParamsBase
{
    /// <summary>
    /// Return the page of entries after this one.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Filter records to the one with the specified `idempotency_key` you chose for
    /// that object. This value is unique across Increase and is used to ensure that
    /// a request is only processed once. Learn more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public string? IdempotencyKey
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("idempotency_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("idempotency_key", value);
        }
    }

    /// <summary>
    /// Limit the size of the list that is returned. The default (and maximum) is
    /// 100 objects.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Filter External Accounts to those with the specified Routing Number.
    /// </summary>
    public string? RoutingNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("routing_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("routing_number", value);
        }
    }

    public ExternalAccountListParamsStatus? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ExternalAccountListParamsStatus>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    public ExternalAccountListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalAccountListParams(ExternalAccountListParams externalAccountListParams)
        : base(externalAccountListParams) { }
#pragma warning restore CS8618

    public ExternalAccountListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalAccountListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExternalAccountListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(ExternalAccountListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/external_accounts"
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

[JsonConverter(
    typeof(JsonModelConverter<
        ExternalAccountListParamsStatus,
        ExternalAccountListParamsStatusFromRaw
    >)
)]
public sealed record class ExternalAccountListParamsStatus : JsonModel
{
    /// <summary>
    /// Filter External Accounts for those with the specified status or statuses.
    /// For GET requests, this should be encoded as a comma-delimited string, such
    /// as `?in=one,two,three`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, In>>? In
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, In>>>("in");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, In>>?>(
                "in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.In ?? [])
        {
            item.Validate();
        }
    }

    public ExternalAccountListParamsStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalAccountListParamsStatus(
        ExternalAccountListParamsStatus externalAccountListParamsStatus
    )
        : base(externalAccountListParamsStatus) { }
#pragma warning restore CS8618

    public ExternalAccountListParamsStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalAccountListParamsStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalAccountListParamsStatusFromRaw.FromRawUnchecked"/>
    public static ExternalAccountListParamsStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalAccountListParamsStatusFromRaw : IFromRawJson<ExternalAccountListParamsStatus>
{
    /// <inheritdoc/>
    public ExternalAccountListParamsStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalAccountListParamsStatus.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InConverter))]
public enum In
{
    /// <summary>
    /// The External Account is active.
    /// </summary>
    Active,

    /// <summary>
    /// The External Account is archived and won't appear in the dashboard.
    /// </summary>
    Archived,
}

sealed class InConverter : JsonConverter<In>
{
    public override In Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => In.Active,
            "archived" => In.Archived,
            _ => (In)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, In value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                In.Active => "active",
                In.Archived => "archived",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
