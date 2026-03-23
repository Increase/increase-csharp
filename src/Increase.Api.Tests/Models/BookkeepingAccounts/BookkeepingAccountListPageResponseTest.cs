using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Models.BookkeepingAccounts;

namespace Increase.Api.Tests.Models.BookkeepingAccounts;

public class BookkeepingAccountListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BookkeepingAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    AccountID = null,
                    ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
                    Name = "John Doe Balance",
                    Type = Type.BookkeepingAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<BookkeepingAccount> expectedData =
        [
            new()
            {
                ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                AccountID = null,
                ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                IdempotencyKey = null,
                Name = "John Doe Balance",
                Type = Type.BookkeepingAccount,
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
        var model = new BookkeepingAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    AccountID = null,
                    ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
                    Name = "John Doe Balance",
                    Type = Type.BookkeepingAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingAccountListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BookkeepingAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    AccountID = null,
                    ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
                    Name = "John Doe Balance",
                    Type = Type.BookkeepingAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BookkeepingAccountListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BookkeepingAccount> expectedData =
        [
            new()
            {
                ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                AccountID = null,
                ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                IdempotencyKey = null,
                Name = "John Doe Balance",
                Type = Type.BookkeepingAccount,
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
        var model = new BookkeepingAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    AccountID = null,
                    ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
                    Name = "John Doe Balance",
                    Type = Type.BookkeepingAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BookkeepingAccountListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "bookkeeping_account_e37p1f1iuocw5intf35v",
                    AccountID = null,
                    ComplianceCategory = BookkeepingAccountComplianceCategory.CustomerBalance,
                    EntityID = "entity_n8y8tnk2p9339ti393yi",
                    IdempotencyKey = null,
                    Name = "John Doe Balance",
                    Type = Type.BookkeepingAccount,
                },
            ],
            NextCursor = "v57w5d",
        };

        BookkeepingAccountListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
