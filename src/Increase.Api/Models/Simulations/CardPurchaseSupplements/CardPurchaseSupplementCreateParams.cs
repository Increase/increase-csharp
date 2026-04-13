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

namespace Increase.Api.Models.Simulations.CardPurchaseSupplements;

/// <summary>
/// Simulates the creation of a Card Purchase Supplement (Level 3 data) for a card
/// settlement. This happens asynchronously in production when Visa sends enhanced
/// transaction data about a purchase.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CardPurchaseSupplementCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The identifier of the Transaction to create a Card Purchase Supplement for.
    /// The Transaction must have a source of type `card_settlement`.
    /// </summary>
    public required string TransactionID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("transaction_id");
        }
        init { this._rawBodyData.Set("transaction_id", value); }
    }

    /// <summary>
    /// Invoice-level information about the payment.
    /// </summary>
    public Invoice? Invoice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Invoice>("invoice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("invoice", value);
        }
    }

    /// <summary>
    /// Line item information, such as individual products purchased.
    /// </summary>
    public IReadOnlyList<LineItem>? LineItems
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<LineItem>>("line_items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<LineItem>?>(
                "line_items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public CardPurchaseSupplementCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CardPurchaseSupplementCreateParams(
        CardPurchaseSupplementCreateParams cardPurchaseSupplementCreateParams
    )
        : base(cardPurchaseSupplementCreateParams)
    {
        this._rawBodyData = new(cardPurchaseSupplementCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CardPurchaseSupplementCreateParams(
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
    CardPurchaseSupplementCreateParams(
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
    public static CardPurchaseSupplementCreateParams FromRawUnchecked(
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

    public virtual bool Equals(CardPurchaseSupplementCreateParams? other)
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
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/simulations/card_purchase_supplements"
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
/// Invoice-level information about the payment.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Invoice, InvoiceFromRaw>))]
public sealed record class Invoice : JsonModel
{
    /// <summary>
    /// Discount given to cardholder.
    /// </summary>
    public long? DiscountAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("discount_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discount_amount", value);
        }
    }

    /// <summary>
    /// Amount of duty taxes.
    /// </summary>
    public long? DutyTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duty_tax_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duty_tax_amount", value);
        }
    }

    /// <summary>
    /// Date the order was taken.
    /// </summary>
    public string? OrderDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("order_date");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("order_date", value);
        }
    }

    /// <summary>
    /// The shipping cost.
    /// </summary>
    public long? ShippingAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("shipping_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipping_amount", value);
        }
    }

    /// <summary>
    /// Country code of the shipping destination.
    /// </summary>
    public string? ShippingDestinationCountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_destination_country_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipping_destination_country_code", value);
        }
    }

    /// <summary>
    /// Postal code of the shipping destination.
    /// </summary>
    public string? ShippingDestinationPostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_destination_postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipping_destination_postal_code", value);
        }
    }

    /// <summary>
    /// Postal code of the location being shipped from.
    /// </summary>
    public string? ShippingSourcePostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_source_postal_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipping_source_postal_code", value);
        }
    }

    /// <summary>
    /// Taxes paid for freight and shipping.
    /// </summary>
    public long? ShippingTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("shipping_tax_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipping_tax_amount", value);
        }
    }

    /// <summary>
    /// Tax rate for freight and shipping.
    /// </summary>
    public string? ShippingTaxRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("shipping_tax_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shipping_tax_rate", value);
        }
    }

    /// <summary>
    /// Value added tax invoice reference number.
    /// </summary>
    public string? UniqueValueAddedTaxInvoiceReference
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unique_value_added_tax_invoice_reference"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unique_value_added_tax_invoice_reference", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DiscountAmount;
        _ = this.DutyTaxAmount;
        _ = this.OrderDate;
        _ = this.ShippingAmount;
        _ = this.ShippingDestinationCountryCode;
        _ = this.ShippingDestinationPostalCode;
        _ = this.ShippingSourcePostalCode;
        _ = this.ShippingTaxAmount;
        _ = this.ShippingTaxRate;
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

[JsonConverter(typeof(JsonModelConverter<LineItem, LineItemFromRaw>))]
public sealed record class LineItem : JsonModel
{
    /// <summary>
    /// Discount amount for this specific line item.
    /// </summary>
    public long? DiscountAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("discount_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("discount_amount", value);
        }
    }

    /// <summary>
    /// Code used to categorize the purchase item.
    /// </summary>
    public string? ItemCommodityCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("item_commodity_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("item_commodity_code", value);
        }
    }

    /// <summary>
    /// Description of the purchase item.
    /// </summary>
    public string? ItemDescriptor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("item_descriptor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("item_descriptor", value);
        }
    }

    /// <summary>
    /// The number of units of the product being purchased.
    /// </summary>
    public string? ItemQuantity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("item_quantity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("item_quantity", value);
        }
    }

    /// <summary>
    /// Code used to categorize the product being purchased.
    /// </summary>
    public string? ProductCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("product_code", value);
        }
    }

    /// <summary>
    /// Sales tax amount for this line item.
    /// </summary>
    public long? SalesTaxAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sales_tax_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sales_tax_amount", value);
        }
    }

    /// <summary>
    /// Sales tax rate for this line item.
    /// </summary>
    public string? SalesTaxRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sales_tax_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sales_tax_rate", value);
        }
    }

    /// <summary>
    /// Total amount of all line items.
    /// </summary>
    public long? TotalAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_amount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total_amount", value);
        }
    }

    /// <summary>
    /// Cost of line item per unit of measure, in major units.
    /// </summary>
    public string? UnitCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unit_cost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unit_cost", value);
        }
    }

    /// <summary>
    /// Code indicating unit of measure (gallons, etc.).
    /// </summary>
    public string? UnitOfMeasureCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("unit_of_measure_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unit_of_measure_code", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DiscountAmount;
        _ = this.ItemCommodityCode;
        _ = this.ItemDescriptor;
        _ = this.ItemQuantity;
        _ = this.ProductCode;
        _ = this.SalesTaxAmount;
        _ = this.SalesTaxRate;
        _ = this.TotalAmount;
        _ = this.UnitCost;
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
