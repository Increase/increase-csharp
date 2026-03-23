using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.RoutingNumbers;

namespace Increase.Api.Tests.Models.RoutingNumbers;

public class RoutingNumberListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RoutingNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
                    FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
                    Name = "First Bank of the United States",
                    RealTimePaymentsTransfers =
                        RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
                    RoutingNumber = "021000021",
                    Type = Type.RoutingNumber,
                    WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<RoutingNumberListResponse> expectedData =
        [
            new()
            {
                AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
                FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
                Name = "First Bank of the United States",
                RealTimePaymentsTransfers =
                    RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
                RoutingNumber = "021000021",
                Type = Type.RoutingNumber,
                WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
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
        var model = new RoutingNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
                    FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
                    Name = "First Bank of the United States",
                    RealTimePaymentsTransfers =
                        RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
                    RoutingNumber = "021000021",
                    Type = Type.RoutingNumber,
                    WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingNumberListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RoutingNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
                    FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
                    Name = "First Bank of the United States",
                    RealTimePaymentsTransfers =
                        RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
                    RoutingNumber = "021000021",
                    Type = Type.RoutingNumber,
                    WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingNumberListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<RoutingNumberListResponse> expectedData =
        [
            new()
            {
                AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
                FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
                Name = "First Bank of the United States",
                RealTimePaymentsTransfers =
                    RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
                RoutingNumber = "021000021",
                Type = Type.RoutingNumber,
                WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
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
        var model = new RoutingNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
                    FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
                    Name = "First Bank of the United States",
                    RealTimePaymentsTransfers =
                        RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
                    RoutingNumber = "021000021",
                    Type = Type.RoutingNumber,
                    WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RoutingNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    AchTransfers = RoutingNumberListResponseAchTransfers.Supported,
                    FednowTransfers = RoutingNumberListResponseFednowTransfers.Supported,
                    Name = "First Bank of the United States",
                    RealTimePaymentsTransfers =
                        RoutingNumberListResponseRealTimePaymentsTransfers.Supported,
                    RoutingNumber = "021000021",
                    Type = Type.RoutingNumber,
                    WireTransfers = RoutingNumberListResponseWireTransfers.Supported,
                },
            ],
            NextCursor = "v57w5d",
        };

        RoutingNumberListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
