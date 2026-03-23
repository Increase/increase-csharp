using System;
using Increase.Api.Models.Files;

namespace Increase.Api.Tests.Models.Files;

public class FileRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileRetrieveParams { FileID = "file_makxrc67oh9l6sg7w9yc" };

        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        FileRetrieveParams parameters = new() { FileID = "file_makxrc67oh9l6sg7w9yc" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.increase.com/files/file_makxrc67oh9l6sg7w9yc"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileRetrieveParams { FileID = "file_makxrc67oh9l6sg7w9yc" };

        FileRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
