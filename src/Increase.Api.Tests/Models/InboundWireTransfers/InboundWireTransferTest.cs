using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundWireTransfers = Increase.Api.Models.InboundWireTransfers;

namespace Increase.Api.Tests.Models.InboundWireTransfers;

public class InboundWireTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundWireTransfers::InboundWireTransfer
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
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            Description = "Inbound wire transfer",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = "20220118MMQFMP0P000001",
            InstructingAgentRoutingNumber = "101050001",
            InstructionIdentification = "202201180000001",
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
        };

        string expectedID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";
        InboundWireTransfers::Acceptance expectedAcceptance = new()
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorAddressLine1 = "33 Liberty Street";
        string expectedCreditorAddressLine2 = "New York, NY, 10045";
        string expectedCreditorName = "National Phonograph Company";
        string expectedDebtorAddressLine1 = "33 Liberty Street";
        string expectedDebtorAddressLine2 = "New York, NY, 10045";
        string expectedDebtorName = "Ian Crease";
        string expectedDescription = "Inbound wire transfer";
        string expectedEndToEndIdentification = "Invoice 29582";
        string expectedInputMessageAccountabilityData = "20220118MMQFMP0P000001";
        string expectedInstructingAgentRoutingNumber = "101050001";
        string expectedInstructionIdentification = "202201180000001";
        InboundWireTransfers::Reversal expectedReversal = new()
        {
            Reason = InboundWireTransfers::ReversalReason.Duplicate,
            ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        ApiEnum<string, InboundWireTransfers::InboundWireTransferStatus> expectedStatus =
            InboundWireTransfers::InboundWireTransferStatus.Accepted;
        ApiEnum<string, InboundWireTransfers::Type> expectedType =
            InboundWireTransfers::Type.InboundWireTransfer;
        string expectedUniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a";
        string expectedUnstructuredRemittanceInformation = "INVOICE 2468";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAcceptance, model.Acceptance);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditorAddressLine1, model.CreditorAddressLine1);
        Assert.Equal(expectedCreditorAddressLine2, model.CreditorAddressLine2);
        Assert.Null(model.CreditorAddressLine3);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedDebtorAddressLine1, model.DebtorAddressLine1);
        Assert.Equal(expectedDebtorAddressLine2, model.DebtorAddressLine2);
        Assert.Null(model.DebtorAddressLine3);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEndToEndIdentification, model.EndToEndIdentification);
        Assert.Equal(expectedInputMessageAccountabilityData, model.InputMessageAccountabilityData);
        Assert.Equal(expectedInstructingAgentRoutingNumber, model.InstructingAgentRoutingNumber);
        Assert.Equal(expectedInstructionIdentification, model.InstructionIdentification);
        Assert.Equal(expectedReversal, model.Reversal);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(
            expectedUniqueEndToEndTransactionReference,
            model.UniqueEndToEndTransactionReference
        );
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
        Assert.Null(model.WireDrawdownRequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundWireTransfers::InboundWireTransfer
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
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            Description = "Inbound wire transfer",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = "20220118MMQFMP0P000001",
            InstructingAgentRoutingNumber = "101050001",
            InstructionIdentification = "202201180000001",
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundWireTransfers::InboundWireTransfer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundWireTransfers::InboundWireTransfer
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
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            Description = "Inbound wire transfer",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = "20220118MMQFMP0P000001",
            InstructingAgentRoutingNumber = "101050001",
            InstructionIdentification = "202201180000001",
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundWireTransfers::InboundWireTransfer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";
        InboundWireTransfers::Acceptance expectedAcceptance = new()
        {
            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorAddressLine1 = "33 Liberty Street";
        string expectedCreditorAddressLine2 = "New York, NY, 10045";
        string expectedCreditorName = "National Phonograph Company";
        string expectedDebtorAddressLine1 = "33 Liberty Street";
        string expectedDebtorAddressLine2 = "New York, NY, 10045";
        string expectedDebtorName = "Ian Crease";
        string expectedDescription = "Inbound wire transfer";
        string expectedEndToEndIdentification = "Invoice 29582";
        string expectedInputMessageAccountabilityData = "20220118MMQFMP0P000001";
        string expectedInstructingAgentRoutingNumber = "101050001";
        string expectedInstructionIdentification = "202201180000001";
        InboundWireTransfers::Reversal expectedReversal = new()
        {
            Reason = InboundWireTransfers::ReversalReason.Duplicate,
            ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        ApiEnum<string, InboundWireTransfers::InboundWireTransferStatus> expectedStatus =
            InboundWireTransfers::InboundWireTransferStatus.Accepted;
        ApiEnum<string, InboundWireTransfers::Type> expectedType =
            InboundWireTransfers::Type.InboundWireTransfer;
        string expectedUniqueEndToEndTransactionReference = "9a21e10a-7600-4a24-8ff3-2cbc5943c27a";
        string expectedUnstructuredRemittanceInformation = "INVOICE 2468";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAcceptance, deserialized.Acceptance);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditorAddressLine1, deserialized.CreditorAddressLine1);
        Assert.Equal(expectedCreditorAddressLine2, deserialized.CreditorAddressLine2);
        Assert.Null(deserialized.CreditorAddressLine3);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedDebtorAddressLine1, deserialized.DebtorAddressLine1);
        Assert.Equal(expectedDebtorAddressLine2, deserialized.DebtorAddressLine2);
        Assert.Null(deserialized.DebtorAddressLine3);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEndToEndIdentification, deserialized.EndToEndIdentification);
        Assert.Equal(
            expectedInputMessageAccountabilityData,
            deserialized.InputMessageAccountabilityData
        );
        Assert.Equal(
            expectedInstructingAgentRoutingNumber,
            deserialized.InstructingAgentRoutingNumber
        );
        Assert.Equal(expectedInstructionIdentification, deserialized.InstructionIdentification);
        Assert.Equal(expectedReversal, deserialized.Reversal);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(
            expectedUniqueEndToEndTransactionReference,
            deserialized.UniqueEndToEndTransactionReference
        );
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
        Assert.Null(deserialized.WireDrawdownRequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundWireTransfers::InboundWireTransfer
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
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            Description = "Inbound wire transfer",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = "20220118MMQFMP0P000001",
            InstructingAgentRoutingNumber = "101050001",
            InstructionIdentification = "202201180000001",
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundWireTransfers::InboundWireTransfer
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
            DebtorAddressLine1 = "33 Liberty Street",
            DebtorAddressLine2 = "New York, NY, 10045",
            DebtorAddressLine3 = null,
            DebtorName = "Ian Crease",
            Description = "Inbound wire transfer",
            EndToEndIdentification = "Invoice 29582",
            InputMessageAccountabilityData = "20220118MMQFMP0P000001",
            InstructingAgentRoutingNumber = "101050001",
            InstructionIdentification = "202201180000001",
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
        };

        InboundWireTransfers::InboundWireTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcceptanceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundWireTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedAcceptedAt, model.AcceptedAt);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundWireTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundWireTransfers::Acceptance>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundWireTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundWireTransfers::Acceptance>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedAcceptedAt, deserialized.AcceptedAt);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundWireTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundWireTransfers::Acceptance
        {
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        InboundWireTransfers::Acceptance copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReversalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundWireTransfers::Reversal
        {
            Reason = InboundWireTransfers::ReversalReason.Duplicate,
            ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ApiEnum<string, InboundWireTransfers::ReversalReason> expectedReason =
            InboundWireTransfers::ReversalReason.Duplicate;
        DateTimeOffset expectedReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedReversedAt, model.ReversedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundWireTransfers::Reversal
        {
            Reason = InboundWireTransfers::ReversalReason.Duplicate,
            ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundWireTransfers::Reversal>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundWireTransfers::Reversal
        {
            Reason = InboundWireTransfers::ReversalReason.Duplicate,
            ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundWireTransfers::Reversal>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InboundWireTransfers::ReversalReason> expectedReason =
            InboundWireTransfers::ReversalReason.Duplicate;
        DateTimeOffset expectedReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedReversedAt, deserialized.ReversedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundWireTransfers::Reversal
        {
            Reason = InboundWireTransfers::ReversalReason.Duplicate,
            ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundWireTransfers::Reversal
        {
            Reason = InboundWireTransfers::ReversalReason.Duplicate,
            ReversedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        InboundWireTransfers::Reversal copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReversalReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundWireTransfers::ReversalReason.Duplicate)]
    [InlineData(InboundWireTransfers::ReversalReason.CreditorRequest)]
    [InlineData(InboundWireTransfers::ReversalReason.TransactionForbidden)]
    public void Validation_Works(InboundWireTransfers::ReversalReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundWireTransfers::ReversalReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireTransfers::ReversalReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundWireTransfers::ReversalReason.Duplicate)]
    [InlineData(InboundWireTransfers::ReversalReason.CreditorRequest)]
    [InlineData(InboundWireTransfers::ReversalReason.TransactionForbidden)]
    public void SerializationRoundtrip_Works(InboundWireTransfers::ReversalReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundWireTransfers::ReversalReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireTransfers::ReversalReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireTransfers::ReversalReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireTransfers::ReversalReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class InboundWireTransferStatusTest : TestBase
{
    [Theory]
    [InlineData(InboundWireTransfers::InboundWireTransferStatus.Pending)]
    [InlineData(InboundWireTransfers::InboundWireTransferStatus.Accepted)]
    [InlineData(InboundWireTransfers::InboundWireTransferStatus.Declined)]
    [InlineData(InboundWireTransfers::InboundWireTransferStatus.Reversed)]
    public void Validation_Works(InboundWireTransfers::InboundWireTransferStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundWireTransfers::InboundWireTransferStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireTransfers::InboundWireTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundWireTransfers::InboundWireTransferStatus.Pending)]
    [InlineData(InboundWireTransfers::InboundWireTransferStatus.Accepted)]
    [InlineData(InboundWireTransfers::InboundWireTransferStatus.Declined)]
    [InlineData(InboundWireTransfers::InboundWireTransferStatus.Reversed)]
    public void SerializationRoundtrip_Works(
        InboundWireTransfers::InboundWireTransferStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundWireTransfers::InboundWireTransferStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireTransfers::InboundWireTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireTransfers::InboundWireTransferStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundWireTransfers::InboundWireTransferStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(InboundWireTransfers::Type.InboundWireTransfer)]
    public void Validation_Works(InboundWireTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundWireTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundWireTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundWireTransfers::Type.InboundWireTransfer)]
    public void SerializationRoundtrip_Works(InboundWireTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundWireTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundWireTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundWireTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, InboundWireTransfers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
