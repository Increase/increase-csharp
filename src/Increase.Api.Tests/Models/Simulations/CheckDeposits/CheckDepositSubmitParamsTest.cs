using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.Simulations.CheckDeposits;

namespace Increase.Api.Tests.Models.Simulations.CheckDeposits;

public class CheckDepositSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckDepositSubmitParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Scan = new()
            {
                AccountNumber = "x",
                RoutingNumber = "x",
                AuxiliaryOnUs = "x",
            },
        };

        string expectedCheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1";
        Scan expectedScan = new()
        {
            AccountNumber = "x",
            RoutingNumber = "x",
            AuxiliaryOnUs = "x",
        };

        Assert.Equal(expectedCheckDepositID, parameters.CheckDepositID);
        Assert.Equal(expectedScan, parameters.Scan);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CheckDepositSubmitParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        Assert.Null(parameters.Scan);
        Assert.False(parameters.RawBodyData.ContainsKey("scan"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CheckDepositSubmitParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",

            // Null should be interpreted as omitted for these properties
            Scan = null,
        };

        Assert.Null(parameters.Scan);
        Assert.False(parameters.RawBodyData.ContainsKey("scan"));
    }

    [Fact]
    public void Url_Works()
    {
        CheckDepositSubmitParams parameters = new()
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/simulations/check_deposits/check_deposit_f06n9gpg7sxn8t19lfc1/submit"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckDepositSubmitParams
        {
            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
            Scan = new()
            {
                AccountNumber = "x",
                RoutingNumber = "x",
                AuxiliaryOnUs = "x",
            },
        };

        CheckDepositSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ScanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Scan
        {
            AccountNumber = "x",
            RoutingNumber = "x",
            AuxiliaryOnUs = "x",
        };

        string expectedAccountNumber = "x";
        string expectedRoutingNumber = "x";
        string expectedAuxiliaryOnUs = "x";

        Assert.Equal(expectedAccountNumber, model.AccountNumber);
        Assert.Equal(expectedRoutingNumber, model.RoutingNumber);
        Assert.Equal(expectedAuxiliaryOnUs, model.AuxiliaryOnUs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Scan
        {
            AccountNumber = "x",
            RoutingNumber = "x",
            AuxiliaryOnUs = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scan>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Scan
        {
            AccountNumber = "x",
            RoutingNumber = "x",
            AuxiliaryOnUs = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Scan>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedAccountNumber = "x";
        string expectedRoutingNumber = "x";
        string expectedAuxiliaryOnUs = "x";

        Assert.Equal(expectedAccountNumber, deserialized.AccountNumber);
        Assert.Equal(expectedRoutingNumber, deserialized.RoutingNumber);
        Assert.Equal(expectedAuxiliaryOnUs, deserialized.AuxiliaryOnUs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Scan
        {
            AccountNumber = "x",
            RoutingNumber = "x",
            AuxiliaryOnUs = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Scan { AccountNumber = "x", RoutingNumber = "x" };

        Assert.Null(model.AuxiliaryOnUs);
        Assert.False(model.RawData.ContainsKey("auxiliary_on_us"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Scan { AccountNumber = "x", RoutingNumber = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Scan
        {
            AccountNumber = "x",
            RoutingNumber = "x",

            // Null should be interpreted as omitted for these properties
            AuxiliaryOnUs = null,
        };

        Assert.Null(model.AuxiliaryOnUs);
        Assert.False(model.RawData.ContainsKey("auxiliary_on_us"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Scan
        {
            AccountNumber = "x",
            RoutingNumber = "x",

            // Null should be interpreted as omitted for these properties
            AuxiliaryOnUs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Scan
        {
            AccountNumber = "x",
            RoutingNumber = "x",
            AuxiliaryOnUs = "x",
        };

        Scan copied = new(model);

        Assert.Equal(model, copied);
    }
}
