using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using OAuthApplications = Increase.Api.Models.OAuthApplications;

namespace Increase.Api.Tests.Models.OAuthApplications;

public class OAuthApplicationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OAuthApplications::OAuthApplication
        {
            ID = "application_gj9ufmpgh5i56k4vyriy",
            ClientID = "client_id_ec79nb1bukwwafdewe88",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            Name = "Ian Crease's App",
            Status = OAuthApplications::OAuthApplicationStatus.Active,
            Type = OAuthApplications::Type.OAuthApplication,
        };

        string expectedID = "application_gj9ufmpgh5i56k4vyriy";
        string expectedClientID = "client_id_ec79nb1bukwwafdewe88";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedName = "Ian Crease's App";
        ApiEnum<string, OAuthApplications::OAuthApplicationStatus> expectedStatus =
            OAuthApplications::OAuthApplicationStatus.Active;
        ApiEnum<string, OAuthApplications::Type> expectedType =
            OAuthApplications::Type.OAuthApplication;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Null(model.DeletedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OAuthApplications::OAuthApplication
        {
            ID = "application_gj9ufmpgh5i56k4vyriy",
            ClientID = "client_id_ec79nb1bukwwafdewe88",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            Name = "Ian Crease's App",
            Status = OAuthApplications::OAuthApplicationStatus.Active,
            Type = OAuthApplications::Type.OAuthApplication,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OAuthApplications::OAuthApplication>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OAuthApplications::OAuthApplication
        {
            ID = "application_gj9ufmpgh5i56k4vyriy",
            ClientID = "client_id_ec79nb1bukwwafdewe88",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            Name = "Ian Crease's App",
            Status = OAuthApplications::OAuthApplicationStatus.Active,
            Type = OAuthApplications::Type.OAuthApplication,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OAuthApplications::OAuthApplication>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "application_gj9ufmpgh5i56k4vyriy";
        string expectedClientID = "client_id_ec79nb1bukwwafdewe88";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedName = "Ian Crease's App";
        ApiEnum<string, OAuthApplications::OAuthApplicationStatus> expectedStatus =
            OAuthApplications::OAuthApplicationStatus.Active;
        ApiEnum<string, OAuthApplications::Type> expectedType =
            OAuthApplications::Type.OAuthApplication;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Null(deserialized.DeletedAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OAuthApplications::OAuthApplication
        {
            ID = "application_gj9ufmpgh5i56k4vyriy",
            ClientID = "client_id_ec79nb1bukwwafdewe88",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            Name = "Ian Crease's App",
            Status = OAuthApplications::OAuthApplicationStatus.Active,
            Type = OAuthApplications::Type.OAuthApplication,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OAuthApplications::OAuthApplication
        {
            ID = "application_gj9ufmpgh5i56k4vyriy",
            ClientID = "client_id_ec79nb1bukwwafdewe88",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DeletedAt = null,
            Name = "Ian Crease's App",
            Status = OAuthApplications::OAuthApplicationStatus.Active,
            Type = OAuthApplications::Type.OAuthApplication,
        };

        OAuthApplications::OAuthApplication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OAuthApplicationStatusTest : TestBase
{
    [Theory]
    [InlineData(OAuthApplications::OAuthApplicationStatus.Active)]
    [InlineData(OAuthApplications::OAuthApplicationStatus.Deleted)]
    public void Validation_Works(OAuthApplications::OAuthApplicationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OAuthApplications::OAuthApplicationStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OAuthApplications::OAuthApplicationStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OAuthApplications::OAuthApplicationStatus.Active)]
    [InlineData(OAuthApplications::OAuthApplicationStatus.Deleted)]
    public void SerializationRoundtrip_Works(OAuthApplications::OAuthApplicationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OAuthApplications::OAuthApplicationStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OAuthApplications::OAuthApplicationStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, OAuthApplications::OAuthApplicationStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, OAuthApplications::OAuthApplicationStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(OAuthApplications::Type.OAuthApplication)]
    public void Validation_Works(OAuthApplications::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OAuthApplications::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OAuthApplications::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OAuthApplications::Type.OAuthApplication)]
    public void SerializationRoundtrip_Works(OAuthApplications::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OAuthApplications::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OAuthApplications::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OAuthApplications::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OAuthApplications::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
