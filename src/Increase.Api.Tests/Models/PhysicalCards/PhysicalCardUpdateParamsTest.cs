using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Tests.Models.PhysicalCards;

public class PhysicalCardUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCardUpdateParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            Status = Status.Disabled,
        };

        string expectedPhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl";
        ApiEnum<string, Status> expectedStatus = Status.Disabled;

        Assert.Equal(expectedPhysicalCardID, parameters.PhysicalCardID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCardUpdateParams parameters = new()
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            Status = Status.Disabled,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/physical_cards/physical_card_ode8duyq5v2ynhjoharl"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCardUpdateParams
        {
            PhysicalCardID = "physical_card_ode8duyq5v2ynhjoharl",
            Status = Status.Disabled,
        };

        PhysicalCardUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
