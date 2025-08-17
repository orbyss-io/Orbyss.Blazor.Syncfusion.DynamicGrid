using Newtonsoft.Json.Linq;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Extensions;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interfaces;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Grids;

namespace Syncfusion.DynamicGrid.Demo
{
    internal class MockDynamicGridDataProvider : IDynamicGridDataProvider
    {
        private readonly JArray array = JArray.Parse(ExampleConstants.Data);

        public Task<DynamicGridDataProviderResult> GetData(DataManagerRequest request, string? whereFilterHash, string? sortOrderHash)
        {
            var items = array.Where(token =>
            {
                var result = request.Where?.All(where =>
                {
                    return where?.MatchesItem(token) != false;
                });

                return result != false;
            });

            if (request.Skip > 0 || request.Take > 0)
            {
                items = items
                    .Skip(request.Skip)
                    .Take(request.Take);
            }

            if (request.Sorted?.Count > 0)
            {
                var sorted = request.Sorted[0];
                IOrderedEnumerable<JToken> ordered;

                if (sorted.Direction.Equals(nameof(SortDirection.Descending), StringComparison.OrdinalIgnoreCase))
                {
                    ordered = items.OrderByDescending(x => $"{x.SelectToken(sorted.Name)}");
                }
                else
                {
                    ordered = items.OrderBy(x => $"{x.SelectToken(sorted.Name)}");
                }

                items = ordered;
            }

            var result = new DynamicGridDataProviderResult(
                items,
                array.Count
            );

            return Task.FromResult(result);
        }
    }
}