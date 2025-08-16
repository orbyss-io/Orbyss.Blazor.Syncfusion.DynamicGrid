using Newtonsoft.Json.Schema;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Grids;

namespace Orbyss.Blazor.Syncfusion.DynamicGrid.Helpers
{
    public class DynamicColumnBuilder(ITableUiSchemaInterpreter interpreter, IColumnTypeProvider columnTypeProvider, IJsonPathInterpreter jsonPathInterpreter)
    {
        internal DynamicColumn[] BuildDynamicColumns(TableUiSchema tableUiSchema, JSchema itemsJsonSchema)
        {
            var result = new List<DynamicColumn>();

            foreach (var column in tableUiSchema.Columns.Items)
            {
                var scope = interpreter.InterpretScope(column.Scope);
                var label = interpreter.InterpretLabel(column.I18n, column.Label);
                var width = GetColumnWidth(tableUiSchema, column);
                if(string.IsNullOrWhiteSpace(width))
                {
                    width = "150";
                }
                var columnType = columnTypeProvider.GetColumnType(itemsJsonSchema, scope.AbsoluteSchemaJsonPath);

                var dynamicColumn = new DynamicColumn(
                    columnType,
                    scope,
                    jsonPathInterpreter.FromSchemaPath(scope.AbsoluteSchemaJsonPath),
                    label,                    
                    ParseRule(column.Filter?.Rule),
                    width,
                    GetEnumConfiguration(columnType),                    
                    null,
                    GetTextAlign(tableUiSchema, column),                    
                    null,
                    column.Sortable ?? false,
                    column.Filter?.Types?.Contains(FilterItemType.Header) == true
                );

                result.Add(dynamicColumn);
            }

            return [.. result];
        }

        static string? GetColumnWidth(TableUiSchema tableUiSchema, TableColumnItem column)
        {
            if(string.IsNullOrWhiteSpace(column.Layout?.Width))
            {
                return tableUiSchema.Columns.GlobalLayout?.Width;
            }

            return column.Layout?.Width;
        }

        private static Operator? ParseRule(FilterItemRule? rule)
        {
            if (!rule.HasValue)
            {
                return null;
            }

            if (Enum.TryParse<Operator>(rule.ToString(), true, out var result))
            {
                return result;
            }

            throw new NotSupportedException($"'{rule}' rule is not supported.");
        }

        private static TextAlign GetTextAlign(TableUiSchema tableSchema, TableColumnItem column)
        {
            HorizontalAlignment horizontalAlignment;
            if (column.Layout.HasValue)
            {
                horizontalAlignment = column.Layout.Value.Alignment.Horizontal;
            }
            else
            {
                horizontalAlignment = tableSchema.Columns.GlobalLayout?.Alignment.Horizontal ?? HorizontalAlignment.Center;
            }

            return Enum.TryParse<TextAlign>($"{horizontalAlignment}", true, out var result)
                ? result
                : TextAlign.Center;
        }

        private static DynamicColumnEnumConfiguration? GetEnumConfiguration(TableColumnType tableColumnType)
        {
            if (tableColumnType is TableColumnType.Enum)
            {
                return new(false);
            }

            if (tableColumnType is TableColumnType.EnumList)
            {
                return new(true);
            }

            return null;
        }
    }
}