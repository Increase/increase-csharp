using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Cards = Increase.Api.Models.Cards;

namespace Increase.Api.Tests.Models.Cards;

public class CardListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cards::CardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_oubs0hwk5rn6knuecxg2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AuthorizationControls = new()
                    {
                        MerchantAcceptorIdentifier = new()
                        {
                            Allowed = [new("identifier")],
                            Blocked = [new("identifier")],
                        },
                        MerchantCategoryCode = new()
                        {
                            Allowed = [new("code")],
                            Blocked = [new("code")],
                        },
                        MerchantCountry = new()
                        {
                            Allowed = [new("country")],
                            Blocked = [new("country")],
                        },
                        Usage = new()
                        {
                            Category = Cards::CardAuthorizationControlsUsageCategory.SingleUse,
                            MultiUse = new(
                                [
                                    new()
                                    {
                                        Interval =
                                            Cards::CardAuthorizationControlsUsageMultiUseSpendingLimitInterval.AllTime,
                                        MerchantCategoryCodes = [new("code")],
                                        SettlementAmount = 0,
                                    },
                                ]
                            ),
                            SingleUse = new(
                                new Cards::CardAuthorizationControlsUsageSingleUseSettlementAmount()
                                {
                                    Comparison =
                                        Cards::CardAuthorizationControlsUsageSingleUseSettlementAmountComparison.Equals,
                                    Value = 0,
                                }
                            ),
                        },
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Cards::Card> expectedData =
        [
            new()
            {
                ID = "card_oubs0hwk5rn6knuecxg2",
                AccountID = "account_in71c4amph0vgo2qllky",
                AuthorizationControls = new()
                {
                    MerchantAcceptorIdentifier = new()
                    {
                        Allowed = [new("identifier")],
                        Blocked = [new("identifier")],
                    },
                    MerchantCategoryCode = new()
                    {
                        Allowed = [new("code")],
                        Blocked = [new("code")],
                    },
                    MerchantCountry = new()
                    {
                        Allowed = [new("country")],
                        Blocked = [new("country")],
                    },
                    Usage = new()
                    {
                        Category = Cards::CardAuthorizationControlsUsageCategory.SingleUse,
                        MultiUse = new(
                            [
                                new()
                                {
                                    Interval =
                                        Cards::CardAuthorizationControlsUsageMultiUseSpendingLimitInterval.AllTime,
                                    MerchantCategoryCodes = [new("code")],
                                    SettlementAmount = 0,
                                },
                            ]
                        ),
                        SingleUse = new(
                            new Cards::CardAuthorizationControlsUsageSingleUseSettlementAmount()
                            {
                                Comparison =
                                    Cards::CardAuthorizationControlsUsageSingleUseSettlementAmountComparison.Equals,
                                Value = 0,
                            }
                        ),
                    },
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cards::CardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_oubs0hwk5rn6knuecxg2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AuthorizationControls = new()
                    {
                        MerchantAcceptorIdentifier = new()
                        {
                            Allowed = [new("identifier")],
                            Blocked = [new("identifier")],
                        },
                        MerchantCategoryCode = new()
                        {
                            Allowed = [new("code")],
                            Blocked = [new("code")],
                        },
                        MerchantCountry = new()
                        {
                            Allowed = [new("country")],
                            Blocked = [new("country")],
                        },
                        Usage = new()
                        {
                            Category = Cards::CardAuthorizationControlsUsageCategory.SingleUse,
                            MultiUse = new(
                                [
                                    new()
                                    {
                                        Interval =
                                            Cards::CardAuthorizationControlsUsageMultiUseSpendingLimitInterval.AllTime,
                                        MerchantCategoryCodes = [new("code")],
                                        SettlementAmount = 0,
                                    },
                                ]
                            ),
                            SingleUse = new(
                                new Cards::CardAuthorizationControlsUsageSingleUseSettlementAmount()
                                {
                                    Comparison =
                                        Cards::CardAuthorizationControlsUsageSingleUseSettlementAmountComparison.Equals,
                                    Value = 0,
                                }
                            ),
                        },
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::CardListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cards::CardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_oubs0hwk5rn6knuecxg2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AuthorizationControls = new()
                    {
                        MerchantAcceptorIdentifier = new()
                        {
                            Allowed = [new("identifier")],
                            Blocked = [new("identifier")],
                        },
                        MerchantCategoryCode = new()
                        {
                            Allowed = [new("code")],
                            Blocked = [new("code")],
                        },
                        MerchantCountry = new()
                        {
                            Allowed = [new("country")],
                            Blocked = [new("country")],
                        },
                        Usage = new()
                        {
                            Category = Cards::CardAuthorizationControlsUsageCategory.SingleUse,
                            MultiUse = new(
                                [
                                    new()
                                    {
                                        Interval =
                                            Cards::CardAuthorizationControlsUsageMultiUseSpendingLimitInterval.AllTime,
                                        MerchantCategoryCodes = [new("code")],
                                        SettlementAmount = 0,
                                    },
                                ]
                            ),
                            SingleUse = new(
                                new Cards::CardAuthorizationControlsUsageSingleUseSettlementAmount()
                                {
                                    Comparison =
                                        Cards::CardAuthorizationControlsUsageSingleUseSettlementAmountComparison.Equals,
                                    Value = 0,
                                }
                            ),
                        },
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cards::CardListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Cards::Card> expectedData =
        [
            new()
            {
                ID = "card_oubs0hwk5rn6knuecxg2",
                AccountID = "account_in71c4amph0vgo2qllky",
                AuthorizationControls = new()
                {
                    MerchantAcceptorIdentifier = new()
                    {
                        Allowed = [new("identifier")],
                        Blocked = [new("identifier")],
                    },
                    MerchantCategoryCode = new()
                    {
                        Allowed = [new("code")],
                        Blocked = [new("code")],
                    },
                    MerchantCountry = new()
                    {
                        Allowed = [new("country")],
                        Blocked = [new("country")],
                    },
                    Usage = new()
                    {
                        Category = Cards::CardAuthorizationControlsUsageCategory.SingleUse,
                        MultiUse = new(
                            [
                                new()
                                {
                                    Interval =
                                        Cards::CardAuthorizationControlsUsageMultiUseSpendingLimitInterval.AllTime,
                                    MerchantCategoryCodes = [new("code")],
                                    SettlementAmount = 0,
                                },
                            ]
                        ),
                        SingleUse = new(
                            new Cards::CardAuthorizationControlsUsageSingleUseSettlementAmount()
                            {
                                Comparison =
                                    Cards::CardAuthorizationControlsUsageSingleUseSettlementAmountComparison.Equals,
                                Value = 0,
                            }
                        ),
                    },
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
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cards::CardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_oubs0hwk5rn6knuecxg2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AuthorizationControls = new()
                    {
                        MerchantAcceptorIdentifier = new()
                        {
                            Allowed = [new("identifier")],
                            Blocked = [new("identifier")],
                        },
                        MerchantCategoryCode = new()
                        {
                            Allowed = [new("code")],
                            Blocked = [new("code")],
                        },
                        MerchantCountry = new()
                        {
                            Allowed = [new("country")],
                            Blocked = [new("country")],
                        },
                        Usage = new()
                        {
                            Category = Cards::CardAuthorizationControlsUsageCategory.SingleUse,
                            MultiUse = new(
                                [
                                    new()
                                    {
                                        Interval =
                                            Cards::CardAuthorizationControlsUsageMultiUseSpendingLimitInterval.AllTime,
                                        MerchantCategoryCodes = [new("code")],
                                        SettlementAmount = 0,
                                    },
                                ]
                            ),
                            SingleUse = new(
                                new Cards::CardAuthorizationControlsUsageSingleUseSettlementAmount()
                                {
                                    Comparison =
                                        Cards::CardAuthorizationControlsUsageSingleUseSettlementAmountComparison.Equals,
                                    Value = 0,
                                }
                            ),
                        },
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cards::CardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "card_oubs0hwk5rn6knuecxg2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AuthorizationControls = new()
                    {
                        MerchantAcceptorIdentifier = new()
                        {
                            Allowed = [new("identifier")],
                            Blocked = [new("identifier")],
                        },
                        MerchantCategoryCode = new()
                        {
                            Allowed = [new("code")],
                            Blocked = [new("code")],
                        },
                        MerchantCountry = new()
                        {
                            Allowed = [new("country")],
                            Blocked = [new("country")],
                        },
                        Usage = new()
                        {
                            Category = Cards::CardAuthorizationControlsUsageCategory.SingleUse,
                            MultiUse = new(
                                [
                                    new()
                                    {
                                        Interval =
                                            Cards::CardAuthorizationControlsUsageMultiUseSpendingLimitInterval.AllTime,
                                        MerchantCategoryCodes = [new("code")],
                                        SettlementAmount = 0,
                                    },
                                ]
                            ),
                            SingleUse = new(
                                new Cards::CardAuthorizationControlsUsageSingleUseSettlementAmount()
                                {
                                    Comparison =
                                        Cards::CardAuthorizationControlsUsageSingleUseSettlementAmountComparison.Equals,
                                    Value = 0,
                                }
                            ),
                        },
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
                },
            ],
            NextCursor = "v57w5d",
        };

        Cards::CardListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
