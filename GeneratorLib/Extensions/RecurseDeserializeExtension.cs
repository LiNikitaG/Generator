using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeneratorLib.Extensions;

public static class RecurseDeserializeExtension
{
    public static void RecurseDeserialize(this Dictionary<string, object> result)
    {
        foreach (var keyValuePair in result.ToArray())
        {
            var jarray = keyValuePair.Value as JArray;

            if (jarray != null)
            {
                var dictionaries = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jarray.ToString()); 

                result[keyValuePair.Key] = dictionaries;

                foreach (var dictionary in dictionaries)
                {
                    RecurseDeserialize(dictionary);
                }
            }
        }
    }
}