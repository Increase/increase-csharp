using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.IntrafiAccountEnrollments;

/// <summary>
/// IntraFi is a [network of financial institutions](https://www.intrafi.com/network-banks)
/// that allows Increase users to sweep funds to multiple banks. This enables accounts
/// to become eligible for additional Federal Deposit Insurance Corporation (FDIC)
/// insurance. An IntraFi Account Enrollment object represents the status of an account
/// in the network. Sweeping an account to IntraFi doesn't affect funds availability.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IntrafiAccountEnrollment, IntrafiAccountEnrollmentFromRaw>)
)]
public sealed record class IntrafiAccountEnrollment : JsonModel
{
    /// <summary>
    /// The identifier of this enrollment at IntraFi.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The identifier of the Increase Account being swept into the network.
    /// </summary>
    public required string AccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("account_id");
        }
        init { this._rawData.Set("account_id", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the enrollment was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The contact email for the account owner, to be shared with IntraFi.
    /// </summary>
    public required string? EmailAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email_address");
        }
        init { this._rawData.Set("email_address", value); }
    }

    /// <summary>
    /// The idempotency key you chose for this object. This value is unique across
    /// Increase and is used to ensure that a request is only processed once. Learn
    /// more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public required string? IdempotencyKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("idempotency_key");
        }
        init { this._rawData.Set("idempotency_key", value); }
    }

    /// <summary>
    /// The identifier of the account in IntraFi's system. This identifier will be
    /// printed on any IntraFi statements or documents.
    /// </summary>
    public required string IntrafiID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("intrafi_id");
        }
        init { this._rawData.Set("intrafi_id", value); }
    }

    /// <summary>
    /// The status of the account in the network. An account takes about one business
    /// day to go from `pending_enrolling` to `enrolled`.
    /// </summary>
    public required ApiEnum<string, IntrafiAccountEnrollmentStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, IntrafiAccountEnrollmentStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `intrafi_account_enrollment`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.IntrafiAccountEnrollments.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.IntrafiAccountEnrollments.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountID;
        _ = this.CreatedAt;
        _ = this.EmailAddress;
        _ = this.IdempotencyKey;
        _ = this.IntrafiID;
        this.Status.Validate();
        this.Type.Validate();
    }

    public IntrafiAccountEnrollment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntrafiAccountEnrollment(IntrafiAccountEnrollment intrafiAccountEnrollment)
        : base(intrafiAccountEnrollment) { }
#pragma warning restore CS8618

    public IntrafiAccountEnrollment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntrafiAccountEnrollment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntrafiAccountEnrollmentFromRaw.FromRawUnchecked"/>
    public static IntrafiAccountEnrollment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntrafiAccountEnrollmentFromRaw : IFromRawJson<IntrafiAccountEnrollment>
{
    /// <inheritdoc/>
    public IntrafiAccountEnrollment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntrafiAccountEnrollment.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the account in the network. An account takes about one business
/// day to go from `pending_enrolling` to `enrolled`.
/// </summary>
[JsonConverter(typeof(IntrafiAccountEnrollmentStatusConverter))]
public enum IntrafiAccountEnrollmentStatus
{
    /// <summary>
    /// The account is being added to the IntraFi network.
    /// </summary>
    PendingEnrolling,

    /// <summary>
    /// The account has been enrolled with IntraFi.
    /// </summary>
    Enrolled,

    /// <summary>
    /// The account is being unenrolled from IntraFi's deposit sweep.
    /// </summary>
    PendingUnenrolling,

    /// <summary>
    /// The account was once enrolled, but is no longer enrolled at IntraFi.
    /// </summary>
    Unenrolled,

    /// <summary>
    /// Something unexpected happened with this account. Contact Increase support.
    /// </summary>
    RequiresAttention,
}

sealed class IntrafiAccountEnrollmentStatusConverter : JsonConverter<IntrafiAccountEnrollmentStatus>
{
    public override IntrafiAccountEnrollmentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_enrolling" => IntrafiAccountEnrollmentStatus.PendingEnrolling,
            "enrolled" => IntrafiAccountEnrollmentStatus.Enrolled,
            "pending_unenrolling" => IntrafiAccountEnrollmentStatus.PendingUnenrolling,
            "unenrolled" => IntrafiAccountEnrollmentStatus.Unenrolled,
            "requires_attention" => IntrafiAccountEnrollmentStatus.RequiresAttention,
            _ => (IntrafiAccountEnrollmentStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IntrafiAccountEnrollmentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IntrafiAccountEnrollmentStatus.PendingEnrolling => "pending_enrolling",
                IntrafiAccountEnrollmentStatus.Enrolled => "enrolled",
                IntrafiAccountEnrollmentStatus.PendingUnenrolling => "pending_unenrolling",
                IntrafiAccountEnrollmentStatus.Unenrolled => "unenrolled",
                IntrafiAccountEnrollmentStatus.RequiresAttention => "requires_attention",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `intrafi_account_enrollment`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    IntrafiAccountEnrollment,
}

sealed class TypeConverter
    : JsonConverter<global::Increase.Api.Models.IntrafiAccountEnrollments.Type>
{
    public override global::Increase.Api.Models.IntrafiAccountEnrollments.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "intrafi_account_enrollment" => global::Increase
                .Api
                .Models
                .IntrafiAccountEnrollments
                .Type
                .IntrafiAccountEnrollment,
            _ => (global::Increase.Api.Models.IntrafiAccountEnrollments.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.IntrafiAccountEnrollments.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase
                    .Api
                    .Models
                    .IntrafiAccountEnrollments
                    .Type
                    .IntrafiAccountEnrollment => "intrafi_account_enrollment",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
