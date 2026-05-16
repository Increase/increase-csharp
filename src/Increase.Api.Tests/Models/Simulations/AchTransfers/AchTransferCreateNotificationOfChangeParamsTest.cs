using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Simulations.AchTransfers;

namespace Increase.Api.Tests.Models.Simulations.AchTransfers;

public class AchTransferCreateNotificationOfChangeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AchTransferCreateNotificationOfChangeParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            CorrectedAccountFunding = CorrectedAccountFunding.Checking,
            CorrectedAccountNumber = "x",
            CorrectedIndividualID = "x",
            CorrectedRoutingNumber = "123456789",
        };

        string expectedAchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q";
        ApiEnum<string, CorrectedAccountFunding> expectedCorrectedAccountFunding =
            CorrectedAccountFunding.Checking;
        string expectedCorrectedAccountNumber = "x";
        string expectedCorrectedIndividualID = "x";
        string expectedCorrectedRoutingNumber = "123456789";

        Assert.Equal(expectedAchTransferID, parameters.AchTransferID);
        Assert.Equal(expectedCorrectedAccountFunding, parameters.CorrectedAccountFunding);
        Assert.Equal(expectedCorrectedAccountNumber, parameters.CorrectedAccountNumber);
        Assert.Equal(expectedCorrectedIndividualID, parameters.CorrectedIndividualID);
        Assert.Equal(expectedCorrectedRoutingNumber, parameters.CorrectedRoutingNumber);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AchTransferCreateNotificationOfChangeParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        Assert.Null(parameters.CorrectedAccountFunding);
        Assert.False(parameters.RawBodyData.ContainsKey("corrected_account_funding"));
        Assert.Null(parameters.CorrectedAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("corrected_account_number"));
        Assert.Null(parameters.CorrectedIndividualID);
        Assert.False(parameters.RawBodyData.ContainsKey("corrected_individual_id"));
        Assert.Null(parameters.CorrectedRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("corrected_routing_number"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AchTransferCreateNotificationOfChangeParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",

            // Null should be interpreted as omitted for these properties
            CorrectedAccountFunding = null,
            CorrectedAccountNumber = null,
            CorrectedIndividualID = null,
            CorrectedRoutingNumber = null,
        };

        Assert.Null(parameters.CorrectedAccountFunding);
        Assert.False(parameters.RawBodyData.ContainsKey("corrected_account_funding"));
        Assert.Null(parameters.CorrectedAccountNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("corrected_account_number"));
        Assert.Null(parameters.CorrectedIndividualID);
        Assert.False(parameters.RawBodyData.ContainsKey("corrected_individual_id"));
        Assert.Null(parameters.CorrectedRoutingNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("corrected_routing_number"));
    }

    [Fact]
    public void Url_Works()
    {
        AchTransferCreateNotificationOfChangeParams parameters = new()
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/ach_transfers/ach_transfer_uoxatyh3lt5evrsdvo7q/create_notification_of_change"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AchTransferCreateNotificationOfChangeParams
        {
            AchTransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
            CorrectedAccountFunding = CorrectedAccountFunding.Checking,
            CorrectedAccountNumber = "x",
            CorrectedIndividualID = "x",
            CorrectedRoutingNumber = "123456789",
        };

        AchTransferCreateNotificationOfChangeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CorrectedAccountFundingTest : TestBase
{
    [Theory]
    [InlineData(CorrectedAccountFunding.Checking)]
    [InlineData(CorrectedAccountFunding.Savings)]
    [InlineData(CorrectedAccountFunding.GeneralLedger)]
    public void Validation_Works(CorrectedAccountFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CorrectedAccountFunding> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CorrectedAccountFunding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CorrectedAccountFunding.Checking)]
    [InlineData(CorrectedAccountFunding.Savings)]
    [InlineData(CorrectedAccountFunding.GeneralLedger)]
    public void SerializationRoundtrip_Works(CorrectedAccountFunding rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CorrectedAccountFunding> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CorrectedAccountFunding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CorrectedAccountFunding>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CorrectedAccountFunding>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
