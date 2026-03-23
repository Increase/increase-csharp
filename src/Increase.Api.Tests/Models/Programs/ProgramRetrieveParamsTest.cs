using System;
using Increase.Api.Models.Programs;

namespace Increase.Api.Tests.Models.Programs;

public class ProgramRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProgramRetrieveParams { ProgramID = "program_i2v2os4mwza1oetokh9i" };

        string expectedProgramID = "program_i2v2os4mwza1oetokh9i";

        Assert.Equal(expectedProgramID, parameters.ProgramID);
    }

    [Fact]
    public void Url_Works()
    {
        ProgramRetrieveParams parameters = new() { ProgramID = "program_i2v2os4mwza1oetokh9i" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.increase.com/programs/program_i2v2os4mwza1oetokh9i"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProgramRetrieveParams { ProgramID = "program_i2v2os4mwza1oetokh9i" };

        ProgramRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
