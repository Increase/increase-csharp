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

namespace Increase.Api.Models.Cards;

/// <summary>
/// List Cards
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardListParams : ParamsBase
{
    /// <summary>
    /// Filter Cards to ones belonging to the specified Account.
    /// </summary>
    public string? AccountID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("account_id", value);
        }
    }

    public CreatedAt? CreatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<CreatedAt>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at", value);
        }
    }

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

    public CardListParamsStatus? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<CardListParamsStatus>("status");
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

    public CardListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardListParams(CardListParams cardListParams)
        : base(cardListParams) { }
#pragma warning restore CS8618

    public CardListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CardListParams FromRawUnchecked(
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

    public virtual bool Equals(CardListParams? other)
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
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/cards")
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

[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    /// <summary>
    /// Return results after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Return results before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <summary>
    /// Return results on or after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after", value);
        }
    }

    /// <summary>
    /// Return results on or before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
        _ = this.OnOrAfter;
        _ = this.OnOrBefore;
    }

    public CreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt(CreatedAt createdAt)
        : base(createdAt) { }
#pragma warning restore CS8618

    public CreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CardListParamsStatus, CardListParamsStatusFromRaw>))]
public sealed record class CardListParamsStatus : JsonModel
{
    /// <summary>
    /// Filter Cards by status. For GET requests, this should be encoded as a comma-delimited
    /// string, such as `?in=one,two,three`.
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

    public CardListParamsStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardListParamsStatus(CardListParamsStatus cardListParamsStatus)
        : base(cardListParamsStatus) { }
#pragma warning restore CS8618

    public CardListParamsStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardListParamsStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardListParamsStatusFromRaw.FromRawUnchecked"/>
    public static CardListParamsStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardListParamsStatusFromRaw : IFromRawJson<CardListParamsStatus>
{
    /// <inheritdoc/>
    public CardListParamsStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardListParamsStatus.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InConverter))]
public enum In
{
    /// <summary>
    /// The card is active.
    /// </summary>
    Active,

    /// <summary>
    /// The card is temporarily disabled.
    /// </summary>
    Disabled,

    /// <summary>
    /// The card is permanently canceled.
    /// </summary>
    Canceled,
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
            "disabled" => In.Disabled,
            "canceled" => In.Canceled,
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
                In.Disabled => "disabled",
                In.Canceled => "canceled",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
