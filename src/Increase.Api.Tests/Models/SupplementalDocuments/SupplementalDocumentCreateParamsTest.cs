using System;
using Increase.Api.Models.SupplementalDocuments;

namespace Increase.Api.Tests.Models.SupplementalDocuments;

public class SupplementalDocumentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SupplementalDocumentCreateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FileID = "file_makxrc67oh9l6sg7w9yc",
        };

        string expectedEntityID = "entity_n8y8tnk2p9339ti393yi";
        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";

        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        SupplementalDocumentCreateParams parameters = new()
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FileID = "file_makxrc67oh9l6sg7w9yc",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/entity_supplemental_documents"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SupplementalDocumentCreateParams
        {
            EntityID = "entity_n8y8tnk2p9339ti393yi",
            FileID = "file_makxrc67oh9l6sg7w9yc",
        };

        SupplementalDocumentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
