using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using InboundRealTimePaymentsTransfers = Increase.Api.Models.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.InboundRealTimePaymentsTransfers;

public class InboundRealTimePaymentsTransferListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransferListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Confirmation = new()
                        {
                            ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreditorName = "Ian Crease",
                        Currency = InboundRealTimePaymentsTransfers::Currency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        Decline = new()
                        {
                            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            DeclinedTransactionID = "declined_transaction_id",
                            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
                        },
                        Status = InboundRealTimePaymentsTransfers::Status.Confirmed,
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        Type =
                            InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        List<InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer> expectedData =
        [
            new()
            {
                ID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                Confirmation = new()
                {
                    ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                },
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreditorName = "Ian Crease",
                Currency = InboundRealTimePaymentsTransfers::Currency.Usd,
                DebtorAccountNumber = "987654321",
                DebtorName = "National Phonograph Company",
                DebtorRoutingNumber = "101050001",
                Decline = new()
                {
                    DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeclinedTransactionID = "declined_transaction_id",
                    Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
                },
                Status = InboundRealTimePaymentsTransfers::Status.Confirmed,
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                Type = InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer,
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
        var model =
            new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransferListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Confirmation = new()
                        {
                            ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreditorName = "Ian Crease",
                        Currency = InboundRealTimePaymentsTransfers::Currency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        Decline = new()
                        {
                            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            DeclinedTransactionID = "declined_transaction_id",
                            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
                        },
                        Status = InboundRealTimePaymentsTransfers::Status.Confirmed,
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        Type =
                            InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransferListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransferListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Confirmation = new()
                        {
                            ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreditorName = "Ian Crease",
                        Currency = InboundRealTimePaymentsTransfers::Currency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        Decline = new()
                        {
                            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            DeclinedTransactionID = "declined_transaction_id",
                            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
                        },
                        Status = InboundRealTimePaymentsTransfers::Status.Confirmed,
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        Type =
                            InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransferListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer> expectedData =
        [
            new()
            {
                ID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                Amount = 100,
                Confirmation = new()
                {
                    ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                },
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                CreditorName = "Ian Crease",
                Currency = InboundRealTimePaymentsTransfers::Currency.Usd,
                DebtorAccountNumber = "987654321",
                DebtorName = "National Phonograph Company",
                DebtorRoutingNumber = "101050001",
                Decline = new()
                {
                    DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeclinedTransactionID = "declined_transaction_id",
                    Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
                },
                Status = InboundRealTimePaymentsTransfers::Status.Confirmed,
                TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                Type = InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer,
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
        var model =
            new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransferListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Confirmation = new()
                        {
                            ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreditorName = "Ian Crease",
                        Currency = InboundRealTimePaymentsTransfers::Currency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        Decline = new()
                        {
                            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            DeclinedTransactionID = "declined_transaction_id",
                            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
                        },
                        Status = InboundRealTimePaymentsTransfers::Status.Confirmed,
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        Type =
                            InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer,
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
        var model =
            new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransferListPageResponse
            {
                Data =
                [
                    new()
                    {
                        ID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        AccountID = "account_in71c4amph0vgo2qllky",
                        AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                        Amount = 100,
                        Confirmation = new()
                        {
                            ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        CreditorName = "Ian Crease",
                        Currency = InboundRealTimePaymentsTransfers::Currency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        Decline = new()
                        {
                            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                            DeclinedTransactionID = "declined_transaction_id",
                            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
                        },
                        Status = InboundRealTimePaymentsTransfers::Status.Confirmed,
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        Type =
                            InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer,
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                ],
                NextCursor = "v57w5d",
            };

        InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransferListPageResponse copied =
            new(model);

        Assert.Equal(model, copied);
    }
}
