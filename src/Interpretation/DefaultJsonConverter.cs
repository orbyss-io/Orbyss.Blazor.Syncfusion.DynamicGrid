using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;

public static class DefaultJsonConverter
{
    public static TValue Deserialize<TValue>(string json)
    {
        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new StringEnumConverter());
        return JsonConvert.DeserializeObject<TValue>(json, settings)!;
    }

    public static string Serialize(object @object)
    {
        var contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
        var settings = new JsonSerializerSettings
        {
            ContractResolver = contractResolver
        };
        settings.Converters.Add(new StringEnumConverter());
        return JsonConvert.SerializeObject(@object, settings)!;
    }
}