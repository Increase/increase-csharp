using System;
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
            BillingAddress = null,
            Description = null,
            DigitalWallet = null,
            EntityID = null,
            Status = null,
        };

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
