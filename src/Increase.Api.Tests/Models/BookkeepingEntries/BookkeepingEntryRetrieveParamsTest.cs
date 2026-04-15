using System;
using Increase.Api.Models.BookkeepingEntries;

namespace Increase.Api.Tests.Models.BookkeepingEntries;

public class BookkeepingEntryRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BookkeepingEntryRetrieveParams
        {
            BookkeepingEntryID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
        };

        string expectedBookkeepingEntryID = "bookkeeping_entry_ctjpajsj3ks2blx10375";

        Assert.Equal(expectedBookkeepingEntryID, parameters.BookkeepingEntryID);
    }

    [Fact]
    public void Url_Works()
    {
        BookkeepingEntryRetrieveParams parameters = new()
        {
            BookkeepingEntryID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/bookkeeping_entries/bookkeeping_entry_ctjpajsj3ks2blx10375"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BookkeepingEntryRetrieveParams
        {
            BookkeepingEntryID = "bookkeeping_entry_ctjpajsj3ks2blx10375",
        };

        BookkeepingEntryRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
