using System.Threading.Tasks;
using Increase.Api.Models.Simulations.PhysicalCards;

namespace Increase.Api.Tests.Services.Simulations;

public class PhysicalCardServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var physicalCard = await this.client.Simulations.PhysicalCards.Create(
            "physical_card_ode8duyq5v2ynhjoharl",
            new() { Category = Category.Delivered },
            TestContext.Current.CancellationToken
        );
        physicalCard.Validate();
    }

    [Fact]
    public async Task AdvanceShipment_Works()
    {
        var physicalCard = await this.client.Simulations.PhysicalCards.AdvanceShipment(
            "physical_card_ode8duyq5v2ynhjoharl",
            new() { ShipmentStatus = ShipmentStatus.Shipped },
            TestContext.Current.CancellationToken
        );
        physicalCard.Validate();
    }
}
