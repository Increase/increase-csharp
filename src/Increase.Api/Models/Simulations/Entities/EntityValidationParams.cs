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
using Increase.Api.Exceptions;

namespace Increase.Api.Models.Simulations.Entities;

/// <summary>
/// Set the status for an [Entity's validation](/documentation/api/entities#entity-object.validation).
/// In production, Know Your Customer validations [run automatically](/documentation/entity-validation#entity-validation).
/// While developing, it can be helpful to override the behavior in Sandbox.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EntityValidationParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? EntityID { get; init; }

    /// <summary>
    /// The validation issues to attach. Only allowed when `status` is `invalid`.
    /// </summary>
    public required IReadOnlyList<Issue> Issues
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Issue>>("issues");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Issue>>(
                "issues",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The validation status to set on the Entity.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawBodyData.Set("status", value); }
    }

    public EntityValidationParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EntityValidationParams(EntityValidationParams entityValidationParams)
        : base(entityValidationParams)
    {
        this.EntityID = entityValidationParams.EntityID;

        this._rawBodyData = new(entityValidationParams._rawBodyData);
    }
#pragma warning restore CS8618

    public EntityValidationParams(
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
    EntityValidationParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string entityID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.EntityID = entityID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EntityValidationParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string entityID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            entityID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["EntityID"] = JsonSerializer.SerializeToElement(this.EntityID),
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

    public virtual bool Equals(EntityValidationParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EntityID?.Equals(other.EntityID) ?? other.EntityID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/simulations/entities/{0}/validation", this.EntityID)
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

[JsonConverter(typeof(JsonModelConverter<Issue, IssueFromRaw>))]
public sealed record class Issue : JsonModel
{
    /// <summary>
    /// The type of issue.
    /// </summary>
    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Category.Validate();
    }

    public Issue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Issue(Issue issue)
        : base(issue) { }
#pragma warning restore CS8618

    public Issue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Issue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IssueFromRaw.FromRawUnchecked"/>
    public static Issue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Issue(ApiEnum<string, Category> category)
        : this()
    {
        this.Category = category;
    }
}

class IssueFromRaw : IFromRawJson<Issue>
{
    /// <inheritdoc/>
    public Issue FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Issue.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of issue.
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    /// <summary>
    /// The entity's tax identifier could not be validated. Update the tax ID with
    /// the [update an entity API](/documentation/api/entities#update-an-entity.corporation.legal_identifier).
    /// </summary>
    EntityTaxIdentifier,

    /// <summary>
    /// The entity's address could not be validated. Update the address with the
    /// [update an entity API](/documentation/api/entities#update-an-entity.corporation.address).
    /// </summary>
    EntityAddress,

    /// <summary>
    /// A beneficial owner's identity could not be verified. Update the identification
    /// with the [update a beneficial owner API](/documentation/api/beneficial-owners#update-a-beneficial-owner).
    /// </summary>
    BeneficialOwnerIdentity,

    /// <summary>
    /// A beneficial owner's address could not be validated. Update the address with
    /// the [update a beneficial owner API](/documentation/api/beneficial-owners#update-a-beneficial-owner).
    /// </summary>
    BeneficialOwnerAddress,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "entity_tax_identifier" => Category.EntityTaxIdentifier,
            "entity_address" => Category.EntityAddress,
            "beneficial_owner_identity" => Category.BeneficialOwnerIdentity,
            "beneficial_owner_address" => Category.BeneficialOwnerAddress,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.EntityTaxIdentifier => "entity_tax_identifier",
                Category.EntityAddress => "entity_address",
                Category.BeneficialOwnerIdentity => "beneficial_owner_identity",
                Category.BeneficialOwnerAddress => "beneficial_owner_address",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The validation status to set on the Entity.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The submitted data is valid.
    /// </summary>
    Valid,

    /// <summary>
    /// Additional information is required to validate the data.
    /// </summary>
    Invalid,

    /// <summary>
    /// The submitted data is being validated.
    /// </summary>
    Pending,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "valid" => Status.Valid,
            "invalid" => Status.Invalid,
            "pending" => Status.Pending,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Valid => "valid",
                Status.Invalid => "invalid",
                Status.Pending => "pending",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
