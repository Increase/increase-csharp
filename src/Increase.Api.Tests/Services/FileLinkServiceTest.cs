using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class FileLinkServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var fileLink = await this.client.FileLinks.Create(
            new() { FileID = "file_makxrc67oh9l6sg7w9yc" },
            TestContext.Current.CancellationToken
        );
        fileLink.Validate();
    }
}
