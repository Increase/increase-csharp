using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class PhysicalCheckBatchServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var physicalCheckBatch = await this.client.PhysicalCheckBatches.Create(
            new()
            {
                MailingAddress = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Name = "Ian Crease",
                    PostalCode = "10045",
                    State = "NY",
                    Line2 = "line2",
                    Phone = "x",
                },
                ReturnAddress = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    Name = "National Phonograph Company",
                    PostalCode = "10045",
                    State = "NY",
                    Line2 = "line2",
                    Phone = "x",
                },
            },
            TestContext.Current.CancellationToken
        );
        physicalCheckBatch.Validate();
    }

    [Fact]
    public async Task Cancel_Works()
    {
        var physicalCheckBatch = await this.client.PhysicalCheckBatches.Cancel(
            "physical_check_batch_yzdwjhdbw0in6191whce",
            new(),
            TestContext.Current.CancellationToken
        );
        physicalCheckBatch.Validate();
    }

    [Fact]
    public async Task Complete_Works()
    {
        var physicalCheckBatch = await this.client.PhysicalCheckBatches.Complete(
            "physical_check_batch_yzdwjhdbw0in6191whce",
            new(),
            TestContext.Current.CancellationToken
        );
        physicalCheckBatch.Validate();
    }
}
