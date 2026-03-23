using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using PhysicalCards = Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Tests.Models.PhysicalCards;

public class PhysicalCardListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_ode8duyq5v2ynhjoharl",
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    Shipment = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = "Unit 2",
                            Line3 = null,
                            Name = "Ian Crease",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
                        Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
                        Status = PhysicalCards::PhysicalCardShipmentStatus.Shipped,
                        Tracking = new()
                        {
                            Number = "9400110200881234567890",
                            ReturnNumber = null,
                            ReturnReason = null,
                            ShippedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Updates =
                            [
                                new()
                                {
                                    CarrierEstimatedDeliveryAt = null,
                                    Category = PhysicalCards::Category.Delivered,
                                    City = null,
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    PostalCode = "10001",
                                    State = null,
                                },
                            ],
                        },
                    },
                    Status = PhysicalCards::PhysicalCardStatus.Active,
                    Type = PhysicalCards::Type.PhysicalCard,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<PhysicalCards::PhysicalCard> expectedData =
        [
            new()
            {
                ID = "physical_card_ode8duyq5v2ynhjoharl",
                CardID = "card_oubs0hwk5rn6knuecxg2",
                Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                IdempotencyKey = null,
                PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                Shipment = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = "Unit 2",
                        Line3 = null,
                        Name = "Ian Crease",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
                    Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
                    Status = PhysicalCards::PhysicalCardShipmentStatus.Shipped,
                    Tracking = new()
                    {
                        Number = "9400110200881234567890",
                        ReturnNumber = null,
                        ReturnReason = null,
                        ShippedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Updates =
                        [
                            new()
                            {
                                CarrierEstimatedDeliveryAt = null,
                                Category = PhysicalCards::Category.Delivered,
                                City = null,
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                PostalCode = "10001",
                                State = null,
                            },
                        ],
                    },
                },
                Status = PhysicalCards::PhysicalCardStatus.Active,
                Type = PhysicalCards::Type.PhysicalCard,
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
        var model = new PhysicalCards::PhysicalCardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_ode8duyq5v2ynhjoharl",
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    Shipment = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = "Unit 2",
                            Line3 = null,
                            Name = "Ian Crease",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
                        Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
                        Status = PhysicalCards::PhysicalCardShipmentStatus.Shipped,
                        Tracking = new()
                        {
                            Number = "9400110200881234567890",
                            ReturnNumber = null,
                            ReturnReason = null,
                            ShippedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Updates =
                            [
                                new()
                                {
                                    CarrierEstimatedDeliveryAt = null,
                                    Category = PhysicalCards::Category.Delivered,
                                    City = null,
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    PostalCode = "10001",
                                    State = null,
                                },
                            ],
                        },
                    },
                    Status = PhysicalCards::PhysicalCardStatus.Active,
                    Type = PhysicalCards::Type.PhysicalCard,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCardListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCards::PhysicalCardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_ode8duyq5v2ynhjoharl",
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    Shipment = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = "Unit 2",
                            Line3 = null,
                            Name = "Ian Crease",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
                        Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
                        Status = PhysicalCards::PhysicalCardShipmentStatus.Shipped,
                        Tracking = new()
                        {
                            Number = "9400110200881234567890",
                            ReturnNumber = null,
                            ReturnReason = null,
                            ShippedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Updates =
                            [
                                new()
                                {
                                    CarrierEstimatedDeliveryAt = null,
                                    Category = PhysicalCards::Category.Delivered,
                                    City = null,
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    PostalCode = "10001",
                                    State = null,
                                },
                            ],
                        },
                    },
                    Status = PhysicalCards::PhysicalCardStatus.Active,
                    Type = PhysicalCards::Type.PhysicalCard,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCardListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PhysicalCards::PhysicalCard> expectedData =
        [
            new()
            {
                ID = "physical_card_ode8duyq5v2ynhjoharl",
                CardID = "card_oubs0hwk5rn6knuecxg2",
                Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                IdempotencyKey = null,
                PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                Shipment = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = "Unit 2",
                        Line3 = null,
                        Name = "Ian Crease",
                        PostalCode = "10045",
                        State = "NY",
                    },
                    Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
                    Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
                    Status = PhysicalCards::PhysicalCardShipmentStatus.Shipped,
                    Tracking = new()
                    {
                        Number = "9400110200881234567890",
                        ReturnNumber = null,
                        ReturnReason = null,
                        ShippedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        Updates =
                        [
                            new()
                            {
                                CarrierEstimatedDeliveryAt = null,
                                Category = PhysicalCards::Category.Delivered,
                                City = null,
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                PostalCode = "10001",
                                State = null,
                            },
                        ],
                    },
                },
                Status = PhysicalCards::PhysicalCardStatus.Active,
                Type = PhysicalCards::Type.PhysicalCard,
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
        var model = new PhysicalCards::PhysicalCardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_ode8duyq5v2ynhjoharl",
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    Shipment = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = "Unit 2",
                            Line3 = null,
                            Name = "Ian Crease",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
                        Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
                        Status = PhysicalCards::PhysicalCardShipmentStatus.Shipped,
                        Tracking = new()
                        {
                            Number = "9400110200881234567890",
                            ReturnNumber = null,
                            ReturnReason = null,
                            ShippedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Updates =
                            [
                                new()
                                {
                                    CarrierEstimatedDeliveryAt = null,
                                    Category = PhysicalCards::Category.Delivered,
                                    City = null,
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    PostalCode = "10001",
                                    State = null,
                                },
                            ],
                        },
                    },
                    Status = PhysicalCards::PhysicalCardStatus.Active,
                    Type = PhysicalCards::Type.PhysicalCard,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCards::PhysicalCardListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "physical_card_ode8duyq5v2ynhjoharl",
                    CardID = "card_oubs0hwk5rn6knuecxg2",
                    Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    PhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec",
                    Shipment = new()
                    {
                        Address = new()
                        {
                            City = "New York",
                            Country = "US",
                            Line1 = "33 Liberty Street",
                            Line2 = "Unit 2",
                            Line3 = null,
                            Name = "Ian Crease",
                            PostalCode = "10045",
                            State = "NY",
                        },
                        Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
                        Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
                        Status = PhysicalCards::PhysicalCardShipmentStatus.Shipped,
                        Tracking = new()
                        {
                            Number = "9400110200881234567890",
                            ReturnNumber = null,
                            ReturnReason = null,
                            ShippedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            Updates =
                            [
                                new()
                                {
                                    CarrierEstimatedDeliveryAt = null,
                                    Category = PhysicalCards::Category.Delivered,
                                    City = null,
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    PostalCode = "10001",
                                    State = null,
                                },
                            ],
                        },
                    },
                    Status = PhysicalCards::PhysicalCardStatus.Active,
                    Type = PhysicalCards::Type.PhysicalCard,
                },
            ],
            NextCursor = "v57w5d",
        };

        PhysicalCards::PhysicalCardListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
