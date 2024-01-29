using GeneratorLib.Enums;

namespace GeneratorLib.Models;

public class StateTemplate
{
    public IList<TemplateLine> StartResult { get; set; }
    public StateTemplate Inside { get; set; }
    public IList<TemplateLine> EndResult { get; set; }
    
    public StateTemplateType  StateType { get; set; }

}