using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models
{
    public sealed record InitialOrdering(
        [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("scope")] string Scope,
        [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("direction")] InitialOrderingDirection Direction
    );

    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum InitialOrderingDirection
    {
        Ascending,
        Descending
    }
}