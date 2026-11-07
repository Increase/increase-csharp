using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using CheckbookChecks = Increase.Api.Models.CheckbookChecks;

namespace Increase.Api.Tests.Models.CheckbookChecks;

public class CheckbookCheckListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckbookChecks::CheckbookCheckListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_check_klgh3z50guf6jcnfhibb",
                    CheckNumber = 1,
                    CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Status = CheckbookChecks::Status.PendingDeposit,
                    Type = CheckbookChecks::Type.CheckbookCheck,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<CheckbookChecks::CheckbookCheck> expectedData =
        [
            new()
            {
                ID = "checkbook_check_klgh3z50guf6jcnfhibb",
                CheckNumber = 1,
                CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Status = CheckbookChecks::Status.PendingDeposit,
                Type = CheckbookChecks::Type.CheckbookCheck,
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
        var model = new CheckbookChecks::CheckbookCheckListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_check_klgh3z50guf6jcnfhibb",
                    CheckNumber = 1,
                    CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Status = CheckbookChecks::Status.PendingDeposit,
                    Type = CheckbookChecks::Type.CheckbookCheck,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckbookChecks::CheckbookCheckListPageResponse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckbookChecks::CheckbookCheckListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_check_klgh3z50guf6jcnfhibb",
                    CheckNumber = 1,
                    CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Status = CheckbookChecks::Status.PendingDeposit,
                    Type = CheckbookChecks::Type.CheckbookCheck,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CheckbookChecks::CheckbookCheckListPageResponse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<CheckbookChecks::CheckbookCheck> expectedData =
        [
            new()
            {
                ID = "checkbook_check_klgh3z50guf6jcnfhibb",
                CheckNumber = 1,
                CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Status = CheckbookChecks::Status.PendingDeposit,
                Type = CheckbookChecks::Type.CheckbookCheck,
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
        var model = new CheckbookChecks::CheckbookCheckListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_check_klgh3z50guf6jcnfhibb",
                    CheckNumber = 1,
                    CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Status = CheckbookChecks::Status.PendingDeposit,
                    Type = CheckbookChecks::Type.CheckbookCheck,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckbookChecks::CheckbookCheckListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "checkbook_check_klgh3z50guf6jcnfhibb",
                    CheckNumber = 1,
                    CheckbookID = "checkbook_7iudxhxum6vlkcjxmi8y",
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Status = CheckbookChecks::Status.PendingDeposit,
                    Type = CheckbookChecks::Type.CheckbookCheck,
                },
            ],
            NextCursor = "v57w5d",
        };

        CheckbookChecks::CheckbookCheckListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
