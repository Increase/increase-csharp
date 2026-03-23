using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Tests.Models.AccountNumbers;

public class AccountNumberCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountNumberCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",
            InboundAch = new(DebitStatus.Allowed),
            InboundChecks = new(Status.Allowed),
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedName = "Rent payments";
        InboundAch expectedInboundAch = new(DebitStatus.Allowed);
        InboundChecks expectedInboundChecks = new(Status.Allowed);

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedInboundAch, parameters.InboundAch);
        Assert.Equal(expectedInboundChecks, parameters.InboundChecks);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountNumberCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",
        };

        Assert.Null(parameters.InboundAch);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_ach"));
        Assert.Null(parameters.InboundChecks);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_checks"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountNumberCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",

            // Null should be interpreted as omitted for these properties
            InboundAch = null,
            InboundChecks = null,
        };

        Assert.Null(parameters.InboundAch);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_ach"));
        Assert.Null(parameters.InboundChecks);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_checks"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountNumberCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/account_numbers"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountNumberCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Name = "Rent payments",
            InboundAch = new(DebitStatus.Allowed),
            InboundChecks = new(Status.Allowed),
        };

        AccountNumberCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class InboundAchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundAch { DebitStatus = DebitStatus.Allowed };

        ApiEnum<string, DebitStatus> expectedDebitStatus = DebitStatus.Allowed;

        Assert.Equal(expectedDebitStatus, model.DebitStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundAch { DebitStatus = DebitStatus.Allowed };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundAch { DebitStatus = DebitStatus.Allowed };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundAch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DebitStatus> expectedDebitStatus = DebitStatus.Allowed;

        Assert.Equal(expectedDebitStatus, deserialized.DebitStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundAch { DebitStatus = DebitStatus.Allowed };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundAch { DebitStatus = DebitStatus.Allowed };

        InboundAch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DebitStatusTest : TestBase
{
    [Theory]
    [InlineData(DebitStatus.Allowed)]
    [InlineData(DebitStatus.Blocked)]
    public void Validation_Works(DebitStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DebitStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DebitStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DebitStatus.Allowed)]
    [InlineData(DebitStatus.Blocked)]
    public void SerializationRoundtrip_Works(DebitStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DebitStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DebitStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DebitStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DebitStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InboundChecksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundChecks { Status = Status.Allowed };

        ApiEnum<string, Status> expectedStatus = Status.Allowed;

        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundChecks { Status = Status.Allowed };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundChecks>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundChecks { Status = Status.Allowed };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundChecks>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.Allowed;

        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundChecks { Status = Status.Allowed };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundChecks { Status = Status.Allowed };

        InboundChecks copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Allowed)]
    [InlineData(Status.CheckTransfersOnly)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Allowed)]
    [InlineData(Status.CheckTransfersOnly)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
