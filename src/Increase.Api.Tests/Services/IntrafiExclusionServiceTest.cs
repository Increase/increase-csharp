using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class IntrafiExclusionServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var intrafiExclusion = await this.client.IntrafiExclusions.Create(
            new() { EntityID = "entity_n8y8tnk2p9339ti393yi", FdicCertificateNumber = "314159" },
            TestContext.Current.CancellationToken
        );
        intrafiExclusion.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var intrafiExclusion = await this.client.IntrafiExclusions.Retrieve(
            "account_in71c4amph0vgo2qllky",
            new(),
            TestContext.Current.CancellationToken
        );
        intrafiExclusion.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.IntrafiExclusions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var intrafiExclusion = await this.client.IntrafiExclusions.Archive(
            "intrafi_exclusion_ygfqduuzpau3jqof6jyh",
            new(),
            TestContext.Current.CancellationToken
        );
        intrafiExclusion.Validate();
    }
}
