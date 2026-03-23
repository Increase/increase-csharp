using System.Threading.Tasks;
using Increase.Api.Models.Entities;

namespace Increase.Api.Tests.Services;

public class EntityServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var entity = await this.client.Entities.Create(
            new() { Structure = Structure.Corporation },
            TestContext.Current.CancellationToken
        );
        entity.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var entity = await this.client.Entities.Retrieve(
            "entity_n8y8tnk2p9339ti393yi",
            new(),
            TestContext.Current.CancellationToken
        );
        entity.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var entity = await this.client.Entities.Update(
            "entity_n8y8tnk2p9339ti393yi",
            new(),
            TestContext.Current.CancellationToken
        );
        entity.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Entities.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var entity = await this.client.Entities.Archive(
            "entity_n8y8tnk2p9339ti393yi",
            new(),
            TestContext.Current.CancellationToken
        );
        entity.Validate();
    }
}
