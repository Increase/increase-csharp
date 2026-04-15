using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using CardDisputes = Increase.Api.Models.Simulations.CardDisputes;

namespace Increase.Api.Tests.Models.Simulations.CardDisputes;

public class CardDisputeActionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CardDisputes::CardDisputeActionParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputes::Network.Visa,
            Visa = new()
            {
                Action = CardDisputes::Action.AcceptUserSubmission,
                AcceptChargeback = new(),
                AcceptUserSubmission = new(),
                DeclineUserPrearbitration = new(),
                ReceiveMerchantPrearbitration = new(),
                Represent = new(),
                RequestFurtherInformation = new("x"),
                TimeOutChargeback = new(),
                TimeOutMerchantPrearbitration = new(),
                TimeOutRepresentment = new(),
                TimeOutUserPrearbitration = new(),
            },
        };

        string expectedCardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men";
        ApiEnum<string, CardDisputes::Network> expectedNetwork = CardDisputes::Network.Visa;
        CardDisputes::Visa expectedVisa = new()
        {
            Action = CardDisputes::Action.AcceptUserSubmission,
            AcceptChargeback = new(),
            AcceptUserSubmission = new(),
            DeclineUserPrearbitration = new(),
            ReceiveMerchantPrearbitration = new(),
            Represent = new(),
            RequestFurtherInformation = new("x"),
            TimeOutChargeback = new(),
            TimeOutMerchantPrearbitration = new(),
            TimeOutRepresentment = new(),
            TimeOutUserPrearbitration = new(),
        };

        Assert.Equal(expectedCardDisputeID, parameters.CardDisputeID);
        Assert.Equal(expectedNetwork, parameters.Network);
        Assert.Equal(expectedVisa, parameters.Visa);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CardDisputes::CardDisputeActionParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputes::Network.Visa,
        };

        Assert.Null(parameters.Visa);
        Assert.False(parameters.RawBodyData.ContainsKey("visa"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CardDisputes::CardDisputeActionParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputes::Network.Visa,

            // Null should be interpreted as omitted for these properties
            Visa = null,
        };

        Assert.Null(parameters.Visa);
        Assert.False(parameters.RawBodyData.ContainsKey("visa"));
    }

    [Fact]
    public void Url_Works()
    {
        CardDisputes::CardDisputeActionParams parameters = new()
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputes::Network.Visa,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/card_disputes/card_dispute_h9sc95nbl1cgltpp7men/action"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CardDisputes::CardDisputeActionParams
        {
            CardDisputeID = "card_dispute_h9sc95nbl1cgltpp7men",
            Network = CardDisputes::Network.Visa,
            Visa = new()
            {
                Action = CardDisputes::Action.AcceptUserSubmission,
                AcceptChargeback = new(),
                AcceptUserSubmission = new(),
                DeclineUserPrearbitration = new(),
                ReceiveMerchantPrearbitration = new(),
                Represent = new(),
                RequestFurtherInformation = new("x"),
                TimeOutChargeback = new(),
                TimeOutMerchantPrearbitration = new(),
                TimeOutRepresentment = new(),
                TimeOutUserPrearbitration = new(),
            },
        };

        CardDisputes::CardDisputeActionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class NetworkTest : TestBase
{
    [Theory]
    [InlineData(CardDisputes::Network.Visa)]
    public void Validation_Works(CardDisputes::Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDisputes::Network> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardDisputes::Network>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardDisputes::Network.Visa)]
    public void SerializationRoundtrip_Works(CardDisputes::Network rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDisputes::Network> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardDisputes::Network>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardDisputes::Network>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardDisputes::Network>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::Visa
        {
            Action = CardDisputes::Action.AcceptChargeback,
            AcceptChargeback = new(),
            AcceptUserSubmission = new(),
            DeclineUserPrearbitration = new(),
            ReceiveMerchantPrearbitration = new(),
            Represent = new(),
            RequestFurtherInformation = new("x"),
            TimeOutChargeback = new(),
            TimeOutMerchantPrearbitration = new(),
            TimeOutRepresentment = new(),
            TimeOutUserPrearbitration = new(),
        };

        ApiEnum<string, CardDisputes::Action> expectedAction =
            CardDisputes::Action.AcceptChargeback;
        CardDisputes::AcceptChargeback expectedAcceptChargeback = new();
        CardDisputes::AcceptUserSubmission expectedAcceptUserSubmission = new();
        CardDisputes::DeclineUserPrearbitration expectedDeclineUserPrearbitration = new();
        CardDisputes::ReceiveMerchantPrearbitration expectedReceiveMerchantPrearbitration = new();
        CardDisputes::Represent expectedRepresent = new();
        CardDisputes::RequestFurtherInformation expectedRequestFurtherInformation = new("x");
        CardDisputes::TimeOutChargeback expectedTimeOutChargeback = new();
        CardDisputes::TimeOutMerchantPrearbitration expectedTimeOutMerchantPrearbitration = new();
        CardDisputes::TimeOutRepresentment expectedTimeOutRepresentment = new();
        CardDisputes::TimeOutUserPrearbitration expectedTimeOutUserPrearbitration = new();

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedAcceptChargeback, model.AcceptChargeback);
        Assert.Equal(expectedAcceptUserSubmission, model.AcceptUserSubmission);
        Assert.Equal(expectedDeclineUserPrearbitration, model.DeclineUserPrearbitration);
        Assert.Equal(expectedReceiveMerchantPrearbitration, model.ReceiveMerchantPrearbitration);
        Assert.Equal(expectedRepresent, model.Represent);
        Assert.Equal(expectedRequestFurtherInformation, model.RequestFurtherInformation);
        Assert.Equal(expectedTimeOutChargeback, model.TimeOutChargeback);
        Assert.Equal(expectedTimeOutMerchantPrearbitration, model.TimeOutMerchantPrearbitration);
        Assert.Equal(expectedTimeOutRepresentment, model.TimeOutRepresentment);
        Assert.Equal(expectedTimeOutUserPrearbitration, model.TimeOutUserPrearbitration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::Visa
        {
            Action = CardDisputes::Action.AcceptChargeback,
            AcceptChargeback = new(),
            AcceptUserSubmission = new(),
            DeclineUserPrearbitration = new(),
            ReceiveMerchantPrearbitration = new(),
            Represent = new(),
            RequestFurtherInformation = new("x"),
            TimeOutChargeback = new(),
            TimeOutMerchantPrearbitration = new(),
            TimeOutRepresentment = new(),
            TimeOutUserPrearbitration = new(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::Visa>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::Visa
        {
            Action = CardDisputes::Action.AcceptChargeback,
            AcceptChargeback = new(),
            AcceptUserSubmission = new(),
            DeclineUserPrearbitration = new(),
            ReceiveMerchantPrearbitration = new(),
            Represent = new(),
            RequestFurtherInformation = new("x"),
            TimeOutChargeback = new(),
            TimeOutMerchantPrearbitration = new(),
            TimeOutRepresentment = new(),
            TimeOutUserPrearbitration = new(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::Visa>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, CardDisputes::Action> expectedAction =
            CardDisputes::Action.AcceptChargeback;
        CardDisputes::AcceptChargeback expectedAcceptChargeback = new();
        CardDisputes::AcceptUserSubmission expectedAcceptUserSubmission = new();
        CardDisputes::DeclineUserPrearbitration expectedDeclineUserPrearbitration = new();
        CardDisputes::ReceiveMerchantPrearbitration expectedReceiveMerchantPrearbitration = new();
        CardDisputes::Represent expectedRepresent = new();
        CardDisputes::RequestFurtherInformation expectedRequestFurtherInformation = new("x");
        CardDisputes::TimeOutChargeback expectedTimeOutChargeback = new();
        CardDisputes::TimeOutMerchantPrearbitration expectedTimeOutMerchantPrearbitration = new();
        CardDisputes::TimeOutRepresentment expectedTimeOutRepresentment = new();
        CardDisputes::TimeOutUserPrearbitration expectedTimeOutUserPrearbitration = new();

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedAcceptChargeback, deserialized.AcceptChargeback);
        Assert.Equal(expectedAcceptUserSubmission, deserialized.AcceptUserSubmission);
        Assert.Equal(expectedDeclineUserPrearbitration, deserialized.DeclineUserPrearbitration);
        Assert.Equal(
            expectedReceiveMerchantPrearbitration,
            deserialized.ReceiveMerchantPrearbitration
        );
        Assert.Equal(expectedRepresent, deserialized.Represent);
        Assert.Equal(expectedRequestFurtherInformation, deserialized.RequestFurtherInformation);
        Assert.Equal(expectedTimeOutChargeback, deserialized.TimeOutChargeback);
        Assert.Equal(
            expectedTimeOutMerchantPrearbitration,
            deserialized.TimeOutMerchantPrearbitration
        );
        Assert.Equal(expectedTimeOutRepresentment, deserialized.TimeOutRepresentment);
        Assert.Equal(expectedTimeOutUserPrearbitration, deserialized.TimeOutUserPrearbitration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::Visa
        {
            Action = CardDisputes::Action.AcceptChargeback,
            AcceptChargeback = new(),
            AcceptUserSubmission = new(),
            DeclineUserPrearbitration = new(),
            ReceiveMerchantPrearbitration = new(),
            Represent = new(),
            RequestFurtherInformation = new("x"),
            TimeOutChargeback = new(),
            TimeOutMerchantPrearbitration = new(),
            TimeOutRepresentment = new(),
            TimeOutUserPrearbitration = new(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CardDisputes::Visa { Action = CardDisputes::Action.AcceptChargeback };

        Assert.Null(model.AcceptChargeback);
        Assert.False(model.RawData.ContainsKey("accept_chargeback"));
        Assert.Null(model.AcceptUserSubmission);
        Assert.False(model.RawData.ContainsKey("accept_user_submission"));
        Assert.Null(model.DeclineUserPrearbitration);
        Assert.False(model.RawData.ContainsKey("decline_user_prearbitration"));
        Assert.Null(model.ReceiveMerchantPrearbitration);
        Assert.False(model.RawData.ContainsKey("receive_merchant_prearbitration"));
        Assert.Null(model.Represent);
        Assert.False(model.RawData.ContainsKey("represent"));
        Assert.Null(model.RequestFurtherInformation);
        Assert.False(model.RawData.ContainsKey("request_further_information"));
        Assert.Null(model.TimeOutChargeback);
        Assert.False(model.RawData.ContainsKey("time_out_chargeback"));
        Assert.Null(model.TimeOutMerchantPrearbitration);
        Assert.False(model.RawData.ContainsKey("time_out_merchant_prearbitration"));
        Assert.Null(model.TimeOutRepresentment);
        Assert.False(model.RawData.ContainsKey("time_out_representment"));
        Assert.Null(model.TimeOutUserPrearbitration);
        Assert.False(model.RawData.ContainsKey("time_out_user_prearbitration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CardDisputes::Visa { Action = CardDisputes::Action.AcceptChargeback };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CardDisputes::Visa
        {
            Action = CardDisputes::Action.AcceptChargeback,

            // Null should be interpreted as omitted for these properties
            AcceptChargeback = null,
            AcceptUserSubmission = null,
            DeclineUserPrearbitration = null,
            ReceiveMerchantPrearbitration = null,
            Represent = null,
            RequestFurtherInformation = null,
            TimeOutChargeback = null,
            TimeOutMerchantPrearbitration = null,
            TimeOutRepresentment = null,
            TimeOutUserPrearbitration = null,
        };

        Assert.Null(model.AcceptChargeback);
        Assert.False(model.RawData.ContainsKey("accept_chargeback"));
        Assert.Null(model.AcceptUserSubmission);
        Assert.False(model.RawData.ContainsKey("accept_user_submission"));
        Assert.Null(model.DeclineUserPrearbitration);
        Assert.False(model.RawData.ContainsKey("decline_user_prearbitration"));
        Assert.Null(model.ReceiveMerchantPrearbitration);
        Assert.False(model.RawData.ContainsKey("receive_merchant_prearbitration"));
        Assert.Null(model.Represent);
        Assert.False(model.RawData.ContainsKey("represent"));
        Assert.Null(model.RequestFurtherInformation);
        Assert.False(model.RawData.ContainsKey("request_further_information"));
        Assert.Null(model.TimeOutChargeback);
        Assert.False(model.RawData.ContainsKey("time_out_chargeback"));
        Assert.Null(model.TimeOutMerchantPrearbitration);
        Assert.False(model.RawData.ContainsKey("time_out_merchant_prearbitration"));
        Assert.Null(model.TimeOutRepresentment);
        Assert.False(model.RawData.ContainsKey("time_out_representment"));
        Assert.Null(model.TimeOutUserPrearbitration);
        Assert.False(model.RawData.ContainsKey("time_out_user_prearbitration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CardDisputes::Visa
        {
            Action = CardDisputes::Action.AcceptChargeback,

            // Null should be interpreted as omitted for these properties
            AcceptChargeback = null,
            AcceptUserSubmission = null,
            DeclineUserPrearbitration = null,
            ReceiveMerchantPrearbitration = null,
            Represent = null,
            RequestFurtherInformation = null,
            TimeOutChargeback = null,
            TimeOutMerchantPrearbitration = null,
            TimeOutRepresentment = null,
            TimeOutUserPrearbitration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::Visa
        {
            Action = CardDisputes::Action.AcceptChargeback,
            AcceptChargeback = new(),
            AcceptUserSubmission = new(),
            DeclineUserPrearbitration = new(),
            ReceiveMerchantPrearbitration = new(),
            Represent = new(),
            RequestFurtherInformation = new("x"),
            TimeOutChargeback = new(),
            TimeOutMerchantPrearbitration = new(),
            TimeOutRepresentment = new(),
            TimeOutUserPrearbitration = new(),
        };

        CardDisputes::Visa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(CardDisputes::Action.AcceptChargeback)]
    [InlineData(CardDisputes::Action.AcceptUserSubmission)]
    [InlineData(CardDisputes::Action.DeclineUserPrearbitration)]
    [InlineData(CardDisputes::Action.ReceiveMerchantPrearbitration)]
    [InlineData(CardDisputes::Action.Represent)]
    [InlineData(CardDisputes::Action.RequestFurtherInformation)]
    [InlineData(CardDisputes::Action.TimeOutChargeback)]
    [InlineData(CardDisputes::Action.TimeOutMerchantPrearbitration)]
    [InlineData(CardDisputes::Action.TimeOutRepresentment)]
    [InlineData(CardDisputes::Action.TimeOutUserPrearbitration)]
    public void Validation_Works(CardDisputes::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDisputes::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardDisputes::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CardDisputes::Action.AcceptChargeback)]
    [InlineData(CardDisputes::Action.AcceptUserSubmission)]
    [InlineData(CardDisputes::Action.DeclineUserPrearbitration)]
    [InlineData(CardDisputes::Action.ReceiveMerchantPrearbitration)]
    [InlineData(CardDisputes::Action.Represent)]
    [InlineData(CardDisputes::Action.RequestFurtherInformation)]
    [InlineData(CardDisputes::Action.TimeOutChargeback)]
    [InlineData(CardDisputes::Action.TimeOutMerchantPrearbitration)]
    [InlineData(CardDisputes::Action.TimeOutRepresentment)]
    [InlineData(CardDisputes::Action.TimeOutUserPrearbitration)]
    public void SerializationRoundtrip_Works(CardDisputes::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CardDisputes::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardDisputes::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CardDisputes::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CardDisputes::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AcceptChargebackTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::AcceptChargeback { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::AcceptChargeback { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::AcceptChargeback>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::AcceptChargeback { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::AcceptChargeback>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::AcceptChargeback { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::AcceptChargeback { };

        CardDisputes::AcceptChargeback copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AcceptUserSubmissionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::AcceptUserSubmission { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::AcceptUserSubmission { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::AcceptUserSubmission>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::AcceptUserSubmission { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::AcceptUserSubmission>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::AcceptUserSubmission { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::AcceptUserSubmission { };

        CardDisputes::AcceptUserSubmission copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DeclineUserPrearbitrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::DeclineUserPrearbitration { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::DeclineUserPrearbitration { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::DeclineUserPrearbitration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::DeclineUserPrearbitration { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::DeclineUserPrearbitration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::DeclineUserPrearbitration { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::DeclineUserPrearbitration { };

        CardDisputes::DeclineUserPrearbitration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReceiveMerchantPrearbitrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::ReceiveMerchantPrearbitration { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::ReceiveMerchantPrearbitration { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::ReceiveMerchantPrearbitration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::ReceiveMerchantPrearbitration { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::ReceiveMerchantPrearbitration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::ReceiveMerchantPrearbitration { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::ReceiveMerchantPrearbitration { };

        CardDisputes::ReceiveMerchantPrearbitration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RepresentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::Represent { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::Represent { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::Represent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::Represent { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::Represent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::Represent { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::Represent { };

        CardDisputes::Represent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RequestFurtherInformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::RequestFurtherInformation { Reason = "x" };

        string expectedReason = "x";

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::RequestFurtherInformation { Reason = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::RequestFurtherInformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::RequestFurtherInformation { Reason = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::RequestFurtherInformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedReason = "x";

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::RequestFurtherInformation { Reason = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::RequestFurtherInformation { Reason = "x" };

        CardDisputes::RequestFurtherInformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TimeOutChargebackTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::TimeOutChargeback { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::TimeOutChargeback { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::TimeOutChargeback>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::TimeOutChargeback { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::TimeOutChargeback>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::TimeOutChargeback { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::TimeOutChargeback { };

        CardDisputes::TimeOutChargeback copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TimeOutMerchantPrearbitrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::TimeOutMerchantPrearbitration { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::TimeOutMerchantPrearbitration { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::TimeOutMerchantPrearbitration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::TimeOutMerchantPrearbitration { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::TimeOutMerchantPrearbitration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::TimeOutMerchantPrearbitration { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::TimeOutMerchantPrearbitration { };

        CardDisputes::TimeOutMerchantPrearbitration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TimeOutRepresentmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::TimeOutRepresentment { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::TimeOutRepresentment { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::TimeOutRepresentment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::TimeOutRepresentment { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::TimeOutRepresentment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::TimeOutRepresentment { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::TimeOutRepresentment { };

        CardDisputes::TimeOutRepresentment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TimeOutUserPrearbitrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CardDisputes::TimeOutUserPrearbitration { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CardDisputes::TimeOutUserPrearbitration { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::TimeOutUserPrearbitration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CardDisputes::TimeOutUserPrearbitration { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CardDisputes::TimeOutUserPrearbitration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CardDisputes::TimeOutUserPrearbitration { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CardDisputes::TimeOutUserPrearbitration { };

        CardDisputes::TimeOutUserPrearbitration copied = new(model);

        Assert.Equal(model, copied);
    }
}
