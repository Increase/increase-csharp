using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Tests.Models.PhysicalCards;

public class PhysicalCardCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCardCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
            Shipment = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                    Country = "x",
                    Line2 = "Unit 2",
                    Line3 = "x",
                    PhoneNumber = "x",
                },
                Method = Method.Usps,
                Schedule = Schedule.NextDay,
            },
            PhysicalCardProfileID = "physical_card_profile_id",
        };

        string expectedCardID = "card_oubs0hwk5rn6knuecxg2";
        Cardholder expectedCardholder = new() { FirstName = "Ian", LastName = "Crease" };
        Shipment expectedShipment = new()
        {
            Address = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Country = "x",
                Line2 = "Unit 2",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,
            Schedule = Schedule.NextDay,
        };
        string expectedPhysicalCardProfileID = "physical_card_profile_id";

        Assert.Equal(expectedCardID, parameters.CardID);
        Assert.Equal(expectedCardholder, parameters.Cardholder);
        Assert.Equal(expectedShipment, parameters.Shipment);
        Assert.Equal(expectedPhysicalCardProfileID, parameters.PhysicalCardProfileID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhysicalCardCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
            Shipment = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                    Country = "x",
                    Line2 = "Unit 2",
                    Line3 = "x",
                    PhoneNumber = "x",
                },
                Method = Method.Usps,
                Schedule = Schedule.NextDay,
            },
        };

        Assert.Null(parameters.PhysicalCardProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("physical_card_profile_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhysicalCardCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
            Shipment = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                    Country = "x",
                    Line2 = "Unit 2",
                    Line3 = "x",
                    PhoneNumber = "x",
                },
                Method = Method.Usps,
                Schedule = Schedule.NextDay,
            },

            // Null should be interpreted as omitted for these properties
            PhysicalCardProfileID = null,
        };

        Assert.Null(parameters.PhysicalCardProfileID);
        Assert.False(parameters.RawBodyData.ContainsKey("physical_card_profile_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCardCreateParams parameters = new()
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
            Shipment = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                    Country = "x",
                    Line2 = "Unit 2",
                    Line3 = "x",
                    PhoneNumber = "x",
                },
                Method = Method.Usps,
                Schedule = Schedule.NextDay,
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/physical_cards"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCardCreateParams
        {
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
            Shipment = new()
            {
                Address = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                    Country = "x",
                    Line2 = "Unit 2",
                    Line3 = "x",
                    PhoneNumber = "x",
                },
                Method = Method.Usps,
                Schedule = Schedule.NextDay,
            },
            PhysicalCardProfileID = "physical_card_profile_id",
        };

        PhysicalCardCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CardholderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cardholder { FirstName = "first_name", LastName = "last_name" };

        string expectedFirstName = "first_name";
        string expectedLastName = "last_name";

        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedLastName, model.LastName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cardholder { FirstName = "first_name", LastName = "last_name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cardholder>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cardholder { FirstName = "first_name", LastName = "last_name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cardholder>(
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
        var model = new Cardholder { FirstName = "first_name", LastName = "last_name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cardholder { FirstName = "first_name", LastName = "last_name" };

        Cardholder copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ShipmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,
            Schedule = Schedule.NextDay,
        };

        Address expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
            Country = "x",
            Line2 = "x",
            Line3 = "x",
            PhoneNumber = "x",
        };
        ApiEnum<string, Method> expectedMethod = Method.Usps;
        ApiEnum<string, Schedule> expectedSchedule = Schedule.NextDay;

        Assert.Equal(expectedAddress, model.Address);
        Assert.Equal(expectedMethod, model.Method);
        Assert.Equal(expectedSchedule, model.Schedule);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,
            Schedule = Schedule.NextDay,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Shipment>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,
            Schedule = Schedule.NextDay,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Shipment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Address expectedAddress = new()
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
            Country = "x",
            Line2 = "x",
            Line3 = "x",
            PhoneNumber = "x",
        };
        ApiEnum<string, Method> expectedMethod = Method.Usps;
        ApiEnum<string, Schedule> expectedSchedule = Schedule.NextDay;

        Assert.Equal(expectedAddress, deserialized.Address);
        Assert.Equal(expectedMethod, deserialized.Method);
        Assert.Equal(expectedSchedule, deserialized.Schedule);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,
            Schedule = Schedule.NextDay,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,
        };

        Assert.Null(model.Schedule);
        Assert.False(model.RawData.ContainsKey("schedule"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,

            // Null should be interpreted as omitted for these properties
            Schedule = null,
        };

        Assert.Null(model.Schedule);
        Assert.False(model.RawData.ContainsKey("schedule"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,

            // Null should be interpreted as omitted for these properties
            Schedule = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Shipment
        {
            Address = new()
            {
                City = "x",
                Line1 = "x",
                Name = "name",
                PostalCode = "x",
                State = "x",
                Country = "x",
                Line2 = "x",
                Line3 = "x",
                PhoneNumber = "x",
            },
            Method = Method.Usps,
            Schedule = Schedule.NextDay,
        };

        Shipment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
            Country = "x",
            Line2 = "x",
            Line3 = "x",
            PhoneNumber = "x",
        };

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedName = "name";
        string expectedPostalCode = "x";
        string expectedState = "x";
        string expectedCountry = "x";
        string expectedLine2 = "x";
        string expectedLine3 = "x";
        string expectedPhoneNumber = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedLine3, model.Line3);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
            Country = "x",
            Line2 = "x",
            Line3 = "x",
            PhoneNumber = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
            Country = "x",
            Line2 = "x",
            Line3 = "x",
            PhoneNumber = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Address>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedName = "name";
        string expectedPostalCode = "x";
        string expectedState = "x";
        string expectedCountry = "x";
        string expectedLine2 = "x";
        string expectedLine3 = "x";
        string expectedPhoneNumber = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedLine3, deserialized.Line3);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
            Country = "x",
            Line2 = "x",
            Line3 = "x",
            PhoneNumber = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
        };

        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Line3);
        Assert.False(model.RawData.ContainsKey("line3"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Country = null,
            Line2 = null,
            Line3 = null,
            PhoneNumber = null,
        };

        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Line3);
        Assert.False(model.RawData.ContainsKey("line3"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Country = null,
            Line2 = null,
            Line3 = null,
            PhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Address
        {
            City = "x",
            Line1 = "x",
            Name = "name",
            PostalCode = "x",
            State = "x",
            Country = "x",
            Line2 = "x",
            Line3 = "x",
            PhoneNumber = "x",
        };

        Address copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Method.Usps)]
    [InlineData(Method.FedexPriorityOvernight)]
    [InlineData(Method.Fedex2Day)]
    [InlineData(Method.DhlWorldwideExpress)]
    public void Validation_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Method.Usps)]
    [InlineData(Method.FedexPriorityOvernight)]
    [InlineData(Method.Fedex2Day)]
    [InlineData(Method.DhlWorldwideExpress)]
    public void SerializationRoundtrip_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ScheduleTest : TestBase
{
    [Theory]
    [InlineData(Schedule.NextDay)]
    [InlineData(Schedule.SameDay)]
    public void Validation_Works(Schedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Schedule> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Schedule>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Schedule.NextDay)]
    [InlineData(Schedule.SameDay)]
    public void SerializationRoundtrip_Works(Schedule rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Schedule> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Schedule>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Schedule>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Schedule>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
