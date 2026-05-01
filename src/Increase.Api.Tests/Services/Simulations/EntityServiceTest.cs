using System.Threading.Tasks;
using Increase.Api.Models.Simulations.Entities;

namespace Increase.Api.Tests.Services.Simulations;

public class EntityServiceTest : TestBase
{
    [Fact]
    public async Task Validation_Works()
    {
        var entity = await this.client.Simulations.Entities.Validation(
            "entity_n8y8tnk2p9339ti393yi",
            new() { Issues = [new(Category.EntityTaxIdentifier)], Status = Status.Invalid },
            TestContext.Current.CancellationToken
        );
        entity.Validate();
    }
}
