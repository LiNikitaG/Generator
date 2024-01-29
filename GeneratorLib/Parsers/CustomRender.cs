using GeneratorLib.Enums;
using GeneratorLib.Models;
using GeneratorLib.Parsers.Statements;
using GeneratorLib.Parsers.Values;

namespace GeneratorLib.Parsers;

public static class CustomRender
{
    public static string Render(StateTemplate state, dynamic data)
    {
        if (state.StateType == StateTemplateType.TextSpan)
            return RenderTextSpan(state, data);

        return RenderStatement(state, data);
    }

    private static string RenderTextSpan(StateTemplate state, dynamic data)
    {
        ValueParser.SetValue(state.StartResult, data);
        ValueParser.SetValue(state.EndResult, data);

        var startStr = string.Join("\r\n", state.StartResult.Select(x => x.ResultValue));
        var endStr = state.EndResult != null ? string.Join("\r\n", state.EndResult.Select(x => x.ResultValue)) : null;

        string insStr = "";
        if (state.Inside != null)
            insStr = Render(state.Inside, data);

        return string.Join("\r\n", new[] {startStr, insStr, endStr}
            .Where(x => !string.IsNullOrWhiteSpace(x)));
    }

    private static string RenderStatement(StateTemplate state, dynamic data)
    {
        var render = Render;
        return StatementParser.Statements[state.StateType](state, data, render);
    }
}