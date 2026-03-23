using System;
using Increase.Api.Models.Exports;

namespace Increase.Api.Tests.Models.Exports;

public class ExportRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExportRetrieveParams { ExportID = "export_8s4m48qz3bclzje0zwh9" };

        string expectedExportID = "export_8s4m48qz3bclzje0zwh9";

        Assert.Equal(expectedExportID, parameters.ExportID);
    }

    [Fact]
    public void Url_Works()
    {
        ExportRetrieveParams parameters = new() { ExportID = "export_8s4m48qz3bclzje0zwh9" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/exports/export_8s4m48qz3bclzje0zwh9"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExportRetrieveParams { ExportID = "export_8s4m48qz3bclzje0zwh9" };

        ExportRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
