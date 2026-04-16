using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Events;

namespace Increase.Api.Tests.Models.Events;

public class EventListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventListParams
        {
            AssociatedObjectID = "associated_object_id",
            Category = new() { In = [In.AccountCreated] },
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Cursor = "cursor",
            Limit = 1,
            OrderBy = new() { Direction = Direction.Ascending, Field = Field.CreatedAt },
        };

        string expectedAssociatedObjectID = "associated_object_id";
        Category expectedCategory = new() { In = [In.AccountCreated] };
        CreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCursor = "cursor";
        long expectedLimit = 1;
        OrderBy expectedOrderBy = new()
        {
            Direction = Direction.Ascending,
            Field = Field.CreatedAt,
        };

        Assert.Equal(expectedAssociatedObjectID, parameters.AssociatedObjectID);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedCreatedAt, parameters.CreatedAt);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventListParams { };

        Assert.Null(parameters.AssociatedObjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("associated_object_id"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventListParams
        {
            // Null should be interpreted as omitted for these properties
            AssociatedObjectID = null,
            Category = null,
            CreatedAt = null,
            Cursor = null,
            Limit = null,
            OrderBy = null,
        };

        Assert.Null(parameters.AssociatedObjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("associated_object_id"));
        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
    }

    [Fact]
    public void Url_Works()
    {
        EventListParams parameters = new()
        {
            AssociatedObjectID = "associated_object_id",
            Category = new() { In = [In.AccountCreated] },
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            },
            Cursor = "cursor",
            Limit = 1,
            OrderBy = new() { Direction = Direction.Ascending, Field = Field.CreatedAt },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/events?associated_object_id=associated_object_id&category.in=account.created&created_at.after=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at.before=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at.on_or_after=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at.on_or_before=2019-12-27T18%3a11%3a19.117%2b00%3a00&cursor=cursor&limit=1&order_by.direction=ascending&order_by.field=created_at"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EventListParams
        {
            AssociatedObjectID = "associated_object_id",
            Category = new() { In = [In.AccountCreated] },
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Cursor = "cursor",
            Limit = 1,
            OrderBy = new() { Direction = Direction.Ascending, Field = Field.CreatedAt },
        };

        EventListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Category { In = [In.AccountCreated] };

        List<ApiEnum<string, In>> expectedIn = [In.AccountCreated];

        Assert.NotNull(model.In);
        Assert.Equal(expectedIn.Count, model.In.Count);
        for (int i = 0; i < expectedIn.Count; i++)
        {
            Assert.Equal(expectedIn[i], model.In[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Category { In = [In.AccountCreated] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Category>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Category { In = [In.AccountCreated] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Category>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, In>> expectedIn = [In.AccountCreated];

        Assert.NotNull(deserialized.In);
        Assert.Equal(expectedIn.Count, deserialized.In.Count);
        for (int i = 0; i < expectedIn.Count; i++)
        {
            Assert.Equal(expectedIn[i], deserialized.In[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Category { In = [In.AccountCreated] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Category { };

        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Category { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Category
        {
            // Null should be interpreted as omitted for these properties
            In = null,
        };

        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Category
        {
            // Null should be interpreted as omitted for these properties
            In = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Category { In = [In.AccountCreated] };

        Category copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InTest : TestBase
{
    [Theory]
    [InlineData(In.AccountCreated)]
    [InlineData(In.AccountUpdated)]
    [InlineData(In.AccountNumberCreated)]
    [InlineData(In.AccountNumberUpdated)]
    [InlineData(In.AccountStatementCreated)]
    [InlineData(In.AccountTransferCreated)]
    [InlineData(In.AccountTransferUpdated)]
    [InlineData(In.AchPrenotificationCreated)]
    [InlineData(In.AchPrenotificationUpdated)]
    [InlineData(In.AchTransferCreated)]
    [InlineData(In.AchTransferUpdated)]
    [InlineData(In.BlockchainAddressCreated)]
    [InlineData(In.BlockchainAddressUpdated)]
    [InlineData(In.BlockchainOfframpTransferCreated)]
    [InlineData(In.BlockchainOfframpTransferUpdated)]
    [InlineData(In.BlockchainOnrampTransferCreated)]
    [InlineData(In.BlockchainOnrampTransferUpdated)]
    [InlineData(In.BookkeepingAccountCreated)]
    [InlineData(In.BookkeepingAccountUpdated)]
    [InlineData(In.BookkeepingEntrySetUpdated)]
    [InlineData(In.CardCreated)]
    [InlineData(In.CardUpdated)]
    [InlineData(In.CardPaymentCreated)]
    [InlineData(In.CardPaymentUpdated)]
    [InlineData(In.CardPurchaseSupplementCreated)]
    [InlineData(In.CardProfileCreated)]
    [InlineData(In.CardProfileUpdated)]
    [InlineData(In.CardDisputeCreated)]
    [InlineData(In.CardDisputeUpdated)]
    [InlineData(In.CheckDepositCreated)]
    [InlineData(In.CheckDepositUpdated)]
    [InlineData(In.CheckTransferCreated)]
    [InlineData(In.CheckTransferUpdated)]
    [InlineData(In.DeclinedTransactionCreated)]
    [InlineData(In.DigitalCardProfileCreated)]
    [InlineData(In.DigitalCardProfileUpdated)]
    [InlineData(In.DigitalWalletTokenCreated)]
    [InlineData(In.DigitalWalletTokenUpdated)]
    [InlineData(In.DocumentCreated)]
    [InlineData(In.EntityCreated)]
    [InlineData(In.EntityUpdated)]
    [InlineData(In.EventSubscriptionCreated)]
    [InlineData(In.EventSubscriptionUpdated)]
    [InlineData(In.ExportCreated)]
    [InlineData(In.ExportUpdated)]
    [InlineData(In.ExternalAccountCreated)]
    [InlineData(In.ExternalAccountUpdated)]
    [InlineData(In.FednowTransferCreated)]
    [InlineData(In.FednowTransferUpdated)]
    [InlineData(In.FileCreated)]
    [InlineData(In.GroupUpdated)]
    [InlineData(In.GroupHeartbeat)]
    [InlineData(In.InboundAchTransferCreated)]
    [InlineData(In.InboundAchTransferUpdated)]
    [InlineData(In.InboundAchTransferReturnCreated)]
    [InlineData(In.InboundAchTransferReturnUpdated)]
    [InlineData(In.InboundCheckDepositCreated)]
    [InlineData(In.InboundCheckDepositUpdated)]
    [InlineData(In.InboundFednowTransferCreated)]
    [InlineData(In.InboundFednowTransferUpdated)]
    [InlineData(In.InboundMailItemCreated)]
    [InlineData(In.InboundMailItemUpdated)]
    [InlineData(In.InboundRealTimePaymentsTransferCreated)]
    [InlineData(In.InboundRealTimePaymentsTransferUpdated)]
    [InlineData(In.InboundWireDrawdownRequestCreated)]
    [InlineData(In.InboundWireTransferCreated)]
    [InlineData(In.InboundWireTransferUpdated)]
    [InlineData(In.IntrafiAccountEnrollmentCreated)]
    [InlineData(In.IntrafiAccountEnrollmentUpdated)]
    [InlineData(In.IntrafiExclusionCreated)]
    [InlineData(In.IntrafiExclusionUpdated)]
    [InlineData(In.LegacyCardDisputeCreated)]
    [InlineData(In.LegacyCardDisputeUpdated)]
    [InlineData(In.LockboxCreated)]
    [InlineData(In.LockboxUpdated)]
    [InlineData(In.OAuthConnectionCreated)]
    [InlineData(In.OAuthConnectionDeactivated)]
    [InlineData(In.CardPushTransferCreated)]
    [InlineData(In.CardPushTransferUpdated)]
    [InlineData(In.CardValidationCreated)]
    [InlineData(In.CardValidationUpdated)]
    [InlineData(In.PendingTransactionCreated)]
    [InlineData(In.PendingTransactionUpdated)]
    [InlineData(In.PhysicalCardCreated)]
    [InlineData(In.PhysicalCardUpdated)]
    [InlineData(In.PhysicalCardProfileCreated)]
    [InlineData(In.PhysicalCardProfileUpdated)]
    [InlineData(In.PhysicalCheckCreated)]
    [InlineData(In.PhysicalCheckUpdated)]
    [InlineData(In.ProgramCreated)]
    [InlineData(In.ProgramUpdated)]
    [InlineData(In.ProofOfAuthorizationRequestCreated)]
    [InlineData(In.ProofOfAuthorizationRequestUpdated)]
    [InlineData(In.RealTimeDecisionCardAuthorizationRequested)]
    [InlineData(In.RealTimeDecisionCardBalanceInquiryRequested)]
    [InlineData(In.RealTimeDecisionDigitalWalletTokenRequested)]
    [InlineData(In.RealTimeDecisionDigitalWalletAuthenticationRequested)]
    [InlineData(In.RealTimeDecisionCardAuthenticationRequested)]
    [InlineData(In.RealTimeDecisionCardAuthenticationChallengeRequested)]
    [InlineData(In.RealTimePaymentsTransferCreated)]
    [InlineData(In.RealTimePaymentsTransferUpdated)]
    [InlineData(In.RealTimePaymentsRequestForPaymentCreated)]
    [InlineData(In.RealTimePaymentsRequestForPaymentUpdated)]
    [InlineData(In.SwiftTransferCreated)]
    [InlineData(In.SwiftTransferUpdated)]
    [InlineData(In.TransactionCreated)]
    [InlineData(In.WireDrawdownRequestCreated)]
    [InlineData(In.WireDrawdownRequestUpdated)]
    [InlineData(In.WireTransferCreated)]
    [InlineData(In.WireTransferUpdated)]
    public void Validation_Works(In rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, In> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(In.AccountCreated)]
    [InlineData(In.AccountUpdated)]
    [InlineData(In.AccountNumberCreated)]
    [InlineData(In.AccountNumberUpdated)]
    [InlineData(In.AccountStatementCreated)]
    [InlineData(In.AccountTransferCreated)]
    [InlineData(In.AccountTransferUpdated)]
    [InlineData(In.AchPrenotificationCreated)]
    [InlineData(In.AchPrenotificationUpdated)]
    [InlineData(In.AchTransferCreated)]
    [InlineData(In.AchTransferUpdated)]
    [InlineData(In.BlockchainAddressCreated)]
    [InlineData(In.BlockchainAddressUpdated)]
    [InlineData(In.BlockchainOfframpTransferCreated)]
    [InlineData(In.BlockchainOfframpTransferUpdated)]
    [InlineData(In.BlockchainOnrampTransferCreated)]
    [InlineData(In.BlockchainOnrampTransferUpdated)]
    [InlineData(In.BookkeepingAccountCreated)]
    [InlineData(In.BookkeepingAccountUpdated)]
    [InlineData(In.BookkeepingEntrySetUpdated)]
    [InlineData(In.CardCreated)]
    [InlineData(In.CardUpdated)]
    [InlineData(In.CardPaymentCreated)]
    [InlineData(In.CardPaymentUpdated)]
    [InlineData(In.CardPurchaseSupplementCreated)]
    [InlineData(In.CardProfileCreated)]
    [InlineData(In.CardProfileUpdated)]
    [InlineData(In.CardDisputeCreated)]
    [InlineData(In.CardDisputeUpdated)]
    [InlineData(In.CheckDepositCreated)]
    [InlineData(In.CheckDepositUpdated)]
    [InlineData(In.CheckTransferCreated)]
    [InlineData(In.CheckTransferUpdated)]
    [InlineData(In.DeclinedTransactionCreated)]
    [InlineData(In.DigitalCardProfileCreated)]
    [InlineData(In.DigitalCardProfileUpdated)]
    [InlineData(In.DigitalWalletTokenCreated)]
    [InlineData(In.DigitalWalletTokenUpdated)]
    [InlineData(In.DocumentCreated)]
    [InlineData(In.EntityCreated)]
    [InlineData(In.EntityUpdated)]
    [InlineData(In.EventSubscriptionCreated)]
    [InlineData(In.EventSubscriptionUpdated)]
    [InlineData(In.ExportCreated)]
    [InlineData(In.ExportUpdated)]
    [InlineData(In.ExternalAccountCreated)]
    [InlineData(In.ExternalAccountUpdated)]
    [InlineData(In.FednowTransferCreated)]
    [InlineData(In.FednowTransferUpdated)]
    [InlineData(In.FileCreated)]
    [InlineData(In.GroupUpdated)]
    [InlineData(In.GroupHeartbeat)]
    [InlineData(In.InboundAchTransferCreated)]
    [InlineData(In.InboundAchTransferUpdated)]
    [InlineData(In.InboundAchTransferReturnCreated)]
    [InlineData(In.InboundAchTransferReturnUpdated)]
    [InlineData(In.InboundCheckDepositCreated)]
    [InlineData(In.InboundCheckDepositUpdated)]
    [InlineData(In.InboundFednowTransferCreated)]
    [InlineData(In.InboundFednowTransferUpdated)]
    [InlineData(In.InboundMailItemCreated)]
    [InlineData(In.InboundMailItemUpdated)]
    [InlineData(In.InboundRealTimePaymentsTransferCreated)]
    [InlineData(In.InboundRealTimePaymentsTransferUpdated)]
    [InlineData(In.InboundWireDrawdownRequestCreated)]
    [InlineData(In.InboundWireTransferCreated)]
    [InlineData(In.InboundWireTransferUpdated)]
    [InlineData(In.IntrafiAccountEnrollmentCreated)]
    [InlineData(In.IntrafiAccountEnrollmentUpdated)]
    [InlineData(In.IntrafiExclusionCreated)]
    [InlineData(In.IntrafiExclusionUpdated)]
    [InlineData(In.LegacyCardDisputeCreated)]
    [InlineData(In.LegacyCardDisputeUpdated)]
    [InlineData(In.LockboxCreated)]
    [InlineData(In.LockboxUpdated)]
    [InlineData(In.OAuthConnectionCreated)]
    [InlineData(In.OAuthConnectionDeactivated)]
    [InlineData(In.CardPushTransferCreated)]
    [InlineData(In.CardPushTransferUpdated)]
    [InlineData(In.CardValidationCreated)]
    [InlineData(In.CardValidationUpdated)]
    [InlineData(In.PendingTransactionCreated)]
    [InlineData(In.PendingTransactionUpdated)]
    [InlineData(In.PhysicalCardCreated)]
    [InlineData(In.PhysicalCardUpdated)]
    [InlineData(In.PhysicalCardProfileCreated)]
    [InlineData(In.PhysicalCardProfileUpdated)]
    [InlineData(In.PhysicalCheckCreated)]
    [InlineData(In.PhysicalCheckUpdated)]
    [InlineData(In.ProgramCreated)]
    [InlineData(In.ProgramUpdated)]
    [InlineData(In.ProofOfAuthorizationRequestCreated)]
    [InlineData(In.ProofOfAuthorizationRequestUpdated)]
    [InlineData(In.RealTimeDecisionCardAuthorizationRequested)]
    [InlineData(In.RealTimeDecisionCardBalanceInquiryRequested)]
    [InlineData(In.RealTimeDecisionDigitalWalletTokenRequested)]
    [InlineData(In.RealTimeDecisionDigitalWalletAuthenticationRequested)]
    [InlineData(In.RealTimeDecisionCardAuthenticationRequested)]
    [InlineData(In.RealTimeDecisionCardAuthenticationChallengeRequested)]
    [InlineData(In.RealTimePaymentsTransferCreated)]
    [InlineData(In.RealTimePaymentsTransferUpdated)]
    [InlineData(In.RealTimePaymentsRequestForPaymentCreated)]
    [InlineData(In.RealTimePaymentsRequestForPaymentUpdated)]
    [InlineData(In.SwiftTransferCreated)]
    [InlineData(In.SwiftTransferUpdated)]
    [InlineData(In.TransactionCreated)]
    [InlineData(In.WireDrawdownRequestCreated)]
    [InlineData(In.WireDrawdownRequestUpdated)]
    [InlineData(In.WireTransferCreated)]
    [InlineData(In.WireTransferUpdated)]
    public void SerializationRoundtrip_Works(In rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, In> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
        Assert.Equal(expectedOnOrAfter, model.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, model.OnOrBefore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
        Assert.Equal(expectedOnOrAfter, deserialized.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, deserialized.OnOrBefore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreatedAt { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OrderByTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OrderBy { Direction = Direction.Ascending, Field = Field.CreatedAt };

        ApiEnum<string, Direction> expectedDirection = Direction.Ascending;
        ApiEnum<string, Field> expectedField = Field.CreatedAt;

        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedField, model.Field);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OrderBy { Direction = Direction.Ascending, Field = Field.CreatedAt };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrderBy>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OrderBy { Direction = Direction.Ascending, Field = Field.CreatedAt };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrderBy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Direction> expectedDirection = Direction.Ascending;
        ApiEnum<string, Field> expectedField = Field.CreatedAt;

        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedField, deserialized.Field);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OrderBy { Direction = Direction.Ascending, Field = Field.CreatedAt };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OrderBy { };

        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OrderBy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OrderBy
        {
            // Null should be interpreted as omitted for these properties
            Direction = null,
            Field = null,
        };

        Assert.Null(model.Direction);
        Assert.False(model.RawData.ContainsKey("direction"));
        Assert.Null(model.Field);
        Assert.False(model.RawData.ContainsKey("field"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OrderBy
        {
            // Null should be interpreted as omitted for these properties
            Direction = null,
            Field = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OrderBy { Direction = Direction.Ascending, Field = Field.CreatedAt };

        OrderBy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DirectionTest : TestBase
{
    [Theory]
    [InlineData(Direction.Ascending)]
    [InlineData(Direction.Descending)]
    public void Validation_Works(Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Direction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Direction.Ascending)]
    [InlineData(Direction.Descending)]
    public void SerializationRoundtrip_Works(Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Direction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Direction>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FieldTest : TestBase
{
    [Theory]
    [InlineData(Field.CreatedAt)]
    public void Validation_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Field.CreatedAt)]
    public void SerializationRoundtrip_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
