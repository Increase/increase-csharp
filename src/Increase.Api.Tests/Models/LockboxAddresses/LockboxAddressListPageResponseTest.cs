using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using LockboxAddresses = Increase.Api.Models.LockboxAddresses;

namespace Increase.Api.Tests.Models.LockboxAddresses;

public class LockboxAddressListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LockboxAddresses::LockboxAddressListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        State = "CA",
                    },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox Address 1",
                    IdempotencyKey = null,
                    Status = LockboxAddresses::LockboxAddressStatus.Active,
                    Type = LockboxAddresses::Type.LockboxAddress,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<LockboxAddresses::LockboxAddress> expectedData =
        [
            new()
            {
                ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                Address = new()
                {
                    City = "San Francisco",
                    Line1 = "1234 Market St",
                    Line2 = "Ste 567",
                    PostalCode = "94114",
                    State = "CA",
                },
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "Lockbox Address 1",
                IdempotencyKey = null,
                Status = LockboxAddresses::LockboxAddressStatus.Active,
                Type = LockboxAddresses::Type.LockboxAddress,
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
        var model = new LockboxAddresses::LockboxAddressListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        State = "CA",
                    },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox Address 1",
                    IdempotencyKey = null,
                    Status = LockboxAddresses::LockboxAddressStatus.Active,
                    Type = LockboxAddresses::Type.LockboxAddress,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<LockboxAddresses::LockboxAddressListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LockboxAddresses::LockboxAddressListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        State = "CA",
                    },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox Address 1",
                    IdempotencyKey = null,
                    Status = LockboxAddresses::LockboxAddressStatus.Active,
                    Type = LockboxAddresses::Type.LockboxAddress,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<LockboxAddresses::LockboxAddressListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<LockboxAddresses::LockboxAddress> expectedData =
        [
            new()
            {
                ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                Address = new()
                {
                    City = "San Francisco",
                    Line1 = "1234 Market St",
                    Line2 = "Ste 567",
                    PostalCode = "94114",
                    State = "CA",
                },
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "Lockbox Address 1",
                IdempotencyKey = null,
                Status = LockboxAddresses::LockboxAddressStatus.Active,
                Type = LockboxAddresses::Type.LockboxAddress,
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
        var model = new LockboxAddresses::LockboxAddressListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        State = "CA",
                    },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox Address 1",
                    IdempotencyKey = null,
                    Status = LockboxAddresses::LockboxAddressStatus.Active,
                    Type = LockboxAddresses::Type.LockboxAddress,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LockboxAddresses::LockboxAddressListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "lockbox_address_lw6sbzl9ol5dfd8hdml6",
                    Address = new()
                    {
                        City = "San Francisco",
                        Line1 = "1234 Market St",
                        Line2 = "Ste 567",
                        PostalCode = "94114",
                        State = "CA",
                    },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Lockbox Address 1",
                    IdempotencyKey = null,
                    Status = LockboxAddresses::LockboxAddressStatus.Active,
                    Type = LockboxAddresses::Type.LockboxAddress,
                },
            ],
            NextCursor = "v57w5d",
        };

        LockboxAddresses::LockboxAddressListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
