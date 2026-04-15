using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.Accounts;

namespace Increase.Api.Tests.Models.Accounts;

public class AccountUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AccountUpdateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Loan = new(0),
            Name = "My renamed account",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        AccountUpdateParamsLoan expectedLoan = new(0);
        string expectedName = "My renamed account";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedLoan, parameters.Loan);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AccountUpdateParams { AccountID = "account_in71c4amph0vgo2qllky" };

        Assert.Null(parameters.Loan);
        Assert.False(parameters.RawBodyData.ContainsKey("loan"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AccountUpdateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",

            // Null should be interpreted as omitted for these properties
            Loan = null,
            Name = null,
        };

        Assert.Null(parameters.Loan);
        Assert.False(parameters.RawBodyData.ContainsKey("loan"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        AccountUpdateParams parameters = new() { AccountID = "account_in71c4amph0vgo2qllky" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/accounts/account_in71c4amph0vgo2qllky"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AccountUpdateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Loan = new(0),
            Name = "My renamed account",
        };

        AccountUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AccountUpdateParamsLoanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountUpdateParamsLoan { CreditLimit = 0 };

        long expectedCreditLimit = 0;

        Assert.Equal(expectedCreditLimit, model.CreditLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AccountUpdateParamsLoan { CreditLimit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountUpdateParamsLoan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountUpdateParamsLoan { CreditLimit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AccountUpdateParamsLoan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedCreditLimit = 0;

        Assert.Equal(expectedCreditLimit, deserialized.CreditLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AccountUpdateParamsLoan { CreditLimit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountUpdateParamsLoan { CreditLimit = 0 };

        AccountUpdateParamsLoan copied = new(model);

        Assert.Equal(model, copied);
    }
}
