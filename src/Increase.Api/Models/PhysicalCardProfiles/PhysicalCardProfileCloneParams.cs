using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.PhysicalCardProfiles;

/// <summary>
/// Clone a Physical Card Profile
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhysicalCardProfileCloneParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PhysicalCardProfileID { get; init; }

    /// <summary>
    /// The identifier of the File containing the physical card's carrier image.
    /// </summary>
    public string? CarrierImageFileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("carrier_image_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("carrier_image_file_id", value);
        }
    }

    /// <summary>
    /// A phone number the user can contact to receive support for their card.
    /// </summary>
    public string? ContactPhone
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("contact_phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contact_phone", value);
        }
    }

    /// <summary>
    /// A description you can use to identify the Card Profile.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// The identifier of the File containing the physical card's front image.
    /// </summary>
    public string? FrontImageFileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("front_image_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("front_image_file_id", value);
        }
    }

    /// <summary>
    /// Text printed on the front of the card. Reach out to [support@increase.com](mailto:support@increase.com)
    /// for more information.
    /// </summary>
    public PhysicalCardProfileCloneParamsFrontText? FrontText
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<PhysicalCardProfileCloneParamsFrontText>(
                "front_text"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("front_text", value);
        }
    }

    /// <summary>
    /// The identifier of the Program to use for the cloned Physical Card Profile.
    /// </summary>
    public string? ProgramID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("program_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("program_id", value);
        }
    }

    public PhysicalCardProfileCloneParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardProfileCloneParams(
        PhysicalCardProfileCloneParams physicalCardProfileCloneParams
    )
        : base(physicalCardProfileCloneParams)
    {
        this.PhysicalCardProfileID = physicalCardProfileCloneParams.PhysicalCardProfileID;

        this._rawBodyData = new(physicalCardProfileCloneParams._rawBodyData);
    }
#pragma warning restore CS8618

    public PhysicalCardProfileCloneParams(
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
    PhysicalCardProfileCloneParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string physicalCardProfileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.PhysicalCardProfileID = physicalCardProfileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhysicalCardProfileCloneParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string physicalCardProfileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            physicalCardProfileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PhysicalCardProfileID"] = JsonSerializer.SerializeToElement(
                        this.PhysicalCardProfileID
                    ),
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

    public virtual bool Equals(PhysicalCardProfileCloneParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.PhysicalCardProfileID?.Equals(other.PhysicalCardProfileID)
                ?? other.PhysicalCardProfileID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/physical_card_profiles/{0}/clone", this.PhysicalCardProfileID)
        )
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
/// Text printed on the front of the card. Reach out to [support@increase.com](mailto:support@increase.com)
/// for more information.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PhysicalCardProfileCloneParamsFrontText,
        PhysicalCardProfileCloneParamsFrontTextFromRaw
    >)
)]
public sealed record class PhysicalCardProfileCloneParamsFrontText : JsonModel
{
    /// <summary>
    /// The first line of text on the front of the card.
    /// </summary>
    public required string Line1
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("line1");
        }
        init { this._rawData.Set("line1", value); }
    }

    /// <summary>
    /// The second line of text on the front of the card. Providing a second line
    /// moves the first line slightly higher and prints the second line in the spot
    /// where the first line would have otherwise been printed.
    /// </summary>
    public string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("line2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Line1;
        _ = this.Line2;
    }

    public PhysicalCardProfileCloneParamsFrontText() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCardProfileCloneParamsFrontText(
        PhysicalCardProfileCloneParamsFrontText physicalCardProfileCloneParamsFrontText
    )
        : base(physicalCardProfileCloneParamsFrontText) { }
#pragma warning restore CS8618

    public PhysicalCardProfileCloneParamsFrontText(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCardProfileCloneParamsFrontText(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCardProfileCloneParamsFrontTextFromRaw.FromRawUnchecked"/>
    public static PhysicalCardProfileCloneParamsFrontText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhysicalCardProfileCloneParamsFrontText(string line1)
        : this()
    {
        this.Line1 = line1;
    }
}

class PhysicalCardProfileCloneParamsFrontTextFromRaw
    : IFromRawJson<PhysicalCardProfileCloneParamsFrontText>
{
    /// <inheritdoc/>
    public PhysicalCardProfileCloneParamsFrontText FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhysicalCardProfileCloneParamsFrontText.FromRawUnchecked(rawData);
}
