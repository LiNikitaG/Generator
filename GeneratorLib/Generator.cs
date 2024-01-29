using GeneratorLib.Parsers;
using Newtonsoft.Json;

namespace GeneratorLib;

public class Generator
{
    public static string CreateHtml(string template, string jsonData)
    {
        var data = JsonConvert.DeserializeObject<dynamic>(jsonData);
        if (CustomParser.TryParse(template,out var stateTemp,out var error))
        {
            return CustomRender.Render(stateTemp, data);
        }

        return $"Error: {error}";
    }
}