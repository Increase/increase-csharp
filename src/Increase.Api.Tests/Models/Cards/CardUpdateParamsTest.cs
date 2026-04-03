using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardUpdateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            AuthorizationControls = new()
            {
                MaximumAuthorizationCount = new(0),
                MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
                MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
                MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
                SpendingLimits =
                [
                    new()
                    {
                        Interval =
                            CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            BillingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
            },
            Description = "New description",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_id",
                Email = "dev@stainless.com",
                Phone = "x",
            },
            EntityID = "entity_id",
            Status = Status.Active,
        };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        CardUpdateParamsAuthorizationControls expectedAuthorizationControls = new()
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };
        CardUpdateParamsBillingAddress expectedBillingAddress = new()
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };
        string expectedDescription = "New description";
        CardUpdateParamsDigitalWallet expectedDigitalWallet = new()
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };
        string expectedEntityID = "entity_id";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedCardID, parameters.CardID);
        Assert.Equal(expectedAuthorizationControls, parameters.AuthorizationControls);
        Assert.Equal(expectedBillingAddress, parameters.BillingAddress);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDigitalWallet, parameters.DigitalWallet);
        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardUpdateParams { CardID = "card_oubs0hwk5rn6knuecxg2" };

        Assert.Null(parameters.AuthorizationControls);
        Assert.False(parameters.RawBodyData.ContainsKey("authorization_controls"));
        Assert.Null(parameters.BillingAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DigitalWallet);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_wallet"));
        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardUpdateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",

            // Null should be interpreted as omitted for these properties
            AuthorizationControls = null,
            BillingAddress = null,
            Description = null,
            DigitalWallet = null,
            EntityID = null,
            Status = null,
        };

        Assert.Null(parameters.AuthorizationControls);
        Assert.False(parameters.RawBodyData.ContainsKey("authorization_controls"));
        Assert.Null(parameters.BillingAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("billing_address"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.DigitalWallet);
        Assert.False(parameters.RawBodyData.ContainsKey("digital_wallet"));
        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawBodyData.ContainsKey("entity_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        CardUpdateParams parameters = new() { CardID = "card_oubs0hwk5rn6knuecxg2" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/cards/card_oubs0hwk5rn6knuecxg2"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardUpdateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            AuthorizationControls = new()
            {
                MaximumAuthorizationCount = new(0),
                MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
                MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
                MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
                SpendingLimits =
                [
                    new()
                    {
                        Interval =
                            CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            BillingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
            },
            Description = "New description",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_id",
                Email = "dev@stainless.com",
                Phone = "x",
            },
            EntityID = "entity_id",
            Status = Status.Active,
        };

        CardUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount expectedMaximumAuthorizationCount =
            new(0);
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier expectedMerchantAcceptorIdentifier =
            new() { Allowed = [new("x")], Blocked = [new("x")] };
        CardUpdateParamsAuthorizationControlsMerchantCategoryCode expectedMerchantCategoryCode =
            new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] };
        CardUpdateParamsAuthorizationControlsMerchantCountry expectedMerchantCountry = new()
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };
        List<CardUpdateParamsAuthorizationControlsSpendingLimit> expectedSpendingLimits =
        [
            new()
            {
                Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                SettlementAmount = 0,
                MerchantCategoryCodes = [new("x")],
            },
        ];

        Assert.Equal(expectedMaximumAuthorizationCount, model.MaximumAuthorizationCount);
        Assert.Equal(expectedMerchantAcceptorIdentifier, model.MerchantAcceptorIdentifier);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCountry, model.MerchantCountry);
        Assert.NotNull(model.SpendingLimits);
        Assert.Equal(expectedSpendingLimits.Count, model.SpendingLimits.Count);
        for (int i = 0; i < expectedSpendingLimits.Count; i++)
        {
            Assert.Equal(expectedSpendingLimits[i], model.SpendingLimits[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControls>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControls>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount expectedMaximumAuthorizationCount =
            new(0);
        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier expectedMerchantAcceptorIdentifier =
            new() { Allowed = [new("x")], Blocked = [new("x")] };
        CardUpdateParamsAuthorizationControlsMerchantCategoryCode expectedMerchantCategoryCode =
            new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] };
        CardUpdateParamsAuthorizationControlsMerchantCountry expectedMerchantCountry = new()
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };
        List<CardUpdateParamsAuthorizationControlsSpendingLimit> expectedSpendingLimits =
        [
            new()
            {
                Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                SettlementAmount = 0,
                MerchantCategoryCodes = [new("x")],
            },
        ];

        Assert.Equal(expectedMaximumAuthorizationCount, deserialized.MaximumAuthorizationCount);
        Assert.Equal(expectedMerchantAcceptorIdentifier, deserialized.MerchantAcceptorIdentifier);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCountry, deserialized.MerchantCountry);
        Assert.NotNull(deserialized.SpendingLimits);
        Assert.Equal(expectedSpendingLimits.Count, deserialized.SpendingLimits.Count);
        for (int i = 0; i < expectedSpendingLimits.Count; i++)
        {
            Assert.Equal(expectedSpendingLimits[i], deserialized.SpendingLimits[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls { };

        Assert.Null(model.MaximumAuthorizationCount);
        Assert.False(model.RawData.ContainsKey("maximum_authorization_count"));
        Assert.Null(model.MerchantAcceptorIdentifier);
        Assert.False(model.RawData.ContainsKey("merchant_acceptor_identifier"));
        Assert.Null(model.MerchantCategoryCode);
        Assert.False(model.RawData.ContainsKey("merchant_category_code"));
        Assert.Null(model.MerchantCountry);
        Assert.False(model.RawData.ContainsKey("merchant_country"));
        Assert.Null(model.SpendingLimits);
        Assert.False(model.RawData.ContainsKey("spending_limits"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls
        {
            // Null should be interpreted as omitted for these properties
            MaximumAuthorizationCount = null,
            MerchantAcceptorIdentifier = null,
            MerchantCategoryCode = null,
            MerchantCountry = null,
            SpendingLimits = null,
        };

        Assert.Null(model.MaximumAuthorizationCount);
        Assert.False(model.RawData.ContainsKey("maximum_authorization_count"));
        Assert.Null(model.MerchantAcceptorIdentifier);
        Assert.False(model.RawData.ContainsKey("merchant_acceptor_identifier"));
        Assert.Null(model.MerchantCategoryCode);
        Assert.False(model.RawData.ContainsKey("merchant_category_code"));
        Assert.Null(model.MerchantCountry);
        Assert.False(model.RawData.ContainsKey("merchant_country"));
        Assert.Null(model.SpendingLimits);
        Assert.False(model.RawData.ContainsKey("spending_limits"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls
        {
            // Null should be interpreted as omitted for these properties
            MaximumAuthorizationCount = null,
            MerchantAcceptorIdentifier = null,
            MerchantCategoryCode = null,
            MerchantCountry = null,
            SpendingLimits = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        CardUpdateParamsAuthorizationControls copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMaximumAuthorizationCountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount
        {
            AllTime = 0,
        };

        long expectedAllTime = 0;

        Assert.Equal(expectedAllTime, model.AllTime);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount
        {
            AllTime = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount
        {
            AllTime = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAllTime = 0;

        Assert.Equal(expectedAllTime, deserialized.AllTime);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount
        {
            AllTime = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount
        {
            AllTime = 0,
        };

        CardUpdateParamsAuthorizationControlsMaximumAuthorizationCount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        List<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed> expectedAllowed =
        [
            new("x"),
        ];
        List<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked> expectedBlocked =
        [
            new("x"),
        ];

        Assert.NotNull(model.Allowed);
        Assert.Equal(expectedAllowed.Count, model.Allowed.Count);
        for (int i = 0; i < expectedAllowed.Count; i++)
        {
            Assert.Equal(expectedAllowed[i], model.Allowed[i]);
        }
        Assert.NotNull(model.Blocked);
        Assert.Equal(expectedBlocked.Count, model.Blocked.Count);
        for (int i = 0; i < expectedBlocked.Count; i++)
        {
            Assert.Equal(expectedBlocked[i], model.Blocked[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed> expectedAllowed =
        [
            new("x"),
        ];
        List<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked> expectedBlocked =
        [
            new("x"),
        ];

        Assert.NotNull(deserialized.Allowed);
        Assert.Equal(expectedAllowed.Count, deserialized.Allowed.Count);
        for (int i = 0; i < expectedAllowed.Count; i++)
        {
            Assert.Equal(expectedAllowed[i], deserialized.Allowed[i]);
        }
        Assert.NotNull(deserialized.Blocked);
        Assert.Equal(expectedBlocked.Count, deserialized.Blocked.Count);
        for (int i = 0; i < expectedBlocked.Count; i++)
        {
            Assert.Equal(expectedBlocked[i], deserialized.Blocked[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
        {
            // Null should be interpreted as omitted for these properties
            Allowed = null,
            Blocked = null,
        };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
        {
            // Null should be interpreted as omitted for these properties
            Allowed = null,
            Blocked = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "x",
        };

        string expectedIdentifier = "x";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedIdentifier = "x";

        Assert.Equal(expectedIdentifier, deserialized.Identifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "x",
        };

        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "x",
        };

        string expectedIdentifier = "x";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedIdentifier = "x";

        Assert.Equal(expectedIdentifier, deserialized.Identifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "x",
        };

        CardUpdateParamsAuthorizationControlsMerchantAcceptorIdentifierBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantCategoryCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        List<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed> expectedAllowed =
        [
            new("xxxx"),
        ];
        List<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked> expectedBlocked =
        [
            new("xxxx"),
        ];

        Assert.NotNull(model.Allowed);
        Assert.Equal(expectedAllowed.Count, model.Allowed.Count);
        for (int i = 0; i < expectedAllowed.Count; i++)
        {
            Assert.Equal(expectedAllowed[i], model.Allowed[i]);
        }
        Assert.NotNull(model.Blocked);
        Assert.Equal(expectedBlocked.Count, model.Blocked.Count);
        for (int i = 0; i < expectedBlocked.Count; i++)
        {
            Assert.Equal(expectedBlocked[i], model.Blocked[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCategoryCode>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCategoryCode>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed> expectedAllowed =
        [
            new("xxxx"),
        ];
        List<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked> expectedBlocked =
        [
            new("xxxx"),
        ];

        Assert.NotNull(deserialized.Allowed);
        Assert.Equal(expectedAllowed.Count, deserialized.Allowed.Count);
        for (int i = 0; i < expectedAllowed.Count; i++)
        {
            Assert.Equal(expectedAllowed[i], deserialized.Allowed[i]);
        }
        Assert.NotNull(deserialized.Blocked);
        Assert.Equal(expectedBlocked.Count, deserialized.Blocked.Count);
        for (int i = 0; i < expectedBlocked.Count; i++)
        {
            Assert.Equal(expectedBlocked[i], deserialized.Blocked[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode
        {
            // Null should be interpreted as omitted for these properties
            Allowed = null,
            Blocked = null,
        };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode
        {
            // Null should be interpreted as omitted for these properties
            Allowed = null,
            Blocked = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        CardUpdateParamsAuthorizationControlsMerchantCategoryCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "xxxx",
        };

        string expectedCode = "xxxx";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "xxxx",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "xxxx",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCode = "xxxx";

        Assert.Equal(expectedCode, deserialized.Code);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "xxxx",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "xxxx",
        };

        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "xxxx",
        };

        string expectedCode = "xxxx";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "xxxx",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "xxxx",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCode = "xxxx";

        Assert.Equal(expectedCode, deserialized.Code);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "xxxx",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "xxxx",
        };

        CardUpdateParamsAuthorizationControlsMerchantCategoryCodeBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantCountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };

        List<CardUpdateParamsAuthorizationControlsMerchantCountryAllowed> expectedAllowed =
        [
            new("xx"),
        ];
        List<CardUpdateParamsAuthorizationControlsMerchantCountryBlocked> expectedBlocked =
        [
            new("xx"),
        ];

        Assert.NotNull(model.Allowed);
        Assert.Equal(expectedAllowed.Count, model.Allowed.Count);
        for (int i = 0; i < expectedAllowed.Count; i++)
        {
            Assert.Equal(expectedAllowed[i], model.Allowed[i]);
        }
        Assert.NotNull(model.Blocked);
        Assert.Equal(expectedBlocked.Count, model.Blocked.Count);
        for (int i = 0; i < expectedBlocked.Count; i++)
        {
            Assert.Equal(expectedBlocked[i], model.Blocked[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCountry>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCountry>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<CardUpdateParamsAuthorizationControlsMerchantCountryAllowed> expectedAllowed =
        [
            new("xx"),
        ];
        List<CardUpdateParamsAuthorizationControlsMerchantCountryBlocked> expectedBlocked =
        [
            new("xx"),
        ];

        Assert.NotNull(deserialized.Allowed);
        Assert.Equal(expectedAllowed.Count, deserialized.Allowed.Count);
        for (int i = 0; i < expectedAllowed.Count; i++)
        {
            Assert.Equal(expectedAllowed[i], deserialized.Allowed[i]);
        }
        Assert.NotNull(deserialized.Blocked);
        Assert.Equal(expectedBlocked.Count, deserialized.Blocked.Count);
        for (int i = 0; i < expectedBlocked.Count; i++)
        {
            Assert.Equal(expectedBlocked[i], deserialized.Blocked[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry
        {
            // Null should be interpreted as omitted for these properties
            Allowed = null,
            Blocked = null,
        };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry
        {
            // Null should be interpreted as omitted for these properties
            Allowed = null,
            Blocked = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountry
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };

        CardUpdateParamsAuthorizationControlsMerchantCountry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantCountryAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryAllowed
        {
            Country = "xx",
        };

        string expectedCountry = "xx";

        Assert.Equal(expectedCountry, model.Country);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryAllowed
        {
            Country = "xx",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCountryAllowed>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryAllowed
        {
            Country = "xx",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCountryAllowed>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCountry = "xx";

        Assert.Equal(expectedCountry, deserialized.Country);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryAllowed
        {
            Country = "xx",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryAllowed
        {
            Country = "xx",
        };

        CardUpdateParamsAuthorizationControlsMerchantCountryAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsMerchantCountryBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryBlocked
        {
            Country = "xx",
        };

        string expectedCountry = "xx";

        Assert.Equal(expectedCountry, model.Country);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryBlocked
        {
            Country = "xx",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCountryBlocked>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryBlocked
        {
            Country = "xx",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsMerchantCountryBlocked>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCountry = "xx";

        Assert.Equal(expectedCountry, deserialized.Country);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryBlocked
        {
            Country = "xx",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsMerchantCountryBlocked
        {
            Country = "xx",
        };

        CardUpdateParamsAuthorizationControlsMerchantCountryBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsSpendingLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        ApiEnum<
            string,
            CardUpdateParamsAuthorizationControlsSpendingLimitInterval
        > expectedInterval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime;
        long expectedSettlementAmount = 0;
        List<CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode> expectedMerchantCategoryCodes =
        [
            new("x"),
        ];

        Assert.Equal(expectedInterval, model.Interval);
        Assert.Equal(expectedSettlementAmount, model.SettlementAmount);
        Assert.NotNull(model.MerchantCategoryCodes);
        Assert.Equal(expectedMerchantCategoryCodes.Count, model.MerchantCategoryCodes.Count);
        for (int i = 0; i < expectedMerchantCategoryCodes.Count; i++)
        {
            Assert.Equal(expectedMerchantCategoryCodes[i], model.MerchantCategoryCodes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsSpendingLimit>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsSpendingLimit>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            CardUpdateParamsAuthorizationControlsSpendingLimitInterval
        > expectedInterval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime;
        long expectedSettlementAmount = 0;
        List<CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode> expectedMerchantCategoryCodes =
        [
            new("x"),
        ];

        Assert.Equal(expectedInterval, deserialized.Interval);
        Assert.Equal(expectedSettlementAmount, deserialized.SettlementAmount);
        Assert.NotNull(deserialized.MerchantCategoryCodes);
        Assert.Equal(expectedMerchantCategoryCodes.Count, deserialized.MerchantCategoryCodes.Count);
        for (int i = 0; i < expectedMerchantCategoryCodes.Count; i++)
        {
            Assert.Equal(expectedMerchantCategoryCodes[i], deserialized.MerchantCategoryCodes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,
        };

        Assert.Null(model.MerchantCategoryCodes);
        Assert.False(model.RawData.ContainsKey("merchant_category_codes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,

            // Null should be interpreted as omitted for these properties
            MerchantCategoryCodes = null,
        };

        Assert.Null(model.MerchantCategoryCodes);
        Assert.False(model.RawData.ContainsKey("merchant_category_codes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,

            // Null should be interpreted as omitted for these properties
            MerchantCategoryCodes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimit
        {
            Interval = CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        CardUpdateParamsAuthorizationControlsSpendingLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsAuthorizationControlsSpendingLimitIntervalTest : TestBase
{
    [Theory]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime)]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerTransaction)]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerDay)]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerWeek)]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerMonth)]
    public void Validation_Works(
        CardUpdateParamsAuthorizationControlsSpendingLimitInterval rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardUpdateParamsAuthorizationControlsSpendingLimitInterval> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardUpdateParamsAuthorizationControlsSpendingLimitInterval>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.AllTime)]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerTransaction)]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerDay)]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerWeek)]
    [InlineData(CardUpdateParamsAuthorizationControlsSpendingLimitInterval.PerMonth)]
    public void SerializationRoundtrip_Works(
        CardUpdateParamsAuthorizationControlsSpendingLimitInterval rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardUpdateParamsAuthorizationControlsSpendingLimitInterval> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardUpdateParamsAuthorizationControlsSpendingLimitInterval>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CardUpdateParamsAuthorizationControlsSpendingLimitInterval>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CardUpdateParamsAuthorizationControlsSpendingLimitInterval>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "x",
        };

        string expectedCode = "x";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCode = "x";

        Assert.Equal(expectedCode, deserialized.Code);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "x",
        };

        CardUpdateParamsAuthorizationControlsSpendingLimitMerchantCategoryCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedLine2, model.Line2);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardUpdateParamsBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardUpdateParamsBillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";
        string expectedLine2 = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedLine2, deserialized.Line2);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsBillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        CardUpdateParamsBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardUpdateParamsDigitalWalletTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardUpdateParamsDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string expectedDigitalCardProfileID = "digital_card_profile_id";
        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "x";

        Assert.Equal(expectedDigitalCardProfileID, model.DigitalCardProfileID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardUpdateParamsDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardUpdateParamsDigitalWallet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardUpdateParamsDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardUpdateParamsDigitalWallet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDigitalCardProfileID = "digital_card_profile_id";
        string expectedEmail = "dev@stainless.com";
        string expectedPhone = "x";

        Assert.Equal(expectedDigitalCardProfileID, deserialized.DigitalCardProfileID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardUpdateParamsDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardUpdateParamsDigitalWallet { };

        Assert.Null(model.DigitalCardProfileID);
        Assert.False(model.RawData.ContainsKey("digital_card_profile_id"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardUpdateParamsDigitalWallet { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardUpdateParamsDigitalWallet
        {
            // Null should be interpreted as omitted for these properties
            DigitalCardProfileID = null,
            Email = null,
            Phone = null,
        };

        Assert.Null(model.DigitalCardProfileID);
        Assert.False(model.RawData.ContainsKey("digital_card_profile_id"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardUpdateParamsDigitalWallet
        {
            // Null should be interpreted as omitted for these properties
            DigitalCardProfileID = null,
            Email = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardUpdateParamsDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        CardUpdateParamsDigitalWallet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    [InlineData(Status.Canceled)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Disabled)]
    [InlineData(Status.Canceled)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
