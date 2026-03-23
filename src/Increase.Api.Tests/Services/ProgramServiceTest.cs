using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class ProgramServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var program = await this.client.Programs.Retrieve(
            "program_i2v2os4mwza1oetokh9i",
            new(),
            TestContext.Current.CancellationToken
        );
        program.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Programs.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
