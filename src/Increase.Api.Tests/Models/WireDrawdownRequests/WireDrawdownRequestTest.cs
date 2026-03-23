using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using WireDrawdownRequests = Increase.Api.Models.WireDrawdownRequests;

namespace Increase.Api.Tests.Models.WireDrawdownRequests;

public class WireDrawdownRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequest
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
        };

        string expectedID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 10000;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        WireDrawdownRequests::WireDrawdownRequestCreditorAddress expectedCreditorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };
        string expectedCreditorName = "Ian Crease";
        string expectedCurrency = "USD";
        string expectedDebtorAccountNumber = "987654321";
        WireDrawdownRequests::WireDrawdownRequestDebtorAddress expectedDebtorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };
        string expectedDebtorName = "Ian Crease";
        string expectedDebtorRoutingNumber = "101050001";
        string expectedFulfillmentInboundWireTransferID =
            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";
        ApiEnum<string, WireDrawdownRequests::WireDrawdownRequestStatus> expectedStatus =
            WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled;
        WireDrawdownRequests::Submission expectedSubmission = new("20220118MMQFMP0P000003");
        ApiEnum<string, WireDrawdownRequests::Type> expectedType =
            WireDrawdownRequests::Type.WireDrawdownRequest;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAccountNumberID, model.AccountNumberID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditorAddress, model.CreditorAddress);
        Assert.Equal(expectedCreditorName, model.CreditorName);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDebtorAccountNumber, model.DebtorAccountNumber);
        Assert.Equal(expectedDebtorAddress, model.DebtorAddress);
        Assert.Null(model.DebtorExternalAccountID);
        Assert.Equal(expectedDebtorName, model.DebtorName);
        Assert.Equal(expectedDebtorRoutingNumber, model.DebtorRoutingNumber);
        Assert.Equal(
            expectedFulfillmentInboundWireTransferID,
            model.FulfillmentInboundWireTransferID
        );
        Assert.Null(model.IdempotencyKey);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubmission, model.Submission);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            model.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequest
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireDrawdownRequests::WireDrawdownRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequest
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireDrawdownRequests::WireDrawdownRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "wire_drawdown_request_q6lmocus3glo0lr2bfv3";
        string expectedAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        long expectedAmount = 10000;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        WireDrawdownRequests::WireDrawdownRequestCreditorAddress expectedCreditorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };
        string expectedCreditorName = "Ian Crease";
        string expectedCurrency = "USD";
        string expectedDebtorAccountNumber = "987654321";
        WireDrawdownRequests::WireDrawdownRequestDebtorAddress expectedDebtorAddress = new()
        {
            City = "New York",
            Country = "US",
            Line1 = "33 Liberty Street",
            Line2 = null,
            PostalCode = "10045",
            State = "NY",
        };
        string expectedDebtorName = "Ian Crease";
        string expectedDebtorRoutingNumber = "101050001";
        string expectedFulfillmentInboundWireTransferID =
            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0";
        ApiEnum<string, WireDrawdownRequests::WireDrawdownRequestStatus> expectedStatus =
            WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled;
        WireDrawdownRequests::Submission expectedSubmission = new("20220118MMQFMP0P000003");
        ApiEnum<string, WireDrawdownRequests::Type> expectedType =
            WireDrawdownRequests::Type.WireDrawdownRequest;
        string expectedUnstructuredRemittanceInformation = "Invoice 29582";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAccountNumberID, deserialized.AccountNumberID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditorAddress, deserialized.CreditorAddress);
        Assert.Equal(expectedCreditorName, deserialized.CreditorName);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDebtorAccountNumber, deserialized.DebtorAccountNumber);
        Assert.Equal(expectedDebtorAddress, deserialized.DebtorAddress);
        Assert.Null(deserialized.DebtorExternalAccountID);
        Assert.Equal(expectedDebtorName, deserialized.DebtorName);
        Assert.Equal(expectedDebtorRoutingNumber, deserialized.DebtorRoutingNumber);
        Assert.Equal(
            expectedFulfillmentInboundWireTransferID,
            deserialized.FulfillmentInboundWireTransferID
        );
        Assert.Null(deserialized.IdempotencyKey);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubmission, deserialized.Submission);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(
            expectedUnstructuredRemittanceInformation,
            deserialized.UnstructuredRemittanceInformation
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequest
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequest
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
        };

        WireDrawdownRequests::WireDrawdownRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireDrawdownRequestCreditorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireDrawdownRequests::WireDrawdownRequestCreditorAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireDrawdownRequests::WireDrawdownRequestCreditorAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestCreditorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        WireDrawdownRequests::WireDrawdownRequestCreditorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireDrawdownRequestDebtorAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireDrawdownRequests::WireDrawdownRequestDebtorAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WireDrawdownRequests::WireDrawdownRequestDebtorAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postal_code";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireDrawdownRequests::WireDrawdownRequestDebtorAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postal_code",
            State = "state",
        };

        WireDrawdownRequests::WireDrawdownRequestDebtorAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WireDrawdownRequestStatusTest : TestBase
{
    [Theory]
    [InlineData(WireDrawdownRequests::WireDrawdownRequestStatus.PendingSubmission)]
    [InlineData(WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled)]
    [InlineData(WireDrawdownRequests::WireDrawdownRequestStatus.PendingResponse)]
    [InlineData(WireDrawdownRequests::WireDrawdownRequestStatus.Refused)]
    public void Validation_Works(WireDrawdownRequests::WireDrawdownRequestStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireDrawdownRequests::WireDrawdownRequestStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WireDrawdownRequests::WireDrawdownRequestStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WireDrawdownRequests::WireDrawdownRequestStatus.PendingSubmission)]
    [InlineData(WireDrawdownRequests::WireDrawdownRequestStatus.Fulfilled)]
    [InlineData(WireDrawdownRequests::WireDrawdownRequestStatus.PendingResponse)]
    [InlineData(WireDrawdownRequests::WireDrawdownRequestStatus.Refused)]
    public void SerializationRoundtrip_Works(
        WireDrawdownRequests::WireDrawdownRequestStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireDrawdownRequests::WireDrawdownRequestStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WireDrawdownRequests::WireDrawdownRequestStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WireDrawdownRequests::WireDrawdownRequestStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WireDrawdownRequests::WireDrawdownRequestStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000003",
        };

        string expectedInputMessageAccountabilityData = "20220118MMQFMP0P000003";

        Assert.Equal(expectedInputMessageAccountabilityData, model.InputMessageAccountabilityData);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WireDrawdownRequests::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000003",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireDrawdownRequests::Submission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WireDrawdownRequests::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000003",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WireDrawdownRequests::Submission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedInputMessageAccountabilityData = "20220118MMQFMP0P000003";

        Assert.Equal(
            expectedInputMessageAccountabilityData,
            deserialized.InputMessageAccountabilityData
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WireDrawdownRequests::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000003",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WireDrawdownRequests::Submission
        {
            InputMessageAccountabilityData = "20220118MMQFMP0P000003",
        };

        WireDrawdownRequests::Submission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(WireDrawdownRequests::Type.WireDrawdownRequest)]
    public void Validation_Works(WireDrawdownRequests::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireDrawdownRequests::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireDrawdownRequests::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WireDrawdownRequests::Type.WireDrawdownRequest)]
    public void SerializationRoundtrip_Works(WireDrawdownRequests::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WireDrawdownRequests::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WireDrawdownRequests::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WireDrawdownRequests::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WireDrawdownRequests::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
