using System.Threading.Tasks;

namespace Increase.Api.Tests.Services;

public class DigitalCardProfileServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var digitalCardProfile = await this.client.DigitalCardProfiles.Create(
            new()
            {
                AppIconFileID = "file_8zxqkwlh43wo144u8yec",
                BackgroundImageFileID = "file_1ai913suu1zfn1pdetru",
                CardDescription = "MyBank Signature Card",
                Description = "My Card Profile",
                IssuerName = "MyBank",
            },
            TestContext.Current.CancellationToken
        );
        digitalCardProfile.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var digitalCardProfile = await this.client.DigitalCardProfiles.Retrieve(
            "digital_card_profile_s3puplu90f04xhcwkiga",
            new(),
            TestContext.Current.CancellationToken
        );
        digitalCardProfile.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.DigitalCardProfiles.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var digitalCardProfile = await this.client.DigitalCardProfiles.Archive(
            "digital_card_profile_s3puplu90f04xhcwkiga",
            new(),
            TestContext.Current.CancellationToken
        );
        digitalCardProfile.Validate();
    }

    [Fact]
    public async Task Clone_Works()
    {
        var digitalCardProfile = await this.client.DigitalCardProfiles.Clone(
            "digital_card_profile_s3puplu90f04xhcwkiga",
            new(),
            TestContext.Current.CancellationToken
        );
        digitalCardProfile.Validate();
    }
}
