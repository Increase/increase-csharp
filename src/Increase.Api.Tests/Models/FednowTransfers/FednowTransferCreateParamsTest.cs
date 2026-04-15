using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.FednowTransfers;

namespace Increase.Api.Tests.Models.FednowTransfers;

public class FednowTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FednowTransferCreateParams
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            DebtorName = "National Phonograph Company",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",
            AccountNumber = "987654321",
            CreditorAddress = new()
            {
                City = "New York",
                PostalCode = "10045",
                State = "NY",
                Line1 = "33 Liberty Street",
            },
            DebtorAddress = new()
            {
                City = "x",
                PostalCode = "21029-9469",
                State = "x",
                Line1 = "x",
            },
            ExternalAccountID = "external_account_id",
            RequireApproval = true,
            RoutingNumber = "101050001",
        };

        long expectedAmount = 100;
        string expectedCreditorName = "Ian Crease";
        string expectedDebtorName = "National Phonograph Company";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";
        string expectedAccountNumber = "987654321";
        CreditorAddress expectedCreditorAddress = new()
        {
            City = "New York",
            PostalCode = "10045",
            State = "NY",
            Line1 = "33 Liberty Street",
        };
        DebtorAddress expectedDebtorAddress = new()
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };
        string expectedExternalAccountID = "external_account_id";
        bool expectedRequireApproval = true;
        string expectedRoutingNumber = "101050001";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCreditorName, parameters.CreditorName);
        Assert.Equal(expectedDebtorName, parameters.DebtorName);
        Assert.Equal(expectedSourceAccountNumberID, parameters.SourceAccountNumberID);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedCreditorAddress, parameters.CreditorAddress);
        Assert.Equal(expectedDebtorAddress, parameters.DebtorAddress);
        Assert.Equal(expectedExternalAccountID, parameters.ExternalAccountID);
        Assert.Equal(expectedRequireApproval, parameters.RequireApproval);
        Assert.Equal(expectedRoutingNumber, parameters.RoutingNumber);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FednowTransferCreateParams
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            DebtorName = "National Phonograph Company",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.CreditorAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address"));
        Assert.Null(parameters.DebtorAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FednowTransferCreateParams
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            DebtorName = "National Phonograph Company",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",

            // Null should be interpreted as omitted for these properties
            AccountNumber = null,
            CreditorAddress = null,
            DebtorAddress = null,
            ExternalAccountID = null,
            RequireApproval = null,
            RoutingNumber = null,
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.CreditorAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address"));
        Assert.Null(parameters.DebtorAddress);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.RoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("routing_number"));
    }

    [Fact]
    public void Url_Works()
    {
        FednowTransferCreateParams parameters = new()
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            DebtorName = "National Phonograph Company",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/fednow_transfers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FednowTransferCreateParams
        {
            Amount = 100,
            CreditorName = "Ian Crease",
            DebtorName = "National Phonograph Company",
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            UnstructuredRemittanceInformation = "Invoice 29582",
            AccountNumber = "987654321",
            CreditorAddress = new()
            {
                City = "New York",
                PostalCode = "10045",
                State = "NY",
                Line1 = "33 Liberty Street",
            },
            DebtorAddress = new()
            {
                City = "x",
                PostalCode = "21029-9469",
                State = "x",
                Line1 = "x",
            },
            ExternalAccountID = "external_account_id",
            RequireApproval = true,
            RoutingNumber = "101050001",
        };

        FednowTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CreditorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        string expectedCity = "x";
        string expectedPostalCode = "21029-9469";
        string expectedState = "x";
        string expectedLine1 = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedLine1, model.Line1);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditorAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedPostalCode = "21029-9469";
        string expectedState = "x";
        string expectedLine1 = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedLine1, deserialized.Line1);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
        };

        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line1 = null,
        };

        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line1 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        CreditorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DebtorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        string expectedCity = "x";
        string expectedPostalCode = "21029-9469";
        string expectedState = "x";
        string expectedLine1 = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedLine1, model.Line1);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
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
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DebtorAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedPostalCode = "21029-9469";
        string expectedState = "x";
        string expectedLine1 = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedLine1, deserialized.Line1);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
        };

        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line1 = null,
        };

        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line1 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DebtorAddress
        {
            City = "x",
            PostalCode = "21029-9469",
            State = "x",
            Line1 = "x",
        };

        DebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}
