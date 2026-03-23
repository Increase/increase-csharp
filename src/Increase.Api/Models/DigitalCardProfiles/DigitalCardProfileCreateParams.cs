using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.DigitalCardProfiles;

/// <summary>
/// Create a Digital Card Profile
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DigitalCardProfileCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the File containing the card's icon image.
    /// </summary>
    public required string AppIconFileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("app_icon_file_id");
        }
        init { this._rawBodyData.Set("app_icon_file_id", value); }
    }

    /// <summary>
    /// The identifier of the File containing the card's front image.
    /// </summary>
    public required string BackgroundImageFileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("background_image_file_id");
        }
        init { this._rawBodyData.Set("background_image_file_id", value); }
    }

    /// <summary>
    /// A user-facing description for the card itself.
    /// </summary>
    public required string CardDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("card_description");
        }
        init { this._rawBodyData.Set("card_description", value); }
    }

    /// <summary>
    /// A description you can use to identify the Card Profile.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// A user-facing description for whoever is issuing the card.
    /// </summary>
    public required string IssuerName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("issuer_name");
        }
        init { this._rawBodyData.Set("issuer_name", value); }
    }

    /// <summary>
    /// An email address the user can contact to receive support for their card.
    /// </summary>
    public string? ContactEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("contact_email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contact_email", value);
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
    /// A website the user can visit to view and receive support for their card.
    /// </summary>
    public string? ContactWebsite
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("contact_website");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contact_website", value);
        }
    }

    /// <summary>
    /// The Card's text color, specified as an RGB triple. The default is white.
    /// </summary>
    public TextColor? TextColor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TextColor>("text_color");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("text_color", value);
        }
    }

    public DigitalCardProfileCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfileCreateParams(
        DigitalCardProfileCreateParams digitalCardProfileCreateParams
    )
        : base(digitalCardProfileCreateParams)
    {
        this._rawBodyData = new(digitalCardProfileCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DigitalCardProfileCreateParams(
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
    DigitalCardProfileCreateParams(
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
    public static DigitalCardProfileCreateParams FromRawUnchecked(
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

    public virtual bool Equals(DigitalCardProfileCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/digital_card_profiles")
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
/// The Card's text color, specified as an RGB triple. The default is white.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TextColor, TextColorFromRaw>))]
public sealed record class TextColor : JsonModel
{
    /// <summary>
    /// The value of the blue channel in the RGB color.
    /// </summary>
    public required long Blue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("blue");
        }
        init { this._rawData.Set("blue", value); }
    }

    /// <summary>
    /// The value of the green channel in the RGB color.
    /// </summary>
    public required long Green
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("green");
        }
        init { this._rawData.Set("green", value); }
    }

    /// <summary>
    /// The value of the red channel in the RGB color.
    /// </summary>
    public required long Red
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("red");
        }
        init { this._rawData.Set("red", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Blue;
        _ = this.Green;
        _ = this.Red;
    }

    public TextColor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextColor(TextColor textColor)
        : base(textColor) { }
#pragma warning restore CS8618

    public TextColor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextColor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextColorFromRaw.FromRawUnchecked"/>
    public static TextColor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextColorFromRaw : IFromRawJson<TextColor>
{
    /// <inheritdoc/>
    public TextColor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextColor.FromRawUnchecked(rawData);
}
