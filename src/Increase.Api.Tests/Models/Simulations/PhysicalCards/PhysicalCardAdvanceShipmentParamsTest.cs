using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.PhysicalCards;

namespace Increase.Api.Tests.Models.Simulations.PhysicalCards;

public class PhysicalCardAdvanceShipmentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCardAdvanceShipmentParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            ShipmentStatus = ShipmentStatus.Shipped,
        };

        string expectedPhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl";
        ApiEnum<string, ShipmentStatus> expectedShipmentStatus = ShipmentStatus.Shipped;

        Assert.Equal(expectedPhysicalCardID, parameters.PhysicalCardID);
        Assert.Equal(expectedShipmentStatus, parameters.ShipmentStatus);
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCardAdvanceShipmentParams parameters = new()
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            ShipmentStatus = ShipmentStatus.Shipped,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/physical_cards/physical_card_ode8duyq5v2ynhjoharl/advance_shipment"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCardAdvanceShipmentParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            ShipmentStatus = ShipmentStatus.Shipped,
        };

        PhysicalCardAdvanceShipmentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ShipmentStatusTest : TestBase
{
    [Theory]
    [InlineData(ShipmentStatus.Pending)]
    [InlineData(ShipmentStatus.Canceled)]
    [InlineData(ShipmentStatus.Submitted)]
    [InlineData(ShipmentStatus.Acknowledged)]
    [InlineData(ShipmentStatus.Rejected)]
    [InlineData(ShipmentStatus.Shipped)]
    [InlineData(ShipmentStatus.Returned)]
    [InlineData(ShipmentStatus.RequiresAttention)]
    public void Validation_Works(ShipmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShipmentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShipmentStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ShipmentStatus.Pending)]
    [InlineData(ShipmentStatus.Canceled)]
    [InlineData(ShipmentStatus.Submitted)]
    [InlineData(ShipmentStatus.Acknowledged)]
    [InlineData(ShipmentStatus.Rejected)]
    [InlineData(ShipmentStatus.Shipped)]
    [InlineData(ShipmentStatus.Returned)]
    [InlineData(ShipmentStatus.RequiresAttention)]
    public void SerializationRoundtrip_Works(ShipmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShipmentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShipmentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShipmentStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShipmentStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
