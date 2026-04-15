using System;
using Increase.Api.Models.IntrafiExclusions;

namespace Increase.Api.Tests.Models.IntrafiExclusions;

public class IntrafiExclusionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrafiExclusionListParams
        {
            Cursor = "cursor",
            EntityID = "entity_id",
            IdempotencyKey = "x",
            Limit = 1,
        };

        string expectedCursor = "cursor";
        string expectedEntityID = "entity_id";
        string expectedIdempotencyKey = "x";
        long expectedLimit = 1;

        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntrafiExclusionListParams { };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawQueryData.ContainsKey("entity_id"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IntrafiExclusionListParams
        {
            // Null should be interpreted as omitted for these properties
            Cursor = null,
            EntityID = null,
            IdempotencyKey = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawQueryData.ContainsKey("entity_id"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawQueryData.ContainsKey("idempotency_key"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        IntrafiExclusionListParams parameters = new()
        {
            Cursor = "cursor",
            EntityID = "entity_id",
            IdempotencyKey = "x",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/intrafi_exclusions?cursor=cursor&entity_id=entity_id&idempotency_key=x&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrafiExclusionListParams
        {
            Cursor = "cursor",
            EntityID = "entity_id",
            IdempotencyKey = "x",
            Limit = 1,
        };

        IntrafiExclusionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
