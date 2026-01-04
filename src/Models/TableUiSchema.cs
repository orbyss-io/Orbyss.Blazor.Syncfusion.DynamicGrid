using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

public sealed record TableUiSchema(
    [property: JsonProperty, System.Text.Json.Serialization.JsonRequired, Newtonsoft.Json.JsonRequired, JsonPropertyName("columns")] TableColumns Columns,
    [property: JsonProperty, JsonPropertyName("label")] string? Label,
    [property: JsonProperty, JsonPropertyName("i18n")] string? I18N,
    [property: JsonProperty, JsonPropertyName("initialOrdering")] InitialOrdering? InitialOrdering
);