using Newtonsoft.Json.Linq;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interfaces;

public interface IColumnValueStringifier
{
    string StringifyColumn(DynamicColumn column, JToken rowToken);
}