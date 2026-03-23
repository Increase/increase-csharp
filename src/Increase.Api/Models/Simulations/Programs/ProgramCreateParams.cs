using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;

namespace Increase.Api.Models.Simulations.Programs;

/// <summary>
/// Simulates a [Program](#programs) being created in your group. By default, your
/// group has one program called Commercial Banking. Note that when your group operates
/// more than one program, `program_id` is a required field when creating accounts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ProgramCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The name of the program being added.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// The bank for the program's accounts, defaults to First Internet Bank.
    /// </summary>
    public ApiEnum<string, Bank>? Bank
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Bank>>("bank");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("bank", value);
        }
    }

    /// <summary>
    /// The maximum extendable credit of the program being added.
    /// </summary>
    public long? LendingMaximumExtendableCredit
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("lending_maximum_extendable_credit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("lending_maximum_extendable_credit", value);
        }
    }

    /// <summary>
    /// The identifier of the Account the Program should be added to is for.
    /// </summary>
    public string? ReserveAccountID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("reserve_account_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("reserve_account_id", value);
        }
    }

    public ProgramCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProgramCreateParams(ProgramCreateParams programCreateParams)
        : base(programCreateParams)
    {
        this._rawBodyData = new(programCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ProgramCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProgramCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ProgramCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ProgramCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/simulations/programs")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// The bank for the program's accounts, defaults to First Internet Bank.
/// </summary>
[JsonConverter(typeof(BankConverter))]
public enum Bank
{
    /// <summary>
    /// Core Bank
    /// </summary>
    CoreBank,

    /// <summary>
    /// First Internet Bank of Indiana
    /// </summary>
    FirstInternetBank,

    /// <summary>
    /// Grasshopper Bank
    /// </summary>
    GrasshopperBank,

    /// <summary>
    /// Twin City Bank
    /// </summary>
    TwinCityBank,
}

sealed class BankConverter : JsonConverter<Bank>
{
    public override Bank Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "core_bank" => Bank.CoreBank,
            "first_internet_bank" => Bank.FirstInternetBank,
            "grasshopper_bank" => Bank.GrasshopperBank,
            "twin_city_bank" => Bank.TwinCityBank,
            _ => (Bank)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Bank value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Bank.CoreBank => "core_bank",
                Bank.FirstInternetBank => "first_internet_bank",
                Bank.GrasshopperBank => "grasshopper_bank",
                Bank.TwinCityBank => "twin_city_bank",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
