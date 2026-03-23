using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using SwiftTransfers = Increase.Api.Models.SwiftTransfers;

namespace Increase.Api.Tests.Models.SwiftTransfers;

public class SwiftTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwiftTransfers::SwiftTransfer
        {
            ID = "swift_transfer_29h21xkng03788zwd3fh",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            BankIdentificationCode = "ECBFDEFFTPP",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = SwiftTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = null,
                PostalCode = "60314",
                State = null,
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = null,
            },
            DebtorName = "National Phonograph Company",
            IdempotencyKey = null,
            InstructedAmount = 100,
            InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            RoutingNumber = null,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = SwiftTransfers::SwiftTransferStatus.Initiated,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = SwiftTransfers::Type.SwiftTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Remittance information",
        };

        string expectedID = "swift_transfer_29h21xkng03788zwd3fh";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        long expectedAmount = 100;
        string expectedBankIdentificationCode = "ECBFDEFFTPP";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        SwiftTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = SwiftTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        SwiftTransfers::SwiftTransferCreditorAddress expectedCreditorAddress = new()
        {
            City = "Frankfurt",
            Country = "DE",
            Line1 = "Sonnemannstrasse 20",
            Line2 = null,
            PostalCode = "60314",
            State = null,
        };
        string expectedCreditorName = "Ian Crease";
        SwiftTransfers::SwiftTransferDebtorAddress expectedDebtorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = null,
        };
        string expectedDebtorName = "National Phonograph Company";
        long expectedInstructedAmount = 100;
        ApiEnum<
            string,
            SwiftTransfers::SwiftTransferInstructedCurrency
        > expectedInstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd;
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, SwiftTransfers::SwiftTransferStatus> expectedStatus =
            SwiftTransfers::SwiftTransferStatus.Initiated;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, SwiftTransfers::Type> expectedType = SwiftTransfers::Type.SwiftTransfer;
        string expectedUniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a";
        string expectedUnstructuredRemittanceInformation = "Remittance information";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedBankIdentificationCode, model.BankIdentificationCode);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedCreditorAddress, model.CreditorAddress);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedDebtorAddress, model.DebtorAddress);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedInstructedAmount, model.InstructedAmount);
        Assert.Equal(expectedInstructedCurrency, model.InstructedCurrency);
        Assert.Equal(expectedPendingTransactionID, model.PendingTransactionID);
        Assert.Null(model.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, model.SourceAccountNumberID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(
            expectedUniqueEndToEndTransactionReference,
            model.UniqueEndToEndTransactionReference
        );
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwiftTransfers::SwiftTransfer
        {
            ID = "swift_transfer_29h21xkng03788zwd3fh",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            BankIdentificationCode = "ECBFDEFFTPP",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = SwiftTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = null,
                PostalCode = "60314",
                State = null,
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = null,
            },
            DebtorName = "National Phonograph Company",
            IdempotencyKey = null,
            InstructedAmount = 100,
            InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            RoutingNumber = null,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = SwiftTransfers::SwiftTransferStatus.Initiated,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = SwiftTransfers::Type.SwiftTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Remittance information",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::SwiftTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwiftTransfers::SwiftTransfer
        {
            ID = "swift_transfer_29h21xkng03788zwd3fh",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            BankIdentificationCode = "ECBFDEFFTPP",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = SwiftTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = null,
                PostalCode = "60314",
                State = null,
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = null,
            },
            DebtorName = "National Phonograph Company",
            IdempotencyKey = null,
            InstructedAmount = 100,
            InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            RoutingNumber = null,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = SwiftTransfers::SwiftTransferStatus.Initiated,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = SwiftTransfers::Type.SwiftTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Remittance information",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::SwiftTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "swift_transfer_29h21xkng03788zwd3fh";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumber = "987654321";
        long expectedAmount = 100;
        string expectedBankIdentificationCode = "ECBFDEFFTPP";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        SwiftTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = SwiftTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        SwiftTransfers::SwiftTransferCreditorAddress expectedCreditorAddress = new()
        {
            City = "Frankfurt",
            Country = "DE",
            Line1 = "Sonnemannstrasse 20",
            Line2 = null,
            PostalCode = "60314",
            State = null,
        };
        string expectedCreditorName = "Ian Crease";
        SwiftTransfers::SwiftTransferDebtorAddress expectedDebtorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = null,
        };
        string expectedDebtorName = "National Phonograph Company";
        long expectedInstructedAmount = 100;
        ApiEnum<
            string,
            SwiftTransfers::SwiftTransferInstructedCurrency
        > expectedInstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd;
        string expectedPendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, SwiftTransfers::SwiftTransferStatus> expectedStatus =
            SwiftTransfers::SwiftTransferStatus.Initiated;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, SwiftTransfers::Type> expectedType = SwiftTransfers::Type.SwiftTransfer;
        string expectedUniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a";
        string expectedUnstructuredRemittanceInformation = "Remittance information";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedBankIdentificationCode, deserialized.BankIdentificationCode);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedCreditorAddress, deserialized.CreditorAddress);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedDebtorAddress, deserialized.DebtorAddress);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedInstructedAmount, deserialized.InstructedAmount);
        Assert.Equal(expectedInstructedCurrency, deserialized.InstructedCurrency);
        Assert.Equal(expectedPendingTransactionID, deserialized.PendingTransactionID);
        Assert.Null(deserialized.RoutingNumber);
        Assert.Equal(expectedSourceAccountNumberID, deserialized.SourceAccountNumberID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(
            expectedUniqueEndToEndTransactionReference,
            deserialized.UniqueEndToEndTransactionReference
        );
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwiftTransfers::SwiftTransfer
        {
            ID = "swift_transfer_29h21xkng03788zwd3fh",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            BankIdentificationCode = "ECBFDEFFTPP",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = SwiftTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = null,
                PostalCode = "60314",
                State = null,
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = null,
            },
            DebtorName = "National Phonograph Company",
            IdempotencyKey = null,
            InstructedAmount = 100,
            InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            RoutingNumber = null,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = SwiftTransfers::SwiftTransferStatus.Initiated,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = SwiftTransfers::Type.SwiftTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Remittance information",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SwiftTransfers::SwiftTransfer
        {
            ID = "swift_transfer_29h21xkng03788zwd3fh",
            AccountID = "account_in71c4amph0vgo2qllky",
            AccountNumber = "987654321",
            Amount = 100,
            BankIdentificationCode = "ECBFDEFFTPP",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = SwiftTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            CreditorAddress = new()
            {
                City = "Frankfurt",
                Country = "DE",
                Line1 = "Sonnemannstrasse 20",
                Line2 = null,
                PostalCode = "60314",
                State = null,
            },
            CreditorName = "Ian Crease",
            DebtorAddress = new()
            {
                City = "New York",
                Country = "US",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = null,
            },
            DebtorName = "National Phonograph Company",
            IdempotencyKey = null,
            InstructedAmount = 100,
            InstructedCurrency = SwiftTransfers::SwiftTransferInstructedCurrency.Usd,
            PendingTransactionID = "pending_transaction_k1sfetcau2qbvjbzgju4",
            RoutingNumber = null,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Status = SwiftTransfers::SwiftTransferStatus.Initiated,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = SwiftTransfers::Type.SwiftTransfer,
            UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
            UnstructuredRemittanceInformation = "Remittance information",
        };

        SwiftTransfers::SwiftTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwiftTransfers::CreatedBy
        {
            Category = SwiftTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, SwiftTransfers::Category> expectedCategory = SwiftTransfers::Category.User;
        SwiftTransfers::ApiKey expectedApiKey = new("description");
        SwiftTransfers::OAuthApplication expectedOAuthApplication = new("name");
        SwiftTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwiftTransfers::CreatedBy
        {
            Category = SwiftTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwiftTransfers::CreatedBy
        {
            Category = SwiftTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SwiftTransfers::Category> expectedCategory = SwiftTransfers::Category.User;
        SwiftTransfers::ApiKey expectedApiKey = new("description");
        SwiftTransfers::OAuthApplication expectedOAuthApplication = new("name");
        SwiftTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwiftTransfers::CreatedBy
        {
            Category = SwiftTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SwiftTransfers::CreatedBy { Category = SwiftTransfers::Category.User };

        Assert.Null(model.ApiKey);
        Assert.False(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.OAuthApplication);
        Assert.False(model.RawData.ContainsKey("oauth_application"));
        Assert.Null(model.User);
        Assert.False(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SwiftTransfers::CreatedBy { Category = SwiftTransfers::Category.User };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SwiftTransfers::CreatedBy
        {
            Category = SwiftTransfers::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        Assert.Null(model.ApiKey);
        Assert.True(model.RawData.ContainsKey("api_key"));
        Assert.Null(model.OAuthApplication);
        Assert.True(model.RawData.ContainsKey("oauth_application"));
        Assert.Null(model.User);
        Assert.True(model.RawData.ContainsKey("user"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SwiftTransfers::CreatedBy
        {
            Category = SwiftTransfers::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SwiftTransfers::CreatedBy
        {
            Category = SwiftTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        SwiftTransfers::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(SwiftTransfers::Category.ApiKey)]
    [InlineData(SwiftTransfers::Category.OAuthApplication)]
    [InlineData(SwiftTransfers::Category.User)]
    public void Validation_Works(SwiftTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwiftTransfers::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SwiftTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SwiftTransfers::Category.ApiKey)]
    [InlineData(SwiftTransfers::Category.OAuthApplication)]
    [InlineData(SwiftTransfers::Category.User)]
    public void SerializationRoundtrip_Works(SwiftTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwiftTransfers::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SwiftTransfers::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SwiftTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SwiftTransfers::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwiftTransfers::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwiftTransfers::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwiftTransfers::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::ApiKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwiftTransfers::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SwiftTransfers::ApiKey { Description = "description" };

        SwiftTransfers::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwiftTransfers::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwiftTransfers::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwiftTransfers::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::OAuthApplication>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwiftTransfers::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SwiftTransfers::OAuthApplication { Name = "name" };

        SwiftTransfers::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwiftTransfers::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwiftTransfers::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwiftTransfers::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::User>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, deserialized.Email);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwiftTransfers::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SwiftTransfers::User { Email = "email" };

        SwiftTransfers::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SwiftTransferCreditorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwiftTransfers::SwiftTransferCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwiftTransfers::SwiftTransferCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::SwiftTransferCreditorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwiftTransfers::SwiftTransferCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::SwiftTransferCreditorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwiftTransfers::SwiftTransferCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SwiftTransfers::SwiftTransferCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        SwiftTransfers::SwiftTransferCreditorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SwiftTransferDebtorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SwiftTransfers::SwiftTransferDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SwiftTransfers::SwiftTransferDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::SwiftTransferDebtorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SwiftTransfers::SwiftTransferDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SwiftTransfers::SwiftTransferDebtorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SwiftTransfers::SwiftTransferDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SwiftTransfers::SwiftTransferDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        SwiftTransfers::SwiftTransferDebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SwiftTransferInstructedCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SwiftTransfers::SwiftTransferInstructedCurrency.Usd)]
    public void Validation_Works(SwiftTransfers::SwiftTransferInstructedCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwiftTransfers::SwiftTransferInstructedCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SwiftTransfers::SwiftTransferInstructedCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SwiftTransfers::SwiftTransferInstructedCurrency.Usd)]
    public void SerializationRoundtrip_Works(
        SwiftTransfers::SwiftTransferInstructedCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwiftTransfers::SwiftTransferInstructedCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SwiftTransfers::SwiftTransferInstructedCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SwiftTransfers::SwiftTransferInstructedCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SwiftTransfers::SwiftTransferInstructedCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SwiftTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(SwiftTransfers::SwiftTransferStatus.PendingApproval)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.Canceled)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.PendingReviewing)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.RequiresAttention)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.PendingInitiating)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.Initiated)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.Rejected)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.Returned)]
    public void Validation_Works(SwiftTransfers::SwiftTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwiftTransfers::SwiftTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SwiftTransfers::SwiftTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SwiftTransfers::SwiftTransferStatus.PendingApproval)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.Canceled)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.PendingReviewing)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.RequiresAttention)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.PendingInitiating)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.Initiated)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.Rejected)]
    [InlineData(SwiftTransfers::SwiftTransferStatus.Returned)]
    public void SerializationRoundtrip_Works(SwiftTransfers::SwiftTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwiftTransfers::SwiftTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SwiftTransfers::SwiftTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SwiftTransfers::SwiftTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SwiftTransfers::SwiftTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(SwiftTransfers::Type.SwiftTransfer)]
    public void Validation_Works(SwiftTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwiftTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SwiftTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SwiftTransfers::Type.SwiftTransfer)]
    public void SerializationRoundtrip_Works(SwiftTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SwiftTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SwiftTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SwiftTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SwiftTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
