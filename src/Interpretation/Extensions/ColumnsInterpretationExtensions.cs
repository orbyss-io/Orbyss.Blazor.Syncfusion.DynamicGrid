using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;
using Syncfusion.Blazor.Grids;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation.Extensions
{
    public static class ColumnsInterpretationExtensions
    {
        internal static ColumnType ToSfColumnType(this TableColumnType tableColumnType, DynamicColumnAdditionalConfiguration? otherConfig)
        {
            return tableColumnType switch
            {
                TableColumnType.Text => ColumnType.String,
                TableColumnType.Number => ColumnType.Double,
                TableColumnType.Integer => ColumnType.Integer,
                TableColumnType.DateOnly => ColumnType.DateOnly,
                TableColumnType.DateTime => ColumnType.DateTime,
                TableColumnType.DateTimeTicks => ColumnType.Long,
                TableColumnType.DateOnlyTicks => ColumnType.Long,
                TableColumnType.Boolean => otherConfig?.RenderBooleanAsCheckbox == true
                    ? ColumnType.CheckBox
                    : ColumnType.Boolean,

                _ => throw new NotSupportedException($"Table column type '{tableColumnType}' is not supported")
            };
        }
    }
}