using System;
using Increase.Api.Models.Simulations.InboundFednowTransfers;

namespace Increase.Api.Tests.Models.Simulations.InboundFednowTransfers;

public class InboundFednowTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InboundFednowTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            DebtorAccountNumber = "x",
            DebtorName = "x",
            DebtorRoutingNumber = "xxxxxxxxx",
            UnstructuredRemittanceInformation = "x",
        };

        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 1000;
        string expectedDebtorAccountNumber = "x";
        string expectedDebtorName = "x";
        string expectedDebtorRoutingNumber = "xxxxxxxxx";
        string expectedUnstructuredRemittanceInformation = "x";

        Assert.Equal(expectedAccountNumberID, parameters.AccountNumberID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedDebtorAccountNumber, parameters.DebtorAccountNumber);
        Assert.Equal(expectedDebtorName, parameters.DebtorName);
        Assert.Equal(expectedDebtorRoutingNumber, parameters.DebtorRoutingNumber);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InboundFednowTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
        };

        Assert.Null(parameters.DebtorAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_account_number"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.DebtorRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_routing_number"));
        Assert.Null(parameters.UnstructuredRemittanceInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("unstructured_remittance_information"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InboundFednowTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,

            // Null should be interpreted as omitted for these properties
            DebtorAccountNumber = null,
            DebtorName = null,
            DebtorRoutingNumber = null,
            UnstructuredRemittanceInformation = null,
        };

        Assert.Null(parameters.DebtorAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_account_number"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.DebtorRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_routing_number"));
        Assert.Null(parameters.UnstructuredRemittanceInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("unstructured_remittance_information"));
    }

    [Fact]
    public void Url_Works()
    {
        InboundFednowTransferCreateParams parameters = new()
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/simulations/inbound_fednow_transfers"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InboundFednowTransferCreateParams
        {
            AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            Amount = 1000,
            DebtorAccountNumber = "x",
            DebtorName = "x",
            DebtorRoutingNumber = "xxxxxxxxx",
            UnstructuredRemittanceInformation = "x",
        };

        InboundFednowTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
