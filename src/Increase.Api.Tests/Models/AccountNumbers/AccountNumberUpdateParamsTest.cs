using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Tests.Models.AccountNumbers;

public class AccountNumberUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountNumberUpdateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            InboundAch = new()
            {
                DebitStatus = AccountNumberUpdateParamsInboundAchDebitStatus.Blocked,
            },
            InboundChecks = new(AccountNumberUpdateParamsInboundChecksStatus.Allowed),
            Name = "x",
            Status = AccountNumberUpdateParamsStatus.Disabled,
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        AccountNumberUpdateParamsInboundAch expectedInboundAch = new()
        {
            DebitStatus = AccountNumberUpdateParamsInboundAchDebitStatus.Blocked,
        };
        AccountNumberUpdateParamsInboundChecks expectedInboundChecks = new(
            AccountNumberUpdateParamsInboundChecksStatus.Allowed
        );
        string expectedName = "x";
        ApiEnum<string, AccountNumberUpdateParamsStatus> expectedStatus =
            AccountNumberUpdateParamsStatus.Disabled;

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedInboundAch, parameters.InboundAch);
        Assert.Equal(expectedInboundChecks, parameters.InboundChecks);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountNumberUpdateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        Assert.Null(parameters.InboundAch);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_ach"));
        Assert.Null(parameters.InboundChecks);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_checks"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountNumberUpdateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",

            // Null should be interpreted as omitted for these properties
            InboundAch = null,
            InboundChecks = null,
            Name = null,
            Status = null,
        };

        Assert.Null(parameters.InboundAch);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_ach"));
        Assert.Null(parameters.InboundChecks);
        Assert.False(parameters.RawBodyData.ContainsKey("inbound_checks"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountNumberUpdateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/account_numbers/account_number_v18nkfqm6afpsrvy82b2"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountNumberUpdateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            InboundAch = new()
            {
                DebitStatus = AccountNumberUpdateParamsInboundAchDebitStatus.Blocked,
            },
            InboundChecks = new(AccountNumberUpdateParamsInboundChecksStatus.Allowed),
            Name = "x",
            Status = AccountNumberUpdateParamsStatus.Disabled,
        };

        AccountNumberUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountNumberUpdateParamsInboundAchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch
        {
            DebitStatus = AccountNumberUpdateParamsInboundAchDebitStatus.Allowed,
        };

        ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus> expectedDebitStatus =
            AccountNumberUpdateParamsInboundAchDebitStatus.Allowed;

        Assert.Equal(expectedDebitStatus, model.DebitStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch
        {
            DebitStatus = AccountNumberUpdateParamsInboundAchDebitStatus.Allowed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumberUpdateParamsInboundAch>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch
        {
            DebitStatus = AccountNumberUpdateParamsInboundAchDebitStatus.Allowed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumberUpdateParamsInboundAch>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus> expectedDebitStatus =
            AccountNumberUpdateParamsInboundAchDebitStatus.Allowed;

        Assert.Equal(expectedDebitStatus, deserialized.DebitStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch
        {
            DebitStatus = AccountNumberUpdateParamsInboundAchDebitStatus.Allowed,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch { };

        Assert.Null(model.DebitStatus);
        Assert.False(model.RawData.ContainsKey("debit_status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch
        {
            // Null should be interpreted as omitted for these properties
            DebitStatus = null,
        };

        Assert.Null(model.DebitStatus);
        Assert.False(model.RawData.ContainsKey("debit_status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch
        {
            // Null should be interpreted as omitted for these properties
            DebitStatus = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountNumberUpdateParamsInboundAch
        {
            DebitStatus = AccountNumberUpdateParamsInboundAchDebitStatus.Allowed,
        };

        AccountNumberUpdateParamsInboundAch copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountNumberUpdateParamsInboundAchDebitStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountNumberUpdateParamsInboundAchDebitStatus.Allowed)]
    [InlineData(AccountNumberUpdateParamsInboundAchDebitStatus.Blocked)]
    public void Validation_Works(AccountNumberUpdateParamsInboundAchDebitStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumberUpdateParamsInboundAchDebitStatus.Allowed)]
    [InlineData(AccountNumberUpdateParamsInboundAchDebitStatus.Blocked)]
    public void SerializationRoundtrip_Works(
        AccountNumberUpdateParamsInboundAchDebitStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundAchDebitStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountNumberUpdateParamsInboundChecksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountNumberUpdateParamsInboundChecks
        {
            Status = AccountNumberUpdateParamsInboundChecksStatus.Allowed,
        };

        ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus> expectedStatus =
            AccountNumberUpdateParamsInboundChecksStatus.Allowed;

        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountNumberUpdateParamsInboundChecks
        {
            Status = AccountNumberUpdateParamsInboundChecksStatus.Allowed,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumberUpdateParamsInboundChecks>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountNumberUpdateParamsInboundChecks
        {
            Status = AccountNumberUpdateParamsInboundChecksStatus.Allowed,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountNumberUpdateParamsInboundChecks>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus> expectedStatus =
            AccountNumberUpdateParamsInboundChecksStatus.Allowed;

        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountNumberUpdateParamsInboundChecks
        {
            Status = AccountNumberUpdateParamsInboundChecksStatus.Allowed,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountNumberUpdateParamsInboundChecks
        {
            Status = AccountNumberUpdateParamsInboundChecksStatus.Allowed,
        };

        AccountNumberUpdateParamsInboundChecks copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AccountNumberUpdateParamsInboundChecksStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountNumberUpdateParamsInboundChecksStatus.Allowed)]
    [InlineData(AccountNumberUpdateParamsInboundChecksStatus.CheckTransfersOnly)]
    public void Validation_Works(AccountNumberUpdateParamsInboundChecksStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumberUpdateParamsInboundChecksStatus.Allowed)]
    [InlineData(AccountNumberUpdateParamsInboundChecksStatus.CheckTransfersOnly)]
    public void SerializationRoundtrip_Works(AccountNumberUpdateParamsInboundChecksStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsInboundChecksStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AccountNumberUpdateParamsStatusTest : TestBase
{
    [Theory]
    [InlineData(AccountNumberUpdateParamsStatus.Active)]
    [InlineData(AccountNumberUpdateParamsStatus.Disabled)]
    [InlineData(AccountNumberUpdateParamsStatus.Canceled)]
    public void Validation_Works(AccountNumberUpdateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountNumberUpdateParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AccountNumberUpdateParamsStatus.Active)]
    [InlineData(AccountNumberUpdateParamsStatus.Disabled)]
    [InlineData(AccountNumberUpdateParamsStatus.Canceled)]
    public void SerializationRoundtrip_Works(AccountNumberUpdateParamsStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AccountNumberUpdateParamsStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AccountNumberUpdateParamsStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AccountNumberUpdateParamsStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
