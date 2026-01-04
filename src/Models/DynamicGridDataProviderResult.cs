using Newtonsoft.Json.Linq;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

public sealed record DynamicGridDataProviderResult(
    IEnumerable<JToken> Data,
    int TotalDataSourceCount
);