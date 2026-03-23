using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using AccountNumbers = Increase.Api.Models.AccountNumbers;

namespace Increase.Api.Tests.Models.AccountNumbers;

public class AccountNumberListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AccountNumbers::AccountNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_number_v18nkfqm6afpsrvy82b2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberValue = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
                    InboundChecks = new(
                        AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
                    ),
                    Name = "ACH",
                    RoutingNumber = "101050001",
                    Status = AccountNumbers::AccountNumberStatus.Active,
                    Type = AccountNumbers::Type.AccountNumber,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<AccountNumbers::AccountNumber> expectedData =
        [
            new()
            {
                ID = "account_number_v18nkfqm6afpsrvy82b2",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberValue = "987654321",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                IdempotencyKey = null,
                InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
                InboundChecks = new(
                    AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
                ),
                Name = "ACH",
                RoutingNumber = "101050001",
                Status = AccountNumbers::AccountNumberStatus.Active,
                Type = AccountNumbers::Type.AccountNumber,
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
        var model = new AccountNumbers::AccountNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_number_v18nkfqm6afpsrvy82b2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberValue = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
                    InboundChecks = new(
                        AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
                    ),
                    Name = "ACH",
                    RoutingNumber = "101050001",
                    Status = AccountNumbers::AccountNumberStatus.Active,
                    Type = AccountNumbers::Type.AccountNumber,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountNumbers::AccountNumberListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AccountNumbers::AccountNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_number_v18nkfqm6afpsrvy82b2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberValue = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
                    InboundChecks = new(
                        AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
                    ),
                    Name = "ACH",
                    RoutingNumber = "101050001",
                    Status = AccountNumbers::AccountNumberStatus.Active,
                    Type = AccountNumbers::Type.AccountNumber,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AccountNumbers::AccountNumberListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<AccountNumbers::AccountNumber> expectedData =
        [
            new()
            {
                ID = "account_number_v18nkfqm6afpsrvy82b2",
                AccountID = "account_in71c4amph0vgo2qllky",
                AccountNumberValue = "987654321",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                IdempotencyKey = null,
                InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
                InboundChecks = new(
                    AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
                ),
                Name = "ACH",
                RoutingNumber = "101050001",
                Status = AccountNumbers::AccountNumberStatus.Active,
                Type = AccountNumbers::Type.AccountNumber,
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
        var model = new AccountNumbers::AccountNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_number_v18nkfqm6afpsrvy82b2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberValue = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
                    InboundChecks = new(
                        AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
                    ),
                    Name = "ACH",
                    RoutingNumber = "101050001",
                    Status = AccountNumbers::AccountNumberStatus.Active,
                    Type = AccountNumbers::Type.AccountNumber,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AccountNumbers::AccountNumberListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "account_number_v18nkfqm6afpsrvy82b2",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    AccountNumberValue = "987654321",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    IdempotencyKey = null,
                    InboundAch = new(AccountNumbers::AccountNumberInboundAchDebitStatus.Blocked),
                    InboundChecks = new(
                        AccountNumbers::AccountNumberInboundChecksStatus.CheckTransfersOnly
                    ),
                    Name = "ACH",
                    RoutingNumber = "101050001",
                    Status = AccountNumbers::AccountNumberStatus.Active,
                    Type = AccountNumbers::Type.AccountNumber,
                },
            ],
            NextCursor = "v57w5d",
        };

        AccountNumbers::AccountNumberListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
