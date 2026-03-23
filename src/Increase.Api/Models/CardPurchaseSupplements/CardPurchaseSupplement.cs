using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.CardPurchaseSupplements;

/// <summary>
/// Additional information about a card purchase (e.g., settlement or refund), such
/// as level 3 line item data.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CardPurchaseSupplement, CardPurchaseSupplementFromRaw>))]
public sealed record class CardPurchaseSupplement : JsonModel
{
    /// <summary>
    /// The Card Purchase Supplement identifier.
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
    /// The ID of the Card Payment this transaction belongs to.
    /// </summary>
    public required string? CardPaymentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("card_payment_id");
        }
        init { this._rawData.Set("card_payment_id", value); }
    }

    /// <summary>
    /// Invoice-level information about the payment.
    /// </summary>
    public required Invoice? Invoice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Invoice>("invoice");
        }
        init { this._rawData.Set("invoice", value); }
    }

    /// <summary>
    /// Line item information, such as individual products purchased.
    /// </summary>
    public required IReadOnlyList<LineItem>? LineItems
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<LineItem>>("line_items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<LineItem>?>(
                "line_items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The ID of the transaction.
    /// </summary>
    public required string TransactionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transaction_id");
        }
        init { this._rawData.Set("transaction_id", value); }
    }

    /// <summary>
    /// A constant representing the object's type. For this resource it will always
    /// be `card_purchase_supplement`.
    /// </summary>
    public required ApiEnum<string, global::Increase.Api.Models.CardPurchaseSupplements.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Increase.Api.Models.CardPurchaseSupplements.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CardPaymentID;
        this.Invoice?.Validate();
        foreach (var item in this.LineItems ?? [])
        {
            item.Validate();
        }
        _ = this.TransactionID;
        this.Type.Validate();
    }

    public CardPurchaseSupplement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPurchaseSupplement(CardPurchaseSupplement cardPurchaseSupplement)
        : base(cardPurchaseSupplement) { }
#pragma warning restore CS8618

    public CardPurchaseSupplement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CardPurchaseSupplement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CardPurchaseSupplementFromRaw.FromRawUnchecked"/>
    public static CardPurchaseSupplement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CardPurchaseSupplementFromRaw : IFromRawJson<CardPurchaseSupplement>
{
    /// <inheritdoc/>
    public CardPurchaseSupplement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CardPurchaseSupplement.FromRawUnchecked(rawData);
}

/// <summary>
/// Invoice-level information about the payment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Invoice, InvoiceFromRaw>))]
public sealed record class Invoice : JsonModel
{
    /// <summary>
    /// Discount given to cardholder.
    /// </summary>
    public required long? DiscountAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("discount_amount");
        }
        init { this._rawData.Set("discount_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the discount.
    /// </summary>
    public required string? DiscountCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discount_currency");
        }
        init { this._rawData.Set("discount_currency", value); }
    }

    /// <summary>
    /// Indicates how the merchant applied the discount.
    /// </summary>
    public required ApiEnum<string, DiscountTreatmentCode>? DiscountTreatmentCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DiscountTreatmentCode>>(
                "discount_treatment_code"
            );
        }
        init { this._rawData.Set("discount_treatment_code", value); }
    }

    /// <summary>
    /// Amount of duty taxes.
    /// </summary>
    public required long? DutyTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duty_tax_amount");
        }
        init { this._rawData.Set("duty_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the duty tax.
    /// </summary>
    public required string? DutyTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("duty_tax_currency");
        }
        init { this._rawData.Set("duty_tax_currency", value); }
    }

    /// <summary>
    /// Date the order was taken.
    /// </summary>
    public required string? OrderDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("order_date");
        }
        init { this._rawData.Set("order_date", value); }
    }

    /// <summary>
    /// The shipping cost.
    /// </summary>
    public required long? ShippingAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("shipping_amount");
        }
        init { this._rawData.Set("shipping_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the shipping cost.
    /// </summary>
    public required string? ShippingCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_currency");
        }
        init { this._rawData.Set("shipping_currency", value); }
    }

    /// <summary>
    /// Country code of the shipping destination.
    /// </summary>
    public required string? ShippingDestinationCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_destination_country_code");
        }
        init { this._rawData.Set("shipping_destination_country_code", value); }
    }

    /// <summary>
    /// Postal code of the shipping destination.
    /// </summary>
    public required string? ShippingDestinationPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_destination_postal_code");
        }
        init { this._rawData.Set("shipping_destination_postal_code", value); }
    }

    /// <summary>
    /// Postal code of the location being shipped from.
    /// </summary>
    public required string? ShippingSourcePostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_source_postal_code");
        }
        init { this._rawData.Set("shipping_source_postal_code", value); }
    }

    /// <summary>
    /// Taxes paid for freight and shipping.
    /// </summary>
    public required long? ShippingTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("shipping_tax_amount");
        }
        init { this._rawData.Set("shipping_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the shipping tax.
    /// </summary>
    public required string? ShippingTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_tax_currency");
        }
        init { this._rawData.Set("shipping_tax_currency", value); }
    }

    /// <summary>
    /// Tax rate for freight and shipping.
    /// </summary>
    public required string? ShippingTaxRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_tax_rate");
        }
        init { this._rawData.Set("shipping_tax_rate", value); }
    }

    /// <summary>
    /// Indicates how the merchant applied taxes.
    /// </summary>
    public required ApiEnum<string, TaxTreatments>? TaxTreatments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TaxTreatments>>("tax_treatments");
        }
        init { this._rawData.Set("tax_treatments", value); }
    }

    /// <summary>
    /// Value added tax invoice reference number.
    /// </summary>
    public required string? UniqueValueAddedTaxInvoiceReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unique_value_added_tax_invoice_reference"
            );
        }
        init { this._rawData.Set("unique_value_added_tax_invoice_reference", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DiscountAmount;
        _ = this.DiscountCurrency;
        this.DiscountTreatmentCode?.Validate();
        _ = this.DutyTaxAmount;
        _ = this.DutyTaxCurrency;
        _ = this.OrderDate;
        _ = this.ShippingAmount;
        _ = this.ShippingCurrency;
        _ = this.ShippingDestinationCountryCode;
        _ = this.ShippingDestinationPostalCode;
        _ = this.ShippingSourcePostalCode;
        _ = this.ShippingTaxAmount;
        _ = this.ShippingTaxCurrency;
        _ = this.ShippingTaxRate;
        this.TaxTreatments?.Validate();
        _ = this.UniqueValueAddedTaxInvoiceReference;
    }

    public Invoice() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Invoice(Invoice invoice)
        : base(invoice) { }
#pragma warning restore CS8618

    public Invoice(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Invoice(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceFromRaw.FromRawUnchecked"/>
    public static Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InvoiceFromRaw : IFromRawJson<Invoice>
{
    /// <inheritdoc/>
    public Invoice FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Invoice.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates how the merchant applied the discount.
/// </summary>
[JsonConverter(typeof(DiscountTreatmentCodeConverter))]
public enum DiscountTreatmentCode
{
    /// <summary>
    /// No invoice level discount provided
    /// </summary>
    NoInvoiceLevelDiscountProvided,

    /// <summary>
    /// Tax calculated on post discount invoice total
    /// </summary>
    TaxCalculatedOnPostDiscountInvoiceTotal,

    /// <summary>
    /// Tax calculated on pre discount invoice total
    /// </summary>
    TaxCalculatedOnPreDiscountInvoiceTotal,
}

sealed class DiscountTreatmentCodeConverter : JsonConverter<DiscountTreatmentCode>
{
    public override DiscountTreatmentCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_invoice_level_discount_provided" =>
                DiscountTreatmentCode.NoInvoiceLevelDiscountProvided,
            "tax_calculated_on_post_discount_invoice_total" =>
                DiscountTreatmentCode.TaxCalculatedOnPostDiscountInvoiceTotal,
            "tax_calculated_on_pre_discount_invoice_total" =>
                DiscountTreatmentCode.TaxCalculatedOnPreDiscountInvoiceTotal,
            _ => (DiscountTreatmentCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DiscountTreatmentCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DiscountTreatmentCode.NoInvoiceLevelDiscountProvided =>
                    "no_invoice_level_discount_provided",
                DiscountTreatmentCode.TaxCalculatedOnPostDiscountInvoiceTotal =>
                    "tax_calculated_on_post_discount_invoice_total",
                DiscountTreatmentCode.TaxCalculatedOnPreDiscountInvoiceTotal =>
                    "tax_calculated_on_pre_discount_invoice_total",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates how the merchant applied taxes.
/// </summary>
[JsonConverter(typeof(TaxTreatmentsConverter))]
public enum TaxTreatments
{
    /// <summary>
    /// No tax applies
    /// </summary>
    NoTaxApplies,

    /// <summary>
    /// Net price line item level
    /// </summary>
    NetPriceLineItemLevel,

    /// <summary>
    /// Net price invoice level
    /// </summary>
    NetPriceInvoiceLevel,

    /// <summary>
    /// Gross price line item level
    /// </summary>
    GrossPriceLineItemLevel,

    /// <summary>
    /// Gross price invoice level
    /// </summary>
    GrossPriceInvoiceLevel,
}

sealed class TaxTreatmentsConverter : JsonConverter<TaxTreatments>
{
    public override TaxTreatments Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_tax_applies" => TaxTreatments.NoTaxApplies,
            "net_price_line_item_level" => TaxTreatments.NetPriceLineItemLevel,
            "net_price_invoice_level" => TaxTreatments.NetPriceInvoiceLevel,
            "gross_price_line_item_level" => TaxTreatments.GrossPriceLineItemLevel,
            "gross_price_invoice_level" => TaxTreatments.GrossPriceInvoiceLevel,
            _ => (TaxTreatments)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TaxTreatments value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TaxTreatments.NoTaxApplies => "no_tax_applies",
                TaxTreatments.NetPriceLineItemLevel => "net_price_line_item_level",
                TaxTreatments.NetPriceInvoiceLevel => "net_price_invoice_level",
                TaxTreatments.GrossPriceLineItemLevel => "gross_price_line_item_level",
                TaxTreatments.GrossPriceInvoiceLevel => "gross_price_invoice_level",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<LineItem, LineItemFromRaw>))]
public sealed record class LineItem : JsonModel
{
    /// <summary>
    /// The Card Purchase Supplement Line Item identifier.
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
    /// Indicates the type of line item.
    /// </summary>
    public required ApiEnum<string, DetailIndicator>? DetailIndicator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DetailIndicator>>(
                "detail_indicator"
            );
        }
        init { this._rawData.Set("detail_indicator", value); }
    }

    /// <summary>
    /// Discount amount for this specific line item.
    /// </summary>
    public required long? DiscountAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("discount_amount");
        }
        init { this._rawData.Set("discount_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the discount.
    /// </summary>
    public required string? DiscountCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("discount_currency");
        }
        init { this._rawData.Set("discount_currency", value); }
    }

    /// <summary>
    /// Indicates how the merchant applied the discount for this specific line item.
    /// </summary>
    public required ApiEnum<string, LineItemDiscountTreatmentCode>? DiscountTreatmentCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LineItemDiscountTreatmentCode>>(
                "discount_treatment_code"
            );
        }
        init { this._rawData.Set("discount_treatment_code", value); }
    }

    /// <summary>
    /// Code used to categorize the purchase item.
    /// </summary>
    public required string? ItemCommodityCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("item_commodity_code");
        }
        init { this._rawData.Set("item_commodity_code", value); }
    }

    /// <summary>
    /// Description of the purchase item.
    /// </summary>
    public required string? ItemDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("item_descriptor");
        }
        init { this._rawData.Set("item_descriptor", value); }
    }

    /// <summary>
    /// The number of units of the product being purchased.
    /// </summary>
    public required string? ItemQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("item_quantity");
        }
        init { this._rawData.Set("item_quantity", value); }
    }

    /// <summary>
    /// Code used to categorize the product being purchased.
    /// </summary>
    public required string? ProductCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product_code");
        }
        init { this._rawData.Set("product_code", value); }
    }

    /// <summary>
    /// Sales tax amount for this line item.
    /// </summary>
    public required long? SalesTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sales_tax_amount");
        }
        init { this._rawData.Set("sales_tax_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the sales
    /// tax assessed.
    /// </summary>
    public required string? SalesTaxCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sales_tax_currency");
        }
        init { this._rawData.Set("sales_tax_currency", value); }
    }

    /// <summary>
    /// Sales tax rate for this line item.
    /// </summary>
    public required string? SalesTaxRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sales_tax_rate");
        }
        init { this._rawData.Set("sales_tax_rate", value); }
    }

    /// <summary>
    /// Total amount of all line items.
    /// </summary>
    public required long? TotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_amount");
        }
        init { this._rawData.Set("total_amount", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the total amount.
    /// </summary>
    public required string? TotalAmountCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("total_amount_currency");
        }
        init { this._rawData.Set("total_amount_currency", value); }
    }

    /// <summary>
    /// Cost of line item per unit of measure, in major units.
    /// </summary>
    public required string? UnitCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unit_cost");
        }
        init { this._rawData.Set("unit_cost", value); }
    }

    /// <summary>
    /// The [ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) code for the unit cost.
    /// </summary>
    public required string? UnitCostCurrency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unit_cost_currency");
        }
        init { this._rawData.Set("unit_cost_currency", value); }
    }

    /// <summary>
    /// Code indicating unit of measure (gallons, etc.).
    /// </summary>
    public required string? UnitOfMeasureCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unit_of_measure_code");
        }
        init { this._rawData.Set("unit_of_measure_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.DetailIndicator?.Validate();
        _ = this.DiscountAmount;
        _ = this.DiscountCurrency;
        this.DiscountTreatmentCode?.Validate();
        _ = this.ItemCommodityCode;
        _ = this.ItemDescriptor;
        _ = this.ItemQuantity;
        _ = this.ProductCode;
        _ = this.SalesTaxAmount;
        _ = this.SalesTaxCurrency;
        _ = this.SalesTaxRate;
        _ = this.TotalAmount;
        _ = this.TotalAmountCurrency;
        _ = this.UnitCost;
        _ = this.UnitCostCurrency;
        _ = this.UnitOfMeasureCode;
    }

    public LineItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LineItem(LineItem lineItem)
        : base(lineItem) { }
#pragma warning restore CS8618

    public LineItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LineItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LineItemFromRaw.FromRawUnchecked"/>
    public static LineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LineItemFromRaw : IFromRawJson<LineItem>
{
    /// <inheritdoc/>
    public LineItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LineItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates the type of line item.
/// </summary>
[JsonConverter(typeof(DetailIndicatorConverter))]
public enum DetailIndicator
{
    /// <summary>
    /// Normal
    /// </summary>
    Normal,

    /// <summary>
    /// Credit
    /// </summary>
    Credit,

    /// <summary>
    /// Purchase
    /// </summary>
    Payment,
}

sealed class DetailIndicatorConverter : JsonConverter<DetailIndicator>
{
    public override DetailIndicator Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "normal" => DetailIndicator.Normal,
            "credit" => DetailIndicator.Credit,
            "payment" => DetailIndicator.Payment,
            _ => (DetailIndicator)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DetailIndicator value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DetailIndicator.Normal => "normal",
                DetailIndicator.Credit => "credit",
                DetailIndicator.Payment => "payment",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Indicates how the merchant applied the discount for this specific line item.
/// </summary>
[JsonConverter(typeof(LineItemDiscountTreatmentCodeConverter))]
public enum LineItemDiscountTreatmentCode
{
    /// <summary>
    /// No line item level discount provided
    /// </summary>
    NoLineItemLevelDiscountProvided,

    /// <summary>
    /// Tax calculated on post discount line item total
    /// </summary>
    TaxCalculatedOnPostDiscountLineItemTotal,

    /// <summary>
    /// Tax calculated on pre discount line item total
    /// </summary>
    TaxCalculatedOnPreDiscountLineItemTotal,
}

sealed class LineItemDiscountTreatmentCodeConverter : JsonConverter<LineItemDiscountTreatmentCode>
{
    public override LineItemDiscountTreatmentCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "no_line_item_level_discount_provided" =>
                LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided,
            "tax_calculated_on_post_discount_line_item_total" =>
                LineItemDiscountTreatmentCode.TaxCalculatedOnPostDiscountLineItemTotal,
            "tax_calculated_on_pre_discount_line_item_total" =>
                LineItemDiscountTreatmentCode.TaxCalculatedOnPreDiscountLineItemTotal,
            _ => (LineItemDiscountTreatmentCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LineItemDiscountTreatmentCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided =>
                    "no_line_item_level_discount_provided",
                LineItemDiscountTreatmentCode.TaxCalculatedOnPostDiscountLineItemTotal =>
                    "tax_calculated_on_post_discount_line_item_total",
                LineItemDiscountTreatmentCode.TaxCalculatedOnPreDiscountLineItemTotal =>
                    "tax_calculated_on_pre_discount_line_item_total",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A constant representing the object's type. For this resource it will always be `card_purchase_supplement`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CardPurchaseSupplement,
}

sealed class TypeConverter : JsonConverter<global::Increase.Api.Models.CardPurchaseSupplements.Type>
{
    public override global::Increase.Api.Models.CardPurchaseSupplements.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_purchase_supplement" => global::Increase
                .Api
                .Models
                .CardPurchaseSupplements
                .Type
                .CardPurchaseSupplement,
            _ => (global::Increase.Api.Models.CardPurchaseSupplements.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Increase.Api.Models.CardPurchaseSupplements.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Increase.Api.Models.CardPurchaseSupplements.Type.CardPurchaseSupplement =>
                    "card_purchase_supplement",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
