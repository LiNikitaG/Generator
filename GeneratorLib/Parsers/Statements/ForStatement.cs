using GeneratorLib.Extensions;
using GeneratorLib.Models;

namespace GeneratorLib.Parsers.Statements;

public static class ForStatement
{
    public static readonly string Name = "for";
    public static readonly string[] Ignore = {"for", "in", "{%", "%}", "endfor"};

    public static string Render(StateTemplate state, dynamic data, Func<StateTemplate, dynamic, string> func)
    {
        var forStatementStart = state.StartResult.FirstOrDefault();
        var dataArr = data[forStatementStart.StatementCollection];
        var result = new List<string>();

        foreach (var item in dataArr)
        {
            var myDynamic = new System.Dynamic.ExpandoObject() as IDictionary<string, Object>;
            myDynamic.Add(forStatementStart.StatementVariable, item);
            result.Add(func(state.Inside, myDynamic.ToDynamic()));
        }

        return string.Join("\r\n", result);
    }
}