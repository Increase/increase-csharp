using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.CardPurchaseSupplements;

namespace Increase.Api.Tests.Models.Simulations.CardPurchaseSupplements;

public class CardPurchaseSupplementCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardPurchaseSupplementCreateParams
        {
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Invoice = new()
            {
                DiscountAmount = 100,
                DutyTaxAmount = 200,
                OrderDate = "2023-07-20",
                ShippingAmount = 300,
                ShippingDestinationCountryCode = "US",
                ShippingDestinationPostalCode = "10045",
                ShippingSourcePostalCode = "10045",
                ShippingTaxAmount = 400,
                ShippingTaxRate = "0.2",
                UniqueValueAddedTaxInvoiceReference = "12302",
            },
            LineItems =
            [
                new()
                {
                    DiscountAmount = 0,
                    ItemCommodityCode = "001",
                    ItemDescriptor = "Coffee",
                    ItemQuantity = "1",
                    ProductCode = "101",
                    SalesTaxAmount = 0,
                    SalesTaxRate = "-16699",
                    TotalAmount = 500,
                    UnitCost = "5",
                    UnitOfMeasureCode = "NMB",
                },
            ],
        };

        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        Invoice expectedInvoice = new()
        {
            DiscountAmount = 100,
            DutyTaxAmount = 200,
            OrderDate = "2023-07-20",
            ShippingAmount = 300,
            ShippingDestinationCountryCode = "US",
            ShippingDestinationPostalCode = "10045",
            ShippingSourcePostalCode = "10045",
            ShippingTaxAmount = 400,
            ShippingTaxRate = "0.2",
            UniqueValueAddedTaxInvoiceReference = "12302",
        };
        List<LineItem> expectedLineItems =
        [
            new()
            {
                DiscountAmount = 0,
                ItemCommodityCode = "001",
                ItemDescriptor = "Coffee",
                ItemQuantity = "1",
                ProductCode = "101",
                SalesTaxAmount = 0,
                SalesTaxRate = "-16699",
                TotalAmount = 500,
                UnitCost = "5",
                UnitOfMeasureCode = "NMB",
            },
        ];

        Assert.Equal(expectedTransactionID, parameters.TransactionID);
        Assert.Equal(expectedInvoice, parameters.Invoice);
        Assert.NotNull(parameters.LineItems);
        Assert.Equal(expectedLineItems.Count, parameters.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], parameters.LineItems[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardPurchaseSupplementCreateParams
        {
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        Assert.Null(parameters.Invoice);
        Assert.False(parameters.RawBodyData.ContainsKey("invoice"));
        Assert.Null(parameters.LineItems);
        Assert.False(parameters.RawBodyData.ContainsKey("line_items"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardPurchaseSupplementCreateParams
        {
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",

            // Null should be interpreted as omitted for these properties
            Invoice = null,
            LineItems = null,
        };

        Assert.Null(parameters.Invoice);
        Assert.False(parameters.RawBodyData.ContainsKey("invoice"));
        Assert.Null(parameters.LineItems);
        Assert.False(parameters.RawBodyData.ContainsKey("line_items"));
    }

    [Fact]
    public void Url_Works()
    {
        CardPurchaseSupplementCreateParams parameters = new()
        {
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/simulations/card_purchase_supplements"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardPurchaseSupplementCreateParams
        {
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Invoice = new()
            {
                DiscountAmount = 100,
                DutyTaxAmount = 200,
                OrderDate = "2023-07-20",
                ShippingAmount = 300,
                ShippingDestinationCountryCode = "US",
                ShippingDestinationPostalCode = "10045",
                ShippingSourcePostalCode = "10045",
                ShippingTaxAmount = 400,
                ShippingTaxRate = "0.2",
                UniqueValueAddedTaxInvoiceReference = "12302",
            },
            LineItems =
            [
                new()
                {
                    DiscountAmount = 0,
                    ItemCommodityCode = "001",
                    ItemDescriptor = "Coffee",
                    ItemQuantity = "1",
                    ProductCode = "101",
                    SalesTaxAmount = 0,
                    SalesTaxRate = "-16699",
                    TotalAmount = 500,
                    UnitCost = "5",
                    UnitOfMeasureCode = "NMB",
                },
            ],
        };

        CardPurchaseSupplementCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
            DutyTaxAmount = 0,
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingDestinationCountryCode = "x",
            ShippingDestinationPostalCode = "x",
            ShippingSourcePostalCode = "x",
            ShippingTaxAmount = 0,
            ShippingTaxRate = "-16699",
            UniqueValueAddedTaxInvoiceReference = "x",
        };

        long expectedDiscountAmount = 0;
        long expectedDutyTaxAmount = 0;
        string expectedOrderDate = "2019-12-27";
        long expectedShippingAmount = 0;
        string expectedShippingDestinationCountryCode = "x";
        string expectedShippingDestinationPostalCode = "x";
        string expectedShippingSourcePostalCode = "x";
        long expectedShippingTaxAmount = 0;
        string expectedShippingTaxRate = "-16699";
        string expectedUniqueValueAddedTaxInvoiceReference = "x";

        Assert.Equal(expectedDiscountAmount, model.DiscountAmount);
        Assert.Equal(expectedDutyTaxAmount, model.DutyTaxAmount);
        Assert.Equal(expectedOrderDate, model.OrderDate);
        Assert.Equal(expectedShippingAmount, model.ShippingAmount);
        Assert.Equal(expectedShippingDestinationCountryCode, model.ShippingDestinationCountryCode);
        Assert.Equal(expectedShippingDestinationPostalCode, model.ShippingDestinationPostalCode);
        Assert.Equal(expectedShippingSourcePostalCode, model.ShippingSourcePostalCode);
        Assert.Equal(expectedShippingTaxAmount, model.ShippingTaxAmount);
        Assert.Equal(expectedShippingTaxRate, model.ShippingTaxRate);
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
            DutyTaxAmount = 0,
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingDestinationCountryCode = "x",
            ShippingDestinationPostalCode = "x",
            ShippingSourcePostalCode = "x",
            ShippingTaxAmount = 0,
            ShippingTaxRate = "-16699",
            UniqueValueAddedTaxInvoiceReference = "x",
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
            DutyTaxAmount = 0,
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingDestinationCountryCode = "x",
            ShippingDestinationPostalCode = "x",
            ShippingSourcePostalCode = "x",
            ShippingTaxAmount = 0,
            ShippingTaxRate = "-16699",
            UniqueValueAddedTaxInvoiceReference = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDiscountAmount = 0;
        long expectedDutyTaxAmount = 0;
        string expectedOrderDate = "2019-12-27";
        long expectedShippingAmount = 0;
        string expectedShippingDestinationCountryCode = "x";
        string expectedShippingDestinationPostalCode = "x";
        string expectedShippingSourcePostalCode = "x";
        long expectedShippingTaxAmount = 0;
        string expectedShippingTaxRate = "-16699";
        string expectedUniqueValueAddedTaxInvoiceReference = "x";

        Assert.Equal(expectedDiscountAmount, deserialized.DiscountAmount);
        Assert.Equal(expectedDutyTaxAmount, deserialized.DutyTaxAmount);
        Assert.Equal(expectedOrderDate, deserialized.OrderDate);
        Assert.Equal(expectedShippingAmount, deserialized.ShippingAmount);
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
        Assert.Equal(expectedShippingTaxRate, deserialized.ShippingTaxRate);
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
            DutyTaxAmount = 0,
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingDestinationCountryCode = "x",
            ShippingDestinationPostalCode = "x",
            ShippingSourcePostalCode = "x",
            ShippingTaxAmount = 0,
            ShippingTaxRate = "-16699",
            UniqueValueAddedTaxInvoiceReference = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Invoice { };

        Assert.Null(model.DiscountAmount);
        Assert.False(model.RawData.ContainsKey("discount_amount"));
        Assert.Null(model.DutyTaxAmount);
        Assert.False(model.RawData.ContainsKey("duty_tax_amount"));
        Assert.Null(model.OrderDate);
        Assert.False(model.RawData.ContainsKey("order_date"));
        Assert.Null(model.ShippingAmount);
        Assert.False(model.RawData.ContainsKey("shipping_amount"));
        Assert.Null(model.ShippingDestinationCountryCode);
        Assert.False(model.RawData.ContainsKey("shipping_destination_country_code"));
        Assert.Null(model.ShippingDestinationPostalCode);
        Assert.False(model.RawData.ContainsKey("shipping_destination_postal_code"));
        Assert.Null(model.ShippingSourcePostalCode);
        Assert.False(model.RawData.ContainsKey("shipping_source_postal_code"));
        Assert.Null(model.ShippingTaxAmount);
        Assert.False(model.RawData.ContainsKey("shipping_tax_amount"));
        Assert.Null(model.ShippingTaxRate);
        Assert.False(model.RawData.ContainsKey("shipping_tax_rate"));
        Assert.Null(model.UniqueValueAddedTaxInvoiceReference);
        Assert.False(model.RawData.ContainsKey("unique_value_added_tax_invoice_reference"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Invoice { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Invoice
        {
            // Null should be interpreted as omitted for these properties
            DiscountAmount = null,
            DutyTaxAmount = null,
            OrderDate = null,
            ShippingAmount = null,
            ShippingDestinationCountryCode = null,
            ShippingDestinationPostalCode = null,
            ShippingSourcePostalCode = null,
            ShippingTaxAmount = null,
            ShippingTaxRate = null,
            UniqueValueAddedTaxInvoiceReference = null,
        };

        Assert.Null(model.DiscountAmount);
        Assert.False(model.RawData.ContainsKey("discount_amount"));
        Assert.Null(model.DutyTaxAmount);
        Assert.False(model.RawData.ContainsKey("duty_tax_amount"));
        Assert.Null(model.OrderDate);
        Assert.False(model.RawData.ContainsKey("order_date"));
        Assert.Null(model.ShippingAmount);
        Assert.False(model.RawData.ContainsKey("shipping_amount"));
        Assert.Null(model.ShippingDestinationCountryCode);
        Assert.False(model.RawData.ContainsKey("shipping_destination_country_code"));
        Assert.Null(model.ShippingDestinationPostalCode);
        Assert.False(model.RawData.ContainsKey("shipping_destination_postal_code"));
        Assert.Null(model.ShippingSourcePostalCode);
        Assert.False(model.RawData.ContainsKey("shipping_source_postal_code"));
        Assert.Null(model.ShippingTaxAmount);
        Assert.False(model.RawData.ContainsKey("shipping_tax_amount"));
        Assert.Null(model.ShippingTaxRate);
        Assert.False(model.RawData.ContainsKey("shipping_tax_rate"));
        Assert.Null(model.UniqueValueAddedTaxInvoiceReference);
        Assert.False(model.RawData.ContainsKey("unique_value_added_tax_invoice_reference"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Invoice
        {
            // Null should be interpreted as omitted for these properties
            DiscountAmount = null,
            DutyTaxAmount = null,
            OrderDate = null,
            ShippingAmount = null,
            ShippingDestinationCountryCode = null,
            ShippingDestinationPostalCode = null,
            ShippingSourcePostalCode = null,
            ShippingTaxAmount = null,
            ShippingTaxRate = null,
            UniqueValueAddedTaxInvoiceReference = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice
        {
            DiscountAmount = 0,
            DutyTaxAmount = 0,
            OrderDate = "2019-12-27",
            ShippingAmount = 0,
            ShippingDestinationCountryCode = "x",
            ShippingDestinationPostalCode = "x",
            ShippingSourcePostalCode = "x",
            ShippingTaxAmount = 0,
            ShippingTaxRate = "-16699",
            UniqueValueAddedTaxInvoiceReference = "x",
        };

        Invoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LineItem
        {
            DiscountAmount = 0,
            ItemCommodityCode = "x",
            ItemDescriptor = "x",
            ItemQuantity = "-16699",
            ProductCode = "x",
            SalesTaxAmount = 0,
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            UnitCost = "-16699",
            UnitOfMeasureCode = "x",
        };

        long expectedDiscountAmount = 0;
        string expectedItemCommodityCode = "x";
        string expectedItemDescriptor = "x";
        string expectedItemQuantity = "-16699";
        string expectedProductCode = "x";
        long expectedSalesTaxAmount = 0;
        string expectedSalesTaxRate = "-16699";
        long expectedTotalAmount = 0;
        string expectedUnitCost = "-16699";
        string expectedUnitOfMeasureCode = "x";

        Assert.Equal(expectedDiscountAmount, model.DiscountAmount);
        Assert.Equal(expectedItemCommodityCode, model.ItemCommodityCode);
        Assert.Equal(expectedItemDescriptor, model.ItemDescriptor);
        Assert.Equal(expectedItemQuantity, model.ItemQuantity);
        Assert.Equal(expectedProductCode, model.ProductCode);
        Assert.Equal(expectedSalesTaxAmount, model.SalesTaxAmount);
        Assert.Equal(expectedSalesTaxRate, model.SalesTaxRate);
        Assert.Equal(expectedTotalAmount, model.TotalAmount);
        Assert.Equal(expectedUnitCost, model.UnitCost);
        Assert.Equal(expectedUnitOfMeasureCode, model.UnitOfMeasureCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LineItem
        {
            DiscountAmount = 0,
            ItemCommodityCode = "x",
            ItemDescriptor = "x",
            ItemQuantity = "-16699",
            ProductCode = "x",
            SalesTaxAmount = 0,
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            UnitCost = "-16699",
            UnitOfMeasureCode = "x",
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
            DiscountAmount = 0,
            ItemCommodityCode = "x",
            ItemDescriptor = "x",
            ItemQuantity = "-16699",
            ProductCode = "x",
            SalesTaxAmount = 0,
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            UnitCost = "-16699",
            UnitOfMeasureCode = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDiscountAmount = 0;
        string expectedItemCommodityCode = "x";
        string expectedItemDescriptor = "x";
        string expectedItemQuantity = "-16699";
        string expectedProductCode = "x";
        long expectedSalesTaxAmount = 0;
        string expectedSalesTaxRate = "-16699";
        long expectedTotalAmount = 0;
        string expectedUnitCost = "-16699";
        string expectedUnitOfMeasureCode = "x";

        Assert.Equal(expectedDiscountAmount, deserialized.DiscountAmount);
        Assert.Equal(expectedItemCommodityCode, deserialized.ItemCommodityCode);
        Assert.Equal(expectedItemDescriptor, deserialized.ItemDescriptor);
        Assert.Equal(expectedItemQuantity, deserialized.ItemQuantity);
        Assert.Equal(expectedProductCode, deserialized.ProductCode);
        Assert.Equal(expectedSalesTaxAmount, deserialized.SalesTaxAmount);
        Assert.Equal(expectedSalesTaxRate, deserialized.SalesTaxRate);
        Assert.Equal(expectedTotalAmount, deserialized.TotalAmount);
        Assert.Equal(expectedUnitCost, deserialized.UnitCost);
        Assert.Equal(expectedUnitOfMeasureCode, deserialized.UnitOfMeasureCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LineItem
        {
            DiscountAmount = 0,
            ItemCommodityCode = "x",
            ItemDescriptor = "x",
            ItemQuantity = "-16699",
            ProductCode = "x",
            SalesTaxAmount = 0,
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            UnitCost = "-16699",
            UnitOfMeasureCode = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LineItem { };

        Assert.Null(model.DiscountAmount);
        Assert.False(model.RawData.ContainsKey("discount_amount"));
        Assert.Null(model.ItemCommodityCode);
        Assert.False(model.RawData.ContainsKey("item_commodity_code"));
        Assert.Null(model.ItemDescriptor);
        Assert.False(model.RawData.ContainsKey("item_descriptor"));
        Assert.Null(model.ItemQuantity);
        Assert.False(model.RawData.ContainsKey("item_quantity"));
        Assert.Null(model.ProductCode);
        Assert.False(model.RawData.ContainsKey("product_code"));
        Assert.Null(model.SalesTaxAmount);
        Assert.False(model.RawData.ContainsKey("sales_tax_amount"));
        Assert.Null(model.SalesTaxRate);
        Assert.False(model.RawData.ContainsKey("sales_tax_rate"));
        Assert.Null(model.TotalAmount);
        Assert.False(model.RawData.ContainsKey("total_amount"));
        Assert.Null(model.UnitCost);
        Assert.False(model.RawData.ContainsKey("unit_cost"));
        Assert.Null(model.UnitOfMeasureCode);
        Assert.False(model.RawData.ContainsKey("unit_of_measure_code"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LineItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LineItem
        {
            // Null should be interpreted as omitted for these properties
            DiscountAmount = null,
            ItemCommodityCode = null,
            ItemDescriptor = null,
            ItemQuantity = null,
            ProductCode = null,
            SalesTaxAmount = null,
            SalesTaxRate = null,
            TotalAmount = null,
            UnitCost = null,
            UnitOfMeasureCode = null,
        };

        Assert.Null(model.DiscountAmount);
        Assert.False(model.RawData.ContainsKey("discount_amount"));
        Assert.Null(model.ItemCommodityCode);
        Assert.False(model.RawData.ContainsKey("item_commodity_code"));
        Assert.Null(model.ItemDescriptor);
        Assert.False(model.RawData.ContainsKey("item_descriptor"));
        Assert.Null(model.ItemQuantity);
        Assert.False(model.RawData.ContainsKey("item_quantity"));
        Assert.Null(model.ProductCode);
        Assert.False(model.RawData.ContainsKey("product_code"));
        Assert.Null(model.SalesTaxAmount);
        Assert.False(model.RawData.ContainsKey("sales_tax_amount"));
        Assert.Null(model.SalesTaxRate);
        Assert.False(model.RawData.ContainsKey("sales_tax_rate"));
        Assert.Null(model.TotalAmount);
        Assert.False(model.RawData.ContainsKey("total_amount"));
        Assert.Null(model.UnitCost);
        Assert.False(model.RawData.ContainsKey("unit_cost"));
        Assert.Null(model.UnitOfMeasureCode);
        Assert.False(model.RawData.ContainsKey("unit_of_measure_code"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LineItem
        {
            // Null should be interpreted as omitted for these properties
            DiscountAmount = null,
            ItemCommodityCode = null,
            ItemDescriptor = null,
            ItemQuantity = null,
            ProductCode = null,
            SalesTaxAmount = null,
            SalesTaxRate = null,
            TotalAmount = null,
            UnitCost = null,
            UnitOfMeasureCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LineItem
        {
            DiscountAmount = 0,
            ItemCommodityCode = "x",
            ItemDescriptor = "x",
            ItemQuantity = "-16699",
            ProductCode = "x",
            SalesTaxAmount = 0,
            SalesTaxRate = "-16699",
            TotalAmount = 0,
            UnitCost = "-16699",
            UnitOfMeasureCode = "x",
        };

        LineItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
