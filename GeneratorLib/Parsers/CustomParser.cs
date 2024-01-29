using GeneratorLib.Enums;
using GeneratorLib.Models;
using GeneratorLib.Parsers.Statements;
using GeneratorLib.Parsers.Tags;
using GeneratorLib.Parsers.Values;

namespace GeneratorLib.Parsers;

public static class CustomParser
{
    public static bool TryParse(string template, out StateTemplate result, out string error)
    {
        try
        {
            var templateLines = Segmentation(template);
            result = CustomStateBuilder.BuildState(templateLines);
            error = null;
            return true;
        }
        catch (Exception ex)
        {
            error = ex.Message;
            result = null;
            return false;
        }
    }

    private static IList<TemplateLine> Segmentation(string template)
    {
        var templateLines = new List<TemplateLine>();
        var tempsArr = template.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
        var i = 0;

        foreach (var tempArr in tempsArr)
        {
            var newTemplateLine = new TemplateLine()
            {
                Index = i,
                CountIndentation = tempArr.Length - tempArr.TrimStart().Length,
                Value = tempArr.Trim()
            };
            SetType(newTemplateLine);
            templateLines.Add(newTemplateLine);
            i++;
        }

        return templateLines;
    }

    private static void SetType(TemplateLine tempLine)
    {
        if (tempLine.Value.Trim().Length == 0)
        {
            tempLine.Type = TemplateLineType.Empty;
            return;
        }

        if (StatementParser.IsMatch(tempLine.Value))
        {
            StatementParser.Init(tempLine);
            return;
        }

        if (ValueParser.IsMatch(tempLine.Value))
        {
            ValueParser.Init(tempLine);
            return;
        }

        if (TagParser.IsMatch(tempLine.Value))
        {
            TagParser.Init(tempLine);
            return;
        }

        throw new System.Exception($"Не удалось распарсить строку {tempLine.Index + 1}");
    }
}