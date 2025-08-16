using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models
{
    public readonly record struct TableColumnItemLayout(
        [property: JsonProperty, JsonPropertyName("lines")] int? Lines,
        [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("alignment")] Alignment Alignment,
        [property: JsonProperty, JsonPropertyName("width")] string? Width
    );
}