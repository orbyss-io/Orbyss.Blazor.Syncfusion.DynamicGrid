using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models
{
    public sealed record TableColumns(
        [property: JsonProperty, JsonPropertyName("globalLayout")] TableColumnItemLayout? GlobalLayout,
        [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("items")] TableColumnItem[] Items
    );

    public sealed record TableColumnItem(
        [property: JsonProperty, JsonPropertyName("label")] string? Label,
        [property: JsonProperty, JsonPropertyName("i18n")] string? I18n,
        [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("scope")] string Scope,
        [property: JsonProperty, JsonPropertyName("layout")] TableColumnItemLayout? Layout,
        [property: JsonProperty, JsonPropertyName("sortable")] bool? Sortable,
        [property: JsonProperty, JsonPropertyName("filter")] TableFilterDefinition? Filter
    );
}