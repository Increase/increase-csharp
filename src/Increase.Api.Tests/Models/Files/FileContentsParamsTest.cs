using System;
using Increase.Api.Models.Files;

namespace Increase.Api.Tests.Models.Files;

public class FileContentsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileContentsParams { FileID = "file_makxrc67oh9l6sg7w9yc" };

        string expectedFileID = "file_makxrc67oh9l6sg7w9yc";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        FileContentsParams parameters = new() { FileID = "file_makxrc67oh9l6sg7w9yc" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.increase.com/files/file_makxrc67oh9l6sg7w9yc/contents"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileContentsParams { FileID = "file_makxrc67oh9l6sg7w9yc" };

        FileContentsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
