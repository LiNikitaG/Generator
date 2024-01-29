using GeneratorLib.Models;

namespace GeneratorLib.CustomFilters.Filters;

public class PriceFilter
{
    public static void Price(TemplateLine templateLine, dynamic data)
    {
        templateLine.ResultValue = templateLine.Value.Replace(templateLine.MatchValue, "$" + templateLine.MatchValue);
    }
}