using System;
using Increase.Api.Models.SupplementalDocuments;

namespace Increase.Api.Tests.Models.SupplementalDocuments;

public class SupplementalDocumentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SupplementalDocumentListParams
        {
            EntityID = "entity_id",
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
        };

        string expectedEntityID = "entity_id";
        string expectedCursor = "cursor";
        string expectedIdempotencyKey = "x";
        long expectedLimit = 1;

        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SupplementalDocumentListParams { EntityID = "entity_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SupplementalDocumentListParams
        {
            EntityID = "entity_id",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            IdempotencyKey = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        SupplementalDocumentListParams parameters = new()
        {
            EntityID = "entity_id",
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/entity_supplemental_documents?entity_id=entity_id&cursor=cursor&idempotency_key=x&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SupplementalDocumentListParams
        {
            EntityID = "entity_id",
            Cursor = "cursor",
            IdempotencyKey = "x",
            Limit = 1,
        };

        SupplementalDocumentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
