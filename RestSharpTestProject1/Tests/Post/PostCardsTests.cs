using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpTestProject1.Consts;

namespace RestSharpTestProject1.Tests.Post;

public class PostCardsTests : BaseTest
{
    private string? _createdCardId;

    [Test]
    public void CheckPostCards()
    {
        var cardName = "Test Card " + DateTime.Now.Ticks;
        var request = GetRestRequestWithAuthorization(CardsEndpoints.PostCards)
            .AddQueryParameter("idList", UrlParams.ExistingListId)
            .AddQueryParameter("name", cardName); 

        var response = _client.Post(request);
        var responseContent = JToken.Parse(response.Content!);
        _createdCardId = responseContent["id"]?.ToString() ?? throw new Exception("Card ID not found in response");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), "Status code is not OK");
            Assert.That(responseContent["name"]?.ToString(), Is.EqualTo(cardName), "Card name in response does not match the requested name");
            Assert.That(responseContent["idList"]?.ToString(), Is.EqualTo(UrlParams.ExistingListId), "List ID in response does not match the requested list ID");
        });

        request = GetRestRequestWithAuthorization(CardsEndpoints.GetCardsInList)
            .AddUrlSegment("id", UrlParams.ExistingListId);
        response = _client.Get(request); 
        responseContent = JToken.Parse(response.Content!);

        Assert.That(responseContent.Children().Any(card => card["name"]?.ToString() == cardName), Is.True, "The new card was not found in the list of cards for the specified list ID");
    }

    [TearDown]
    public void TearDown()
    {
        var request = GetRestRequestWithAuthorization(CardsEndpoints.DeleteCardById)
            .AddUrlSegment("id", _createdCardId);
        var response = _client.Delete(request);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), "Failed to delete the card in TearDown");
    }
}
