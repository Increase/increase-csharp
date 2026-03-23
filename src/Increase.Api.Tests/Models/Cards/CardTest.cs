using System;
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
