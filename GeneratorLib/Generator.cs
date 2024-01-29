using Fluid;
using GeneratorLib.CustomFilters;
using GeneratorLib.Extensions;
using Newtonsoft.Json;

namespace GeneratorLib;

public class Generator
{
    public static string CreateHtml(string template, string jsonData)
    {
        RegisterFilters.RegisterCustomFilters();

        var dataOb = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
        dataOb?.RecurseDeserialize();

        var parser = new FluidParser();
        if (parser.TryParse(template, out var template1, out var error))
        {
            var context = new TemplateContext(dataOb);
            return template1.Render(context);
        }

        return $"Error: {error}";
    }
}