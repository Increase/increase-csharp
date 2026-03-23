using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.RoutingNumbers;

namespace Increase.Api.Tests.Models.RoutingNumbers;

public class RoutingNumberListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RoutingNumberListResponse
        {
            AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
            FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
            Name = "First Bank of the United States",
            RealTimePaymentsTransfers =
                RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
            RoutingNumber = "021000021",
            Type = Type.RoutingNumber,
            WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
        };

        ApiEnum<string, RoutingNumberListResponseAchTransfers> expectedAchTransfers =
            RoutingNumberListResponseAchTransfers.Supported;
        ApiEnum<string, RoutingNumberListResponseFednowTransfers> expectedFednowTransfers =
            RoutingNumberListResponseFednowTransfers.Supported;
        string expectedName = "First Bank of the United States";
        ApiEnum<
            string,
            RoutingNumberListResponseRealTimePaymentsTransfers
        > expectedRealTimePaymentsTransfers =
            RoutingNumberListResponseRealTimePaymentsTransfers.Supported;
        string expectedRoutingNumber = "021000021";
        ApiEnum<string, Type> expectedType = Type.RoutingNumber;
        ApiEnum<string, RoutingNumberListResponseWireTransfers> expectedWireTransfers =
            RoutingNumberListResponseWireTransfers.Supported;

        Assert.Equal(expectedAchTransfers, model.AchTransfers);
        Assert.Equal(expectedFednowTransfers, model.FednowTransfers);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRealTimePaymentsTransfers, model.RealTimePaymentsTransfers);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWireTransfers, model.WireTransfers);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RoutingNumberListResponse
        {
            AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
            FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
            Name = "First Bank of the United States",
            RealTimePaymentsTransfers =
                RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
            RoutingNumber = "021000021",
            Type = Type.RoutingNumber,
            WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingNumberListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RoutingNumberListResponse
        {
            AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
            FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
            Name = "First Bank of the United States",
            RealTimePaymentsTransfers =
                RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
            RoutingNumber = "021000021",
            Type = Type.RoutingNumber,
            WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingNumberListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RoutingNumberListResponseAchTransfers> expectedAchTransfers =
            RoutingNumberListResponseAchTransfers.Supported;
        ApiEnum<string, RoutingNumberListResponseFednowTransfers> expectedFednowTransfers =
            RoutingNumberListResponseFednowTransfers.Supported;
        string expectedName = "First Bank of the United States";
        ApiEnum<
            string,
            RoutingNumberListResponseRealTimePaymentsTransfers
        > expectedRealTimePaymentsTransfers =
            RoutingNumberListResponseRealTimePaymentsTransfers.Supported;
        string expectedRoutingNumber = "021000021";
        ApiEnum<string, Type> expectedType = Type.RoutingNumber;
        ApiEnum<string, RoutingNumberListResponseWireTransfers> expectedWireTransfers =
            RoutingNumberListResponseWireTransfers.Supported;

        Assert.Equal(expectedAchTransfers, deserialized.AchTransfers);
        Assert.Equal(expectedFednowTransfers, deserialized.FednowTransfers);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRealTimePaymentsTransfers, deserialized.RealTimePaymentsTransfers);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWireTransfers, deserialized.WireTransfers);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RoutingNumberListResponse
        {
            AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
            FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
            Name = "First Bank of the United States",
            RealTimePaymentsTransfers =
                RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
            RoutingNumber = "021000021",
            Type = Type.RoutingNumber,
            WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RoutingNumberListResponse
        {
            AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
            FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
            Name = "First Bank of the United States",
            RealTimePaymentsTransfers =
                RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
            RoutingNumber = "021000021",
            Type = Type.RoutingNumber,
            WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
        };

        RoutingNumberListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoutingNumberListResponseAchTransfersTest : TestBase
{
    [Theory]
    [InlineData(RoutingNumberListResponseAchTransfers.Supported)]
    [InlineData(RoutingNumberListResponseAchTransfers.NotSupported)]
    public void Validation_Works(RoutingNumberListResponseAchTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingNumberListResponseAchTransfers> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseAchTransfers>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingNumberListResponseAchTransfers.Supported)]
    [InlineData(RoutingNumberListResponseAchTransfers.NotSupported)]
    public void SerializationRoundtrip_Works(RoutingNumberListResponseAchTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingNumberListResponseAchTransfers> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseAchTransfers>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseAchTransfers>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseAchTransfers>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RoutingNumberListResponseFednowTransfersTest : TestBase
{
    [Theory]
    [InlineData(RoutingNumberListResponseFednowTransfers.Supported)]
    [InlineData(RoutingNumberListResponseFednowTransfers.NotSupported)]
    public void Validation_Works(RoutingNumberListResponseFednowTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingNumberListResponseFednowTransfers> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseFednowTransfers>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingNumberListResponseFednowTransfers.Supported)]
    [InlineData(RoutingNumberListResponseFednowTransfers.NotSupported)]
    public void SerializationRoundtrip_Works(RoutingNumberListResponseFednowTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingNumberListResponseFednowTransfers> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseFednowTransfers>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseFednowTransfers>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseFednowTransfers>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RoutingNumberListResponseRealTimePaymentsTransfersTest : TestBase
{
    [Theory]
    [InlineData(RoutingNumberListResponseRealTimePaymentsTransfers.Supported)]
    [InlineData(RoutingNumberListResponseRealTimePaymentsTransfers.NotSupported)]
    public void Validation_Works(RoutingNumberListResponseRealTimePaymentsTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingNumberListResponseRealTimePaymentsTransfers> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseRealTimePaymentsTransfers>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingNumberListResponseRealTimePaymentsTransfers.Supported)]
    [InlineData(RoutingNumberListResponseRealTimePaymentsTransfers.NotSupported)]
    public void SerializationRoundtrip_Works(
        RoutingNumberListResponseRealTimePaymentsTransfers rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingNumberListResponseRealTimePaymentsTransfers> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseRealTimePaymentsTransfers>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseRealTimePaymentsTransfers>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseRealTimePaymentsTransfers>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.RoutingNumber)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.RoutingNumber)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RoutingNumberListResponseWireTransfersTest : TestBase
{
    [Theory]
    [InlineData(RoutingNumberListResponseWireTransfers.Supported)]
    [InlineData(RoutingNumberListResponseWireTransfers.NotSupported)]
    public void Validation_Works(RoutingNumberListResponseWireTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingNumberListResponseWireTransfers> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseWireTransfers>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingNumberListResponseWireTransfers.Supported)]
    [InlineData(RoutingNumberListResponseWireTransfers.NotSupported)]
    public void SerializationRoundtrip_Works(RoutingNumberListResponseWireTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingNumberListResponseWireTransfers> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseWireTransfers>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseWireTransfers>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RoutingNumberListResponseWireTransfers>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
