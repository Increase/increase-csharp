using System.Threading.Tasks;
using Increase.Api.Models.Exports;

namespace Increase.Api.Tests.Services;

public class ExportServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var export = await this.client.Exports.Create(
            new() { Category = Category.TransactionCsv },
            TestContext.Current.CancellationToken
        );
        export.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var export = await this.client.Exports.Retrieve(
            "export_8s4m48qz3bclzje0zwh9",
            new(),
            TestContext.Current.CancellationToken
        );
        export.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Exports.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }
}
