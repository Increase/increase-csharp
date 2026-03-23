using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using ExternalAccounts = Increase.Api.Models.ExternalAccounts;

namespace Increase.Api.Tests.Models.ExternalAccounts;

public class ExternalAccountListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalAccounts::ExternalAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "external_account_ukk55lr923a3ac0pp7iv",
                    AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
                    AccountNumber = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Landlord",
                    Funding = ExternalAccounts::ExternalAccountFunding.Checking,
                    IdempotencyKey = null,
                    RoutingNumber = "101050001",
                    Status = ExternalAccounts::ExternalAccountStatus.Active,
                    Type = ExternalAccounts::Type.ExternalAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<ExternalAccounts::ExternalAccount> expectedData =
        [
            new()
            {
                ID = "external_account_ukk55lr923a3ac0pp7iv",
                AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
                AccountNumber = "987654321",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "Landlord",
                Funding = ExternalAccounts::ExternalAccountFunding.Checking,
                IdempotencyKey = null,
                RoutingNumber = "101050001",
                Status = ExternalAccounts::ExternalAccountStatus.Active,
                Type = ExternalAccounts::Type.ExternalAccount,
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
        var model = new ExternalAccounts::ExternalAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "external_account_ukk55lr923a3ac0pp7iv",
                    AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
                    AccountNumber = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Landlord",
                    Funding = ExternalAccounts::ExternalAccountFunding.Checking,
                    IdempotencyKey = null,
                    RoutingNumber = "101050001",
                    Status = ExternalAccounts::ExternalAccountStatus.Active,
                    Type = ExternalAccounts::Type.ExternalAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExternalAccounts::ExternalAccountListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalAccounts::ExternalAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "external_account_ukk55lr923a3ac0pp7iv",
                    AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
                    AccountNumber = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Landlord",
                    Funding = ExternalAccounts::ExternalAccountFunding.Checking,
                    IdempotencyKey = null,
                    RoutingNumber = "101050001",
                    Status = ExternalAccounts::ExternalAccountStatus.Active,
                    Type = ExternalAccounts::Type.ExternalAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ExternalAccounts::ExternalAccountListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<ExternalAccounts::ExternalAccount> expectedData =
        [
            new()
            {
                ID = "external_account_ukk55lr923a3ac0pp7iv",
                AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
                AccountNumber = "987654321",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Description = "Landlord",
                Funding = ExternalAccounts::ExternalAccountFunding.Checking,
                IdempotencyKey = null,
                RoutingNumber = "101050001",
                Status = ExternalAccounts::ExternalAccountStatus.Active,
                Type = ExternalAccounts::Type.ExternalAccount,
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
        var model = new ExternalAccounts::ExternalAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "external_account_ukk55lr923a3ac0pp7iv",
                    AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
                    AccountNumber = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Landlord",
                    Funding = ExternalAccounts::ExternalAccountFunding.Checking,
                    IdempotencyKey = null,
                    RoutingNumber = "101050001",
                    Status = ExternalAccounts::ExternalAccountStatus.Active,
                    Type = ExternalAccounts::Type.ExternalAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalAccounts::ExternalAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "external_account_ukk55lr923a3ac0pp7iv",
                    AccountHolder = ExternalAccounts::ExternalAccountAccountHolder.Business,
                    AccountNumber = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Description = "Landlord",
                    Funding = ExternalAccounts::ExternalAccountFunding.Checking,
                    IdempotencyKey = null,
                    RoutingNumber = "101050001",
                    Status = ExternalAccounts::ExternalAccountStatus.Active,
                    Type = ExternalAccounts::Type.ExternalAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        ExternalAccounts::ExternalAccountListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
