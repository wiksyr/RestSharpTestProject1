using RestSharp;
using RestSharpTestProject1.Arguments.Holders;
using RestSharpTestProject1.Dtos;
using System.Collections;

namespace RestSharpTestProject1.Arguments.Providers;

public class PutCardValidationArgumentsProvider : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[]
        {
            new CardValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "id", Value = "invalid_id", Type = ParameterType.UrlSegment },
                },
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Message = "invalid id"
            }
        };
        yield return new object[]
        {
            new CardValidationArgumentsHolder
            {
                Params = new List<ParameterDto>
                {
                    new ParameterDto { Name = "id", Value = "6a8c73244a9a844697f31821", Type = ParameterType.UrlSegment }
                },
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Message = "not found"
            }
        };
    }
}
