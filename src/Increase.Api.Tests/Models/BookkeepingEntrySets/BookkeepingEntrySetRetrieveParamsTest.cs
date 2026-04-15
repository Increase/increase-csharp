using System;
using Increase.Api.Models.BookkeepingEntrySets;

namespace Increase.Api.Tests.Models.BookkeepingEntrySets;

public class BookkeepingEntrySetRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingEntrySetRetrieveParams
        {
            BookkeepingEntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
        };

        string expectedBookkeepingEntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf";

        Assert.Equal(expectedBookkeepingEntrySetID, parameters.BookkeepingEntrySetID);
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingEntrySetRetrieveParams parameters = new()
        {
            BookkeepingEntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/bookkeeping_entry_sets/bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingEntrySetRetrieveParams
        {
            BookkeepingEntrySetID = "bookkeeping_entry_set_n80c6wr2p8gtc6p4ingf",
        };

        BookkeepingEntrySetRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
