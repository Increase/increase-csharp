using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Programs;

/// <summary>
/// Programs determine the compliance and commercial terms of Accounts. By default,
/// you have a Commercial Banking program for managing your own funds. If you are
/// lending or managing funds on behalf of your customers, or otherwise engaged in
/// regulated activity, we will work together to create additional Programs for you.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Program, ProgramFromRaw>))]
public sealed record class Program : JsonModel
{
    /// <summary>
    /// The Program identifier.
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
    /// The Bank the Program is with.
    /// </summary>
    public required ApiEnum<string, Bank> Bank
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Bank>>("bank");
        }
        init { this._rawData.Set("bank", value); }
    }

    /// <summary>
    /// The Program billing account.
    /// </summary>
    public required string? BillingAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("billing_account_id");
        }
        init { this._rawData.Set("billing_account_id", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Program
    /// was created.
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
    /// The default configuration for digital cards attached to this Program.
    /// </summary>
    public required string? DefaultDigitalCardProfileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("default_digital_card_profile_id");
        }
        init { this._rawData.Set("default_digital_card_profile_id", value); }
    }

    /// <summary>
    /// The Interest Rate currently being earned on the accounts in this program,
    /// as a string containing a decimal number. For example, a 1% interest rate would
    /// be represented as "0.01".
    /// </summary>
    public required string InterestRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("interest_rate");
        }
        init { this._rawData.Set("interest_rate", value); }
    }

    /// <summary>
    /// The lending details for the program.
    /// </summary>
    public required Lending? Lending
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Lending>("lending");
        }
        init { this._rawData.Set("lending", value); }
    }

    /// <summary>
    /// The name of the Program.
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
    /// A constant representing the object's type. For this resource it will always
    /// be `program`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.Programs.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.Programs.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) time at which the Program
    /// was last updated.
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Bank.Validate();
        _ = this.BillingAccountID;
        _ = this.CreatedAt;
        _ = this.DefaultDigitalCardProfileID;
        _ = this.InterestRate;
        this.Lending?.Validate();
        _ = this.Name;
        this.Type.Validate();
        _ = this.UpdatedAt;
    }

    public Program() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Program(Program program)
        : base(program) { }
#pragma warning restore CS8618

    public Program(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Program(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProgramFromRaw.FromRawUnchecked"/>
    public static Program FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProgramFromRaw : IFromRawJson<Program>
{
    /// <inheritdoc/>
    public Program FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Program.FromRawUnchecked(rawData);
}

/// <summary>
/// The Bank the Program is with.
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
}

sealed class BankConverter : JsonConverter<Bank>
{
    public override Bank Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "core_bank" => Bank.CoreBank,
            "first_internet_bank" => Bank.FirstInternetBank,
            "grasshopper_bank" => Bank.GrasshopperBank,
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
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The lending details for the program.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Lending, LendingFromRaw>))]
public sealed record class Lending : JsonModel
{
    /// <summary>
    /// The maximum extendable credit of the program.
    /// </summary>
    public required long MaximumExtendableCredit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("maximum_extendable_credit");
        }
        init { this._rawData.Set("maximum_extendable_credit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MaximumExtendableCredit;
    }

    public Lending() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Lending(Lending lending)
        : base(lending) { }
#pragma warning restore CS8618

    public Lending(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Lending(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LendingFromRaw.FromRawUnchecked"/>
    public static Lending FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Lending(long maximumExtendableCredit)
        : this()
    {
        this.MaximumExtendableCredit = maximumExtendableCredit;
    }
}

class LendingFromRaw : IFromRawJson<Lending>
{
    /// <inheritdoc/>
    public Lending FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Lending.FromRawUnchecked(rawData);
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `program`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Program,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.Programs.Type>
{
    public override global::Increase.Api.Models.Programs.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "program" => global::Increase.Api.Models.Programs.Type.Program,
            _ => (global::Increase.Api.Models.Programs.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.Programs.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.Programs.Type.Program => "program",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
