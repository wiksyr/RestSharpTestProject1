using RestSharp;
using RestSharpTestProject1.Arguments.Holders;
using RestSharpTestProject1.Consts;
using RestSharpTestProject1.Extensions;
using System.Net;

namespace RestSharpTestProject1.Tests.Get;

public class GetCardsValidationTests : BaseTest
{
    [TestCaseSource(typeof(Arguments.Providers.CardValidationArgumentsProvider))]
    public void CheckGetCardValidation(CardValidationArgumentsHolder args)
    {
        var request = GetRestRequestWithoutAuthorization(CardsEndpoints.GetCardById);
        request.AddOrUpdateFromDtos(args.Params);
        var response = _client.Execute(request);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.StatusCode, Is.EqualTo(args.StatusCode));
            Assert.That(response.Content, Does.Contain(args.Message));
        }
    }
}
