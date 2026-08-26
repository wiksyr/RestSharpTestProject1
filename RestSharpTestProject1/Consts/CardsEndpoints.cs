using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpTestProject1.Consts;

public class CardsEndpoints
{
    public const string GetCardById = "/1/cards/{id}";
    public const string GetCardsInList = "/1/lists/{id}/cards";
    public const string PostCards = "/1/cards";
    public const string DeleteCardById = "/1/cards/{id}";
}
