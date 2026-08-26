using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpTestProject1.Consts;

namespace RestSharpTestProject1.Tests.Put;

public class PutCardsTests : BaseTest
{
    [Test]
    public void CheckPutCard()
    {
        var updatedCardName = "Updated Card Name " + DateTime.Now.Ticks; 
        var request = GetRestRequestWithAuthorization(CardsEndpoints.PutCardById)
            .AddUrlSegment("id", UrlParams.CardIdToUpdate)
            .AddParameter("name", updatedCardName, ParameterType.QueryString);

        var response = _client.Put(request);
        var responseContent = JToken.Parse(response.Content!);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(responseContent.SelectToken("name")?.ToString(), Is.EqualTo(updatedCardName));
        }

        request = GetRestRequestWithAuthorization(CardsEndpoints.GetCardById)
            .AddUrlSegment("id", UrlParams.CardIdToUpdate);

        response = _client.Get(request);
        responseContent = JToken.Parse(response.Content!);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(responseContent.SelectToken("name")?.ToString(), Is.EqualTo(updatedCardName));
        }
    }
}
