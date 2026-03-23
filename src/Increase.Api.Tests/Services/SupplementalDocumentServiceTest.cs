using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class SupplementalDocumentServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var entitySupplementalDocument = await this.client.SupplementalDocuments.Create(
            new()
            {
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                FileID = "file_makxrc67oh9l6sg7w9yc",
            },
            TestContext.Current.CancellationToken
        );
        entitySupplementalDocument.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.SupplementalDocuments.List(
            new() { EntityID = "entity_id" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
