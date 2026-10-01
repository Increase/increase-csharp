using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using PhysicalCheckBatches = Increase.Api.Models.PhysicalCheckBatches;

namespace Increase.Api.Tests.Models.PhysicalCheckBatches;

public class PhysicalCheckBatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatch
        {
            ID = "physical_check_batch_yzdwjhdbw0in6191whce",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "National Phonograph Company",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ShippingMethod = PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass,
            Status = PhysicalCheckBatches::Status.Pending,
            Type = PhysicalCheckBatches::Type.PhysicalCheckBatch,
        };

        string expectedID = "physical_check_batch_yzdwjhdbw0in6191whce";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        PhysicalCheckBatches::PhysicalCheckBatchMailingAddress expectedMailingAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            Name = "Ian Crease",
            Phone = null,
            PostalCode = "10045",
            State = "NY",
        };
        PhysicalCheckBatches::PhysicalCheckBatchReturnAddress expectedReturnAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            Name = "National Phonograph Company",
            Phone = null,
            PostalCode = "10045",
            State = "NY",
        };
        ApiEnum<
            string,
            PhysicalCheckBatches::PhysicalCheckBatchShippingMethod
        > expectedShippingMethod =
            PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass;
        ApiEnum<string, PhysicalCheckBatches::Status> expectedStatus =
            PhysicalCheckBatches::Status.Pending;
        ApiEnum<string, PhysicalCheckBatches::Type> expectedType =
            PhysicalCheckBatches::Type.PhysicalCheckBatch;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedMailingAddress, model.MailingAddress);
        Assert.Equal(expectedReturnAddress, model.ReturnAddress);
        Assert.Equal(expectedShippingMethod, model.ShippingMethod);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatch
        {
            ID = "physical_check_batch_yzdwjhdbw0in6191whce",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "National Phonograph Company",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ShippingMethod = PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass,
            Status = PhysicalCheckBatches::Status.Pending,
            Type = PhysicalCheckBatches::Type.PhysicalCheckBatch,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCheckBatches::PhysicalCheckBatch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatch
        {
            ID = "physical_check_batch_yzdwjhdbw0in6191whce",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "National Phonograph Company",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ShippingMethod = PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass,
            Status = PhysicalCheckBatches::Status.Pending,
            Type = PhysicalCheckBatches::Type.PhysicalCheckBatch,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCheckBatches::PhysicalCheckBatch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "physical_check_batch_yzdwjhdbw0in6191whce";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        PhysicalCheckBatches::PhysicalCheckBatchMailingAddress expectedMailingAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            Name = "Ian Crease",
            Phone = null,
            PostalCode = "10045",
            State = "NY",
        };
        PhysicalCheckBatches::PhysicalCheckBatchReturnAddress expectedReturnAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            Name = "National Phonograph Company",
            Phone = null,
            PostalCode = "10045",
            State = "NY",
        };
        ApiEnum<
            string,
            PhysicalCheckBatches::PhysicalCheckBatchShippingMethod
        > expectedShippingMethod =
            PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass;
        ApiEnum<string, PhysicalCheckBatches::Status> expectedStatus =
            PhysicalCheckBatches::Status.Pending;
        ApiEnum<string, PhysicalCheckBatches::Type> expectedType =
            PhysicalCheckBatches::Type.PhysicalCheckBatch;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedMailingAddress, deserialized.MailingAddress);
        Assert.Equal(expectedReturnAddress, deserialized.ReturnAddress);
        Assert.Equal(expectedShippingMethod, deserialized.ShippingMethod);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatch
        {
            ID = "physical_check_batch_yzdwjhdbw0in6191whce",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "National Phonograph Company",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ShippingMethod = PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass,
            Status = PhysicalCheckBatches::Status.Pending,
            Type = PhysicalCheckBatches::Type.PhysicalCheckBatch,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatch
        {
            ID = "physical_check_batch_yzdwjhdbw0in6191whce",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ReturnAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "National Phonograph Company",
                Phone = null,
                PostalCode = "10045",
                State = "NY",
            },
            ShippingMethod = PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass,
            Status = PhysicalCheckBatches::Status.Pending,
            Type = PhysicalCheckBatches::Type.PhysicalCheckBatch,
        };

        PhysicalCheckBatches::PhysicalCheckBatch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhysicalCheckBatchMailingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PhysicalCheckBatches::PhysicalCheckBatchMailingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PhysicalCheckBatches::PhysicalCheckBatchMailingAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        PhysicalCheckBatches::PhysicalCheckBatchMailingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhysicalCheckBatchReturnAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PhysicalCheckBatches::PhysicalCheckBatchReturnAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PhysicalCheckBatches::PhysicalCheckBatchReturnAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPhone = "phone";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCheckBatches::PhysicalCheckBatchReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            Phone = "phone",
            PostalCode = "postal_code",
            State = "state",
        };

        PhysicalCheckBatches::PhysicalCheckBatchReturnAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PhysicalCheckBatchShippingMethodTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass)]
    [InlineData(PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.FedexOvernight)]
    public void Validation_Works(PhysicalCheckBatches::PhysicalCheckBatchShippingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCheckBatches::PhysicalCheckBatchShippingMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCheckBatches::PhysicalCheckBatchShippingMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.UspsFirstClass)]
    [InlineData(PhysicalCheckBatches::PhysicalCheckBatchShippingMethod.FedexOvernight)]
    public void SerializationRoundtrip_Works(
        PhysicalCheckBatches::PhysicalCheckBatchShippingMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCheckBatches::PhysicalCheckBatchShippingMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCheckBatches::PhysicalCheckBatchShippingMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCheckBatches::PhysicalCheckBatchShippingMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCheckBatches::PhysicalCheckBatchShippingMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCheckBatches::Status.Pending)]
    [InlineData(PhysicalCheckBatches::Status.Completed)]
    [InlineData(PhysicalCheckBatches::Status.Canceled)]
    [InlineData(PhysicalCheckBatches::Status.RequiresAttention)]
    public void Validation_Works(PhysicalCheckBatches::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCheckBatches::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCheckBatches::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCheckBatches::Status.Pending)]
    [InlineData(PhysicalCheckBatches::Status.Completed)]
    [InlineData(PhysicalCheckBatches::Status.Canceled)]
    [InlineData(PhysicalCheckBatches::Status.RequiresAttention)]
    public void SerializationRoundtrip_Works(PhysicalCheckBatches::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCheckBatches::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCheckBatches::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCheckBatches::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PhysicalCheckBatches::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(PhysicalCheckBatches::Type.PhysicalCheckBatch)]
    public void Validation_Works(PhysicalCheckBatches::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCheckBatches::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCheckBatches::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhysicalCheckBatches::Type.PhysicalCheckBatch)]
    public void SerializationRoundtrip_Works(PhysicalCheckBatches::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhysicalCheckBatches::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCheckBatches::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCheckBatches::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhysicalCheckBatches::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
