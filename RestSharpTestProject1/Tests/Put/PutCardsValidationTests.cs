using RestSharp;
using RestSharpTestProject1.Arguments.Holders;
using RestSharpTestProject1.Arguments.Providers;
using RestSharpTestProject1.Consts;
using RestSharpTestProject1.Extensions;
using System.Net;

namespace RestSharpTestProject1.Tests.Put;

public class PutCardsValidationTests : BaseTest
{
    [Test]
    [TestCaseSource(typeof(CardIdValidationArgumentsProvider))]
    public void PutCardsValidationTest(CardValidationArgumentsHolder args)
    {
        var updatedCardName = "Updated Card Name " + DateTime.Now.Ticks;
        var request = GetRestRequestWithAuthorization(CardsEndpoints.PutCardById)
            .AddParameter("name", updatedCardName, ParameterType.QueryString);
        request.AddOrUpdateFromDtos(args.Params);

        var response = _client.Execute(request, Method.Put);
        var responseContent = response.Content; 

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(args.StatusCode), "Status code mismatch");
            Assert.That(responseContent, Does.Contain(args.Message), "Error message mismatch");
        });
    }

    [Test]
    [TestCaseSource(typeof(AuthValidationArgumentsProvider))]
    public void PutCardsValidationAuthTest(AuthValidationArgumentsHolder args)
    {
        var updatedCardName = "Updated Card Name " + DateTime.Now.Ticks;
        var request = GetRestRequestWithoutAuthorization(CardsEndpoints.PutCardById)
            .AddUrlSegment("id", UrlParams.CardIdToUpdate)
            .AddParameter("name", updatedCardName, ParameterType.QueryString);
        request.AddOrUpdateFromDtos(args.Params);

        var response = _client.Execute(request, Method.Put);
        var responseContent = response.Content;

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Status code mismatch");
            Assert.That(responseContent, Does.Contain(args.Message), "Error message mismatch");
        });
    }

}
