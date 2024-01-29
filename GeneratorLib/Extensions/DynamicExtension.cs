using Newtonsoft.Json;

namespace GeneratorLib.Extensions;

public static class DynamicExtension
{
    public static dynamic ToDynamic(this object obj)
    {
        return JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(obj));
    }
}