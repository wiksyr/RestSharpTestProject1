using RestSharp;
using RestSharpTestProject1.Arguments.Holders;
using RestSharpTestProject1.Consts;
using RestSharpTestProject1.Dtos;
using System.Collections;

namespace RestSharpTestProject1.Arguments.Providers;

public class PostCardsValidationArgumentsProvider : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            new CardValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "idList", Value = UrlParams.ExistingListId + "1", Type = ParameterType.QueryString },
                    new ParameterDto { Name = "name", Value = "", Type = ParameterType.QueryString }
                },
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Message = "invalid value for idList"
            }
        };

        yield return new object[]
        {
            new CardValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "idList", Value = UrlParams.ExistingListId.Replace("3","1"), Type = ParameterType.QueryString },
                    new ParameterDto { Name = "name", Value = "", Type = ParameterType.QueryString }
                },
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "could not find"
            }
        };
    }
}
