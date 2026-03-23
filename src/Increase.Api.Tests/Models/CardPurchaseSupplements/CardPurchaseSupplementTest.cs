using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardPurchaseSupplements;

namespace Increase.Api.Tests.Models.CardPurchaseSupplements;

public class CardPurchaseSupplementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPurchaseSupplement
        {
            ID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Invoice = new()
            {
                DiscountAmount = 100,
                DiscountCurrency = "USD",
                DiscountTreatmentCode = null,
                DutyTaxAmount = 200,
                DutyTaxCurrency = "USD",
                OrderDate = "2023-07-20",
                ShippingAmount = 300,
                ShippingCurrency = "USD",
                ShippingDestinationCountryCode = "US",
                ShippingDestinationPostalCode = "10045",
                ShippingSourcePostalCode = "10045",
                ShippingTaxAmount = 400,
                ShippingTaxCurrency = "USD",
                ShippingTaxRate = "0.2",
                TaxTreatments = null,
                UniqueValueAddedTaxInvoiceReference = "12302",
            },
            LineItems =
            [
                new()
                {
                    ID = "card_purchase_supplement_invoice_line_item_nf9760lz0apqy5retmqh",
                    DetailIndicator = DetailIndicator.Normal,
                    DiscountAmount = null,
                    DiscountCurrency = null,
                    DiscountTreatmentCode = null,
                    ItemCommodityCode = "001",
                    ItemDescriptor = "Coffee",
                    ItemQuantity = "1.0",
                    ProductCode = "101",
                    SalesTaxAmount = null,
                    SalesTaxCurrency = null,
                    SalesTaxRate = null,
                    TotalAmount = 500,
                    TotalAmountCurrency = "USD",
                    UnitCost = "5.0",
                    UnitCostCurrency = "USD",
                    UnitOfMeasureCode = "NMB",
                },
            ],
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = Type.CardPurchaseSupplement,
        };

        string expectedID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3";
        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        Invoice expectedInvoice = new()
        {
            DiscountAmount = 100,
            DiscountCurrency = "USD",
            DiscountTreatmentCode = null,
            DutyTaxAmount = 200,
            DutyTaxCurrency = "USD",
            OrderDate = "2023-07-20",
            ShippingAmount = 300,
            ShippingCurrency = "USD",
            ShippingDestinationCountryCode = "US",
            ShippingDestinationPostalCode = "10045",
            ShippingSourcePostalCode = "10045",
            ShippingTaxAmount = 400,
            ShippingTaxCurrency = "USD",
            ShippingTaxRate = "0.2",
            TaxTreatments = null,
            UniqueValueAddedTaxInvoiceReference = "12302",
        };
        List<LineItem> expectedLineItems =
        [
            new()
            {
                ID = "card_purchase_supplement_invoice_line_item_nf9760lz0apqy5retmqh",
                DetailIndicator = DetailIndicator.Normal,
                DiscountAmount = null,
                DiscountCurrency = null,
                DiscountTreatmentCode = null,
                ItemCommodityCode = "001",
                ItemDescriptor = "Coffee",
                ItemQuantity = "1.0",
                ProductCode = "101",
                SalesTaxAmount = null,
                SalesTaxCurrency = null,
                SalesTaxRate = null,
                TotalAmount = 500,
                TotalAmountCurrency = "USD",
                UnitCost = "5.0",
                UnitCostCurrency = "USD",
                UnitOfMeasureCode = "NMB",
            },
        ];
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, Type> expectedType = Type.CardPurchaseSupplement;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCardPaymentID, model.CardPaymentID);
        Assert.Equal(expectedInvoice, model.Invoice);
        Assert.NotNull(model.LineItems);
        Assert.Equal(expectedLineItems.Count, model.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], model.LineItems[i]);
        }
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPurchaseSupplement
        {
            ID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Invoice = new()
            {
                DiscountAmount = 100,
                DiscountCurrency = "USD",
                DiscountTreatmentCode = null,
                DutyTaxAmount = 200,
                DutyTaxCurrency = "USD",
                OrderDate = "2023-07-20",
                ShippingAmount = 300,
                ShippingCurrency = "USD",
                ShippingDestinationCountryCode = "US",
                ShippingDestinationPostalCode = "10045",
                ShippingSourcePostalCode = "10045",
                ShippingTaxAmount = 400,
                ShippingTaxCurrency = "USD",
                ShippingTaxRate = "0.2",
                TaxTreatments = null,
                UniqueValueAddedTaxInvoiceReference = "12302",
            },
            LineItems =
            [
                new()
                {
                    ID = "card_purchase_supplement_invoice_line_item_nf9760lz0apqy5retmqh",
                    DetailIndicator = DetailIndicator.Normal,
                    DiscountAmount = null,
                    DiscountCurrency = null,
                    DiscountTreatmentCode = null,
                    ItemCommodityCode = "001",
                    ItemDescriptor = "Coffee",
                    ItemQuantity = "1.0",
                    ProductCode = "101",
                    SalesTaxAmount = null,
                    SalesTaxCurrency = null,
                    SalesTaxRate = null,
                    TotalAmount = 500,
                    TotalAmountCurrency = "USD",
                    UnitCost = "5.0",
                    UnitCostCurrency = "USD",
                    UnitOfMeasureCode = "NMB",
                },
            ],
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = Type.CardPurchaseSupplement,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPurchaseSupplement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPurchaseSupplement
        {
            ID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Invoice = new()
            {
                DiscountAmount = 100,
                DiscountCurrency = "USD",
                DiscountTreatmentCode = null,
                DutyTaxAmount = 200,
                DutyTaxCurrency = "USD",
                OrderDate = "2023-07-20",
                ShippingAmount = 300,
                ShippingCurrency = "USD",
                ShippingDestinationCountryCode = "US",
                ShippingDestinationPostalCode = "10045",
                ShippingSourcePostalCode = "10045",
                ShippingTaxAmount = 400,
                ShippingTaxCurrency = "USD",
                ShippingTaxRate = "0.2",
                TaxTreatments = null,
                UniqueValueAddedTaxInvoiceReference = "12302",
            },
            LineItems =
            [
                new()
                {
                    ID = "card_purchase_supplement_invoice_line_item_nf9760lz0apqy5retmqh",
                    DetailIndicator = DetailIndicator.Normal,
                    DiscountAmount = null,
                    DiscountCurrency = null,
                    DiscountTreatmentCode = null,
                    ItemCommodityCode = "001",
                    ItemDescriptor = "Coffee",
                    ItemQuantity = "1.0",
                    ProductCode = "101",
                    SalesTaxAmount = null,
                    SalesTaxCurrency = null,
                    SalesTaxRate = null,
                    TotalAmount = 500,
                    TotalAmountCurrency = "USD",
                    UnitCost = "5.0",
                    UnitCostCurrency = "USD",
                    UnitOfMeasureCode = "NMB",
                },
            ],
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = Type.CardPurchaseSupplement,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPurchaseSupplement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3";
        string expectedCardPaymentID = "card_payment_nd3k2kacrqjli8482ave";
        Invoice expectedInvoice = new()
        {
            DiscountAmount = 100,
            DiscountCurrency = "USD",
            DiscountTreatmentCode = null,
            DutyTaxAmount = 200,
            DutyTaxCurrency = "USD",
            OrderDate = "2023-07-20",
            ShippingAmount = 300,
            ShippingCurrency = "USD",
            ShippingDestinationCountryCode = "US",
            ShippingDestinationPostalCode = "10045",
            ShippingSourcePostalCode = "10045",
            ShippingTaxAmount = 400,
            ShippingTaxCurrency = "USD",
            ShippingTaxRate = "0.2",
            TaxTreatments = null,
            UniqueValueAddedTaxInvoiceReference = "12302",
        };
        List<LineItem> expectedLineItems =
        [
            new()
            {
                ID = "card_purchase_supplement_invoice_line_item_nf9760lz0apqy5retmqh",
                DetailIndicator = DetailIndicator.Normal,
                DiscountAmount = null,
                DiscountCurrency = null,
                DiscountTreatmentCode = null,
                ItemCommodityCode = "001",
                ItemDescriptor = "Coffee",
                ItemQuantity = "1.0",
                ProductCode = "101",
                SalesTaxAmount = null,
                SalesTaxCurrency = null,
                SalesTaxRate = null,
                TotalAmount = 500,
                TotalAmountCurrency = "USD",
                UnitCost = "5.0",
                UnitCostCurrency = "USD",
                UnitOfMeasureCode = "NMB",
            },
        ];
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, Type> expectedType = Type.CardPurchaseSupplement;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCardPaymentID, deserialized.CardPaymentID);
        Assert.Equal(expectedInvoice, deserialized.Invoice);
        Assert.NotNull(deserialized.LineItems);
        Assert.Equal(expectedLineItems.Count, deserialized.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], deserialized.LineItems[i]);
        }
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardPurchaseSupplement
        {
            ID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Invoice = new()
            {
                DiscountAmount = 100,
                DiscountCurrency = "USD",
                DiscountTreatmentCode = null,
                DutyTaxAmount = 200,
                DutyTaxCurrency = "USD",
                OrderDate = "2023-07-20",
                ShippingAmount = 300,
                ShippingCurrency = "USD",
                ShippingDestinationCountryCode = "US",
                ShippingDestinationPostalCode = "10045",
                ShippingSourcePostalCode = "10045",
                ShippingTaxAmount = 400,
                ShippingTaxCurrency = "USD",
                ShippingTaxRate = "0.2",
                TaxTreatments = null,
                UniqueValueAddedTaxInvoiceReference = "12302",
            },
            LineItems =
            [
                new()
                {
                    ID = "card_purchase_supplement_invoice_line_item_nf9760lz0apqy5retmqh",
                    DetailIndicator = DetailIndicator.Normal,
                    DiscountAmount = null,
                    DiscountCurrency = null,
                    DiscountTreatmentCode = null,
                    ItemCommodityCode = "001",
                    ItemDescriptor = "Coffee",
                    ItemQuantity = "1.0",
                    ProductCode = "101",
                    SalesTaxAmount = null,
                    SalesTaxCurrency = null,
                    SalesTaxRate = null,
                    TotalAmount = 500,
                    TotalAmountCurrency = "USD",
                    UnitCost = "5.0",
                    UnitCostCurrency = "USD",
                    UnitOfMeasureCode = "NMB",
                },
            ],
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = Type.CardPurchaseSupplement,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPurchaseSupplement
        {
            ID = "card_purchase_supplement_ijuc45iym4jchnh2sfk3",
            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Invoice = new()
            {
                DiscountAmount = 100,
                DiscountCurrency = "USD",
                DiscountTreatmentCode = null,
                DutyTaxAmount = 200,
                DutyTaxCurrency = "USD",
                OrderDate = "2023-07-20",
                ShippingAmount = 300,
                ShippingCurrency = "USD",
                ShippingDestinationCountryCode = "US",
                ShippingDestinationPostalCode = "10045",
                ShippingSourcePostalCode = "10045",
                ShippingTaxAmount = 400,
                ShippingTaxCurrency = "USD",
                ShippingTaxRate = "0.2",
                TaxTreatments = null,
                UniqueValueAddedTaxInvoiceReference = "12302",
            },
            LineItems =
            [
                new()
                {
                    ID = "card_purchase_supplement_invoice_line_item_nf9760lz0apqy5retmqh",
                    DetailIndicator = DetailIndicator.Normal,
                    DiscountAmount = null,
                    DiscountCurrency = null,
                    DiscountTreatmentCode = null,
                    ItemCommodityCode = "001",
                    ItemDescriptor = "Coffee",
                    ItemQuantity = "1.0",
                    ProductCode = "101",
                    SalesTaxAmount = null,
                    SalesTaxCurrency = null,
                    SalesTaxRate = null,
                    TotalAmount = 500,
                    TotalAmountCurrency = "USD",
                    UnitCost = "5.0",
                    UnitCostCurrency = "USD",
                    UnitOfMeasureCode = "NMB",
                },
            ],
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = Type.CardPurchaseSupplement,
        };

        CardPurchaseSupplement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoice
        {
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = DiscountTreatmentCode.NoInvoiceLevelDiscountProvided,
            DutyTaxAmount = 0,
            DutyTaxCurrency = "duty_tax_currency",
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingCurrency = "shipping_currency",
            ShippingDestinationCountryCode = "shipping_destination_country_code",
            ShippingDestinationPostalCode = "shipping_destination_postal_code",
            ShippingSourcePostalCode = "shipping_source_postal_code",
            ShippingTaxAmount = 0,
            ShippingTaxCurrency = "shipping_tax_currency",
            ShippingTaxRate = "-16699",
            TaxTreatments = TaxTreatments.NoTaxApplies,
            UniqueValueAddedTaxInvoiceReference = "unique_value_added_tax_invoice_reference",
        };

        long expectedDiscountAmount = 0;
        string expectedDiscountCurrency = "discount_currency";
        ApiEnum<string, DiscountTreatmentCode> expectedDiscountTreatmentCode =
            DiscountTreatmentCode.NoInvoiceLevelDiscountProvided;
        long expectedDutyTaxAmount = 0;
        string expectedDutyTaxCurrency = "duty_tax_currency";
        string expectedOrderDate = "2019-12-27";
        long expectedShippingAmount = 0;
        string expectedShippingCurrency = "shipping_currency";
        string expectedShippingDestinationCountryCode = "shipping_destination_country_code";
        string expectedShippingDestinationPostalCode = "shipping_destination_postal_code";
        string expectedShippingSourcePostalCode = "shipping_source_postal_code";
        long expectedShippingTaxAmount = 0;
        string expectedShippingTaxCurrency = "shipping_tax_currency";
        string expectedShippingTaxRate = "-16699";
        ApiEnum<string, TaxTreatments> expectedTaxTreatments = TaxTreatments.NoTaxApplies;
        string expectedUniqueValueAddedTaxInvoiceReference =
            "unique_value_added_tax_invoice_reference";

        Assert.Equal(expectedDiscountAmount, model.DiscountAmount);
        Assert.Equal(expectedDiscountCurrency, model.DiscountCurrency);
        Assert.Equal(expectedDiscountTreatmentCode, model.DiscountTreatmentCode);
        Assert.Equal(expectedDutyTaxAmount, model.DutyTaxAmount);
        Assert.Equal(expectedDutyTaxCurrency, model.DutyTaxCurrency);
        Assert.Equal(expectedOrderDate, model.OrderDate);
        Assert.Equal(expectedShippingAmount, model.ShippingAmount);
        Assert.Equal(expectedShippingCurrency, model.ShippingCurrency);
        Assert.Equal(expectedShippingDestinationCountryCode, model.ShippingDestinationCountryCode);
        Assert.Equal(expectedShippingDestinationPostalCode, model.ShippingDestinationPostalCode);
        Assert.Equal(expectedShippingSourcePostalCode, model.ShippingSourcePostalCode);
        Assert.Equal(expectedShippingTaxAmount, model.ShippingTaxAmount);
        Assert.Equal(expectedShippingTaxCurrency, model.ShippingTaxCurrency);
        Assert.Equal(expectedShippingTaxRate, model.ShippingTaxRate);
        Assert.Equal(expectedTaxTreatments, model.TaxTreatments);
        Assert.Equal(
            expectedUniqueValueAddedTaxInvoiceReference,
            model.UniqueValueAddedTaxInvoiceReference
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoice
        {
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = DiscountTreatmentCode.NoInvoiceLevelDiscountProvided,
            DutyTaxAmount = 0,
            DutyTaxCurrency = "duty_tax_currency",
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingCurrency = "shipping_currency",
            ShippingDestinationCountryCode = "shipping_destination_country_code",
            ShippingDestinationPostalCode = "shipping_destination_postal_code",
            ShippingSourcePostalCode = "shipping_source_postal_code",
            ShippingTaxAmount = 0,
            ShippingTaxCurrency = "shipping_tax_currency",
            ShippingTaxRate = "-16699",
            TaxTreatments = TaxTreatments.NoTaxApplies,
            UniqueValueAddedTaxInvoiceReference = "unique_value_added_tax_invoice_reference",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoice
        {
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = DiscountTreatmentCode.NoInvoiceLevelDiscountProvided,
            DutyTaxAmount = 0,
            DutyTaxCurrency = "duty_tax_currency",
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingCurrency = "shipping_currency",
            ShippingDestinationCountryCode = "shipping_destination_country_code",
            ShippingDestinationPostalCode = "shipping_destination_postal_code",
            ShippingSourcePostalCode = "shipping_source_postal_code",
            ShippingTaxAmount = 0,
            ShippingTaxCurrency = "shipping_tax_currency",
            ShippingTaxRate = "-16699",
            TaxTreatments = TaxTreatments.NoTaxApplies,
            UniqueValueAddedTaxInvoiceReference = "unique_value_added_tax_invoice_reference",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDiscountAmount = 0;
        string expectedDiscountCurrency = "discount_currency";
        ApiEnum<string, DiscountTreatmentCode> expectedDiscountTreatmentCode =
            DiscountTreatmentCode.NoInvoiceLevelDiscountProvided;
        long expectedDutyTaxAmount = 0;
        string expectedDutyTaxCurrency = "duty_tax_currency";
        string expectedOrderDate = "2019-12-27";
        long expectedShippingAmount = 0;
        string expectedShippingCurrency = "shipping_currency";
        string expectedShippingDestinationCountryCode = "shipping_destination_country_code";
        string expectedShippingDestinationPostalCode = "shipping_destination_postal_code";
        string expectedShippingSourcePostalCode = "shipping_source_postal_code";
        long expectedShippingTaxAmount = 0;
        string expectedShippingTaxCurrency = "shipping_tax_currency";
        string expectedShippingTaxRate = "-16699";
        ApiEnum<string, TaxTreatments> expectedTaxTreatments = TaxTreatments.NoTaxApplies;
        string expectedUniqueValueAddedTaxInvoiceReference =
            "unique_value_added_tax_invoice_reference";

        Assert.Equal(expectedDiscountAmount, deserialized.DiscountAmount);
        Assert.Equal(expectedDiscountCurrency, deserialized.DiscountCurrency);
        Assert.Equal(expectedDiscountTreatmentCode, deserialized.DiscountTreatmentCode);
        Assert.Equal(expectedDutyTaxAmount, deserialized.DutyTaxAmount);
        Assert.Equal(expectedDutyTaxCurrency, deserialized.DutyTaxCurrency);
        Assert.Equal(expectedOrderDate, deserialized.OrderDate);
        Assert.Equal(expectedShippingAmount, deserialized.ShippingAmount);
        Assert.Equal(expectedShippingCurrency, deserialized.ShippingCurrency);
        Assert.Equal(
            expectedShippingDestinationCountryCode,
            deserialized.ShippingDestinationCountryCode
        );
        Assert.Equal(
            expectedShippingDestinationPostalCode,
            deserialized.ShippingDestinationPostalCode
        );
        Assert.Equal(expectedShippingSourcePostalCode, deserialized.ShippingSourcePostalCode);
        Assert.Equal(expectedShippingTaxAmount, deserialized.ShippingTaxAmount);
        Assert.Equal(expectedShippingTaxCurrency, deserialized.ShippingTaxCurrency);
        Assert.Equal(expectedShippingTaxRate, deserialized.ShippingTaxRate);
        Assert.Equal(expectedTaxTreatments, deserialized.TaxTreatments);
        Assert.Equal(
            expectedUniqueValueAddedTaxInvoiceReference,
            deserialized.UniqueValueAddedTaxInvoiceReference
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoice
        {
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = DiscountTreatmentCode.NoInvoiceLevelDiscountProvided,
            DutyTaxAmount = 0,
            DutyTaxCurrency = "duty_tax_currency",
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingCurrency = "shipping_currency",
            ShippingDestinationCountryCode = "shipping_destination_country_code",
            ShippingDestinationPostalCode = "shipping_destination_postal_code",
            ShippingSourcePostalCode = "shipping_source_postal_code",
            ShippingTaxAmount = 0,
            ShippingTaxCurrency = "shipping_tax_currency",
            ShippingTaxRate = "-16699",
            TaxTreatments = TaxTreatments.NoTaxApplies,
            UniqueValueAddedTaxInvoiceReference = "unique_value_added_tax_invoice_reference",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice
        {
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = DiscountTreatmentCode.NoInvoiceLevelDiscountProvided,
            DutyTaxAmount = 0,
            DutyTaxCurrency = "duty_tax_currency",
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingCurrency = "shipping_currency",
            ShippingDestinationCountryCode = "shipping_destination_country_code",
            ShippingDestinationPostalCode = "shipping_destination_postal_code",
            ShippingSourcePostalCode = "shipping_source_postal_code",
            ShippingTaxAmount = 0,
            ShippingTaxCurrency = "shipping_tax_currency",
            ShippingTaxRate = "-16699",
            TaxTreatments = TaxTreatments.NoTaxApplies,
            UniqueValueAddedTaxInvoiceReference = "unique_value_added_tax_invoice_reference",
        };

        Invoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiscountTreatmentCodeTest : TestBase
{
    [Theory]
    [InlineData(DiscountTreatmentCode.NoInvoiceLevelDiscountProvided)]
    [InlineData(DiscountTreatmentCode.TaxCalculatedOnPostDiscountInvoiceTotal)]
    [InlineData(DiscountTreatmentCode.TaxCalculatedOnPreDiscountInvoiceTotal)]
    public void Validation_Works(DiscountTreatmentCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountTreatmentCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountTreatmentCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DiscountTreatmentCode.NoInvoiceLevelDiscountProvided)]
    [InlineData(DiscountTreatmentCode.TaxCalculatedOnPostDiscountInvoiceTotal)]
    [InlineData(DiscountTreatmentCode.TaxCalculatedOnPreDiscountInvoiceTotal)]
    public void SerializationRoundtrip_Works(DiscountTreatmentCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountTreatmentCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountTreatmentCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountTreatmentCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountTreatmentCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TaxTreatmentsTest : TestBase
{
    [Theory]
    [InlineData(TaxTreatments.NoTaxApplies)]
    [InlineData(TaxTreatments.NetPriceLineItemLevel)]
    [InlineData(TaxTreatments.NetPriceInvoiceLevel)]
    [InlineData(TaxTreatments.GrossPriceLineItemLevel)]
    [InlineData(TaxTreatments.GrossPriceInvoiceLevel)]
    public void Validation_Works(TaxTreatments rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxTreatments> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxTreatments>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TaxTreatments.NoTaxApplies)]
    [InlineData(TaxTreatments.NetPriceLineItemLevel)]
    [InlineData(TaxTreatments.NetPriceInvoiceLevel)]
    [InlineData(TaxTreatments.GrossPriceLineItemLevel)]
    [InlineData(TaxTreatments.GrossPriceInvoiceLevel)]
    public void SerializationRoundtrip_Works(TaxTreatments rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TaxTreatments> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxTreatments>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TaxTreatments>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TaxTreatments>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LineItem
        {
            ID = "id",
            DetailIndicator = DetailIndicator.Normal,
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided,
            ItemCommodityCode = "item_commodity_code",
            ItemDescriptor = "item_descriptor",
            ItemQuantity = "-16699",
            ProductCode = "product_code",
            SalesTaxAmount = 0,
            SalesTaxCurrency = "sales_tax_currency",
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            TotalAmountCurrency = "total_amount_currency",
            UnitCost = "-16699",
            UnitCostCurrency = "unit_cost_currency",
            UnitOfMeasureCode = "unit_of_measure_code",
        };

        string expectedID = "id";
        ApiEnum<string, DetailIndicator> expectedDetailIndicator = DetailIndicator.Normal;
        long expectedDiscountAmount = 0;
        string expectedDiscountCurrency = "discount_currency";
        ApiEnum<string, LineItemDiscountTreatmentCode> expectedDiscountTreatmentCode =
            LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided;
        string expectedItemCommodityCode = "item_commodity_code";
        string expectedItemDescriptor = "item_descriptor";
        string expectedItemQuantity = "-16699";
        string expectedProductCode = "product_code";
        long expectedSalesTaxAmount = 0;
        string expectedSalesTaxCurrency = "sales_tax_currency";
        string expectedSalesTaxRate = "-16699";
        long expectedTotalAmount = 0;
        string expectedTotalAmountCurrency = "total_amount_currency";
        string expectedUnitCost = "-16699";
        string expectedUnitCostCurrency = "unit_cost_currency";
        string expectedUnitOfMeasureCode = "unit_of_measure_code";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDetailIndicator, model.DetailIndicator);
        Assert.Equal(expectedDiscountAmount, model.DiscountAmount);
        Assert.Equal(expectedDiscountCurrency, model.DiscountCurrency);
        Assert.Equal(expectedDiscountTreatmentCode, model.DiscountTreatmentCode);
        Assert.Equal(expectedItemCommodityCode, model.ItemCommodityCode);
        Assert.Equal(expectedItemDescriptor, model.ItemDescriptor);
        Assert.Equal(expectedItemQuantity, model.ItemQuantity);
        Assert.Equal(expectedProductCode, model.ProductCode);
        Assert.Equal(expectedSalesTaxAmount, model.SalesTaxAmount);
        Assert.Equal(expectedSalesTaxCurrency, model.SalesTaxCurrency);
        Assert.Equal(expectedSalesTaxRate, model.SalesTaxRate);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedTotalAmountCurrency, model.TotalAmountCurrency);
        Assert.Equal(expectedUnitCost, model.UnitCost);
        Assert.Equal(expectedUnitCostCurrency, model.UnitCostCurrency);
        Assert.Equal(expectedUnitOfMeasureCode, model.UnitOfMeasureCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LineItem
        {
            ID = "id",
            DetailIndicator = DetailIndicator.Normal,
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided,
            ItemCommodityCode = "item_commodity_code",
            ItemDescriptor = "item_descriptor",
            ItemQuantity = "-16699",
            ProductCode = "product_code",
            SalesTaxAmount = 0,
            SalesTaxCurrency = "sales_tax_currency",
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            TotalAmountCurrency = "total_amount_currency",
            UnitCost = "-16699",
            UnitCostCurrency = "unit_cost_currency",
            UnitOfMeasureCode = "unit_of_measure_code",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LineItem
        {
            ID = "id",
            DetailIndicator = DetailIndicator.Normal,
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided,
            ItemCommodityCode = "item_commodity_code",
            ItemDescriptor = "item_descriptor",
            ItemQuantity = "-16699",
            ProductCode = "product_code",
            SalesTaxAmount = 0,
            SalesTaxCurrency = "sales_tax_currency",
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            TotalAmountCurrency = "total_amount_currency",
            UnitCost = "-16699",
            UnitCostCurrency = "unit_cost_currency",
            UnitOfMeasureCode = "unit_of_measure_code",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, DetailIndicator> expectedDetailIndicator = DetailIndicator.Normal;
        long expectedDiscountAmount = 0;
        string expectedDiscountCurrency = "discount_currency";
        ApiEnum<string, LineItemDiscountTreatmentCode> expectedDiscountTreatmentCode =
            LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided;
        string expectedItemCommodityCode = "item_commodity_code";
        string expectedItemDescriptor = "item_descriptor";
        string expectedItemQuantity = "-16699";
        string expectedProductCode = "product_code";
        long expectedSalesTaxAmount = 0;
        string expectedSalesTaxCurrency = "sales_tax_currency";
        string expectedSalesTaxRate = "-16699";
        long expectedTotalAmount = 0;
        string expectedTotalAmountCurrency = "total_amount_currency";
        string expectedUnitCost = "-16699";
        string expectedUnitCostCurrency = "unit_cost_currency";
        string expectedUnitOfMeasureCode = "unit_of_measure_code";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDetailIndicator, deserialized.DetailIndicator);
        Assert.Equal(expectedDiscountAmount, deserialized.DiscountAmount);
        Assert.Equal(expectedDiscountCurrency, deserialized.DiscountCurrency);
        Assert.Equal(expectedDiscountTreatmentCode, deserialized.DiscountTreatmentCode);
        Assert.Equal(expectedItemCommodityCode, deserialized.ItemCommodityCode);
        Assert.Equal(expectedItemDescriptor, deserialized.ItemDescriptor);
        Assert.Equal(expectedItemQuantity, deserialized.ItemQuantity);
        Assert.Equal(expectedProductCode, deserialized.ProductCode);
        Assert.Equal(expectedSalesTaxAmount, deserialized.SalesTaxAmount);
        Assert.Equal(expectedSalesTaxCurrency, deserialized.SalesTaxCurrency);
        Assert.Equal(expectedSalesTaxRate, deserialized.SalesTaxRate);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedTotalAmountCurrency, deserialized.TotalAmountCurrency);
        Assert.Equal(expectedUnitCost, deserialized.UnitCost);
        Assert.Equal(expectedUnitCostCurrency, deserialized.UnitCostCurrency);
        Assert.Equal(expectedUnitOfMeasureCode, deserialized.UnitOfMeasureCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LineItem
        {
            ID = "id",
            DetailIndicator = DetailIndicator.Normal,
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided,
            ItemCommodityCode = "item_commodity_code",
            ItemDescriptor = "item_descriptor",
            ItemQuantity = "-16699",
            ProductCode = "product_code",
            SalesTaxAmount = 0,
            SalesTaxCurrency = "sales_tax_currency",
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            TotalAmountCurrency = "total_amount_currency",
            UnitCost = "-16699",
            UnitCostCurrency = "unit_cost_currency",
            UnitOfMeasureCode = "unit_of_measure_code",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LineItem
        {
            ID = "id",
            DetailIndicator = DetailIndicator.Normal,
            DiscountAmount = 0,
            DiscountCurrency = "discount_currency",
            DiscountTreatmentCode = LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided,
            ItemCommodityCode = "item_commodity_code",
            ItemDescriptor = "item_descriptor",
            ItemQuantity = "-16699",
            ProductCode = "product_code",
            SalesTaxAmount = 0,
            SalesTaxCurrency = "sales_tax_currency",
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            TotalAmountCurrency = "total_amount_currency",
            UnitCost = "-16699",
            UnitCostCurrency = "unit_cost_currency",
            UnitOfMeasureCode = "unit_of_measure_code",
        };

        LineItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DetailIndicatorTest : TestBase
{
    [Theory]
    [InlineData(DetailIndicator.Normal)]
    [InlineData(DetailIndicator.Credit)]
    [InlineData(DetailIndicator.Payment)]
    public void Validation_Works(DetailIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DetailIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DetailIndicator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DetailIndicator.Normal)]
    [InlineData(DetailIndicator.Credit)]
    [InlineData(DetailIndicator.Payment)]
    public void SerializationRoundtrip_Works(DetailIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DetailIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DetailIndicator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DetailIndicator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DetailIndicator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LineItemDiscountTreatmentCodeTest : TestBase
{
    [Theory]
    [InlineData(LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided)]
    [InlineData(LineItemDiscountTreatmentCode.TaxCalculatedOnPostDiscountLineItemTotal)]
    [InlineData(LineItemDiscountTreatmentCode.TaxCalculatedOnPreDiscountLineItemTotal)]
    public void Validation_Works(LineItemDiscountTreatmentCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LineItemDiscountTreatmentCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LineItemDiscountTreatmentCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LineItemDiscountTreatmentCode.NoLineItemLevelDiscountProvided)]
    [InlineData(LineItemDiscountTreatmentCode.TaxCalculatedOnPostDiscountLineItemTotal)]
    [InlineData(LineItemDiscountTreatmentCode.TaxCalculatedOnPreDiscountLineItemTotal)]
    public void SerializationRoundtrip_Works(LineItemDiscountTreatmentCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LineItemDiscountTreatmentCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LineItemDiscountTreatmentCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LineItemDiscountTreatmentCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, LineItemDiscountTreatmentCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.CardPurchaseSupplement)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.CardPurchaseSupplement)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
