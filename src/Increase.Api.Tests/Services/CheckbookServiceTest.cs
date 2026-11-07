using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class CheckbookServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var checkbook = await this.client.Checkbooks.Create(
            new()
            {
                AccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
                MailingAddress = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                    Line2 = "line2",
                },
                Payer =
                [
                    new("National Phonograph Company"),
                    new("33 Liberty Street"),
                    new("New York, NY 10045"),
                ],
            },
            TestContext.Current.CancellationToken
        );
        checkbook.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var checkbook = await this.client.Checkbooks.Retrieve(
            "checkbook_7iudxhxum6vlkcjxmi8y",
            new(),
            TestContext.Current.CancellationToken
        );
        checkbook.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.Checkbooks.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact]
    public async Task Stop_Works()
    {
        var checkbook = await this.client.Checkbooks.Stop(
            "checkbook_7iudxhxum6vlkcjxmi8y",
            new(),
            TestContext.Current.CancellationToken
        );
        checkbook.Validate();
    }
}
