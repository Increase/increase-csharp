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

namespace Increase.Api.Models.PendingTransactions;

/// <summary>
/// List Pending Transactions
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PendingTransactionListParams : ParamsBase
{
    /// <summary>
    /// Filter pending transactions to those belonging to the specified Account.
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

    public Category? Category
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Category>("category");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("category", value);
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

    /// <summary>
    /// Filter pending transactions to those belonging to the specified Route.
    /// </summary>
    public string? RouteID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("route_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("route_id", value);
        }
    }

    public Status? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Status>("status");
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

    public PendingTransactionListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PendingTransactionListParams(PendingTransactionListParams pendingTransactionListParams)
        : base(pendingTransactionListParams) { }
#pragma warning restore CS8618

    public PendingTransactionListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PendingTransactionListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PendingTransactionListParams FromRawUnchecked(
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

    public virtual bool Equals(PendingTransactionListParams? other)
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/pending_transactions"
        )
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

[JsonConverter(typeof(JsonModelConverter<Category, CategoryFromRaw>))]
public sealed record class Category : JsonModel
{
    /// <summary>
    /// Return results whose value is in the provided list. For GET requests, this
    /// should be encoded as a comma-delimited string, such as `?in=one,two,three`.
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

    public Category() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Category(Category category)
        : base(category) { }
#pragma warning restore CS8618

    public Category(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Category(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryFromRaw.FromRawUnchecked"/>
    public static Category FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryFromRaw : IFromRawJson<Category>
{
    /// <inheritdoc/>
    public Category FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Category.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InConverter))]
public enum In
{
    /// <summary>
    /// Account Transfer Instruction: details will be under the `account_transfer_instruction` object.
    /// </summary>
    AccountTransferInstruction,

    /// <summary>
    /// ACH Transfer Instruction: details will be under the `ach_transfer_instruction` object.
    /// </summary>
    AchTransferInstruction,

    /// <summary>
    /// Card Authorization: details will be under the `card_authorization` object.
    /// </summary>
    CardAuthorization,

    /// <summary>
    /// Check Deposit Instruction: details will be under the `check_deposit_instruction` object.
    /// </summary>
    CheckDepositInstruction,

    /// <summary>
    /// Check Transfer Instruction: details will be under the `check_transfer_instruction` object.
    /// </summary>
    CheckTransferInstruction,

    /// <summary>
    /// FedNow Transfer Instruction: details will be under the `fednow_transfer_instruction` object.
    /// </summary>
    FednowTransferInstruction,

    /// <summary>
    /// Inbound Funds Hold: details will be under the `inbound_funds_hold` object.
    /// </summary>
    InboundFundsHold,

    /// <summary>
    /// User Initiated Hold: details will be under the `user_initiated_hold` object.
    /// </summary>
    UserInitiatedHold,

    /// <summary>
    /// Real-Time Payments Transfer Instruction: details will be under the `real_time_payments_transfer_instruction` object.
    /// </summary>
    RealTimePaymentsTransferInstruction,

    /// <summary>
    /// Wire Transfer Instruction: details will be under the `wire_transfer_instruction` object.
    /// </summary>
    WireTransferInstruction,

    /// <summary>
    /// Inbound Wire Transfer Reversal: details will be under the `inbound_wire_transfer_reversal` object.
    /// </summary>
    InboundWireTransferReversal,

    /// <summary>
    /// Swift Transfer Instruction: details will be under the `swift_transfer_instruction` object.
    /// </summary>
    SwiftTransferInstruction,

    /// <summary>
    /// Card Push Transfer Instruction: details will be under the `card_push_transfer_instruction` object.
    /// </summary>
    CardPushTransferInstruction,

    /// <summary>
    /// Blockchain On-Ramp Transfer Instruction: details will be under the `blockchain_onramp_transfer_instruction` object.
    /// </summary>
    BlockchainOnrampTransferInstruction,

    /// <summary>
    /// Blockchain Off-Ramp Transfer Instruction: details will be under the `blockchain_offramp_transfer_instruction` object.
    /// </summary>
    BlockchainOfframpTransferInstruction,

    /// <summary>
    /// The Pending Transaction was made for an undocumented or deprecated reason.
    /// </summary>
    Other,
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
            "account_transfer_instruction" => In.AccountTransferInstruction,
            "ach_transfer_instruction" => In.AchTransferInstruction,
            "card_authorization" => In.CardAuthorization,
            "check_deposit_instruction" => In.CheckDepositInstruction,
            "check_transfer_instruction" => In.CheckTransferInstruction,
            "fednow_transfer_instruction" => In.FednowTransferInstruction,
            "inbound_funds_hold" => In.InboundFundsHold,
            "user_initiated_hold" => In.UserInitiatedHold,
            "real_time_payments_transfer_instruction" => In.RealTimePaymentsTransferInstruction,
            "wire_transfer_instruction" => In.WireTransferInstruction,
            "inbound_wire_transfer_reversal" => In.InboundWireTransferReversal,
            "swift_transfer_instruction" => In.SwiftTransferInstruction,
            "card_push_transfer_instruction" => In.CardPushTransferInstruction,
            "blockchain_onramp_transfer_instruction" => In.BlockchainOnrampTransferInstruction,
            "blockchain_offramp_transfer_instruction" => In.BlockchainOfframpTransferInstruction,
            "other" => In.Other,
            _ => (In)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, In value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                In.AccountTransferInstruction => "account_transfer_instruction",
                In.AchTransferInstruction => "ach_transfer_instruction",
                In.CardAuthorization => "card_authorization",
                In.CheckDepositInstruction => "check_deposit_instruction",
                In.CheckTransferInstruction => "check_transfer_instruction",
                In.FednowTransferInstruction => "fednow_transfer_instruction",
                In.InboundFundsHold => "inbound_funds_hold",
                In.UserInitiatedHold => "user_initiated_hold",
                In.RealTimePaymentsTransferInstruction => "real_time_payments_transfer_instruction",
                In.WireTransferInstruction => "wire_transfer_instruction",
                In.InboundWireTransferReversal => "inbound_wire_transfer_reversal",
                In.SwiftTransferInstruction => "swift_transfer_instruction",
                In.CardPushTransferInstruction => "card_push_transfer_instruction",
                In.BlockchainOnrampTransferInstruction => "blockchain_onramp_transfer_instruction",
                In.BlockchainOfframpTransferInstruction =>
                    "blockchain_offramp_transfer_instruction",
                In.Other => "other",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
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

[JsonConverter(typeof(JsonModelConverter<Status, StatusFromRaw>))]
public sealed record class Status : JsonModel
{
    /// <summary>
    /// Filter Pending Transactions for those with the specified status. By default
    /// only Pending Transactions in with status `pending` will be returned. For
    /// GET requests, this should be encoded as a comma-delimited string, such as `?in=one,two,three`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, StatusIn>>? In
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, StatusIn>>>("in");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, StatusIn>>?>(
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

    public Status() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Status(Status status)
        : base(status) { }
#pragma warning restore CS8618

    public Status(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Status(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatusFromRaw.FromRawUnchecked"/>
    public static Status FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatusFromRaw : IFromRawJson<Status>
{
    /// <inheritdoc/>
    public Status FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Status.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusInConverter))]
public enum StatusIn
{
    /// <summary>
    /// The Pending Transaction is still awaiting confirmation.
    /// </summary>
    Pending,

    /// <summary>
    /// The Pending Transaction is confirmed. An associated Transaction exists for
    /// this object. The Pending Transaction will no longer count against your balance
    /// and can generally be hidden from UIs, etc.
    /// </summary>
    Complete,
}

sealed class StatusInConverter : JsonConverter<StatusIn>
{
    public override StatusIn Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => StatusIn.Pending,
            "complete" => StatusIn.Complete,
            _ => (StatusIn)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, StatusIn value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusIn.Pending => "pending",
                StatusIn.Complete => "complete",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
