using System;
using Increase.Api.Models.Simulations.InboundWireTransfers;

namespace Increase.Api.Tests.Models.Simulations.InboundWireTransfers;

public class InboundWireTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundWireTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            CreditorAddressLine1 = "x",
            CreditorAddressLine2 = "x",
            CreditorAddressLine3 = "x",
            CreditorName = "x",
            DebtorAddressLine1 = "x",
            DebtorAddressLine2 = "x",
            DebtorAddressLine3 = "x",
            DebtorName = "x",
            EndToEndIdentification = "x",
            InstructingAgentRoutingNumber = "x",
            InstructionIdentification = "x",
            UniqueEndToEndTransactionReference = "x",
            UnstructuredRemittanceInformation = "x",
            WireDrawdownRequestID = "wire_drawdown_request_id",
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 1000;
        string expectedCreditorAddressLine1 = "x";
        string expectedCreditorAddressLine2 = "x";
        string expectedCreditorAddressLine3 = "x";
        string expectedCreditorName = "x";
        string expectedDebtorAddressLine1 = "x";
        string expectedDebtorAddressLine2 = "x";
        string expectedDebtorAddressLine3 = "x";
        string expectedDebtorName = "x";
        string expectedEndToEndIdentification = "x";
        string expectedInstructingAgentRoutingNumber = "x";
        string expectedInstructionIdentification = "x";
        string expectedUniqueEndToEndTransactionReference = "x";
        string expectedUnstructuredRemittanceInformation = "x";
        string expectedWireDrawdownRequestID = "wire_drawdown_request_id";

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCreditorAddressLine1, parameters.CreditorAddressLine1);
        Assert.Equal(expectedCreditorAddressLine2, parameters.CreditorAddressLine2);
        Assert.Equal(expectedCreditorAddressLine3, parameters.CreditorAddressLine3);
        Assert.Equal(expectedCreditorName, parameters.CreditorName);
        Assert.Equal(expectedDebtorAddressLine1, parameters.DebtorAddressLine1);
        Assert.Equal(expectedDebtorAddressLine2, parameters.DebtorAddressLine2);
        Assert.Equal(expectedDebtorAddressLine3, parameters.DebtorAddressLine3);
        Assert.Equal(expectedDebtorName, parameters.DebtorName);
        Assert.Equal(expectedEndToEndIdentification, parameters.EndToEndIdentification);
        Assert.Equal(
            expectedInstructingAgentRoutingNumber,
            parameters.InstructingAgentRoutingNumber
        );
        Assert.Equal(expectedInstructionIdentification, parameters.InstructionIdentification);
        Assert.Equal(
            expectedUniqueEndToEndTransactionReference,
            parameters.UniqueEndToEndTransactionReference
        );
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
        Assert.Equal(expectedWireDrawdownRequestID, parameters.WireDrawdownRequestID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundWireTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
        };

        Assert.Null(parameters.CreditorAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line1"));
        Assert.Null(parameters.CreditorAddressLine2);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line2"));
        Assert.Null(parameters.CreditorAddressLine3);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line3"));
        Assert.Null(parameters.CreditorName);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_name"));
        Assert.Null(parameters.DebtorAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line1"));
        Assert.Null(parameters.DebtorAddressLine2);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line2"));
        Assert.Null(parameters.DebtorAddressLine3);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line3"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.EndToEndIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("end_to_end_identification"));
        Assert.Null(parameters.InstructingAgentRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("instructing_agent_routing_number"));
        Assert.Null(parameters.InstructionIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction_identification"));
        Assert.Null(parameters.UniqueEndToEndTransactionReference);
        Assert.False(parameters.RawBodyData.ContainsKey("unique_end_to_end_transaction_reference"));
        Assert.Null(parameters.UnstructuredRemittanceInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("unstructured_remittance_information"));
        Assert.Null(parameters.WireDrawdownRequestID);
        Assert.False(parameters.RawBodyData.ContainsKey("wire_drawdown_request_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundWireTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,

            // Null should be interpreted as omitted for these properties
            CreditorAddressLine1 = null,
            CreditorAddressLine2 = null,
            CreditorAddressLine3 = null,
            CreditorName = null,
            DebtorAddressLine1 = null,
            DebtorAddressLine2 = null,
            DebtorAddressLine3 = null,
            DebtorName = null,
            EndToEndIdentification = null,
            InstructingAgentRoutingNumber = null,
            InstructionIdentification = null,
            UniqueEndToEndTransactionReference = null,
            UnstructuredRemittanceInformation = null,
            WireDrawdownRequestID = null,
        };

        Assert.Null(parameters.CreditorAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line1"));
        Assert.Null(parameters.CreditorAddressLine2);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line2"));
        Assert.Null(parameters.CreditorAddressLine3);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_address_line3"));
        Assert.Null(parameters.CreditorName);
        Assert.False(parameters.RawBodyData.ContainsKey("creditor_name"));
        Assert.Null(parameters.DebtorAddressLine1);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line1"));
        Assert.Null(parameters.DebtorAddressLine2);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line2"));
        Assert.Null(parameters.DebtorAddressLine3);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_address_line3"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.EndToEndIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("end_to_end_identification"));
        Assert.Null(parameters.InstructingAgentRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("instructing_agent_routing_number"));
        Assert.Null(parameters.InstructionIdentification);
        Assert.False(parameters.RawBodyData.ContainsKey("instruction_identification"));
        Assert.Null(parameters.UniqueEndToEndTransactionReference);
        Assert.False(parameters.RawBodyData.ContainsKey("unique_end_to_end_transaction_reference"));
        Assert.Null(parameters.UnstructuredRemittanceInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("unstructured_remittance_information"));
        Assert.Null(parameters.WireDrawdownRequestID);
        Assert.False(parameters.RawBodyData.ContainsKey("wire_drawdown_request_id"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundWireTransferCreateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/simulations/inbound_wire_transfers"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundWireTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            CreditorAddressLine1 = "x",
            CreditorAddressLine2 = "x",
            CreditorAddressLine3 = "x",
            CreditorName = "x",
            DebtorAddressLine1 = "x",
            DebtorAddressLine2 = "x",
            DebtorAddressLine3 = "x",
            DebtorName = "x",
            EndToEndIdentification = "x",
            InstructingAgentRoutingNumber = "x",
            InstructionIdentification = "x",
            UniqueEndToEndTransactionReference = "x",
            UnstructuredRemittanceInformation = "x",
            WireDrawdownRequestID = "wire_drawdown_request_id",
        };

        InboundWireTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
