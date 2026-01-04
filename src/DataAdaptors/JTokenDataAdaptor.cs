using Orbyss.Blazor.Syncfusion.DynamicGrid.Helpers;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interfaces;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.DataAdaptors;

public class JTokenDataAdaptor(IDynamicGridDataProvider dynamicGridDataProvider) : DataAdaptor
{
    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? additionalParam = null)
    {
        var result = await dynamicGridDataProvider.GetData(
            dataManagerRequest,
            HashBuilder.Build(dataManagerRequest.Where),
            HashBuilder.Build(dataManagerRequest.Sorted)
        );

        return new DataResult { Result = result.Data, Count = result.TotalDataSourceCount };
    }
}