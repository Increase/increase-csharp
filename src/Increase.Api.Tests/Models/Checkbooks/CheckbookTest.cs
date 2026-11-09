using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Checkbooks = Increase.Api.Models.Checkbooks;

namespace Increase.Api.Tests.Models.Checkbooks;

public class CheckbookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Checkbooks::Checkbook
        {
            ID = "checkbook_7iudxhxum6vlkcjxmi8y",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
            },
            Payer =
            [
                new("National Phonograph Company"),
                new("33 Liberty Street"),
                new("New York, NY 10045"),
            ],
            ReturnAddress = new()
            {
                City = "San Francisco",
                Line1 = "244 Kearny St",
                Line2 = "Floor 8",
                Name = "Undeliverable Mail",
                PostalCode = "94108",
                State = "CA",
            },
            Status = Checkbooks::CheckbookStatus.Mailed,
            Style = Checkbooks::Style.ThreeRingBinder,
            TrackingUpdates =
            [
                new()
                {
                    Category = Checkbooks::Category.InTransit,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
                new()
                {
                    Category = Checkbooks::Category.Delivered,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
            ],
            Type = Checkbooks::Type.Checkbook,
        };

        string expectedID = "checkbook_7iudxhxum6vlkcjxmi8y";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        Checkbooks::CheckbookMailingAddress expectedMailingAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            Name = "Ian Crease",
            PostalCode = "10045",
            State = "NY",
        };
        List<Checkbooks::CheckbookPayer> expectedPayer =
        [
            new("National Phonograph Company"),
            new("33 Liberty Street"),
            new("New York, NY 10045"),
        ];
        Checkbooks::ReturnAddress expectedReturnAddress = new()
        {
            City = "San Francisco",
            Line1 = "244 Kearny St",
            Line2 = "Floor 8",
            Name = "Undeliverable Mail",
            PostalCode = "94108",
            State = "CA",
        };
        ApiEnum<string, Checkbooks::CheckbookStatus> expectedStatus =
            Checkbooks::CheckbookStatus.Mailed;
        ApiEnum<string, Checkbooks::Style> expectedStyle = Checkbooks::Style.ThreeRingBinder;
        List<Checkbooks::TrackingUpdate> expectedTrackingUpdates =
        [
            new()
            {
                Category = Checkbooks::Category.InTransit,
                Country = "US",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                PostalCode = "10045",
            },
            new()
            {
                Category = Checkbooks::Category.Delivered,
                Country = "US",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                PostalCode = "10045",
            },
        ];
        ApiEnum<string, Checkbooks::Type> expectedType = Checkbooks::Type.Checkbook;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedMailingAddress, model.MailingAddress);
        Assert.Equal(expectedPayer.Count, model.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], model.Payer[i]);
        }
        Assert.Equal(expectedReturnAddress, model.ReturnAddress);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStyle, model.Style);
        Assert.Equal(expectedTrackingUpdates.Count, model.TrackingUpdates.Count);
        for (int i = 0; i < expectedTrackingUpdates.Count; i++)
        {
            Assert.Equal(expectedTrackingUpdates[i], model.TrackingUpdates[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Checkbooks::Checkbook
        {
            ID = "checkbook_7iudxhxum6vlkcjxmi8y",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
            },
            Payer =
            [
                new("National Phonograph Company"),
                new("33 Liberty Street"),
                new("New York, NY 10045"),
            ],
            ReturnAddress = new()
            {
                City = "San Francisco",
                Line1 = "244 Kearny St",
                Line2 = "Floor 8",
                Name = "Undeliverable Mail",
                PostalCode = "94108",
                State = "CA",
            },
            Status = Checkbooks::CheckbookStatus.Mailed,
            Style = Checkbooks::Style.ThreeRingBinder,
            TrackingUpdates =
            [
                new()
                {
                    Category = Checkbooks::Category.InTransit,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
                new()
                {
                    Category = Checkbooks::Category.Delivered,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
            ],
            Type = Checkbooks::Type.Checkbook,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::Checkbook>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Checkbooks::Checkbook
        {
            ID = "checkbook_7iudxhxum6vlkcjxmi8y",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
            },
            Payer =
            [
                new("National Phonograph Company"),
                new("33 Liberty Street"),
                new("New York, NY 10045"),
            ],
            ReturnAddress = new()
            {
                City = "San Francisco",
                Line1 = "244 Kearny St",
                Line2 = "Floor 8",
                Name = "Undeliverable Mail",
                PostalCode = "94108",
                State = "CA",
            },
            Status = Checkbooks::CheckbookStatus.Mailed,
            Style = Checkbooks::Style.ThreeRingBinder,
            TrackingUpdates =
            [
                new()
                {
                    Category = Checkbooks::Category.InTransit,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
                new()
                {
                    Category = Checkbooks::Category.Delivered,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
            ],
            Type = Checkbooks::Type.Checkbook,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::Checkbook>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "checkbook_7iudxhxum6vlkcjxmi8y";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        Checkbooks::CheckbookMailingAddress expectedMailingAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Line2 = null,
            Name = "Ian Crease",
            PostalCode = "10045",
            State = "NY",
        };
        List<Checkbooks::CheckbookPayer> expectedPayer =
        [
            new("National Phonograph Company"),
            new("33 Liberty Street"),
            new("New York, NY 10045"),
        ];
        Checkbooks::ReturnAddress expectedReturnAddress = new()
        {
            City = "San Francisco",
            Line1 = "244 Kearny St",
            Line2 = "Floor 8",
            Name = "Undeliverable Mail",
            PostalCode = "94108",
            State = "CA",
        };
        ApiEnum<string, Checkbooks::CheckbookStatus> expectedStatus =
            Checkbooks::CheckbookStatus.Mailed;
        ApiEnum<string, Checkbooks::Style> expectedStyle = Checkbooks::Style.ThreeRingBinder;
        List<Checkbooks::TrackingUpdate> expectedTrackingUpdates =
        [
            new()
            {
                Category = Checkbooks::Category.InTransit,
                Country = "US",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                PostalCode = "10045",
            },
            new()
            {
                Category = Checkbooks::Category.Delivered,
                Country = "US",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                PostalCode = "10045",
            },
        ];
        ApiEnum<string, Checkbooks::Type> expectedType = Checkbooks::Type.Checkbook;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedMailingAddress, deserialized.MailingAddress);
        Assert.Equal(expectedPayer.Count, deserialized.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], deserialized.Payer[i]);
        }
        Assert.Equal(expectedReturnAddress, deserialized.ReturnAddress);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStyle, deserialized.Style);
        Assert.Equal(expectedTrackingUpdates.Count, deserialized.TrackingUpdates.Count);
        for (int i = 0; i < expectedTrackingUpdates.Count; i++)
        {
            Assert.Equal(expectedTrackingUpdates[i], deserialized.TrackingUpdates[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Checkbooks::Checkbook
        {
            ID = "checkbook_7iudxhxum6vlkcjxmi8y",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
            },
            Payer =
            [
                new("National Phonograph Company"),
                new("33 Liberty Street"),
                new("New York, NY 10045"),
            ],
            ReturnAddress = new()
            {
                City = "San Francisco",
                Line1 = "244 Kearny St",
                Line2 = "Floor 8",
                Name = "Undeliverable Mail",
                PostalCode = "94108",
                State = "CA",
            },
            Status = Checkbooks::CheckbookStatus.Mailed,
            Style = Checkbooks::Style.ThreeRingBinder,
            TrackingUpdates =
            [
                new()
                {
                    Category = Checkbooks::Category.InTransit,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
                new()
                {
                    Category = Checkbooks::Category.Delivered,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
            ],
            Type = Checkbooks::Type.Checkbook,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Checkbooks::Checkbook
        {
            ID = "checkbook_7iudxhxum6vlkcjxmi8y",
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            IdempotencyKey = null,
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Line2 = null,
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
            },
            Payer =
            [
                new("National Phonograph Company"),
                new("33 Liberty Street"),
                new("New York, NY 10045"),
            ],
            ReturnAddress = new()
            {
                City = "San Francisco",
                Line1 = "244 Kearny St",
                Line2 = "Floor 8",
                Name = "Undeliverable Mail",
                PostalCode = "94108",
                State = "CA",
            },
            Status = Checkbooks::CheckbookStatus.Mailed,
            Style = Checkbooks::Style.ThreeRingBinder,
            TrackingUpdates =
            [
                new()
                {
                    Category = Checkbooks::Category.InTransit,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
                new()
                {
                    Category = Checkbooks::Category.Delivered,
                    Country = "US",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    PostalCode = "10045",
                },
            ],
            Type = Checkbooks::Type.Checkbook,
        };

        Checkbooks::Checkbook copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckbookMailingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Checkbooks::CheckbookMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Checkbooks::CheckbookMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::CheckbookMailingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Checkbooks::CheckbookMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::CheckbookMailingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Checkbooks::CheckbookMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Checkbooks::CheckbookMailingAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        Checkbooks::CheckbookMailingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckbookPayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Checkbooks::CheckbookPayer { Contents = "contents" };

        string expectedContents = "contents";

        Assert.Equal(expectedContents, model.Contents);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Checkbooks::CheckbookPayer { Contents = "contents" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::CheckbookPayer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Checkbooks::CheckbookPayer { Contents = "contents" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::CheckbookPayer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContents = "contents";

        Assert.Equal(expectedContents, deserialized.Contents);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Checkbooks::CheckbookPayer { Contents = "contents" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Checkbooks::CheckbookPayer { Contents = "contents" };

        Checkbooks::CheckbookPayer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReturnAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Checkbooks::ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Checkbooks::ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::ReturnAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Checkbooks::ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::ReturnAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedName = "name";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Checkbooks::ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Checkbooks::ReturnAddress
        {
            City = "city",
            Line1 = "line1",
            Line2 = "line2",
            Name = "name",
            PostalCode = "postal_code",
            State = "state",
        };

        Checkbooks::ReturnAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CheckbookStatusTest : TestBase
{
    [Theory]
    [InlineData(Checkbooks::CheckbookStatus.PendingSubmission)]
    [InlineData(Checkbooks::CheckbookStatus.PendingMailing)]
    [InlineData(Checkbooks::CheckbookStatus.Mailed)]
    [InlineData(Checkbooks::CheckbookStatus.Stopped)]
    public void Validation_Works(Checkbooks::CheckbookStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Checkbooks::CheckbookStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::CheckbookStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Checkbooks::CheckbookStatus.PendingSubmission)]
    [InlineData(Checkbooks::CheckbookStatus.PendingMailing)]
    [InlineData(Checkbooks::CheckbookStatus.Mailed)]
    [InlineData(Checkbooks::CheckbookStatus.Stopped)]
    public void SerializationRoundtrip_Works(Checkbooks::CheckbookStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Checkbooks::CheckbookStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::CheckbookStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::CheckbookStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::CheckbookStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StyleTest : TestBase
{
    [Theory]
    [InlineData(Checkbooks::Style.ThreeRingBinder)]
    [InlineData(Checkbooks::Style.Folder)]
    public void Validation_Works(Checkbooks::Style rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Checkbooks::Style> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Style>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Checkbooks::Style.ThreeRingBinder)]
    [InlineData(Checkbooks::Style.Folder)]
    public void SerializationRoundtrip_Works(Checkbooks::Style rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Checkbooks::Style> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Style>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Style>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Style>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TrackingUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Checkbooks::TrackingUpdate
        {
            Category = Checkbooks::Category.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        ApiEnum<string, Checkbooks::Category> expectedCategory = Checkbooks::Category.InTransit;
        string expectedCountry = "country";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPostalCode = "postal_code";

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPostalCode, model.PostalCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Checkbooks::TrackingUpdate
        {
            Category = Checkbooks::Category.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::TrackingUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Checkbooks::TrackingUpdate
        {
            Category = Checkbooks::Category.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Checkbooks::TrackingUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Checkbooks::Category> expectedCategory = Checkbooks::Category.InTransit;
        string expectedCountry = "country";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPostalCode = "postal_code";

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Checkbooks::TrackingUpdate
        {
            Category = Checkbooks::Category.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Checkbooks::TrackingUpdate
        {
            Category = Checkbooks::Category.InTransit,
            Country = "country",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PostalCode = "postal_code",
        };

        Checkbooks::TrackingUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Checkbooks::Category.InTransit)]
    [InlineData(Checkbooks::Category.ProcessedForDelivery)]
    [InlineData(Checkbooks::Category.Delivered)]
    [InlineData(Checkbooks::Category.DeliveryIssue)]
    [InlineData(Checkbooks::Category.ReturningToSender)]
    [InlineData(Checkbooks::Category.ReturnedToSender)]
    public void Validation_Works(Checkbooks::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Checkbooks::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Checkbooks::Category.InTransit)]
    [InlineData(Checkbooks::Category.ProcessedForDelivery)]
    [InlineData(Checkbooks::Category.Delivered)]
    [InlineData(Checkbooks::Category.DeliveryIssue)]
    [InlineData(Checkbooks::Category.ReturningToSender)]
    [InlineData(Checkbooks::Category.ReturnedToSender)]
    public void SerializationRoundtrip_Works(Checkbooks::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Checkbooks::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Checkbooks::Type.Checkbook)]
    public void Validation_Works(Checkbooks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Checkbooks::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Checkbooks::Type.Checkbook)]
    public void SerializationRoundtrip_Works(Checkbooks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Checkbooks::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Checkbooks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
