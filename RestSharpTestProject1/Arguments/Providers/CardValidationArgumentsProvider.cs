using RestSharp;
using RestSharpTestProject1.Arguments.Holders;
using RestSharpTestProject1.Consts;
using RestSharpTestProject1.Dtos;
using System.Collections;
using System.Net;

namespace RestSharpTestProject1.Arguments.Providers;

public class CardValidationArgumentsProvider : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            new CardValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "key", Value = UrlParams.ValidKey, Type = ParameterType.UrlSegment },
                    new ParameterDto { Name = "token", Value = UrlParams.ValidToken, Type = ParameterType.UrlSegment },
                    new ParameterDto { Name = "id", Value = "invalid_id", Type = ParameterType.UrlSegment }
                },
                StatusCode = HttpStatusCode.BadRequest,
                Message = "invalid id"
            }
        };

        yield return new object[]
        {
            new CardValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "key", Value = UrlParams.ValidKey, Type = ParameterType.UrlSegment },
                    new ParameterDto { Name = "token", Value = UrlParams.ValidToken, Type = ParameterType.UrlSegment },
                    new ParameterDto { Name = "id", Value = "6a8c73244a9a844697f31821", Type = ParameterType.UrlSegment }
                },
                StatusCode = HttpStatusCode.NotFound,
                Message = "not found"
            }
        };



        yield return new object[]
        {
            new CardValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "key", Value = UrlParams.OtherUserKey, Type = ParameterType.UrlSegment },
                    new ParameterDto { Name = "token", Value = UrlParams.OtherUserToken, Type = ParameterType.UrlSegment },
                    new ParameterDto { Name = "id", Value = UrlParams.ExisitngCardId, Type = ParameterType.UrlSegment }
                },
                StatusCode = HttpStatusCode.Unauthorized,
                Message = "unauthorized"
            }
        };

        yield return new object[]
        {
                new CardValidationArgumentsHolder
                {
                    Params = new List<ParameterDto>
                    {
                        new ParameterDto { Name = "id", Value = UrlParams.ExisitngCardId, Type = ParameterType.UrlSegment }
                    },
                    StatusCode = HttpStatusCode.Unauthorized,
                    Message = "unauthorized"
                }
        };
    }
}
