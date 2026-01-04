using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

public readonly record struct Alignment(
    [property: JsonProperty, JsonPropertyName("horizontal")] HorizontalAlignment Horizontal = HorizontalAlignment.Left,
    [property: JsonProperty, JsonPropertyName("vertical")] VerticalAlignment Vertical = VerticalAlignment.Center
);

[System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum HorizontalAlignment
{
    Center,
    Left,
    Right
}

[System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
public enum VerticalAlignment
{
    Center,
    Top,
    Bottom
}