using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundFednowTransfers = Increase.Api.Models.InboundFednowTransfers;

namespace Increase.Api.Tests.Models.InboundFednowTransfers;

public class InboundFednowTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundFednowTransfers::InboundFednowTransfer
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
        };

        string expectedID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        InboundFednowTransfers::Confirmation expectedConfirmation = new(
            "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, InboundFednowTransfers::Currency> expectedCurrency =
            InboundFednowTransfers::Currency.Usd;
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorName = "National Phonograph Company";
        string expectedDebtorRoutingNumber = "101050001";
        InboundFednowTransfers::Decline expectedDecline = new()
        {
            Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };
        ApiEnum<string, InboundFednowTransfers::Status> expectedStatus =
            InboundFednowTransfers::Status.Confirmed;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, InboundFednowTransfers::Type> expectedType =
            InboundFednowTransfers::Type.InboundFednowTransfer;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedConfirmation, model.Confirmation);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtorAccountNumber, model.DebtorAccountNumber);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Equal(expectedDebtorRoutingNumber, model.DebtorRoutingNumber);
        Assert.Equal(expectedDecline, model.Decline);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundFednowTransfers::InboundFednowTransfer
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundFednowTransfers::InboundFednowTransfer>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundFednowTransfers::InboundFednowTransfer
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundFednowTransfers::InboundFednowTransfer>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        InboundFednowTransfers::Confirmation expectedConfirmation = new(
            "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
        );
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, InboundFednowTransfers::Currency> expectedCurrency =
            InboundFednowTransfers::Currency.Usd;
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorName = "National Phonograph Company";
        string expectedDebtorRoutingNumber = "101050001";
        InboundFednowTransfers::Decline expectedDecline = new()
        {
            Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };
        ApiEnum<string, InboundFednowTransfers::Status> expectedStatus =
            InboundFednowTransfers::Status.Confirmed;
        string expectedTransactionID = "transaction_uyrp7fld2ium70oa7oi";
        ApiEnum<string, InboundFednowTransfers::Type> expectedType =
            InboundFednowTransfers::Type.InboundFednowTransfer;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedConfirmation, deserialized.Confirmation);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtorAccountNumber, deserialized.DebtorAccountNumber);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Equal(expectedDebtorRoutingNumber, deserialized.DebtorRoutingNumber);
        Assert.Equal(expectedDecline, deserialized.Decline);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundFednowTransfers::InboundFednowTransfer
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundFednowTransfers::InboundFednowTransfer
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
        };

        InboundFednowTransfers::InboundFednowTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfirmationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundFednowTransfers::Confirmation
        {
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        string expectedTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";

        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundFednowTransfers::Confirmation
        {
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundFednowTransfers::Confirmation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundFednowTransfers::Confirmation
        {
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundFednowTransfers::Confirmation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";

        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundFednowTransfers::Confirmation
        {
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundFednowTransfers::Confirmation
        {
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        InboundFednowTransfers::Confirmation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(InboundFednowTransfers::Currency.Usd)]
    public void Validation_Works(InboundFednowTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFednowTransfers::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFednowTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundFednowTransfers::Currency.Usd)]
    public void SerializationRoundtrip_Works(InboundFednowTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFednowTransfers::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundFednowTransfers::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFednowTransfers::Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundFednowTransfers::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundFednowTransfers::Decline
        {
            Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        ApiEnum<string, InboundFednowTransfers::Reason> expectedReason =
            InboundFednowTransfers::Reason.AccountNumberDisabled;
        string expectedTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";

        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundFednowTransfers::Decline
        {
            Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundFednowTransfers::Decline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundFednowTransfers::Decline
        {
            Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundFednowTransfers::Decline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, InboundFednowTransfers::Reason> expectedReason =
            InboundFednowTransfers::Reason.AccountNumberDisabled;
        string expectedTransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20";

        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundFednowTransfers::Decline
        {
            Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundFednowTransfers::Decline
        {
            Reason = InboundFednowTransfers::Reason.AccountNumberDisabled,
            TransferID = "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20",
        };

        InboundFednowTransfers::Decline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundFednowTransfers::Reason.AccountNumberCanceled)]
    [InlineData(InboundFednowTransfers::Reason.AccountNumberDisabled)]
    [InlineData(InboundFednowTransfers::Reason.AccountRestricted)]
    [InlineData(InboundFednowTransfers::Reason.GroupLocked)]
    [InlineData(InboundFednowTransfers::Reason.EntityNotActive)]
    [InlineData(InboundFednowTransfers::Reason.FednowNotEnabled)]
    public void Validation_Works(InboundFednowTransfers::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFednowTransfers::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFednowTransfers::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundFednowTransfers::Reason.AccountNumberCanceled)]
    [InlineData(InboundFednowTransfers::Reason.AccountNumberDisabled)]
    [InlineData(InboundFednowTransfers::Reason.AccountRestricted)]
    [InlineData(InboundFednowTransfers::Reason.GroupLocked)]
    [InlineData(InboundFednowTransfers::Reason.EntityNotActive)]
    [InlineData(InboundFednowTransfers::Reason.FednowNotEnabled)]
    public void SerializationRoundtrip_Works(InboundFednowTransfers::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFednowTransfers::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundFednowTransfers::Reason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFednowTransfers::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundFednowTransfers::Reason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(InboundFednowTransfers::Status.PendingConfirming)]
    [InlineData(InboundFednowTransfers::Status.TimedOut)]
    [InlineData(InboundFednowTransfers::Status.Confirmed)]
    [InlineData(InboundFednowTransfers::Status.Declined)]
    [InlineData(InboundFednowTransfers::Status.RequiresAttention)]
    public void Validation_Works(InboundFednowTransfers::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFednowTransfers::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFednowTransfers::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundFednowTransfers::Status.PendingConfirming)]
    [InlineData(InboundFednowTransfers::Status.TimedOut)]
    [InlineData(InboundFednowTransfers::Status.Confirmed)]
    [InlineData(InboundFednowTransfers::Status.Declined)]
    [InlineData(InboundFednowTransfers::Status.RequiresAttention)]
    public void SerializationRoundtrip_Works(InboundFednowTransfers::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFednowTransfers::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundFednowTransfers::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFednowTransfers::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundFednowTransfers::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(InboundFednowTransfers::Type.InboundFednowTransfer)]
    public void Validation_Works(InboundFednowTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFednowTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFednowTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundFednowTransfers::Type.InboundFednowTransfer)]
    public void SerializationRoundtrip_Works(InboundFednowTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundFednowTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundFednowTransfers::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, InboundFednowTransfers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundFednowTransfers::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
