using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AchTransfers;

namespace Increase.Api.Tests.Models.AchTransfers;

public class AchTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            StatementDescriptor = "New ACH transfer",
            AccountNumber = "987654321",
            Addenda = new()
            {
                Category = Category.Freeform,
                Freeform = new([new("x")]),
                PaymentOrderRemittanceAdvice = new([new() { InvoiceNumber = "x", PaidAmount = 0 }]),
            },
            CompanyDescriptiveDate = "x",
            CompanyDiscretionaryData = "x",
            CompanyEntryDescription = "x",
            CompanyName = "x",
            DestinationAccountHolder = DestinationAccountHolder.Business,
            ExternalAccountID = "external_account_id",
            Funding = Funding.Checking,
            IndividualID = "x",
            IndividualName = "x",
            PreferredEffectiveDate = new()
            {
                Date = "2019-12-27",
                SettlementSchedule = SettlementSchedule.SameDay,
            },
            RequireApproval = true,
            RoutingNumber = "101050001",
            StandardEntryClassCode = StandardEntryClassCode.CorporateCreditOrDebit,
            TransactionTiming = TransactionTiming.Synchronous,
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 100;
        string expectedStatementDescriptor = "New ACH transfer";
        string expectedAccountNumber = "987654321";
        Addenda expectedAddenda = new()
        {
            Category = Category.Freeform,
            Freeform = new([new("x")]),
            PaymentOrderRemittanceAdvice = new([new() { InvoiceNumber = "x", PaidAmount = 0 }]),
        };
        string expectedCompanyDescriptiveDate = "x";
        string expectedCompanyDiscretionaryData = "x";
        string expectedCompanyEntryDescription = "x";
        string expectedCompanyName = "x";
        ApiEnum<string, DestinationAccountHolder> expectedDestinationAccountHolder =
            DestinationAccountHolder.Business;
        string expectedExternalAccountID = "external_account_id";
        ApiEnum<string, Funding> expectedFunding = Funding.Checking;
        string expectedIndividualID = "x";
        string expectedIndividualName = "x";
        PreferredEffectiveDate expectedPreferredEffectiveDate = new()
        {
            Date = "2019-12-27",
            SettlementSchedule = SettlementSchedule.SameDay,
        };
        bool expectedRequireApproval = true;
        string expectedRoutingNumber = "101050001";
        ApiEnum<string, StandardEntryClassCode> expectedStandardEntryClassCode =
            StandardEntryClassCode.CorporateCreditOrDebit;
        ApiEnum<string, TransactionTiming> expectedTransactionTiming =
            TransactionTiming.Synchronous;

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedStatementDescriptor, parameters.StatementDescriptor);
        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedAddenda, parameters.Addenda);
        Assert.Equal(expectedCompanyDescriptiveDate, parameters.CompanyDescriptiveDate);
        Assert.Equal(expectedCompanyDiscretionaryData, parameters.CompanyDiscretionaryData);
        Assert.Equal(expectedCompanyEntryDescription, parameters.CompanyEntryDescription);
        Assert.Equal(expectedCompanyName, parameters.CompanyName);
        Assert.Equal(expectedDestinationAccountHolder, parameters.DestinationAccountHolder);
        Assert.Equal(expectedExternalAccountID, parameters.ExternalAccountID);
        Assert.Equal(expectedFunding, parameters.Funding);
        Assert.Equal(expectedIndividualID, parameters.IndividualID);
        Assert.Equal(expectedIndividualName, parameters.IndividualName);
        Assert.Equal(expectedPreferredEffectiveDate, parameters.PreferredEffectiveDate);
        Assert.Equal(expectedRequireApproval, parameters.RequireApproval);
        Assert.Equal(expectedRoutingNumber, parameters.RoutingNumber);
        Assert.Equal(expectedStandardEntryClassCode, parameters.StandardEntryClassCode);
        Assert.Equal(expectedTransactionTiming, parameters.TransactionTiming);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AchTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            StatementDescriptor = "New ACH transfer",
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.Addenda);
        Assert.False(parameters.RawBodyData.ContainsKey("addenda"));
        Assert.Null(parameters.CompanyDescriptiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("company_descriptive_date"));
        Assert.Null(parameters.CompanyDiscretionaryData);
        Assert.False(parameters.RawBodyData.ContainsKey("company_discretionary_data"));
        Assert.Null(parameters.CompanyEntryDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("company_entry_description"));
        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("company_name"));
        Assert.Null(parameters.DestinationAccountHolder);
        Assert.False(parameters.RawBodyData.ContainsKey("destination_account_holder"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
        Assert.Null(parameters.Funding);
        Assert.False(parameters.RawBodyData.ContainsKey("funding"));
        Assert.Null(parameters.IndividualID);
        Assert.False(parameters.RawBodyData.ContainsKey("individual_id"));
        Assert.Null(parameters.IndividualName);
        Assert.False(parameters.RawBodyData.ContainsKey("individual_name"));
        Assert.Null(parameters.PreferredEffectiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("preferred_effective_date"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
        Assert.Null(parameters.StandardEntryClassCode);
        Assert.False(parameters.RawBodyData.ContainsKey("standard_entry_class_code"));
        Assert.Null(parameters.TransactionTiming);
        Assert.False(parameters.RawBodyData.ContainsKey("transaction_timing"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AchTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            StatementDescriptor = "New ACH transfer",

            // Null should be interpreted as omitted for these properties
            AccountNumber = null,
            Addenda = null,
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyName = null,
            DestinationAccountHolder = null,
            ExternalAccountID = null,
            Funding = null,
            IndividualID = null,
            IndividualName = null,
            PreferredEffectiveDate = null,
            RequireApproval = null,
            RoutingNumber = null,
            StandardEntryClassCode = null,
            TransactionTiming = null,
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.Addenda);
        Assert.False(parameters.RawBodyData.ContainsKey("addenda"));
        Assert.Null(parameters.CompanyDescriptiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("company_descriptive_date"));
        Assert.Null(parameters.CompanyDiscretionaryData);
        Assert.False(parameters.RawBodyData.ContainsKey("company_discretionary_data"));
        Assert.Null(parameters.CompanyEntryDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("company_entry_description"));
        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("company_name"));
        Assert.Null(parameters.DestinationAccountHolder);
        Assert.False(parameters.RawBodyData.ContainsKey("destination_account_holder"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
        Assert.Null(parameters.Funding);
        Assert.False(parameters.RawBodyData.ContainsKey("funding"));
        Assert.Null(parameters.IndividualID);
        Assert.False(parameters.RawBodyData.ContainsKey("individual_id"));
        Assert.Null(parameters.IndividualName);
        Assert.False(parameters.RawBodyData.ContainsKey("individual_name"));
        Assert.Null(parameters.PreferredEffectiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("preferred_effective_date"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
        Assert.Null(parameters.StandardEntryClassCode);
        Assert.False(parameters.RawBodyData.ContainsKey("standard_entry_class_code"));
        Assert.Null(parameters.TransactionTiming);
        Assert.False(parameters.RawBodyData.ContainsKey("transaction_timing"));
    }

    [Fact]
    public void Url_Works()
    {
        AchTransferCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            StatementDescriptor = "New ACH transfer",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/ach_transfers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            StatementDescriptor = "New ACH transfer",
            AccountNumber = "987654321",
            Addenda = new()
            {
                Category = Category.Freeform,
                Freeform = new([new("x")]),
                PaymentOrderRemittanceAdvice = new([new() { InvoiceNumber = "x", PaidAmount = 0 }]),
            },
            CompanyDescriptiveDate = "x",
            CompanyDiscretionaryData = "x",
            CompanyEntryDescription = "x",
            CompanyName = "x",
            DestinationAccountHolder = DestinationAccountHolder.Business,
            ExternalAccountID = "external_account_id",
            Funding = Funding.Checking,
            IndividualID = "x",
            IndividualName = "x",
            PreferredEffectiveDate = new()
            {
                Date = "2019-12-27",
                SettlementSchedule = SettlementSchedule.SameDay,
            },
            RequireApproval = true,
            RoutingNumber = "101050001",
            StandardEntryClassCode = StandardEntryClassCode.CorporateCreditOrDebit,
            TransactionTiming = TransactionTiming.Synchronous,
        };

        AchTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AddendaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,
            Freeform = new([new("x")]),
            PaymentOrderRemittanceAdvice = new([new() { InvoiceNumber = "x", PaidAmount = 0 }]),
        };

        ApiEnum<string, Category> expectedCategory = Category.Freeform;
        Freeform expectedFreeform = new([new("x")]);
        PaymentOrderRemittanceAdvice expectedPaymentOrderRemittanceAdvice = new(
            [new() { InvoiceNumber = "x", PaidAmount = 0 }]
        );

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedFreeform, model.Freeform);
        Assert.Equal(expectedPaymentOrderRemittanceAdvice, model.PaymentOrderRemittanceAdvice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,
            Freeform = new([new("x")]),
            PaymentOrderRemittanceAdvice = new([new() { InvoiceNumber = "x", PaidAmount = 0 }]),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Addenda>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,
            Freeform = new([new("x")]),
            PaymentOrderRemittanceAdvice = new([new() { InvoiceNumber = "x", PaidAmount = 0 }]),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Addenda>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Category> expectedCategory = Category.Freeform;
        Freeform expectedFreeform = new([new("x")]);
        PaymentOrderRemittanceAdvice expectedPaymentOrderRemittanceAdvice = new(
            [new() { InvoiceNumber = "x", PaidAmount = 0 }]
        );

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedFreeform, deserialized.Freeform);
        Assert.Equal(
            expectedPaymentOrderRemittanceAdvice,
            deserialized.PaymentOrderRemittanceAdvice
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,
            Freeform = new([new("x")]),
            PaymentOrderRemittanceAdvice = new([new() { InvoiceNumber = "x", PaidAmount = 0 }]),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Addenda { Category = Category.Freeform };

        Assert.Null(model.Freeform);
        Assert.False(model.RawData.ContainsKey("freeform"));
        Assert.Null(model.PaymentOrderRemittanceAdvice);
        Assert.False(model.RawData.ContainsKey("payment_order_remittance_advice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Addenda { Category = Category.Freeform };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,

            // Null should be interpreted as omitted for these properties
            Freeform = null,
            PaymentOrderRemittanceAdvice = null,
        };

        Assert.Null(model.Freeform);
        Assert.False(model.RawData.ContainsKey("freeform"));
        Assert.Null(model.PaymentOrderRemittanceAdvice);
        Assert.False(model.RawData.ContainsKey("payment_order_remittance_advice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,

            // Null should be interpreted as omitted for these properties
            Freeform = null,
            PaymentOrderRemittanceAdvice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,
            Freeform = new([new("x")]),
            PaymentOrderRemittanceAdvice = new([new() { InvoiceNumber = "x", PaidAmount = 0 }]),
        };

        Addenda copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Freeform)]
    [InlineData(Category.PaymentOrderRemittanceAdvice)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Freeform)]
    [InlineData(Category.PaymentOrderRemittanceAdvice)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FreeformTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Freeform { Entries = [new("x")] };

        List<Entry> expectedEntries = [new("x")];

        Assert.Equal(expectedEntries.Count, model.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], model.Entries[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Freeform { Entries = [new("x")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Freeform>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Freeform { Entries = [new("x")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Freeform>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Entry> expectedEntries = [new("x")];

        Assert.Equal(expectedEntries.Count, deserialized.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], deserialized.Entries[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Freeform { Entries = [new("x")] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Freeform { Entries = [new("x")] };

        Freeform copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "x" };

        string expectedPaymentRelatedInformation = "x";

        Assert.Equal(expectedPaymentRelatedInformation, model.PaymentRelatedInformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedPaymentRelatedInformation = "x";

        Assert.Equal(expectedPaymentRelatedInformation, deserialized.PaymentRelatedInformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "x" };

        Entry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentOrderRemittanceAdviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "x", PaidAmount = 0 }],
        };

        List<Invoice> expectedInvoices = [new() { InvoiceNumber = "x", PaidAmount = 0 }];

        Assert.Equal(expectedInvoices.Count, model.Invoices.Count);
        for (int i = 0; i < expectedInvoices.Count; i++)
        {
            Assert.Equal(expectedInvoices[i], model.Invoices[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "x", PaidAmount = 0 }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentOrderRemittanceAdvice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "x", PaidAmount = 0 }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaymentOrderRemittanceAdvice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Invoice> expectedInvoices = [new() { InvoiceNumber = "x", PaidAmount = 0 }];

        Assert.Equal(expectedInvoices.Count, deserialized.Invoices.Count);
        for (int i = 0; i < expectedInvoices.Count; i++)
        {
            Assert.Equal(expectedInvoices[i], deserialized.Invoices[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "x", PaidAmount = 0 }],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaymentOrderRemittanceAdvice
        {
            Invoices = [new() { InvoiceNumber = "x", PaidAmount = 0 }],
        };

        PaymentOrderRemittanceAdvice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoice { InvoiceNumber = "x", PaidAmount = 0 };

        string expectedInvoiceNumber = "x";
        long expectedPaidAmount = 0;

        Assert.Equal(expectedInvoiceNumber, model.InvoiceNumber);
        Assert.Equal(expectedPaidAmount, model.PaidAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoice { InvoiceNumber = "x", PaidAmount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoice { InvoiceNumber = "x", PaidAmount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInvoiceNumber = "x";
        long expectedPaidAmount = 0;

        Assert.Equal(expectedInvoiceNumber, deserialized.InvoiceNumber);
        Assert.Equal(expectedPaidAmount, deserialized.PaidAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoice { InvoiceNumber = "x", PaidAmount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Invoice { InvoiceNumber = "x", PaidAmount = 0 };

        Invoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DestinationAccountHolderTest : TestBase
{
    [Theory]
    [InlineData(DestinationAccountHolder.Business)]
    [InlineData(DestinationAccountHolder.Individual)]
    [InlineData(DestinationAccountHolder.Unknown)]
    public void Validation_Works(DestinationAccountHolder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DestinationAccountHolder> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DestinationAccountHolder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DestinationAccountHolder.Business)]
    [InlineData(DestinationAccountHolder.Individual)]
    [InlineData(DestinationAccountHolder.Unknown)]
    public void SerializationRoundtrip_Works(DestinationAccountHolder rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DestinationAccountHolder> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DestinationAccountHolder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DestinationAccountHolder>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DestinationAccountHolder>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FundingTest : TestBase
{
    [Theory]
    [InlineData(Funding.Checking)]
    [InlineData(Funding.Savings)]
    [InlineData(Funding.GeneralLedger)]
    public void Validation_Works(Funding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Funding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Funding.Checking)]
    [InlineData(Funding.Savings)]
    [InlineData(Funding.GeneralLedger)]
    public void SerializationRoundtrip_Works(Funding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Funding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Funding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PreferredEffectiveDateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule = SettlementSchedule.SameDay,
        };

        string expectedDate = "2019-12-27";
        ApiEnum<string, SettlementSchedule> expectedSettlementSchedule = SettlementSchedule.SameDay;

        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedSettlementSchedule, model.SettlementSchedule);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule = SettlementSchedule.SameDay,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferredEffectiveDate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule = SettlementSchedule.SameDay,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PreferredEffectiveDate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDate = "2019-12-27";
        ApiEnum<string, SettlementSchedule> expectedSettlementSchedule = SettlementSchedule.SameDay;

        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedSettlementSchedule, deserialized.SettlementSchedule);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule = SettlementSchedule.SameDay,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PreferredEffectiveDate { };

        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.SettlementSchedule);
        Assert.False(model.RawData.ContainsKey("settlement_schedule"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PreferredEffectiveDate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PreferredEffectiveDate
        {
            // Null should be interpreted as omitted for these properties
            Date = null,
            SettlementSchedule = null,
        };

        Assert.Null(model.Date);
        Assert.False(model.RawData.ContainsKey("date"));
        Assert.Null(model.SettlementSchedule);
        Assert.False(model.RawData.ContainsKey("settlement_schedule"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PreferredEffectiveDate
        {
            // Null should be interpreted as omitted for these properties
            Date = null,
            SettlementSchedule = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PreferredEffectiveDate
        {
            Date = "2019-12-27",
            SettlementSchedule = SettlementSchedule.SameDay,
        };

        PreferredEffectiveDate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SettlementScheduleTest : TestBase
{
    [Theory]
    [InlineData(SettlementSchedule.SameDay)]
    [InlineData(SettlementSchedule.FutureDated)]
    public void Validation_Works(SettlementSchedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SettlementSchedule> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SettlementSchedule>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SettlementSchedule.SameDay)]
    [InlineData(SettlementSchedule.FutureDated)]
    public void SerializationRoundtrip_Works(SettlementSchedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SettlementSchedule> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SettlementSchedule>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SettlementSchedule>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SettlementSchedule>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StandardEntryClassCodeTest : TestBase
{
    [Theory]
    [InlineData(StandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(StandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(StandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(StandardEntryClassCode.InternetInitiated)]
    public void Validation_Works(StandardEntryClassCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StandardEntryClassCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StandardEntryClassCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(StandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(StandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(StandardEntryClassCode.InternetInitiated)]
    public void SerializationRoundtrip_Works(StandardEntryClassCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StandardEntryClassCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StandardEntryClassCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StandardEntryClassCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StandardEntryClassCode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransactionTimingTest : TestBase
{
    [Theory]
    [InlineData(TransactionTiming.Synchronous)]
    [InlineData(TransactionTiming.Asynchronous)]
    public void Validation_Works(TransactionTiming rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionTiming> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionTiming>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TransactionTiming.Synchronous)]
    [InlineData(TransactionTiming.Asynchronous)]
    public void SerializationRoundtrip_Works(TransactionTiming rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransactionTiming> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionTiming>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransactionTiming>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransactionTiming>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
