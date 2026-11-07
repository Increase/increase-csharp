using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class CheckbookCheckServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var checkbookCheck = await this.client.CheckbookChecks.Retrieve(
            "checkbook_check_klgh3z50guf6jcnfhibb",
            new(),
            TestContext.Current.CancellationToken
        );
        checkbookCheck.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.CheckbookChecks.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Stop_Works()
    {
        var checkbookCheck = await this.client.CheckbookChecks.Stop(
            "checkbook_check_klgh3z50guf6jcnfhibb",
            new(),
            TestContext.Current.CancellationToken
        );
        checkbookCheck.Validate();
    }
}
