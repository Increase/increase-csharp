using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using InboundWireDrawdownRequests = Increase.Api.Models.InboundWireDrawdownRequests;

namespace Increase.Api.Tests.Models.InboundWireDrawdownRequests;

public class InboundWireDrawdownRequestListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        List<InboundWireDrawdownRequests::InboundWireDrawdownRequest> expectedData =
        [
            new()
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
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundWireDrawdownRequests::InboundWireDrawdownRequestListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundWireDrawdownRequests::InboundWireDrawdownRequestListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<InboundWireDrawdownRequests::InboundWireDrawdownRequest> expectedData =
        [
            new()
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
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundWireDrawdownRequests::InboundWireDrawdownRequestListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextCursor = "v57w5d",
        };

        InboundWireDrawdownRequests::InboundWireDrawdownRequestListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
