using GeneratorLib.CustomFilters.Filters;
using GeneratorLib.Models;

namespace GeneratorLib.CustomFilters;

public static class CustomFilter
{
    private static readonly Dictionary<string, Action<TemplateLine, dynamic>> Filters = new()
    {
        {"price", PriceFilter.Price},
        {"paragraph", ParagraphFilter.Paragraph},
    };

    public static void InvokeFilter(TemplateLine templateLine, dynamic data)
    {
        Filters[templateLine.ValueFiltter](templateLine, data);
    }
}