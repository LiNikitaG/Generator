using GeneratorLib.Enums;

namespace GeneratorLib.Models;

public class TemplateLine
{
    public int Index { get; set; }
    public int CountIndentation { get; set; }
    public string Value { get; set; }
    public string MatchValue { get; set; }
    public string ResultValue { get; set; }
    public TemplateLineType Type { get; set; }
    
    public string StatementCollection { get; set; }
    public string StatementVariable { get; set; }
    public StateTemplateType  StatementType { get; set; }

    public string[] ValueProperties { get; set; }
    public string? ValueFiltter { get; set; }
}