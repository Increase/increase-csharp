using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using InboundRealTimePaymentsTransfers = Increase.Api.Models.InboundRealTimePaymentsTransfers;

namespace Increase.Api.Tests.Models.InboundRealTimePaymentsTransfers;

public class InboundRealTimePaymentsTransferTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer
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
        };

        string expectedID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        InboundRealTimePaymentsTransfers::Confirmation expectedConfirmation = new()
        {
            ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, InboundRealTimePaymentsTransfers::Currency> expectedCurrency =
            InboundRealTimePaymentsTransfers::Currency.Usd;
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorName = "National Phonograph Company";
        string expectedDebtorRoutingNumber = "101050001";
        InboundRealTimePaymentsTransfers::Decline expectedDecline = new()
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
        };
        ApiEnum<string, InboundRealTimePaymentsTransfers::Status> expectedStatus =
            InboundRealTimePaymentsTransfers::Status.Confirmed;
        string expectedTransactionIdentification = "20220501234567891T1BSLZO01745013025";
        ApiEnum<string, InboundRealTimePaymentsTransfers::Type> expectedType =
            InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer;
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
        Assert.Equal(expectedTransactionIdentification, model.TransactionIdentification);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr";
        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 100;
        InboundRealTimePaymentsTransfers::Confirmation expectedConfirmation = new()
        {
            ConfirmedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        string expectedCreditorName = "Ian Crease";
        ApiEnum<string, InboundRealTimePaymentsTransfers::Currency> expectedCurrency =
            InboundRealTimePaymentsTransfers::Currency.Usd;
        string expectedDebtorAccountNumber = "987654321";
        string expectedDebtorName = "National Phonograph Company";
        string expectedDebtorRoutingNumber = "101050001";
        InboundRealTimePaymentsTransfers::Decline expectedDecline = new()
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
        };
        ApiEnum<string, InboundRealTimePaymentsTransfers::Status> expectedStatus =
            InboundRealTimePaymentsTransfers::Status.Confirmed;
        string expectedTransactionIdentification = "20220501234567891T1BSLZO01745013025";
        ApiEnum<string, InboundRealTimePaymentsTransfers::Type> expectedType =
            InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer;
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
        Assert.Equal(expectedTransactionIdentification, deserialized.TransactionIdentification);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer
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
        };

        InboundRealTimePaymentsTransfers::InboundRealTimePaymentsTransfer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfirmationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Confirmation
        {
            ConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        DateTimeOffset expectedConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedConfirmedAt, model.ConfirmedAt);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Confirmation
        {
            ConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsTransfers::Confirmation>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Confirmation
        {
            ConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<InboundRealTimePaymentsTransfers::Confirmation>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedTransactionID = "transaction_id";

        Assert.Equal(expectedConfirmedAt, deserialized.ConfirmedAt);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Confirmation
        {
            ConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Confirmation
        {
            ConfirmedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TransactionID = "transaction_id",
        };

        InboundRealTimePaymentsTransfers::Confirmation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(InboundRealTimePaymentsTransfers::Currency.Usd)]
    public void Validation_Works(InboundRealTimePaymentsTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsTransfers::Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Currency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundRealTimePaymentsTransfers::Currency.Usd)]
    public void SerializationRoundtrip_Works(InboundRealTimePaymentsTransfers::Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsTransfers::Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Currency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Currency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
        };

        DateTimeOffset expectedDeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeclinedTransactionID = "declined_transaction_id";
        ApiEnum<string, InboundRealTimePaymentsTransfers::Reason> expectedReason =
            InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled;

        Assert.Equal(expectedDeclinedAt, model.DeclinedAt);
        Assert.Equal(expectedDeclinedTransactionID, model.DeclinedTransactionID);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundRealTimePaymentsTransfers::Decline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InboundRealTimePaymentsTransfers::Decline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedDeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDeclinedTransactionID = "declined_transaction_id";
        ApiEnum<string, InboundRealTimePaymentsTransfers::Reason> expectedReason =
            InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled;

        Assert.Equal(expectedDeclinedAt, deserialized.DeclinedAt);
        Assert.Equal(expectedDeclinedTransactionID, deserialized.DeclinedTransactionID);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InboundRealTimePaymentsTransfers::Decline
        {
            DeclinedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeclinedTransactionID = "declined_transaction_id",
            Reason = InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled,
        };

        InboundRealTimePaymentsTransfers::Decline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.AccountNumberDisabled)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.AccountRestricted)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.GroupLocked)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.EntityNotActive)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.RealTimePaymentsNotEnabled)]
    public void Validation_Works(InboundRealTimePaymentsTransfers::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsTransfers::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Reason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.AccountNumberCanceled)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.AccountNumberDisabled)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.AccountRestricted)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.GroupLocked)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.EntityNotActive)]
    [InlineData(InboundRealTimePaymentsTransfers::Reason.RealTimePaymentsNotEnabled)]
    public void SerializationRoundtrip_Works(InboundRealTimePaymentsTransfers::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsTransfers::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Reason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Reason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Reason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(InboundRealTimePaymentsTransfers::Status.PendingConfirming)]
    [InlineData(InboundRealTimePaymentsTransfers::Status.TimedOut)]
    [InlineData(InboundRealTimePaymentsTransfers::Status.Confirmed)]
    [InlineData(InboundRealTimePaymentsTransfers::Status.Declined)]
    public void Validation_Works(InboundRealTimePaymentsTransfers::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsTransfers::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Status>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundRealTimePaymentsTransfers::Status.PendingConfirming)]
    [InlineData(InboundRealTimePaymentsTransfers::Status.TimedOut)]
    [InlineData(InboundRealTimePaymentsTransfers::Status.Confirmed)]
    [InlineData(InboundRealTimePaymentsTransfers::Status.Declined)]
    public void SerializationRoundtrip_Works(InboundRealTimePaymentsTransfers::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsTransfers::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Status>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Status>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer)]
    public void Validation_Works(InboundRealTimePaymentsTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsTransfers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(InboundRealTimePaymentsTransfers::Type.InboundRealTimePaymentsTransfer)]
    public void SerializationRoundtrip_Works(InboundRealTimePaymentsTransfers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, InboundRealTimePaymentsTransfers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, InboundRealTimePaymentsTransfers::Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
