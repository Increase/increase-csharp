using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;

namespace Increase.Api.Models.DigitalCardProfiles;

/// <summary>
/// Clone a Digital Card Profile
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DigitalCardProfileCloneParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? DigitalCardProfileID { get; init; }

    /// <summary>
    /// The identifier of the File containing the card's icon image.
    /// </summary>
    public string? AppIconFileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("app_icon_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("app_icon_file_id", value);
        }
    }

    /// <summary>
    /// Apple Pay specific settings for the Card Profile. Each list you leave out
    /// is copied from the original Card Profile.
    /// </summary>
    public DigitalCardProfileCloneParamsApplePay? ApplePay
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DigitalCardProfileCloneParamsApplePay>(
                "apple_pay"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("apple_pay", value);
        }
    }

    /// <summary>
    /// The identifier of the File containing the card's front image.
    /// </summary>
    public string? BackgroundImageFileID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("background_image_file_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("background_image_file_id", value);
        }
    }

    /// <summary>
    /// A user-facing description for the card itself.
    /// </summary>
    public string? CardDescription
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("card_description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("card_description", value);
        }
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
    /// The name of your company or card program, shown to the user as who to contact
    /// for support with their card.
    /// </summary>
    public string? ContactName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("contact_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("contact_name", value);
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
    /// The Card's text color, specified as an RGB triple. The default is white.
    /// </summary>
    public DigitalCardProfileCloneParamsTextColor? TextColor
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DigitalCardProfileCloneParamsTextColor>(
                "text_color"
            );
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

    public DigitalCardProfileCloneParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfileCloneParams(
        DigitalCardProfileCloneParams digitalCardProfileCloneParams
    )
        : base(digitalCardProfileCloneParams)
    {
        this.DigitalCardProfileID = digitalCardProfileCloneParams.DigitalCardProfileID;

        this._rawBodyData = new(digitalCardProfileCloneParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DigitalCardProfileCloneParams(
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
    DigitalCardProfileCloneParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string digitalCardProfileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.DigitalCardProfileID = digitalCardProfileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DigitalCardProfileCloneParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string digitalCardProfileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            digitalCardProfileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["DigitalCardProfileID"] = JsonSerializer.SerializeToElement(
                        this.DigitalCardProfileID
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

    public virtual bool Equals(DigitalCardProfileCloneParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (
                this.DigitalCardProfileID?.Equals(other.DigitalCardProfileID)
                ?? other.DigitalCardProfileID == null
            )
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/digital_card_profiles/{0}/clone", this.DigitalCardProfileID)
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
/// Apple Pay specific settings for the Card Profile. Each list you leave out is
/// copied from the original Card Profile.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DigitalCardProfileCloneParamsApplePay,
        DigitalCardProfileCloneParamsApplePayFromRaw
    >)
)]
public sealed record class DigitalCardProfileCloneParamsApplePay : JsonModel
{
    /// <summary>
    /// The applications to associate with cards using this Card Profile.
    /// </summary>
    public IReadOnlyList<DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier>? AssociatedApplicationIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier>
            >("associated_application_identifiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier>?>(
                "associated_application_identifiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The App Store listings of the applications to associate with cards using
    /// this Card Profile.
    /// </summary>
    public IReadOnlyList<DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier>? AssociatedStoreIdentifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier>
            >("associated_store_identifiers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier>?>(
                "associated_store_identifiers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AssociatedApplicationIdentifiers ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.AssociatedStoreIdentifiers ?? [])
        {
            item.Validate();
        }
    }

    public DigitalCardProfileCloneParamsApplePay() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfileCloneParamsApplePay(
        DigitalCardProfileCloneParamsApplePay digitalCardProfileCloneParamsApplePay
    )
        : base(digitalCardProfileCloneParamsApplePay) { }
#pragma warning restore CS8618

    public DigitalCardProfileCloneParamsApplePay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalCardProfileCloneParamsApplePay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalCardProfileCloneParamsApplePayFromRaw.FromRawUnchecked"/>
    public static DigitalCardProfileCloneParamsApplePay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalCardProfileCloneParamsApplePayFromRaw
    : IFromRawJson<DigitalCardProfileCloneParamsApplePay>
{
    /// <inheritdoc/>
    public DigitalCardProfileCloneParamsApplePay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalCardProfileCloneParamsApplePay.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier,
        DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifierFromRaw
    >)
)]
public sealed record class DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier
    : JsonModel
{
    /// <summary>
    /// The application identifier, composed of your Apple Developer Team ID and the
    /// application's bundle identifier, like `ABCDE12345.com.example.app`.
    /// </summary>
    public required string Identifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identifier");
        }
        init { this._rawData.Set("identifier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Identifier;
    }

    public DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier(
        DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier digitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier
    )
        : base(digitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier) { }
#pragma warning restore CS8618

    public DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifierFromRaw.FromRawUnchecked"/>
    public static DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier(string identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifierFromRaw
    : IFromRawJson<DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier>
{
    /// <inheritdoc/>
    public DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        DigitalCardProfileCloneParamsApplePayAssociatedApplicationIdentifier.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier,
        DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifierFromRaw
    >)
)]
public sealed record class DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier
    : JsonModel
{
    /// <summary>
    /// The numeric App Store identifier.
    /// </summary>
    public required string Identifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identifier");
        }
        init { this._rawData.Set("identifier", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Identifier;
    }

    public DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier(
        DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier digitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier
    )
        : base(digitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier) { }
#pragma warning restore CS8618

    public DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifierFromRaw.FromRawUnchecked"/>
    public static DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier(string identifier)
        : this()
    {
        this.Identifier = identifier;
    }
}

class DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifierFromRaw
    : IFromRawJson<DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier>
{
    /// <inheritdoc/>
    public DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalCardProfileCloneParamsApplePayAssociatedStoreIdentifier.FromRawUnchecked(rawData);
}

/// <summary>
/// The Card's text color, specified as an RGB triple. The default is white.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DigitalCardProfileCloneParamsTextColor,
        DigitalCardProfileCloneParamsTextColorFromRaw
    >)
)]
public sealed record class DigitalCardProfileCloneParamsTextColor : JsonModel
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

    public DigitalCardProfileCloneParamsTextColor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DigitalCardProfileCloneParamsTextColor(
        DigitalCardProfileCloneParamsTextColor digitalCardProfileCloneParamsTextColor
    )
        : base(digitalCardProfileCloneParamsTextColor) { }
#pragma warning restore CS8618

    public DigitalCardProfileCloneParamsTextColor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DigitalCardProfileCloneParamsTextColor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DigitalCardProfileCloneParamsTextColorFromRaw.FromRawUnchecked"/>
    public static DigitalCardProfileCloneParamsTextColor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DigitalCardProfileCloneParamsTextColorFromRaw
    : IFromRawJson<DigitalCardProfileCloneParamsTextColor>
{
    /// <inheritdoc/>
    public DigitalCardProfileCloneParamsTextColor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DigitalCardProfileCloneParamsTextColor.FromRawUnchecked(rawData);
}
