using GeneratorLib.Enums;
using GeneratorLib.Models;

namespace GeneratorLib.Parsers;

public static class CustomStateBuilder
{
    public static StateTemplate BuildState(IList<TemplateLine> templateLines)
    {
        if (templateLines.First().Type == TemplateLineType.Statement)
            return BuildStatementState(templateLines);

        return BuildTextState(templateLines);
    }

    private static StateTemplate BuildTextState(IList<TemplateLine> templateLines)
    {
        var state = new StateTemplate();
        var statementTempStart = templateLines.FirstOrDefault(x => x.Type == TemplateLineType.Statement);

        if (statementTempStart == null)
        {
            state.StartResult = templateLines;
            return state;
        }

        var statementTempEnd = templateLines.Skip(statementTempStart.Index + 1)
            .First(x => x.CountIndentation == statementTempStart.CountIndentation
                        && x.Type == TemplateLineType.Statement);

        state.StartResult = templateLines.Take(statementTempStart.Index).ToList();
        state.EndResult = templateLines.Skip(statementTempEnd.Index + 1).ToList();
        state.Inside = BuildStatementState(templateLines.Skip(statementTempStart.Index)
            .Take(statementTempEnd.Index + 1 - statementTempStart.Index).ToList());
        state.StateType = StateTemplateType.TextSpan;

        return state;
    }

    private static StateTemplate BuildStatementState(IList<TemplateLine> templateLines)
    {
        var state = new StateTemplate();

        state.StartResult = templateLines.Take(1).ToList();
        state.EndResult = templateLines.Skip(templateLines.Count - 1).Take(1).ToList();
        state.Inside = BuildState(templateLines.Skip(1).Take(templateLines.Count - 2).ToList());
        state.StateType = state.StartResult.FirstOrDefault().StatementType;

        return state;
    }
}