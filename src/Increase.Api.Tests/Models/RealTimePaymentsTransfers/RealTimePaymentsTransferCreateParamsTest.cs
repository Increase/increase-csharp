using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.RealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.RealTimePaymentsTransfers;

public class RealTimePaymentsTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimePaymentsTransferCreateParams
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",
            AccountNumber = "987654321",
            DebtorAddress = new()
            {
                City = "city",
                Country = "x",
                PostalCode = "postal_code",
                State = "xx",
                StreetName = "street_name",
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
            },
            DebtorName = "debtor_name",
            ExternalAccountID = "external_account_id",
            InboundRealTimePaymentsRequestForPaymentID =
                "inbound_real_time_payments_request_for_payment_id",
            RequireApproval = true,
            RoutingNumber = "101050001",
            UltimateCreditorName = "ultimate_creditor_name",
            UltimateDebtorName = "ultimate_debtor_name",
        };

        long expectedAmount = 100;
        string expectedCreditorName = "Ian Crease";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";
        string expectedAccountNumber = "987654321";
        DebtorAddress expectedDebtorAddress = new()
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",
            AddressLine2 = "address_line2",
            BuildingNumber = "building_number",
        };
        string expectedDebtorName = "debtor_name";
        string expectedExternalAccountID = "external_account_id";
        string expectedInboundRealTimePaymentsRequestForPaymentID =
            "inbound_real_time_payments_request_for_payment_id";
        bool expectedRequireApproval = true;
        string expectedRoutingNumber = "101050001";
        string expectedUltimateCreditorName = "ultimate_creditor_name";
        string expectedUltimateDebtorName = "ultimate_debtor_name";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCreditorName, parameters.CreditorName);
        Assert.Equal(expectedSourceAccountNumberID, parameters.SourceAccountNumberID);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedDebtorAddress, parameters.DebtorAddress);
        Assert.Equal(expectedDebtorName, parameters.DebtorName);
        Assert.Equal(expectedExternalAccountID, parameters.ExternalAccountID);
        Assert.Equal(
            expectedInboundRealTimePaymentsRequestForPaymentID,
            parameters.InboundRealTimePaymentsRequestForPaymentID
        );
        Assert.Equal(expectedRequireApproval, parameters.RequireApproval);
        Assert.Equal(expectedRoutingNumber, parameters.RoutingNumber);
        Assert.Equal(expectedUltimateCreditorName, parameters.UltimateCreditorName);
        Assert.Equal(expectedUltimateDebtorName, parameters.UltimateDebtorName);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RealTimePaymentsTransferCreateParams
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.DebtorAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
        Assert.Null(parameters.InboundRealTimePaymentsRequestForPaymentID);
        Assert.False(
            parameters.RawBodyData.ContainsKey("inbound_real_time_payments_request_for_payment_id")
        );
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
        Assert.Null(parameters.UltimateCreditorName);
        Assert.False(parameters.RawBodyData.ContainsKey("ultimate_creditor_name"));
        Assert.Null(parameters.UltimateDebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("ultimate_debtor_name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RealTimePaymentsTransferCreateParams
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",

            // Null should be interpreted as omitted for these properties
            AccountNumber = null,
            DebtorAddress = null,
            DebtorName = null,
            ExternalAccountID = null,
            InboundRealTimePaymentsRequestForPaymentID = null,
            RequireApproval = null,
            RoutingNumber = null,
            UltimateCreditorName = null,
            UltimateDebtorName = null,
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.DebtorAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
        Assert.Null(parameters.InboundRealTimePaymentsRequestForPaymentID);
        Assert.False(
            parameters.RawBodyData.ContainsKey("inbound_real_time_payments_request_for_payment_id")
        );
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
        Assert.Null(parameters.UltimateCreditorName);
        Assert.False(parameters.RawBodyData.ContainsKey("ultimate_creditor_name"));
        Assert.Null(parameters.UltimateDebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("ultimate_debtor_name"));
    }

    [Fact]
    public void Url_Works()
    {
        RealTimePaymentsTransferCreateParams parameters = new()
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/real_time_payments_transfers"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimePaymentsTransferCreateParams
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",
            AccountNumber = "987654321",
            DebtorAddress = new()
            {
                City = "city",
                Country = "x",
                PostalCode = "postal_code",
                State = "xx",
                StreetName = "street_name",
                AddressLine2 = "address_line2",
                BuildingNumber = "building_number",
            },
            DebtorName = "debtor_name",
            ExternalAccountID = "external_account_id",
            InboundRealTimePaymentsRequestForPaymentID =
                "inbound_real_time_payments_request_for_payment_id",
            RequireApproval = true,
            RoutingNumber = "101050001",
            UltimateCreditorName = "ultimate_creditor_name",
            UltimateDebtorName = "ultimate_debtor_name",
        };

        RealTimePaymentsTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DebtorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",
            AddressLine2 = "address_line2",
            BuildingNumber = "building_number",
        };

        string expectedCity = "city";
        string expectedCountry = "x";
        string expectedPostalCode = "postal_code";
        string expectedState = "xx";
        string expectedStreetName = "street_name";
        string expectedAddressLine2 = "address_line2";
        string expectedBuildingNumber = "building_number";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedStreetName, model.StreetName);
        Assert.Equal(expectedAddressLine2, model.AddressLine2);
        Assert.Equal(expectedBuildingNumber, model.BuildingNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",
            AddressLine2 = "address_line2",
            BuildingNumber = "building_number",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",
            AddressLine2 = "address_line2",
            BuildingNumber = "building_number",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "x";
        string expectedPostalCode = "postal_code";
        string expectedState = "xx";
        string expectedStreetName = "street_name";
        string expectedAddressLine2 = "address_line2";
        string expectedBuildingNumber = "building_number";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedStreetName, deserialized.StreetName);
        Assert.Equal(expectedAddressLine2, deserialized.AddressLine2);
        Assert.Equal(expectedBuildingNumber, deserialized.BuildingNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",
            AddressLine2 = "address_line2",
            BuildingNumber = "building_number",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",
        };

        Assert.Null(model.AddressLine2);
        Assert.False(model.RawData.ContainsKey("address_line2"));
        Assert.Null(model.BuildingNumber);
        Assert.False(model.RawData.ContainsKey("building_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",

            // Null should be interpreted as omitted for these properties
            AddressLine2 = null,
            BuildingNumber = null,
        };

        Assert.Null(model.AddressLine2);
        Assert.False(model.RawData.ContainsKey("address_line2"));
        Assert.Null(model.BuildingNumber);
        Assert.False(model.RawData.ContainsKey("building_number"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",

            // Null should be interpreted as omitted for these properties
            AddressLine2 = null,
            BuildingNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DebtorAddress
        {
            City = "city",
            Country = "x",
            PostalCode = "postal_code",
            State = "xx",
            StreetName = "street_name",
            AddressLine2 = "address_line2",
            BuildingNumber = "building_number",
        };

        DebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}
