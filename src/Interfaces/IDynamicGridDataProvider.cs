using Newtonsoft.Json.Linq;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;
using Syncfusion.Blazor;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interfaces
{
    public interface IDynamicGridDataProvider
    {
        /// <summary>
        /// Retrieves data to populate the <see cref="DynamicSfGrid"/>.
        /// </summary>
        /// <param name="request">
        /// Contains the specifications to filter, sort, and serve the right portion of data.
        /// </param>
        /// <param name="whereFilterHash">
        /// Hash of the where filter; changes whenever any of the filter values changes. As long as the hash remains the same, the user is
        /// scrolling through the same filtered data set
        /// </param>
        /// <param name="sortOrderHash">
        /// Hash of the sort order; changes when the sorting order has changed
        /// </param>
        /// <returns>
        /// <see cref="DynamicGridDataProviderResult"/> including the total count of the data source and a list of <see cref="JToken"/>
        /// </returns>
        Task<DynamicGridDataProviderResult> GetData(DataManagerRequest request, string? whereFilterHash, string? sortOrderHash);
    }
}