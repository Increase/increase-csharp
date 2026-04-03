using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Cards = Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::Card
        {
            ID = "card_oubs0hwk5rn6knuecxg2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AuthorizationControls = new()
            {
                MaximumAuthorizationCount = new(0),
                MerchantAcceptorIdentifier = new()
                {
                    Allowed = [new("identifier")],
                    Blocked = [new("identifier")],
                },
                MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
                MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                        MerchantCategoryCodes = [new("code")],
                        SettlementAmount = 0,
                    },
                ],
            },
            BillingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = "NY",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Office Expenses",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
                Email = "user@example.com",
                Phone = "+16505046304",
            },
            EntityID = null,
            ExpirationMonth = 11,
            ExpirationYear = 2028,
            IdempotencyKey = null,
            Last4 = "4242",
            Status = Cards::CardStatus.Active,
            Type = Cards::Type.Card,
        };

        string expectedID = "card_oubs0hwk5rn6knuecxg2";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        Cards::CardAuthorizationControls expectedAuthorizationControls = new()
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new()
            {
                Allowed = [new("identifier")],
                Blocked = [new("identifier")],
            },
            MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
            MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                    MerchantCategoryCodes = [new("code")],
                    SettlementAmount = 0,
                },
            ],
        };
        Cards::CardBillingAddress expectedBillingAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Office Expenses";
        Cards::CardDigitalWallet expectedDigitalWallet = new()
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
            Email = "user@example.com",
            Phone = "+16505046304",
        };
        long expectedExpirationMonth = 11;
        long expectedExpirationYear = 2028;
        string expectedLast4 = "4242";
        ApiEnum<string, Cards::CardStatus> expectedStatus = Cards::CardStatus.Active;
        ApiEnum<string, Cards::Type> expectedType = Cards::Type.Card;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAuthorizationControls, model.AuthorizationControls);
        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDigitalWallet, model.DigitalWallet);
        Assert.Null(model.EntityID);
        Assert.Equal(expectedExpirationMonth, model.ExpirationMonth);
        Assert.Equal(expectedExpirationYear, model.ExpirationYear);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedLast4, model.Last4);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::Card
        {
            ID = "card_oubs0hwk5rn6knuecxg2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AuthorizationControls = new()
            {
                MaximumAuthorizationCount = new(0),
                MerchantAcceptorIdentifier = new()
                {
                    Allowed = [new("identifier")],
                    Blocked = [new("identifier")],
                },
                MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
                MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                        MerchantCategoryCodes = [new("code")],
                        SettlementAmount = 0,
                    },
                ],
            },
            BillingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = "NY",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Office Expenses",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
                Email = "user@example.com",
                Phone = "+16505046304",
            },
            EntityID = null,
            ExpirationMonth = 11,
            ExpirationYear = 2028,
            IdempotencyKey = null,
            Last4 = "4242",
            Status = Cards::CardStatus.Active,
            Type = Cards::Type.Card,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::Card>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::Card
        {
            ID = "card_oubs0hwk5rn6knuecxg2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AuthorizationControls = new()
            {
                MaximumAuthorizationCount = new(0),
                MerchantAcceptorIdentifier = new()
                {
                    Allowed = [new("identifier")],
                    Blocked = [new("identifier")],
                },
                MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
                MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                        MerchantCategoryCodes = [new("code")],
                        SettlementAmount = 0,
                    },
                ],
            },
            BillingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = "NY",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Office Expenses",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
                Email = "user@example.com",
                Phone = "+16505046304",
            },
            EntityID = null,
            ExpirationMonth = 11,
            ExpirationYear = 2028,
            IdempotencyKey = null,
            Last4 = "4242",
            Status = Cards::CardStatus.Active,
            Type = Cards::Type.Card,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::Card>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "card_oubs0hwk5rn6knuecxg2";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        Cards::CardAuthorizationControls expectedAuthorizationControls = new()
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new()
            {
                Allowed = [new("identifier")],
                Blocked = [new("identifier")],
            },
            MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
            MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                    MerchantCategoryCodes = [new("code")],
                    SettlementAmount = 0,
                },
            ],
        };
        Cards::CardBillingAddress expectedBillingAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedDescription = "Office Expenses";
        Cards::CardDigitalWallet expectedDigitalWallet = new()
        {
            DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
            Email = "user@example.com",
            Phone = "+16505046304",
        };
        long expectedExpirationMonth = 11;
        long expectedExpirationYear = 2028;
        string expectedLast4 = "4242";
        ApiEnum<string, Cards::CardStatus> expectedStatus = Cards::CardStatus.Active;
        ApiEnum<string, Cards::Type> expectedType = Cards::Type.Card;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAuthorizationControls, deserialized.AuthorizationControls);
        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDigitalWallet, deserialized.DigitalWallet);
        Assert.Null(deserialized.EntityID);
        Assert.Equal(expectedExpirationMonth, deserialized.ExpirationMonth);
        Assert.Equal(expectedExpirationYear, deserialized.ExpirationYear);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedLast4, deserialized.Last4);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::Card
        {
            ID = "card_oubs0hwk5rn6knuecxg2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AuthorizationControls = new()
            {
                MaximumAuthorizationCount = new(0),
                MerchantAcceptorIdentifier = new()
                {
                    Allowed = [new("identifier")],
                    Blocked = [new("identifier")],
                },
                MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
                MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                        MerchantCategoryCodes = [new("code")],
                        SettlementAmount = 0,
                    },
                ],
            },
            BillingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = "NY",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Office Expenses",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
                Email = "user@example.com",
                Phone = "+16505046304",
            },
            EntityID = null,
            ExpirationMonth = 11,
            ExpirationYear = 2028,
            IdempotencyKey = null,
            Last4 = "4242",
            Status = Cards::CardStatus.Active,
            Type = Cards::Type.Card,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::Card
        {
            ID = "card_oubs0hwk5rn6knuecxg2",
            AccountID = "account_in71c4amph0vgo2qllky",
            AuthorizationControls = new()
            {
                MaximumAuthorizationCount = new(0),
                MerchantAcceptorIdentifier = new()
                {
                    Allowed = [new("identifier")],
                    Blocked = [new("identifier")],
                },
                MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
                MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
                SpendingLimits =
                [
                    new()
                    {
                        Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                        MerchantCategoryCodes = [new("code")],
                        SettlementAmount = 0,
                    },
                ],
            },
            BillingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                PostalCode = "10045",
                State = "NY",
            },
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Description = "Office Expenses",
            DigitalWallet = new()
            {
                DigitalCardProfileID = "digital_card_profile_s3puplu90f04xhcwkiga",
                Email = "user@example.com",
                Phone = "+16505046304",
            },
            EntityID = null,
            ExpirationMonth = 11,
            ExpirationYear = 2028,
            IdempotencyKey = null,
            Last4 = "4242",
            Status = Cards::CardStatus.Active,
            Type = Cards::Type.Card,
        };

        Cards::Card copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new()
            {
                Allowed = [new("identifier")],
                Blocked = [new("identifier")],
            },
            MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
            MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                    MerchantCategoryCodes = [new("code")],
                    SettlementAmount = 0,
                },
            ],
        };

        Cards::CardAuthorizationControlsMaximumAuthorizationCount expectedMaximumAuthorizationCount =
            new(0);
        Cards::CardAuthorizationControlsMerchantAcceptorIdentifier expectedMerchantAcceptorIdentifier =
            new() { Allowed = [new("identifier")], Blocked = [new("identifier")] };
        Cards::CardAuthorizationControlsMerchantCategoryCode expectedMerchantCategoryCode = new()
        {
            Allowed = [new("code")],
            Blocked = [new("code")],
        };
        Cards::CardAuthorizationControlsMerchantCountry expectedMerchantCountry = new()
        {
            Allowed = [new("country")],
            Blocked = [new("country")],
        };
        List<Cards::CardAuthorizationControlsSpendingLimit> expectedSpendingLimits =
        [
            new()
            {
                Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                MerchantCategoryCodes = [new("code")],
                SettlementAmount = 0,
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
        var model = new Cards::CardAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new()
            {
                Allowed = [new("identifier")],
                Blocked = [new("identifier")],
            },
            MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
            MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                    MerchantCategoryCodes = [new("code")],
                    SettlementAmount = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::CardAuthorizationControls>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new()
            {
                Allowed = [new("identifier")],
                Blocked = [new("identifier")],
            },
            MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
            MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                    MerchantCategoryCodes = [new("code")],
                    SettlementAmount = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::CardAuthorizationControls>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Cards::CardAuthorizationControlsMaximumAuthorizationCount expectedMaximumAuthorizationCount =
            new(0);
        Cards::CardAuthorizationControlsMerchantAcceptorIdentifier expectedMerchantAcceptorIdentifier =
            new() { Allowed = [new("identifier")], Blocked = [new("identifier")] };
        Cards::CardAuthorizationControlsMerchantCategoryCode expectedMerchantCategoryCode = new()
        {
            Allowed = [new("code")],
            Blocked = [new("code")],
        };
        Cards::CardAuthorizationControlsMerchantCountry expectedMerchantCountry = new()
        {
            Allowed = [new("country")],
            Blocked = [new("country")],
        };
        List<Cards::CardAuthorizationControlsSpendingLimit> expectedSpendingLimits =
        [
            new()
            {
                Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                MerchantCategoryCodes = [new("code")],
                SettlementAmount = 0,
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
        var model = new Cards::CardAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new()
            {
                Allowed = [new("identifier")],
                Blocked = [new("identifier")],
            },
            MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
            MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                    MerchantCategoryCodes = [new("code")],
                    SettlementAmount = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControls
        {
            MaximumAuthorizationCount = new(0),
            MerchantAcceptorIdentifier = new()
            {
                Allowed = [new("identifier")],
                Blocked = [new("identifier")],
            },
            MerchantCategoryCode = new() { Allowed = [new("code")], Blocked = [new("code")] },
            MerchantCountry = new() { Allowed = [new("country")], Blocked = [new("country")] },
            SpendingLimits =
            [
                new()
                {
                    Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
                    MerchantCategoryCodes = [new("code")],
                    SettlementAmount = 0,
                },
            ],
        };

        Cards::CardAuthorizationControls copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMaximumAuthorizationCountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMaximumAuthorizationCount { AllTime = 0 };

        long expectedAllTime = 0;

        Assert.Equal(expectedAllTime, model.AllTime);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMaximumAuthorizationCount { AllTime = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMaximumAuthorizationCount>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMaximumAuthorizationCount { AllTime = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMaximumAuthorizationCount>(
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
        var model = new Cards::CardAuthorizationControlsMaximumAuthorizationCount { AllTime = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMaximumAuthorizationCount { AllTime = 0 };

        Cards::CardAuthorizationControlsMaximumAuthorizationCount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantAcceptorIdentifierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("identifier")],
            Blocked = [new("identifier")],
        };

        List<Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed> expectedAllowed =
        [
            new("identifier"),
        ];
        List<Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked> expectedBlocked =
        [
            new("identifier"),
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
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("identifier")],
            Blocked = [new("identifier")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantAcceptorIdentifier>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("identifier")],
            Blocked = [new("identifier")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantAcceptorIdentifier>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed> expectedAllowed =
        [
            new("identifier"),
        ];
        List<Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked> expectedBlocked =
        [
            new("identifier"),
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
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("identifier")],
            Blocked = [new("identifier")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifier
        {
            Allowed = [new("identifier")],
            Blocked = [new("identifier")],
        };

        Cards::CardAuthorizationControlsMerchantAcceptorIdentifier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantAcceptorIdentifierAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "identifier",
        };

        string expectedIdentifier = "identifier";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "identifier",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "identifier",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedIdentifier = "identifier";

        Assert.Equal(expectedIdentifier, deserialized.Identifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "identifier",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed
        {
            Identifier = "identifier",
        };

        Cards::CardAuthorizationControlsMerchantAcceptorIdentifierAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantAcceptorIdentifierBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "identifier",
        };

        string expectedIdentifier = "identifier";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "identifier",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "identifier",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedIdentifier = "identifier";

        Assert.Equal(expectedIdentifier, deserialized.Identifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "identifier",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked
        {
            Identifier = "identifier",
        };

        Cards::CardAuthorizationControlsMerchantAcceptorIdentifierBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantCategoryCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("code")],
            Blocked = [new("code")],
        };

        List<Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed> expectedAllowed =
        [
            new("code"),
        ];
        List<Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked> expectedBlocked =
        [
            new("code"),
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
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("code")],
            Blocked = [new("code")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCategoryCode>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("code")],
            Blocked = [new("code")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCategoryCode>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed> expectedAllowed =
        [
            new("code"),
        ];
        List<Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked> expectedBlocked =
        [
            new("code"),
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
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("code")],
            Blocked = [new("code")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCode
        {
            Allowed = [new("code")],
            Blocked = [new("code")],
        };

        Cards::CardAuthorizationControlsMerchantCategoryCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantCategoryCodeAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "code",
        };

        string expectedCode = "code";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "code",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "code",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCode = "code";

        Assert.Equal(expectedCode, deserialized.Code);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "code",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed
        {
            Code = "code",
        };

        Cards::CardAuthorizationControlsMerchantCategoryCodeAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantCategoryCodeBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "code",
        };

        string expectedCode = "code";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "code",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "code",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCode = "code";

        Assert.Equal(expectedCode, deserialized.Code);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "code",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked
        {
            Code = "code",
        };

        Cards::CardAuthorizationControlsMerchantCategoryCodeBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantCountryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountry
        {
            Allowed = [new("country")],
            Blocked = [new("country")],
        };

        List<Cards::CardAuthorizationControlsMerchantCountryAllowed> expectedAllowed =
        [
            new("country"),
        ];
        List<Cards::CardAuthorizationControlsMerchantCountryBlocked> expectedBlocked =
        [
            new("country"),
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
        var model = new Cards::CardAuthorizationControlsMerchantCountry
        {
            Allowed = [new("country")],
            Blocked = [new("country")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCountry>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountry
        {
            Allowed = [new("country")],
            Blocked = [new("country")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCountry>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<Cards::CardAuthorizationControlsMerchantCountryAllowed> expectedAllowed =
        [
            new("country"),
        ];
        List<Cards::CardAuthorizationControlsMerchantCountryBlocked> expectedBlocked =
        [
            new("country"),
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
        var model = new Cards::CardAuthorizationControlsMerchantCountry
        {
            Allowed = [new("country")],
            Blocked = [new("country")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountry
        {
            Allowed = [new("country")],
            Blocked = [new("country")],
        };

        Cards::CardAuthorizationControlsMerchantCountry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantCountryAllowedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryAllowed
        {
            Country = "country",
        };

        string expectedCountry = "country";

        Assert.Equal(expectedCountry, model.Country);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryAllowed
        {
            Country = "country",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCountryAllowed>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryAllowed
        {
            Country = "country",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCountryAllowed>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCountry = "country";

        Assert.Equal(expectedCountry, deserialized.Country);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryAllowed
        {
            Country = "country",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryAllowed
        {
            Country = "country",
        };

        Cards::CardAuthorizationControlsMerchantCountryAllowed copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsMerchantCountryBlockedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryBlocked
        {
            Country = "country",
        };

        string expectedCountry = "country";

        Assert.Equal(expectedCountry, model.Country);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryBlocked
        {
            Country = "country",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCountryBlocked>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryBlocked
        {
            Country = "country",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsMerchantCountryBlocked>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCountry = "country";

        Assert.Equal(expectedCountry, deserialized.Country);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryBlocked
        {
            Country = "country",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsMerchantCountryBlocked
        {
            Country = "country",
        };

        Cards::CardAuthorizationControlsMerchantCountryBlocked copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsSpendingLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimit
        {
            Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
            MerchantCategoryCodes = [new("code")],
            SettlementAmount = 0,
        };

        ApiEnum<string, Cards::CardAuthorizationControlsSpendingLimitInterval> expectedInterval =
            Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime;
        List<Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode> expectedMerchantCategoryCodes =
        [
            new("code"),
        ];
        long expectedSettlementAmount = 0;

        Assert.Equal(expectedInterval, model.Interval);
        Assert.NotNull(model.MerchantCategoryCodes);
        Assert.Equal(expectedMerchantCategoryCodes.Count, model.MerchantCategoryCodes.Count);
        for (int i = 0; i < expectedMerchantCategoryCodes.Count; i++)
        {
            Assert.Equal(expectedMerchantCategoryCodes[i], model.MerchantCategoryCodes[i]);
        }
        Assert.Equal(expectedSettlementAmount, model.SettlementAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimit
        {
            Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
            MerchantCategoryCodes = [new("code")],
            SettlementAmount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsSpendingLimit>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimit
        {
            Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
            MerchantCategoryCodes = [new("code")],
            SettlementAmount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsSpendingLimit>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, Cards::CardAuthorizationControlsSpendingLimitInterval> expectedInterval =
            Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime;
        List<Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode> expectedMerchantCategoryCodes =
        [
            new("code"),
        ];
        long expectedSettlementAmount = 0;

        Assert.Equal(expectedInterval, deserialized.Interval);
        Assert.NotNull(deserialized.MerchantCategoryCodes);
        Assert.Equal(expectedMerchantCategoryCodes.Count, deserialized.MerchantCategoryCodes.Count);
        for (int i = 0; i < expectedMerchantCategoryCodes.Count; i++)
        {
            Assert.Equal(expectedMerchantCategoryCodes[i], deserialized.MerchantCategoryCodes[i]);
        }
        Assert.Equal(expectedSettlementAmount, deserialized.SettlementAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimit
        {
            Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
            MerchantCategoryCodes = [new("code")],
            SettlementAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimit
        {
            Interval = Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime,
            MerchantCategoryCodes = [new("code")],
            SettlementAmount = 0,
        };

        Cards::CardAuthorizationControlsSpendingLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardAuthorizationControlsSpendingLimitIntervalTest : TestBase
{
    [Theory]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime)]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.PerTransaction)]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.PerDay)]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.PerWeek)]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.PerMonth)]
    public void Validation_Works(Cards::CardAuthorizationControlsSpendingLimitInterval rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::CardAuthorizationControlsSpendingLimitInterval> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Cards::CardAuthorizationControlsSpendingLimitInterval>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.AllTime)]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.PerTransaction)]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.PerDay)]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.PerWeek)]
    [InlineData(Cards::CardAuthorizationControlsSpendingLimitInterval.PerMonth)]
    public void SerializationRoundtrip_Works(
        Cards::CardAuthorizationControlsSpendingLimitInterval rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::CardAuthorizationControlsSpendingLimitInterval> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Cards::CardAuthorizationControlsSpendingLimitInterval>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Cards::CardAuthorizationControlsSpendingLimitInterval>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Cards::CardAuthorizationControlsSpendingLimitInterval>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardAuthorizationControlsSpendingLimitMerchantCategoryCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "code",
        };

        string expectedCode = "code";

        Assert.Equal(expectedCode, model.Code);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "code",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "code",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCode = "code";

        Assert.Equal(expectedCode, deserialized.Code);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "code",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode
        {
            Code = "code",
        };

        Cards::CardAuthorizationControlsSpendingLimitMerchantCategoryCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardBillingAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedPostalCode = "10045";
        string expectedState = "NY";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Null(model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardBillingAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::CardBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardBillingAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::CardBillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "New York";
        string expectedLine1 = "33 Liberty Street";
        string expectedPostalCode = "10045";
        string expectedState = "NY";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Null(deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardBillingAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardBillingAddress
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };

        Cards::CardBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardDigitalWalletTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "email",
            Phone = "phone",
        };

        string expectedDigitalCardProfileID = "digital_card_profile_id";
        string expectedEmail = "email";
        string expectedPhone = "phone";

        Assert.Equal(expectedDigitalCardProfileID, model.DigitalCardProfileID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "email",
            Phone = "phone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::CardDigitalWallet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "email",
            Phone = "phone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::CardDigitalWallet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDigitalCardProfileID = "digital_card_profile_id";
        string expectedEmail = "email";
        string expectedPhone = "phone";

        Assert.Equal(expectedDigitalCardProfileID, deserialized.DigitalCardProfileID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "email",
            Phone = "phone",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardDigitalWallet
        {
            DigitalCardProfileID = "digital_card_profile_id",
            Email = "email",
            Phone = "phone",
        };

        Cards::CardDigitalWallet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardStatusTest : TestBase
{
    [Theory]
    [InlineData(Cards::CardStatus.Active)]
    [InlineData(Cards::CardStatus.Disabled)]
    [InlineData(Cards::CardStatus.Canceled)]
    public void Validation_Works(Cards::CardStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::CardStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::CardStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cards::CardStatus.Active)]
    [InlineData(Cards::CardStatus.Disabled)]
    [InlineData(Cards::CardStatus.Canceled)]
    public void SerializationRoundtrip_Works(Cards::CardStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::CardStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::CardStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::CardStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::CardStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Cards::Type.Card)]
    public void Validation_Works(Cards::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cards::Type.Card)]
    public void SerializationRoundtrip_Works(Cards::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cards::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cards::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cards::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
