using Fluid;
using GeneratorLib.CustomFilters.Filters;

namespace GeneratorLib.CustomFilters;

public static class RegisterFilters
{
    public static void RegisterCustomFilters()
    {
        TemplateOptions.Default.Filters.AddFilter("price", PriceFilter.Price);
        TemplateOptions.Default.Filters.AddFilter("paragraph", ParagraphFilter.Paragraph);
    }
}