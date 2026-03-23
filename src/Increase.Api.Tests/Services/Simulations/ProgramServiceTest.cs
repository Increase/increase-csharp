using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class ProgramServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var program = await this.client.Simulations.Programs.Create(
            new() { Name = "For Benefit Of" },
            TestContext.Current.CancellationToken
        );
        program.Validate();
    }
}
