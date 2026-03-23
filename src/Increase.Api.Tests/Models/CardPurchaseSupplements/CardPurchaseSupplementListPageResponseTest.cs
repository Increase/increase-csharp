using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.CardPurchaseSupplements;

namespace Increase.Api.Tests.Models.CardPurchaseSupplements;

public class CardPurchaseSupplementListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardPurchaseSupplementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<CardPurchaseSupplement> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardPurchaseSupplementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPurchaseSupplementListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardPurchaseSupplementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardPurchaseSupplementListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CardPurchaseSupplement> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardPurchaseSupplementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardPurchaseSupplementListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        CardPurchaseSupplementListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
