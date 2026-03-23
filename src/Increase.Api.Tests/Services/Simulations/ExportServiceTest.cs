using System.Threading.Tasks;
using Increase.Api.Models.Simulations.Exports;

namespace Increase.Api.Tests.Services.Simulations;

public class ExportServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var export = await this.client.Simulations.Exports.Create(
            new() { Category = Category.Form1099Int },
            TestContext.Current.CancellationToken
        );
        export.Validate();
    }
}
