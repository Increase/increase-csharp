using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundWireDrawdownRequests = Increase.Api.Models.InboundWireDrawdownRequests;

namespace Increase.Api.Tests.Models.InboundWireDrawdownRequests;

public class InboundWireDrawdownRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequest
        {
            ID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
            Amount = 10000,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorAccountNumber = "987654321",
            CreditorAddressLine1 = "33 Liberty Street",
            CreditorAddressLine2 = "New York, NY, 10045",
            CreditorAddressLine3 = null,
            CreditorName = "Ian Crease",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = null,
            InstructionIdentification = null,
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Type = InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest,
            UniqueEndToEndTransactionReference = null,
            UnstructuredRemittanceInformation = null,
        };

        string expectedID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e";
        long expectedAmount = 10000;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorAccountNumber = "987654321";
        string expectedCreditorAddressLine1 = "33 Liberty Street";
        string expectedCreditorAddressLine2 = "New York, NY, 10045";
        string expectedCreditorName = "Ian Crease";
        string expectedCreditorRoutingNumber = "101050001";
        string expectedCurrency = "USD";
        string expectedDebtorAddressLine1 = "33 Liberty Street";
        string expectedDebtorAddressLine2 = "New York, NY, 10045";
        string expectedDebtorName = "Ian Crease";
        string expectedEndToEndIdentification = "Invoice 29582";
        string expectedRecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, InboundWireDrawdownRequests::Type> expectedType =
            InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditorAccountNumber, model.CreditorAccountNumber);
        Assert.Equal(expectedCreditorAddressLine1, model.CreditorAddressLine1);
        Assert.Equal(expectedCreditorAddressLine2, model.CreditorAddressLine2);
        Assert.Null(model.CreditorAddressLine3);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedCreditorRoutingNumber, model.CreditorRoutingNumber);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtorAddressLine1, model.DebtorAddressLine1);
        Assert.Equal(expectedDebtorAddressLine2, model.DebtorAddressLine2);
        Assert.Null(model.DebtorAddressLine3);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Equal(expectedEndToEndIdentification, model.EndToEndIdentification);
        Assert.Null(model.InputMessageAccountabilityData);
        Assert.Null(model.InstructionIdentification);
        Assert.Equal(expectedRecipientAccountNumberID, model.RecipientAccountNumberID);
        Assert.Equal(expectedType, model.Type);
        Assert.Null(model.UniqueEndToEndTransactionReference);
        Assert.Null(model.UnstructuredRemittanceInformation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequest
        {
            ID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
            Amount = 10000,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorAccountNumber = "987654321",
            CreditorAddressLine1 = "33 Liberty Street",
            CreditorAddressLine2 = "New York, NY, 10045",
            CreditorAddressLine3 = null,
            CreditorName = "Ian Crease",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = null,
            InstructionIdentification = null,
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Type = InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest,
            UniqueEndToEndTransactionReference = null,
            UnstructuredRemittanceInformation = null,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundWireDrawdownRequests::InboundWireDrawdownRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequest
        {
            ID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
            Amount = 10000,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorAccountNumber = "987654321",
            CreditorAddressLine1 = "33 Liberty Street",
            CreditorAddressLine2 = "New York, NY, 10045",
            CreditorAddressLine3 = null,
            CreditorName = "Ian Crease",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = null,
            InstructionIdentification = null,
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Type = InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest,
            UniqueEndToEndTransactionReference = null,
            UnstructuredRemittanceInformation = null,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundWireDrawdownRequests::InboundWireDrawdownRequest>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e";
        long expectedAmount = 10000;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorAccountNumber = "987654321";
        string expectedCreditorAddressLine1 = "33 Liberty Street";
        string expectedCreditorAddressLine2 = "New York, NY, 10045";
        string expectedCreditorName = "Ian Crease";
        string expectedCreditorRoutingNumber = "101050001";
        string expectedCurrency = "USD";
        string expectedDebtorAddressLine1 = "33 Liberty Street";
        string expectedDebtorAddressLine2 = "New York, NY, 10045";
        string expectedDebtorName = "Ian Crease";
        string expectedEndToEndIdentification = "Invoice 29582";
        string expectedRecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, InboundWireDrawdownRequests::Type> expectedType =
            InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditorAccountNumber, deserialized.CreditorAccountNumber);
        Assert.Equal(expectedCreditorAddressLine1, deserialized.CreditorAddressLine1);
        Assert.Equal(expectedCreditorAddressLine2, deserialized.CreditorAddressLine2);
        Assert.Null(deserialized.CreditorAddressLine3);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedCreditorRoutingNumber, deserialized.CreditorRoutingNumber);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtorAddressLine1, deserialized.DebtorAddressLine1);
        Assert.Equal(expectedDebtorAddressLine2, deserialized.DebtorAddressLine2);
        Assert.Null(deserialized.DebtorAddressLine3);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Equal(expectedEndToEndIdentification, deserialized.EndToEndIdentification);
        Assert.Null(deserialized.InputMessageAccountabilityData);
        Assert.Null(deserialized.InstructionIdentification);
        Assert.Equal(expectedRecipientAccountNumberID, deserialized.RecipientAccountNumberID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Null(deserialized.UniqueEndToEndTransactionReference);
        Assert.Null(deserialized.UnstructuredRemittanceInformation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequest
        {
            ID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
            Amount = 10000,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorAccountNumber = "987654321",
            CreditorAddressLine1 = "33 Liberty Street",
            CreditorAddressLine2 = "New York, NY, 10045",
            CreditorAddressLine3 = null,
            CreditorName = "Ian Crease",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = null,
            InstructionIdentification = null,
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Type = InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest,
            UniqueEndToEndTransactionReference = null,
            UnstructuredRemittanceInformation = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequest
        {
            ID = "inbound_wire_drawdown_request_u5a92ikqhz1ytphn799e",
            Amount = 10000,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            CreditorAccountNumber = "987654321",
            CreditorAddressLine1 = "33 Liberty Street",
            CreditorAddressLine2 = "New York, NY, 10045",
            CreditorAddressLine3 = null,
            CreditorName = "Ian Crease",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = null,
            InstructionIdentification = null,
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Type = InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest,
            UniqueEndToEndTransactionReference = null,
            UnstructuredRemittanceInformation = null,
        };

        InboundWireDrawdownRequests::InboundWireDrawdownRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest)]
    public void Validation_Works(InboundWireDrawdownRequests::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundWireDrawdownRequests::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundWireDrawdownRequests::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundWireDrawdownRequests::Type.InboundWireDrawdownRequest)]
    public void SerializationRoundtrip_Works(InboundWireDrawdownRequests::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundWireDrawdownRequests::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireDrawdownRequests::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundWireDrawdownRequests::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireDrawdownRequests::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
