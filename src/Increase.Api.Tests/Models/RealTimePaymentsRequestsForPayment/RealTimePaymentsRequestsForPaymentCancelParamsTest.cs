using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.RealTimePaymentsRequestsForPayment;

namespace Increase.Api.Tests.Models.RealTimePaymentsRequestsForPayment;

public class RealTimePaymentsRequestsForPaymentCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentCancelParams
        {
            RealTimePaymentsRequestForPaymentID =
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
            AdditionalInformation = "x",
            Reason = Reason.RequestedByCustomer,
        };

        string expectedRealTimePaymentsRequestForPaymentID =
            "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7";
        string expectedAdditionalInformation = "x";
        ApiEnum<string, Reason> expectedReason = Reason.RequestedByCustomer;

        Assert.Equal(
            expectedRealTimePaymentsRequestForPaymentID,
            parameters.RealTimePaymentsRequestForPaymentID
        );
        Assert.Equal(expectedAdditionalInformation, parameters.AdditionalInformation);
        Assert.Equal(expectedReason, parameters.Reason);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentCancelParams
        {
            RealTimePaymentsRequestForPaymentID =
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
        };

        Assert.Null(parameters.AdditionalInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("additional_information"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentCancelParams
        {
            RealTimePaymentsRequestForPaymentID =
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",

            // Null should be interpreted as omitted for these properties
            AdditionalInformation = null,
            Reason = null,
        };

        Assert.Null(parameters.AdditionalInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("additional_information"));
        Assert.Null(parameters.Reason);
        Assert.False(parameters.RawBodyData.ContainsKey("reason"));
    }

    [Fact]
    public void Url_Works()
    {
        RealTimePaymentsRequestsForPaymentCancelParams parameters = new()
        {
            RealTimePaymentsRequestForPaymentID =
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/real_time_payments_requests_for_payment/real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7/cancel"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RealTimePaymentsRequestsForPaymentCancelParams
        {
            RealTimePaymentsRequestForPaymentID =
                "real_time_payments_request_for_payment_28kcliz1oevcnqyn9qp7",
            AdditionalInformation = "x",
            Reason = Reason.RequestedByCustomer,
        };

        RealTimePaymentsRequestsForPaymentCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.RequestedByCustomer)]
    [InlineData(Reason.PaidByOtherMeans)]
    [InlineData(Reason.Duplicate)]
    [InlineData(Reason.WrongAmount)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.RequestedByCustomer)]
    [InlineData(Reason.PaidByOtherMeans)]
    [InlineData(Reason.Duplicate)]
    [InlineData(Reason.WrongAmount)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
