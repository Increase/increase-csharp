using System;
using Increase.Api.Models.Simulations.InboundWireDrawdownRequests;

namespace Increase.Api.Tests.Models.Simulations.InboundWireDrawdownRequests;

public class InboundWireDrawdownRequestCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundWireDrawdownRequestCreateParams
        {
            Amount = 10000,
            CreditorAccountNumber = "987654321",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            CreditorAddressLine1 = "33 Liberty Street",
            CreditorAddressLine2 = "New York, NY, 10045",
            CreditorAddressLine3 = "x",
            CreditorName = "Ian Crease",
            DebtorAccountNumber = "987654321",
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = "x",
            DebtorName = "Ian Crease",
            DebtorRoutingNumber = "101050001",
            EndToEndIdentification = "x",
            InstructionIdentification = "x",
            UniqueEndToEndTransactionReference = "x",
            UnstructuredRemittanceInformation = "x",
        };

        long expectedAmount = 10000;
        string expectedCreditorAccountNumber = "987654321";
        string expectedCreditorRoutingNumber = "101050001";
        string expectedCurrency = "USD";
        string expectedRecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedCreditorAddressLine1 = "33 Liberty Street";
        string expectedCreditorAddressLine2 = "New York, NY, 10045";
        string expectedCreditorAddressLine3 = "x";
        string expectedCreditorName = "Ian Crease";
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorAddressLine1 = "33 Liberty Street";
        string expectedDebtorAddressLine2 = "New York, NY, 10045";
        string expectedDebtorAddressLine3 = "x";
        string expectedDebtorName = "Ian Crease";
        string expectedDebtorRoutingNumber = "101050001";
        string expectedEndToEndIdentification = "x";
        string expectedInstructionIdentification = "x";
        string expectedUniqueEndToEndTransactionReference = "x";
        string expectedUnstructuredRemittanceInformation = "x";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCreditorAccountNumber, parameters.CreditorAccountNumber);
        Assert.Equal(expectedCreditorRoutingNumber, parameters.CreditorRoutingNumber);
        Assert.Equal(expectedCurrency, parameters.Currency);
        Assert.Equal(expectedRecipientAccountNumberID, parameters.RecipientAccountNumberID);
        Assert.Equal(expectedCreditorAddressLine1, parameters.CreditorAddressLine1);
        Assert.Equal(expectedCreditorAddressLine2, parameters.CreditorAddressLine2);
        Assert.Equal(expectedCreditorAddressLine3, parameters.CreditorAddressLine3);
        Assert.Equal(expectedCreditorName, parameters.CreditorName);
        Assert.Equal(expectedDebtorAccountNumber, parameters.DebtorAccountNumber);
        Assert.Equal(expectedDebtorAddressLine1, parameters.DebtorAddressLine1);
        Assert.Equal(expectedDebtorAddressLine2, parameters.DebtorAddressLine2);
        Assert.Equal(expectedDebtorAddressLine3, parameters.DebtorAddressLine3);
        Assert.Equal(expectedDebtorName, parameters.DebtorName);
        Assert.Equal(expectedDebtorRoutingNumber, parameters.DebtorRoutingNumber);
        Assert.Equal(expectedEndToEndIdentification, parameters.EndToEndIdentification);
        Assert.Equal(expectedInstructionIdentification, parameters.InstructionIdentification);
        Assert.Equal(
            expectedUniqueEndToEndTransactionReference,
            parameters.UniqueEndToEndTransactionReference
        );
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundWireDrawdownRequestCreateParams
        {
            Amount = 10000,
            CreditorAccountNumber = "987654321",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        Assert.Null(parameters.CreditorAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line1"));
        Assert.Null(parameters.CreditorAddressLine2);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line2"));
        Assert.Null(parameters.CreditorAddressLine3);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line3"));
        Assert.Null(parameters.CreditorName);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_name"));
        Assert.Null(parameters.DebtorAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_account_number"));
        Assert.Null(parameters.DebtorAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line1"));
        Assert.Null(parameters.DebtorAddressLine2);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line2"));
        Assert.Null(parameters.DebtorAddressLine3);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line3"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.DebtorRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_routing_number"));
        Assert.Null(parameters.EndToEndIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("end_to_end_identification"));
        Assert.Null(parameters.InstructionIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction_identification"));
        Assert.Null(parameters.UniqueEndToEndTransactionReference);
        Assert.False(parameters.RawBodyData.ContainsKey("unique_end_to_end_transaction_reference"));
        Assert.Null(parameters.UnstructuredRemittanceInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("unstructured_remittance_information"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundWireDrawdownRequestCreateParams
        {
            Amount = 10000,
            CreditorAccountNumber = "987654321",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",

            // Null should be interpreted as omitted for these properties
            CreditorAddressLine1 = null,
            CreditorAddressLine2 = null,
            CreditorAddressLine3 = null,
            CreditorName = null,
            DebtorAccountNumber = null,
            DebtorAddressLine1 = null,
            DebtorAddressLine2 = null,
            DebtorAddressLine3 = null,
            DebtorName = null,
            DebtorRoutingNumber = null,
            EndToEndIdentification = null,
            InstructionIdentification = null,
            UniqueEndToEndTransactionReference = null,
            UnstructuredRemittanceInformation = null,
        };

        Assert.Null(parameters.CreditorAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line1"));
        Assert.Null(parameters.CreditorAddressLine2);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line2"));
        Assert.Null(parameters.CreditorAddressLine3);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line3"));
        Assert.Null(parameters.CreditorName);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_name"));
        Assert.Null(parameters.DebtorAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_account_number"));
        Assert.Null(parameters.DebtorAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line1"));
        Assert.Null(parameters.DebtorAddressLine2);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line2"));
        Assert.Null(parameters.DebtorAddressLine3);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line3"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.DebtorRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_routing_number"));
        Assert.Null(parameters.EndToEndIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("end_to_end_identification"));
        Assert.Null(parameters.InstructionIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction_identification"));
        Assert.Null(parameters.UniqueEndToEndTransactionReference);
        Assert.False(parameters.RawBodyData.ContainsKey("unique_end_to_end_transaction_reference"));
        Assert.Null(parameters.UnstructuredRemittanceInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("unstructured_remittance_information"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundWireDrawdownRequestCreateParams parameters = new()
        {
            Amount = 10000,
            CreditorAccountNumber = "987654321",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/inbound_wire_drawdown_requests"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundWireDrawdownRequestCreateParams
        {
            Amount = 10000,
            CreditorAccountNumber = "987654321",
            CreditorRoutingNumber = "101050001",
            Currency = "USD",
            RecipientAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            CreditorAddressLine1 = "33 Liberty Street",
            CreditorAddressLine2 = "New York, NY, 10045",
            CreditorAddressLine3 = "x",
            CreditorName = "Ian Crease",
            DebtorAccountNumber = "987654321",
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = "x",
            DebtorName = "Ian Crease",
            DebtorRoutingNumber = "101050001",
            EndToEndIdentification = "x",
            InstructionIdentification = "x",
            UniqueEndToEndTransactionReference = "x",
            UnstructuredRemittanceInformation = "x",
        };

        InboundWireDrawdownRequestCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
