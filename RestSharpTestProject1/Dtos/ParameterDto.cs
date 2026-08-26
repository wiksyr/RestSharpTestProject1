namespace RestSharpTestProject1.Dtos;

public class ParameterDto
{
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public RestSharp.ParameterType Type { get; set; }
}
