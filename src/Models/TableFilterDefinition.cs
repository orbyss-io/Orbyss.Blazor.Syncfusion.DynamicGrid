using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

public readonly record struct TableFilterDefinition(
    [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("types")] FilterItemType[] Types,
    [property: JsonProperty, JsonPropertyName("rule")] FilterItemRule? Rule,
    [property: JsonProperty, JsonPropertyName("caseSensitive")] bool? CaseSensitive = null)
{
    public TableFilterDefinition(FilterItemType type, FilterItemRule rule, bool? caseSensitive = null)
        : this([type], rule, caseSensitive)
    {
    }
}

/// <summary>
/// Indicates whether the filter item type is added to the filter form, or whether the filter field is directly available on the header of the column
/// </summary>
[System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum FilterItemType
{
    Form,
    Header,
    SearchBar
}

[System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum FilterItemRule
{
    Contains,
    Equal,
    StartsWith,
    EndsWith,
    GreaterThan,
    GreaterThanOrEqual,
    LessThan,
    LessThanOrEqual
}