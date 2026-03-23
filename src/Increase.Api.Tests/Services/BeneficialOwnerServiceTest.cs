using System.Threading.Tasks;
using Increase.Api.Models.BeneficialOwners;

namespace Increase.Api.Tests.Services;

public class BeneficialOwnerServiceTest : TestBase
{
    [Fact]
    public async Task Create_Works()
    {
        var entityBeneficialOwner = await this.client.BeneficialOwners.Create(
            new()
            {
                EntityID = "entity_n8y8tnk2p9339ti393yi",
                Individual = new()
                {
                    Address = new()
                    {
                        City = "New York",
                        Country = "US",
                        Line1 = "33 Liberty Street",
                        Line2 = "x",
                        State = "NY",
                        Zip = "10045",
                    },
                    DateOfBirth = "1970-01-31",
                    Identification = new()
                    {
                        Method = Method.SocialSecurityNumber,
                        Number = "078051120",
                        DriversLicense = new()
                        {
                            ExpirationDate = "2019-12-27",
                            FileID = "file_id",
                            State = "x",
                            BackFileID = "back_file_id",
                        },
                        Other = new()
                        {
                            Country = "x",
                            Description = "x",
                            FileID = "file_id",
                            BackFileID = "back_file_id",
                            ExpirationDate = "2019-12-27",
                        },
                        Passport = new()
                        {
                            Country = "x",
                            ExpirationDate = "2019-12-27",
                            FileID = "file_id",
                        },
                    },
                    Name = "Ian Crease",
                    ConfirmedNoUsTaxID = true,
                },
                Prongs = [Prong.Control],
            },
            TestContext.Current.CancellationToken
        );
        entityBeneficialOwner.Validate();
    }

    [Fact]
    public async Task Retrieve_Works()
    {
        var entityBeneficialOwner = await this.client.BeneficialOwners.Retrieve(
            "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            new(),
            TestContext.Current.CancellationToken
        );
        entityBeneficialOwner.Validate();
    }

    [Fact]
    public async Task Update_Works()
    {
        var entityBeneficialOwner = await this.client.BeneficialOwners.Update(
            "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            new(),
            TestContext.Current.CancellationToken
        );
        entityBeneficialOwner.Validate();
    }

    [Fact]
    public async Task List_Works()
    {
        var page = await this.client.BeneficialOwners.List(
            new() { EntityID = "entity_id" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact]
    public async Task Archive_Works()
    {
        var entityBeneficialOwner = await this.client.BeneficialOwners.Archive(
            "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
            new(),
            TestContext.Current.CancellationToken
        );
        entityBeneficialOwner.Validate();
    }
}
