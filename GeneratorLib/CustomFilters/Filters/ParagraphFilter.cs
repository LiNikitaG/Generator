using Fluid;
using Fluid.Values;

namespace GeneratorLib.CustomFilters.Filters;

public class ParagraphFilter
{
    public static ValueTask<FluidValue> Paragraph(FluidValue input, FilterArguments arguments, TemplateContext context)
    {
        return new StringValue("\n\t" + input.ToStringValue());
    }
}