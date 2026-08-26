using System.Linq;
using RestSharp;
using RestSharpTestProject1.Dtos;

namespace RestSharpTestProject1.Extensions;

public static class RestRequestExtensions
{
    /// <summary>
    /// Add or update parameters on a RestRequest based on ParameterDto collection.
    /// Supports QueryString, UrlSegment, Header, Cookie and falls back to AddParameter for others.
    /// </summary>
public static void AddOrUpdateFromDtos(this RestRequest request, IEnumerable<ParameterDto>? parameters)
    {
        if (parameters == null) return;

        foreach (var p in parameters)
        {
            // Note: we intentionally don't try to instantiate RestSharp.Parameter (abstract).
            // Instead add appropriate parameter using RestRequest helpers. This may produce duplicates
            // if the same name already exists; RestSharp's internal behavior will apply.

            switch (p.Type)
            {
                case ParameterType.QueryString:
                    request.AddQueryParameter(p.Name, p.Value);
                    break;

                case ParameterType.UrlSegment:
                    request.AddUrlSegment(p.Name, p.Value);
                    break;

                case ParameterType.HttpHeader:
                    request.AddHeader(p.Name, p.Value);
                    break;

                default:
                    // fallback to AddParameter for other types
                    request.AddParameter(p.Name, p.Value, p.Type);
                    break;
            }
        }
    }
}
