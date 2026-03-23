using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.CardAuthentications;

namespace Increase.Api.Tests.Models.Simulations.CardAuthentications;

public class CardAuthenticationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardAuthenticationCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Category = Category.PaymentAuthentication,
            DeviceChannel = DeviceChannel.App,
            MerchantAcceptorID = "5665270011000168",
            MerchantCategoryCode = "5734",
            MerchantCountry = "US",
            MerchantName = "x",
            PurchaseAmount = 1000,
        };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        ApiEnum<string, Category> expectedCategory = Category.PaymentAuthentication;
        ApiEnum<string, DeviceChannel> expectedDeviceChannel = DeviceChannel.App;
        string expectedMerchantAcceptorID = "5665270011000168";
        string expectedMerchantCategoryCode = "5734";
        string expectedMerchantCountry = "US";
        string expectedMerchantName = "x";
        long expectedPurchaseAmount = 1000;

        Assert.Equal(expectedCardID, parameters.CardID);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedDeviceChannel, parameters.DeviceChannel);
        Assert.Equal(expectedMerchantAcceptorID, parameters.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, parameters.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCountry, parameters.MerchantCountry);
        Assert.Equal(expectedMerchantName, parameters.MerchantName);
        Assert.Equal(expectedPurchaseAmount, parameters.PurchaseAmount);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardAuthenticationCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.DeviceChannel);
        Assert.False(parameters.RawBodyData.ContainsKey("device_channel"));
        Assert.Null(parameters.MerchantAcceptorID);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_acceptor_id"));
        Assert.Null(parameters.MerchantCategoryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_category_code"));
        Assert.Null(parameters.MerchantCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_country"));
        Assert.Null(parameters.MerchantName);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_name"));
        Assert.Null(parameters.PurchaseAmount);
        Assert.False(parameters.RawBodyData.ContainsKey("purchase_amount"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardAuthenticationCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",

            // Null should be interpreted as omitted for these properties
            Category = null,
            DeviceChannel = null,
            MerchantAcceptorID = null,
            MerchantCategoryCode = null,
            MerchantCountry = null,
            MerchantName = null,
            PurchaseAmount = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawBodyData.ContainsKey("category"));
        Assert.Null(parameters.DeviceChannel);
        Assert.False(parameters.RawBodyData.ContainsKey("device_channel"));
        Assert.Null(parameters.MerchantAcceptorID);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_acceptor_id"));
        Assert.Null(parameters.MerchantCategoryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_category_code"));
        Assert.Null(parameters.MerchantCountry);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_country"));
        Assert.Null(parameters.MerchantName);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_name"));
        Assert.Null(parameters.PurchaseAmount);
        Assert.False(parameters.RawBodyData.ContainsKey("purchase_amount"));
    }

    [Fact]
    public void Url_Works()
    {
        CardAuthenticationCreateParams parameters = new() { CardID = "card_oubs0hwk5rn6knuecxg2" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/simulations/card_authentications"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardAuthenticationCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Category = Category.PaymentAuthentication,
            DeviceChannel = DeviceChannel.App,
            MerchantAcceptorID = "5665270011000168",
            MerchantCategoryCode = "5734",
            MerchantCountry = "US",
            MerchantName = "x",
            PurchaseAmount = 1000,
        };

        CardAuthenticationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.PaymentAuthentication)]
    [InlineData(Category.NonPaymentAuthentication)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.PaymentAuthentication)]
    [InlineData(Category.NonPaymentAuthentication)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DeviceChannelTest : TestBase
{
    [Theory]
    [InlineData(DeviceChannel.App)]
    [InlineData(DeviceChannel.Browser)]
    [InlineData(DeviceChannel.ThreeDSRequestorInitiated)]
    public void Validation_Works(DeviceChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeviceChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeviceChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DeviceChannel.App)]
    [InlineData(DeviceChannel.Browser)]
    [InlineData(DeviceChannel.ThreeDSRequestorInitiated)]
    public void SerializationRoundtrip_Works(DeviceChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DeviceChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeviceChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DeviceChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DeviceChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
