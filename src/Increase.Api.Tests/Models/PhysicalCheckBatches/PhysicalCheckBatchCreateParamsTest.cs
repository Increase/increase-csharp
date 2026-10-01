using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.PhysicalCheckBatches;

namespace Increase.Api.Tests.Models.PhysicalCheckBatches;

public class PhysicalCheckBatchCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCheckBatchCreateParams
        {
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "National Phonograph Company",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
            ShippingMethod = ShippingMethod.UspsFirstClass,
        };

        MailingAddress expectedMailingAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Name = "Ian Crease",
            PostalCode = "10045",
            State = "NY",
            Line2 = "line2",
            Phone = "x",
        };
        ReturnAddress expectedReturnAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Name = "National Phonograph Company",
            PostalCode = "10045",
            State = "NY",
            Line2 = "line2",
            Phone = "x",
        };
        ApiEnum<string, ShippingMethod> expectedShippingMethod = ShippingMethod.UspsFirstClass;

        Assert.Equal(expectedMailingAddress, parameters.MailingAddress);
        Assert.Equal(expectedReturnAddress, parameters.ReturnAddress);
        Assert.Equal(expectedShippingMethod, parameters.ShippingMethod);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhysicalCheckBatchCreateParams
        {
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "National Phonograph Company",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
        };

        Assert.Null(parameters.ShippingMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("shipping_method"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhysicalCheckBatchCreateParams
        {
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "National Phonograph Company",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },

            // Null should be interpreted as omitted for these properties
            ShippingMethod = null,
        };

        Assert.Null(parameters.ShippingMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("shipping_method"));
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCheckBatchCreateParams parameters = new()
        {
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "National Phonograph Company",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/physical_check_batches"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCheckBatchCreateParams
        {
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "National Phonograph Company",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
                Phone = "x",
            },
            ShippingMethod = ShippingMethod.UspsFirstClass,
        };

        PhysicalCheckBatchCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MailingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedName = "name";
        string expectedPostalCode = "21029-9469";
        string expectedState = "xx";
        string expectedLine2 = "line2";
        string expectedPhone = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MailingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MailingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedName = "name";
        string expectedPostalCode = "21029-9469";
        string expectedState = "xx";
        string expectedLine2 = "line2";
        string expectedPhone = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Phone = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MailingAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        MailingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReturnAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedName = "name";
        string expectedPostalCode = "21029-9469";
        string expectedState = "xx";
        string expectedLine2 = "line2";
        string expectedPhone = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReturnAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReturnAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedName = "name";
        string expectedPostalCode = "21029-9469";
        string expectedState = "xx";
        string expectedLine2 = "line2";
        string expectedPhone = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Phone = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Name = "name",
            PostalCode = "21029-9469",
            State = "xx",
            Line2 = "line2",
            Phone = "x",
        };

        ReturnAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ShippingMethodTest : TestBase
{
    [Theory]
    [InlineData(ShippingMethod.UspsFirstClass)]
    [InlineData(ShippingMethod.FedexOvernight)]
    public void Validation_Works(ShippingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShippingMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShippingMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ShippingMethod.UspsFirstClass)]
    [InlineData(ShippingMethod.FedexOvernight)]
    public void SerializationRoundtrip_Works(ShippingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShippingMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShippingMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShippingMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShippingMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
