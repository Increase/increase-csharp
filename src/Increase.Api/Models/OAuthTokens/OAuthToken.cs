using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.OAuthTokens;

/// <summary>
/// A token that is returned to your application when a user completes the OAuth
/// flow and may be used to authenticate requests. Learn more about OAuth [here](/documentation/oauth).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OAuthToken, OAuthTokenFromRaw>))]
public sealed record class OAuthToken : JsonModel
{
    /// <summary>
    /// You may use this token in place of an API key to make OAuth requests on a
    /// user's behalf.
    /// </summary>
    public required string AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("access_token");
        }
        init { this._rawData.Set("access_token", value); }
    }

    /// <summary>
    /// The Group's identifier. A Group is the top-level organization in Increase.
    /// </summary>
    public required string GroupID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_id");
        }
        init { this._rawData.Set("group_id", value); }
    }

    /// <summary>
    /// The type of OAuth token.
    /// </summary>
    public required ApiEnum<string, TokenType> TokenType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TokenType>>("token_type");
        }
        init { this._rawData.Set("token_type", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `oauth_token`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.OAuthTokens.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.OAuthTokens.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.GroupID;
        this.TokenType.Validate();
        this.Type.Validate();
    }

    public OAuthToken() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthToken(OAuthToken oauthToken)
        : base(oauthToken) { }
#pragma warning restore CS8618

    public OAuthToken(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthToken(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OAuthTokenFromRaw.FromRawUnchecked"/>
    public static OAuthToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OAuthTokenFromRaw : IFromRawJson<OAuthToken>
{
    /// <inheritdoc/>
    public OAuthToken FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OAuthToken.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of OAuth token.
/// </summary>
[JsonConverter(typeof(TokenTypeConverter))]
public enum TokenType
{
    Bearer,
}

sealed class TokenTypeConverter : JsonConverter<TokenType>
{
    public override TokenType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bearer" => TokenType.Bearer,
            _ => (TokenType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TokenType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TokenType.Bearer => "bearer",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `oauth_token`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    OAuthToken,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.OAuthTokens.Type>
{
    public override global::Increase.Api.Models.OAuthTokens.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "oauth_token" => global::Increase.Api.Models.OAuthTokens.Type.OAuthToken,
            _ => (global::Increase.Api.Models.OAuthTokens.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.OAuthTokens.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.OAuthTokens.Type.OAuthToken => "oauth_token",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
