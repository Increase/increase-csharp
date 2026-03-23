using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using PhysicalCards = Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Tests.Models.PhysicalCards;

public class PhysicalCardTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCard
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
        };

        string expectedID = "physical_card_ode8duyq5v2ynhjoharl";
        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        PhysicalCards::PhysicalCardCardholder expectedCardholder = new()
        {
            FirstName = "Ian",
            LastName = "Crease",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedPhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec";
        PhysicalCards::PhysicalCardShipment expectedShipment = new()
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
        };
        ApiEnum<string, PhysicalCards::PhysicalCardStatus> expectedStatus =
            PhysicalCards::PhysicalCardStatus.Active;
        ApiEnum<string, PhysicalCards::Type> expectedType = PhysicalCards::Type.PhysicalCard;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedCardholder, model.Cardholder);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedPhysicalCardProfileID, model.PhysicalCardProfileID);
        Assert.Equal(expectedShipment, model.Shipment);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCard
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCard>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCards::PhysicalCard
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCard>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "physical_card_ode8duyq5v2ynhjoharl";
        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        PhysicalCards::PhysicalCardCardholder expectedCardholder = new()
        {
            FirstName = "Ian",
            LastName = "Crease",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedPhysicalCardProfileID = "physical_card_profile_m534d5rn9qyy9ufqxoec";
        PhysicalCards::PhysicalCardShipment expectedShipment = new()
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
        };
        ApiEnum<string, PhysicalCards::PhysicalCardStatus> expectedStatus =
            PhysicalCards::PhysicalCardStatus.Active;
        ApiEnum<string, PhysicalCards::Type> expectedType = PhysicalCards::Type.PhysicalCard;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedCardholder, deserialized.Cardholder);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedPhysicalCardProfileID, deserialized.PhysicalCardProfileID);
        Assert.Equal(expectedShipment, deserialized.Shipment);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCards::PhysicalCard
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCards::PhysicalCard
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
        };

        PhysicalCards::PhysicalCard copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhysicalCardCardholderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCardCardholder
        {
            FirstName = "first_name",
            LastName = "last_name",
        };

        string expectedFirstName = "first_name";
        string expectedLastName = "last_name";

        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedLastName, model.LastName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCardCardholder
        {
            FirstName = "first_name",
            LastName = "last_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCardCardholder>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCards::PhysicalCardCardholder
        {
            FirstName = "first_name",
            LastName = "last_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCardCardholder>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFirstName = "first_name";
        string expectedLastName = "last_name";

        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedLastName, deserialized.LastName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCards::PhysicalCardCardholder
        {
            FirstName = "first_name",
            LastName = "last_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCards::PhysicalCardCardholder
        {
            FirstName = "first_name",
            LastName = "last_name",
        };

        PhysicalCards::PhysicalCardCardholder copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhysicalCardShipmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipment
        {
            Address = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
                Name = "name",
                PostalCode = "postal_code",
                State = "state",
            },
            Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
            Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
            Status = PhysicalCards::PhysicalCardShipmentStatus.Pending,
            Tracking = new()
            {
                Number = "number",
                ReturnNumber = "return_number",
                ReturnReason = "return_reason",
                ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Updates =
                [
                    new()
                    {
                        CarrierEstimatedDeliveryAt = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        Category = PhysicalCards::Category.InTransit,
                        City = "city",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PostalCode = "postal_code",
                        State = "state",
                    },
                ],
            },
        };

        PhysicalCards::PhysicalCardShipmentAddress expectedAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentMethod> expectedMethod =
            PhysicalCards::PhysicalCardShipmentMethod.Usps;
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentSchedule> expectedSchedule =
            PhysicalCards::PhysicalCardShipmentSchedule.NextDay;
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentStatus> expectedStatus =
            PhysicalCards::PhysicalCardShipmentStatus.Pending;
        PhysicalCards::Tracking expectedTracking = new()
        {
            Number = "number",
            ReturnNumber = "return_number",
            ReturnReason = "return_reason",
            ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Updates =
            [
                new()
                {
                    CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Category = PhysicalCards::Category.InTransit,
                    City = "city",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                    State = "state",
                },
            ],
        };

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedSchedule, model.Schedule);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTracking, model.Tracking);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipment
        {
            Address = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
                Name = "name",
                PostalCode = "postal_code",
                State = "state",
            },
            Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
            Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
            Status = PhysicalCards::PhysicalCardShipmentStatus.Pending,
            Tracking = new()
            {
                Number = "number",
                ReturnNumber = "return_number",
                ReturnReason = "return_reason",
                ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Updates =
                [
                    new()
                    {
                        CarrierEstimatedDeliveryAt = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        Category = PhysicalCards::Category.InTransit,
                        City = "city",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PostalCode = "postal_code",
                        State = "state",
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCardShipment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipment
        {
            Address = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
                Name = "name",
                PostalCode = "postal_code",
                State = "state",
            },
            Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
            Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
            Status = PhysicalCards::PhysicalCardShipmentStatus.Pending,
            Tracking = new()
            {
                Number = "number",
                ReturnNumber = "return_number",
                ReturnReason = "return_reason",
                ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Updates =
                [
                    new()
                    {
                        CarrierEstimatedDeliveryAt = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        Category = PhysicalCards::Category.InTransit,
                        City = "city",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PostalCode = "postal_code",
                        State = "state",
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCardShipment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PhysicalCards::PhysicalCardShipmentAddress expectedAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentMethod> expectedMethod =
            PhysicalCards::PhysicalCardShipmentMethod.Usps;
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentSchedule> expectedSchedule =
            PhysicalCards::PhysicalCardShipmentSchedule.NextDay;
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentStatus> expectedStatus =
            PhysicalCards::PhysicalCardShipmentStatus.Pending;
        PhysicalCards::Tracking expectedTracking = new()
        {
            Number = "number",
            ReturnNumber = "return_number",
            ReturnReason = "return_reason",
            ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Updates =
            [
                new()
                {
                    CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Category = PhysicalCards::Category.InTransit,
                    City = "city",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                    State = "state",
                },
            ],
        };

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedSchedule, deserialized.Schedule);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTracking, deserialized.Tracking);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipment
        {
            Address = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
                Name = "name",
                PostalCode = "postal_code",
                State = "state",
            },
            Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
            Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
            Status = PhysicalCards::PhysicalCardShipmentStatus.Pending,
            Tracking = new()
            {
                Number = "number",
                ReturnNumber = "return_number",
                ReturnReason = "return_reason",
                ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Updates =
                [
                    new()
                    {
                        CarrierEstimatedDeliveryAt = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        Category = PhysicalCards::Category.InTransit,
                        City = "city",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PostalCode = "postal_code",
                        State = "state",
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipment
        {
            Address = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                Line3 = "line3",
                Name = "name",
                PostalCode = "postal_code",
                State = "state",
            },
            Method = PhysicalCards::PhysicalCardShipmentMethod.Usps,
            Schedule = PhysicalCards::PhysicalCardShipmentSchedule.NextDay,
            Status = PhysicalCards::PhysicalCardShipmentStatus.Pending,
            Tracking = new()
            {
                Number = "number",
                ReturnNumber = "return_number",
                ReturnReason = "return_reason",
                ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Updates =
                [
                    new()
                    {
                        CarrierEstimatedDeliveryAt = DateTimeOffset.Parse(
                            "2019-12-27T18:11:19.117Z"
                        ),
                        Category = PhysicalCards::Category.InTransit,
                        City = "city",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PostalCode = "postal_code",
                        State = "state",
                    },
                ],
            },
        };

        PhysicalCards::PhysicalCardShipment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhysicalCardShipmentAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipmentAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedLine3 = "line3";
        string expectedName = "name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedLine3, model.Line3);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipmentAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCardShipmentAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipmentAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::PhysicalCardShipmentAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedLine3 = "line3";
        string expectedName = "name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedLine3, deserialized.Line3);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipmentAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCards::PhysicalCardShipmentAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            Line3 = "line3",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        PhysicalCards::PhysicalCardShipmentAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhysicalCardShipmentMethodTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCards::PhysicalCardShipmentMethod.Usps)]
    [InlineData(PhysicalCards::PhysicalCardShipmentMethod.FedexPriorityOvernight)]
    [InlineData(PhysicalCards::PhysicalCardShipmentMethod.Fedex2Day)]
    [InlineData(PhysicalCards::PhysicalCardShipmentMethod.DhlWorldwideExpress)]
    public void Validation_Works(PhysicalCards::PhysicalCardShipmentMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCards::PhysicalCardShipmentMethod.Usps)]
    [InlineData(PhysicalCards::PhysicalCardShipmentMethod.FedexPriorityOvernight)]
    [InlineData(PhysicalCards::PhysicalCardShipmentMethod.Fedex2Day)]
    [InlineData(PhysicalCards::PhysicalCardShipmentMethod.DhlWorldwideExpress)]
    public void SerializationRoundtrip_Works(PhysicalCards::PhysicalCardShipmentMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PhysicalCardShipmentScheduleTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCards::PhysicalCardShipmentSchedule.NextDay)]
    [InlineData(PhysicalCards::PhysicalCardShipmentSchedule.SameDay)]
    public void Validation_Works(PhysicalCards::PhysicalCardShipmentSchedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentSchedule> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentSchedule>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCards::PhysicalCardShipmentSchedule.NextDay)]
    [InlineData(PhysicalCards::PhysicalCardShipmentSchedule.SameDay)]
    public void SerializationRoundtrip_Works(PhysicalCards::PhysicalCardShipmentSchedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentSchedule> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentSchedule>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentSchedule>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentSchedule>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PhysicalCardShipmentStatusTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Pending)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Canceled)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Submitted)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Acknowledged)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Rejected)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Shipped)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Returned)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.RequiresAttention)]
    public void Validation_Works(PhysicalCards::PhysicalCardShipmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Pending)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Canceled)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Submitted)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Acknowledged)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Rejected)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Shipped)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.Returned)]
    [InlineData(PhysicalCards::PhysicalCardShipmentStatus.RequiresAttention)]
    public void SerializationRoundtrip_Works(PhysicalCards::PhysicalCardShipmentStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::PhysicalCardShipmentStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardShipmentStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TrackingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCards::Tracking
        {
            Number = "number",
            ReturnNumber = "return_number",
            ReturnReason = "return_reason",
            ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Updates =
            [
                new()
                {
                    CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Category = PhysicalCards::Category.InTransit,
                    City = "city",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                    State = "state",
                },
            ],
        };

        string expectedNumber = "number";
        string expectedReturnNumber = "return_number";
        string expectedReturnReason = "return_reason";
        DateTimeOffset expectedShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<PhysicalCards::Update> expectedUpdates =
        [
            new()
            {
                CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Category = PhysicalCards::Category.InTransit,
                City = "city",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PostalCode = "postal_code",
                State = "state",
            },
        ];

        Assert.Equal(expectedNumber, model.Number);
        Assert.Equal(expectedReturnNumber, model.ReturnNumber);
        Assert.Equal(expectedReturnReason, model.ReturnReason);
        Assert.Equal(expectedShippedAt, model.ShippedAt);
        Assert.Equal(expectedUpdates.Count, model.Updates.Count);
        for (int i = 0; i < expectedUpdates.Count; i++)
        {
            Assert.Equal(expectedUpdates[i], model.Updates[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCards::Tracking
        {
            Number = "number",
            ReturnNumber = "return_number",
            ReturnReason = "return_reason",
            ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Updates =
            [
                new()
                {
                    CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Category = PhysicalCards::Category.InTransit,
                    City = "city",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                    State = "state",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::Tracking>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCards::Tracking
        {
            Number = "number",
            ReturnNumber = "return_number",
            ReturnReason = "return_reason",
            ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Updates =
            [
                new()
                {
                    CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Category = PhysicalCards::Category.InTransit,
                    City = "city",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                    State = "state",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::Tracking>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNumber = "number";
        string expectedReturnNumber = "return_number";
        string expectedReturnReason = "return_reason";
        DateTimeOffset expectedShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<PhysicalCards::Update> expectedUpdates =
        [
            new()
            {
                CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Category = PhysicalCards::Category.InTransit,
                City = "city",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PostalCode = "postal_code",
                State = "state",
            },
        ];

        Assert.Equal(expectedNumber, deserialized.Number);
        Assert.Equal(expectedReturnNumber, deserialized.ReturnNumber);
        Assert.Equal(expectedReturnReason, deserialized.ReturnReason);
        Assert.Equal(expectedShippedAt, deserialized.ShippedAt);
        Assert.Equal(expectedUpdates.Count, deserialized.Updates.Count);
        for (int i = 0; i < expectedUpdates.Count; i++)
        {
            Assert.Equal(expectedUpdates[i], deserialized.Updates[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCards::Tracking
        {
            Number = "number",
            ReturnNumber = "return_number",
            ReturnReason = "return_reason",
            ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Updates =
            [
                new()
                {
                    CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Category = PhysicalCards::Category.InTransit,
                    City = "city",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                    State = "state",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCards::Tracking
        {
            Number = "number",
            ReturnNumber = "return_number",
            ReturnReason = "return_reason",
            ShippedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Updates =
            [
                new()
                {
                    CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Category = PhysicalCards::Category.InTransit,
                    City = "city",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PostalCode = "postal_code",
                    State = "state",
                },
            ],
        };

        PhysicalCards::Tracking copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCards::Update
        {
            CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Category = PhysicalCards::Category.InTransit,
            City = "city",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
            State = "state",
        };

        DateTimeOffset expectedCarrierEstimatedDeliveryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        ApiEnum<string, PhysicalCards::Category> expectedCategory =
            PhysicalCards::Category.InTransit;
        string expectedCity = "city";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCarrierEstimatedDeliveryAt, model.CarrierEstimatedDeliveryAt);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCards::Update
        {
            CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Category = PhysicalCards::Category.InTransit,
            City = "city",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::Update>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCards::Update
        {
            CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Category = PhysicalCards::Category.InTransit,
            City = "city",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCards::Update>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCarrierEstimatedDeliveryAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        ApiEnum<string, PhysicalCards::Category> expectedCategory =
            PhysicalCards::Category.InTransit;
        string expectedCity = "city";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCarrierEstimatedDeliveryAt, deserialized.CarrierEstimatedDeliveryAt);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCards::Update
        {
            CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Category = PhysicalCards::Category.InTransit,
            City = "city",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCards::Update
        {
            CarrierEstimatedDeliveryAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Category = PhysicalCards::Category.InTransit,
            City = "city",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
            State = "state",
        };

        PhysicalCards::Update copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCards::Category.InTransit)]
    [InlineData(PhysicalCards::Category.ProcessedForDelivery)]
    [InlineData(PhysicalCards::Category.Delivered)]
    [InlineData(PhysicalCards::Category.DeliveryIssue)]
    [InlineData(PhysicalCards::Category.ReturnedToSender)]
    public void Validation_Works(PhysicalCards::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCards::Category.InTransit)]
    [InlineData(PhysicalCards::Category.ProcessedForDelivery)]
    [InlineData(PhysicalCards::Category.Delivered)]
    [InlineData(PhysicalCards::Category.DeliveryIssue)]
    [InlineData(PhysicalCards::Category.ReturnedToSender)]
    public void SerializationRoundtrip_Works(PhysicalCards::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PhysicalCardStatusTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCards::PhysicalCardStatus.Active)]
    [InlineData(PhysicalCards::PhysicalCardStatus.Disabled)]
    [InlineData(PhysicalCards::PhysicalCardStatus.Canceled)]
    public void Validation_Works(PhysicalCards::PhysicalCardStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::PhysicalCardStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::PhysicalCardStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCards::PhysicalCardStatus.Active)]
    [InlineData(PhysicalCards::PhysicalCardStatus.Disabled)]
    [InlineData(PhysicalCards::PhysicalCardStatus.Canceled)]
    public void SerializationRoundtrip_Works(PhysicalCards::PhysicalCardStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::PhysicalCardStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::PhysicalCardStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCards::PhysicalCardStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCards::Type.PhysicalCard)]
    public void Validation_Works(PhysicalCards::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCards::Type.PhysicalCard)]
    public void SerializationRoundtrip_Works(PhysicalCards::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCards::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCards::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
