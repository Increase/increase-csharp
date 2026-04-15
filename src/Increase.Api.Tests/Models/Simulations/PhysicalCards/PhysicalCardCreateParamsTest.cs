using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.PhysicalCards;

namespace Increase.Api.Tests.Models.Simulations.PhysicalCards;

public class PhysicalCardCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCardCreateParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            Category = Category.Delivered,
            CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            City = "New York",
            PostalCode = "10045",
            State = "NY",
        };

        string expectedPhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl";
        ApiEnum<string, Category> expectedCategory = Category.Delivered;
        DateTimeOffset expectedCarrierEstimatedDeliveryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedCity = "New York";
        string expectedPostalCode = "10045";
        string expectedState = "NY";

        Assert.Equal(expectedPhysicalCardID, parameters.PhysicalCardID);
        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedCarrierEstimatedDeliveryAt, parameters.CarrierEstimatedDeliveryAt);
        Assert.Equal(expectedCity, parameters.City);
        Assert.Equal(expectedPostalCode, parameters.PostalCode);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhysicalCardCreateParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            Category = Category.Delivered,
        };

        Assert.Null(parameters.CarrierEstimatedDeliveryAt);
        Assert.False(parameters.RawBodyData.ContainsKey("carrier_estimated_delivery_at"));
        Assert.Null(parameters.City);
        Assert.False(parameters.RawBodyData.ContainsKey("city"));
        Assert.Null(parameters.PostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("postal_code"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhysicalCardCreateParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            Category = Category.Delivered,

            // Null should be interpreted as omitted for these properties
            CarrierEstimatedDeliveryAt = null,
            City = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(parameters.CarrierEstimatedDeliveryAt);
        Assert.False(parameters.RawBodyData.ContainsKey("carrier_estimated_delivery_at"));
        Assert.Null(parameters.City);
        Assert.False(parameters.RawBodyData.ContainsKey("city"));
        Assert.Null(parameters.PostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("postal_code"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCardCreateParams parameters = new()
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            Category = Category.Delivered,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/physical_cards/physical_card_ode8duyq5v2ynhjoharl/tracking_updates"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCardCreateParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            Category = Category.Delivered,
            CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            City = "New York",
            PostalCode = "10045",
            State = "NY",
        };

        PhysicalCardCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.InTransit)]
    [InlineData(Category.ProcessedForDelivery)]
    [InlineData(Category.Delivered)]
    [InlineData(Category.DeliveryIssue)]
    [InlineData(Category.ReturnedToSender)]
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
    [InlineData(Category.InTransit)]
    [InlineData(Category.ProcessedForDelivery)]
    [InlineData(Category.Delivered)]
    [InlineData(Category.DeliveryIssue)]
    [InlineData(Category.ReturnedToSender)]
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
