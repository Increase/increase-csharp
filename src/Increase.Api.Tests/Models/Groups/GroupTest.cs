using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Groups = Increase.Api.Models.Groups;

namespace Increase.Api.Tests.Models.Groups;

public class GroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Groups::Group
        {
            ID = "group_1g4mhziu6kvrs3vz35um",
            AchDebitStatus = Groups::AchDebitStatus.Disabled,
            ActivationStatus = Groups::ActivationStatus.Activated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Groups::Type.Group,
        };

        string expectedID = "group_1g4mhziu6kvrs3vz35um";
        ApiEnum<string, Groups::AchDebitStatus> expectedAchDebitStatus =
            Groups::AchDebitStatus.Disabled;
        ApiEnum<string, Groups::ActivationStatus> expectedActivationStatus =
            Groups::ActivationStatus.Activated;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, Groups::Type> expectedType = Groups::Type.Group;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAchDebitStatus, model.AchDebitStatus);
        Assert.Equal(expectedActivationStatus, model.ActivationStatus);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Groups::Group
        {
            ID = "group_1g4mhziu6kvrs3vz35um",
            AchDebitStatus = Groups::AchDebitStatus.Disabled,
            ActivationStatus = Groups::ActivationStatus.Activated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Groups::Type.Group,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Groups::Group>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Groups::Group
        {
            ID = "group_1g4mhziu6kvrs3vz35um",
            AchDebitStatus = Groups::AchDebitStatus.Disabled,
            ActivationStatus = Groups::ActivationStatus.Activated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Groups::Type.Group,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Groups::Group>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "group_1g4mhziu6kvrs3vz35um";
        ApiEnum<string, Groups::AchDebitStatus> expectedAchDebitStatus =
            Groups::AchDebitStatus.Disabled;
        ApiEnum<string, Groups::ActivationStatus> expectedActivationStatus =
            Groups::ActivationStatus.Activated;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, Groups::Type> expectedType = Groups::Type.Group;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAchDebitStatus, deserialized.AchDebitStatus);
        Assert.Equal(expectedActivationStatus, deserialized.ActivationStatus);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Groups::Group
        {
            ID = "group_1g4mhziu6kvrs3vz35um",
            AchDebitStatus = Groups::AchDebitStatus.Disabled,
            ActivationStatus = Groups::ActivationStatus.Activated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Groups::Type.Group,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Groups::Group
        {
            ID = "group_1g4mhziu6kvrs3vz35um",
            AchDebitStatus = Groups::AchDebitStatus.Disabled,
            ActivationStatus = Groups::ActivationStatus.Activated,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = Groups::Type.Group,
        };

        Groups::Group copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AchDebitStatusTest : TestBase
{
    [Theory]
    [InlineData(Groups::AchDebitStatus.Disabled)]
    [InlineData(Groups::AchDebitStatus.Enabled)]
    public void Validation_Works(Groups::AchDebitStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Groups::AchDebitStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Groups::AchDebitStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Groups::AchDebitStatus.Disabled)]
    [InlineData(Groups::AchDebitStatus.Enabled)]
    public void SerializationRoundtrip_Works(Groups::AchDebitStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Groups::AchDebitStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Groups::AchDebitStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Groups::AchDebitStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Groups::AchDebitStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ActivationStatusTest : TestBase
{
    [Theory]
    [InlineData(Groups::ActivationStatus.Unactivated)]
    [InlineData(Groups::ActivationStatus.Activated)]
    public void Validation_Works(Groups::ActivationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Groups::ActivationStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Groups::ActivationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Groups::ActivationStatus.Unactivated)]
    [InlineData(Groups::ActivationStatus.Activated)]
    public void SerializationRoundtrip_Works(Groups::ActivationStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Groups::ActivationStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Groups::ActivationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Groups::ActivationStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Groups::ActivationStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Groups::Type.Group)]
    public void Validation_Works(Groups::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Groups::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Groups::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Groups::Type.Group)]
    public void SerializationRoundtrip_Works(Groups::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Groups::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Groups::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Groups::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Groups::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
