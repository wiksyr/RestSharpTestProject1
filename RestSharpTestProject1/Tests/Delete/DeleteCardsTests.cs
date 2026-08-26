using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpTestProject1.Consts;

namespace RestSharpTestProject1.Tests.Delete;

public class DeleteCardsTests : BaseTest
{
    private string? _cardIdToDelete;

    [SetUp]
    public void Setup()
    {
        var request = GetRestRequestWithAuthorization(CardsEndpoints.PostCards)
            .AddParameter("name", "Card to Delete " + DateTime.Now.Ticks, ParameterType.QueryString)
            .AddParameter("idList", UrlParams.ExistingListId, ParameterType.QueryString);

        var response = _client.Post(request);
        var responseContent = JToken.Parse(response.Content!);

        _cardIdToDelete = responseContent["id"]?.ToString();
    }

    [Test]
    public void DeleteCardsTest()
    {
        var request = GetRestRequestWithAuthorization(CardsEndpoints.DeleteCardById)
            .AddUrlSegment("id", _cardIdToDelete);
        
        var response = _client.Delete(request);
        var responseContent = JToken.Parse(response.Content!);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), "Status code is not OK");
            Assert.That(responseContent.SelectToken("_value")?.ToString(), Is.EqualTo(null), "Response content is not empty JSON object");
        }

        request = GetRestRequestWithAuthorization(CardsEndpoints.GetCardsInList)
            .AddUrlSegment("id", UrlParams.ExistingListId);
        responseContent = JToken.Parse(response.Content!) ;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), "Status code is not OK");
            Assert.That(responseContent.Children().Select(child => child.SelectToken("id")).Contains(_cardIdToDelete), Is.False, "Deleted card is still present in the list");
        }
    }
}
