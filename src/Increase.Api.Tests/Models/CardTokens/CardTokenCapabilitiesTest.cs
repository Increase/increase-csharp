using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardTokens;

namespace Increase.Api.Tests.Models.CardTokens;

public class CardTokenCapabilitiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardTokenCapabilities
        {
            Routes =
            [
                new()
                {
                    CrossBorderPushTransfers = CrossBorderPushTransfers.NotSupported,
                    DomesticPushTransfers = DomesticPushTransfers.Supported,
                    IssuerCountry = "US",
                    RouteValue = RouteRoute.Visa,
                },
            ],
            Type = CardTokenCapabilitiesType.CardTokenCapabilities,
        };

        List<Route> expectedRoutes =
        [
            new()
            {
                CrossBorderPushTransfers = CrossBorderPushTransfers.NotSupported,
                DomesticPushTransfers = DomesticPushTransfers.Supported,
                IssuerCountry = "US",
                RouteValue = RouteRoute.Visa,
            },
        ];
        ApiEnum<string, CardTokenCapabilitiesType> expectedType =
            CardTokenCapabilitiesType.CardTokenCapabilities;

        Assert.Equal(expectedRoutes.Count, model.Routes.Count);
        for (int i = 0; i < expectedRoutes.Count; i++)
        {
            Assert.Equal(expectedRoutes[i], model.Routes[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardTokenCapabilities
        {
            Routes =
            [
                new()
                {
                    CrossBorderPushTransfers = CrossBorderPushTransfers.NotSupported,
                    DomesticPushTransfers = DomesticPushTransfers.Supported,
                    IssuerCountry = "US",
                    RouteValue = RouteRoute.Visa,
                },
            ],
            Type = CardTokenCapabilitiesType.CardTokenCapabilities,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardTokenCapabilities>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardTokenCapabilities
        {
            Routes =
            [
                new()
                {
                    CrossBorderPushTransfers = CrossBorderPushTransfers.NotSupported,
                    DomesticPushTransfers = DomesticPushTransfers.Supported,
                    IssuerCountry = "US",
                    RouteValue = RouteRoute.Visa,
                },
            ],
            Type = CardTokenCapabilitiesType.CardTokenCapabilities,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardTokenCapabilities>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Route> expectedRoutes =
        [
            new()
            {
                CrossBorderPushTransfers = CrossBorderPushTransfers.NotSupported,
                DomesticPushTransfers = DomesticPushTransfers.Supported,
                IssuerCountry = "US",
                RouteValue = RouteRoute.Visa,
            },
        ];
        ApiEnum<string, CardTokenCapabilitiesType> expectedType =
            CardTokenCapabilitiesType.CardTokenCapabilities;

        Assert.Equal(expectedRoutes.Count, deserialized.Routes.Count);
        for (int i = 0; i < expectedRoutes.Count; i++)
        {
            Assert.Equal(expectedRoutes[i], deserialized.Routes[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardTokenCapabilities
        {
            Routes =
            [
                new()
                {
                    CrossBorderPushTransfers = CrossBorderPushTransfers.NotSupported,
                    DomesticPushTransfers = DomesticPushTransfers.Supported,
                    IssuerCountry = "US",
                    RouteValue = RouteRoute.Visa,
                },
            ],
            Type = CardTokenCapabilitiesType.CardTokenCapabilities,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardTokenCapabilities
        {
            Routes =
            [
                new()
                {
                    CrossBorderPushTransfers = CrossBorderPushTransfers.NotSupported,
                    DomesticPushTransfers = DomesticPushTransfers.Supported,
                    IssuerCountry = "US",
                    RouteValue = RouteRoute.Visa,
                },
            ],
            Type = CardTokenCapabilitiesType.CardTokenCapabilities,
        };

        CardTokenCapabilities copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RouteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Route
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            IssuerCountry = "issuer_country",
            RouteValue = RouteRoute.Visa,
        };

        ApiEnum<string, CrossBorderPushTransfers> expectedCrossBorderPushTransfers =
            CrossBorderPushTransfers.Supported;
        ApiEnum<string, DomesticPushTransfers> expectedDomesticPushTransfers =
            DomesticPushTransfers.Supported;
        string expectedIssuerCountry = "issuer_country";
        ApiEnum<string, RouteRoute> expectedRouteValue = RouteRoute.Visa;

        Assert.Equal(expectedCrossBorderPushTransfers, model.CrossBorderPushTransfers);
        Assert.Equal(expectedDomesticPushTransfers, model.DomesticPushTransfers);
        Assert.Equal(expectedIssuerCountry, model.IssuerCountry);
        Assert.Equal(expectedRouteValue, model.RouteValue);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Route
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            IssuerCountry = "issuer_country",
            RouteValue = RouteRoute.Visa,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Route>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Route
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            IssuerCountry = "issuer_country",
            RouteValue = RouteRoute.Visa,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Route>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, CrossBorderPushTransfers> expectedCrossBorderPushTransfers =
            CrossBorderPushTransfers.Supported;
        ApiEnum<string, DomesticPushTransfers> expectedDomesticPushTransfers =
            DomesticPushTransfers.Supported;
        string expectedIssuerCountry = "issuer_country";
        ApiEnum<string, RouteRoute> expectedRouteValue = RouteRoute.Visa;

        Assert.Equal(expectedCrossBorderPushTransfers, deserialized.CrossBorderPushTransfers);
        Assert.Equal(expectedDomesticPushTransfers, deserialized.DomesticPushTransfers);
        Assert.Equal(expectedIssuerCountry, deserialized.IssuerCountry);
        Assert.Equal(expectedRouteValue, deserialized.RouteValue);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Route
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            IssuerCountry = "issuer_country",
            RouteValue = RouteRoute.Visa,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Route
        {
            CrossBorderPushTransfers = CrossBorderPushTransfers.Supported,
            DomesticPushTransfers = DomesticPushTransfers.Supported,
            IssuerCountry = "issuer_country",
            RouteValue = RouteRoute.Visa,
        };

        Route copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CrossBorderPushTransfersTest : TestBase
{
    [Theory]
    [InlineData(CrossBorderPushTransfers.Supported)]
    [InlineData(CrossBorderPushTransfers.NotSupported)]
    public void Validation_Works(CrossBorderPushTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CrossBorderPushTransfers> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CrossBorderPushTransfers>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CrossBorderPushTransfers.Supported)]
    [InlineData(CrossBorderPushTransfers.NotSupported)]
    public void SerializationRoundtrip_Works(CrossBorderPushTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CrossBorderPushTransfers> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CrossBorderPushTransfers>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CrossBorderPushTransfers>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CrossBorderPushTransfers>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DomesticPushTransfersTest : TestBase
{
    [Theory]
    [InlineData(DomesticPushTransfers.Supported)]
    [InlineData(DomesticPushTransfers.NotSupported)]
    public void Validation_Works(DomesticPushTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DomesticPushTransfers> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DomesticPushTransfers>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DomesticPushTransfers.Supported)]
    [InlineData(DomesticPushTransfers.NotSupported)]
    public void SerializationRoundtrip_Works(DomesticPushTransfers rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DomesticPushTransfers> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DomesticPushTransfers>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DomesticPushTransfers>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DomesticPushTransfers>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RouteRouteTest : TestBase
{
    [Theory]
    [InlineData(RouteRoute.Visa)]
    [InlineData(RouteRoute.Mastercard)]
    [InlineData(RouteRoute.Pulse)]
    public void Validation_Works(RouteRoute rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRoute> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRoute>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RouteRoute.Visa)]
    [InlineData(RouteRoute.Mastercard)]
    [InlineData(RouteRoute.Pulse)]
    public void SerializationRoundtrip_Works(RouteRoute rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RouteRoute> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRoute>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RouteRoute>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RouteRoute>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CardTokenCapabilitiesTypeTest : TestBase
{
    [Theory]
    [InlineData(CardTokenCapabilitiesType.CardTokenCapabilities)]
    public void Validation_Works(CardTokenCapabilitiesType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardTokenCapabilitiesType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardTokenCapabilitiesType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardTokenCapabilitiesType.CardTokenCapabilities)]
    public void SerializationRoundtrip_Works(CardTokenCapabilitiesType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardTokenCapabilitiesType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardTokenCapabilitiesType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardTokenCapabilitiesType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardTokenCapabilitiesType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
