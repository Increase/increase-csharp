using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class BookkeepingEntryServiceTest : TestBase
{
    [Fact]
    public async Task Retrieve_Works()
    {
        var bookkeepingEntry = await this.client.BookkeepingEntries.Retrieve(
            "bookkeeping_entry_ctjpajsj3ks2blx10375",
            new(),
            TestContext.Current.CancellationToken
        );
        bookkeepingEntry.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.BookkeepingEntries.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
