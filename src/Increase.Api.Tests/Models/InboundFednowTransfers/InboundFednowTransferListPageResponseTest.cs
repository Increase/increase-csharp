using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using InboundFednowTransfers = Increase.Api.Models.InboundFednowTransfers;

namespace Increase.Api.Tests.Models.InboundFednowTransfers;

public class InboundFednowTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundFednowTransfers::InboundFednowTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    Confirmation = new("inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorName = "Ian Crease",
                    Currency = InboundFednowTransfers::Currency.Usd,
                    DebtorAccountNumber = "987654321",
                    DebtorName = "National Phonograph Company",
                    DebtorRoutingNumber = "101050001",
                    Decline = new()
                    {
                        Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
                        TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    },
                    Status = InboundFednowTransfers::Status.Confirmed,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundFednowTransfers::Type.InboundFednowTransfer,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        List<InboundFednowTransfers::InboundFednowTransfer> expectedData =
        [
            new()
            {
                ID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                Confirmation = new("inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreditorName = "Ian Crease",
                Currency = InboundFednowTransfers::Currency.Usd,
                DebtorAccountNumber = "987654321",
                DebtorName = "National Phonograph Company",
                DebtorRoutingNumber = "101050001",
                Decline = new()
                {
                    Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
                    TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                },
                Status = InboundFednowTransfers::Status.Confirmed,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = InboundFednowTransfers::Type.InboundFednowTransfer,
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
        var model = new InboundFednowTransfers::InboundFednowTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    Confirmation = new("inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorName = "Ian Crease",
                    Currency = InboundFednowTransfers::Currency.Usd,
                    DebtorAccountNumber = "987654321",
                    DebtorName = "National Phonograph Company",
                    DebtorRoutingNumber = "101050001",
                    Decline = new()
                    {
                        Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
                        TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    },
                    Status = InboundFednowTransfers::Status.Confirmed,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundFednowTransfers::Type.InboundFednowTransfer,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundFednowTransfers::InboundFednowTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundFednowTransfers::InboundFednowTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    Confirmation = new("inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorName = "Ian Crease",
                    Currency = InboundFednowTransfers::Currency.Usd,
                    DebtorAccountNumber = "987654321",
                    DebtorName = "National Phonograph Company",
                    DebtorRoutingNumber = "101050001",
                    Decline = new()
                    {
                        Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
                        TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    },
                    Status = InboundFednowTransfers::Status.Confirmed,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundFednowTransfers::Type.InboundFednowTransfer,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundFednowTransfers::InboundFednowTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<InboundFednowTransfers::InboundFednowTransfer> expectedData =
        [
            new()
            {
                ID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                Confirmation = new("inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"),
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreditorName = "Ian Crease",
                Currency = InboundFednowTransfers::Currency.Usd,
                DebtorAccountNumber = "987654321",
                DebtorName = "National Phonograph Company",
                DebtorRoutingNumber = "101050001",
                Decline = new()
                {
                    Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
                    TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                },
                Status = InboundFednowTransfers::Status.Confirmed,
                TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                Type = InboundFednowTransfers::Type.InboundFednowTransfer,
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
        var model = new InboundFednowTransfers::InboundFednowTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    Confirmation = new("inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorName = "Ian Crease",
                    Currency = InboundFednowTransfers::Currency.Usd,
                    DebtorAccountNumber = "987654321",
                    DebtorName = "National Phonograph Company",
                    DebtorRoutingNumber = "101050001",
                    Decline = new()
                    {
                        Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
                        TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    },
                    Status = InboundFednowTransfers::Status.Confirmed,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundFednowTransfers::Type.InboundFednowTransfer,
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
        var model = new InboundFednowTransfers::InboundFednowTransferListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                    Amount = 100,
                    Confirmation = new("inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"),
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    CreditorName = "Ian Crease",
                    Currency = InboundFednowTransfers::Currency.Usd,
                    DebtorAccountNumber = "987654321",
                    DebtorName = "National Phonograph Company",
                    DebtorRoutingNumber = "101050001",
                    Decline = new()
                    {
                        Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
                        TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
                    },
                    Status = InboundFednowTransfers::Status.Confirmed,
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    Type = InboundFednowTransfers::Type.InboundFednowTransfer,
                    UnstructuredRemittanceInformation = "Invoice 29582",
                },
            ],
            NextCursor = "v57w5d",
        };

        InboundFednowTransfers::InboundFednowTransferListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
