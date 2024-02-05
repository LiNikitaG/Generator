using System.Text.RegularExpressions;
using GeneratorLib.CustomFilters;
using GeneratorLib.Enums;
using GeneratorLib.Models;

namespace GeneratorLib.Parsers.Values;

public static class ValueParser
{
    private static readonly string Pattern = @"\{\{(.*?)\}\}";
    private static readonly string[] Ignore = new[] {"|",};

    public static bool IsMatch(string tempLine)
    {
        var t = Regex.Match(tempLine.Trim(), Pattern);
        return t.Success;

    }

    public static void Init(TemplateLine templateLine)
    {
        var match = Regex.Match(templateLine.Value, Pattern);
        var arr = match.Value.Trim('{', '}').Split(" ")
            .Where(x => !string.IsNullOrWhiteSpace(x) && !Ignore.Contains(x))
            .ToArray();

        templateLine.MatchValue = match.Value;
        templateLine.Type = TemplateLineType.Value;
        templateLine.ValueProperties = arr.First().Split(".");
        templateLine.ValueFiltter = arr.Length > 1 ? arr.Last() : null;
    }

    public static void SetValue(IList<TemplateLine>? templateLine, dynamic data)
    {
        if (templateLine == null)
            return;

        foreach (var item in templateLine.Where(x => x.Type == TemplateLineType.Value))
        {
            dynamic val = data;

            foreach (var prop in item.ValueProperties)
                val = val[prop];

            if (item.ValueFiltter != null)
                CustomFilter.InvokeFilter(item, data);

            item.ResultValue = item.ResultValue.Replace(item.MatchValue, val.ToString());
        }
    }

    public static void SetDefault(IList<TemplateLine>? templateLine)
    {
        if (templateLine == null)
            return;

        foreach (var item in templateLine)
        {
            item.ResultValue = item.Value;
        }
    }
}