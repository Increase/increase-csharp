using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class PhysicalCardProfileServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var physicalCardProfile = await this.client.PhysicalCardProfiles.Create(
            new()
            {
                CarrierImageFileID = "file_h6v7mtipe119os47ehlu",
                ContactPhone = "+16505046304",
                Description = "My Card Profile",
                FrontImageFileID = "file_o6aex13wm1jcc36sgcj1",
                ProgramID = "program_i2v2os4mwza1oetokh9i",
            },
            TestContext.Current.CancellationToken
        );
        physicalCardProfile.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var physicalCardProfile = await this.client.PhysicalCardProfiles.Retrieve(
            "physical_card_profile_m534d5rn9qyy9ufqxoec",
            new(),
            TestContext.Current.CancellationToken
        );
        physicalCardProfile.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.PhysicalCardProfiles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var physicalCardProfile = await this.client.PhysicalCardProfiles.Archive(
            "physical_card_profile_m534d5rn9qyy9ufqxoec",
            new(),
            TestContext.Current.CancellationToken
        );
        physicalCardProfile.Validate();
    }

    [Fact]
    public async Task Clone_Works()
    {
        var physicalCardProfile = await this.client.PhysicalCardProfiles.Clone(
            "physical_card_profile_m534d5rn9qyy9ufqxoec",
            new(),
            TestContext.Current.CancellationToken
        );
        physicalCardProfile.Validate();
    }
}
