using RestSharp;
using RestSharpTestProject1.Dtos;

namespace RestSharpTestProject1.Consts;

public class UrlParams
{
    public const string ExisitngCardId = "6a8c73244a9a844697f31824";
    public const string ExistingListId = "6a8c73244a9a844697f317f2";

    public const string ValidKey = "5db25c32469ff85185d010c9b2736345";
    public const string ValidToken = "ATTA4af94b6e84868b13ca0a02b030c78f04d55c679edd1fe1d33a9f5f269b1f36f0DEB27D05";

    public const string InvalidKey = "invalid_key";
    public const string InvalidToken = "invalid_token";

    public const string OtherUserKey = "8b32218e6887516d17c84253faf967b6";
    public const string OtherUserToken = "492343b8106e7df3ebb7f01e219cbf32827c852a5f9e2b8f9ca296b1cc604955";

    public static readonly IEnumerable<ParameterDto> ValidAuthorizationParams = new List<ParameterDto>
    {
        new ParameterDto { Name = "key", Value = ValidKey, Type = ParameterType.QueryString },
        new ParameterDto { Name = "token", Value = ValidToken, Type = ParameterType.QueryString }
    }; 

    public static readonly IEnumerable<ParameterDto> OtherUserAuthorizationParams = new List<ParameterDto>
    {
        new ParameterDto { Name = "key", Value = "8b32218e6887516d17c84253faf967b6", Type = ParameterType.QueryString },
        new ParameterDto { Name = "token", Value = "492343b8106e7df3ebb7f01e219cbf32827c852a5f9e2b8f9ca296b1cc604955", Type = ParameterType.QueryString }
    };
}
