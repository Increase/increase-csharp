using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.PhysicalCheckBatches;

/// <summary>
/// Physical Check Batches are groups of checks that are mailed in the same parcel.
/// Tracking updates are propagated to every related Check Transfer.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhysicalCheckBatch, PhysicalCheckBatchFromRaw>))]
public sealed record class PhysicalCheckBatch : JsonModel
{
    /// <summary>
    /// The Physical Check Batch's identifier.
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
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time at which
    /// the Physical Check Batch was created.
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
    /// The mailing address of the parcel.
    /// </summary>
    public required PhysicalCheckBatchMailingAddress MailingAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhysicalCheckBatchMailingAddress>(
                "mailing_address"
            );
        }
        init { this._rawData.Set("mailing_address", value); }
    }

    /// <summary>
    /// The return address of the parcel.
    /// </summary>
    public required PhysicalCheckBatchReturnAddress ReturnAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhysicalCheckBatchReturnAddress>("return_address");
        }
        init { this._rawData.Set("return_address", value); }
    }

    /// <summary>
    /// The shipping method for the parcel.
    /// </summary>
    public required ApiEnum<string, PhysicalCheckBatchShippingMethod> ShippingMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, PhysicalCheckBatchShippingMethod>>(
                "shipping_method"
            );
        }
        init { this._rawData.Set("shipping_method", value); }
    }

    /// <summary>
    /// The lifecycle status of the Physical Check Batch.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `physical_check_batch`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.PhysicalCheckBatches.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.PhysicalCheckBatches.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.IdempotencyKey;
        this.MailingAddress.Validate();
        this.ReturnAddress.Validate();
        this.ShippingMethod.Validate();
        this.Status.Validate();
        this.Type.Validate();
    }

    public PhysicalCheckBatch() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCheckBatch(PhysicalCheckBatch physicalCheckBatch)
        : base(physicalCheckBatch) { }
#pragma warning restore CS8618

    public PhysicalCheckBatch(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCheckBatch(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCheckBatchFromRaw.FromRawUnchecked"/>
    public static PhysicalCheckBatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCheckBatchFromRaw : IFromRawJson<PhysicalCheckBatch>
{
    /// <inheritdoc/>
    public PhysicalCheckBatch FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PhysicalCheckBatch.FromRawUnchecked(rawData);
}

/// <summary>
/// The mailing address of the parcel.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PhysicalCheckBatchMailingAddress,
        PhysicalCheckBatchMailingAddressFromRaw
    >)
)]
public sealed record class PhysicalCheckBatchMailingAddress : JsonModel
{
    /// <summary>
    /// The city of the address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the address.
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
    /// The second line of the address.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The name component of the address.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The phone number that is used for delivery issues.
    /// </summary>
    public required string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <summary>
    /// The postal code of the address.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The state of the address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Name;
        _ = this.Phone;
        _ = this.PostalCode;
        _ = this.State;
    }

    public PhysicalCheckBatchMailingAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCheckBatchMailingAddress(
        PhysicalCheckBatchMailingAddress physicalCheckBatchMailingAddress
    )
        : base(physicalCheckBatchMailingAddress) { }
#pragma warning restore CS8618

    public PhysicalCheckBatchMailingAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCheckBatchMailingAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCheckBatchMailingAddressFromRaw.FromRawUnchecked"/>
    public static PhysicalCheckBatchMailingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCheckBatchMailingAddressFromRaw : IFromRawJson<PhysicalCheckBatchMailingAddress>
{
    /// <inheritdoc/>
    public PhysicalCheckBatchMailingAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhysicalCheckBatchMailingAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The return address of the parcel.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PhysicalCheckBatchReturnAddress,
        PhysicalCheckBatchReturnAddressFromRaw
    >)
)]
public sealed record class PhysicalCheckBatchReturnAddress : JsonModel
{
    /// <summary>
    /// The city of the return address.
    /// </summary>
    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// The first line of the return address.
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
    /// The second line of the return address.
    /// </summary>
    public required string? Line2
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("line2");
        }
        init { this._rawData.Set("line2", value); }
    }

    /// <summary>
    /// The name component of the return address.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The phone number that is used for delivery issues.
    /// </summary>
    public required string? Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    /// <summary>
    /// The postal code of the return address.
    /// </summary>
    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postal_code");
        }
        init { this._rawData.Set("postal_code", value); }
    }

    /// <summary>
    /// The state of the return address.
    /// </summary>
    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Line1;
        _ = this.Line2;
        _ = this.Name;
        _ = this.Phone;
        _ = this.PostalCode;
        _ = this.State;
    }

    public PhysicalCheckBatchReturnAddress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhysicalCheckBatchReturnAddress(
        PhysicalCheckBatchReturnAddress physicalCheckBatchReturnAddress
    )
        : base(physicalCheckBatchReturnAddress) { }
#pragma warning restore CS8618

    public PhysicalCheckBatchReturnAddress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhysicalCheckBatchReturnAddress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhysicalCheckBatchReturnAddressFromRaw.FromRawUnchecked"/>
    public static PhysicalCheckBatchReturnAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhysicalCheckBatchReturnAddressFromRaw : IFromRawJson<PhysicalCheckBatchReturnAddress>
{
    /// <inheritdoc/>
    public PhysicalCheckBatchReturnAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhysicalCheckBatchReturnAddress.FromRawUnchecked(rawData);
}

/// <summary>
/// The shipping method for the parcel.
/// </summary>
[JsonConverter(typeof(PhysicalCheckBatchShippingMethodConverter))]
public enum PhysicalCheckBatchShippingMethod
{
    /// <summary>
    /// USPS First Class
    /// </summary>
    UspsFirstClass,

    /// <summary>
    /// FedEx Overnight
    /// </summary>
    FedexOvernight,
}

sealed class PhysicalCheckBatchShippingMethodConverter
    : JsonConverter<PhysicalCheckBatchShippingMethod>
{
    public override PhysicalCheckBatchShippingMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "usps_first_class" => PhysicalCheckBatchShippingMethod.UspsFirstClass,
            "fedex_overnight" => PhysicalCheckBatchShippingMethod.FedexOvernight,
            _ => (PhysicalCheckBatchShippingMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhysicalCheckBatchShippingMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PhysicalCheckBatchShippingMethod.UspsFirstClass => "usps_first_class",
                PhysicalCheckBatchShippingMethod.FedexOvernight => "fedex_overnight",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The lifecycle status of the Physical Check Batch.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    /// <summary>
    /// The batch is pending completion and is open to accepting new checks.
    /// </summary>
    Pending,

    /// <summary>
    /// The batch has been completed.
    /// </summary>
    Completed,

    /// <summary>
    /// The batch and all checks related to it have been canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// The batch requires attention from an Increase operator.
    /// </summary>
    RequiresAttention,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => Status.Pending,
            "completed" => Status.Completed,
            "canceled" => Status.Canceled,
            "requires_attention" => Status.RequiresAttention,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Pending => "pending",
                Status.Completed => "completed",
                Status.Canceled => "canceled",
                Status.RequiresAttention => "requires_attention",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `physical_check_batch`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    PhysicalCheckBatch,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.PhysicalCheckBatches.Type>
{
    public override global::Increase.Api.Models.PhysicalCheckBatches.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "physical_check_batch" => global::Increase
                .Api
                .Models
                .PhysicalCheckBatches
                .Type
                .PhysicalCheckBatch,
            _ => (global::Increase.Api.Models.PhysicalCheckBatches.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.PhysicalCheckBatches.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.PhysicalCheckBatches.Type.PhysicalCheckBatch =>
                    "physical_check_batch",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
