using System;
using Increase.Api;

namespace Increase.Api.Tests;

public class TestBase
{
    protected IIncreaseClient client;

    public TestBase()
    {
        client = new IncreaseClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
