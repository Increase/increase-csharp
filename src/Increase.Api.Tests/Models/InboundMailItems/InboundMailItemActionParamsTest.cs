using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundMailItems = Increase.Api.Models.InboundMailItems;

namespace Increase.Api.Tests.Models.InboundMailItems;

public class InboundMailItemActionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundMailItems::InboundMailItemActionParams
        {
            InboundMailItemID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
            Checks =
            [
                new()
                {
                    Action = InboundMailItems::Action.Deposit,
                    AccountID = "account_in71c4amph0vgo2qllky",
                },
                new() { Action = InboundMailItems::Action.Ignore, AccountID = "account_id" },
            ],
        };

        string expectedInboundMailItemID = "inbound_mail_item_q6rrg7mmqpplx80zceev";
        List<InboundMailItems::Check> expectedChecks =
        [
            new()
            {
                Action = InboundMailItems::Action.Deposit,
                AccountID = "account_in71c4amph0vgo2qllky",
            },
            new() { Action = InboundMailItems::Action.Ignore, AccountID = "account_id" },
        ];

        Assert.Equal(expectedInboundMailItemID, parameters.InboundMailItemID);
        Assert.Equal(expectedChecks.Count, parameters.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], parameters.Checks[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        InboundMailItems::InboundMailItemActionParams parameters = new()
        {
            InboundMailItemID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
            Checks =
            [
                new()
                {
                    Action = InboundMailItems::Action.Deposit,
                    AccountID = "account_in71c4amph0vgo2qllky",
                },
                new() { Action = InboundMailItems::Action.Ignore, AccountID = "account_id" },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/inbound_mail_items/inbound_mail_item_q6rrg7mmqpplx80zceev/action"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundMailItems::InboundMailItemActionParams
        {
            InboundMailItemID = "inbound_mail_item_q6rrg7mmqpplx80zceev",
            Checks =
            [
                new()
                {
                    Action = InboundMailItems::Action.Deposit,
                    AccountID = "account_in71c4amph0vgo2qllky",
                },
                new() { Action = InboundMailItems::Action.Ignore, AccountID = "account_id" },
            ],
        };

        InboundMailItems::InboundMailItemActionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundMailItems::Check
        {
            Action = InboundMailItems::Action.Deposit,
            AccountID = "account_id",
        };

        ApiEnum<string, InboundMailItems::Action> expectedAction = InboundMailItems::Action.Deposit;
        string expectedAccountID = "account_id";

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedAccountID, model.AccountID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundMailItems::Check
        {
            Action = InboundMailItems::Action.Deposit,
            AccountID = "account_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMailItems::Check>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundMailItems::Check
        {
            Action = InboundMailItems::Action.Deposit,
            AccountID = "account_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundMailItems::Check>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InboundMailItems::Action> expectedAction = InboundMailItems::Action.Deposit;
        string expectedAccountID = "account_id";

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundMailItems::Check
        {
            Action = InboundMailItems::Action.Deposit,
            AccountID = "account_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundMailItems::Check { Action = InboundMailItems::Action.Deposit };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundMailItems::Check { Action = InboundMailItems::Action.Deposit };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InboundMailItems::Check
        {
            Action = InboundMailItems::Action.Deposit,

            // Null should be interpreted as omitted for these properties
            AccountID = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundMailItems::Check
        {
            Action = InboundMailItems::Action.Deposit,

            // Null should be interpreted as omitted for these properties
            AccountID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundMailItems::Check
        {
            Action = InboundMailItems::Action.Deposit,
            AccountID = "account_id",
        };

        InboundMailItems::Check copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(InboundMailItems::Action.Deposit)]
    [InlineData(InboundMailItems::Action.Ignore)]
    public void Validation_Works(InboundMailItems::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundMailItems::Action.Deposit)]
    [InlineData(InboundMailItems::Action.Ignore)]
    public void SerializationRoundtrip_Works(InboundMailItems::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundMailItems::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundMailItems::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
