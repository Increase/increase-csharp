using System;
using Increase.Api.Models.CardValidations;

namespace Increase.Api.Tests.Models.CardValidations;

public class CardValidationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardValidationCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            CardholderFirstName = "Dee",
            CardholderLastName = "Hock",
            CardholderMiddleName = "Ward",
            CardholderPostalCode = "10045",
            CardholderStreetAddress = "33 Liberty Street",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedCardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";
        string expectedMerchantCategoryCode = "1234";
        string expectedMerchantCityName = "New York";
        string expectedMerchantName = "Acme Corp";
        string expectedMerchantPostalCode = "10045";
        string expectedMerchantState = "NY";
        string expectedCardholderFirstName = "Dee";
        string expectedCardholderLastName = "Hock";
        string expectedCardholderMiddleName = "Ward";
        string expectedCardholderPostalCode = "10045";
        string expectedCardholderStreetAddress = "33 Liberty Street";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedCardTokenID, parameters.CardTokenID);
        Assert.Equal(expectedMerchantCategoryCode, parameters.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCityName, parameters.MerchantCityName);
        Assert.Equal(expectedMerchantName, parameters.MerchantName);
        Assert.Equal(expectedMerchantPostalCode, parameters.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, parameters.MerchantState);
        Assert.Equal(expectedCardholderFirstName, parameters.CardholderFirstName);
        Assert.Equal(expectedCardholderLastName, parameters.CardholderLastName);
        Assert.Equal(expectedCardholderMiddleName, parameters.CardholderMiddleName);
        Assert.Equal(expectedCardholderPostalCode, parameters.CardholderPostalCode);
        Assert.Equal(expectedCardholderStreetAddress, parameters.CardholderStreetAddress);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardValidationCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
        };

        Assert.Null(parameters.CardholderFirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_first_name"));
        Assert.Null(parameters.CardholderLastName);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_last_name"));
        Assert.Null(parameters.CardholderMiddleName);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_middle_name"));
        Assert.Null(parameters.CardholderPostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_postal_code"));
        Assert.Null(parameters.CardholderStreetAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_street_address"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardValidationCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantPostalCode = "10045",
            MerchantState = "NY",

            // Null should be interpreted as omitted for these properties
            CardholderFirstName = null,
            CardholderLastName = null,
            CardholderMiddleName = null,
            CardholderPostalCode = null,
            CardholderStreetAddress = null,
        };

        Assert.Null(parameters.CardholderFirstName);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_first_name"));
        Assert.Null(parameters.CardholderLastName);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_last_name"));
        Assert.Null(parameters.CardholderMiddleName);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_middle_name"));
        Assert.Null(parameters.CardholderPostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_postal_code"));
        Assert.Null(parameters.CardholderStreetAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("cardholder_street_address"));
    }

    [Fact]
    public void Url_Works()
    {
        CardValidationCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/card_validations"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardValidationCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            CardholderFirstName = "Dee",
            CardholderLastName = "Hock",
            CardholderMiddleName = "Ward",
            CardholderPostalCode = "10045",
            CardholderStreetAddress = "33 Liberty Street",
        };

        CardValidationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
