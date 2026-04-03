using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
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
                        Interval = Interval.AllTime,
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
            Description = "Card for Ian Crease",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_id",
                Email = "dev@stainless.com",
                Phone = "x",
            },
            EntityID = "entity_id",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        AuthorizationControls expectedAuthorizationControls = new()
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };
        BillingAddress expectedBillingAddress = new()
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };
        string expectedDescription = "Card for Ian Crease";
        DigitalWallet expectedDigitalWallet = new()
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };
        string expectedEntityID = "entity_id";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAuthorizationControls, parameters.AuthorizationControls);
        Assert.Equal(expectedBillingAddress, parameters.BillingAddress);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDigitalWallet, parameters.DigitalWallet);
        Assert.Equal(expectedEntityID, parameters.EntityID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardCreateParams { AccountID = "account_in71c4amph0vgo2qllky" };

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
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",

            // Null should be interpreted as omitted for these properties
            AuthorizationControls = null,
            BillingAddress = null,
            Description = null,
            DigitalWallet = null,
            EntityID = null,
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
    }

    [Fact]
    public void Url_Works()
    {
        CardCreateParams parameters = new() { AccountID = "account_in71c4amph0vgo2qllky" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/cards"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
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
                        Interval = Interval.AllTime,
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
            Description = "Card for Ian Crease",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_id",
                Email = "dev@stainless.com",
                Phone = "x",
            },
            EntityID = "entity_id",
        };

        CardCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AuthorizationControlsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        MaximumAuthorizationCount expectedMaximumAuthorizationCount = new(0);
        MerchantAcceptorIdentifier expectedMerchantAcceptorIdentifier = new()
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };
        MerchantCategoryCode expectedMerchantCategoryCode = new()
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };
        MerchantCountry expectedMerchantCountry = new()
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };
        List<SpendingLimit> expectedSpendingLimits =
        [
            new()
            {
                Interval = Interval.AllTime,
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
        var model = new AuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthorizationControls>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AuthorizationControls>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MaximumAuthorizationCount expectedMaximumAuthorizationCount = new(0);
        MerchantAcceptorIdentifier expectedMerchantAcceptorIdentifier = new()
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };
        MerchantCategoryCode expectedMerchantCategoryCode = new()
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };
        MerchantCountry expectedMerchantCountry = new()
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };
        List<SpendingLimit> expectedSpendingLimits =
        [
            new()
            {
                Interval = Interval.AllTime,
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
        var model = new AuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Interval.AllTime,
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
        var model = new AuthorizationControls { };

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
        var model = new AuthorizationControls { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AuthorizationControls
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
        var model = new AuthorizationControls
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
        var model = new AuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        AuthorizationControls copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MaximumAuthorizationCountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaximumAuthorizationCount { AllTime = 0 };

        long expectedAllTime = 0;

        Assert.Equal(expectedAllTime, model.AllTime);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MaximumAuthorizationCount { AllTime = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaximumAuthorizationCount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MaximumAuthorizationCount { AllTime = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MaximumAuthorizationCount>(
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
        var model = new MaximumAuthorizationCount { AllTime = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MaximumAuthorizationCount { AllTime = 0 };

        MaximumAuthorizationCount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantAcceptorIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantAcceptorIdentifier { Allowed = [new("x")], Blocked = [new("x")] };

        List<Allowed> expectedAllowed = [new("x")];
        List<Blocked> expectedBlocked = [new("x")];

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
        var model = new MerchantAcceptorIdentifier { Allowed = [new("x")], Blocked = [new("x")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantAcceptorIdentifier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantAcceptorIdentifier { Allowed = [new("x")], Blocked = [new("x")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantAcceptorIdentifier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Allowed> expectedAllowed = [new("x")];
        List<Blocked> expectedBlocked = [new("x")];

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
        var model = new MerchantAcceptorIdentifier { Allowed = [new("x")], Blocked = [new("x")] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MerchantAcceptorIdentifier { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MerchantAcceptorIdentifier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MerchantAcceptorIdentifier
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
        var model = new MerchantAcceptorIdentifier
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
        var model = new MerchantAcceptorIdentifier { Allowed = [new("x")], Blocked = [new("x")] };

        MerchantAcceptorIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Allowed { Identifier = "x" };

        string expectedIdentifier = "x";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Allowed { Identifier = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Allowed>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Allowed { Identifier = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Allowed>(
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
        var model = new Allowed { Identifier = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Allowed { Identifier = "x" };

        Allowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Blocked { Identifier = "x" };

        string expectedIdentifier = "x";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Blocked { Identifier = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Blocked>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Blocked { Identifier = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Blocked>(
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
        var model = new Blocked { Identifier = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Blocked { Identifier = "x" };

        Blocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCategoryCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantCategoryCode { Allowed = [new("xxxx")], Blocked = [new("xxxx")] };

        List<MerchantCategoryCodeAllowed> expectedAllowed = [new("xxxx")];
        List<MerchantCategoryCodeBlocked> expectedBlocked = [new("xxxx")];

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
        var model = new MerchantCategoryCode { Allowed = [new("xxxx")], Blocked = [new("xxxx")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCategoryCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantCategoryCode { Allowed = [new("xxxx")], Blocked = [new("xxxx")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCategoryCode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MerchantCategoryCodeAllowed> expectedAllowed = [new("xxxx")];
        List<MerchantCategoryCodeBlocked> expectedBlocked = [new("xxxx")];

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
        var model = new MerchantCategoryCode { Allowed = [new("xxxx")], Blocked = [new("xxxx")] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MerchantCategoryCode { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MerchantCategoryCode { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MerchantCategoryCode
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
        var model = new MerchantCategoryCode
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
        var model = new MerchantCategoryCode { Allowed = [new("xxxx")], Blocked = [new("xxxx")] };

        MerchantCategoryCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCategoryCodeAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantCategoryCodeAllowed { Code = "xxxx" };

        string expectedCode = "xxxx";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MerchantCategoryCodeAllowed { Code = "xxxx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCategoryCodeAllowed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantCategoryCodeAllowed { Code = "xxxx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCategoryCodeAllowed>(
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
        var model = new MerchantCategoryCodeAllowed { Code = "xxxx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MerchantCategoryCodeAllowed { Code = "xxxx" };

        MerchantCategoryCodeAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCategoryCodeBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantCategoryCodeBlocked { Code = "xxxx" };

        string expectedCode = "xxxx";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MerchantCategoryCodeBlocked { Code = "xxxx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCategoryCodeBlocked>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantCategoryCodeBlocked { Code = "xxxx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCategoryCodeBlocked>(
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
        var model = new MerchantCategoryCodeBlocked { Code = "xxxx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MerchantCategoryCodeBlocked { Code = "xxxx" };

        MerchantCategoryCodeBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        List<MerchantCountryAllowed> expectedAllowed = [new("xx")];
        List<MerchantCountryBlocked> expectedBlocked = [new("xx")];

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
        var model = new MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCountry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCountry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<MerchantCountryAllowed> expectedAllowed = [new("xx")];
        List<MerchantCountryBlocked> expectedBlocked = [new("xx")];

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
        var model = new MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MerchantCountry { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MerchantCountry { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MerchantCountry
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
        var model = new MerchantCountry
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
        var model = new MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        MerchantCountry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCountryAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantCountryAllowed { Country = "xx" };

        string expectedCountry = "xx";

        Assert.Equal(expectedCountry, model.Country);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MerchantCountryAllowed { Country = "xx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCountryAllowed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantCountryAllowed { Country = "xx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCountryAllowed>(
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
        var model = new MerchantCountryAllowed { Country = "xx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MerchantCountryAllowed { Country = "xx" };

        MerchantCountryAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCountryBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MerchantCountryBlocked { Country = "xx" };

        string expectedCountry = "xx";

        Assert.Equal(expectedCountry, model.Country);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MerchantCountryBlocked { Country = "xx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCountryBlocked>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MerchantCountryBlocked { Country = "xx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MerchantCountryBlocked>(
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
        var model = new MerchantCountryBlocked { Country = "xx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MerchantCountryBlocked { Country = "xx" };

        MerchantCountryBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SpendingLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpendingLimit
        {
            Interval = Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        ApiEnum<string, Interval> expectedInterval = Interval.AllTime;
        long expectedSettlementAmount = 0;
        List<SpendingLimitMerchantCategoryCode> expectedMerchantCategoryCodes = [new("x")];

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
        var model = new SpendingLimit
        {
            Interval = Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendingLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpendingLimit
        {
            Interval = Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendingLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Interval> expectedInterval = Interval.AllTime;
        long expectedSettlementAmount = 0;
        List<SpendingLimitMerchantCategoryCode> expectedMerchantCategoryCodes = [new("x")];

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
        var model = new SpendingLimit
        {
            Interval = Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SpendingLimit { Interval = Interval.AllTime, SettlementAmount = 0 };

        Assert.Null(model.MerchantCategoryCodes);
        Assert.False(model.RawData.ContainsKey("merchant_category_codes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SpendingLimit { Interval = Interval.AllTime, SettlementAmount = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SpendingLimit
        {
            Interval = Interval.AllTime,
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
        var model = new SpendingLimit
        {
            Interval = Interval.AllTime,
            SettlementAmount = 0,

            // Null should be interpreted as omitted for these properties
            MerchantCategoryCodes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SpendingLimit
        {
            Interval = Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        SpendingLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntervalTest : TestBase
{
    [Theory]
    [InlineData(Interval.AllTime)]
    [InlineData(Interval.PerTransaction)]
    [InlineData(Interval.PerDay)]
    [InlineData(Interval.PerWeek)]
    [InlineData(Interval.PerMonth)]
    public void Validation_Works(Interval rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Interval> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Interval>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Interval.AllTime)]
    [InlineData(Interval.PerTransaction)]
    [InlineData(Interval.PerDay)]
    [InlineData(Interval.PerWeek)]
    [InlineData(Interval.PerMonth)]
    public void SerializationRoundtrip_Works(Interval rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Interval> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Interval>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Interval>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Interval>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SpendingLimitMerchantCategoryCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpendingLimitMerchantCategoryCode { Code = "x" };

        string expectedCode = "x";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SpendingLimitMerchantCategoryCode { Code = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendingLimitMerchantCategoryCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpendingLimitMerchantCategoryCode { Code = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendingLimitMerchantCategoryCode>(
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
        var model = new SpendingLimitMerchantCategoryCode { Code = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SpendingLimitMerchantCategoryCode { Code = "x" };

        SpendingLimitMerchantCategoryCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingAddress
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
        var model = new BillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
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
        var model = new BillingAddress
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
        var model = new BillingAddress
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
        var model = new BillingAddress
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
        var model = new BillingAddress
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
        var model = new BillingAddress
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
        var model = new BillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        BillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalWalletTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DigitalWallet
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
        var model = new DigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWallet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DigitalWallet>(
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
        var model = new DigitalWallet
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
        var model = new DigitalWallet { };

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
        var model = new DigitalWallet { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DigitalWallet
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
        var model = new DigitalWallet
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
        var model = new DigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        DigitalWallet copied = new(model);

        Assert.Equal(model, copied);
    }
}
