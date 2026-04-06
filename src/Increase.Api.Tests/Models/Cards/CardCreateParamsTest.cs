using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Cards = Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Cards::CardCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AuthorizationControls = new()
            {
                MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
                MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
                MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
                Usage = new()
                {
                    Category = Cards::Category.SingleUse,
                    MultiUse = new()
                    {
                        SpendingLimits =
                        [
                            new()
                            {
                                Interval = Cards::Interval.AllTime,
                                SettlementAmount = 0,
                                MerchantCategoryCodes = [new("x")],
                            },
                        ],
                    },
                    SingleUse = new(
                        new Cards::SettlementAmount()
                        {
                            Comparison = Cards::Comparison.Equals,
                            Value = 0,
                        }
                    ),
                },
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
        Cards::AuthorizationControls expectedAuthorizationControls = new()
        {
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            Usage = new()
            {
                Category = Cards::Category.SingleUse,
                MultiUse = new()
                {
                    SpendingLimits =
                    [
                        new()
                        {
                            Interval = Cards::Interval.AllTime,
                            SettlementAmount = 0,
                            MerchantCategoryCodes = [new("x")],
                        },
                    ],
                },
                SingleUse = new(
                    new Cards::SettlementAmount()
                    {
                        Comparison = Cards::Comparison.Equals,
                        Value = 0,
                    }
                ),
            },
        };
        Cards::BillingAddress expectedBillingAddress = new()
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };
        string expectedDescription = "Card for Ian Crease";
        Cards::DigitalWallet expectedDigitalWallet = new()
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
        var parameters = new Cards::CardCreateParams { AccountID = "account_in71c4amph0vgo2qllky" };

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
        var parameters = new Cards::CardCreateParams
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
        Cards::CardCreateParams parameters = new() { AccountID = "account_in71c4amph0vgo2qllky" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/cards"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Cards::CardCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AuthorizationControls = new()
            {
                MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
                MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
                MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
                Usage = new()
                {
                    Category = Cards::Category.SingleUse,
                    MultiUse = new()
                    {
                        SpendingLimits =
                        [
                            new()
                            {
                                Interval = Cards::Interval.AllTime,
                                SettlementAmount = 0,
                                MerchantCategoryCodes = [new("x")],
                            },
                        ],
                    },
                    SingleUse = new(
                        new Cards::SettlementAmount()
                        {
                            Comparison = Cards::Comparison.Equals,
                            Value = 0,
                        }
                    ),
                },
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

        Cards::CardCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AuthorizationControlsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::AuthorizationControls
        {
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            Usage = new()
            {
                Category = Cards::Category.SingleUse,
                MultiUse = new()
                {
                    SpendingLimits =
                    [
                        new()
                        {
                            Interval = Cards::Interval.AllTime,
                            SettlementAmount = 0,
                            MerchantCategoryCodes = [new("x")],
                        },
                    ],
                },
                SingleUse = new(
                    new Cards::SettlementAmount()
                    {
                        Comparison = Cards::Comparison.Equals,
                        Value = 0,
                    }
                ),
            },
        };

        Cards::MerchantAcceptorIdentifier expectedMerchantAcceptorIdentifier = new()
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };
        Cards::MerchantCategoryCode expectedMerchantCategoryCode = new()
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };
        Cards::MerchantCountry expectedMerchantCountry = new()
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };
        Cards::Usage expectedUsage = new()
        {
            Category = Cards::Category.SingleUse,
            MultiUse = new()
            {
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::Interval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            SingleUse = new(
                new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
            ),
        };

        Assert.Equal(expectedMerchantAcceptorIdentifier, model.MerchantAcceptorIdentifier);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCountry, model.MerchantCountry);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::AuthorizationControls
        {
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            Usage = new()
            {
                Category = Cards::Category.SingleUse,
                MultiUse = new()
                {
                    SpendingLimits =
                    [
                        new()
                        {
                            Interval = Cards::Interval.AllTime,
                            SettlementAmount = 0,
                            MerchantCategoryCodes = [new("x")],
                        },
                    ],
                },
                SingleUse = new(
                    new Cards::SettlementAmount()
                    {
                        Comparison = Cards::Comparison.Equals,
                        Value = 0,
                    }
                ),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::AuthorizationControls>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::AuthorizationControls
        {
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            Usage = new()
            {
                Category = Cards::Category.SingleUse,
                MultiUse = new()
                {
                    SpendingLimits =
                    [
                        new()
                        {
                            Interval = Cards::Interval.AllTime,
                            SettlementAmount = 0,
                            MerchantCategoryCodes = [new("x")],
                        },
                    ],
                },
                SingleUse = new(
                    new Cards::SettlementAmount()
                    {
                        Comparison = Cards::Comparison.Equals,
                        Value = 0,
                    }
                ),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::AuthorizationControls>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Cards::MerchantAcceptorIdentifier expectedMerchantAcceptorIdentifier = new()
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };
        Cards::MerchantCategoryCode expectedMerchantCategoryCode = new()
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };
        Cards::MerchantCountry expectedMerchantCountry = new()
        {
            Allowed = [new("xx")],
            Blocked = [new("xx")],
        };
        Cards::Usage expectedUsage = new()
        {
            Category = Cards::Category.SingleUse,
            MultiUse = new()
            {
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::Interval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            SingleUse = new(
                new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
            ),
        };

        Assert.Equal(expectedMerchantAcceptorIdentifier, deserialized.MerchantAcceptorIdentifier);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCountry, deserialized.MerchantCountry);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::AuthorizationControls
        {
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            Usage = new()
            {
                Category = Cards::Category.SingleUse,
                MultiUse = new()
                {
                    SpendingLimits =
                    [
                        new()
                        {
                            Interval = Cards::Interval.AllTime,
                            SettlementAmount = 0,
                            MerchantCategoryCodes = [new("x")],
                        },
                    ],
                },
                SingleUse = new(
                    new Cards::SettlementAmount()
                    {
                        Comparison = Cards::Comparison.Equals,
                        Value = 0,
                    }
                ),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cards::AuthorizationControls { };

        Assert.Null(model.MerchantAcceptorIdentifier);
        Assert.False(model.RawData.ContainsKey("merchant_acceptor_identifier"));
        Assert.Null(model.MerchantCategoryCode);
        Assert.False(model.RawData.ContainsKey("merchant_category_code"));
        Assert.Null(model.MerchantCountry);
        Assert.False(model.RawData.ContainsKey("merchant_country"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cards::AuthorizationControls { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cards::AuthorizationControls
        {
            // Null should be interpreted as omitted for these properties
            MerchantAcceptorIdentifier = null,
            MerchantCategoryCode = null,
            MerchantCountry = null,
            Usage = null,
        };

        Assert.Null(model.MerchantAcceptorIdentifier);
        Assert.False(model.RawData.ContainsKey("merchant_acceptor_identifier"));
        Assert.Null(model.MerchantCategoryCode);
        Assert.False(model.RawData.ContainsKey("merchant_category_code"));
        Assert.Null(model.MerchantCountry);
        Assert.False(model.RawData.ContainsKey("merchant_country"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Cards::AuthorizationControls
        {
            // Null should be interpreted as omitted for these properties
            MerchantAcceptorIdentifier = null,
            MerchantCategoryCode = null,
            MerchantCountry = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::AuthorizationControls
        {
            MerchantAcceptorIdentifier = new() { Allowed = [new("x")], Blocked = [new("x")] },
            MerchantCategoryCode = new() { Allowed = [new("xxxx")], Blocked = [new("xxxx")] },
            MerchantCountry = new() { Allowed = [new("xx")], Blocked = [new("xx")] },
            Usage = new()
            {
                Category = Cards::Category.SingleUse,
                MultiUse = new()
                {
                    SpendingLimits =
                    [
                        new()
                        {
                            Interval = Cards::Interval.AllTime,
                            SettlementAmount = 0,
                            MerchantCategoryCodes = [new("x")],
                        },
                    ],
                },
                SingleUse = new(
                    new Cards::SettlementAmount()
                    {
                        Comparison = Cards::Comparison.Equals,
                        Value = 0,
                    }
                ),
            },
        };

        Cards::AuthorizationControls copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantAcceptorIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::MerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        List<Cards::Allowed> expectedAllowed = [new("x")];
        List<Cards::Blocked> expectedBlocked = [new("x")];

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
        var model = new Cards::MerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantAcceptorIdentifier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::MerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantAcceptorIdentifier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Cards::Allowed> expectedAllowed = [new("x")];
        List<Cards::Blocked> expectedBlocked = [new("x")];

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
        var model = new Cards::MerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cards::MerchantAcceptorIdentifier { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cards::MerchantAcceptorIdentifier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cards::MerchantAcceptorIdentifier
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
        var model = new Cards::MerchantAcceptorIdentifier
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
        var model = new Cards::MerchantAcceptorIdentifier
        {
            Allowed = [new("x")],
            Blocked = [new("x")],
        };

        Cards::MerchantAcceptorIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::Allowed { Identifier = "x" };

        string expectedIdentifier = "x";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::Allowed { Identifier = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::Allowed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::Allowed { Identifier = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::Allowed>(
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
        var model = new Cards::Allowed { Identifier = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::Allowed { Identifier = "x" };

        Cards::Allowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::Blocked { Identifier = "x" };

        string expectedIdentifier = "x";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::Blocked { Identifier = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::Blocked>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::Blocked { Identifier = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::Blocked>(
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
        var model = new Cards::Blocked { Identifier = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::Blocked { Identifier = "x" };

        Cards::Blocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCategoryCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::MerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        List<Cards::MerchantCategoryCodeAllowed> expectedAllowed = [new("xxxx")];
        List<Cards::MerchantCategoryCodeBlocked> expectedBlocked = [new("xxxx")];

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
        var model = new Cards::MerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCategoryCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::MerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCategoryCode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Cards::MerchantCategoryCodeAllowed> expectedAllowed = [new("xxxx")];
        List<Cards::MerchantCategoryCodeBlocked> expectedBlocked = [new("xxxx")];

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
        var model = new Cards::MerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cards::MerchantCategoryCode { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cards::MerchantCategoryCode { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cards::MerchantCategoryCode
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
        var model = new Cards::MerchantCategoryCode
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
        var model = new Cards::MerchantCategoryCode
        {
            Allowed = [new("xxxx")],
            Blocked = [new("xxxx")],
        };

        Cards::MerchantCategoryCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCategoryCodeAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::MerchantCategoryCodeAllowed { Code = "xxxx" };

        string expectedCode = "xxxx";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::MerchantCategoryCodeAllowed { Code = "xxxx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCategoryCodeAllowed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::MerchantCategoryCodeAllowed { Code = "xxxx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCategoryCodeAllowed>(
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
        var model = new Cards::MerchantCategoryCodeAllowed { Code = "xxxx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::MerchantCategoryCodeAllowed { Code = "xxxx" };

        Cards::MerchantCategoryCodeAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCategoryCodeBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::MerchantCategoryCodeBlocked { Code = "xxxx" };

        string expectedCode = "xxxx";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::MerchantCategoryCodeBlocked { Code = "xxxx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCategoryCodeBlocked>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::MerchantCategoryCodeBlocked { Code = "xxxx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCategoryCodeBlocked>(
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
        var model = new Cards::MerchantCategoryCodeBlocked { Code = "xxxx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::MerchantCategoryCodeBlocked { Code = "xxxx" };

        Cards::MerchantCategoryCodeBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        List<Cards::MerchantCountryAllowed> expectedAllowed = [new("xx")];
        List<Cards::MerchantCountryBlocked> expectedBlocked = [new("xx")];

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
        var model = new Cards::MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCountry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCountry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Cards::MerchantCountryAllowed> expectedAllowed = [new("xx")];
        List<Cards::MerchantCountryBlocked> expectedBlocked = [new("xx")];

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
        var model = new Cards::MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cards::MerchantCountry { };

        Assert.Null(model.Allowed);
        Assert.False(model.RawData.ContainsKey("allowed"));
        Assert.Null(model.Blocked);
        Assert.False(model.RawData.ContainsKey("blocked"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cards::MerchantCountry { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cards::MerchantCountry
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
        var model = new Cards::MerchantCountry
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
        var model = new Cards::MerchantCountry { Allowed = [new("xx")], Blocked = [new("xx")] };

        Cards::MerchantCountry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCountryAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::MerchantCountryAllowed { Country = "xx" };

        string expectedCountry = "xx";

        Assert.Equal(expectedCountry, model.Country);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::MerchantCountryAllowed { Country = "xx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCountryAllowed>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::MerchantCountryAllowed { Country = "xx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCountryAllowed>(
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
        var model = new Cards::MerchantCountryAllowed { Country = "xx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::MerchantCountryAllowed { Country = "xx" };

        Cards::MerchantCountryAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MerchantCountryBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::MerchantCountryBlocked { Country = "xx" };

        string expectedCountry = "xx";

        Assert.Equal(expectedCountry, model.Country);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::MerchantCountryBlocked { Country = "xx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCountryBlocked>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::MerchantCountryBlocked { Country = "xx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MerchantCountryBlocked>(
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
        var model = new Cards::MerchantCountryBlocked { Country = "xx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::MerchantCountryBlocked { Country = "xx" };

        Cards::MerchantCountryBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::Usage
        {
            Category = Cards::Category.SingleUse,
            MultiUse = new()
            {
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::Interval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            SingleUse = new(
                new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
            ),
        };

        ApiEnum<string, Cards::Category> expectedCategory = Cards::Category.SingleUse;
        Cards::MultiUse expectedMultiUse = new()
        {
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };
        Cards::SingleUse expectedSingleUse = new(
            new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
        );

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedMultiUse, model.MultiUse);
        Assert.Equal(expectedSingleUse, model.SingleUse);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::Usage
        {
            Category = Cards::Category.SingleUse,
            MultiUse = new()
            {
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::Interval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            SingleUse = new(
                new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::Usage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::Usage
        {
            Category = Cards::Category.SingleUse,
            MultiUse = new()
            {
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::Interval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            SingleUse = new(
                new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::Usage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Cards::Category> expectedCategory = Cards::Category.SingleUse;
        Cards::MultiUse expectedMultiUse = new()
        {
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };
        Cards::SingleUse expectedSingleUse = new(
            new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
        );

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedMultiUse, deserialized.MultiUse);
        Assert.Equal(expectedSingleUse, deserialized.SingleUse);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::Usage
        {
            Category = Cards::Category.SingleUse,
            MultiUse = new()
            {
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::Interval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            SingleUse = new(
                new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cards::Usage { Category = Cards::Category.SingleUse };

        Assert.Null(model.MultiUse);
        Assert.False(model.RawData.ContainsKey("multi_use"));
        Assert.Null(model.SingleUse);
        Assert.False(model.RawData.ContainsKey("single_use"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cards::Usage { Category = Cards::Category.SingleUse };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cards::Usage
        {
            Category = Cards::Category.SingleUse,

            // Null should be interpreted as omitted for these properties
            MultiUse = null,
            SingleUse = null,
        };

        Assert.Null(model.MultiUse);
        Assert.False(model.RawData.ContainsKey("multi_use"));
        Assert.Null(model.SingleUse);
        Assert.False(model.RawData.ContainsKey("single_use"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Cards::Usage
        {
            Category = Cards::Category.SingleUse,

            // Null should be interpreted as omitted for these properties
            MultiUse = null,
            SingleUse = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::Usage
        {
            Category = Cards::Category.SingleUse,
            MultiUse = new()
            {
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::Interval.AllTime,
                        SettlementAmount = 0,
                        MerchantCategoryCodes = [new("x")],
                    },
                ],
            },
            SingleUse = new(
                new Cards::SettlementAmount() { Comparison = Cards::Comparison.Equals, Value = 0 }
            ),
        };

        Cards::Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Cards::Category.SingleUse)]
    [InlineData(Cards::Category.MultiUse)]
    public void Validation_Works(Cards::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cards::Category.SingleUse)]
    [InlineData(Cards::Category.MultiUse)]
    public void SerializationRoundtrip_Works(Cards::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MultiUseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::MultiUse
        {
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        List<Cards::SpendingLimit> expectedSpendingLimits =
        [
            new()
            {
                Interval = Cards::Interval.AllTime,
                SettlementAmount = 0,
                MerchantCategoryCodes = [new("x")],
            },
        ];

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
        var model = new Cards::MultiUse
        {
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MultiUse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::MultiUse
        {
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::MultiUse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Cards::SpendingLimit> expectedSpendingLimits =
        [
            new()
            {
                Interval = Cards::Interval.AllTime,
                SettlementAmount = 0,
                MerchantCategoryCodes = [new("x")],
            },
        ];

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
        var model = new Cards::MultiUse
        {
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::Interval.AllTime,
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
        var model = new Cards::MultiUse { };

        Assert.Null(model.SpendingLimits);
        Assert.False(model.RawData.ContainsKey("spending_limits"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cards::MultiUse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cards::MultiUse
        {
            // Null should be interpreted as omitted for these properties
            SpendingLimits = null,
        };

        Assert.Null(model.SpendingLimits);
        Assert.False(model.RawData.ContainsKey("spending_limits"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Cards::MultiUse
        {
            // Null should be interpreted as omitted for these properties
            SpendingLimits = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::MultiUse
        {
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::Interval.AllTime,
                    SettlementAmount = 0,
                    MerchantCategoryCodes = [new("x")],
                },
            ],
        };

        Cards::MultiUse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SpendingLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        ApiEnum<string, Cards::Interval> expectedInterval = Cards::Interval.AllTime;
        long expectedSettlementAmount = 0;
        List<Cards::SpendingLimitMerchantCategoryCode> expectedMerchantCategoryCodes = [new("x")];

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
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::SpendingLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::SpendingLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Cards::Interval> expectedInterval = Cards::Interval.AllTime;
        long expectedSettlementAmount = 0;
        List<Cards::SpendingLimitMerchantCategoryCode> expectedMerchantCategoryCodes = [new("x")];

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
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
            SettlementAmount = 0,
        };

        Assert.Null(model.MerchantCategoryCodes);
        Assert.False(model.RawData.ContainsKey("merchant_category_codes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
            SettlementAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
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
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
            SettlementAmount = 0,

            // Null should be interpreted as omitted for these properties
            MerchantCategoryCodes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::SpendingLimit
        {
            Interval = Cards::Interval.AllTime,
            SettlementAmount = 0,
            MerchantCategoryCodes = [new("x")],
        };

        Cards::SpendingLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntervalTest : TestBase
{
    [Theory]
    [InlineData(Cards::Interval.AllTime)]
    [InlineData(Cards::Interval.PerTransaction)]
    [InlineData(Cards::Interval.PerDay)]
    [InlineData(Cards::Interval.PerWeek)]
    [InlineData(Cards::Interval.PerMonth)]
    public void Validation_Works(Cards::Interval rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::Interval> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::Interval>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cards::Interval.AllTime)]
    [InlineData(Cards::Interval.PerTransaction)]
    [InlineData(Cards::Interval.PerDay)]
    [InlineData(Cards::Interval.PerWeek)]
    [InlineData(Cards::Interval.PerMonth)]
    public void SerializationRoundtrip_Works(Cards::Interval rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::Interval> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::Interval>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::Interval>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::Interval>>(
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
        var model = new Cards::SpendingLimitMerchantCategoryCode { Code = "x" };

        string expectedCode = "x";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::SpendingLimitMerchantCategoryCode { Code = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::SpendingLimitMerchantCategoryCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::SpendingLimitMerchantCategoryCode { Code = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::SpendingLimitMerchantCategoryCode>(
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
        var model = new Cards::SpendingLimitMerchantCategoryCode { Code = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::SpendingLimitMerchantCategoryCode { Code = "x" };

        Cards::SpendingLimitMerchantCategoryCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SingleUseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::SingleUse
        {
            SettlementAmount = new() { Comparison = Cards::Comparison.Equals, Value = 0 },
        };

        Cards::SettlementAmount expectedSettlementAmount = new()
        {
            Comparison = Cards::Comparison.Equals,
            Value = 0,
        };

        Assert.Equal(expectedSettlementAmount, model.SettlementAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::SingleUse
        {
            SettlementAmount = new() { Comparison = Cards::Comparison.Equals, Value = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::SingleUse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::SingleUse
        {
            SettlementAmount = new() { Comparison = Cards::Comparison.Equals, Value = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::SingleUse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Cards::SettlementAmount expectedSettlementAmount = new()
        {
            Comparison = Cards::Comparison.Equals,
            Value = 0,
        };

        Assert.Equal(expectedSettlementAmount, deserialized.SettlementAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::SingleUse
        {
            SettlementAmount = new() { Comparison = Cards::Comparison.Equals, Value = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::SingleUse
        {
            SettlementAmount = new() { Comparison = Cards::Comparison.Equals, Value = 0 },
        };

        Cards::SingleUse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SettlementAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::SettlementAmount
        {
            Comparison = Cards::Comparison.Equals,
            Value = 0,
        };

        ApiEnum<string, Cards::Comparison> expectedComparison = Cards::Comparison.Equals;
        long expectedValue = 0;

        Assert.Equal(expectedComparison, model.Comparison);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::SettlementAmount
        {
            Comparison = Cards::Comparison.Equals,
            Value = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::SettlementAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::SettlementAmount
        {
            Comparison = Cards::Comparison.Equals,
            Value = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::SettlementAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Cards::Comparison> expectedComparison = Cards::Comparison.Equals;
        long expectedValue = 0;

        Assert.Equal(expectedComparison, deserialized.Comparison);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::SettlementAmount
        {
            Comparison = Cards::Comparison.Equals,
            Value = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::SettlementAmount
        {
            Comparison = Cards::Comparison.Equals,
            Value = 0,
        };

        Cards::SettlementAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComparisonTest : TestBase
{
    [Theory]
    [InlineData(Cards::Comparison.Equals)]
    [InlineData(Cards::Comparison.LessThanOrEquals)]
    public void Validation_Works(Cards::Comparison rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::Comparison> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::Comparison>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cards::Comparison.Equals)]
    [InlineData(Cards::Comparison.LessThanOrEquals)]
    public void SerializationRoundtrip_Works(Cards::Comparison rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::Comparison> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::Comparison>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::Comparison>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::Comparison>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::BillingAddress
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
        var model = new Cards::BillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::BillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::BillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::BillingAddress>(
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
        var model = new Cards::BillingAddress
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
        var model = new Cards::BillingAddress
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
        var model = new Cards::BillingAddress
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
        var model = new Cards::BillingAddress
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
        var model = new Cards::BillingAddress
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
        var model = new Cards::BillingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
        };

        Cards::BillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DigitalWalletTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::DigitalWallet
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
        var model = new Cards::DigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::DigitalWallet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::DigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::DigitalWallet>(
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
        var model = new Cards::DigitalWallet
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
        var model = new Cards::DigitalWallet { };

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
        var model = new Cards::DigitalWallet { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cards::DigitalWallet
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
        var model = new Cards::DigitalWallet
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
        var model = new Cards::DigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "dev@stainless.com",
            Phone = "x",
        };

        Cards::DigitalWallet copied = new(model);

        Assert.Equal(model, copied);
    }
}
