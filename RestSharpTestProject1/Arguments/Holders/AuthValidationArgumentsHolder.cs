using RestSharpTestProject1.Dtos;

namespace RestSharpTestProject1.Arguments.Holders;

public class AuthValidationArgumentsHolder
{
    public IEnumerable<ParameterDto> Params { get; set; } = new List<ParameterDto>();
    public string Message { get; set; } = string.Empty;
}
