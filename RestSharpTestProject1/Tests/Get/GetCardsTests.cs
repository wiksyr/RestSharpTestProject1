using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using RestSharpTestProject1.Consts;
using System.Net;

namespace RestSharpTestProject1.Tests.Get;

public class GetCardsTests : BaseTest
{
    [Test]
    public void GetTrelloApiPage()
    {
        var request = new RestRequest();

        var response = _client.Get(request); 

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public void GetTrelloCardsInAList()
    {
        var request = GetRestRequestWithAuthorization(CardsEndpoints.GetCardsInList)
            .AddUrlSegment("id", UrlParams.ExistingListId);

        var response = _client.Get(request);
        var responseContent = JToken.Parse(response.Content);
        var jsonSchema = JSchema.Parse(File.ReadAllText("Resources/Schemas/get_cards.json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responseContent.IsValid(jsonSchema), Is.True);
    }

    [Test]
    public void GetTrelloCard()
    {
        var request = GetRestRequestWithAuthorization(CardsEndpoints.GetCardById)
            .AddUrlSegment("id", UrlParams.ExisitngCardId);

        var response = _client.Get(request);
        var responseContent = JToken.Parse(response.Content);
        var jsonSchema = JSchema.Parse(File.ReadAllText("Resources/Schemas/get_card.json"));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent.SelectToken("desc")?.ToString(), Does.Contain("Quickly add to-dos from email,"));
            Assert.That(responseContent.IsValid(jsonSchema), Is.True);
        }
    }
}
