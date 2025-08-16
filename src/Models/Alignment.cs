using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models
{
    public readonly record struct Alignment(
        [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("horizontal")] HorizontalAlignment Horizontal,
        [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("vertical")] VerticalAlignment Vertical
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
}