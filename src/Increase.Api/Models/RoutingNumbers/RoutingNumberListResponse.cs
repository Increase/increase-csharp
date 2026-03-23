using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.RoutingNumbers;

/// <summary>
/// Routing numbers are used to identify your bank in a financial transaction.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RoutingNumberListResponse, RoutingNumberListResponseFromRaw>)
)]
public sealed record class RoutingNumberListResponse : JsonModel
{
    /// <summary>
    /// This routing number's support for ACH Transfers.
    /// </summary>
    public required ApiEnum<string, RoutingNumberListResponseAchTransfers> AchTransfers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RoutingNumberListResponseAchTransfers>
            >("ach_transfers");
        }
        init { this._rawData.Set("ach_transfers", value); }
    }

    /// <summary>
    /// This routing number's support for FedNow Transfers.
    /// </summary>
    public required ApiEnum<string, RoutingNumberListResponseFednowTransfers> FednowTransfers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RoutingNumberListResponseFednowTransfers>
            >("fednow_transfers");
        }
        init { this._rawData.Set("fednow_transfers", value); }
    }

    /// <summary>
    /// The name of the financial institution belonging to a routing number.
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
    /// This routing number's support for Real-Time Payments Transfers.
    /// </summary>
    public required ApiEnum<
        string,
        RoutingNumberListResponseRealTimePaymentsTransfers
    > RealTimePaymentsTransfers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RoutingNumberListResponseRealTimePaymentsTransfers>
            >("real_time_payments_transfers");
        }
        init { this._rawData.Set("real_time_payments_transfers", value); }
    }

    /// <summary>
    /// The nine digit routing number identifier.
    /// </summary>
    public required string RoutingNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("routing_number");
        }
        init { this._rawData.Set("routing_number", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `routing_number`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.RoutingNumbers.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.RoutingNumbers.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// This routing number's support for Wire Transfers.
    /// </summary>
    public required ApiEnum<string, RoutingNumberListResponseWireTransfers> WireTransfers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, RoutingNumberListResponseWireTransfers>
            >("wire_transfers");
        }
        init { this._rawData.Set("wire_transfers", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AchTransfers.Validate();
        this.FednowTransfers.Validate();
        _ = this.Name;
        this.RealTimePaymentsTransfers.Validate();
        _ = this.RoutingNumber;
        this.Type.Validate();
        this.WireTransfers.Validate();
    }

    public RoutingNumberListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoutingNumberListResponse(RoutingNumberListResponse routingNumberListResponse)
        : base(routingNumberListResponse) { }
#pragma warning restore CS8618

    public RoutingNumberListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RoutingNumberListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RoutingNumberListResponseFromRaw.FromRawUnchecked"/>
    public static RoutingNumberListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RoutingNumberListResponseFromRaw : IFromRawJson<RoutingNumberListResponse>
{
    /// <inheritdoc/>
    public RoutingNumberListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RoutingNumberListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// This routing number's support for ACH Transfers.
/// </summary>
[JsonConverter(typeof(RoutingNumberListResponseAchTransfersConverter))]
public enum RoutingNumberListResponseAchTransfers
{
    /// <summary>
    /// The routing number can receive this transfer type.
    /// </summary>
    Supported,

    /// <summary>
    /// The routing number cannot receive this transfer type.
    /// </summary>
    NotSupported,
}

sealed class RoutingNumberListResponseAchTransfersConverter
    : JsonConverter<RoutingNumberListResponseAchTransfers>
{
    public override RoutingNumberListResponseAchTransfers Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => RoutingNumberListResponseAchTransfers.Supported,
            "not_supported" => RoutingNumberListResponseAchTransfers.NotSupported,
            _ => (RoutingNumberListResponseAchTransfers)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingNumberListResponseAchTransfers value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingNumberListResponseAchTransfers.Supported => "supported",
                RoutingNumberListResponseAchTransfers.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This routing number's support for FedNow Transfers.
/// </summary>
[JsonConverter(typeof(RoutingNumberListResponseFednowTransfersConverter))]
public enum RoutingNumberListResponseFednowTransfers
{
    /// <summary>
    /// The routing number can receive this transfer type.
    /// </summary>
    Supported,

    /// <summary>
    /// The routing number cannot receive this transfer type.
    /// </summary>
    NotSupported,
}

sealed class RoutingNumberListResponseFednowTransfersConverter
    : JsonConverter<RoutingNumberListResponseFednowTransfers>
{
    public override RoutingNumberListResponseFednowTransfers Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => RoutingNumberListResponseFednowTransfers.Supported,
            "not_supported" => RoutingNumberListResponseFednowTransfers.NotSupported,
            _ => (RoutingNumberListResponseFednowTransfers)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingNumberListResponseFednowTransfers value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingNumberListResponseFednowTransfers.Supported => "supported",
                RoutingNumberListResponseFednowTransfers.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This routing number's support for Real-Time Payments Transfers.
/// </summary>
[JsonConverter(typeof(RoutingNumberListResponseRealTimePaymentsTransfersConverter))]
public enum RoutingNumberListResponseRealTimePaymentsTransfers
{
    /// <summary>
    /// The routing number can receive this transfer type.
    /// </summary>
    Supported,

    /// <summary>
    /// The routing number cannot receive this transfer type.
    /// </summary>
    NotSupported,
}

sealed class RoutingNumberListResponseRealTimePaymentsTransfersConverter
    : JsonConverter<RoutingNumberListResponseRealTimePaymentsTransfers>
{
    public override RoutingNumberListResponseRealTimePaymentsTransfers Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
            "not_supported" => RoutingNumberListResponseRealTimePaymentsTransfers.NotSupported,
            _ => (RoutingNumberListResponseRealTimePaymentsTransfers)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingNumberListResponseRealTimePaymentsTransfers value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingNumberListResponseRealTimePaymentsTransfers.Supported => "supported",
                RoutingNumberListResponseRealTimePaymentsTransfers.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `routing_number`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    RoutingNumber,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.RoutingNumbers.Type>
{
    public override global::Increase.Api.Models.RoutingNumbers.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "routing_number" => global::Increase.Api.Models.RoutingNumbers.Type.RoutingNumber,
            _ => (global::Increase.Api.Models.RoutingNumbers.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.RoutingNumbers.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.RoutingNumbers.Type.RoutingNumber => "routing_number",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// This routing number's support for Wire Transfers.
/// </summary>
[JsonConverter(typeof(RoutingNumberListResponseWireTransfersConverter))]
public enum RoutingNumberListResponseWireTransfers
{
    /// <summary>
    /// The routing number can receive this transfer type.
    /// </summary>
    Supported,

    /// <summary>
    /// The routing number cannot receive this transfer type.
    /// </summary>
    NotSupported,
}

sealed class RoutingNumberListResponseWireTransfersConverter
    : JsonConverter<RoutingNumberListResponseWireTransfers>
{
    public override RoutingNumberListResponseWireTransfers Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "supported" => RoutingNumberListResponseWireTransfers.Supported,
            "not_supported" => RoutingNumberListResponseWireTransfers.NotSupported,
            _ => (RoutingNumberListResponseWireTransfers)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RoutingNumberListResponseWireTransfers value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RoutingNumberListResponseWireTransfers.Supported => "supported",
                RoutingNumberListResponseWireTransfers.NotSupported => "not_supported",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
