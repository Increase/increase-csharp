using System.Threading.Tasks;
using Increase.Api.Models.PhysicalCards;

namespace Increase.Api.Tests.Services;

public class PhysicalCardServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var physicalCard = await this.client.PhysicalCards.Create(
            new()
            {
                CardID = "card_oubs0hwk5rn6knuecxg2",
                Cardholder = new() { FirstName = "Ian", LastName = "Crease" },
                Shipment = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Line1 = "33 Liberty Street",
                        Name = "Ian Crease",
                        PostalCode = "10045",
                        State = "NY",
                        Country = "x",
                        Line2 = "Unit 2",
                        Line3 = "x",
                        PhoneNumber = "x",
                    },
                    Method = Method.Usps,
                    Schedule = Schedule.NextDay,
                },
            },
            TestContext.Current.CancellationToken
        );
        physicalCard.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var physicalCard = await this.client.PhysicalCards.Retrieve(
            "physical_card_ode8duyq5v2ynhjoharl",
            new(),
            TestContext.Current.CancellationToken
        );
        physicalCard.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var physicalCard = await this.client.PhysicalCards.Update(
            "physical_card_ode8duyq5v2ynhjoharl",
            new() { Status = Status.Disabled },
            TestContext.Current.CancellationToken
        );
        physicalCard.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.PhysicalCards.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
