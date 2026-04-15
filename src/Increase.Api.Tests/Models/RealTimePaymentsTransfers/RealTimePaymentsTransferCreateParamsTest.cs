using System;
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
            DebtorName = "x",
            ExternalAccountID = "external_account_id",
            RequireApproval = true,
            RoutingNumber = "101050001",
            UltimateCreditorName = "x",
            UltimateDebtorName = "x",
        };

        long expectedAmount = 100;
        string expectedCreditorName = "Ian Crease";
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";
        string expectedAccountNumber = "987654321";
        string expectedDebtorName = "x";
        string expectedExternalAccountID = "external_account_id";
        bool expectedRequireApproval = true;
        string expectedRoutingNumber = "101050001";
        string expectedUltimateCreditorName = "x";
        string expectedUltimateDebtorName = "x";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCreditorName, parameters.CreditorName);
        Assert.Equal(expectedSourceAccountNumberID, parameters.SourceAccountNumberID);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            parameters.UnstructuredRemittanceInformation
        );
        Assert.Equal(expectedAccountNumber, parameters.AccountNumber);
        Assert.Equal(expectedDebtorName, parameters.DebtorName);
        Assert.Equal(expectedExternalAccountID, parameters.ExternalAccountID);
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
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
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
            DebtorName = null,
            ExternalAccountID = null,
            RequireApproval = null,
            RoutingNumber = null,
            UltimateCreditorName = null,
            UltimateDebtorName = null,
        };

        Assert.Null(parameters.AccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("account_number"));
        Assert.Null(parameters.DebtorName);
        Assert.False(parameters.RawBodyData.ContainsKey("debtor_name"));
        Assert.Null(parameters.ExternalAccountID);
        Assert.False(parameters.RawBodyData.ContainsKey("external_account_id"));
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
            DebtorName = "x",
            ExternalAccountID = "external_account_id",
            RequireApproval = true,
            RoutingNumber = "101050001",
            UltimateCreditorName = "x",
            UltimateDebtorName = "x",
        };

        RealTimePaymentsTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
