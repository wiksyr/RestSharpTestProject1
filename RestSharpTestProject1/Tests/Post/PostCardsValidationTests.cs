using RestSharp;
using RestSharpTestProject1.Arguments.Holders;
using RestSharpTestProject1.Arguments.Providers;
using RestSharpTestProject1.Consts;
using RestSharpTestProject1.Extensions;

namespace RestSharpTestProject1.Tests.Post;

public class PostCardsValidationTests : BaseTest
{
    [Test]
    [TestCaseSource(typeof(PostCardsValidationArgumentsProvider))]
    public void PostCardsValidationTest(CardValidationArgumentsHolder args)
    {
        var cardName = "Test Card " + DateTime.Now.Ticks;
        var request = GetRestRequestWithAuthorization(CardsEndpoints.PostCards);
        request.AddOrUpdateFromDtos(args.Params);

        var response = _client.Execute(request, Method.Post); 
        var responseContent = response.Content;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(args.StatusCode), $"Expected status code: {args.StatusCode}, but got: {response.StatusCode}. Response content: {responseContent}");
            Assert.That(responseContent, Does.Contain(args.Message), $"Expected message: {args.Message}, but got: {responseContent}");
        };
    }
}
