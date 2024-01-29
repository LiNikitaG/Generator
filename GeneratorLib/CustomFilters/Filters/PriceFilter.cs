using Fluid;
using Fluid.Values;

namespace GeneratorLib.CustomFilters.Filters;

public static class PriceFilter
{
    public static ValueTask<FluidValue> Price(FluidValue input, FilterArguments arguments, TemplateContext context)
    {
        return new StringValue("$"+input.ToStringValue());
    }
}