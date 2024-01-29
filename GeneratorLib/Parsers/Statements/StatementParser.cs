using System.Text.RegularExpressions;
using GeneratorLib.Enums;
using GeneratorLib.Models;

namespace GeneratorLib.Parsers.Statements;

public static class StatementParser
{
    private static readonly string Pattern = @"\{\%(.*?)\%\}";

    public static readonly
        Dictionary<StateTemplateType, Func<StateTemplate, dynamic, Func<StateTemplate, dynamic, string>, string>>
        Statements = new()
        {
            {StateTemplateType.ForStatement, ForStatement.Render}
        };

    public static bool IsMatch(string tempLine)
    {
        return Regex.Match(tempLine, Pattern).Success;
    }

    public static void Init(TemplateLine templateLine)
    {
        var match = Regex.Match(templateLine.Value, Pattern);
        var arr = match.Value.Split(" ")
            .Where(x => !string.IsNullOrWhiteSpace(x));

        if (arr.Contains(ForStatement.Name))
        {
            arr = arr.Where(x => !ForStatement.Ignore.Contains(x));
            templateLine.StatementType = StateTemplateType.ForStatement;
        }

        templateLine.MatchValue = match.Value;
        templateLine.Type = TemplateLineType.Statement;
        templateLine.StatementVariable = arr.FirstOrDefault();
        templateLine.StatementCollection = arr.LastOrDefault();
    }
}