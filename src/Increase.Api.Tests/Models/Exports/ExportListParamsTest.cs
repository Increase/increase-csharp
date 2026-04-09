using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.Exports;

namespace Increase.Api.Tests.Models.Exports;

public class ExportListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExportListParams
        {
            Category = ExportListParamsCategory.AccountStatementOfx,
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Cursor = "cursor",
            Form1099Int = new() { AccountID = "account_id" },
            Form1099Misc = new() { AccountID = "account_id" },
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.Pending] },
        };

        ApiEnum<string, ExportListParamsCategory> expectedCategory =
            ExportListParamsCategory.AccountStatementOfx;
        ExportListParamsCreatedAt expectedCreatedAt = new()
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCursor = "cursor";
        Form1099Int expectedForm1099Int = new() { AccountID = "account_id" };
        Form1099Misc expectedForm1099Misc = new() { AccountID = "account_id" };
        string expectedIdempotencyKey = "x";
        long expectedLimit = 1;
        Status expectedStatus = new() { In = [In.Pending] };

        Assert.Equal(expectedCategory, parameters.Category);
        Assert.Equal(expectedCreatedAt, parameters.CreatedAt);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedForm1099Int, parameters.Form1099Int);
        Assert.Equal(expectedForm1099Misc, parameters.Form1099Misc);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExportListParams { };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Form1099Int);
        Assert.False(parameters.RawQueryData.ContainsKey("form_1099_int"));
        Assert.Null(parameters.Form1099Misc);
        Assert.False(parameters.RawQueryData.ContainsKey("form_1099_misc"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExportListParams
        {
            // Null should be interpreted as omitted for these properties
            Category = null,
            CreatedAt = null,
            Cursor = null,
            Form1099Int = null,
            Form1099Misc = null,
            IdempotencyKey = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.Category);
        Assert.False(parameters.RawQueryData.ContainsKey("category"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Form1099Int);
        Assert.False(parameters.RawQueryData.ContainsKey("form_1099_int"));
        Assert.Null(parameters.Form1099Misc);
        Assert.False(parameters.RawQueryData.ContainsKey("form_1099_misc"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        ExportListParams parameters = new()
        {
            Category = ExportListParamsCategory.AccountStatementOfx,
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Cursor = "cursor",
            Form1099Int = new() { AccountID = "account_id" },
            Form1099Misc = new() { AccountID = "account_id" },
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.Pending] },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.increase.com/exports?category=account_statement_ofx&created_at.after=2019-12-27T18%3a11%3a19.117Z&created_at.before=2019-12-27T18%3a11%3a19.117Z&created_at.on_or_after=2019-12-27T18%3a11%3a19.117Z&created_at.on_or_before=2019-12-27T18%3a11%3a19.117Z&cursor=cursor&form_1099_int.account_id=account_id&form_1099_misc.account_id=account_id&idempotency_key=x&limit=1&status.in=pending"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExportListParams
        {
            Category = ExportListParamsCategory.AccountStatementOfx,
            CreatedAt = new()
            {
                After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Cursor = "cursor",
            Form1099Int = new() { AccountID = "account_id" },
            Form1099Misc = new() { AccountID = "account_id" },
            IdempotencyKey = "x",
            Limit = 1,
            Status = new() { In = [In.Pending] },
        };

        ExportListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ExportListParamsCategoryTest : TestBase
{
    [Theory]
    [InlineData(ExportListParamsCategory.AccountStatementOfx)]
    [InlineData(ExportListParamsCategory.AccountStatementBai2)]
    [InlineData(ExportListParamsCategory.TransactionCsv)]
    [InlineData(ExportListParamsCategory.BalanceCsv)]
    [InlineData(ExportListParamsCategory.BookkeepingAccountBalanceCsv)]
    [InlineData(ExportListParamsCategory.EntityCsv)]
    [InlineData(ExportListParamsCategory.VendorCsv)]
    [InlineData(ExportListParamsCategory.DashboardTableCsv)]
    [InlineData(ExportListParamsCategory.AccountVerificationLetter)]
    [InlineData(ExportListParamsCategory.FundingInstructions)]
    [InlineData(ExportListParamsCategory.Form1099Int)]
    [InlineData(ExportListParamsCategory.Form1099Misc)]
    [InlineData(ExportListParamsCategory.FeeCsv)]
    [InlineData(ExportListParamsCategory.VoidedCheck)]
    [InlineData(ExportListParamsCategory.DailyAccountBalanceCsv)]
    public void Validation_Works(ExportListParamsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExportListParamsCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExportListParamsCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExportListParamsCategory.AccountStatementOfx)]
    [InlineData(ExportListParamsCategory.AccountStatementBai2)]
    [InlineData(ExportListParamsCategory.TransactionCsv)]
    [InlineData(ExportListParamsCategory.BalanceCsv)]
    [InlineData(ExportListParamsCategory.BookkeepingAccountBalanceCsv)]
    [InlineData(ExportListParamsCategory.EntityCsv)]
    [InlineData(ExportListParamsCategory.VendorCsv)]
    [InlineData(ExportListParamsCategory.DashboardTableCsv)]
    [InlineData(ExportListParamsCategory.AccountVerificationLetter)]
    [InlineData(ExportListParamsCategory.FundingInstructions)]
    [InlineData(ExportListParamsCategory.Form1099Int)]
    [InlineData(ExportListParamsCategory.Form1099Misc)]
    [InlineData(ExportListParamsCategory.FeeCsv)]
    [InlineData(ExportListParamsCategory.VoidedCheck)]
    [InlineData(ExportListParamsCategory.DailyAccountBalanceCsv)]
    public void SerializationRoundtrip_Works(ExportListParamsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExportListParamsCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExportListParamsCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExportListParamsCategory>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExportListParamsCategory>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExportListParamsCreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExportListParamsCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
        Assert.Equal(expectedOnOrAfter, model.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, model.OnOrBefore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExportListParamsCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExportListParamsCreatedAt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExportListParamsCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExportListParamsCreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
        Assert.Equal(expectedOnOrAfter, deserialized.OnOrAfter);
        Assert.Equal(expectedOnOrBefore, deserialized.OnOrBefore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExportListParamsCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExportListParamsCreatedAt { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExportListParamsCreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExportListParamsCreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
        Assert.Null(model.OnOrAfter);
        Assert.False(model.RawData.ContainsKey("on_or_after"));
        Assert.Null(model.OnOrBefore);
        Assert.False(model.RawData.ContainsKey("on_or_before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExportListParamsCreatedAt
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            OnOrAfter = null,
            OnOrBefore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExportListParamsCreatedAt
        {
            After = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Before = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ExportListParamsCreatedAt copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class Form1099IntTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        string expectedAccountID = "account_id";

        Assert.Equal(expectedAccountID, model.AccountID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Form1099Int>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Form1099Int>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Form1099Int { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Form1099Int { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Form1099Int
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Form1099Int
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Form1099Int { AccountID = "account_id" };

        Form1099Int copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class Form1099MiscTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Form1099Misc { AccountID = "account_id" };

        string expectedAccountID = "account_id";

        Assert.Equal(expectedAccountID, model.AccountID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Form1099Misc { AccountID = "account_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Form1099Misc>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Form1099Misc { AccountID = "account_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Form1099Misc>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Form1099Misc { AccountID = "account_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Form1099Misc { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Form1099Misc { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Form1099Misc
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
        };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Form1099Misc
        {
            // Null should be interpreted as omitted for these properties
            AccountID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Form1099Misc { AccountID = "account_id" };

        Form1099Misc copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Status { In = [In.Pending] };

        List<ApiEnum<string, In>> expectedIn = [In.Pending];

        Assert.NotNull(model.In);
        Assert.Equal(expectedIn.Count, model.In.Count);
        for (int i = 0; i < expectedIn.Count; i++)
        {
            Assert.Equal(expectedIn[i], model.In[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Status { In = [In.Pending] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Status { In = [In.Pending] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Status>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ApiEnum<string, In>> expectedIn = [In.Pending];

        Assert.NotNull(deserialized.In);
        Assert.Equal(expectedIn.Count, deserialized.In.Count);
        for (int i = 0; i < expectedIn.Count; i++)
        {
            Assert.Equal(expectedIn[i], deserialized.In[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Status { In = [In.Pending] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Status { };

        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Status { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Status
        {
            // Null should be interpreted as omitted for these properties
            In = null,
        };

        Assert.Null(model.In);
        Assert.False(model.RawData.ContainsKey("in"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Status
        {
            // Null should be interpreted as omitted for these properties
            In = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Status { In = [In.Pending] };

        Status copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InTest : TestBase
{
    [Theory]
    [InlineData(In.Pending)]
    [InlineData(In.Complete)]
    [InlineData(In.Failed)]
    public void Validation_Works(In rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, In> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(In.Pending)]
    [InlineData(In.Complete)]
    [InlineData(In.Failed)]
    public void SerializationRoundtrip_Works(In rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, In> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, In>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
