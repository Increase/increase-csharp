using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using InboundWireTransfers = Increase.Api.Models.InboundWireTransfers;

namespace Increase.Api.Tests.Models.InboundWireTransfers;

public class InboundWireTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundWireTransfers::InboundWireTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddressLine1 = "33 Liberty Street",
                    CreditorAddressLine2 = "New York, NY, 10045",
                    CreditorAddressLine3 = null,
                    CreditorName = "National Phonograph Company",
                    DebtorAccountNumber = "987654321",
                    DebtorAddressLine1 = "33 Liberty Street",
                    DebtorAddressLine2 = "New York, NY, 10045",
                    DebtorAddressLine3 = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    Description = "Inbound wire transfer",
                    EndToEndIdentification = "Invoice 29582",
                    InputMessageAccountabilityData = "20220118MMQFMP0P000001",
                    InstructingAgentRoutingNumber = "101050001",
                    InstructionIdentification = "202201180000001",
                    Purpose = "CASH",
                    Reversal = new()
                    {
                        Reason = InboundWireTransfers::ReversalReason.Duplicate,
                        ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Status = InboundWireTransfers::InboundWireTransferStatus.Accepted,
                    Type = InboundWireTransfers::Type.InboundWireTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "INVOICE 2468",
                    WireDrawdownRequestID = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<InboundWireTransfers::InboundWireTransfer> expectedData =
        [
            new()
            {
                ID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                Acceptance = new()
                {
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                },
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreditorAddressLine1 = "33 Liberty Street",
                CreditorAddressLine2 = "New York, NY, 10045",
                CreditorAddressLine3 = null,
                CreditorName = "National Phonograph Company",
                DebtorAccountNumber = "987654321",
                DebtorAddressLine1 = "33 Liberty Street",
                DebtorAddressLine2 = "New York, NY, 10045",
                DebtorAddressLine3 = null,
                DebtorName = "Ian Crease",
                DebtorRoutingNumber = "101050001",
                Description = "Inbound wire transfer",
                EndToEndIdentification = "Invoice 29582",
                InputMessageAccountabilityData = "20220118MMQFMP0P000001",
                InstructingAgentRoutingNumber = "101050001",
                InstructionIdentification = "202201180000001",
                Purpose = "CASH",
                Reversal = new()
                {
                    Reason = InboundWireTransfers::ReversalReason.Duplicate,
                    ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Status = InboundWireTransfers::InboundWireTransferStatus.Accepted,
                Type = InboundWireTransfers::Type.InboundWireTransfer,
                UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                UnstructuredRemittanceInformation = "INVOICE 2468",
                WireDrawdownRequestID = null,
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
        var model = new InboundWireTransfers::InboundWireTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddressLine1 = "33 Liberty Street",
                    CreditorAddressLine2 = "New York, NY, 10045",
                    CreditorAddressLine3 = null,
                    CreditorName = "National Phonograph Company",
                    DebtorAccountNumber = "987654321",
                    DebtorAddressLine1 = "33 Liberty Street",
                    DebtorAddressLine2 = "New York, NY, 10045",
                    DebtorAddressLine3 = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    Description = "Inbound wire transfer",
                    EndToEndIdentification = "Invoice 29582",
                    InputMessageAccountabilityData = "20220118MMQFMP0P000001",
                    InstructingAgentRoutingNumber = "101050001",
                    InstructionIdentification = "202201180000001",
                    Purpose = "CASH",
                    Reversal = new()
                    {
                        Reason = InboundWireTransfers::ReversalReason.Duplicate,
                        ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Status = InboundWireTransfers::InboundWireTransferStatus.Accepted,
                    Type = InboundWireTransfers::Type.InboundWireTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "INVOICE 2468",
                    WireDrawdownRequestID = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundWireTransfers::InboundWireTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundWireTransfers::InboundWireTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddressLine1 = "33 Liberty Street",
                    CreditorAddressLine2 = "New York, NY, 10045",
                    CreditorAddressLine3 = null,
                    CreditorName = "National Phonograph Company",
                    DebtorAccountNumber = "987654321",
                    DebtorAddressLine1 = "33 Liberty Street",
                    DebtorAddressLine2 = "New York, NY, 10045",
                    DebtorAddressLine3 = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    Description = "Inbound wire transfer",
                    EndToEndIdentification = "Invoice 29582",
                    InputMessageAccountabilityData = "20220118MMQFMP0P000001",
                    InstructingAgentRoutingNumber = "101050001",
                    InstructionIdentification = "202201180000001",
                    Purpose = "CASH",
                    Reversal = new()
                    {
                        Reason = InboundWireTransfers::ReversalReason.Duplicate,
                        ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Status = InboundWireTransfers::InboundWireTransferStatus.Accepted,
                    Type = InboundWireTransfers::Type.InboundWireTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "INVOICE 2468",
                    WireDrawdownRequestID = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundWireTransfers::InboundWireTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<InboundWireTransfers::InboundWireTransfer> expectedData =
        [
            new()
            {
                ID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                Acceptance = new()
                {
                    AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                },
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreditorAddressLine1 = "33 Liberty Street",
                CreditorAddressLine2 = "New York, NY, 10045",
                CreditorAddressLine3 = null,
                CreditorName = "National Phonograph Company",
                DebtorAccountNumber = "987654321",
                DebtorAddressLine1 = "33 Liberty Street",
                DebtorAddressLine2 = "New York, NY, 10045",
                DebtorAddressLine3 = null,
                DebtorName = "Ian Crease",
                DebtorRoutingNumber = "101050001",
                Description = "Inbound wire transfer",
                EndToEndIdentification = "Invoice 29582",
                InputMessageAccountabilityData = "20220118MMQFMP0P000001",
                InstructingAgentRoutingNumber = "101050001",
                InstructionIdentification = "202201180000001",
                Purpose = "CASH",
                Reversal = new()
                {
                    Reason = InboundWireTransfers::ReversalReason.Duplicate,
                    ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Status = InboundWireTransfers::InboundWireTransferStatus.Accepted,
                Type = InboundWireTransfers::Type.InboundWireTransfer,
                UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                UnstructuredRemittanceInformation = "INVOICE 2468",
                WireDrawdownRequestID = null,
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
        var model = new InboundWireTransfers::InboundWireTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddressLine1 = "33 Liberty Street",
                    CreditorAddressLine2 = "New York, NY, 10045",
                    CreditorAddressLine3 = null,
                    CreditorName = "National Phonograph Company",
                    DebtorAccountNumber = "987654321",
                    DebtorAddressLine1 = "33 Liberty Street",
                    DebtorAddressLine2 = "New York, NY, 10045",
                    DebtorAddressLine3 = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    Description = "Inbound wire transfer",
                    EndToEndIdentification = "Invoice 29582",
                    InputMessageAccountabilityData = "20220118MMQFMP0P000001",
                    InstructingAgentRoutingNumber = "101050001",
                    InstructionIdentification = "202201180000001",
                    Purpose = "CASH",
                    Reversal = new()
                    {
                        Reason = InboundWireTransfers::ReversalReason.Duplicate,
                        ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Status = InboundWireTransfers::InboundWireTransferStatus.Accepted,
                    Type = InboundWireTransfers::Type.InboundWireTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "INVOICE 2468",
                    WireDrawdownRequestID = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundWireTransfers::InboundWireTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                    Acceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorAddressLine1 = "33 Liberty Street",
                    CreditorAddressLine2 = "New York, NY, 10045",
                    CreditorAddressLine3 = null,
                    CreditorName = "National Phonograph Company",
                    DebtorAccountNumber = "987654321",
                    DebtorAddressLine1 = "33 Liberty Street",
                    DebtorAddressLine2 = "New York, NY, 10045",
                    DebtorAddressLine3 = null,
                    DebtorName = "Ian Crease",
                    DebtorRoutingNumber = "101050001",
                    Description = "Inbound wire transfer",
                    EndToEndIdentification = "Invoice 29582",
                    InputMessageAccountabilityData = "20220118MMQFMP0P000001",
                    InstructingAgentRoutingNumber = "101050001",
                    InstructionIdentification = "202201180000001",
                    Purpose = "CASH",
                    Reversal = new()
                    {
                        Reason = InboundWireTransfers::ReversalReason.Duplicate,
                        ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Status = InboundWireTransfers::InboundWireTransferStatus.Accepted,
                    Type = InboundWireTransfers::Type.InboundWireTransfer,
                    UniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a",
                    UnstructuredRemittanceInformation = "INVOICE 2468",
                    WireDrawdownRequestID = null,
                },
            ],
            NextCursor = "v57w5d",
        };

        InboundWireTransfers::InboundWireTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
