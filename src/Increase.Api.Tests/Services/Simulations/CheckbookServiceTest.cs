using System.Threading.Tasks;

namespace Increase.Api.Tests.Services.Simulations;

public class CheckbookServiceTest : TestBase
{
    [Fact]
    public async Task Mail_Works()
    {
        var checkbook = await this.client.Simulations.Checkbooks.Mail(
            "checkbook_7iudxhxum6vlkcjxmi8y",
            new(),
            TestContext.Current.CancellationToken
        );
        checkbook.Validate();
    }
}
