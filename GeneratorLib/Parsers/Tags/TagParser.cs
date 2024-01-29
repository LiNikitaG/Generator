using System.Text.RegularExpressions;
using GeneratorLib.Enums;
using GeneratorLib.Models;

namespace GeneratorLib.Parsers.Tags;

public class TagParser
{
    private static readonly string Pattern = @"\<(.*?)\>";

    public static bool IsMatch(string tempLine)
    {
        return Regex.Match(tempLine, Pattern).Success;
    }

    public static void Init(TemplateLine templateLine)
    {
        templateLine.Type = TemplateLineType.Tag;
        templateLine.MatchValue = Regex.Match(templateLine.Value, Pattern).Value;
    }
}