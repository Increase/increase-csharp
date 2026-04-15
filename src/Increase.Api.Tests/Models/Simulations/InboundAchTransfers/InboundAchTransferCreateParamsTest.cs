using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.InboundAchTransfers;

namespace Increase.Api.Tests.Models.Simulations.InboundAchTransfers;

public class InboundAchTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundAchTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            Addenda = new()
            {
                Category = Category.Freeform,
                Freeform = new([new("payment_related_information")]),
            },
            CompanyDescriptiveDate = "J!",
            CompanyDiscretionaryData = "J!",
            CompanyEntryDescription = "J!",
            CompanyID = "company_id",
            CompanyName = "company_name",
            ReceiverIDNumber = "x",
            ReceiverName = "x",
            ResolveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StandardEntryClassCode = StandardEntryClassCode.CorporateCreditOrDebit,
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 1000;
        Addenda expectedAddenda = new()
        {
            Category = Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };
        string expectedCompanyDescriptiveDate = "J!";
        string expectedCompanyDiscretionaryData = "J!";
        string expectedCompanyEntryDescription = "J!";
        string expectedCompanyID = "company_id";
        string expectedCompanyName = "company_name";
        string expectedReceiverIDNumber = "x";
        string expectedReceiverName = "x";
        DateTimeOffset expectedResolveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, StandardEntryClassCode> expectedStandardEntryClassCode =
            StandardEntryClassCode.CorporateCreditOrDebit;

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedAddenda, parameters.Addenda);
        Assert.Equal(expectedCompanyDescriptiveDate, parameters.CompanyDescriptiveDate);
        Assert.Equal(expectedCompanyDiscretionaryData, parameters.CompanyDiscretionaryData);
        Assert.Equal(expectedCompanyEntryDescription, parameters.CompanyEntryDescription);
        Assert.Equal(expectedCompanyID, parameters.CompanyID);
        Assert.Equal(expectedCompanyName, parameters.CompanyName);
        Assert.Equal(expectedReceiverIDNumber, parameters.ReceiverIDNumber);
        Assert.Equal(expectedReceiverName, parameters.ReceiverName);
        Assert.Equal(expectedResolveAt, parameters.ResolveAt);
        Assert.Equal(expectedStandardEntryClassCode, parameters.StandardEntryClassCode);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundAchTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
        };

        Assert.Null(parameters.Addenda);
        Assert.False(parameters.RawBodyData.ContainsKey("addenda"));
        Assert.Null(parameters.CompanyDescriptiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("company_descriptive_date"));
        Assert.Null(parameters.CompanyDiscretionaryData);
        Assert.False(parameters.RawBodyData.ContainsKey("company_discretionary_data"));
        Assert.Null(parameters.CompanyEntryDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("company_entry_description"));
        Assert.Null(parameters.CompanyID);
        Assert.False(parameters.RawBodyData.ContainsKey("company_id"));
        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("company_name"));
        Assert.Null(parameters.ReceiverIDNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("receiver_id_number"));
        Assert.Null(parameters.ReceiverName);
        Assert.False(parameters.RawBodyData.ContainsKey("receiver_name"));
        Assert.Null(parameters.ResolveAt);
        Assert.False(parameters.RawBodyData.ContainsKey("resolve_at"));
        Assert.Null(parameters.StandardEntryClassCode);
        Assert.False(parameters.RawBodyData.ContainsKey("standard_entry_class_code"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundAchTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,

            // Null should be interpreted as omitted for these properties
            Addenda = null,
            CompanyDescriptiveDate = null,
            CompanyDiscretionaryData = null,
            CompanyEntryDescription = null,
            CompanyID = null,
            CompanyName = null,
            ReceiverIDNumber = null,
            ReceiverName = null,
            ResolveAt = null,
            StandardEntryClassCode = null,
        };

        Assert.Null(parameters.Addenda);
        Assert.False(parameters.RawBodyData.ContainsKey("addenda"));
        Assert.Null(parameters.CompanyDescriptiveDate);
        Assert.False(parameters.RawBodyData.ContainsKey("company_descriptive_date"));
        Assert.Null(parameters.CompanyDiscretionaryData);
        Assert.False(parameters.RawBodyData.ContainsKey("company_discretionary_data"));
        Assert.Null(parameters.CompanyEntryDescription);
        Assert.False(parameters.RawBodyData.ContainsKey("company_entry_description"));
        Assert.Null(parameters.CompanyID);
        Assert.False(parameters.RawBodyData.ContainsKey("company_id"));
        Assert.Null(parameters.CompanyName);
        Assert.False(parameters.RawBodyData.ContainsKey("company_name"));
        Assert.Null(parameters.ReceiverIDNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("receiver_id_number"));
        Assert.Null(parameters.ReceiverName);
        Assert.False(parameters.RawBodyData.ContainsKey("receiver_name"));
        Assert.Null(parameters.ResolveAt);
        Assert.False(parameters.RawBodyData.ContainsKey("resolve_at"));
        Assert.Null(parameters.StandardEntryClassCode);
        Assert.False(parameters.RawBodyData.ContainsKey("standard_entry_class_code"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundAchTransferCreateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/inbound_ach_transfers"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundAchTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            Addenda = new()
            {
                Category = Category.Freeform,
                Freeform = new([new("payment_related_information")]),
            },
            CompanyDescriptiveDate = "J!",
            CompanyDiscretionaryData = "J!",
            CompanyEntryDescription = "J!",
            CompanyID = "company_id",
            CompanyName = "company_name",
            ReceiverIDNumber = "x",
            ReceiverName = "x",
            ResolveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StandardEntryClassCode = StandardEntryClassCode.CorporateCreditOrDebit,
        };

        InboundAchTransferCreateParams copied = new(parameters);

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
            Freeform = new([new("payment_related_information")]),
        };

        ApiEnum<string, Category> expectedCategory = Category.Freeform;
        Freeform expectedFreeform = new([new("payment_related_information")]);

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedFreeform, model.Freeform);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,
            Freeform = new([new("payment_related_information")]),
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
            Freeform = new([new("payment_related_information")]),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Addenda>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Category> expectedCategory = Category.Freeform;
        Freeform expectedFreeform = new([new("payment_related_information")]);

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedFreeform, deserialized.Freeform);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Addenda { Category = Category.Freeform };

        Assert.Null(model.Freeform);
        Assert.False(model.RawData.ContainsKey("freeform"));
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
        };

        Assert.Null(model.Freeform);
        Assert.False(model.RawData.ContainsKey("freeform"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,

            // Null should be interpreted as omitted for these properties
            Freeform = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Addenda
        {
            Category = Category.Freeform,
            Freeform = new([new("payment_related_information")]),
        };

        Addenda copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Freeform)]
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
        var model = new Freeform { Entries = [new("payment_related_information")] };

        List<Entry> expectedEntries = [new("payment_related_information")];

        Assert.Equal(expectedEntries.Count, model.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], model.Entries[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Freeform { Entries = [new("payment_related_information")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Freeform>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Freeform { Entries = [new("payment_related_information")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Freeform>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Entry> expectedEntries = [new("payment_related_information")];

        Assert.Equal(expectedEntries.Count, deserialized.Entries.Count);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i], deserialized.Entries[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Freeform { Entries = [new("payment_related_information")] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Freeform { Entries = [new("payment_related_information")] };

        Freeform copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "payment_related_information" };

        string expectedPaymentRelatedInformation = "payment_related_information";

        Assert.Equal(expectedPaymentRelatedInformation, model.PaymentRelatedInformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "payment_related_information" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "payment_related_information" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Entry>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedPaymentRelatedInformation = "payment_related_information";

        Assert.Equal(expectedPaymentRelatedInformation, deserialized.PaymentRelatedInformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "payment_related_information" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Entry { PaymentRelatedInformation = "payment_related_information" };

        Entry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StandardEntryClassCodeTest : TestBase
{
    [Theory]
    [InlineData(StandardEntryClassCode.CorporateCreditOrDebit)]
    [InlineData(StandardEntryClassCode.CorporateTradeExchange)]
    [InlineData(StandardEntryClassCode.PrearrangedPaymentsAndDeposit)]
    [InlineData(StandardEntryClassCode.InternetInitiated)]
    [InlineData(StandardEntryClassCode.PointOfSale)]
    [InlineData(StandardEntryClassCode.TelephoneInitiated)]
    [InlineData(StandardEntryClassCode.CustomerInitiated)]
    [InlineData(StandardEntryClassCode.AccountsReceivable)]
    [InlineData(StandardEntryClassCode.MachineTransfer)]
    [InlineData(StandardEntryClassCode.SharedNetworkTransaction)]
    [InlineData(StandardEntryClassCode.RepresentedCheck)]
    [InlineData(StandardEntryClassCode.BackOfficeConversion)]
    [InlineData(StandardEntryClassCode.PointOfPurchase)]
    [InlineData(StandardEntryClassCode.CheckTruncation)]
    [InlineData(StandardEntryClassCode.DestroyedCheck)]
    [InlineData(StandardEntryClassCode.InternationalAchTransaction)]
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
    [InlineData(StandardEntryClassCode.PointOfSale)]
    [InlineData(StandardEntryClassCode.TelephoneInitiated)]
    [InlineData(StandardEntryClassCode.CustomerInitiated)]
    [InlineData(StandardEntryClassCode.AccountsReceivable)]
    [InlineData(StandardEntryClassCode.MachineTransfer)]
    [InlineData(StandardEntryClassCode.SharedNetworkTransaction)]
    [InlineData(StandardEntryClassCode.RepresentedCheck)]
    [InlineData(StandardEntryClassCode.BackOfficeConversion)]
    [InlineData(StandardEntryClassCode.PointOfPurchase)]
    [InlineData(StandardEntryClassCode.CheckTruncation)]
    [InlineData(StandardEntryClassCode.DestroyedCheck)]
    [InlineData(StandardEntryClassCode.InternationalAchTransaction)]
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
