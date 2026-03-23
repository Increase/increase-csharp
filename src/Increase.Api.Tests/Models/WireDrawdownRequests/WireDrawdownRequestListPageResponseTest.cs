using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using WireDrawdownRequests = Increase.Api.Models.WireDrawdownRequests;

namespace Increase.Api.Tests.Models.WireDrawdownRequests;

public class WireDrawdownRequestListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 10000,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    CreditorName = "Ian Crease",
                    Currency = "USD",
                    DebtorAccountNumber = "987654321",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    DebtorExternalAccountID = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    FulfillmentInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    IdempotencyKey = null,
                    Status = WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled,
                    Submission = new("20220118MMQFMP0P000003"),
                    Type = WireDrawdownRequests::Type.WireDrawdownRequest,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        List<WireDrawdownRequests::WireDrawdownRequest> expectedData =
        [
            new()
            {
                ID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 10000,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreditorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    PostalCode = "10045",
                    State = "NY",
                },
                CreditorName = "Ian Crease",
                Currency = "USD",
                DebtorAccountNumber = "987654321",
                DebtorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    PostalCode = "10045",
                    State = "NY",
                },
                DebtorExternalAccountID = null,
                DebtorName = "Ian Crease",
                DebtorRoutingNumber = "101050001",
                FulfillmentInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                IdempotencyKey = null,
                Status = WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled,
                Submission = new("20220118MMQFMP0P000003"),
                Type = WireDrawdownRequests::Type.WireDrawdownRequest,
                UnstructuredRemittanceInformation = "Invoice 29582",
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 10000,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    CreditorName = "Ian Crease",
                    Currency = "USD",
                    DebtorAccountNumber = "987654321",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    DebtorExternalAccountID = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    FulfillmentInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    IdempotencyKey = null,
                    Status = WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled,
                    Submission = new("20220118MMQFMP0P000003"),
                    Type = WireDrawdownRequests::Type.WireDrawdownRequest,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireDrawdownRequests::WireDrawdownRequestListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 10000,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    CreditorName = "Ian Crease",
                    Currency = "USD",
                    DebtorAccountNumber = "987654321",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    DebtorExternalAccountID = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    FulfillmentInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    IdempotencyKey = null,
                    Status = WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled,
                    Submission = new("20220118MMQFMP0P000003"),
                    Type = WireDrawdownRequests::Type.WireDrawdownRequest,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireDrawdownRequests::WireDrawdownRequestListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<WireDrawdownRequests::WireDrawdownRequest> expectedData =
        [
            new()
            {
                ID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 10000,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreditorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    PostalCode = "10045",
                    State = "NY",
                },
                CreditorName = "Ian Crease",
                Currency = "USD",
                DebtorAccountNumber = "987654321",
                DebtorAddress = new()
                {
                    City = "New York",
                    Country = "US",
                    Line1 = "33 Liberty Street",
                    Line2 = null,
                    PostalCode = "10045",
                    State = "NY",
                },
                DebtorExternalAccountID = null,
                DebtorName = "Ian Crease",
                DebtorRoutingNumber = "101050001",
                FulfillmentInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                IdempotencyKey = null,
                Status = WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled,
                Submission = new("20220118MMQFMP0P000003"),
                Type = WireDrawdownRequests::Type.WireDrawdownRequest,
                UnstructuredRemittanceInformation = "Invoice 29582",
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 10000,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    CreditorName = "Ian Crease",
                    Currency = "USD",
                    DebtorAccountNumber = "987654321",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    DebtorExternalAccountID = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    FulfillmentInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    IdempotencyKey = null,
                    Status = WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled,
                    Submission = new("20220118MMQFMP0P000003"),
                    Type = WireDrawdownRequests::Type.WireDrawdownRequest,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 10000,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    CreditorName = "Ian Crease",
                    Currency = "USD",
                    DebtorAccountNumber = "987654321",
                    DebtorAddress = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = null,
                        PostalCode = "10045",
                        State = "NY",
                    },
                    DebtorExternalAccountID = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    FulfillmentInboundWireTransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    IdempotencyKey = null,
                    Status = WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled,
                    Submission = new("20220118MMQFMP0P000003"),
                    Type = WireDrawdownRequests::Type.WireDrawdownRequest,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        WireDrawdownRequests::WireDrawdownRequestListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
