using System.Text;
using System.Threading.Tasks;
using Increase.Api.Models.Files;

namespace Increase.Api.Tests.Services;

public class FileServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var file = await this.client.Files.Create(
            new()
            {
                File = Encoding.UTF8.GetBytes("Example data"),
                Purpose = Purpose.CheckImageFront,
            },
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var file = await this.client.Files.Retrieve(
            "file_makxrc67oh9l6sg7w9yc",
            new(),
            TestContext.Current.CancellationToken
        );
        file.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Files.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
