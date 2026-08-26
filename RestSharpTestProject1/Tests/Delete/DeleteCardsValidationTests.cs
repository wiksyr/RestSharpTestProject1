using RestSharp;
using RestSharpTestProject1.Arguments.Holders;
using RestSharpTestProject1.Arguments.Providers;
using RestSharpTestProject1.Consts;
using RestSharpTestProject1.Extensions;
using System.Net;

namespace RestSharpTestProject1.Tests.Delete;

public class DeleteCardsValidationTests : BaseTest
{
    [Test]
    [TestCaseSource(typeof(CardIdValidationArgumentsProvider))]
    public void DeleteCardsValidationTest(CardValidationArgumentsHolder args)
    {
        var request = GetRestRequestWithAuthorization(CardsEndpoints.DeleteCardById); 
        request.AddOrUpdateFromDtos(args.Params);

        var response = _client.Execute(request, Method.Delete);
        var responseContent = response.Content;

        using (Assert.EnterMultipleScope())
        {
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(args.StatusCode), $"Expected status code: {args.StatusCode}, but got: {response.StatusCode}. Response content: {responseContent}");
                Assert.That(responseContent, Does.Contain(args.Message), $"Expected message: {args.Message}, but got: {responseContent}");
            }); 
        }
    }

    [Test]
    [TestCaseSource(typeof(AuthValidationArgumentsProvider))]
    public void DeleteCardsValidationAuthTest(AuthValidationArgumentsHolder args)
    {
        var request = GetRestRequestWithoutAuthorization(CardsEndpoints.DeleteCardById)
            .AddUrlSegment("id", UrlParams.ExisitngCardId.Replace("3", "1"));
        request.AddOrUpdateFromDtos(args.Params);

        var response = _client.Execute(request, Method.Delete);
        var responseContent = response.Content;

        using (Assert.EnterMultipleScope())
        {
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), $"Expected status code: {HttpStatusCode.Unauthorized}, but got: {response.StatusCode}. Response content: {responseContent}");
                Assert.That(responseContent, Does.Contain(args.Message), $"Expected message: {args.Message}, but got: {responseContent}");
            });
        }
    }
}
