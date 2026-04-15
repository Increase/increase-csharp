using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CardPushTransfers;

namespace Increase.Api.Tests.Models.CardPushTransfers;

public class CardPushTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardPushTransferCreateParams
        {
            BusinessApplicationIdentifier = BusinessApplicationIdentifier.FundsDisbursement,
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantNamePrefix = "Acme",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            PresentmentAmount = new() { Currency = Currency.Usd, Value = "1234.56" },
            RecipientName = "Ian Crease",
            SenderAddressCity = "New York",
            SenderAddressLine1 = "33 Liberty Street",
            SenderAddressPostalCode = "10045",
            SenderAddressState = "NY",
            SenderName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            MerchantLegalBusinessName = "x6",
            MerchantStreetAddress = "merchant_street_address",
            RecipientAddressCity = "recipient_address_city",
            RecipientAddressLine1 = "recipient_address_line1",
            RecipientAddressPostalCode = "x6",
            RecipientAddressState = "x6",
            RequireApproval = true,
        };

        ApiEnum<string, BusinessApplicationIdentifier> expectedBusinessApplicationIdentifier =
            BusinessApplicationIdentifier.FundsDisbursement;
        string expectedCardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0";
        string expectedMerchantCategoryCode = "1234";
        string expectedMerchantCityName = "New York";
        string expectedMerchantName = "Acme Corp";
        string expectedMerchantNamePrefix = "Acme";
        string expectedMerchantPostalCode = "10045";
        string expectedMerchantState = "NY";
        PresentmentAmount expectedPresentmentAmount = new()
        {
            Currency = Currency.Usd,
            Value = "1234.56",
        };
        string expectedRecipientName = "Ian Crease";
        string expectedSenderAddressCity = "New York";
        string expectedSenderAddressLine1 = "33 Liberty Street";
        string expectedSenderAddressPostalCode = "10045";
        string expectedSenderAddressState = "NY";
        string expectedSenderName = "Ian Crease";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedMerchantLegalBusinessName = "x6";
        string expectedMerchantStreetAddress = "merchant_street_address";
        string expectedRecipientAddressCity = "recipient_address_city";
        string expectedRecipientAddressLine1 = "recipient_address_line1";
        string expectedRecipientAddressPostalCode = "x6";
        string expectedRecipientAddressState = "x6";
        bool expectedRequireApproval = true;

        Assert.Equal(
            expectedBusinessApplicationIdentifier,
            parameters.BusinessApplicationIdentifier
        );
        Assert.Equal(expectedCardTokenID, parameters.CardTokenID);
        Assert.Equal(expectedMerchantCategoryCode, parameters.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCityName, parameters.MerchantCityName);
        Assert.Equal(expectedMerchantName, parameters.MerchantName);
        Assert.Equal(expectedMerchantNamePrefix, parameters.MerchantNamePrefix);
        Assert.Equal(expectedMerchantPostalCode, parameters.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, parameters.MerchantState);
        Assert.Equal(expectedPresentmentAmount, parameters.PresentmentAmount);
        Assert.Equal(expectedRecipientName, parameters.RecipientName);
        Assert.Equal(expectedSenderAddressCity, parameters.SenderAddressCity);
        Assert.Equal(expectedSenderAddressLine1, parameters.SenderAddressLine1);
        Assert.Equal(expectedSenderAddressPostalCode, parameters.SenderAddressPostalCode);
        Assert.Equal(expectedSenderAddressState, parameters.SenderAddressState);
        Assert.Equal(expectedSenderName, parameters.SenderName);
        Assert.Equal(expectedSourceAccountNumberID, parameters.SourceAccountNumberID);
        Assert.Equal(expectedMerchantLegalBusinessName, parameters.MerchantLegalBusinessName);
        Assert.Equal(expectedMerchantStreetAddress, parameters.MerchantStreetAddress);
        Assert.Equal(expectedRecipientAddressCity, parameters.RecipientAddressCity);
        Assert.Equal(expectedRecipientAddressLine1, parameters.RecipientAddressLine1);
        Assert.Equal(expectedRecipientAddressPostalCode, parameters.RecipientAddressPostalCode);
        Assert.Equal(expectedRecipientAddressState, parameters.RecipientAddressState);
        Assert.Equal(expectedRequireApproval, parameters.RequireApproval);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardPushTransferCreateParams
        {
            BusinessApplicationIdentifier = BusinessApplicationIdentifier.FundsDisbursement,
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantNamePrefix = "Acme",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            PresentmentAmount = new() { Currency = Currency.Usd, Value = "1234.56" },
            RecipientName = "Ian Crease",
            SenderAddressCity = "New York",
            SenderAddressLine1 = "33 Liberty Street",
            SenderAddressPostalCode = "10045",
            SenderAddressState = "NY",
            SenderName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        Assert.Null(parameters.MerchantLegalBusinessName);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_legal_business_name"));
        Assert.Null(parameters.MerchantStreetAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_street_address"));
        Assert.Null(parameters.RecipientAddressCity);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_address_city"));
        Assert.Null(parameters.RecipientAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_address_line1"));
        Assert.Null(parameters.RecipientAddressPostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_address_postal_code"));
        Assert.Null(parameters.RecipientAddressState);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_address_state"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardPushTransferCreateParams
        {
            BusinessApplicationIdentifier = BusinessApplicationIdentifier.FundsDisbursement,
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantNamePrefix = "Acme",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            PresentmentAmount = new() { Currency = Currency.Usd, Value = "1234.56" },
            RecipientName = "Ian Crease",
            SenderAddressCity = "New York",
            SenderAddressLine1 = "33 Liberty Street",
            SenderAddressPostalCode = "10045",
            SenderAddressState = "NY",
            SenderName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",

            // Null should be interpreted as omitted for these properties
            MerchantLegalBusinessName = null,
            MerchantStreetAddress = null,
            RecipientAddressCity = null,
            RecipientAddressLine1 = null,
            RecipientAddressPostalCode = null,
            RecipientAddressState = null,
            RequireApproval = null,
        };

        Assert.Null(parameters.MerchantLegalBusinessName);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_legal_business_name"));
        Assert.Null(parameters.MerchantStreetAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("merchant_street_address"));
        Assert.Null(parameters.RecipientAddressCity);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_address_city"));
        Assert.Null(parameters.RecipientAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_address_line1"));
        Assert.Null(parameters.RecipientAddressPostalCode);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_address_postal_code"));
        Assert.Null(parameters.RecipientAddressState);
        Assert.False(parameters.RawBodyData.ContainsKey("recipient_address_state"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
    }

    [Fact]
    public void Url_Works()
    {
        CardPushTransferCreateParams parameters = new()
        {
            BusinessApplicationIdentifier = BusinessApplicationIdentifier.FundsDisbursement,
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantNamePrefix = "Acme",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            PresentmentAmount = new() { Currency = Currency.Usd, Value = "1234.56" },
            RecipientName = "Ian Crease",
            SenderAddressCity = "New York",
            SenderAddressLine1 = "33 Liberty Street",
            SenderAddressPostalCode = "10045",
            SenderAddressState = "NY",
            SenderName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.increase.com/card_push_transfers"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardPushTransferCreateParams
        {
            BusinessApplicationIdentifier = BusinessApplicationIdentifier.FundsDisbursement,
            CardTokenID = "outbound_card_token_zlt0ml6youq3q7vcdlg0",
            MerchantCategoryCode = "1234",
            MerchantCityName = "New York",
            MerchantName = "Acme Corp",
            MerchantNamePrefix = "Acme",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            PresentmentAmount = new() { Currency = Currency.Usd, Value = "1234.56" },
            RecipientName = "Ian Crease",
            SenderAddressCity = "New York",
            SenderAddressLine1 = "33 Liberty Street",
            SenderAddressPostalCode = "10045",
            SenderAddressState = "NY",
            SenderName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            MerchantLegalBusinessName = "x6",
            MerchantStreetAddress = "merchant_street_address",
            RecipientAddressCity = "recipient_address_city",
            RecipientAddressLine1 = "recipient_address_line1",
            RecipientAddressPostalCode = "x6",
            RecipientAddressState = "x6",
            RequireApproval = true,
        };

        CardPushTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BusinessApplicationIdentifierTest : TestBase
{
    [Theory]
    [InlineData(BusinessApplicationIdentifier.AccountToAccount)]
    [InlineData(BusinessApplicationIdentifier.BusinessToBusiness)]
    [InlineData(BusinessApplicationIdentifier.MoneyTransferBankInitiated)]
    [InlineData(BusinessApplicationIdentifier.NonCardBillPayment)]
    [InlineData(BusinessApplicationIdentifier.ConsumerBillPayment)]
    [InlineData(BusinessApplicationIdentifier.CardBillPayment)]
    [InlineData(BusinessApplicationIdentifier.FundsDisbursement)]
    [InlineData(BusinessApplicationIdentifier.FundsTransfer)]
    [InlineData(BusinessApplicationIdentifier.LoyaltyAndOffers)]
    [InlineData(BusinessApplicationIdentifier.MerchantDisbursement)]
    [InlineData(BusinessApplicationIdentifier.MerchantPayment)]
    [InlineData(BusinessApplicationIdentifier.PersonToPerson)]
    [InlineData(BusinessApplicationIdentifier.TopUp)]
    [InlineData(BusinessApplicationIdentifier.WalletTransfer)]
    public void Validation_Works(BusinessApplicationIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BusinessApplicationIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BusinessApplicationIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BusinessApplicationIdentifier.AccountToAccount)]
    [InlineData(BusinessApplicationIdentifier.BusinessToBusiness)]
    [InlineData(BusinessApplicationIdentifier.MoneyTransferBankInitiated)]
    [InlineData(BusinessApplicationIdentifier.NonCardBillPayment)]
    [InlineData(BusinessApplicationIdentifier.ConsumerBillPayment)]
    [InlineData(BusinessApplicationIdentifier.CardBillPayment)]
    [InlineData(BusinessApplicationIdentifier.FundsDisbursement)]
    [InlineData(BusinessApplicationIdentifier.FundsTransfer)]
    [InlineData(BusinessApplicationIdentifier.LoyaltyAndOffers)]
    [InlineData(BusinessApplicationIdentifier.MerchantDisbursement)]
    [InlineData(BusinessApplicationIdentifier.MerchantPayment)]
    [InlineData(BusinessApplicationIdentifier.PersonToPerson)]
    [InlineData(BusinessApplicationIdentifier.TopUp)]
    [InlineData(BusinessApplicationIdentifier.WalletTransfer)]
    public void SerializationRoundtrip_Works(BusinessApplicationIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BusinessApplicationIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BusinessApplicationIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BusinessApplicationIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BusinessApplicationIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PresentmentAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PresentmentAmount { Currency = Currency.Afn, Value = "-16699" };

        ApiEnum<string, Currency> expectedCurrency = Currency.Afn;
        string expectedValue = "-16699";

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PresentmentAmount { Currency = Currency.Afn, Value = "-16699" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PresentmentAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PresentmentAmount { Currency = Currency.Afn, Value = "-16699" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PresentmentAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Currency> expectedCurrency = Currency.Afn;
        string expectedValue = "-16699";

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PresentmentAmount { Currency = Currency.Afn, Value = "-16699" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PresentmentAmount { Currency = Currency.Afn, Value = "-16699" };

        PresentmentAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Currency.Afn)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Aoa)]
    [InlineData(Currency.Ars)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bhd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Btn)]
    [InlineData(Currency.Bob)]
    [InlineData(Currency.Bov)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Cve)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Clf)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Cop)]
    [InlineData(Currency.Cou)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Cdf)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Crc)]
    [InlineData(Currency.Cup)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Svc)]
    [InlineData(Currency.Ern)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Fkp)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Ghs)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gtq)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Hnl)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Huf)]
    [InlineData(Currency.Isk)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Irr)]
    [InlineData(Currency.Iqd)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Jod)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kpw)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kwd)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Lak)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lyd)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mru)]
    [InlineData(Currency.Mur)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Mxv)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nio)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Omr)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pab)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Pen)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Shp)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Stn)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Ssp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Sdg)]
    [InlineData(Currency.Srd)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Che)]
    [InlineData(Currency.Chw)]
    [InlineData(Currency.Syp)]
    [InlineData(Currency.Twd)]
    [InlineData(Currency.Tjs)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Tnd)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Tmt)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.Usn)]
    [InlineData(Currency.Uyu)]
    [InlineData(Currency.Uyi)]
    [InlineData(Currency.Uyw)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Ves)]
    [InlineData(Currency.Ved)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zmw)]
    [InlineData(Currency.Zwg)]
    public void Validation_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Currency.Afn)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Aoa)]
    [InlineData(Currency.Ars)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bhd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Btn)]
    [InlineData(Currency.Bob)]
    [InlineData(Currency.Bov)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Cve)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Clf)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Cop)]
    [InlineData(Currency.Cou)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Cdf)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Crc)]
    [InlineData(Currency.Cup)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Svc)]
    [InlineData(Currency.Ern)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Fkp)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Ghs)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gtq)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Hnl)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Huf)]
    [InlineData(Currency.Isk)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Irr)]
    [InlineData(Currency.Iqd)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Jod)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kpw)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kwd)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Lak)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lyd)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mru)]
    [InlineData(Currency.Mur)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Mxv)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nio)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Omr)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pab)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Pen)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Shp)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Stn)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Ssp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Sdg)]
    [InlineData(Currency.Srd)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Che)]
    [InlineData(Currency.Chw)]
    [InlineData(Currency.Syp)]
    [InlineData(Currency.Twd)]
    [InlineData(Currency.Tjs)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Tnd)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Tmt)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.Usn)]
    [InlineData(Currency.Uyu)]
    [InlineData(Currency.Uyi)]
    [InlineData(Currency.Uyw)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Ves)]
    [InlineData(Currency.Ved)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zmw)]
    [InlineData(Currency.Zwg)]
    public void SerializationRoundtrip_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
