using Newtonsoft.Json.Schema;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interfaces;

public interface IDynamicColumnBuilder
{
    DynamicColumn[] BuildDynamicColumns(JSchema itemsJsonSchema);

    DynamicColumn[] BuildDynamicColumns(TableUiSchema tableUiSchema, JSchema itemsJsonSchema);
}