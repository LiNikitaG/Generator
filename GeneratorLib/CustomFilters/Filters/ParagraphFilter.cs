using GeneratorLib.Models;

namespace GeneratorLib.CustomFilters.Filters;

public class ParagraphFilter
{
    public static void Paragraph(TemplateLine templateLine, dynamic data)
    {
        templateLine.ResultValue = templateLine.Value.Replace(templateLine.MatchValue,
            "\n\t" + templateLine.MatchValue);
    }
}