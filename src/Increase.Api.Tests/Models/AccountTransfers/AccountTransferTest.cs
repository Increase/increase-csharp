using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using AccountTransfers = Increase.Api.Models.AccountTransfers;

namespace Increase.Api.Tests.Models.AccountTransfers;

public class AccountTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountTransfers::AccountTransfer
        {
            ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AccountTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AccountTransfers::Currency.Usd,
            Description = "Move money into savings",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
            DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
            IdempotencyKey = null,
            PendingTransactionID = null,
            Status = AccountTransfers::Status.Complete,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AccountTransfers::Type.AccountTransfer,
        };

        string expectedID = "account_transfer_7k9qe1ysdgqztnt63l7n";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 100;
        AccountTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        AccountTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        AccountTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = AccountTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        ApiEnum<string, AccountTransfers::Currency> expectedCurrency =
            AccountTransfers::Currency.Usd;
        string expectedDescription = "Move money into savings";
        string expectedDestinationAccountID = "account_uf16sut2ct5bevmq3eh";
        string expectedDestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4";
        ApiEnum<string, AccountTransfers::Status> expectedStatus =
            AccountTransfers::Status.Complete;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, AccountTransfers::Type> expectedType =
            AccountTransfers::Type.AccountTransfer;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedCancellation, model.Cancellation);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDestinationAccountID, model.DestinationAccountID);
        Assert.Equal(expectedDestinationTransactionID, model.DestinationTransactionID);
        Assert.Null(model.IdempotencyKey);
        Assert.Null(model.PendingTransactionID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountTransfers::AccountTransfer
        {
            ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AccountTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AccountTransfers::Currency.Usd,
            Description = "Move money into savings",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
            DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
            IdempotencyKey = null,
            PendingTransactionID = null,
            Status = AccountTransfers::Status.Complete,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AccountTransfers::Type.AccountTransfer,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::AccountTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransfers::AccountTransfer
        {
            ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AccountTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AccountTransfers::Currency.Usd,
            Description = "Move money into savings",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
            DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
            IdempotencyKey = null,
            PendingTransactionID = null,
            Status = AccountTransfers::Status.Complete,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AccountTransfers::Type.AccountTransfer,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::AccountTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "account_transfer_7k9qe1ysdgqztnt63l7n";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 100;
        AccountTransfers::Approval expectedApproval = new()
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };
        AccountTransfers::Cancellation expectedCancellation = new()
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        AccountTransfers::CreatedBy expectedCreatedBy = new()
        {
            Category = AccountTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };
        ApiEnum<string, AccountTransfers::Currency> expectedCurrency =
            AccountTransfers::Currency.Usd;
        string expectedDescription = "Move money into savings";
        string expectedDestinationAccountID = "account_uf16sut2ct5bevmq3eh";
        string expectedDestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4";
        ApiEnum<string, AccountTransfers::Status> expectedStatus =
            AccountTransfers::Status.Complete;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, AccountTransfers::Type> expectedType =
            AccountTransfers::Type.AccountTransfer;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(expectedCancellation, deserialized.Cancellation);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDestinationAccountID, deserialized.DestinationAccountID);
        Assert.Equal(expectedDestinationTransactionID, deserialized.DestinationTransactionID);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Null(deserialized.PendingTransactionID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountTransfers::AccountTransfer
        {
            ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AccountTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AccountTransfers::Currency.Usd,
            Description = "Move money into savings",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
            DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
            IdempotencyKey = null,
            PendingTransactionID = null,
            Status = AccountTransfers::Status.Complete,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AccountTransfers::Type.AccountTransfer,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransfers::AccountTransfer
        {
            ID = "account_transfer_7k9qe1ysdgqztnt63l7n",
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 100,
            Approval = new()
            {
                ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                ApprovedBy = null,
            },
            Cancellation = new()
            {
                CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CanceledBy = null,
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreatedBy = new()
            {
                Category = AccountTransfers::Category.User,
                ApiKey = new("description"),
                OAuthApplication = new("name"),
                User = new("user@example.com"),
            },
            Currency = AccountTransfers::Currency.Usd,
            Description = "Move money into savings",
            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
            DestinationTransactionID = "transaction_j3itv8dtk5o8pw3p1xj4",
            IdempotencyKey = null,
            PendingTransactionID = null,
            Status = AccountTransfers::Status.Complete,
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
            Type = AccountTransfers::Type.AccountTransfer,
        };

        AccountTransfers::AccountTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedApprovedAt, model.ApprovedAt);
        Assert.Null(model.ApprovedBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::Approval>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::Approval>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedApprovedAt, deserialized.ApprovedAt);
        Assert.Null(deserialized.ApprovedBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransfers::Approval
        {
            ApprovedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            ApprovedBy = null,
        };

        AccountTransfers::Approval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CancellationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedCanceledAt, model.CanceledAt);
        Assert.Null(model.CanceledBy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::Cancellation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::Cancellation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");

        Assert.Equal(expectedCanceledAt, deserialized.CanceledAt);
        Assert.Null(deserialized.CanceledBy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransfers::Cancellation
        {
            CanceledAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CanceledBy = null,
        };

        AccountTransfers::Cancellation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreatedByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountTransfers::CreatedBy
        {
            Category = AccountTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        ApiEnum<string, AccountTransfers::Category> expectedCategory =
            AccountTransfers::Category.User;
        AccountTransfers::ApiKey expectedApiKey = new("description");
        AccountTransfers::OAuthApplication expectedOAuthApplication = new("name");
        AccountTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedOAuthApplication, model.OAuthApplication);
        Assert.Equal(expectedUser, model.User);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountTransfers::CreatedBy
        {
            Category = AccountTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::CreatedBy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransfers::CreatedBy
        {
            Category = AccountTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::CreatedBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccountTransfers::Category> expectedCategory =
            AccountTransfers::Category.User;
        AccountTransfers::ApiKey expectedApiKey = new("description");
        AccountTransfers::OAuthApplication expectedOAuthApplication = new("name");
        AccountTransfers::User expectedUser = new("user@example.com");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedOAuthApplication, deserialized.OAuthApplication);
        Assert.Equal(expectedUser, deserialized.User);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountTransfers::CreatedBy
        {
            Category = AccountTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountTransfers::CreatedBy { Category = AccountTransfers::Category.User };

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
        var model = new AccountTransfers::CreatedBy { Category = AccountTransfers::Category.User };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AccountTransfers::CreatedBy
        {
            Category = AccountTransfers::Category.User,

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
        var model = new AccountTransfers::CreatedBy
        {
            Category = AccountTransfers::Category.User,

            ApiKey = null,
            OAuthApplication = null,
            User = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransfers::CreatedBy
        {
            Category = AccountTransfers::Category.User,
            ApiKey = new("description"),
            OAuthApplication = new("name"),
            User = new("user@example.com"),
        };

        AccountTransfers::CreatedBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(AccountTransfers::Category.ApiKey)]
    [InlineData(AccountTransfers::Category.OAuthApplication)]
    [InlineData(AccountTransfers::Category.User)]
    public void Validation_Works(AccountTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransfers::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountTransfers::Category.ApiKey)]
    [InlineData(AccountTransfers::Category.OAuthApplication)]
    [InlineData(AccountTransfers::Category.User)]
    public void SerializationRoundtrip_Works(AccountTransfers::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransfers::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Category>>(
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
        var model = new AccountTransfers::ApiKey { Description = "description" };

        string expectedDescription = "description";

        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountTransfers::ApiKey { Description = "description" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransfers::ApiKey { Description = "description" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::ApiKey>(
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
        var model = new AccountTransfers::ApiKey { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransfers::ApiKey { Description = "description" };

        AccountTransfers::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountTransfers::OAuthApplication { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountTransfers::OAuthApplication { Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransfers::OAuthApplication { Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::OAuthApplication>(
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
        var model = new AccountTransfers::OAuthApplication { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransfers::OAuthApplication { Name = "name" };

        AccountTransfers::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountTransfers::User { Email = "email" };

        string expectedEmail = "email";

        Assert.Equal(expectedEmail, model.Email);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountTransfers::User { Email = "email" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::User>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountTransfers::User { Email = "email" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountTransfers::User>(
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
        var model = new AccountTransfers::User { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountTransfers::User { Email = "email" };

        AccountTransfers::User copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(AccountTransfers::Currency.Usd)]
    public void Validation_Works(AccountTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransfers::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountTransfers::Currency.Usd)]
    public void SerializationRoundtrip_Works(AccountTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransfers::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(AccountTransfers::Status.PendingApproval)]
    [InlineData(AccountTransfers::Status.Canceled)]
    [InlineData(AccountTransfers::Status.Complete)]
    public void Validation_Works(AccountTransfers::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransfers::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountTransfers::Status.PendingApproval)]
    [InlineData(AccountTransfers::Status.Canceled)]
    [InlineData(AccountTransfers::Status.Complete)]
    public void SerializationRoundtrip_Works(AccountTransfers::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransfers::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(AccountTransfers::Type.AccountTransfer)]
    public void Validation_Works(AccountTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountTransfers::Type.AccountTransfer)]
    public void SerializationRoundtrip_Works(AccountTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AccountTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
