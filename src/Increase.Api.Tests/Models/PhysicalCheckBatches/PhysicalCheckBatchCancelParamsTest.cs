using System;
using Increase.Api.Models.PhysicalCheckBatches;

namespace Increase.Api.Tests.Models.PhysicalCheckBatches;

public class PhysicalCheckBatchCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhysicalCheckBatchCancelParams
        {
            PhysicalCheckBatchID = "physical_check_batch_yzdwjhdbw0in6191whce",
        };

        string expectedPhysicalCheckBatchID = "physical_check_batch_yzdwjhdbw0in6191whce";

        Assert.Equal(expectedPhysicalCheckBatchID, parameters.PhysicalCheckBatchID);
    }

    [Fact]
    public void Url_Works()
    {
        PhysicalCheckBatchCancelParams parameters = new()
        {
            PhysicalCheckBatchID = "physical_check_batch_yzdwjhdbw0in6191whce",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.increase.com/physical_check_batches/physical_check_batch_yzdwjhdbw0in6191whce/cancel"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhysicalCheckBatchCancelParams
        {
            PhysicalCheckBatchID = "physical_check_batch_yzdwjhdbw0in6191whce",
        };

        PhysicalCheckBatchCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
