using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class BookkeepingEntrySetServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var bookkeepingEntrySet = await this.client.BookkeepingEntrySets.Create(
            new()
            {
                Entries =
                [
                    new() { AccountID = "bookkeeping_account_9husfpw68pzmve9dvvc7", Amount = 100 },
                    new() { AccountID = "bookkeeping_account_t2obldz1rcu15zr54umg", Amount = -100 },
                ],
            },
            TestContext.Current.CancellationToken
        );
        bookkeepingEntrySet.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var bookkeepingEntrySet = await this.client.BookkeepingEntrySets.Retrieve(
            "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
            new(),
            TestContext.Current.CancellationToken
        );
        bookkeepingEntrySet.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.BookkeepingEntrySets.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
