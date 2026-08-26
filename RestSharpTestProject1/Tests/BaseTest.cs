using RestSharp;

namespace RestSharpTestProject1.Tests; 

public class BaseTest
{
    protected static RestClient _client;

    [OneTimeSetUp]
    public static void InitializeRestClient() => _client = new RestClient("https://api.trello.com");

    [OneTimeTearDown]
    public static void TearDownRestClient() => _client?.Dispose();

    protected RestRequest GetRestRequestWithAuthorization(string resource)
    {
        return GetRestRequestWithoutAuthorization(resource)
            .AddQueryParameter("key", "5db25c32469ff85185d010c9b2736345")
            .AddQueryParameter("token", "ATTA4af94b6e84868b13ca0a02b030c78f04d55c679edd1fe1d33a9f5f269b1f36f0DEB27D05");
    }
    protected RestRequest GetRestRequestWithoutAuthorization(string resource)
    {
        return new RestRequest(resource);
    }
}
