using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Programs = Increase.Api.Models.Programs;

namespace Increase.Api.Tests.Models.Programs;

public class ProgramListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Programs::ProgramListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "program_i2v2os4mwza1oetokh9i",
                    Bank = Programs::Bank.FirstInternetBank,
                    BillingAccountID = null,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DefaultDigitalCardProfileID = null,
                    InterestRate = "0.01",
                    Lending = new(0),
                    Name = "Commercial Banking",
                    Type = Programs::Type.Program,
                    UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Programs::Program> expectedData =
        [
            new()
            {
                ID = "program_i2v2os4mwza1oetokh9i",
                Bank = Programs::Bank.FirstInternetBank,
                BillingAccountID = null,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DefaultDigitalCardProfileID = null,
                InterestRate = "0.01",
                Lending = new(0),
                Name = "Commercial Banking",
                Type = Programs::Type.Program,
                UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
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
        var model = new Programs::ProgramListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "program_i2v2os4mwza1oetokh9i",
                    Bank = Programs::Bank.FirstInternetBank,
                    BillingAccountID = null,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DefaultDigitalCardProfileID = null,
                    InterestRate = "0.01",
                    Lending = new(0),
                    Name = "Commercial Banking",
                    Type = Programs::Type.Program,
                    UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Programs::ProgramListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Programs::ProgramListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "program_i2v2os4mwza1oetokh9i",
                    Bank = Programs::Bank.FirstInternetBank,
                    BillingAccountID = null,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DefaultDigitalCardProfileID = null,
                    InterestRate = "0.01",
                    Lending = new(0),
                    Name = "Commercial Banking",
                    Type = Programs::Type.Program,
                    UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Programs::ProgramListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Programs::Program> expectedData =
        [
            new()
            {
                ID = "program_i2v2os4mwza1oetokh9i",
                Bank = Programs::Bank.FirstInternetBank,
                BillingAccountID = null,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                DefaultDigitalCardProfileID = null,
                InterestRate = "0.01",
                Lending = new(0),
                Name = "Commercial Banking",
                Type = Programs::Type.Program,
                UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
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
        var model = new Programs::ProgramListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "program_i2v2os4mwza1oetokh9i",
                    Bank = Programs::Bank.FirstInternetBank,
                    BillingAccountID = null,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DefaultDigitalCardProfileID = null,
                    InterestRate = "0.01",
                    Lending = new(0),
                    Name = "Commercial Banking",
                    Type = Programs::Type.Program,
                    UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Programs::ProgramListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "program_i2v2os4mwza1oetokh9i",
                    Bank = Programs::Bank.FirstInternetBank,
                    BillingAccountID = null,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    DefaultDigitalCardProfileID = null,
                    InterestRate = "0.01",
                    Lending = new(0),
                    Name = "Commercial Banking",
                    Type = Programs::Type.Program,
                    UpdatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                },
            ],
            NextCursor = "v57w5d",
        };

        Programs::ProgramListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
