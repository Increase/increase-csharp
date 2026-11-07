using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using CheckbookChecks = Increase.Api.Models.CheckbookChecks;

namespace Increase.Api.Tests.Models.CheckbookChecks;

public class CheckbookCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckbookChecks::CheckbookCheck
        {
            ID = "checkbook_check_klgh3z50guf6jcnfhibb",
            CheckNumber = 1,
            CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Status = CheckbookChecks::Status.PendingDeposit,
            Type = CheckbookChecks::Type.CheckbookCheck,
        };

        string expectedID = "checkbook_check_klgh3z50guf6jcnfhibb";
        long expectedCheckNumber = 1;
        string expectedCheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, CheckbookChecks::Status> expectedStatus =
            CheckbookChecks::Status.PendingDeposit;
        ApiEnum<string, CheckbookChecks::Type> expectedType = CheckbookChecks::Type.CheckbookCheck;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCheckNumber, model.CheckNumber);
        Assert.Equal(expectedCheckbookID, model.CheckbookID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckbookChecks::CheckbookCheck
        {
            ID = "checkbook_check_klgh3z50guf6jcnfhibb",
            CheckNumber = 1,
            CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Status = CheckbookChecks::Status.PendingDeposit,
            Type = CheckbookChecks::Type.CheckbookCheck,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckbookChecks::CheckbookCheck>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckbookChecks::CheckbookCheck
        {
            ID = "checkbook_check_klgh3z50guf6jcnfhibb",
            CheckNumber = 1,
            CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Status = CheckbookChecks::Status.PendingDeposit,
            Type = CheckbookChecks::Type.CheckbookCheck,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckbookChecks::CheckbookCheck>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "checkbook_check_klgh3z50guf6jcnfhibb";
        long expectedCheckNumber = 1;
        string expectedCheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, CheckbookChecks::Status> expectedStatus =
            CheckbookChecks::Status.PendingDeposit;
        ApiEnum<string, CheckbookChecks::Type> expectedType = CheckbookChecks::Type.CheckbookCheck;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCheckNumber, deserialized.CheckNumber);
        Assert.Equal(expectedCheckbookID, deserialized.CheckbookID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckbookChecks::CheckbookCheck
        {
            ID = "checkbook_check_klgh3z50guf6jcnfhibb",
            CheckNumber = 1,
            CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Status = CheckbookChecks::Status.PendingDeposit,
            Type = CheckbookChecks::Type.CheckbookCheck,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckbookChecks::CheckbookCheck
        {
            ID = "checkbook_check_klgh3z50guf6jcnfhibb",
            CheckNumber = 1,
            CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Status = CheckbookChecks::Status.PendingDeposit,
            Type = CheckbookChecks::Type.CheckbookCheck,
        };

        CheckbookChecks::CheckbookCheck copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(CheckbookChecks::Status.PendingDeposit)]
    [InlineData(CheckbookChecks::Status.Deposited)]
    [InlineData(CheckbookChecks::Status.Stopped)]
    [InlineData(CheckbookChecks::Status.RequiresAttention)]
    public void Validation_Works(CheckbookChecks::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckbookChecks::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckbookChecks::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckbookChecks::Status.PendingDeposit)]
    [InlineData(CheckbookChecks::Status.Deposited)]
    [InlineData(CheckbookChecks::Status.Stopped)]
    [InlineData(CheckbookChecks::Status.RequiresAttention)]
    public void SerializationRoundtrip_Works(CheckbookChecks::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckbookChecks::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckbookChecks::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckbookChecks::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckbookChecks::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(CheckbookChecks::Type.CheckbookCheck)]
    public void Validation_Works(CheckbookChecks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckbookChecks::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckbookChecks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CheckbookChecks::Type.CheckbookCheck)]
    public void SerializationRoundtrip_Works(CheckbookChecks::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CheckbookChecks::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckbookChecks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CheckbookChecks::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CheckbookChecks::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
