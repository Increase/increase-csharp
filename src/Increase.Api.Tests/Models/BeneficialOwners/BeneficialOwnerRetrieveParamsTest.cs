using System;
using Increase.Api.Models.BeneficialOwners;

namespace Increase.Api.Tests.Models.BeneficialOwners;

public class BeneficialOwnerRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BeneficialOwnerRetrieveParams
        {
            EntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
        };

        string expectedEntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6";

        Assert.Equal(expectedEntityBeneficialOwnerID, parameters.EntityBeneficialOwnerID);
    }

    [Fact]
    public void Url_Works()
    {
        BeneficialOwnerRetrieveParams parameters = new()
        {
            EntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/entity_beneficial_owners/entity_beneficial_owner_vozma8szzu1sxezp5zq6"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BeneficialOwnerRetrieveParams
        {
            EntityBeneficialOwnerID = "entity_beneficial_owner_vozma8szzu1sxezp5zq6",
        };

        BeneficialOwnerRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
