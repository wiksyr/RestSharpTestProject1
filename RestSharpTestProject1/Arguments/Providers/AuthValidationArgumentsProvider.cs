using RestSharp;
using RestSharpTestProject1.Arguments.Holders;
using RestSharpTestProject1.Consts;
using RestSharpTestProject1.Dtos;
using System.Collections;

namespace RestSharpTestProject1.Arguments.Providers;

public class AuthValidationArgumentsProvider : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[]         {
            new AuthValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "key", Value = UrlParams.InvalidKey, Type = ParameterType.QueryString },
                    new ParameterDto { Name = "token", Value = UrlParams.ValidToken, Type = ParameterType.QueryString }
                },
                Message = "invalid key"
            }
        };

        yield return new object[]         {
            new AuthValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "key", Value = UrlParams.ValidKey, Type = ParameterType.QueryString },
                    new ParameterDto { Name = "token", Value = UrlParams.InvalidToken, Type = ParameterType.QueryString }
                },
                Message = "invalid app token"
            }
        };

        yield return new object[]         {
            new AuthValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                },
                Message = "missing scopes"
            }
        };
    }
}
