using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.Checkbooks;

namespace Increase.Api.Tests.Models.Checkbooks;

public class CheckbookCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckbookCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
            },
            Payer =
            [
                new("National Phonograph Company"),
                new("33 Liberty Street"),
                new("New York, NY 10045"),
            ],
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        MailingAddress expectedMailingAddress = new()
        {
            City = "New York",
            Line1 = "33 Liberty Street",
            Name = "Ian Crease",
            PostalCode = "10045",
            State = "NY",
            Line2 = "line2",
        };
        List<Payer> expectedPayer =
        [
            new("National Phonograph Company"),
            new("33 Liberty Street"),
            new("New York, NY 10045"),
        ];

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedMailingAddress, parameters.MailingAddress);
        Assert.Equal(expectedPayer.Count, parameters.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], parameters.Payer[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        CheckbookCreateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
            },
            Payer =
            [
                new("National Phonograph Company"),
                new("33 Liberty Street"),
                new("New York, NY 10045"),
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/checkbooks"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckbookCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                Name = "Ian Crease",
                PostalCode = "10045",
                State = "NY",
                Line2 = "line2",
            },
            Payer =
            [
                new("National Phonograph Company"),
                new("33 Liberty Street"),
                new("New York, NY 10045"),
            ],
        };

        CheckbookCreateParams copied = new(parameters);

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
        };

        string expectedCity = "city";
        string expectedLine1 = "line1";
        string expectedName = "name";
        string expectedPostalCode = "21029-9469";
        string expectedState = "xx";
        string expectedLine2 = "line2";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedLine2, model.Line2);
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

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedLine2, deserialized.Line2);
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
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
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
        };

        MailingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Payer { Contents = "contents" };

        string expectedContents = "contents";

        Assert.Equal(expectedContents, model.Contents);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Payer { Contents = "contents" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payer>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Payer { Contents = "contents" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payer>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedContents = "contents";

        Assert.Equal(expectedContents, deserialized.Contents);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Payer { Contents = "contents" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Payer { Contents = "contents" };

        Payer copied = new(model);

        Assert.Equal(model, copied);
    }
}
