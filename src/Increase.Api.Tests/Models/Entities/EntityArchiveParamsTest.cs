using System;
using Increase.Api.Models.Entities;

namespace Increase.Api.Tests.Models.Entities;

public class EntityArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityArchiveParams { EntityID = "entity_n8y8tnk2p9339ti393yi" };

        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";

        Assert.Equal(expectedEntityID, parameters.EntityID);
    }

    [Fact]
    public void Url_Works()
    {
        EntityArchiveParams parameters = new() { EntityID = "entity_n8y8tnk2p9339ti393yi" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/entities/entity_n8y8tnk2p9339ti393yi/archive"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityArchiveParams { EntityID = "entity_n8y8tnk2p9339ti393yi" };

        EntityArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
