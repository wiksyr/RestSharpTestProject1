using RestSharp;
using System.Net;
using System.Collections.Generic;
using RestSharpTestProject1.Dtos;

namespace RestSharpTestProject1.Arguments.Holders;

public class CardValidationArgumentsHolder
{
    public IEnumerable<ParameterDto> Params { get; set; } = new List<ParameterDto>();
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}
